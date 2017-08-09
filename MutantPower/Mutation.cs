using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;

namespace MutantPower
{
    public static class Mutation
    {
        public static void MutationOperation(Instruction instruction, string operation)
        {
            switch (operation)
            {
                case "++":
                    {
                        if (instruction.OpCode == OpCodes.Add)
                            instruction.OpCode = OpCodes.Sub;

                        else if (instruction.OpCode == OpCodes.Sub)
                            instruction.OpCode = OpCodes.Add;
                        break;
                    }
                case "--":
                    {
                        if (instruction.OpCode == OpCodes.Sub)
                            instruction.OpCode = OpCodes.Add;

                        else if (instruction.OpCode == OpCodes.Add)
                            instruction.OpCode = OpCodes.Sub;
                        break;
                    }
                case "true":
                    {
                        if (instruction.OpCode == OpCodes.Brtrue_S)
                            instruction.OpCode = OpCodes.Brfalse_S;

                        else if (instruction.OpCode == OpCodes.Brfalse_S)
                            instruction.OpCode = OpCodes.Brtrue_S;
                        break;
                    }
                case "false":
                {
                    if (instruction.OpCode == OpCodes.Brfalse_S)
                        instruction.OpCode = OpCodes.Brtrue_S;

                    else if (instruction.OpCode == OpCodes.Brtrue_S)
                        instruction.OpCode = OpCodes.Brfalse_S;
                    break;
                }
                default:
                    {
                        break;
                    }
            }
        }

        public static void MutateInstructionForMethod(ModuleDefinition module, string method, string operation)
        {
            foreach (var typeDefinition in module.Types)
            {
                if (typeDefinition.IsInterface)
                    continue;

                MethodDefinition methodDef = typeDefinition.Methods.Where(m => m.Name == method).Select(m => m).SingleOrDefault();
                if (methodDef != null)
                    foreach (var instruction in methodDef.Body.Instructions)
                    {
                        MutationOperation(instruction, operation);
                    }
            }
        }

        public static void WriteMutatedDllToDisk(ModuleDefinition module, string inputAssembly, string method, string path)
        {
            module.Name = Path.GetFileName(inputAssembly);

            var temporaryFileName = Path.Combine(path, string.Format("{0}_temp{1}_{2})", Path.GetFileNameWithoutExtension(inputAssembly),
                method,
                Path.GetExtension(inputAssembly)));
            var backupFileName = Path.Combine(path, string.Format("{0}_backup{1}_{2}", Path.GetFileNameWithoutExtension(inputAssembly),
                method,
                Path.GetExtension(inputAssembly)));

            module.Write(temporaryFileName);
            File.Replace(temporaryFileName, inputAssembly, backupFileName);
        }

        public static void MutationDLLByMethodInstructionOperation(string dll, string method, string operation)
        {
            if (string.IsNullOrWhiteSpace(dll) || string.IsNullOrWhiteSpace(method) || string.IsNullOrWhiteSpace(operation))
            {
                throw new ArgumentNullException();
            }

            var inputAssembly = dll;
            var path = Path.GetDirectoryName(inputAssembly);

            var module = ModuleDefinition.ReadModule(inputAssembly);
           
            MutateInstructionForMethod(module, method, operation);
            WriteMutatedDllToDisk(module, inputAssembly, method, path);
        }
    }
}

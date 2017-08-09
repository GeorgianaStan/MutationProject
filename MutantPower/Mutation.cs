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
                default:
                    {
                        break;
                    }
            }
        }

        public static void MutationDLLByMethodInstructionOperation(string dll, string method, string operation)
        {
            var inputAssembly = dll;
            var path = Path.GetDirectoryName(inputAssembly);

            var module = ModuleDefinition.ReadModule(inputAssembly);
            foreach (var typeDefinition in module.Types)
            {
                if (typeDefinition.IsInterface)
                    continue;

                foreach (var methodDefinition in typeDefinition.Methods)
                {
                    if (methodDefinition.Name == method)
                    {
                        foreach (var instruction in methodDefinition.Body.Instructions)
                        {
                            MutationOperation(instruction, operation);
                        }
                    }
                }
            }

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
    }
}

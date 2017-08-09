using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace MutantPower
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mutation.MutationDLLByMethodInstructionOperation(args[0], "AddUnit", "++");
            Mutation.MutationDLLByMethodInstructionOperation(args[0], "SubUnit", "--");
            Mutation.MutationDLLByMethodInstructionOperation(args[0], "Greater", "true");
            Mutation.MutationDLLByMethodInstructionOperation(args[0], "Lower", "false");
            //LessThanOrEqual
            //GreaterThanOrEqual
            //ReplaceZeroWith257
        }
    }
}
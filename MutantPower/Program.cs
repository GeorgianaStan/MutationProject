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
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "SuvUnit", "++");
            //LessThanOrEqual
            //GreaterThanOrEqual
            //ReplaceZeroWith257
        }
    }
}
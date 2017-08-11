namespace MutantPower
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "AddUnit", "++");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "SubUnit", "--");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "Greater", "true");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "Lower", "false");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "ReplaceZeroWith257", "zerowith257");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "Replace257WithZero", "Replace257WithZero");
            Mutation.MutationDLLByMethodInstructionOperation(args[0], "ReplaceStringGeorgianaToAnotherString", "ReplaceStringGeorgianaToAnotherString");
            //Mutation.MutationDLLByMethodInstructionOperation(args[0], "ReplaceStringToBool", "ReplaceStringToBool");
            
        }
    }
}
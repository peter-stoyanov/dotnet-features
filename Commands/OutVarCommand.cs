
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class OutVarCommand : BaseCommand
    {
        protected override bool isActive => false;

        public OutVarCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            InlineOutVariable();
            InlineOutVariableDiscarded();

            return CommandResult.Success;
        }

        private void InlineOutVariable()
        {
            string numberAsString = "1640";

            if (int.TryParse(numberAsString, out int result))
                Console.WriteLine(result);
            else
                Console.WriteLine("Could not parse input");
        }

        private void InlineOutVariableDiscarded()
        {
            string numberAsString = "1640";

            if (int.TryParse(numberAsString, out var _))
                Console.WriteLine("Success");
            else
                Console.WriteLine("Could not parse input");
        }
    }
}
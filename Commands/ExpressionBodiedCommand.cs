
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class ExpressionBodiedCommand : BaseCommand
    {
        protected override bool isActive => false;

        public ExpressionBodiedCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            ThrowExpression();

            return CommandResult.Success;
        }

        private void ThrowExpression()
        {
            string input = null;

            try
            {
                // nameof = whenever you need the name of a variable, a property, or a member field
                var result = input ?? throw new ArgumentException("Cannot be blank", paramName: nameof(input));
            }
            catch (System.Exception ex)
            {
                UI.WriteMessage(ex.ToString());
            }
        }
    }

    public class ExpressionMembersExample
    {
        // Expression-bodied constructor
        public ExpressionMembersExample(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~ExpressionMembersExample() => Console.Error.WriteLine("Finalized!");

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }

        public override string ToString() => $"{Label}.";

        public string FullName => $"{Label}";
    }
}
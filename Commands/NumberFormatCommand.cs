
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class NumberFormatCommand : BaseCommand
    {
        protected override bool isActive => false;
        public NumberFormatCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            return CommandResult.Success;
        }
    }
}

using System;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public abstract class BaseCommand
    {
        protected virtual bool isActive => false;

        protected IUserInterface UI { get; set; }

        protected BaseCommand(IUserInterface userInteface)
        {
            UI = userInteface;
        }

        public CommandResult RunCommand()
        {
            try
            {
                if (isActive)
                {
                    UI.WriteMessage($"Executing {this.GetType().Name}.");

                    return InternalCommand();
                }
                else
                {
                    return CommandResult.Suspended;
                }
            }
            catch (Exception exception)
            {
                UI.WriteWarning($"Error while executing {this.GetType().Name}.");
                UI.WriteWarning(exception.ToString());

                return CommandResult.Error;
            }
        }

        protected abstract CommandResult InternalCommand();
    }
}
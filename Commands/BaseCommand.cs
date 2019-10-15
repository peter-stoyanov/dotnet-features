
using System;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public abstract class BaseCommand
    {
        protected virtual bool isActive => false;

        protected IUserInterface Interface { get; }

        protected BaseCommand(IUserInterface userInteface)
        {
            Interface = userInteface;
        }

        public CommandResult RunCommand()
        {
            try
            {
                if (isActive)
                {
                    Interface.WriteMessage($"Executing {nameof(BaseCommand)}.");

                    return InternalCommand();
                }
                else
                {
                    return CommandResult.Suspended;
                }
            }
            catch (Exception exception)
            {
                Interface.WriteWarning($"Error while executing {nameof(BaseCommand)}.");
                Interface.WriteWarning(exception.ToString());

                return CommandResult.Error;
            }
        }

        protected abstract CommandResult InternalCommand();
    }
}
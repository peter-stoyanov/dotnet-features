using System;
using dotnet_features.Commands;
using dotnet_features.UserInterface;
using dotnet_features.Utils;

namespace dotnet_features
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new ConsoleUserInterface();

            try
            {
                userInterface.WriteMessage("Starting ...");

                var commands = ReflectiveEnumerator.GetEnumerableOfType<BaseCommand>(new object[] { userInterface });

                foreach (BaseCommand command in commands)
                {
                    command.RunCommand();
                }
            }
            catch (Exception ex)
            {
                userInterface.WriteWarning(ex.ToString());
            }
            finally
            {
                userInterface.WriteMessage("Finished!");
            }
        }

        // static IEnumerable<BaseCommand> GetCommands(params object[] constructorArgs)
        // {
        //     var types = Assembly.
        //         GetAssembly(typeof(BaseCommand))
        //         .GetTypes()
        //         .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BaseCommand)));

        //     var commands = new List<BaseCommand>();

        //     foreach (Type type in types)
        //     {
        //         commands.Add((BaseCommand)Activator.CreateInstance(typeof(BaseCommand), constructorArgs));
        //     }

        //     return commands;
        // }
    }
}

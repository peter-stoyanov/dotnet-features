
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class OtherFeauresCommand : BaseCommand
    {
        protected override bool isActive => false;

        public OtherFeauresCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            NullConditional();
            ExceptionFilter();
            NullCoalescingAssignment();

            return CommandResult.Success;
        }

        private void NullConditional()
        {
            var person = new Person();

            var result = person?.FirstName ?? "Unspecified";

            UI.WriteMessage(result);
        }

        class Person
        {
            public string FirstName { get; set; }
        }

        private void DictionaryInit()
        {
            var webErrors = new Dictionary<int, string>
            {
                [404] = "Page not Found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };
        }

        public void ExceptionFilter()
        {
            try
            {
                throw new Exception("301");
            }
            catch (Exception e) when (e.Message.Contains("301"))
            {
                UI.WriteMessage("Site Moved");
            }
        }

        public void NullCoalescingAssignment()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            UI.WriteMessage(string.Join(" ", numbers));  // output: 17 17
            UI.WriteMessage(i.ToString());  // output: 17
        }
    }
}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class RangesCommand : BaseCommand
    {
        protected override bool isActive => false;

        public RangesCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            IndexStruct();
            RangeStruct();
            Task.Run(async () => await GetBigResultsAsync()).Wait();
            return CommandResult.Success;
        }

        private void IndexStruct()
        {
            Index i1 = 3;  // number 3 from beginning
            Index i2 = ^4; // number 4 from end

            // Note: the start index is inclusive (included to the slice), and the end index is exclusive (excluded from the slice).

            int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            UI.WriteMessage($"{a[i1]}, {a[i2]}"); // "3, 6"
        }

        private void RangeStruct()
        {
            Index i1 = new Index(3, fromEnd: false);  // number 3 from beginning
            Index i2 = ^4; // number 4 from end

            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var slice = array[i1..i2]; // { 3, 4, 5 }

            UI.WriteMessage($"{string.Join(", ", slice)}");

            var slice1 = array[4..^2];
            var slice2 = array[..3];
            var slice3 = array[2..];
            var slice4 = array[..];

            UI.WriteMessage($"{string.Join(", ", slice4)}");

            UI.WriteMessage($"arr[] and arr[..] slice are the same object: {array == array[..]}");
        }

        private async Task GetBigResultsAsync()
        {
            await foreach(var dataPoint in FetchIOTData())
            {
                UI.WriteMessage(dataPoint.ToString());
            }
        }

        private async IAsyncEnumerable<int> FetchIOTData()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000); // Simulate waiting for data to come through.
                yield return i;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class TuplesCommand : BaseCommand
    {
        protected override bool isActive => true;

        public TuplesCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            var inventory = Stocktake(GetWeapons());
            UI.WriteMessage(inventory.Item1.ToString());
            UI.WriteMessage(inventory.Item2.ToString());

            var inventory2 = StocktakeNew(GetWeapons());
            UI.WriteMessage(inventory2.weight.ToString());
            UI.WriteMessage(inventory2.count.ToString());

            var tuple1 = (0, 0);
            var tuple2 = (x: 0, y: 0);
            var tuple3 = (x: tuple2.x, y: tuple1.Item2);

            tuple2.x = 5; // mutable ??, well it seems so

            var (x, y) = StocktakeNew(GetWeapons());

            return CommandResult.Success;
        }

        public IEnumerable<IWeapon> GetWeapons()
        {
            yield return new Weapon { Weight = 3 };
            yield return new Weapon { Weight = 5 };
            yield return new Weapon { Weight = 4 };
        }

        public Tuple<int, int> Stocktake(IEnumerable<IWeapon> weapons)
        {
            var weight = 0;
            var count = 0;
            foreach (var weapon in weapons)
            {
                weight += weapon.Weight;
                count++;
            }

            return new Tuple<int, int>(weight, count);
        }

        public (int weight, int count) StocktakeNew(IEnumerable<IWeapon> weapons)
        {
            var weight = 0;
            var count = 0;
            foreach (var weapon in weapons)
            {
                weight += weapon.Weight;
                count++;
            }

            return (weight, count);
        }
    }

    public interface IWeapon
    {
        int Weight { get; set; }
    }

    public class Weapon : IWeapon
    {
        public int Weight { get; set; }
    }
}
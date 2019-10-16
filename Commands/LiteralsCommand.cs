
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_features.UserInterface;

namespace dotnet_features.Commands
{
    public class LiteralsCommand : BaseCommand
    {
        protected override bool isActive => false;

        public LiteralsCommand(IUserInterface userInteface) : base(userInteface)
        {
        }

        protected override CommandResult InternalCommand()
        {
            BinaryLiteral();
            DigitSeparator();

            return CommandResult.Success;
        }

        private void BinaryLiteral()
        {
            // Represent 50 in decimal, hexadecimal & binary
            int a = 50; // decimal representation of 50
            int b = 0X32; // hexadecimal representation of 50
            int c = 0B110010; //binary representation of 50

            //Represent 100 in decimal, hexadecimal & binary
            int d = 50 * 2; // decimal represenation of 100
            int e = 0x32 * 2; // hexadecimal represenation of 100
            int f = 0b110010 * 2; //binary represenation of 100

            UI.WriteMessage($"a: {a:0000} b: {b:0000} c: {c:0000}");
            UI.WriteMessage($"d: {d:0000} e: {e:0000} f: {f:0000}");
        }

        private void DigitSeparator()
        {
            int binaryData = 0B0010_0111_0001_0000; // binary value of 10000
            int hexaDecimalData = 0X2B_67; //HexaDecimal Value of 11,111
            int decimalData = 104_567_789;
            int myCustomData = 1___________2__________3___4____5_____6;
            double realdata = 1_000.111_1e1_00;

            UI.WriteMessage(@$"
                binaryData :{binaryData}
                hexaDecimalData: {hexaDecimalData}
                decimalData: {decimalData}
                myCustomData: {myCustomData}
                realdata: {realdata}");
        }
    }
}
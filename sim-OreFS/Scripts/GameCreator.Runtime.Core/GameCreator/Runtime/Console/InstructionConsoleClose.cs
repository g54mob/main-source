using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace GameCreator.Runtime.Console
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Console Close")]
	[Description("Closes the Runtime Console")]
	[Category("Debug/Console/Console Close")]
	[Keywords(new string[] { "Terminal", "Log", "Debug" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.Blue, typeof(OverlayMinus))]
	public class InstructionConsoleClose : Instruction
	{
		public override string Title => "Close Console";

		protected override Task Run(Args args)
		{
			Console.Close();
			return Instruction.DefaultResult;
		}
	}
}

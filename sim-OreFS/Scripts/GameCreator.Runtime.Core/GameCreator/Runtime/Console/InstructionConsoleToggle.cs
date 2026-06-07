using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace GameCreator.Runtime.Console
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Console Toggle")]
	[Description("Toggles the Runtime Console")]
	[Category("Debug/Console/Console Toggle")]
	[Keywords(new string[] { "Terminal", "Log", "Debug" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.Blue)]
	public class InstructionConsoleToggle : Instruction
	{
		public override string Title => "Toggle Open/Close Console";

		protected override Task Run(Args args)
		{
			Console.Toggle();
			return Instruction.DefaultResult;
		}
	}
}

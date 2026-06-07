using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace GameCreator.Runtime.Console
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Console Open")]
	[Description("Opens the Runtime Console")]
	[Category("Debug/Console/Console Open")]
	[Keywords(new string[] { "Terminal", "Log", "Debug" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.Blue, typeof(OverlayPlus))]
	public class InstructionConsoleOpen : Instruction
	{
		public override string Title => "Open Console";

		protected override Task Run(Args args)
		{
			Console.Open();
			return Instruction.DefaultResult;
		}
	}
}

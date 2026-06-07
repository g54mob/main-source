using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Clear Console")]
	[Description("Clears the console in a development or Editor build")]
	[Category("Debug/Clear Console")]
	[Keywords(new string[] { "Debug", "Terminal" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCommonDebugConsoleClear : Instruction
	{
		public override string Title => "Clear Console";

		protected override Task Run(Args args)
		{
			Debug.ClearDeveloperConsole();
			return Instruction.DefaultResult;
		}
	}
}

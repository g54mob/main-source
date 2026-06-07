using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Quit Application")]
	[Description("Closes the application and exits the program. This instruction is ignored in the Unity Editor or WebGL platforms")]
	[Category("Application/Quit Application")]
	[Keywords(new string[] { "Exit", "Close", "Shutdown", "Turn" })]
	[Image(typeof(IconExit), ColorTheme.Type.Blue)]
	public class InstructionAppQuit : Instruction
	{
		public override string Title => "Quit Application";

		protected override Task Run(Args args)
		{
			Application.Quit();
			return Instruction.DefaultResult;
		}
	}
}

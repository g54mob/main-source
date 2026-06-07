using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Toggle Console")]
	[Description("Shows or hides the Console in a standalone development build")]
	[Category("Debug/Toggle Console")]
	[Keywords(new string[] { "Debug", "Terminal" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.TextLight)]
	public class InstructionCommonDebugConsoleToggle : Instruction
	{
		private enum Option
		{
			Show = 0,
			Hide = 1
		}

		[SerializeField]
		private Option m_Option;

		public override string Title => $"{m_Option} Console";

		protected override Task Run(Args args)
		{
			Debug.developerConsoleEnabled = true;
			Debug.developerConsoleVisible = m_Option == Option.Show;
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Console Command")]
	[Description("Submits a Command onto the Runtime Console")]
	[Category("Debug/Console/Console Command")]
	[Parameter("Command", "The command message to submit")]
	[Keywords(new string[] { "Debug", "Log", "Terminal", "Submit", "Send", "Execute", "Run" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionConsoleSubmit : Instruction
	{
		[SerializeField]
		private PropertyGetString m_Command = new PropertyGetString("run name Actions");

		public override string Title => $"Submit: {m_Command}";

		public InstructionConsoleSubmit()
		{
		}

		public InstructionConsoleSubmit(string text)
		{
			m_Command = new PropertyGetString(text);
		}

		protected override Task Run(Args args)
		{
			string text = m_Command.Get(args);
			if (string.IsNullOrEmpty(text))
			{
				return Instruction.DefaultResult;
			}
			Console.Open();
			Console.Submit(new Input(text));
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Console
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Console Text")]
	[Description("Prints a message to the Runtime Console")]
	[Category("Debug/Console/Console Text")]
	[Parameter("Message", "The text message to log")]
	[Keywords(new string[] { "Debug", "Log", "Print", "Show", "Display", "Name", "Test", "Message", "String", "Terminal" })]
	[Image(typeof(IconTerminal), ColorTheme.Type.Green)]
	public class InstructionConsolePrint : Instruction
	{
		[SerializeField]
		private PropertyGetString m_Message = new PropertyGetString("My message");

		public override string Title => $"Log: {m_Message}";

		public InstructionConsolePrint()
		{
		}

		public InstructionConsolePrint(string text)
		{
			m_Message = new PropertyGetString(text);
		}

		protected override Task Run(Args args)
		{
			string text = m_Message.Get(args);
			if (string.IsNullOrEmpty(text))
			{
				return Instruction.DefaultResult;
			}
			Console.Open();
			Console.Print(text);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Log Text")]
	[Description("Prints a message to the Unity Console")]
	[Category("Debug/Log Text")]
	[Parameter("Message", "The text message to log")]
	[Keywords(new string[] { "Debug", "Log", "Print", "Show", "Display", "Name", "Test", "Message", "String" })]
	[Image(typeof(IconBug), ColorTheme.Type.TextLight)]
	public class InstructionCommonDebugText : Instruction
	{
		[SerializeField]
		private PropertyGetString m_Message = new PropertyGetString("My message");

		public override string Title => $"Log: {m_Message}";

		public InstructionCommonDebugText()
		{
		}

		public InstructionCommonDebugText(string text)
		{
			m_Message = new PropertyGetString(text);
		}

		protected override Task Run(Args args)
		{
			Debug.Log(m_Message.Get(args));
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Comment")]
	[Description("Displays an explanation or annotation in the instructions list. It is intended to make instructions easier for humans to understand")]
	[Category("Debug/Comment")]
	[Parameter("Text", "The text of the comment")]
	[Keywords(new string[] { "Debug", "Note", "Annotation", "Explanation" })]
	[Image(typeof(IconNote), ColorTheme.Type.TextLight)]
	public class InstructionCommonDebugComment : Instruction
	{
		[SerializeField]
		private string m_Text = "My comment...";

		public override string Title => "// " + m_Text;

		public override Color Color => ColorTheme.Get(ColorTheme.Type.TextLight);

		public InstructionCommonDebugComment()
		{
		}

		public InstructionCommonDebugComment(string comment)
			: this()
		{
			m_Text = comment;
		}

		protected override Task Run(Args args)
		{
			return Instruction.DefaultResult;
		}
	}
}

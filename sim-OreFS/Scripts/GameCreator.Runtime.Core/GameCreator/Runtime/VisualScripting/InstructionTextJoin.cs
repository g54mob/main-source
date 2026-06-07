using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Join")]
	[Description("Joins two string values and stores them")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayPlus))]
	[Category("Math/Text/Join")]
	[Parameter("Text 1", "The source of the first text")]
	[Parameter("Text 2", "The source of the second text")]
	[Keywords(new string[] { "Concat", "Concatenate", "Together", "Mix" })]
	public class InstructionTextJoin : TInstructionText
	{
		[SerializeField]
		private PropertyGetString m_Text1 = GetStringString.Create;

		[SerializeField]
		private PropertyGetString m_Text2 = GetStringString.Create;

		public override string Title => $"Set {m_Set} = {m_Text1} + {m_Text2}";

		protected override Task Run(Args args)
		{
			string text = m_Text1.Get(args);
			string text2 = m_Text2.Get(args);
			m_Set.Set(text + text2, args);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Text")]
	[Description("Changes the value of a string")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	[Category("Math/Text/Set Text")]
	[Parameter("Text", "The source of the text")]
	public class InstructionTextSetString : TInstructionText
	{
		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		public override string Title => $"Set {m_Set} = {m_Text}";

		protected override Task Run(Args args)
		{
			string value = m_Text.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}

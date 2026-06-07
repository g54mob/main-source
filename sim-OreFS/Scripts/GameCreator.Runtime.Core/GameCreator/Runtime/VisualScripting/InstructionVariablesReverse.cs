using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Reverse List")]
	[Description("Reorders the elements of a list so the first ones become the last ones")]
	[Image(typeof(IconReverse), ColorTheme.Type.Teal)]
	[Category("Variables/Reverse List")]
	[Parameter("List Variable", "Local List or Global List which elements are reversed")]
	[Keywords(new string[] { "Invert", "Order", "Sort", "Array", "List", "Variables" })]
	public class InstructionVariablesReverse : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		public override string Title => $"Reverse {m_ListVariable}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			list.Reverse();
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}
	}
}

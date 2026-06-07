using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Swap List")]
	[Description("Swaps two positions of a list")]
	[Image(typeof(IconRepeat), ColorTheme.Type.Teal)]
	[Category("Variables/Swap List")]
	[Parameter("List Variable", "Local List or Global List which elements are swapped")]
	[Keywords(new string[] { "Order", "Change", "Array", "List", "Variables" })]
	public class InstructionVariablesSwap : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeReference]
		private TListGetPick m_Element1 = new GetPickFirst();

		[SerializeReference]
		private TListGetPick m_Element2 = new GetPickLast();

		public override string Title => $"Swap {m_ListVariable} {m_Element1} with {m_Element2}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			int index = m_Element1.GetIndex(list.Count, args);
			int index2 = m_Element2.GetIndex(list.Count, args);
			object value = list[index];
			object value2 = list[index2];
			list[index] = value2;
			list[index2] = value;
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}
	}
}

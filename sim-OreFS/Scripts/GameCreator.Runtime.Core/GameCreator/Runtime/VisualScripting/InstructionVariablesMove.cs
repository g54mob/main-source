using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Move List")]
	[Description("Move a position from a list to another position")]
	[Image(typeof(IconMove), ColorTheme.Type.Teal)]
	[Category("Variables/Move List")]
	[Parameter("List Variable", "Local List or Global List which elements are moved")]
	[Keywords(new string[] { "Order", "Change", "Array", "List", "Variables" })]
	public class InstructionVariablesMove : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeReference]
		private TListGetPick m_From = new GetPickLast();

		[SerializeReference]
		private TListGetPick m_To = new GetPickLast();

		public override string Title => $"Move {m_ListVariable} {m_From} to {m_To}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			int index = m_From.GetIndex(list.Count, args);
			int index2 = m_To.GetIndex(list.Count, args);
			object item = list[index];
			list.RemoveAt(index);
			list.Insert(index2, item);
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}
	}
}

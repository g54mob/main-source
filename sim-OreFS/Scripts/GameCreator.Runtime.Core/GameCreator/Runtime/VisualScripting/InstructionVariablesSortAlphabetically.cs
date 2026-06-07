using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Sort List Alphabetically")]
	[Description("Sorts the List Variable elements based on their alphabet distance")]
	[Image(typeof(IconSort), ColorTheme.Type.Teal)]
	[Category("Variables/Sort List Alphabetically")]
	[Parameter("List Variable", "Local List or Global List which elements are sorted")]
	[Parameter("Order", "Sort alphabetically ascending or descending")]
	[Parameter("Ignore Case", "Whether the string comparison should ignore upper/lower case")]
	[Keywords(new string[] { "Order", "Organize", "Array", "List", "Variables" })]
	public class InstructionVariablesSortAlphabetically : Instruction
	{
		private enum Order
		{
			Ascending = 0,
			Descending = 1
		}

		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeField]
		private Order m_Order;

		[SerializeField]
		private bool m_IgnoreCase;

		public override string Title => $"Sort {m_ListVariable} {m_Order}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			list.Sort(SortingMethod);
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}

		private int SortingMethod(object a, object b)
		{
			StringComparison comparisonType = (m_IgnoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
			if (m_Order != Order.Ascending)
			{
				return string.Compare(b.ToString(), a.ToString(), comparisonType);
			}
			return string.Compare(a.ToString(), b.ToString(), comparisonType);
		}
	}
}

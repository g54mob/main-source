using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("List is Empty")]
	[Description("Checks whether a List Variable is empty or not")]
	[Category("Variables/List is Empty")]
	[Parameter("List Variables", "The Local or Global List Variable to check")]
	[Keywords(new string[] { "Size", "Length", "Any", "Local", "Global", "Variable" })]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class ConditionVariablesListEmpty : Condition
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		protected override string Summary => $"{m_ListVariable} is Empty";

		protected override bool Run(Args args)
		{
			return m_ListVariable.GetCount(args) == 0;
		}
	}
}

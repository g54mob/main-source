using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Filter List")]
	[Description("Checks Conditions against each element of a list and removes it if the Condition is not true")]
	[Image(typeof(IconFilter), ColorTheme.Type.Teal)]
	[Category("Variables/Filter List")]
	[Parameter("List Variable", "Local List or Global List which elements are filtered")]
	[Parameter("Filter", "Checks a set of Conditions with each collected game object and removes the element if the Condition is not true")]
	[Example("The Filter field runs the Conditions list for each element in a Local List Variables or Global List Variables. It sets as the 'Target' value the currently examined game object. For example, filtering by the tag name 'Enemy' can be done using the 'Tag' Condition and comparing the field 'Target' with the string 'Enemy'. All game objects that are not tagged as 'Enemy' are removed")]
	[Keywords(new string[] { "Remove", "Pick", "Select", "Array", "List", "Variables" })]
	public class InstructionVariablesFilter : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeField]
		private ConditionList m_Conditions = new ConditionList();

		public override string Title => $"Filter {m_ListVariable}";

		protected override Task Run(Args args)
		{
			Args args2 = new Args(args.Self, null);
			List<object> list = m_ListVariable.Get(args);
			List<GameObject> list2 = new List<GameObject>();
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = list[i] as GameObject;
				if (!(gameObject == null))
				{
					args2.ChangeTarget(gameObject);
					if (m_Conditions.Check(args2, CheckMode.And))
					{
						list2.Add(gameObject);
					}
				}
			}
			m_ListVariable.Fill(list2.ToArray(), args);
			return Instruction.DefaultResult;
		}
	}
}

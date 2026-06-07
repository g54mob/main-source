using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Conditions as OR")]
	[Description("Returns true if at least one of the Conditions from the list is True")]
	[Category("Visual Scripting/Run Conditions as OR")]
	[Keywords(new string[] { "|", "One", "Selector" })]
	[Image(typeof(IconOR), ColorTheme.Type.Red)]
	public class ConditionVisualScriptingConditionsOR : Condition
	{
		[SerializeField]
		private ConditionList m_Conditions = new ConditionList();

		protected override string Summary
		{
			get
			{
				string text = m_Conditions.ToString("or");
				if (!string.IsNullOrEmpty(text))
				{
					return "(" + text + ")";
				}
				return "(none)";
			}
		}

		protected override bool Run(Args args)
		{
			return m_Conditions.Check(args, CheckMode.Or);
		}
	}
}

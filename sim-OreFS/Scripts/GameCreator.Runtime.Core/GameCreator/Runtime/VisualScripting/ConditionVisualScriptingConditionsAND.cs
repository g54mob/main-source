using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Conditions as AND")]
	[Description("Returns true only if all the Conditions from the list are True")]
	[Category("Visual Scripting/Conditions as AND")]
	[Keywords(new string[] { "&", "All", "Sequence" })]
	[Image(typeof(IconAND), ColorTheme.Type.Green)]
	public class ConditionVisualScriptingConditionsAND : Condition
	{
		[SerializeField]
		private ConditionList m_Conditions = new ConditionList();

		protected override string Summary
		{
			get
			{
				string text = m_Conditions.ToString("and");
				if (!string.IsNullOrEmpty(text))
				{
					return "(" + text + ")";
				}
				return "(none)";
			}
		}

		protected override bool Run(Args args)
		{
			return m_Conditions.Check(args, CheckMode.And);
		}
	}
}

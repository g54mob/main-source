using System;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Check Conditions")]
	[Category("Visual Scripting/Check Conditions")]
	[Image(typeof(IconCondition), ColorTheme.Type.Green)]
	[Description("Returns whether the conditions list ran successfully or not")]
	[Keywords(new string[] { "Conditions", "Check" })]
	public class GetBoolCheckConditions : PropertyTypeGetBool
	{
		[SerializeField]
		private RunConditionsList m_Conditions = new RunConditionsList();

		public override string String => m_Conditions.ToString();

		public override bool Get(Args args)
		{
			return m_Conditions.Check(args);
		}

		public GetBoolCheckConditions()
		{
		}

		public GetBoolCheckConditions(params Condition[] conditions)
		{
			m_Conditions = new RunConditionsList(conditions);
		}

		public static PropertyGetBool Create()
		{
			return new PropertyGetBool(new GetBoolCheckConditions());
		}

		public static PropertyGetBool Create(params Condition[] conditions)
		{
			return new PropertyGetBool(new GetBoolCheckConditions(conditions));
		}
	}
}

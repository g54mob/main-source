using System;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Condition")]
	[Category("Visual Scripting/Condition")]
	[Image(typeof(IconCondition), ColorTheme.Type.Green)]
	[Description("Returns one value or another depending on the result of the Conditions")]
	[Keywords(new string[] { "Check", "Branch" })]
	public class GetDecimalCondition : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ConditionList m_Condition = new ConditionList();

		[SerializeField]
		private PropertyGetDecimal m_True = GetDecimalConstantOne.Create;

		[SerializeField]
		private PropertyGetDecimal m_False = GetDecimalConstantZero.Create;

		public override string String => m_Condition.ToString();

		public override double Get(Args args)
		{
			if (!m_Condition.Check(args, CheckMode.And))
			{
				return m_False.Get(args);
			}
			return m_True.Get(args);
		}
	}
}

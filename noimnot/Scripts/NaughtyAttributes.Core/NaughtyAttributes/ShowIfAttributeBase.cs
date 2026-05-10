using System;

namespace NaughtyAttributes
{
	public class ShowIfAttributeBase : MetaAttribute
	{
		public string[] Conditions { get; private set; }

		public EConditionOperator ConditionOperator { get; private set; }

		public bool Inverted { get; protected set; }

		public Enum EnumValue { get; private set; }

		public ShowIfAttributeBase(string condition)
		{
		}

		public ShowIfAttributeBase(EConditionOperator conditionOperator, params string[] conditions)
		{
		}

		public ShowIfAttributeBase(string enumName, Enum enumValue)
		{
		}
	}
}

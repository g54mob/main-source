using System;

namespace NaughtyAttributes
{
	public abstract class EnableIfAttributeBase : MetaAttribute
	{
		public string[] Conditions { get; private set; }

		public EConditionOperator ConditionOperator { get; private set; }

		public bool Inverted { get; protected set; }

		public Enum EnumValue { get; private set; }

		public EnableIfAttributeBase(string condition)
		{
		}

		public EnableIfAttributeBase(EConditionOperator conditionOperator, params string[] conditions)
		{
		}

		public EnableIfAttributeBase(string enumName, Enum enumValue)
		{
		}
	}
}

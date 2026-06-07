namespace ExternalPropertyAttributes
{
	public abstract class EnableIfAttributeBase : MetaAttribute
	{
		public string[] Conditions { get; private set; }

		public EConditionOperator ConditionOperator { get; private set; }

		public bool Inverted { get; protected set; }

		public EnableIfAttributeBase(string condition)
		{
		}

		public EnableIfAttributeBase(EConditionOperator conditionOperator, params string[] conditions)
		{
		}
	}
}

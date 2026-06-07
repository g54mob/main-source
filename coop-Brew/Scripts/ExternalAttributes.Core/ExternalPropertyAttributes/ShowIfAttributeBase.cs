namespace ExternalPropertyAttributes
{
	public class ShowIfAttributeBase : MetaAttribute
	{
		public string[] Conditions { get; private set; }

		public EConditionOperator ConditionOperator { get; private set; }

		public bool Inverted { get; protected set; }

		public ShowIfAttributeBase(string condition)
		{
		}

		public ShowIfAttributeBase(EConditionOperator conditionOperator, params string[] conditions)
		{
		}
	}
}

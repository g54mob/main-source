namespace FluffyUnderware.DevTools
{
	public class FieldConditionAttribute : ConditionalAttribute, IDTFieldRenderAttribute
	{
		public FieldConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse = false, ActionEnum action = ActionEnum.Show, object actionData = null, ActionPositionEnum position = ActionPositionEnum.Below)
			: base(null, null)
		{
		}

		public FieldConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2)
			: base(null, null)
		{
		}

		public FieldConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2, string fieldOrProperty3, object compareTo3, bool compareFalse3)
			: base(null, null)
		{
		}

		public FieldConditionAttribute(string methodToQuery)
			: base(null, null)
		{
		}
	}
}

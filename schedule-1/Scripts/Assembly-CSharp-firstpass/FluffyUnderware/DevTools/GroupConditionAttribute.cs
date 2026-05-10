namespace FluffyUnderware.DevTools
{
	public class GroupConditionAttribute : ConditionalAttribute, IDTGroupRenderAttribute
	{
		public GroupConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse = false)
			: base(null, null)
		{
		}

		public GroupConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2)
			: base(null, null)
		{
		}

		public GroupConditionAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2, string fieldOrProperty3, object compareTo3, bool compareFalse3)
			: base(null, null)
		{
		}

		public GroupConditionAttribute(string methodToQuery)
			: base(null, null)
		{
		}
	}
}

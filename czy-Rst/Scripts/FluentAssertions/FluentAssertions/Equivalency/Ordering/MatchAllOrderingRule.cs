namespace FluentAssertions.Equivalency.Ordering
{
	internal class MatchAllOrderingRule : IOrderingRule
	{
		public OrderStrictness Evaluate(IObjectInfo objectInfo)
		{
			return OrderStrictness.Strict;
		}

		public override string ToString()
		{
			return "Always be strict about the collection order";
		}
	}
}

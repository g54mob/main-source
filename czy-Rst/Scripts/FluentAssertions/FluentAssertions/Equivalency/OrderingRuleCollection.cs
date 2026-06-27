using System.Collections;
using System.Collections.Generic;

namespace FluentAssertions.Equivalency
{
	public class OrderingRuleCollection : IEnumerable<IOrderingRule>, IEnumerable
	{
		private readonly List<IOrderingRule> rules = new List<IOrderingRule>();

		public OrderingRuleCollection()
		{
		}

		public OrderingRuleCollection(IEnumerable<IOrderingRule> orderingRules)
		{
			rules.AddRange(orderingRules);
		}

		public IEnumerator<IOrderingRule> GetEnumerator()
		{
			return rules.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(IOrderingRule rule)
		{
			rules.Add(rule);
		}

		internal void Clear()
		{
			rules.Clear();
		}

		public bool IsOrderingStrictFor(IObjectInfo objectInfo)
		{
			List<OrderStrictness> list = rules.ConvertAll((IOrderingRule r) => r.Evaluate(objectInfo));
			if (list.Contains(OrderStrictness.Strict))
			{
				return !list.Contains(OrderStrictness.NotStrict);
			}
			return false;
		}
	}
}

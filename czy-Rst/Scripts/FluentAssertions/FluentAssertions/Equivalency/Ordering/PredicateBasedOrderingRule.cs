using System;
using System.Linq.Expressions;

namespace FluentAssertions.Equivalency.Ordering
{
	internal class PredicateBasedOrderingRule : IOrderingRule
	{
		private readonly Func<IObjectInfo, bool> predicate;

		private readonly string description;

		public bool Invert { get; init; }

		public PredicateBasedOrderingRule(Expression<Func<IObjectInfo, bool>> predicate)
		{
			description = predicate.Body.ToString();
			this.predicate = predicate.Compile();
		}

		public OrderStrictness Evaluate(IObjectInfo objectInfo)
		{
			if (predicate(objectInfo))
			{
				if (!Invert)
				{
					return OrderStrictness.Strict;
				}
				return OrderStrictness.NotStrict;
			}
			return OrderStrictness.Irrelevant;
		}

		public override string ToString()
		{
			return "Be " + (Invert ? "not strict" : "strict") + " about the order of collections when " + description;
		}
	}
}

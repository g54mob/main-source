using System.Collections.Generic;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency.Ordering
{
	internal class ByteArrayOrderingRule : IOrderingRule
	{
		public OrderStrictness Evaluate(IObjectInfo objectInfo)
		{
			if (!objectInfo.CompileTimeType.IsSameOrInherits(typeof(IEnumerable<byte>)))
			{
				return OrderStrictness.Irrelevant;
			}
			return OrderStrictness.Strict;
		}

		public override string ToString()
		{
			return "Be strict about the order of items in byte arrays";
		}
	}
}

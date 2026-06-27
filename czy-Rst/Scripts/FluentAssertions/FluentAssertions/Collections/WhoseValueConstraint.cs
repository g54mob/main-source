using System.Collections.Generic;

namespace FluentAssertions.Collections
{
	public class WhoseValueConstraint<TCollection, TKey, TValue, TAssertions> : AndConstraint<TAssertions> where TCollection : IEnumerable<KeyValuePair<TKey, TValue>> where TAssertions : GenericDictionaryAssertions<TCollection, TKey, TValue, TAssertions>
	{
		public TValue WhoseValue { get; }

		public WhoseValueConstraint(TAssertions parentConstraint, TValue value)
			: base(parentConstraint)
		{
			WhoseValue = value;
		}
	}
}

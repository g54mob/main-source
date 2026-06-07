using System;
using System.Collections;

namespace NUnit.Framework.Constraints
{
	public class DictionaryContainsValueConstraint : CollectionContainsConstraint
	{
		public override string DisplayName => "ContainsValue";

		public override string Description => "dictionary containing value " + MsgUtils.FormatValue(base.Expected);

		public DictionaryContainsValueConstraint(object expected)
			: base(expected)
		{
		}

		protected override bool Matches(IEnumerable actual)
		{
			if (!(actual is IDictionary dictionary))
			{
				throw new ArgumentException("The actual value must be an IDictionary", "actual");
			}
			return base.Matches((IEnumerable)dictionary.Values);
		}
	}
}

using System;
using System.Collections;

namespace NUnit.Framework.Constraints
{
	public class DictionaryContainsKeyConstraint : CollectionContainsConstraint
	{
		public override string DisplayName => "ContainsKey";

		public override string Description => "dictionary containing key " + MsgUtils.FormatValue(base.Expected);

		public DictionaryContainsKeyConstraint(object expected)
			: base(expected)
		{
		}

		protected override bool Matches(IEnumerable actual)
		{
			if (!(actual is IDictionary dictionary))
			{
				throw new ArgumentException("The actual value must be an IDictionary", "actual");
			}
			return base.Matches((IEnumerable)dictionary.Keys);
		}
	}
}

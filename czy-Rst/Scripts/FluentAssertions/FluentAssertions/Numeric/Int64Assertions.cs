using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class Int64Assertions : NumericAssertions<long>
	{
		internal Int64Assertions(long value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(long subject, long expected)
		{
			if (subject > 0 && subject < 10 && expected > 0 && expected < 10)
			{
				return null;
			}
			decimal num = (decimal)subject - (decimal)expected;
			if (!(num != 0m))
			{
				return null;
			}
			return num.ToString(CultureInfo.InvariantCulture);
		}
	}
}

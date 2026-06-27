using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableInt32Assertions : NullableNumericAssertions<int>
	{
		internal NullableInt32Assertions(int? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(int subject, int expected)
		{
			if (subject > 0 && subject < 10 && expected > 0 && expected < 10)
			{
				return null;
			}
			long num = (long)subject - (long)expected;
			if (num == 0L)
			{
				return null;
			}
			return num.ToString(CultureInfo.InvariantCulture);
		}
	}
}

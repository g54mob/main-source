using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableInt16Assertions : NullableNumericAssertions<short>
	{
		internal NullableInt16Assertions(short? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(short subject, short expected)
		{
			if (subject < 10 && expected < 10)
			{
				return null;
			}
			int num = subject - expected;
			if (num == 0)
			{
				return null;
			}
			return num.ToString(CultureInfo.InvariantCulture);
		}
	}
}

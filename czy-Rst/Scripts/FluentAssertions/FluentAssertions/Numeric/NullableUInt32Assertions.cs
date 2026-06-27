using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableUInt32Assertions : NullableNumericAssertions<uint>
	{
		internal NullableUInt32Assertions(uint? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(uint subject, uint expected)
		{
			if (subject < 10 && expected < 10)
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

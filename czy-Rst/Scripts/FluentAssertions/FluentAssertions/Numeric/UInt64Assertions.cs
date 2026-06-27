using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class UInt64Assertions : NumericAssertions<ulong>
	{
		internal UInt64Assertions(ulong value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(ulong subject, ulong expected)
		{
			if (subject < 10 && expected < 10)
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

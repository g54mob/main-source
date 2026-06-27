using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableUInt16Assertions : NullableNumericAssertions<ushort>
	{
		internal NullableUInt16Assertions(ushort? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(ushort subject, ushort expected)
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

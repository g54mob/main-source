using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class ByteAssertions : NumericAssertions<byte>
	{
		internal ByteAssertions(byte value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(byte subject, byte expected)
		{
			int num = subject - expected;
			if (num == 0)
			{
				return null;
			}
			return num.ToString(CultureInfo.InvariantCulture);
		}
	}
}

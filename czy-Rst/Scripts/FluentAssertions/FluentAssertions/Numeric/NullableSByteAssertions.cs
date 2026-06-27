using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableSByteAssertions : NullableNumericAssertions<sbyte>
	{
		internal NullableSByteAssertions(sbyte? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(sbyte subject, sbyte expected)
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

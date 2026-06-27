using System;
using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class DecimalAssertions : NumericAssertions<decimal>
	{
		internal DecimalAssertions(decimal value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override string CalculateDifferenceForFailureMessage(decimal subject, decimal expected)
		{
			try
			{
				decimal num = subject - expected;
				return (num != 0m) ? num.ToString(CultureInfo.InvariantCulture) : null;
			}
			catch (OverflowException)
			{
				return null;
			}
		}
	}
}

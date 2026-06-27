using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableDoubleAssertions : NullableNumericAssertions<double>
	{
		internal NullableDoubleAssertions(double? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override bool IsNaN(double value)
		{
			return double.IsNaN(value);
		}

		private protected override string CalculateDifferenceForFailureMessage(double subject, double expected)
		{
			double num = subject - expected;
			if (num == 0.0)
			{
				return null;
			}
			return num.ToString("R", CultureInfo.InvariantCulture);
		}
	}
}

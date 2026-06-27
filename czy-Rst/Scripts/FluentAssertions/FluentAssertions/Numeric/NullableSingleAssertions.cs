using System.Diagnostics;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	internal class NullableSingleAssertions : NullableNumericAssertions<float>
	{
		internal NullableSingleAssertions(float? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}

		private protected override bool IsNaN(float value)
		{
			return float.IsNaN(value);
		}

		private protected override string CalculateDifferenceForFailureMessage(float subject, float expected)
		{
			float num = subject - expected;
			if (num == 0f)
			{
				return null;
			}
			return num.ToString("R", CultureInfo.InvariantCulture);
		}
	}
}

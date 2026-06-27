using System;
using System.Globalization;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class EnumEqualityStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!comparands.GetExpectedType(context.Options).IsEnum)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			assertionChain.ForCondition(comparands.Subject?.GetType().IsEnum ?? false).BecauseOf(context.Reason).FailWith(delegate
			{
				decimal? v = ExtractDecimal(comparands.Expectation);
				string displayNameForEnumComparison = GetDisplayNameForEnumComparison(comparands.Expectation, v);
				return new FailReason("Expected {context:enum} to be equivalent to {0}{reason}, but found {1}.", displayNameForEnumComparison.AsNonFormattable(), comparands.Subject);
			});
			if (assertionChain.Succeeded)
			{
				switch (context.Options.EnumEquivalencyHandling)
				{
				case EnumEquivalencyHandling.ByValue:
					HandleByValue(assertionChain, comparands, context.Reason);
					break;
				case EnumEquivalencyHandling.ByName:
					HandleByName(assertionChain, comparands, context.Reason);
					break;
				default:
					throw new InvalidOperationException($"Do not know how to handle {context.Options.EnumEquivalencyHandling}");
				}
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static void HandleByValue(AssertionChain assertionChain, Comparands comparands, Reason reason)
		{
			decimal? subjectsUnderlyingValue = ExtractDecimal(comparands.Subject);
			decimal? expectationsUnderlyingValue = ExtractDecimal(comparands.Expectation);
			assertionChain.ForCondition(subjectsUnderlyingValue == expectationsUnderlyingValue).BecauseOf(reason).FailWith(delegate
			{
				string displayNameForEnumComparison = GetDisplayNameForEnumComparison(comparands.Subject, subjectsUnderlyingValue);
				string displayNameForEnumComparison2 = GetDisplayNameForEnumComparison(comparands.Expectation, expectationsUnderlyingValue);
				return new FailReason("Expected {context:enum} to equal {0} by value{reason}, but found {1}.", displayNameForEnumComparison2.AsNonFormattable(), displayNameForEnumComparison.AsNonFormattable());
			});
		}

		private static void HandleByName(AssertionChain assertionChain, Comparands comparands, Reason reason)
		{
			string text = comparands.Subject.ToString();
			string text2 = comparands.Expectation.ToString();
			assertionChain.ForCondition(text == text2).BecauseOf(reason).FailWith(delegate
			{
				decimal? v = ExtractDecimal(comparands.Subject);
				decimal? v2 = ExtractDecimal(comparands.Expectation);
				string displayNameForEnumComparison = GetDisplayNameForEnumComparison(comparands.Subject, v);
				string displayNameForEnumComparison2 = GetDisplayNameForEnumComparison(comparands.Expectation, v2);
				return new FailReason("Expected {context:enum} to equal {0} by name{reason}, but found {1}.", displayNameForEnumComparison2.AsNonFormattable(), displayNameForEnumComparison.AsNonFormattable());
			});
		}

		private static string GetDisplayNameForEnumComparison(object o, decimal? v)
		{
			if (o == null || !v.HasValue)
			{
				return "<null>";
			}
			string name = o.GetType().Name;
			string text = SystemExtensions.Replace(o.ToString(), ", ", "|", StringComparison.Ordinal);
			string text2 = v.Value.ToString(CultureInfo.InvariantCulture);
			return name + "." + text + " {value: " + text2 + "}";
		}

		private static decimal? ExtractDecimal(object o)
		{
			if (o == null)
			{
				return null;
			}
			return Convert.ToDecimal(o, CultureInfo.InvariantCulture);
		}
	}
}

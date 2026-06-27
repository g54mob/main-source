using System;
using System.Globalization;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency.Steps
{
	public class AutoConversionStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!context.Options.ConversionSelector.RequiresConversion(comparands, context.CurrentNode))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			if (comparands.Expectation == null || comparands.Subject == null)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			Type type = comparands.Subject.GetType();
			Type expectationType = comparands.Expectation.GetType();
			if (type.IsSameOrInherits(expectationType))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			if (TryChangeType(comparands.Subject, expectationType, out var conversionResult))
			{
				context.Tracer.WriteLine((INode member) => FormattableString.Invariant($"Converted subject {comparands.Subject} at {member.Subject} to {expectationType}"));
				comparands.Subject = conversionResult;
			}
			else
			{
				context.Tracer.WriteLine((INode member) => FormattableString.Invariant($"Subject {comparands.Subject} at {member.Subject} could not be converted to {expectationType}"));
			}
			return EquivalencyResult.ContinueWithNext;
		}

		private static bool TryChangeType(object subject, Type expectationType, out object conversionResult)
		{
			conversionResult = null;
			try
			{
				if (expectationType.IsEnum)
				{
					if ((subject is sbyte || subject is byte || subject is short || subject is ushort || subject is int || subject is uint || subject is long || subject is ulong) ? true : false)
					{
						conversionResult = Enum.ToObject(expectationType, subject);
						return Enum.IsDefined(expectationType, conversionResult);
					}
					return false;
				}
				conversionResult = Convert.ChangeType(subject, expectationType, CultureInfo.InvariantCulture);
				return true;
			}
			catch (FormatException)
			{
			}
			catch (InvalidCastException)
			{
			}
			return false;
		}

		public override string ToString()
		{
			return string.Empty;
		}
	}
}

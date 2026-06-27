using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace FluentAssertions
{
	public static class NumericAssertionsExtensions
	{
		public static AndConstraint<NumericAssertions<sbyte>> BeCloseTo(this NumericAssertions<sbyte> parent, sbyte nearbyValue, byte delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			sbyte subject = parent.Subject;
			sbyte b = (sbyte)(nearbyValue - delta);
			if (b > nearbyValue)
			{
				b = sbyte.MinValue;
			}
			sbyte b2 = (sbyte)(nearbyValue + delta);
			if (b2 < nearbyValue)
			{
				b2 = sbyte.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, b <= subject && subject <= b2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<sbyte>>(parent);
		}

		public static AndConstraint<NumericAssertions<byte>> BeCloseTo(this NumericAssertions<byte> parent, byte nearbyValue, byte delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			byte subject = parent.Subject;
			byte b = (byte)(nearbyValue - delta);
			if (b > nearbyValue)
			{
				b = 0;
			}
			byte b2 = (byte)(nearbyValue + delta);
			if (b2 < nearbyValue)
			{
				b2 = byte.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, b <= subject && subject <= b2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<byte>>(parent);
		}

		public static AndConstraint<NumericAssertions<short>> BeCloseTo(this NumericAssertions<short> parent, short nearbyValue, ushort delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			short subject = parent.Subject;
			short num = (short)(nearbyValue - delta);
			if (num > nearbyValue)
			{
				num = short.MinValue;
			}
			short num2 = (short)(nearbyValue + delta);
			if (num2 < nearbyValue)
			{
				num2 = short.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, num <= subject && subject <= num2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<short>>(parent);
		}

		public static AndConstraint<NumericAssertions<ushort>> BeCloseTo(this NumericAssertions<ushort> parent, ushort nearbyValue, ushort delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ushort subject = parent.Subject;
			ushort num = (ushort)(nearbyValue - delta);
			if (num > nearbyValue)
			{
				num = 0;
			}
			ushort num2 = (ushort)(nearbyValue + delta);
			if (num2 < nearbyValue)
			{
				num2 = ushort.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, num <= subject && subject <= num2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<ushort>>(parent);
		}

		public static AndConstraint<NumericAssertions<int>> BeCloseTo(this NumericAssertions<int> parent, int nearbyValue, uint delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			int subject = parent.Subject;
			int num = (int)(nearbyValue - delta);
			if (num > nearbyValue)
			{
				num = int.MinValue;
			}
			int num2 = (int)(nearbyValue + delta);
			if (num2 < nearbyValue)
			{
				num2 = int.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, num <= subject && subject <= num2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<int>>(parent);
		}

		public static AndConstraint<NumericAssertions<uint>> BeCloseTo(this NumericAssertions<uint> parent, uint nearbyValue, uint delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			uint subject = parent.Subject;
			uint num = nearbyValue - delta;
			if (num > nearbyValue)
			{
				num = 0u;
			}
			uint num2 = nearbyValue + delta;
			if (num2 < nearbyValue)
			{
				num2 = uint.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, num <= subject && subject <= num2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<uint>>(parent);
		}

		public static AndConstraint<NumericAssertions<long>> BeCloseTo(this NumericAssertions<long> parent, long nearbyValue, ulong delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			long subject = parent.Subject;
			long minValue = GetMinValue(nearbyValue, delta);
			long maxValue = GetMaxValue(nearbyValue, delta);
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, minValue <= subject && subject <= maxValue, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<long>>(parent);
		}

		public static AndConstraint<NumericAssertions<ulong>> BeCloseTo(this NumericAssertions<ulong> parent, ulong nearbyValue, ulong delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ulong subject = parent.Subject;
			ulong num = nearbyValue - delta;
			if (num > nearbyValue)
			{
				num = 0uL;
			}
			ulong num2 = nearbyValue + delta;
			if (num2 < nearbyValue)
			{
				num2 = ulong.MaxValue;
			}
			FailIfValueOutsideBounds(parent.CurrentAssertionChain, num <= subject && subject <= num2, nearbyValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<ulong>>(parent);
		}

		private static void FailIfValueOutsideBounds<TValue, TDelta>(AssertionChain assertionChain, bool valueWithinBounds, TValue nearbyValue, TDelta delta, TValue actualValue, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			assertionChain.ForCondition(valueWithinBounds).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be within {0} from {1}{reason}, but found {2}.", delta, nearbyValue, actualValue);
		}

		public static AndConstraint<NumericAssertions<sbyte>> NotBeCloseTo(this NumericAssertions<sbyte> parent, sbyte distantValue, byte delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			sbyte subject = parent.Subject;
			sbyte b = (sbyte)(distantValue - delta);
			if (b > distantValue)
			{
				b = sbyte.MinValue;
			}
			sbyte b2 = (sbyte)(distantValue + delta);
			if (b2 < distantValue)
			{
				b2 = sbyte.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, b > subject || subject > b2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<sbyte>>(parent);
		}

		public static AndConstraint<NumericAssertions<byte>> NotBeCloseTo(this NumericAssertions<byte> parent, byte distantValue, byte delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			byte subject = parent.Subject;
			byte b = (byte)(distantValue - delta);
			if (b > distantValue)
			{
				b = 0;
			}
			byte b2 = (byte)(distantValue + delta);
			if (b2 < distantValue)
			{
				b2 = byte.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, b > subject || subject > b2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<byte>>(parent);
		}

		public static AndConstraint<NumericAssertions<short>> NotBeCloseTo(this NumericAssertions<short> parent, short distantValue, ushort delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			short subject = parent.Subject;
			short num = (short)(distantValue - delta);
			if (num > distantValue)
			{
				num = short.MinValue;
			}
			short num2 = (short)(distantValue + delta);
			if (num2 < distantValue)
			{
				num2 = short.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, num > subject || subject > num2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<short>>(parent);
		}

		public static AndConstraint<NumericAssertions<ushort>> NotBeCloseTo(this NumericAssertions<ushort> parent, ushort distantValue, ushort delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ushort subject = parent.Subject;
			ushort num = (ushort)(distantValue - delta);
			if (num > distantValue)
			{
				num = 0;
			}
			ushort num2 = (ushort)(distantValue + delta);
			if (num2 < distantValue)
			{
				num2 = ushort.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, num > subject || subject > num2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<ushort>>(parent);
		}

		public static AndConstraint<NumericAssertions<int>> NotBeCloseTo(this NumericAssertions<int> parent, int distantValue, uint delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			int subject = parent.Subject;
			int num = (int)(distantValue - delta);
			if (num > distantValue)
			{
				num = int.MinValue;
			}
			int num2 = (int)(distantValue + delta);
			if (num2 < distantValue)
			{
				num2 = int.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, num > subject || subject > num2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<int>>(parent);
		}

		public static AndConstraint<NumericAssertions<uint>> NotBeCloseTo(this NumericAssertions<uint> parent, uint distantValue, uint delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			uint subject = parent.Subject;
			uint num = distantValue - delta;
			if (num > distantValue)
			{
				num = 0u;
			}
			uint num2 = distantValue + delta;
			if (num2 < distantValue)
			{
				num2 = uint.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, num > subject || subject > num2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<uint>>(parent);
		}

		public static AndConstraint<NumericAssertions<long>> NotBeCloseTo(this NumericAssertions<long> parent, long distantValue, ulong delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			long subject = parent.Subject;
			long minValue = GetMinValue(distantValue, delta);
			long maxValue = GetMaxValue(distantValue, delta);
			FailIfValueInsideBounds(parent.CurrentAssertionChain, minValue > subject || subject > maxValue, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<long>>(parent);
		}

		public static AndConstraint<NumericAssertions<ulong>> NotBeCloseTo(this NumericAssertions<ulong> parent, ulong distantValue, ulong delta, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ulong subject = parent.Subject;
			ulong num = distantValue - delta;
			if (num > distantValue)
			{
				num = 0uL;
			}
			ulong num2 = distantValue + delta;
			if (num2 < distantValue)
			{
				num2 = ulong.MaxValue;
			}
			FailIfValueInsideBounds(parent.CurrentAssertionChain, num > subject || subject > num2, distantValue, delta, subject, because, becauseArgs);
			return new AndConstraint<NumericAssertions<ulong>>(parent);
		}

		private static void FailIfValueInsideBounds<TValue, TDelta>(AssertionChain assertionChain, bool valueOutsideBounds, TValue distantValue, TDelta delta, TValue actualValue, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			assertionChain.ForCondition(valueOutsideBounds).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be within {0} from {1}{reason}, but found {2}.", delta, distantValue, actualValue);
		}

		public static AndConstraint<NullableNumericAssertions<float>> BeApproximately(this NullableNumericAssertions<float> parent, float expectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", expectedValue, precision);
			if (currentAssertionChain.Succeeded)
			{
				new SingleAssertions(parent.Subject.Value, currentAssertionChain).BeApproximately(expectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<float>> BeApproximately(this NullableNumericAssertions<float> parent, float? expectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue && !expectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<float>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(expectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was {2}.", expectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.BeApproximately(expectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NumericAssertions<float>> BeApproximately(this NumericAssertions<float> parent, float expectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (float.IsNaN(expectedValue))
			{
				throw new ArgumentException("Cannot determine approximation of a float to NaN", "expectedValue");
			}
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (float.IsPositiveInfinity(expectedValue))
			{
				FailIfDifferenceOutsidePrecision(float.IsPositiveInfinity(parent.Subject), parent, expectedValue, precision, float.NaN, because, becauseArgs);
			}
			else if (float.IsNegativeInfinity(expectedValue))
			{
				FailIfDifferenceOutsidePrecision(float.IsNegativeInfinity(parent.Subject), parent, expectedValue, precision, float.NaN, because, becauseArgs);
			}
			else
			{
				float num = Math.Abs(expectedValue - parent.Subject);
				FailIfDifferenceOutsidePrecision(num <= precision, parent, expectedValue, precision, num, because, becauseArgs);
			}
			return new AndConstraint<NumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> BeApproximately(this NullableNumericAssertions<double> parent, double expectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", expectedValue, precision);
			if (currentAssertionChain.Succeeded)
			{
				new DoubleAssertions(parent.Subject.Value, currentAssertionChain).BeApproximately(expectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> BeApproximately(this NullableNumericAssertions<double> parent, double? expectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue && !expectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<double>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(expectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was {2}.", expectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.BeApproximately(expectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		public static AndConstraint<NumericAssertions<double>> BeApproximately(this NumericAssertions<double> parent, double expectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (double.IsNaN(expectedValue))
			{
				throw new ArgumentException("Cannot determine approximation of a double to NaN", "expectedValue");
			}
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (double.IsPositiveInfinity(expectedValue))
			{
				FailIfDifferenceOutsidePrecision(double.IsPositiveInfinity(parent.Subject), parent, expectedValue, precision, double.NaN, because, becauseArgs);
			}
			else if (double.IsNegativeInfinity(expectedValue))
			{
				FailIfDifferenceOutsidePrecision(double.IsNegativeInfinity(parent.Subject), parent, expectedValue, precision, double.NaN, because, becauseArgs);
			}
			else
			{
				double num = Math.Abs(expectedValue - parent.Subject);
				FailIfDifferenceOutsidePrecision(num <= precision, parent, expectedValue, precision, num, because, becauseArgs);
			}
			return new AndConstraint<NumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<decimal>> BeApproximately(this NullableNumericAssertions<decimal> parent, decimal expectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was <null>.", expectedValue, precision);
			if (currentAssertionChain.Succeeded)
			{
				new DecimalAssertions(parent.Subject.Value, currentAssertionChain).BeApproximately(expectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<decimal>> BeApproximately(this NullableNumericAssertions<decimal> parent, decimal? expectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue && !expectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(expectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {0} +/- {1}{reason}, but it was {2}.", expectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.BeApproximately(expectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
		}

		public static AndConstraint<NumericAssertions<decimal>> BeApproximately(this NumericAssertions<decimal> parent, decimal expectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			decimal num = Math.Abs(expectedValue - parent.Subject);
			FailIfDifferenceOutsidePrecision(num <= precision, parent, expectedValue, precision, num, because, becauseArgs);
			return new AndConstraint<NumericAssertions<decimal>>(parent);
		}

		private static void FailIfDifferenceOutsidePrecision<T>(bool differenceWithinPrecision, NumericAssertions<T> parent, T expectedValue, T precision, T actualDifference, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs) where T : struct, IComparable<T>
		{
			parent.CurrentAssertionChain.ForCondition(differenceWithinPrecision).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to approximate {1} +/- {2}{reason}, but {0} differed by {3}.", parent.Subject, expectedValue, precision, actualDifference);
		}

		public static AndConstraint<NullableNumericAssertions<float>> NotBeApproximately(this NullableNumericAssertions<float> parent, float unexpectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (parent.Subject.HasValue)
			{
				new SingleAssertions(parent.Subject.Value, parent.CurrentAssertionChain).NotBeApproximately(unexpectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<float>> NotBeApproximately(this NullableNumericAssertions<float> parent, float? unexpectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue != !unexpectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<float>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue && unexpectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to not approximate {0} +/- {1}{reason}, but it was {2}.", unexpectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.NotBeApproximately(unexpectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NumericAssertions<float>> NotBeApproximately(this NumericAssertions<float> parent, float unexpectedValue, float precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (float.IsNaN(unexpectedValue))
			{
				throw new ArgumentException("Cannot determine approximation of a float to NaN", "unexpectedValue");
			}
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (float.IsPositiveInfinity(unexpectedValue))
			{
				FailIfDifferenceWithinPrecision(parent, !float.IsPositiveInfinity(parent.Subject), unexpectedValue, precision, float.NaN, because, becauseArgs);
			}
			else if (float.IsNegativeInfinity(unexpectedValue))
			{
				FailIfDifferenceWithinPrecision(parent, !float.IsNegativeInfinity(parent.Subject), unexpectedValue, precision, float.NaN, because, becauseArgs);
			}
			else
			{
				float num = Math.Abs(unexpectedValue - parent.Subject);
				FailIfDifferenceWithinPrecision(parent, num > precision, unexpectedValue, precision, num, because, becauseArgs);
			}
			return new AndConstraint<NumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> NotBeApproximately(this NullableNumericAssertions<double> parent, double unexpectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (parent.Subject.HasValue)
			{
				new DoubleAssertions(parent.Subject.Value, parent.CurrentAssertionChain).NotBeApproximately(unexpectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> NotBeApproximately(this NullableNumericAssertions<double> parent, double? unexpectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue != !unexpectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<double>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue && unexpectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to not approximate {0} +/- {1}{reason}, but it was {2}.", unexpectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.NotBeApproximately(unexpectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		public static AndConstraint<NumericAssertions<double>> NotBeApproximately(this NumericAssertions<double> parent, double unexpectedValue, double precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (double.IsNaN(unexpectedValue))
			{
				throw new ArgumentException("Cannot determine approximation of a double to NaN", "unexpectedValue");
			}
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (double.IsPositiveInfinity(unexpectedValue))
			{
				FailIfDifferenceWithinPrecision(parent, !double.IsPositiveInfinity(parent.Subject), unexpectedValue, precision, double.NaN, because, becauseArgs);
			}
			else if (double.IsNegativeInfinity(unexpectedValue))
			{
				FailIfDifferenceWithinPrecision(parent, !double.IsNegativeInfinity(parent.Subject), unexpectedValue, precision, double.NaN, because, becauseArgs);
			}
			else
			{
				double num = Math.Abs(unexpectedValue - parent.Subject);
				FailIfDifferenceWithinPrecision(parent, num > precision, unexpectedValue, precision, num, because, becauseArgs);
			}
			return new AndConstraint<NumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<decimal>> NotBeApproximately(this NullableNumericAssertions<decimal> parent, decimal unexpectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (parent.Subject.HasValue)
			{
				new DecimalAssertions(parent.Subject.Value, parent.CurrentAssertionChain).NotBeApproximately(unexpectedValue, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<decimal>> NotBeApproximately(this NullableNumericAssertions<decimal> parent, decimal? unexpectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			if (!parent.Subject.HasValue != !unexpectedValue.HasValue)
			{
				return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
			}
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			currentAssertionChain.ForCondition(parent.Subject.HasValue && unexpectedValue.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to not approximate {0} +/- {1}{reason}, but it was {2}.", unexpectedValue, precision, parent.Subject);
			if (currentAssertionChain.Succeeded)
			{
				parent.NotBeApproximately(unexpectedValue.Value, precision, because, becauseArgs);
			}
			return new AndConstraint<NullableNumericAssertions<decimal>>(parent);
		}

		public static AndConstraint<NumericAssertions<decimal>> NotBeApproximately(this NumericAssertions<decimal> parent, decimal unexpectedValue, decimal precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			decimal num = Math.Abs(unexpectedValue - parent.Subject);
			FailIfDifferenceWithinPrecision(parent, num > precision, unexpectedValue, precision, num, because, becauseArgs);
			return new AndConstraint<NumericAssertions<decimal>>(parent);
		}

		private static void FailIfDifferenceWithinPrecision<T>(NumericAssertions<T> parent, bool differenceOutsidePrecision, T unexpectedValue, T precision, T actualDifference, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs) where T : struct, IComparable<T>
		{
			parent.CurrentAssertionChain.ForCondition(differenceOutsidePrecision).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to not approximate {1} +/- {2}{reason}, but {0} only differed by {3}.", parent.Subject, unexpectedValue, precision, actualDifference);
		}

		public static AndConstraint<NumericAssertions<float>> BeNaN(this NumericAssertions<float> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			float subject = parent.Subject;
			parent.CurrentAssertionChain.ForCondition(float.IsNaN(subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be NaN{reason}, but found {0}.", subject);
			return new AndConstraint<NumericAssertions<float>>(parent);
		}

		public static AndConstraint<NumericAssertions<double>> BeNaN(this NumericAssertions<double> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			double subject = parent.Subject;
			parent.CurrentAssertionChain.ForCondition(double.IsNaN(subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be NaN{reason}, but found {0}.", subject);
			return new AndConstraint<NumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<float>> BeNaN(this NullableNumericAssertions<float> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			float? subject = parent.Subject;
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			int condition;
			if (subject.HasValue)
			{
				float valueOrDefault = subject.GetValueOrDefault();
				condition = (float.IsNaN(valueOrDefault) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			currentAssertionChain.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be NaN{reason}, but found {0}.", subject);
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> BeNaN(this NullableNumericAssertions<double> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			double? subject = parent.Subject;
			AssertionChain currentAssertionChain = parent.CurrentAssertionChain;
			int condition;
			if (subject.HasValue)
			{
				double valueOrDefault = subject.GetValueOrDefault();
				condition = (double.IsNaN(valueOrDefault) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			currentAssertionChain.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be NaN{reason}, but found {0}.", subject);
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		public static AndConstraint<NumericAssertions<float>> NotBeNaN(this NumericAssertions<float> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			float subject = parent.Subject;
			parent.CurrentAssertionChain.ForCondition(!float.IsNaN(subject)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be NaN{reason}.");
			return new AndConstraint<NumericAssertions<float>>(parent);
		}

		public static AndConstraint<NumericAssertions<double>> NotBeNaN(this NumericAssertions<double> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			double subject = parent.Subject;
			parent.CurrentAssertionChain.ForCondition(!double.IsNaN(subject)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be NaN{reason}.");
			return new AndConstraint<NumericAssertions<double>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<float>> NotBeNaN(this NullableNumericAssertions<float> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			float? subject = parent.Subject;
			int num;
			if (subject.HasValue)
			{
				float valueOrDefault = subject.GetValueOrDefault();
				num = (float.IsNaN(valueOrDefault) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			parent.CurrentAssertionChain.ForCondition(!flag).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be NaN{reason}.");
			return new AndConstraint<NullableNumericAssertions<float>>(parent);
		}

		public static AndConstraint<NullableNumericAssertions<double>> NotBeNaN(this NullableNumericAssertions<double> parent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			double? subject = parent.Subject;
			int num;
			if (subject.HasValue)
			{
				double valueOrDefault = subject.GetValueOrDefault();
				num = (double.IsNaN(valueOrDefault) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			parent.CurrentAssertionChain.ForCondition(!flag).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be NaN{reason}.");
			return new AndConstraint<NullableNumericAssertions<double>>(parent);
		}

		private static long GetMinValue(long value, ulong delta)
		{
			long num = ((delta <= long.MaxValue) ? (value - (long)delta) : ((value >= 0) ? (-((long)delta - value)) : long.MinValue));
			if (num > value)
			{
				num = long.MinValue;
			}
			return num;
		}

		private static long GetMaxValue(long value, ulong delta)
		{
			long num = ((delta <= long.MaxValue) ? (value + (long)delta) : ((value < 0) ? (value + (long)delta) : long.MaxValue));
			if (num < value)
			{
				num = long.MaxValue;
			}
			return num;
		}
	}
}

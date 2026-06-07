using System;
using System.Collections;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
	public class Is
	{
		public static ConstraintExpression Not => new ConstraintExpression().Not;

		public static ConstraintExpression All => new ConstraintExpression().All;

		public static NullConstraint Null => new NullConstraint();

		public static TrueConstraint True => new TrueConstraint();

		public static FalseConstraint False => new FalseConstraint();

		public static GreaterThanConstraint Positive => new GreaterThanConstraint(0);

		public static LessThanConstraint Negative => new LessThanConstraint(0);

		public static EqualConstraint Zero => new EqualConstraint(0);

		public static NaNConstraint NaN => new NaNConstraint();

		public static EmptyConstraint Empty => new EmptyConstraint();

		public static UniqueItemsConstraint Unique => new UniqueItemsConstraint();

		public static BinarySerializableConstraint BinarySerializable => new BinarySerializableConstraint();

		public static XmlSerializableConstraint XmlSerializable => new XmlSerializableConstraint();

		public static CollectionOrderedConstraint Ordered => new CollectionOrderedConstraint();

		public static EqualConstraint EqualTo(object expected)
		{
			return new EqualConstraint(expected);
		}

		public static SameAsConstraint SameAs(object expected)
		{
			return new SameAsConstraint(expected);
		}

		public static GreaterThanConstraint GreaterThan(object expected)
		{
			return new GreaterThanConstraint(expected);
		}

		public static GreaterThanOrEqualConstraint GreaterThanOrEqualTo(object expected)
		{
			return new GreaterThanOrEqualConstraint(expected);
		}

		public static GreaterThanOrEqualConstraint AtLeast(object expected)
		{
			return new GreaterThanOrEqualConstraint(expected);
		}

		public static LessThanConstraint LessThan(object expected)
		{
			return new LessThanConstraint(expected);
		}

		public static LessThanOrEqualConstraint LessThanOrEqualTo(object expected)
		{
			return new LessThanOrEqualConstraint(expected);
		}

		public static LessThanOrEqualConstraint AtMost(object expected)
		{
			return new LessThanOrEqualConstraint(expected);
		}

		public static ExactTypeConstraint TypeOf(Type expectedType)
		{
			return new ExactTypeConstraint(expectedType);
		}

		public static ExactTypeConstraint TypeOf<TExpected>()
		{
			return new ExactTypeConstraint(typeof(TExpected));
		}

		public static InstanceOfTypeConstraint InstanceOf(Type expectedType)
		{
			return new InstanceOfTypeConstraint(expectedType);
		}

		public static InstanceOfTypeConstraint InstanceOf<TExpected>()
		{
			return new InstanceOfTypeConstraint(typeof(TExpected));
		}

		public static AssignableFromConstraint AssignableFrom(Type expectedType)
		{
			return new AssignableFromConstraint(expectedType);
		}

		public static AssignableFromConstraint AssignableFrom<TExpected>()
		{
			return new AssignableFromConstraint(typeof(TExpected));
		}

		public static AssignableToConstraint AssignableTo(Type expectedType)
		{
			return new AssignableToConstraint(expectedType);
		}

		public static AssignableToConstraint AssignableTo<TExpected>()
		{
			return new AssignableToConstraint(typeof(TExpected));
		}

		public static CollectionEquivalentConstraint EquivalentTo(IEnumerable expected)
		{
			return new CollectionEquivalentConstraint(expected);
		}

		public static CollectionSubsetConstraint SubsetOf(IEnumerable expected)
		{
			return new CollectionSubsetConstraint(expected);
		}

		public static CollectionSupersetConstraint SupersetOf(IEnumerable expected)
		{
			return new CollectionSupersetConstraint(expected);
		}

		[Obsolete("Deprecated, use Does.Contain")]
		public static SubstringConstraint StringContaining(string expected)
		{
			return new SubstringConstraint(expected);
		}

		[Obsolete("Deprecated, use Does.StartWith")]
		public static StartsWithConstraint StringStarting(string expected)
		{
			return new StartsWithConstraint(expected);
		}

		[Obsolete("Deprecated, use Does.EndWith")]
		public static EndsWithConstraint StringEnding(string expected)
		{
			return new EndsWithConstraint(expected);
		}

		[Obsolete("Deprecated, use Does.Match")]
		public static RegexConstraint StringMatching(string pattern)
		{
			return new RegexConstraint(pattern);
		}

		public static SamePathConstraint SamePath(string expected)
		{
			return new SamePathConstraint(expected);
		}

		public static SubPathConstraint SubPathOf(string expected)
		{
			return new SubPathConstraint(expected);
		}

		public static SamePathOrUnderConstraint SamePathOrUnder(string expected)
		{
			return new SamePathOrUnderConstraint(expected);
		}

		public static RangeConstraint InRange(IComparable from, IComparable to)
		{
			return new RangeConstraint(from, to);
		}
	}
}

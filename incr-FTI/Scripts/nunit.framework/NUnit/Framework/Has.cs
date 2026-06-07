using System;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
	public class Has
	{
		public static ConstraintExpression No => new ConstraintExpression().Not;

		public static ConstraintExpression All => new ConstraintExpression().All;

		public static ConstraintExpression Some => new ConstraintExpression().Some;

		public static ConstraintExpression None => new ConstraintExpression().None;

		public static ResolvableConstraintExpression Length => Property("Length");

		public static ResolvableConstraintExpression Count => Property("Count");

		public static ResolvableConstraintExpression Message => Property("Message");

		public static ResolvableConstraintExpression InnerException => Property("InnerException");

		public static ConstraintExpression Exactly(int expectedCount)
		{
			return new ConstraintExpression().Exactly(expectedCount);
		}

		public static ResolvableConstraintExpression Property(string name)
		{
			return new ConstraintExpression().Property(name);
		}

		public static ResolvableConstraintExpression Attribute(Type expectedType)
		{
			return new ConstraintExpression().Attribute(expectedType);
		}

		public static ResolvableConstraintExpression Attribute<T>()
		{
			return Attribute(typeof(T));
		}

		public static CollectionContainsConstraint Member(object expected)
		{
			return new CollectionContainsConstraint(expected);
		}
	}
}

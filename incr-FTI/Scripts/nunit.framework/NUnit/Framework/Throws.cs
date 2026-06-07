using System;
using System.Reflection;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
	public class Throws
	{
		public static ResolvableConstraintExpression Exception => new ConstraintExpression().Append(new ThrowsOperator());

		public static ResolvableConstraintExpression InnerException => Exception.InnerException;

		public static ExactTypeConstraint TargetInvocationException => TypeOf(typeof(TargetInvocationException));

		public static ExactTypeConstraint ArgumentException => TypeOf(typeof(ArgumentException));

		public static ExactTypeConstraint ArgumentNullException => TypeOf(typeof(ArgumentNullException));

		public static ExactTypeConstraint InvalidOperationException => TypeOf(typeof(InvalidOperationException));

		public static ThrowsNothingConstraint Nothing => new ThrowsNothingConstraint();

		public static ExactTypeConstraint TypeOf(Type expectedType)
		{
			return Exception.TypeOf(expectedType);
		}

		public static ExactTypeConstraint TypeOf<TExpected>()
		{
			return TypeOf(typeof(TExpected));
		}

		public static InstanceOfTypeConstraint InstanceOf(Type expectedType)
		{
			return Exception.InstanceOf(expectedType);
		}

		public static InstanceOfTypeConstraint InstanceOf<TExpected>()
		{
			return InstanceOf(typeof(TExpected));
		}
	}
}

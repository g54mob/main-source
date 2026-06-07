using System;

namespace NUnit.Framework.Constraints
{
	internal class ExceptionNotThrownConstraint : Constraint
	{
		public override string Description => "No Exception to be thrown";

		public override ConstraintResult ApplyTo(object actual)
		{
			Exception ex = actual as Exception;
			return new ConstraintResult(this, ex, ex == null);
		}
	}
}

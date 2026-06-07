namespace NUnit.Framework.Constraints
{
	public class ResolvableConstraintExpression : ConstraintExpression, IResolveConstraint
	{
		public ConstraintExpression And => Append(new AndOperator());

		public ConstraintExpression Or => Append(new OrOperator());

		public ResolvableConstraintExpression()
		{
		}

		public ResolvableConstraintExpression(ConstraintBuilder builder)
			: base(builder)
		{
		}

		IConstraint IResolveConstraint.Resolve()
		{
			return builder.Resolve();
		}
	}
}

namespace NUnit.Framework.Constraints
{
	public class GreaterThanOrEqualConstraint : ComparisonConstraint
	{
		public GreaterThanOrEqualConstraint(object expected)
			: base(expected, lessComparisonResult: false, equalComparisonResult: true, greaterComparisonResult: true, "greater than or equal to")
		{
		}
	}
}

namespace NUnit.Framework.Constraints
{
	public class GreaterThanConstraint : ComparisonConstraint
	{
		public GreaterThanConstraint(object expected)
			: base(expected, lessComparisonResult: false, equalComparisonResult: false, greaterComparisonResult: true, "greater than")
		{
		}
	}
}

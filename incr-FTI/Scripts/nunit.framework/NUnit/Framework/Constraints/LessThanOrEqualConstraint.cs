namespace NUnit.Framework.Constraints
{
	public class LessThanOrEqualConstraint : ComparisonConstraint
	{
		public LessThanOrEqualConstraint(object expected)
			: base(expected, lessComparisonResult: true, equalComparisonResult: true, greaterComparisonResult: false, "less than or equal to")
		{
		}
	}
}

namespace NUnit.Framework.Constraints
{
	public class LessThanConstraint : ComparisonConstraint
	{
		public LessThanConstraint(object expected)
			: base(expected, lessComparisonResult: true, equalComparisonResult: false, greaterComparisonResult: false, "less than")
		{
		}
	}
}

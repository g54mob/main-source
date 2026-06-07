namespace NUnit.Framework.Constraints
{
	public class EmptyStringConstraint : StringConstraint
	{
		public override string Description => "<empty>";

		protected override bool Matches(string actual)
		{
			return actual == string.Empty;
		}
	}
}

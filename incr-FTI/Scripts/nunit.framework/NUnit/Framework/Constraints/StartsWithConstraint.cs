namespace NUnit.Framework.Constraints
{
	public class StartsWithConstraint : StringConstraint
	{
		public StartsWithConstraint(string expected)
			: base(expected)
		{
			descriptionText = "String starting with";
		}

		protected override bool Matches(string actual)
		{
			if (caseInsensitive)
			{
				return actual?.ToLower().StartsWith(expected.ToLower()) ?? false;
			}
			return actual?.StartsWith(expected) ?? false;
		}
	}
}

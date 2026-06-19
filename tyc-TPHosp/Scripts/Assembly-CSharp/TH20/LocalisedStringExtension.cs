namespace TH20
{
	public static class LocalisedStringExtension
	{
		public static bool IsNull(this LocalisedString localisedString)
		{
			return localisedString.Term.IsNullOrEmpty();
		}
	}
}

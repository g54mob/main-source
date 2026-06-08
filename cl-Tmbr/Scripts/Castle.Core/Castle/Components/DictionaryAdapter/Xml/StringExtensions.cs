namespace Castle.Components.DictionaryAdapter.Xml
{
	internal static class StringExtensions
	{
		public static string NonEmpty(this string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				return s;
			}
			return null;
		}
	}
}

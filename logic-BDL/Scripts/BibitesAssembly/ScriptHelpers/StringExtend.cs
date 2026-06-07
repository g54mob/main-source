namespace ScriptHelpers
{
	public static class StringExtend
	{
		public static string Capitalize(this string str)
		{
			str = str.ToLower();
			return $"{char.ToUpper(str[0])}{str.Substring(1)}";
		}

		public static string ToSpeciesFormat(this string str)
		{
			string[] array = str.Split(' ');
			return array[0].Capitalize() + " " + ((array.Length > 1) ? array[1] : array[0]).ToLower();
		}
	}
}

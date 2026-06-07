using System.Text;

namespace Utils
{
	public static class StringExtensions
	{
		public static string SanitizeSpaces(this string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			return value.Normalize(NormalizationForm.FormC).Replace(" ", "_");
		}

		public static string UnsanitizeSpaces(this string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			return value.Replace("_", " ");
		}
	}
}

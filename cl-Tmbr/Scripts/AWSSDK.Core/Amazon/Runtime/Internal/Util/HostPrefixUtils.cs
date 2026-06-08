using System.Text.RegularExpressions;

namespace Amazon.Runtime.Internal.Util
{
	public static class HostPrefixUtils
	{
		private const string LabelValidationRegexPattern = "^[A-Za-z0-9\\-]+$";

		private static Regex _labelValidationRegex = new Regex("^[A-Za-z0-9\\-]+$", RegexOptions.Compiled | RegexOptions.Singleline);

		private static Regex LabelValidationRegex()
		{
			return _labelValidationRegex;
		}

		public static bool IsValidLabelValue(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			if (value.Length < 1 || value.Length > 63)
			{
				return false;
			}
			if (!LabelValidationRegex().IsMatch(value))
			{
				return false;
			}
			return true;
		}
	}
}

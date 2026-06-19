using System.Text.RegularExpressions;

namespace Pug.UnityExtensions
{
	public static class StringExtensions
	{
		public static bool Like(this string str, string pattern)
		{
			return new Regex("^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$", RegexOptions.IgnoreCase | RegexOptions.Singleline).IsMatch(str);
		}
	}
}

using System.Linq;
using System.Text.RegularExpressions;

namespace Barmetler.RoadSystem.Util
{
	public static class StringUtility
	{
		public static string GetInitials(string str)
		{
			if (str == null)
			{
				return null;
			}
			MatchCollection source = ((!Regex.IsMatch(str, "^([A-Z][a-z0-9_]*)+$")) ? Regex.Matches(str, "([A-Za-z][^ \\-_]*)") : Regex.Matches(str, "([A-Z][^A-Z]*)"));
			return string.Join("", from Match g in source
				where g.Value.Length > 0
				select (g.Value.ToCharArray()[0].ToString() ?? "").ToUpper());
		}
	}
}

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LaundryBear
{
	public static class RegexExtensions
	{
		public static string ReplaceGroup(this Regex regex, string input, string groupName, string replacement)
		{
			return regex.Replace(input, delegate(Match match)
			{
				Group obj = match.Groups[groupName];
				StringBuilder stringBuilder = new StringBuilder();
				int num = 0;
				foreach (Capture item in obj.Captures.Cast<Capture>())
				{
					int num2 = item.Index + item.Length - match.Index;
					int length = item.Index - match.Index - num;
					stringBuilder.Append(match.Value.Substring(num, length));
					stringBuilder.Append(replacement);
					num = num2;
				}
				stringBuilder.Append(match.Value.Substring(num));
				return stringBuilder.ToString();
			});
		}
	}
}

using System.Globalization;
using System.Text.RegularExpressions;

namespace Helpers.Extensions
{
	public static class NumberExtensions
	{
		private static readonly NumberFormatInfo nfi = new NumberFormatInfo
		{
			NumberGroupSeparator = "\u202f",
			NumberGroupSizes = new int[1] { 3 }
		};

		public static string ToReadableString(this int value)
		{
			return value.ToString("N0", nfi);
		}

		public static int GameVersionNumber(this string gameVersion)
		{
			try
			{
				string[] array = gameVersion.Split('.');
				int num = ((array.Length != 0) ? int.Parse(array[0]) : 0);
				int num2 = ((array.Length > 1) ? int.Parse(array[1]) : 0);
				int num3 = 0;
				if (array.Length > 2)
				{
					Match match = Regex.Match(array[2], "\\d+");
					if (match.Success)
					{
						num3 = int.Parse(match.Value);
					}
				}
				return num * 1000000 + num2 * 1000 + num3;
			}
			catch
			{
				return 0;
			}
		}
	}
}

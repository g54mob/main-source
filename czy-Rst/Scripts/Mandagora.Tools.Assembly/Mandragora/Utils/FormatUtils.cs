using System.Globalization;

namespace Mandragora.Utils
{
	public class FormatUtils
	{
		public static float ConvertToFloat(string value)
		{
			string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (!(numberDecimalSeparator == "."))
			{
				if (numberDecimalSeparator == ",")
				{
					value = value.Replace(".", ",");
				}
			}
			else
			{
				value = value.Replace(",", ".");
			}
			if (float.TryParse(value, out var result))
			{
				return result;
			}
			if (float.TryParse(value.Replace(".", ","), out result))
			{
				return result;
			}
			return float.NaN;
		}
	}
}

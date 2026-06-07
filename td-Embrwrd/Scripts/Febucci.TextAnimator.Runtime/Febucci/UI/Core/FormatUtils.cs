using System.Collections.Generic;

namespace Febucci.UI.Core
{
	public static class FormatUtils
	{
		public static bool TryGetFloat(List<string> attributes, int index, float defValue, out float result)
		{
			result = default(float);
			return false;
		}

		public static bool TryGetFloat(string attribute, float defValue, out float result)
		{
			result = default(float);
			return false;
		}

		public static bool ParseFloat(string value, out float result)
		{
			result = default(float);
			return false;
		}
	}
}

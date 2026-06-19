using System.Collections.Generic;
using System.Globalization;
using I2.Loc;

namespace TH20
{
	public static class LocalisationParams
	{
		private static Dictionary<string, object> _parameters = new Dictionary<string, object>();

		public static void Set(string param, string value)
		{
			if (_parameters.ContainsKey(param))
			{
				_parameters[param] = value;
			}
			else
			{
				_parameters.Add(param, value);
			}
		}

		public static void Set(string param, int value)
		{
			Set(param, StringUtils.FormatNumber(value));
		}

		public static void Set(string param, float value)
		{
			Set(param, value.ToString(CultureInfo.InvariantCulture));
		}

		public static string Localise(ref string text)
		{
			LocalizationManager.ApplyLocalizationParams(ref text, _parameters);
			return text;
		}
	}
}

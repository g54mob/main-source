using UnityEngine;

namespace ScriptHelpers
{
	public static class FloatFormatter
	{
		public struct ScientificPrefix
		{
			public string prefix;

			public int valueExponent;

			public int unitExponent;

			public float valueFactor => Mathf.Pow(10f, valueExponent);

			public float unitFactor => Mathf.Pow(10f, unitExponent);

			public ScientificPrefix(int exponentOfValue)
			{
				valueExponent = exponentOfValue;
				unitExponent = 3 * Mathf.FloorToInt((float)exponentOfValue / 3f);
				prefix = unitExponent switch
				{
					-12 => "f", 
					-9 => "n", 
					-6 => "μ", 
					-3 => "m", 
					0 => "", 
					3 => "k", 
					6 => "M", 
					9 => "G", 
					12 => "T", 
					_ => "", 
				};
			}

			public override string ToString()
			{
				return prefix;
			}
		}

		public static string ScientificFormat(this float val, int precision, string units = "", bool alwaysShowSign = false, bool prefixWithUnits = true, bool scientificPrecision = true, bool SIUnits = true, bool isInt = false)
		{
			string text = ((!(val >= 0f)) ? "-" : (alwaysShowSign ? "+" : ""));
			float num = Mathf.Abs(val);
			ScientificPrefix scientificPrefix = val.SIPrefix();
			if (isInt && scientificPrefix.unitExponent == 0)
			{
				precision = 0;
			}
			string text2;
			if (scientificPrecision)
			{
				precision -= scientificPrefix.valueExponent;
				float num2 = Mathf.Pow(10f, precision);
				num = Mathf.Round(num * num2) / num2;
				text2 = text + (num / scientificPrefix.unitFactor).ToString("F" + Mathf.Max(0, precision + scientificPrefix.unitExponent));
			}
			else
			{
				text2 = text + (num / scientificPrefix.unitFactor).ToString("F" + precision);
			}
			if (SIUnits)
			{
				return text2 + (prefixWithUnits ? " " : "") + scientificPrefix.prefix + (prefixWithUnits ? "" : " ") + units.Replace(" ", "");
			}
			return text + num.ToString("F" + Mathf.Max(precision, 0)) + units;
		}

		public static string ScientificFormat(this int val, int precision, string units = "", bool alwaysShowSign = false, bool prefixWithUnits = false)
		{
			return ScientificFormat(val, precision, units, alwaysShowSign, prefixWithUnits, true, true, false);
		}

		public static string ScientificFormat(this long val, int precision, string units = "", bool alwaysShowSign = false, bool prefixWithUnits = false)
		{
			return ScientificFormat(val, precision, units, alwaysShowSign, prefixWithUnits, true, true, false);
		}

		public static ScientificPrefix SIPrefix(this float val)
		{
			float num = Mathf.Abs(val);
			if (Mathf.Approximately(num, 0f))
			{
				return new ScientificPrefix(0);
			}
			return new ScientificPrefix(Mathf.FloorToInt(Mathf.Log10(num)));
		}

		public static ScientificPrefix SIPrefix(this int val)
		{
			return ((float)val).SIPrefix();
		}

		public static ScientificPrefix SIPrefix(this long val)
		{
			return ((float)val).SIPrefix();
		}
	}
}

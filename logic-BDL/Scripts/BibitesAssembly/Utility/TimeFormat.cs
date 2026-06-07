using System;
using ScriptHelpers;

namespace Utility
{
	public struct TimeFormat
	{
		public Timescale scale;

		public string units;

		public float factor;

		public float val;

		public TimeFormat(float value, Timescale valueScale)
		{
			value *= FactorAtTimeScale(valueScale);
			if (value < FactorAtTimeScale(Timescale.Seconds))
			{
				FloatFormatter.ScientificPrefix scientificPrefix = value.SIPrefix();
				scale = Timescale.SubSeconds;
				units = scientificPrefix.prefix + "s";
				factor = scientificPrefix.unitFactor;
				val = value / factor;
				return;
			}
			if (value < FactorAtTimeScale(Timescale.Minutes))
			{
				scale = Timescale.Seconds;
			}
			else if (value < FactorAtTimeScale(Timescale.Hours))
			{
				scale = Timescale.Minutes;
			}
			else if (value < FactorAtTimeScale(Timescale.Days))
			{
				scale = Timescale.Hours;
			}
			else if (value < FactorAtTimeScale(Timescale.Months))
			{
				scale = Timescale.Days;
			}
			else if (value < FactorAtTimeScale(Timescale.Years))
			{
				scale = Timescale.Months;
			}
			else
			{
				scale = Timescale.Years;
			}
			units = SmallUnitsAtTimeScale(scale);
			factor = FactorAtTimeScale(scale);
			val = value / factor;
		}

		public string FormattedValue(float value, int precision = 0, Timescale scale = Timescale.Seconds)
		{
			float num = FactorAtTimeScale(scale);
			return (value * num / factor).ToString($"F{precision}") + " " + units;
		}

		public string FormattedValue(int precision = 0)
		{
			return val.ToString($"F{precision}") + units;
		}

		public string FormattedTimeValue(int unitsPrecision, string spacer = " ", bool smallUnits = true, bool spaceBeforeUnits = false, Timescale minTimescale = Timescale.Seconds)
		{
			string text = (spaceBeforeUnits ? " " : "");
			string text2 = "";
			int num = (int)scale;
			float num2 = val;
			Timescale timescale = scale;
			for (int i = 0; i <= unitsPrecision; i++)
			{
				int num3 = num - i;
				if (num3 < (int)minTimescale)
				{
					break;
				}
				Timescale timescale2 = (Timescale)num3;
				float num4 = FactorFromTimeScaleTo(timescale, timescale2);
				string text3 = (smallUnits ? SmallUnitsAtTimeScale(timescale2) : BigUnitsAtTimeScale(timescale2));
				num2 *= num4;
				float num5 = num2.FloorApproximately();
				if (num3 > 1)
				{
					text2 += string.Format("{0}{1:F0}{2}{3}", (num3 < num) ? spacer : "", num5, spaceBeforeUnits ? " " : "", text3);
					timescale = timescale2;
					num2 -= num5;
					continue;
				}
				text2 = text2 + ((num3 < num) ? spacer : "") + num2.ToString($"F{num + 1 - unitsPrecision}") + text + text3;
				break;
			}
			return text2;
		}

		public static float FactorAtTimeScale(Timescale val)
		{
			return val switch
			{
				Timescale.Seconds => 1f, 
				Timescale.Minutes => 60f, 
				Timescale.Hours => 3600f, 
				Timescale.Days => 86400f, 
				Timescale.Months => 2592000f, 
				Timescale.Years => 31104000f, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static string SmallUnitsAtTimeScale(Timescale val)
		{
			return val switch
			{
				Timescale.Seconds => "s", 
				Timescale.Minutes => "m", 
				Timescale.Hours => "h", 
				Timescale.Days => "d", 
				Timescale.Months => "M", 
				Timescale.Years => "y", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static string BigUnitsAtTimeScale(Timescale val)
		{
			return val switch
			{
				Timescale.Seconds => "seconds", 
				Timescale.Minutes => "minutes", 
				Timescale.Hours => "hours", 
				Timescale.Days => "days", 
				Timescale.Months => "months", 
				Timescale.Years => "years", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static float FactorFromTimeScaleTo(Timescale from, Timescale to)
		{
			return FactorAtTimeScale(from) / FactorAtTimeScale(to);
		}
	}
}

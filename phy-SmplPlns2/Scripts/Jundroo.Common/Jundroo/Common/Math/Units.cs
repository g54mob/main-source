using System;
using System.Text;
using UnityEngine;

namespace Jundroo.Common.Math
{
	public static class Units
	{
		public enum UnitPrecisionMode
		{
			Normal = 0,
			High = 1
		}

		public const float FeetToMeters = 0.3048f;

		public const float FuelDensity = 0.804f;

		public const float KilogramsToPounds = 2.20462f;

		public const float MetersPerSecondToKnots = 1.943844f;

		public const float MetersPerSecondToMilesPerHour = 2.23694f;

		public const float MetersToFeet = 3.28084f;

		public const float MetersToMiles = 0.000621371f;

		public const float PoundsToKilograms = 0.45359293f;

		[ThreadStatic]
		private static StringBuilder _sb;

		public static UnitSystem CurrentUnitSystem { get; set; }

		public static string MetersOrFeetStringLower
		{
			get
			{
				if (CurrentUnitSystem != UnitSystem.Metric)
				{
					return "feet";
				}
				return "meters";
			}
		}

		public static string MetersOrFeetStringUpper
		{
			get
			{
				if (CurrentUnitSystem != UnitSystem.Metric)
				{
					return "Feet";
				}
				return "Meters";
			}
		}

		static Units()
		{
			_sb = new StringBuilder();
			CurrentUnitSystem = UnitSystem.Metric;
		}

		public static string Format(this float value, UnitType type, bool solo = false, bool longName = false, string format = "#,##0", bool rtf = false)
		{
			UnitSystem.Unit unit = CurrentUnitSystem.Units[type];
			value *= unit.Factor;
			if (solo)
			{
				return value.ToString(format);
			}
			StringBuilder sb = _sb;
			sb.Clear();
			sb.Append(value.ToString(format));
			if (longName)
			{
				sb.Append(' ');
				sb.Append(unit.Name);
			}
			else
			{
				sb.Append(rtf ? (unit.AbbreviationRT ?? unit.Abbreviation) : unit.Abbreviation);
			}
			return sb.ToString();
		}

		public static string GetAccelerationString(float acceleration)
		{
			if (!IsFinite(acceleration))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				float num = acceleration * 3.28084f;
				return $"{num:n1}ft/s2";
			}
			return $"{acceleration:n1}m/s2";
		}

		public static string GetAngleString(float degrees, int decimalPlaces)
		{
			return degrees.ToString($"n{decimalPlaces}") + "°";
		}

		public static string GetAngularVelocityString(float v)
		{
			return $"{v:n2}deg/s";
		}

		public static string GetDensityString(float density)
		{
			if (!IsFinite(density))
			{
				return "N/A";
			}
			if (density > 0.01f)
			{
				return density.ToString("n3") + "kg/m3";
			}
			return (density * 1000f).ToString("n1") + "g/m3";
		}

		public static string GetDistanceString(float distanceInMeters)
		{
			if (!IsFinite(distanceInMeters))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				return (distanceInMeters * 3.28084f).ToString("n1") + "ft";
			}
			if (distanceInMeters >= 1E+11f)
			{
				return (distanceInMeters / 1E+09f).ToString("n1") + "Gm";
			}
			if (distanceInMeters >= 100000000f)
			{
				return (distanceInMeters / 1000000f).ToString("n1") + "Mm";
			}
			if (distanceInMeters >= 1000000f)
			{
				return (distanceInMeters / 1000f).ToString("n0") + "km";
			}
			if (distanceInMeters >= 1000f)
			{
				return (distanceInMeters / 1000f).ToString("n1") + "km";
			}
			return distanceInMeters.ToString("n1") + "m";
		}

		public static string GetEnergyString(float energy)
		{
			if (!IsFinite(energy))
			{
				return "N/A";
			}
			if (energy >= 1E+09f)
			{
				return $"{energy / 1E+09f:n1} GJ";
			}
			if (energy >= 1000000f)
			{
				return $"{energy / 1000000f:n1}MJ";
			}
			if (energy >= 1000f)
			{
				return $"{energy / 1000f:n1}kJ";
			}
			return $"{energy:n1}J";
		}

		public static string GetForceString(float forceInNewtons)
		{
			if (!IsFinite(forceInNewtons))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				return ((int)((float)(int)((0.22480895f * forceInNewtons + 5f) / 10f) * 10f)).ToString("#,##0") + "lbf";
			}
			float f = forceInNewtons / 1000f;
			if (Mathf.Abs(f) < 1f)
			{
				return f.ToString("n3") + "kN";
			}
			if (Mathf.Abs(f) < 10f)
			{
				return f.ToString("n2") + "kN";
			}
			if (Mathf.Abs(f) < 100f)
			{
				return f.ToString("n1") + "kN";
			}
			return f.ToString("n0") + "kN";
		}

		public static string GetIspString(float isp)
		{
			if (!IsFinite(isp))
			{
				return "N/A";
			}
			return $"{isp:n0}s";
		}

		public static string GetMassFlowRateString(float currentMassFlowRate)
		{
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				float num = currentMassFlowRate * 2.20462f;
				return $"{num:n1}lbs/s";
			}
			return $"{currentMassFlowRate:n1}kg/s";
		}

		public static string GetMassString(float massInKg)
		{
			if (!IsFinite(massInKg))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				return Mathf.RoundToInt(2.20462f * massInKg).ToString("#,##0") + "lbs";
			}
			return Mathf.RoundToInt(massInKg).ToString("#,##0") + "kg";
		}

		public static string GetMemoryString(long size)
		{
			if (size > 1073741824)
			{
				return $"{(double)size / 1024.0 / 1024.0 / 1024.0:n1} GB";
			}
			if (size > 1048576)
			{
				return $"{(double)size / 1024.0 / 1024.0:n1} MB";
			}
			if (size > 1024)
			{
				return $"{(double)size / 1024.0:n1} kB";
			}
			return $"{size:n0} bytes";
		}

		public static string GetPercentageString(float percentage)
		{
			return $"{percentage * 100f:n0}%";
		}

		public static string GetPercentageString(float value, float total)
		{
			if (!IsFinite(value))
			{
				return "N/A";
			}
			float percentage = 0f;
			if (total > 0f)
			{
				percentage = value / total;
			}
			return GetPercentageString(percentage);
		}

		public static string GetPowerString(float power)
		{
			if (!IsFinite(power))
			{
				return "N/A";
			}
			if (power < 0f)
			{
				return "-" + GetPowerString(0f - power);
			}
			if (power >= 1E+09f)
			{
				return $"{power / 1E+09f:n1} GW";
			}
			if (power >= 1000000f)
			{
				return $"{power / 1000000f:n1}MW";
			}
			if (power >= 1000f)
			{
				return $"{power / 1000f:n1}kW";
			}
			return $"{power:n0}W";
		}

		public static string GetPressureString(float pressure)
		{
			if (!IsFinite(pressure))
			{
				return "N/A";
			}
			if (pressure >= 100000f)
			{
				return (pressure / 1000000f).ToString("n2") + "MPa";
			}
			if (pressure >= 10000f)
			{
				return (pressure / 1000f).ToString("n0") + "kPa";
			}
			if (pressure >= 1000f)
			{
				return (pressure / 1000f).ToString("n1") + "kPa";
			}
			return pressure.ToString("n0") + "Pa";
		}

		public static string GetPriceString(long price)
		{
			if (!IsFinite(price))
			{
				return "N/A";
			}
			if (price >= 1000000000)
			{
				return $"${(float)price / 1E+09f:n1}B";
			}
			if (price >= 1000000)
			{
				return $"${(float)price / 1000000f:n1}M";
			}
			if (price >= 10000)
			{
				return $"${(float)price / 1000f:n0}k";
			}
			return $"${price:n0}";
		}

		public static string GetRatioString(float num, float den)
		{
			float ratio = 0f;
			if (den != 0f)
			{
				ratio = num / den;
			}
			return GetRatioString(ratio);
		}

		public static string GetRatioString(float ratio)
		{
			return $"{ratio:n2}x";
		}

		public static string GetRelativeTimeString(double seconds)
		{
			if (!IsFinite(seconds))
			{
				return "N/A";
			}
			string empty = string.Empty;
			if (seconds > 31536000.0)
			{
				double num = seconds / 31536000.0;
				if (num >= 1000.0)
				{
					return $"{num:n0}years";
				}
				if (num >= 100.0)
				{
					return $"{num:n1}years";
				}
				return $"{num:n2}years";
			}
			if (seconds > 86400.0)
			{
				double num2 = seconds / 86400.0;
				return $"{num2:n2}days";
			}
			if (seconds > 3600.0)
			{
				double num3 = seconds / 3600.0;
				seconds -= num3 * 3600.0;
				return $"{num3:n2}hours";
			}
			if (seconds > 90.0)
			{
				double num4 = seconds / 60.0;
				return $"{num4:n1}m";
			}
			return empty + $"{seconds:n0}s";
		}

		public static string GetStopwatchTimeString(double seconds)
		{
			if (!IsFinite(seconds))
			{
				return "N/A";
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			string text = string.Empty;
			if (seconds > 86400.0)
			{
				num = System.Math.Floor(seconds / 86400.0);
				seconds -= num * 86400.0;
				text += $"{num:n0}d ";
			}
			if (seconds > 3600.0)
			{
				num2 = System.Math.Floor(seconds / 3600.0);
				seconds -= num2 * 3600.0;
				text += $"{num2:n0}h ";
			}
			if (seconds > 60.0)
			{
				num3 = System.Math.Floor(seconds / 60.0);
				seconds -= num3 * 60.0;
				text += $"{num3:n0}m ";
			}
			return text + $"{seconds:n2}s";
		}

		public static string GetTemperatureString(float temperatureInKelvin)
		{
			if (!IsFinite(temperatureInKelvin))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				float num = temperatureInKelvin * 9f / 5f - 459.67f;
				return $"{num:0.0}°F";
			}
			float num2 = temperatureInKelvin - 273.15f;
			return $"{num2:0.0}°C";
		}

		public static string GetVelocityString(float v, UnitPrecisionMode precision = UnitPrecisionMode.Normal)
		{
			if (!IsFinite(v))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				float num = v * 2.23694f;
				return $"{num:n1}mph";
			}
			if (CurrentUnitSystem == UnitSystem.Nautical)
			{
				float num2 = v * 1.943844f;
				return $"{num2:n1}kt";
			}
			if (Mathf.Abs(v) >= 10000f)
			{
				float num3 = v / 1000f;
				return $"{num3:n1}km/s";
			}
			if (Mathf.Abs(v) > 1f || precision == UnitPrecisionMode.Normal)
			{
				return $"{v:n0}m/s";
			}
			float num4 = v * 100f;
			return $"{num4:n0}cm/s";
		}

		public static string GetVolumeString(float volumeInLiters)
		{
			if (!IsFinite(volumeInLiters))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial || CurrentUnitSystem == UnitSystem.Nautical)
			{
				return ((int)(0.264172f * volumeInLiters)).ToString("n0") + "gal";
			}
			if (volumeInLiters < 10000f)
			{
				return volumeInLiters.ToString("n0") + "L";
			}
			if (volumeInLiters < 100000000f)
			{
				return (volumeInLiters / 1000f).ToString("n1") + "kL";
			}
			return (volumeInLiters / 1000000f).ToString("n1") + "ML";
		}

		public static bool IsFinite(double value)
		{
			if (!double.IsInfinity(value))
			{
				return !double.IsNaN(value);
			}
			return false;
		}

		public static string GetTorqueString(float torque)
		{
			return MetricPrefix(torque, "Nm");
		}

		public static string MetricPrefix(double value, string unit, bool hasCents = false)
		{
			if (!IsFinite(value))
			{
				return "N/A";
			}
			if (value < 0.0)
			{
				return "-" + MetricPrefix(0.0 - value, unit);
			}
			if (value >= 100000000000.0)
			{
				return string.Format("{0:n0}G" + unit, value * 1E-09);
			}
			if (value >= 10000000000.0)
			{
				return string.Format("{0:n1}G" + unit, value * 1E-09);
			}
			if (value >= 100000000.0)
			{
				return string.Format("{0:n0}M" + unit, value * 1E-06);
			}
			if (value >= 10000000.0)
			{
				return string.Format("{0:n1}M" + unit, value * 1E-06);
			}
			if (value >= 100000.0)
			{
				return string.Format("{0:n0}k" + unit, value * 0.001);
			}
			if (value >= 10000.0)
			{
				return string.Format("{0:n1}k" + unit, value * 0.001);
			}
			if (value >= 1000.0)
			{
				return string.Format("{0:n2}k" + unit, value * 0.001);
			}
			if (value >= 100.0)
			{
				return string.Format("{0:n0}" + unit, value);
			}
			if (value >= 10.0)
			{
				return string.Format("{0:n1}" + unit, value);
			}
			if (value >= 0.0 || !hasCents)
			{
				return string.Format("{0:n2}" + unit, value);
			}
			if (value >= 0.01)
			{
				return string.Format("{0:n3}c" + unit, value * 100.0);
			}
			return string.Format("{0:n0}m" + unit, value * 1000.0);
		}
	}
}

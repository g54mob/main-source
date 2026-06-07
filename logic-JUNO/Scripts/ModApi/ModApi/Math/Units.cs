using UnityEngine;

namespace ModApi.Math
{
	public static class Units
	{
		public enum UnitPrecisionMode
		{
			Normal = 0,
			High = 1
		}

		public enum UnitSystem
		{
			Metric = 0,
			Imperial = 1
		}

		public const float FeetToMeters = 0.3048f;

		public const float FuelMassInKgPerLiter = 0.804f;

		public const float KilogramsToPounds = 2.20462f;

		public const float MetersPerSecondToMilesPerHour = 2.23694f;

		public const float MetersToFeet = 3.28084f;

		public const float MetersToMiles = 0.000621371f;

		public const float PoundsToKilograms = 0.45359293f;

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
			CurrentUnitSystem = UnitSystem.Metric;
		}

		public static string GetAccelerationString(float acceleration)
		{
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(acceleration))
				{
					return "N/A";
				}
				float num = acceleration * 3.28084f;
				return $"{num:n1}ft/s2";
			}
			return MetricPrefix(acceleration, "m/s2");
		}

		public static string GetAngleString(float degrees, int decimalPlaces)
		{
			return degrees.ToString($"n{decimalPlaces}") + "°";
		}

		public static string GetAngularVelocityString(float v)
		{
			return $"{v:n2}deg/s";
		}

		public static string GetCoordinatesString(Vector3 latlonagl)
		{
			string text = string.Empty;
			if (latlonagl.z != 0f)
			{
				text = text + "Altitude: " + GetDistanceString(latlonagl.z) + " ";
			}
			text += string.Format("{0:n2}º{1} ", Mathf.Abs(latlonagl.x), (latlonagl.x >= 0f) ? "N" : "S");
			return text + string.Format("{0:n2}º{1} ", Mathf.Abs(latlonagl.y), (latlonagl.y >= 0f) ? "E" : "W");
		}

		public static string GetDensityString(float density)
		{
			return MetricPrefix((double)density * 1000.0, "g/m3");
		}

		public static string GetDistanceString(float distanceInMeters, bool useAbsoluteValue = true, UnitPrecisionMode precision = UnitPrecisionMode.Normal, bool isArea = false)
		{
			if (useAbsoluteValue)
			{
				distanceInMeters = Mathf.Abs(distanceInMeters);
			}
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(distanceInMeters))
				{
					return "N/A";
				}
				return (distanceInMeters * 3.28084f).ToString("n1") + (isArea ? "ft2" : "ft");
			}
			return MetricPrefix(distanceInMeters, isArea ? "m2" : "m", precision == UnitPrecisionMode.High);
		}

		public static string GetEnergyString(float energy)
		{
			if (!IsFinite(energy))
			{
				return "N/A";
			}
			energy /= 3600f;
			return MetricPrefix(energy, "Wh");
		}

		public static string GetForceString(float forceInScaledNewtons)
		{
			float num = forceInScaledNewtons * 100f;
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(forceInScaledNewtons))
				{
					return "N/A";
				}
				return ((int)((float)(int)((0.22480895f * num + 5f) / 10f) * 10f)).ToString("#,##0") + "lbf";
			}
			return MetricPrefix(num, "N");
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
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				float num = currentMassFlowRate * 2.20462f;
				return $"{num:n1}lbs/s";
			}
			return MetricPrefix((double)currentMassFlowRate * 1000.0, "g/s");
		}

		public static string GetMassString(float massInScaledKg)
		{
			float num = massInScaledKg * 100f;
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(massInScaledKg))
				{
					return "N/A";
				}
				return Mathf.RoundToInt(2.20462f * num).ToString("#,##0") + "lbs";
			}
			if (!((double)num > 1000.0))
			{
				return MetricPrefix((double)num * 1000.0, "g");
			}
			return MetricPrefix((double)num * 0.001, "t");
		}

		public static string GetMemoryString(long size)
		{
			if (size > 1073741824)
			{
				return $"{(double)size / 1073741824.0:n1} GB";
			}
			if (size > 1048576)
			{
				return $"{(double)size / 1048576.0:n1} MB";
			}
			if (size > 1024)
			{
				return $"{(double)size / 1024.0:n1} kB";
			}
			return $"{size:n0} bytes";
		}

		public static string GetMoneyString(long reward)
		{
			string arg = string.Empty;
			if (reward < 0)
			{
				arg = "-";
				reward = -reward;
			}
			if ((double)reward >= 100000000000.0)
			{
				return $"${arg}{(double)reward * 1E-09:n1}B";
			}
			if ((double)reward >= 1000000000.0)
			{
				return $"${arg}{(double)reward * 1E-09:n2}B";
			}
			if ((double)reward >= 10000000.0)
			{
				return $"${arg}{(double)reward * 1E-06:n1}M";
			}
			if ((double)reward >= 1000000.0)
			{
				return $"${arg}{(double)reward * 1E-06:n2}M";
			}
			if ((double)reward >= 10000.0)
			{
				return $"${arg}{(double)reward * 0.001:n0}k";
			}
			if ((double)reward >= 1000.0)
			{
				return $"${arg}{(double)reward * 0.001:n1}k";
			}
			return $"${arg}{reward}";
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
			return MetricPrefix(power, "W");
		}

		public static string GetPressureString(float pressure)
		{
			return MetricPrefix(pressure, "Pa");
		}

		public static string GetPriceString(long price)
		{
			if (!IsFinite(price))
			{
				return "N/A";
			}
			if ((double)price >= 1000000000.0)
			{
				return $"${(double)price * 1E-09:n1}B";
			}
			if ((double)price >= 1000000.0)
			{
				return $"${(double)price * 1E-06:n1}M";
			}
			if ((double)price >= 10000.0)
			{
				return $"${(double)price * 0.001:n0}k";
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

		public static string GetRelativeTimeString(double seconds, int extraDigits = 0)
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
				return $"{num3:n2}hours";
			}
			if (seconds > 90.0)
			{
				double num4 = seconds / 60.0;
				return $"{num4:n1}min";
			}
			return empty + string.Format("{0:n" + extraDigits + "}s", seconds);
		}

		public static string GetStopwatchTimeString(double seconds)
		{
			if (!IsFinite(seconds))
			{
				return "N/A";
			}
			string text = string.Empty;
			if (seconds > 31536000.0)
			{
				long num = (long)(seconds / 31536000.0);
				seconds -= (double)(num * 31536000);
				text += $"{num:n0}d ";
			}
			if (seconds > 86400.0)
			{
				long num2 = (long)(seconds / 86400.0);
				seconds -= (double)(num2 * 86400);
				text += $"{num2:n0}d ";
			}
			if (seconds > 3600.0)
			{
				long num3 = (long)(seconds / 3600.0);
				seconds -= (double)(num3 * 3600);
				text += $"{num3:n0}h ";
			}
			if (seconds > 60.0)
			{
				long num4 = (long)(seconds / 60.0);
				seconds -= (double)(num4 * 60);
				text += $"{num4:n0}m ";
			}
			return text + $"{seconds:n2}s";
		}

		public static string GetTemperatureString(float temperatureInKelvin)
		{
			if (!IsFinite(temperatureInKelvin))
			{
				return "N/A";
			}
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				float num = temperatureInKelvin * 9f / 5f - 459.67f;
				return $"{num:0.0}°F";
			}
			float num2 = temperatureInKelvin - 273.15f;
			return $"{num2:0.0}°C";
		}

		public static string GetTorqueString(float torque)
		{
			return MetricPrefix(torque * 100f, "Nm");
		}

		public static string GetVelocityString(float v, UnitPrecisionMode precision = UnitPrecisionMode.Normal)
		{
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(v))
				{
					return "N/A";
				}
				float num = v * 2.23694f;
				return $"{num:n1}mph";
			}
			return MetricPrefix(v, "m/s", precision == UnitPrecisionMode.High);
		}

		public static string GetVolumeString(float volumeInLiters)
		{
			if (CurrentUnitSystem == UnitSystem.Imperial)
			{
				if (!IsFinite(volumeInLiters))
				{
					return "N/A";
				}
				return ((int)(0.264172f * volumeInLiters)).ToString("n0") + "gal";
			}
			return MetricPrefix(volumeInLiters, "L");
		}

		public static bool IsFinite(double value)
		{
			if (!double.IsInfinity(value))
			{
				return !double.IsNaN(value);
			}
			return false;
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

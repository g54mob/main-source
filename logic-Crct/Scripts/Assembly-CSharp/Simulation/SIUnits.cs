using UnityEngine.UI;

namespace Simulation
{
	public class SIUnits
	{
		public enum FaradUnits
		{
			milli = 0,
			micro = 1,
			nano = 2,
			pico = 3
		}

		public const double pico = 1000000000000.0;

		public const double nano = 1000000000.0;

		public const double micro = 1000000.0;

		public const double milli = 1000.0;

		public const double kilo = 0.001;

		public const double mega = 1E-06;

		public const double giga = 1E-09;

		public const double tera = 1E-12;

		public static double FaradConversion(double v, int u)
		{
			return 0.0;
		}

		public static void FaradReverseConversion(double f, ref InputField input, ref Dropdown drop)
		{
		}

		public static string FaradRating(double f)
		{
			return null;
		}

		public static string OhmRating(double r)
		{
			return null;
		}

		public static double Convert(double v)
		{
			return 0.0;
		}

		private static string Normalize(double v)
		{
			return null;
		}

		public static string Normalize3Decimals(double v, string u)
		{
			return null;
		}

		public static string NormalizeValue(double v, int d)
		{
			return null;
		}

		public static string NormalizeValue3(double v, int d)
		{
			return null;
		}

		public static float NormalizeRounded(float v)
		{
			return 0f;
		}

		public static string NormalizeRound1Place(double v)
		{
			return null;
		}

		public static string NormalizeValue2Places(double v)
		{
			return null;
		}

		public static string Unit(double v, string u)
		{
			return null;
		}

		public static string Normalize(double v, string u)
		{
			return null;
		}

		public static string NormalizeRounded(double v, int d)
		{
			return null;
		}

		public static string NormalizeRounded(double v, int d, string u)
		{
			return null;
		}

		public static string Voltage(double v)
		{
			return null;
		}

		public static string VoltageRounded(double v, int d)
		{
			return null;
		}

		public static string VoltageABS(double v)
		{
			return null;
		}

		public static string Current(double i)
		{
			return null;
		}

		public static string CurrentRounded(double i, int d)
		{
			return null;
		}

		public static string CurrentABS(double i)
		{
			return null;
		}

		public static float SignificantDigits(float N, float n, float minV)
		{
			return 0f;
		}

		public static double SignificantDigits(double N, double n, double minV)
		{
			return 0.0;
		}
	}
}

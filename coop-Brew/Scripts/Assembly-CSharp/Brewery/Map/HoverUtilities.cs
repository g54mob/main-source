using UnityEngine;

namespace Brewery.Map
{
	public static class HoverUtilities
	{
		public static string FormatDistance(Vector3 from, Vector3 to)
		{
			return null;
		}

		public static string FormatDistance(float meters)
		{
			return null;
		}

		public static string GetDirection(Vector3 from, Vector3 to)
		{
			return null;
		}

		public static string FormatDistanceWithDirection(Vector3 from, Vector3 to)
		{
			return null;
		}

		public static string EstimateTravelTime(float meters, float walkSpeed = 5f)
		{
			return null;
		}

		public static string FormatMoney(int amount, bool showSign = false)
		{
			return null;
		}

		public static (string, Color) FormatMoneyWithColor(int amount)
		{
			return default((string, Color));
		}

		public static string FormatTime(float seconds)
		{
			return null;
		}

		public static (string, Color) FormatCountdownWithColor(float hoursRemaining)
		{
			return default((string, Color));
		}

		public static string FormatPercentage(float ratio)
		{
			return null;
		}

		public static string FormatPercentageInt(int percent)
		{
			return null;
		}

		public static Vector3 GetPlayerPosition(ulong clientId)
		{
			return default(Vector3);
		}

		public static Vector3 GetLocalPlayerPosition()
		{
			return default(Vector3);
		}

		public static bool IsPlayerInRange(Vector3 targetPos, ulong clientId, float range)
		{
			return false;
		}

		public static int CalculateProfit(int revenue, int cost)
		{
			return 0;
		}

		public static (string, Color) FormatProfitWithColor(int revenue, int cost)
		{
			return default((string, Color));
		}

		public static string FormatRatio(int current, int max)
		{
			return null;
		}

		public static string GetStockLevelDescription(int current, int max)
		{
			return null;
		}

		public static (string, Color) FormatOccupancyWithColor(int current, int max)
		{
			return default((string, Color));
		}

		public static string FormatWarning(string message)
		{
			return null;
		}

		public static string FormatHint(string keybind, string action)
		{
			return null;
		}

		public static string FormatInfo(string message)
		{
			return null;
		}
	}
}

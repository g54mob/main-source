using System;
using System.Diagnostics;
using UnityEngine;

namespace Brewery.Core
{
	public static class BreweryLogger
	{
		public static bool EnableLogging;

		public static bool IncludeTimestamp;

		public static bool IncludeCallerInfo;

		[Conditional("ENABLE_BREWERY_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void Log(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_BREWERY_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogWarning(string message, UnityEngine.Object context = null)
		{
		}

		public static void LogError(string message, UnityEngine.Object context = null)
		{
		}

		public static void LogException(Exception exception, UnityEngine.Object context = null)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogVerbose(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_NETWORK_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogNetwork(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_NPC_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogNPC(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_SHOP_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogShop(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_STATION_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogStation(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_PLACEMENT_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogPlacement(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_TIMEOFDAY_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogTimeOfDay(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_UI_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogUI(string message, UnityEngine.Object context = null)
		{
		}

		[Conditional("ENABLE_INVENTORY_LOGS")]
		[Conditional("UNITY_EDITOR")]
		public static void LogInventory(string message, UnityEngine.Object context = null)
		{
		}

		private static string FormatMessage(string message)
		{
			return null;
		}

		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		public static void Assert(bool condition, string message, UnityEngine.Object context = null)
		{
		}
	}
}

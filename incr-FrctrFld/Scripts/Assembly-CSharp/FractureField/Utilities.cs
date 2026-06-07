using System;
using System.Collections.Generic;
using UnityEngine;

namespace FractureField
{
	public static class Utilities
	{
		public static readonly DateTimeOffset UnixEpoch;

		private static Dictionary<Transform, Material> originalMaterials;

		public const uint MainSteamAppId = 3946110u;

		public const uint DemoSteamAppId = 4310820u;

		public const uint SteamAppId = 4310820u;

		private const bool ForceBetaInUnityEditor = true;

		private static FractureFieldEnvironment _cachedEnvironment;

		public static DateTime TodayStart => default(DateTime);

		public static DateTime TodayEnd => default(DateTime);

		public static DateTime WeekStart => default(DateTime);

		public static DateTime WeekEnd => default(DateTime);

		public static bool IsDemo => false;

		public static string SteamStoreUrl => null;

		public static bool DisableSteamworks => false;

		public static bool IsUnityEditor => false;

		public static bool IsWindows => false;

		public static bool IsMobileDevice => false;

		public static bool IsMobileDeviceOrEditor => false;

		public static bool IsIOS => false;

		public static bool IsAndroid => false;

		public static bool IsProduction => false;

		public static bool IsBeta => false;

		public static FractureFieldEnvironment FF_Environment
		{
			get
			{
				return default(FractureFieldEnvironment);
			}
			set
			{
			}
		}

		public static void RevertToOriginalMaterial(Dictionary<Transform, Material> originalMaterials)
		{
		}

		public static Dictionary<Transform, Material> GetOriginalMaterials(Transform transform)
		{
			return null;
		}

		private static void GetOriginalMaterialsRecursive(Transform transform)
		{
		}

		public static Dictionary<Transform, Material> ApplyMaterialToChildren(Transform transform, Material material, bool applyOnThisIteration = true)
		{
			return null;
		}

		private static void ApplyMaterialToChildrenRecursive(Transform transform, Material material, bool applyOnThisIteration = true)
		{
		}

		public static string GetVersionNumber()
		{
			return null;
		}

		public static void TimeExecution(Action action, string message = "")
		{
		}

		public static void RebuildLayout(Transform transform)
		{
		}

		public static void RebuildLayout(RectTransform rect)
		{
		}

		public static Func<float, float> CreateLogarithmicMultiplierFunc(float minValue, float maxValue, float startMult, float endMult, bool round = true)
		{
			return null;
		}

		public static void DrawCircle(Vector2 center, float radius, Color color, float duration)
		{
		}

		public static void CopyText(string text)
		{
		}

		public static float DistanceSquared(this Vector2 position, Vector2 other)
		{
			return 0f;
		}
	}
}

using UnityEngine;

namespace SuperTiled2Unity
{
	public static class SuperTileExtensions
	{
		public static bool TryGetProperty(this SuperTile tile, string propName, out CustomProperty property)
		{
			property = null;
			return false;
		}

		public static string GetPropertyValueAsString(this SuperTile tile, string propName)
		{
			return null;
		}

		public static string GetPropertyValueAsString(this SuperTile tile, string propName, string defaultValue)
		{
			return null;
		}

		public static bool GetPropertyValueAsBool(this SuperTile tile, string propName)
		{
			return false;
		}

		public static bool GetPropertyValueAsBool(this SuperTile tile, string propName, bool defaultValue)
		{
			return false;
		}

		public static int GetPropertyValueAsInt(this SuperTile tile, string propName)
		{
			return 0;
		}

		public static int GetPropertyValueAsInt(this SuperTile tile, string propName, int defaultValue)
		{
			return 0;
		}

		public static float GetPropertyValueAsFloat(this SuperTile tile, string propName)
		{
			return 0f;
		}

		public static float GetPropertyValueAsFloat(this SuperTile tile, string propName, float defaultValue)
		{
			return 0f;
		}

		public static Color GetPropertyValueAsColor(this SuperTile tile, string propName)
		{
			return default(Color);
		}

		public static Color GetPropertyValueAsColor(this SuperTile tile, string propName, Color defaultValue)
		{
			return default(Color);
		}

		public static T GetPropertyValueAsEnum<T>(this SuperTile tile, string propName)
		{
			return default(T);
		}

		public static T GetPropertyValueAsEnum<T>(this SuperTile tile, string propName, T defaultValue)
		{
			return default(T);
		}
	}
}

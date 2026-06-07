using UnityEngine;

namespace SuperTiled2Unity
{
	public static class CustomPropertyExtensions
	{
		public static string GetValueAsString(this CustomProperty property)
		{
			return null;
		}

		public static Color GetValueAsColor(this CustomProperty property)
		{
			return default(Color);
		}

		public static int GetValueAsInt(this CustomProperty property)
		{
			return 0;
		}

		public static float GetValueAsFloat(this CustomProperty property)
		{
			return 0f;
		}

		public static bool GetValueAsBool(this CustomProperty property)
		{
			return false;
		}

		public static T GetValueAsEnum<T>(this CustomProperty property)
		{
			return default(T);
		}
	}
}

using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class Vector2Extensions
	{
		public static Vector2 Clamp(this Vector2 v, float minValue, float maxValue)
		{
			return new Vector2(Mathf.Clamp(v.x, minValue, maxValue), Mathf.Clamp(v.y, minValue, maxValue));
		}

		public static Vector2 YX(this Vector2 v)
		{
			return new Vector2(v.y, v.x);
		}
	}
}

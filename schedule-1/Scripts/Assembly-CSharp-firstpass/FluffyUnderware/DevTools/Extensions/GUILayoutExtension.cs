using System;
using UnityEngine;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class GUILayoutExtension
	{
		public static void Area(Action action, Rect screenRectangle, GUIStyle skinBox)
		{
		}

		public static void Area(Action action, Rect screenRectangle)
		{
		}

		public static void Horizontal(Action action, GUIStyle style)
		{
		}

		public static void Horizontal(Action action, params GUILayoutOption[] layoutOptions)
		{
		}

		public static Vector2 ScrollView(Action action, Vector2 scrollPosition, params GUILayoutOption[] layoutOptions)
		{
			return default(Vector2);
		}
	}
}

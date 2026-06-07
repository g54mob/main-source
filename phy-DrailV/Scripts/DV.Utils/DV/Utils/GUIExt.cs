using System;
using UnityEngine;

namespace DV.Utils
{
	public static class GUIExt
	{
		private const float LABEL_WIDTH = 140f;

		public static void FoldoutButton(string label, ref bool value, ref Rect windowRect)
		{
			TextAnchor alignment = GUI.skin.button.alignment;
			try
			{
				GUI.skin.button.alignment = TextAnchor.MiddleLeft;
				if (GUILayout.Button("[" + (value ? "-" : "+") + "] " + label))
				{
					value = !value;
					windowRect.height = 10f;
				}
			}
			finally
			{
				GUI.skin.button.alignment = alignment;
			}
		}

		public static void OutString(string label, string value)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(label);
			GUILayout.Label(value);
			GUILayout.EndHorizontal();
		}

		public static void OutFloat(string label, float value, string unit = "")
		{
			bool wordWrap = GUI.skin.label.wordWrap;
			try
			{
				GUI.skin.label.wordWrap = false;
				GUILayout.BeginHorizontal();
				GUILayout.Label(label, GUILayout.Width(140f));
				GUILayout.Label($"{value:F2} {unit}");
				GUILayout.EndHorizontal();
			}
			finally
			{
				GUI.skin.label.wordWrap = wordWrap;
			}
		}

		public static void OutFloatAndSlider(string label, float value, float sliderMin = 0f, float sliderMax = 1f, string unit = "")
		{
			OutFloat(label, value, unit);
			bool enabled = GUI.enabled;
			try
			{
				GUI.enabled = false;
				GUILayout.HorizontalSlider(value, sliderMin, sliderMax);
			}
			finally
			{
				GUI.enabled = enabled;
			}
		}

		public static float FloatAndSlider(string label, float value, float sliderMin = 0f, float sliderMax = 1f, string unit = "")
		{
			OutFloat(label, value, unit);
			return GUILayout.HorizontalSlider(value, sliderMin, sliderMax);
		}

		public static bool IsPointOnScreen(Vector3 screenPoint)
		{
			if (screenPoint.z >= 0f && 0f <= screenPoint.x && screenPoint.x < (float)Screen.width && 0f <= screenPoint.y)
			{
				return screenPoint.y < (float)Screen.height;
			}
			return false;
		}

		public static bool CustomButton(Action<GUIStyle> drawButton)
		{
			GUIStyle obj = new GUIStyle(GUI.skin.button);
			drawButton(obj);
			if (Event.current.type != EventType.MouseDown || !GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
			{
				return false;
			}
			GUI.changed = true;
			return true;
		}

		public static bool Foldout(bool toggle, string content, Action action)
		{
			return Foldout(toggle, content, null, action);
		}

		public static bool Foldout(bool toggle, string content, GUIStyle foldoutStyle, Action action)
		{
			toggle = GUILayout.Toggle(toggle, "", foldoutStyle ?? GUI.skin.label);
			if (!toggle)
			{
				return false;
			}
			GUILayout.BeginHorizontal();
			GUILayout.Space(20f);
			GUILayout.BeginVertical();
			action();
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			return true;
		}
	}
}

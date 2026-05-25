using UnityEngine;

public static class UL_GUI_Utils
{
	public static void Text(string text)
	{
		GUILayout.Label(text, GUI.skin.box);
	}

	public static float Slider(string text, float value, float min, float max)
	{
		GUILayout.BeginHorizontal(GUI.skin.box);
		GUILayout.Label(string.Format("<b>{0}</b>", text), GUILayout.ExpandWidth(false));
		GUILayout.BeginVertical();
		GUILayout.Space(6f);
		value = GUILayout.HorizontalSlider(value, min, max);
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		return value;
	}
}

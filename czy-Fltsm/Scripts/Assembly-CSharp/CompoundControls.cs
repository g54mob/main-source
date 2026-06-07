using UnityEngine;

public class CompoundControls : MonoBehaviour
{
	public static float LabelTextboxSlider(float sliderValue, float sliderMinValue, float SliderMaxValue, string labelText)
	{
		GUILayout.Label(labelText, GUILayout.ExpandWidth(expand: false));
		GUILayout.BeginHorizontal();
		float num = GUILayout.HorizontalSlider(sliderValue, sliderMinValue, SliderMaxValue);
		string s = GUILayout.TextField(num.ToString("0.00"), GUILayout.ExpandWidth(expand: false));
		if (Mathf.Approximately(num, sliderValue) && float.TryParse(s, out var result))
		{
			num = result;
		}
		GUILayout.EndHorizontal();
		return Mathf.Clamp(num, sliderMinValue, SliderMaxValue);
	}

	public static float LabelSlider(float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
	{
		TextAnchor alignment = GUI.skin.label.alignment;
		int fontSize = GUI.skin.label.fontSize;
		GUILayout.Label(labelText, GUILayout.ExpandHeight(expand: false));
		GUILayout.BeginHorizontal();
		sliderValue = GUILayout.HorizontalSlider(sliderValue, sliderMinValue, sliderMaxValue);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUI.skin.label.fontSize = 8;
		GUILayout.Label(sliderMinValue.ToString());
		GUI.skin.label.alignment = TextAnchor.UpperRight;
		GUILayout.Label(sliderMaxValue.ToString());
		GUILayout.EndHorizontal();
		GUI.skin.label.alignment = alignment;
		GUI.skin.label.fontSize = fontSize;
		return sliderValue;
	}
}

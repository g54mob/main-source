using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSqueezer : MonoBehaviour
{
	public int defaultFontSize;

	public int defaultMaxHeight;

	public int squeezedFontSize;

	public List<Text> texts;

	private static Vector3[] corners = new Vector3[4]
	{
		Vector3.zero,
		Vector3.zero,
		Vector3.zero,
		Vector3.zero
	};

	public void Squeeze()
	{
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		float num = 100000f;
		float num2 = -100000f;
		foreach (Text text in texts)
		{
			if (text.isActiveAndEnabled)
			{
				float edge = GetEdge(text.rectTransform, component, corners, 0);
				num = Mathf.Min(num, edge);
				num2 = Mathf.Max(num2, edge);
				edge = GetEdge(text.rectTransform, component, corners, 1);
				num = Mathf.Min(num, edge);
				num2 = Mathf.Max(num2, edge);
			}
		}
		float num3 = num2 - num;
		int fontSize = ((!(num3 < (float)defaultMaxHeight)) ? squeezedFontSize : defaultFontSize);
		foreach (Text text2 in texts)
		{
			if (text2.isActiveAndEnabled)
			{
				text2.fontSize = fontSize;
			}
		}
	}

	private static float GetEdge(RectTransform srcRt, RectTransform destRt, Vector3[] corners, int cornerIndex)
	{
		srcRt.GetWorldCorners(corners);
		return destRt.worldToLocalMatrix.MultiplyPoint(corners[cornerIndex]).y;
	}
}

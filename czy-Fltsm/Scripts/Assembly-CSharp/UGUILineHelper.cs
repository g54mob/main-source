using UnityEngine;
using UnityEngine.UI;

public static class UGUILineHelper
{
	public static Image DrawLine(Vector2 from, Vector2 to, float lineWidth, Transform parent, Color color)
	{
		Image image = new GameObject("Line").AddComponent<Image>();
		RectTransform obj = image.transform as RectTransform;
		Vector2 to2 = to - from;
		float z = Vector2.SignedAngle(Vector2.up, to2);
		obj.SetParent(parent, worldPositionStays: false);
		obj.pivot = Vector2.zero;
		obj.anchoredPosition = from;
		obj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lineWidth);
		obj.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, to2.magnitude);
		obj.rotation = Quaternion.Euler(0f, 0f, z);
		image.color = color;
		return image;
	}

	public static Image[] DrawPolygon(Vector2[] vertices, float lineWidth, Transform parent)
	{
		int num = vertices.Length;
		Image[] array = new Image[num];
		for (int i = 0; i < vertices.Length; i++)
		{
			array[i] = DrawLine(vertices[i], vertices[(i + 1) % num], lineWidth, parent);
		}
		return array;
	}

	public static Image DrawLine(Vector2 from, Vector2 to, float lineWidth, Transform parent)
	{
		return DrawLine(from, to, lineWidth, parent, Color.white);
	}
}

using UnityEngine;

public class UILine
{
	public Vector2 start;

	public Vector2 end;

	public Color color;

	public float thickness;

	public UILine(Vector2 start, Vector2 end, Color color, float thickness)
	{
		this.start = start;
		this.end = end;
		this.color = color;
		this.thickness = thickness;
	}
}

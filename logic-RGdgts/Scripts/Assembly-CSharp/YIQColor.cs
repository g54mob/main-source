using UnityEngine;

public struct YIQColor
{
	public float y;

	public float i;

	public float q;

	public float a;

	public Color color;

	public YIQColor(float y, float i, float q, float a, Color color)
	{
		this.y = 0f;
		this.i = 0f;
		this.q = 0f;
		this.a = 0f;
		this.color = default(Color);
	}

	public YIQColor(Color color)
	{
		y = 0f;
		i = 0f;
		q = 0f;
		a = 0f;
		this.color = default(Color);
	}

	public static bool operator ==(YIQColor c1, YIQColor c2)
	{
		return false;
	}

	public static bool operator !=(YIQColor c1, YIQColor c2)
	{
		return false;
	}

	public override string ToString()
	{
		return null;
	}
}

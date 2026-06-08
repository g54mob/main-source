using UnityEngine;

public class Coordinate2D
{
	public int x;

	public int y;

	public Coordinate2D()
	{
	}

	public Coordinate2D(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public Coordinate2D(Vector2 vec)
	{
		x = (int)vec.x;
		y = (int)vec.y;
	}

	public void Clear()
	{
		x = 0;
		y = 0;
	}

	public override string ToString()
	{
		return string.Format("{0}:{1}", x, y);
	}

	public static Coordinate2D operator +(Coordinate2D c1, Coordinate2D c2)
	{
		return new Coordinate2D(c1.x + c2.x, c1.y + c2.y);
	}
}

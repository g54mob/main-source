using System;
using Unity.Mathematics;

[Serializable]
public class ArcadeBodyBounds : RBush.IRectangular
{
	public float x;

	public float y;

	public float width;

	public float height;

	public float left
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float top
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float right => 0f;

	public float bottom => 0f;

	public float minX => 0f;

	public float minY => 0f;

	public float maxX => 0f;

	public float maxY => 0f;

	public ArcadeBodyBounds()
	{
	}

	public ArcadeBodyBounds(float x, float y, float width, float height)
	{
	}

	public static ArcadeRect FromBounds(float x, float y, float right, float bottom)
	{
		return default(ArcadeRect);
	}

	public void setTo(float x, float y, float width, float height)
	{
	}

	public bool contains(float2 position)
	{
		return false;
	}

	public float2 randomPoint()
	{
		return default(float2);
	}
}

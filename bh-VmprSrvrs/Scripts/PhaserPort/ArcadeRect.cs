using System;
using Unity.Mathematics;

[Serializable]
public struct ArcadeRect
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

	public ArcadeRect(float2 pos, float2 size)
	{
		x = 0f;
		y = 0f;
		width = 0f;
		height = 0f;
	}

	public ArcadeRect(float x, float y, float2 size)
	{
		this.x = 0f;
		this.y = 0f;
		width = 0f;
		height = 0f;
	}

	public ArcadeRect(float x, float y, float width, float height)
	{
		this.x = 0f;
		this.y = 0f;
		this.width = 0f;
		this.height = 0f;
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
}

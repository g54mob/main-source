using System;
using UnityEngine;

[Serializable]
public class Separator
{
	public enum Direction
	{
		Horizontal = 0,
		Vertical = 1
	}

	public int separatorSymbol;

	public Color color = Color.white;

	[SerializeField]
	private int positionX;

	[SerializeField]
	private int positionY;

	public int length;

	public Direction direction;

	public int PositionX
	{
		get
		{
			return positionX;
		}
		set
		{
			positionX = value;
		}
	}

	public int PositionY
	{
		get
		{
			return positionY;
		}
		set
		{
			positionY = value;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (separatorSymbol < 0)
		{
			return;
		}
		offsetX += PositionX;
		offsetY += PositionY;
		if (direction == Direction.Horizontal)
		{
			for (int i = 0; i < length; i++)
			{
				r.SetCell(i + offsetX, offsetY, separatorSymbol, color);
			}
		}
		else
		{
			for (int j = 0; j < length; j++)
			{
				r.SetCell(offsetX, j + offsetY, separatorSymbol, color);
			}
		}
	}
}

using System;
using UnityEngine;

public readonly struct Coord : IEquatable<Coord>
{
	private const int dirNone = -1;

	private const int dirN = 0;

	private const int dirE = 1;

	private const int dirS = 2;

	private const int dirW = 3;

	private const int dirNE = 4;

	private const int dirSE = 5;

	private const int dirSW = 6;

	private const int dirNW = 7;

	private const int dirUp = 8;

	private const int dirDown = 9;

	private const int dirSelf = 10;

	public int x { get; }

	public int y { get; }

	public static Coord Zero => new Coord(0, 0);

	public Vector2 AsVector2 => new Vector2(x, y);

	public Coord(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override int GetHashCode()
	{
		return (17 * 31 + x) * 31 + y;
	}

	public override bool Equals(object other)
	{
		if (!(other is Coord))
		{
			return false;
		}
		return Equals((Coord)other);
	}

	public bool Equals(Coord other)
	{
		if (x == other.x)
		{
			return y == other.y;
		}
		return false;
	}

	public Coord Offset(int xOffset, int yOffset)
	{
		return new Coord(x + xOffset, y + yOffset);
	}

	public Coord Offset(Coord offset)
	{
		return new Coord(x + offset.x, y + offset.y);
	}

	public Coord Offset(int dirInt)
	{
		Coord offset = OffsetForBlockDir(dirInt);
		return Offset(offset);
	}

	public int DirTo(Coord other)
	{
		if (other.y == y)
		{
			if (other.x == x + 1)
			{
				return 1;
			}
			if (other.x == x - 1)
			{
				return 3;
			}
		}
		else if (other.x == x)
		{
			if (other.y == y + 1)
			{
				return 0;
			}
			if (other.y == y - 1)
			{
				return 2;
			}
		}
		return -1;
	}

	public int FuzzyDirTo(Coord other)
	{
		if (other.y == y)
		{
			if (other.x > x)
			{
				return 1;
			}
			if (other.x < x)
			{
				return 3;
			}
		}
		else if (other.x == x)
		{
			if (other.y > y)
			{
				return 0;
			}
			if (other.y < y)
			{
				return 2;
			}
		}
		return -1;
	}

	public int Magnitude()
	{
		return Mathf.Abs(x) + Mathf.Abs(y);
	}

	public int MaxRadiusFrom(Coord other)
	{
		return Mathf.Max(Mathf.Abs(x - other.x), Mathf.Abs(y - other.y));
	}

	public int GridDistanceFrom(Coord other)
	{
		return Mathf.Abs(x - other.x) + Mathf.Abs(y - other.y);
	}

	public static Coord OffsetForBlockDir(int dirInt)
	{
		return dirInt switch
		{
			0 => new Coord(0, 1), 
			4 => new Coord(1, 1), 
			1 => new Coord(1, 0), 
			5 => new Coord(1, -1), 
			2 => new Coord(0, -1), 
			6 => new Coord(-1, -1), 
			3 => new Coord(-1, 0), 
			7 => new Coord(-1, 1), 
			10 => new Coord(0, 0), 
			_ => new Coord(0, 0), 
		};
	}

	public bool IsContainedWithinInclusiveBounds(Coord negativeCorner, Coord positiveCorner)
	{
		if (x >= negativeCorner.x && x <= positiveCorner.x && y >= negativeCorner.y)
		{
			return y <= positiveCorner.y;
		}
		return false;
	}

	public Vector3 WorldVectorWithHeight(float h)
	{
		return new Vector3(x, h, y);
	}

	public string DisplayValue()
	{
		return $"{x} / {y}";
	}

	public override string ToString()
	{
		return $"[{x},{y}]";
	}

	public Coord Left()
	{
		return Offset(3);
	}

	public Coord Right()
	{
		return Offset(1);
	}

	public Coord Up()
	{
		return Offset(0);
	}

	public Coord Down()
	{
		return Offset(2);
	}

	public Coord Rotated(int numClockwiseRotations)
	{
		switch (numClockwiseRotations)
		{
		case 1:
			return new Coord(y, x * -1);
		case 2:
			return new Coord(x * -1, y * -1);
		case -1:
		case 3:
			return new Coord(y * -1, x);
		default:
			Debug.LogError("Tried to rotate Coord with invalid numClockwise: " + numClockwiseRotations);
			break;
		case 0:
			break;
		}
		return this;
	}
}

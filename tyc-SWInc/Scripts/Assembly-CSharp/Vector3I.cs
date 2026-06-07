using System;
using UnityEngine;

[Serializable]
public struct Vector3I
{
	public int x;

	public int y;

	public int z;

	public Vector3I(int xx, int yy, int zz)
	{
		x = xx;
		y = yy;
		z = zz;
	}

	public Vector3I(float xx, float yy, float zz)
	{
		x = (int)xx;
		y = (int)yy;
		z = (int)zz;
	}

	public Vector3I(Vector3 v)
	{
		x = Mathf.FloorToInt(v.x);
		y = Mathf.RoundToInt(v.y);
		z = Mathf.FloorToInt(v.z);
	}

	public Vector3 ToVector3()
	{
		return new Vector3(x, y, z);
	}

	public Vector3 ToSwincVector3()
	{
		return new Vector3(x, y * 2, z);
	}

	public Vector2 ToVector2()
	{
		return new Vector2(x, z);
	}

	public static Vector3I operator +(Vector3I a, Vector3I b)
	{
		return new Vector3I(a.x + b.x, a.y + b.y, a.z + b.z);
	}

	public static Vector3I operator -(Vector3I a, Vector3I b)
	{
		return new Vector3I(a.x - b.x, a.y - b.y, a.z - b.z);
	}

	public override bool Equals(object obj)
	{
		if (obj is Vector3I)
		{
			Vector3I vector3I = (Vector3I)obj;
			if (vector3I.x == x && vector3I.y == y)
			{
				return vector3I.z == z;
			}
			return false;
		}
		if (obj is Vector3)
		{
			Vector3 vector = (Vector3)obj;
			if (vector.x == (float)x && vector.y == (float)y)
			{
				return vector.z == (float)z;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}

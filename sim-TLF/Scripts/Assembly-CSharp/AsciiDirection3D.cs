using UnityEngine;

public static class AsciiDirection3D
{
	public enum Direction
	{
		Left = 0,
		Right = 1,
		Up = 2,
		Down = 3,
		Forward = 4,
		Backward = 5,
		None = 6
	}

	public static Direction GetDirection(Vector3 origin, Transform reference, Vector3 target)
	{
		Vector3 rhs = target - origin;
		if (rhs.sqrMagnitude < 0.0001f)
		{
			return Direction.None;
		}
		rhs.Normalize();
		float num = Vector3.Dot(reference.right, rhs);
		float num2 = Vector3.Dot(reference.up, rhs);
		float num3 = Vector3.Dot(reference.forward, rhs);
		float num4 = Mathf.Abs(num);
		float num5 = Mathf.Abs(num2);
		float num6 = Mathf.Abs(num3);
		if (num4 >= num5 && num4 >= num6)
		{
			if (!(num > 0f))
			{
				return Direction.Left;
			}
			return Direction.Right;
		}
		if (num5 >= num4 && num5 >= num6)
		{
			if (!(num2 > 0f))
			{
				return Direction.Down;
			}
			return Direction.Up;
		}
		if (!(num3 > 0f))
		{
			return Direction.Backward;
		}
		return Direction.Forward;
	}

	public static char GetAsciiArrow(Direction dir)
	{
		return dir switch
		{
			Direction.Left => '<', 
			Direction.Right => '>', 
			Direction.Up => '^', 
			Direction.Down => 'v', 
			Direction.Forward => '^', 
			Direction.Backward => 'v', 
			_ => ' ', 
		};
	}

	public static char GetArrow(Vector3 origin, Transform reference, Vector3 target)
	{
		return GetAsciiArrow(GetDirection(origin, reference, target));
	}
}

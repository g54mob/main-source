using UnityEngine;

public static class Vector3Extensions
{
	public static void ScaleUniform(this Vector3 vector3, float scale)
	{
		vector3.Scale(new Vector3(scale, scale, scale));
	}

	public static bool IsCardinal2D(this Vector3 vector3, Vector3 other)
	{
		Vector3 vector4 = other - vector3;
		if (vector4.x < 0f)
		{
			vector4.x = 0f - vector4.x;
		}
		if (vector4.y < 0f)
		{
			vector4.y = 0f - vector4.y;
		}
		if (!(vector4.x < float.Epsilon))
		{
			return vector4.y < float.Epsilon;
		}
		return true;
	}

	public static Vector3 RotateCW2D(this Vector3 vector)
	{
		return new Vector3(vector.y, 0f - vector.x, 0f);
	}

	public static Vector3 RotateCCW2D(this Vector3 vector)
	{
		return new Vector3(0f - vector.y, vector.x, 0f);
	}
}

using System.Numerics;
using UnityEngine;

public class VectorExtensions : MonoBehaviour
{
	public unsafe static UnityEngine.Vector3 XZVector(UnityEngine.Vector3 v)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_002d: Expected native int or pointer, but got O
		UnityEngine.Vector3 vector = default(UnityEngine.Vector3);
		((UnityEngine.Vector3*)(nint)vector)->x = v.x;
		((UnityEngine.Vector3*)(nint)vector)->z = v.z;
		((UnityEngine.Vector3*)(nint)vector)->y = 0f;
		return vector;
	}

	public static Vector2 XZVector2(UnityEngine.Vector3 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe static System.Numerics.Vector3 UnityToNet(UnityEngine.Vector3 vec)
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_003b: Expected native int or pointer, but got O
		System.Numerics.Vector3 vector = default(System.Numerics.Vector3);
		((System.Numerics.Vector3*)(nint)vector)->X = 0f;
		((System.Numerics.Vector3*)(nint)vector)->Z = 0f;
		*(System.Numerics.Vector3*)(nint)vector = new System.Numerics.Vector3(vec.x, vec.y, vec.z);
		return vector;
	}

	public unsafe static UnityEngine.Vector3 NetToUnity(System.Numerics.Vector3 vec)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		UnityEngine.Vector3 vector = default(UnityEngine.Vector3);
		((UnityEngine.Vector3*)(nint)vector)->x = vec.X;
		((UnityEngine.Vector3*)(nint)vector)->y = vec.Y;
		((UnityEngine.Vector3*)(nint)vector)->z = vec.Z;
		return vector;
	}

	public unsafe static UnityEngine.Vector3 ClampVector(UnityEngine.Vector3 vec, float min, float max)
	{
		//IL_015c: Expected native int or pointer, but got O
		//IL_0169: Expected native int or pointer, but got O
		//IL_0176: Expected native int or pointer, but got O
		//IL_00c7: Expected native int or pointer, but got O
		//IL_00d4: Expected native int or pointer, but got O
		//IL_00e1: Expected native int or pointer, but got O
		float num = vec.x;
		if (!(min > vec.x))
		{
			if (num > max)
			{
				num = max;
			}
		}
		else
		{
			num = min;
		}
		float num2 = vec.y;
		if (!(min > vec.y))
		{
			if (num2 > max)
			{
				num2 = max;
			}
		}
		else
		{
			num2 = min;
		}
		float num3 = vec.z;
		UnityEngine.Vector3 vector = default(UnityEngine.Vector3);
		if (!(min > vec.z))
		{
			if (num3 > max)
			{
				((UnityEngine.Vector3*)(nint)vector)->x = num;
				((UnityEngine.Vector3*)(nint)vector)->y = num2;
				((UnityEngine.Vector3*)(nint)vector)->z = max;
				return vector;
			}
		}
		else
		{
			num3 = min;
		}
		((UnityEngine.Vector3*)(nint)vector)->x = num;
		((UnityEngine.Vector3*)(nint)vector)->y = num2;
		((UnityEngine.Vector3*)(nint)vector)->z = num3;
		return vector;
	}
}

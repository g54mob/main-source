using System;
using UnityEngine;

namespace ProGrids;

public static class PGExtensions
{
	public static bool Contains(Transform[] t_arr, Transform t)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00af: Expected I4, but got O
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < t_arr.Length)
			{
				if ((nint)obj >= t_arr.Length)
				{
					break;
				}
				if (t_arr[obj] != t)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				return true;
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public static float Sum(Vector3 v)
	{
		float num = v.y + v.x;
		return num + v.z;
	}

	public unsafe static bool InFrustum(Camera cam, Vector3 point)
	{
		//IL_00ee: Expected I4, but got O
		//IL_002a: Expected O, but got Ref
		//IL_003c: Invalid comparison between F4 and I4
		//IL_0080: Invalid comparison between F4 and I4
		//IL_00c4: Invalid comparison between F4 and I4
		if ((object)cam != null)
		{
			object obj = default(object);
			Vector3 vector = cam.WorldToViewportPoint((Vector3)(&obj));
			if (!(vector.x < 0f) && !(1f < vector.x) && !(vector.y < 0f) && !(1f < vector.y))
			{
				bool flag = vector.z < 0f;
				return !flag;
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}

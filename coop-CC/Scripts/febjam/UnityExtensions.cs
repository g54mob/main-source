using System.Runtime.CompilerServices;
using UnityEngine;

public static class UnityExtensions
{
	public static void SetParentAndReset(this Transform t, Transform parent)
	{
		t.SetParent(parent);
		t.localPosition = Vector3.zero;
		t.localScale = Vector3.one;
		t.localRotation = Quaternion.identity;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 XYZW(this Vector3 pos)
	{
		return new Vector4(pos.x, pos.y, pos.z, 1f);
	}

	public static string ToStringFull(this Vector3 v)
	{
		return $"({v.x}, {v.y}, {v.z})";
	}
}

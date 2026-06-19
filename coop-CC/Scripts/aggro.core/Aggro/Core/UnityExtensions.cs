using System.Runtime.CompilerServices;
using UnityEngine;

namespace Aggro.Core
{
	public static class UnityExtensions
	{
		public static void SetParentAndReset(this Transform t, Transform parent, bool ignoreScale = false)
		{
			t.SetParent(parent);
			t.localPosition = Vector3.zero;
			if (!ignoreScale)
			{
				t.localScale = Vector3.one;
			}
			t.localRotation = Quaternion.identity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 XYZW(this Vector3 pos)
		{
			return new Vector4(pos.x, pos.y, pos.z, 1f);
		}

		public static void ResetAll(this Transform t)
		{
			t.localPosition = Vector3.zero;
			t.localScale = Vector3.one;
			t.localRotation = Quaternion.identity;
		}
	}
}

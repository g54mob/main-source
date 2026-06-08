using System.Runtime.InteropServices;
using UnityEngine;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Vector3Interpolator : IValueInterpolator<Vector3>
	{
		public Vector3 Lerp(Vector3 t1, Vector3 t2, float f)
		{
			return Vector3.Lerp(t1, t2, f);
		}

		public float Distance(Vector3 t1, Vector3 t2)
		{
			return Vector3.Distance(t1, t2);
		}
	}
}

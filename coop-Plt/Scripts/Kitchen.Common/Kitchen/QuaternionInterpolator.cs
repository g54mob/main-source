using System.Runtime.InteropServices;
using UnityEngine;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct QuaternionInterpolator : IValueInterpolator<Quaternion>
	{
		public Quaternion Lerp(Quaternion t1, Quaternion t2, float f)
		{
			return Quaternion.Slerp(t1, t2, f);
		}

		public float Distance(Quaternion t1, Quaternion t2)
		{
			return Quaternion.Angle(t2, t1);
		}
	}
}

using System.Runtime.InteropServices;
using UnityEngine;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct FloatInterpolator : IValueInterpolator<float>
	{
		public float Lerp(float t1, float t2, float f)
		{
			return Mathf.Lerp(t1, t2, f);
		}

		public float Distance(float t1, float t2)
		{
			return Mathf.Abs(t2 - t1);
		}
	}
}

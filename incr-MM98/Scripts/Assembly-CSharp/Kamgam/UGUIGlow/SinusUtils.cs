using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public static class SinusUtils
	{
		public static float ApplySinusMode(float value, SinusMode mode)
		{
			return mode switch
			{
				SinusMode.Absolute => Mathf.Abs(value), 
				SinusMode.ClampPositive => Mathf.Max(0f, value), 
				SinusMode.ClampNegative => Mathf.Min(0f, value), 
				_ => value, 
			};
		}
	}
}

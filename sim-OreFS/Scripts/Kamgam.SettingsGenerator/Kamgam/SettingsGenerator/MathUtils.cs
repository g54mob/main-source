using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public static class MathUtils
	{
		public static float MapWithAnchor(float inValue, float inMin, float inAnchor, float inMax, float outMin, float outAnchor, float outMax, bool clamp = true)
		{
			if (inMin > inAnchor || inMin >= inMax)
			{
				throw new Exception($"inMin ({inMin}) has to be below inAnchor ({inAnchor}) and inMax ({inMax})");
			}
			if (outMin > outAnchor || outMin >= outMax)
			{
				throw new Exception($"outMin ({outMin}) has to be below outAnchor ({outAnchor}) and outMax ({outMax})");
			}
			if (Mathf.Approximately(inValue, inAnchor))
			{
				return outAnchor;
			}
			if (Mathf.Approximately(inValue, inMin) || (clamp && inValue < inMin))
			{
				return outMin;
			}
			if (Mathf.Approximately(inValue, inMax) || (clamp && inValue > inMax))
			{
				return outMax;
			}
			float num = Mathf.Abs(inAnchor - inValue);
			float num3;
			float num4;
			if (inValue < inAnchor)
			{
				float num2 = inAnchor - inMin;
				num3 = num / num2;
				num4 = outMin - outAnchor;
			}
			else
			{
				float num2 = inMax - inAnchor;
				num3 = num / num2;
				num4 = outMax - outAnchor;
			}
			return outAnchor + num4 * num3;
		}
	}
}

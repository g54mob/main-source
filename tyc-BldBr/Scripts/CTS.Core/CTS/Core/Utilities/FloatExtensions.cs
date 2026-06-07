namespace CTS.Core.Utilities
{
	public static class FloatExtensions
	{
		public static float Remap(this float val, float minIn, float maxIn, float minOut, float maxOut)
		{
			return minOut + (val - minIn) * (maxOut - minOut) / (maxIn - minIn);
		}

		public static float GetSignedAngle(this float angle)
		{
			if (angle > 180f)
			{
				while (angle > 180f)
				{
					angle -= 360f;
				}
			}
			else if (angle < -180f)
			{
				while (angle < -180f)
				{
					angle += 360f;
				}
			}
			return angle;
		}

		public static float InverseLerpUnclamped(this float value, float min, float max)
		{
			return (value - min) / (max - min);
		}
	}
}

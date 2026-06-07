namespace DV
{
	public class LowPassFilter
	{
		private bool init;

		private float intermediateValueBuf;

		public float factor = 0.5f;

		public LowPassFilter(float factor)
		{
			this.factor = factor;
			init = true;
		}

		public float Get(float targetValue)
		{
			if (init)
			{
				intermediateValueBuf = targetValue;
			}
			return intermediateValueBuf = targetValue * factor + intermediateValueBuf * (1f - factor);
		}

		public float Get(float targetValue, float factor)
		{
			this.factor = factor;
			return Get(targetValue);
		}

		public static float Get(float targetValue, ref float intermediateValueBuf, float factor, bool init)
		{
			if (init)
			{
				intermediateValueBuf = targetValue;
			}
			return intermediateValueBuf = targetValue * factor + intermediateValueBuf * (1f - factor);
		}
	}
}

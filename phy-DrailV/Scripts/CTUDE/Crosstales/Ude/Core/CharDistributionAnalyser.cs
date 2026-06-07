namespace Crosstales.Ude.Core
{
	public abstract class CharDistributionAnalyser
	{
		protected const float SURE_YES = 0.99f;

		protected const float SURE_NO = 0.01f;

		protected const int MINIMUM_DATA_THRESHOLD = 4;

		protected const int ENOUGH_DATA_THRESHOLD = 1024;

		protected bool done;

		protected int freqChars;

		protected int totalChars;

		protected int[] charToFreqOrder;

		protected float typicalDistributionRatio;

		public CharDistributionAnalyser()
		{
			Reset();
		}

		public abstract int GetOrder(byte[] buf, int offset);

		public void HandleOneChar(byte[] buf, int offset, int charLen)
		{
			int num = ((charLen == 2) ? GetOrder(buf, offset) : (-1));
			if (num >= 0)
			{
				totalChars++;
				if (num < charToFreqOrder.Length && 512 > charToFreqOrder[num])
				{
					freqChars++;
				}
			}
		}

		public virtual void Reset()
		{
			done = false;
			totalChars = 0;
			freqChars = 0;
		}

		public virtual float GetConfidence()
		{
			if (totalChars <= 0 || freqChars <= 4)
			{
				return 0.01f;
			}
			if (totalChars != freqChars)
			{
				float num = (float)freqChars / ((float)(totalChars - freqChars) * typicalDistributionRatio);
				if (num < 0.99f)
				{
					return num;
				}
			}
			return 0.99f;
		}

		public bool GotEnoughData()
		{
			return totalChars > 1024;
		}
	}
}

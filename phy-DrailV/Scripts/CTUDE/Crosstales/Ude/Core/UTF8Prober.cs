namespace Crosstales.Ude.Core
{
	public class UTF8Prober : CharsetProber
	{
		private static float ONE_CHAR_PROB = 0.5f;

		private CodingStateMachine codingSM;

		private int numOfMBChar;

		public UTF8Prober()
		{
			numOfMBChar = 0;
			codingSM = new CodingStateMachine(new UTF8SMModel());
			Reset();
		}

		public override string GetCharsetName()
		{
			return "UTF-8";
		}

		public override void Reset()
		{
			codingSM.Reset();
			numOfMBChar = 0;
			state = ProbingState.Detecting;
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			int num = 0;
			int num2 = offset + len;
			for (int i = offset; i < num2; i++)
			{
				switch (codingSM.NextState(buf[i]))
				{
				case 1:
					state = ProbingState.NotMe;
					break;
				case 2:
					state = ProbingState.FoundIt;
					break;
				case 0:
					if (codingSM.CurrentCharLen >= 2)
					{
						numOfMBChar++;
					}
					continue;
				default:
					continue;
				}
				break;
			}
			if (state == ProbingState.Detecting && GetConfidence() > 0.95f)
			{
				state = ProbingState.FoundIt;
			}
			return state;
		}

		public override float GetConfidence()
		{
			float num = 0.99f;
			float num2 = 0f;
			if (numOfMBChar < 6)
			{
				for (int i = 0; i < numOfMBChar; i++)
				{
					num *= ONE_CHAR_PROB;
				}
				return 1f - num;
			}
			return 0.99f;
		}
	}
}

namespace Crosstales.Ude.Core
{
	public class Big5Prober : CharsetProber
	{
		private CodingStateMachine codingSM;

		private BIG5DistributionAnalyser distributionAnalyser;

		private byte[] lastChar = new byte[2];

		public Big5Prober()
		{
			codingSM = new CodingStateMachine(new BIG5SMModel());
			distributionAnalyser = new BIG5DistributionAnalyser();
			Reset();
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
				{
					int currentCharLen = codingSM.CurrentCharLen;
					if (i == offset)
					{
						lastChar[1] = buf[offset];
						distributionAnalyser.HandleOneChar(lastChar, 0, currentCharLen);
					}
					else
					{
						distributionAnalyser.HandleOneChar(buf, i - 1, currentCharLen);
					}
					continue;
				}
				default:
					continue;
				}
				break;
			}
			lastChar[0] = buf[num2 - 1];
			if (state == ProbingState.Detecting && distributionAnalyser.GotEnoughData() && GetConfidence() > 0.95f)
			{
				state = ProbingState.FoundIt;
			}
			return state;
		}

		public override void Reset()
		{
			codingSM.Reset();
			state = ProbingState.Detecting;
			distributionAnalyser.Reset();
		}

		public override string GetCharsetName()
		{
			return "Big-5";
		}

		public override float GetConfidence()
		{
			return distributionAnalyser.GetConfidence();
		}
	}
}

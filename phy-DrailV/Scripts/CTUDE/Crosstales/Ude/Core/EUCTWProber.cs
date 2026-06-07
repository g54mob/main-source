namespace Crosstales.Ude.Core
{
	public class EUCTWProber : CharsetProber
	{
		private CodingStateMachine codingSM;

		private EUCTWDistributionAnalyser distributionAnalyser;

		private byte[] lastChar = new byte[2];

		public EUCTWProber()
		{
			codingSM = new CodingStateMachine(new EUCTWSMModel());
			distributionAnalyser = new EUCTWDistributionAnalyser();
			Reset();
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			int num = offset + len;
			for (int i = 0; i < num; i++)
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
			lastChar[0] = buf[num - 1];
			if (state == ProbingState.Detecting && distributionAnalyser.GotEnoughData() && GetConfidence() > 0.95f)
			{
				state = ProbingState.FoundIt;
			}
			return state;
		}

		public override string GetCharsetName()
		{
			return "EUC-TW";
		}

		public override void Reset()
		{
			codingSM.Reset();
			state = ProbingState.Detecting;
			distributionAnalyser.Reset();
		}

		public override float GetConfidence()
		{
			return distributionAnalyser.GetConfidence();
		}
	}
}

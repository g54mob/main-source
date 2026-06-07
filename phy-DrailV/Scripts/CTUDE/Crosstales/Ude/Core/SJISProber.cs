namespace Crosstales.Ude.Core
{
	public class SJISProber : CharsetProber
	{
		private CodingStateMachine codingSM;

		private SJISContextAnalyser contextAnalyser;

		private SJISDistributionAnalyser distributionAnalyser;

		private byte[] lastChar = new byte[2];

		public SJISProber()
		{
			codingSM = new CodingStateMachine(new SJISSMModel());
			distributionAnalyser = new SJISDistributionAnalyser();
			contextAnalyser = new SJISContextAnalyser();
			Reset();
		}

		public override string GetCharsetName()
		{
			return "Shift-JIS";
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			int num = offset + len;
			for (int i = offset; i < num; i++)
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
						contextAnalyser.HandleOneChar(lastChar, 2 - currentCharLen, currentCharLen);
						distributionAnalyser.HandleOneChar(lastChar, 0, currentCharLen);
					}
					else
					{
						contextAnalyser.HandleOneChar(buf, i + 1 - currentCharLen, currentCharLen);
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
			if (state == ProbingState.Detecting && contextAnalyser.GotEnoughData() && GetConfidence() > 0.95f)
			{
				state = ProbingState.FoundIt;
			}
			return state;
		}

		public override void Reset()
		{
			codingSM.Reset();
			state = ProbingState.Detecting;
			contextAnalyser.Reset();
			distributionAnalyser.Reset();
		}

		public override float GetConfidence()
		{
			float confidence = contextAnalyser.GetConfidence();
			float confidence2 = distributionAnalyser.GetConfidence();
			if (!(confidence > confidence2))
			{
				return confidence2;
			}
			return confidence;
		}
	}
}

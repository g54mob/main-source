namespace Crosstales.Ude.Core
{
	public class GB18030Prober : CharsetProber
	{
		private CodingStateMachine codingSM;

		private GB18030DistributionAnalyser analyser;

		private byte[] lastChar;

		public GB18030Prober()
		{
			lastChar = new byte[2];
			codingSM = new CodingStateMachine(new GB18030SMModel());
			analyser = new GB18030DistributionAnalyser();
			Reset();
		}

		public override string GetCharsetName()
		{
			return "gb18030";
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
						analyser.HandleOneChar(lastChar, 0, currentCharLen);
					}
					else
					{
						analyser.HandleOneChar(buf, i - 1, currentCharLen);
					}
					continue;
				}
				default:
					continue;
				}
				break;
			}
			lastChar[0] = buf[num2 - 1];
			if (state == ProbingState.Detecting && analyser.GotEnoughData() && GetConfidence() > 0.95f)
			{
				state = ProbingState.FoundIt;
			}
			return state;
		}

		public override float GetConfidence()
		{
			return analyser.GetConfidence();
		}

		public override void Reset()
		{
			codingSM.Reset();
			state = ProbingState.Detecting;
			analyser.Reset();
		}
	}
}

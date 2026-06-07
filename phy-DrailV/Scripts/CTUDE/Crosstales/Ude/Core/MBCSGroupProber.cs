using System;

namespace Crosstales.Ude.Core
{
	public class MBCSGroupProber : CharsetProber
	{
		private const int PROBERS_NUM = 7;

		private static readonly string[] ProberName = new string[7] { "UTF8", "SJIS", "EUCJP", "GB18030", "EUCKR", "Big5", "EUCTW" };

		private CharsetProber[] probers = new CharsetProber[7];

		private bool[] isActive = new bool[7];

		private int bestGuess;

		private int activeNum;

		public MBCSGroupProber()
		{
			probers[0] = new UTF8Prober();
			probers[1] = new SJISProber();
			probers[2] = new EUCJPProber();
			probers[3] = new GB18030Prober();
			probers[4] = new EUCKRProber();
			probers[5] = new Big5Prober();
			probers[6] = new EUCTWProber();
			Reset();
		}

		public override string GetCharsetName()
		{
			if (bestGuess == -1)
			{
				GetConfidence();
				if (bestGuess == -1)
				{
					bestGuess = 0;
				}
			}
			return probers[bestGuess].GetCharsetName();
		}

		public override void Reset()
		{
			activeNum = 0;
			for (int i = 0; i < probers.Length; i++)
			{
				if (probers[i] != null)
				{
					probers[i].Reset();
					isActive[i] = true;
					activeNum++;
				}
				else
				{
					isActive[i] = false;
				}
			}
			bestGuess = -1;
			state = ProbingState.Detecting;
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			byte[] array = new byte[len];
			int len2 = 0;
			bool flag = true;
			int num = offset + len;
			for (int i = offset; i < num; i++)
			{
				if ((buf[i] & 0x80) != 0)
				{
					array[len2++] = buf[i];
					flag = true;
				}
				else if (flag)
				{
					array[len2++] = buf[i];
					flag = false;
				}
			}
			ProbingState probingState = ProbingState.NotMe;
			for (int j = 0; j < probers.Length; j++)
			{
				if (!isActive[j])
				{
					continue;
				}
				switch (probers[j].HandleData(array, 0, len2))
				{
				case ProbingState.FoundIt:
					bestGuess = j;
					state = ProbingState.FoundIt;
					break;
				case ProbingState.NotMe:
					isActive[j] = false;
					activeNum--;
					if (activeNum > 0)
					{
						continue;
					}
					state = ProbingState.NotMe;
					break;
				default:
					continue;
				}
				break;
			}
			return state;
		}

		public override float GetConfidence()
		{
			float num = 0f;
			float num2 = 0f;
			if (state == ProbingState.FoundIt)
			{
				return 0.99f;
			}
			if (state == ProbingState.NotMe)
			{
				return 0.01f;
			}
			for (int i = 0; i < 7; i++)
			{
				if (isActive[i])
				{
					num2 = probers[i].GetConfidence();
					if (num < num2)
					{
						num = num2;
						bestGuess = i;
					}
				}
			}
			return num;
		}

		public override void DumpStatus()
		{
			GetConfidence();
			for (int i = 0; i < 7; i++)
			{
				if (!isActive[i])
				{
					Console.WriteLine("  MBCS inactive: {0} (confidence is too low).", ProberName[i]);
					continue;
				}
				float confidence = probers[i].GetConfidence();
				Console.WriteLine("  MBCS {0}: [{1}]", confidence, ProberName[i]);
			}
		}
	}
}

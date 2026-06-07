using System;

namespace Crosstales.Ude.Core
{
	public class SBCSGroupProber : CharsetProber
	{
		private const int PROBERS_NUM = 13;

		private CharsetProber[] probers = new CharsetProber[13];

		private bool[] isActive = new bool[13];

		private int bestGuess;

		private int activeNum;

		public SBCSGroupProber()
		{
			probers[0] = new SingleByteCharSetProber(new Win1251Model());
			probers[1] = new SingleByteCharSetProber(new Koi8rModel());
			probers[2] = new SingleByteCharSetProber(new Latin5Model());
			probers[3] = new SingleByteCharSetProber(new MacCyrillicModel());
			probers[4] = new SingleByteCharSetProber(new Ibm866Model());
			probers[5] = new SingleByteCharSetProber(new Ibm855Model());
			probers[6] = new SingleByteCharSetProber(new Latin7Model());
			probers[7] = new SingleByteCharSetProber(new Win1253Model());
			probers[8] = new SingleByteCharSetProber(new Latin5BulgarianModel());
			probers[9] = new SingleByteCharSetProber(new Win1251BulgarianModel());
			HebrewProber hebrewProber = new HebrewProber();
			probers[10] = hebrewProber;
			probers[11] = new SingleByteCharSetProber(new Win1255Model(), reversed: false, hebrewProber);
			probers[12] = new SingleByteCharSetProber(new Win1255Model(), reversed: true, hebrewProber);
			hebrewProber.SetModelProbers(probers[11], probers[12]);
			Reset();
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			ProbingState probingState = ProbingState.NotMe;
			byte[] array = CharsetProber.FilterWithoutEnglishLetters(buf, offset, len);
			if (array.Length == 0)
			{
				return state;
			}
			for (int i = 0; i < 13; i++)
			{
				if (!isActive[i])
				{
					continue;
				}
				switch (probers[i].HandleData(array, 0, array.Length))
				{
				case ProbingState.FoundIt:
					bestGuess = i;
					state = ProbingState.FoundIt;
					break;
				case ProbingState.NotMe:
					isActive[i] = false;
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
			switch (state)
			{
			case ProbingState.FoundIt:
				return 0.99f;
			case ProbingState.NotMe:
				return 0.01f;
			default:
			{
				for (int i = 0; i < 13; i++)
				{
					if (isActive[i])
					{
						float confidence = probers[i].GetConfidence();
						if (num < confidence)
						{
							num = confidence;
							bestGuess = i;
						}
					}
				}
				return num;
			}
			}
		}

		public override void DumpStatus()
		{
			float confidence = GetConfidence();
			Console.WriteLine(" SBCS Group Prober --------begin status");
			for (int i = 0; i < 13; i++)
			{
				if (!isActive[i])
				{
					Console.WriteLine(" inactive: [{0}] (i.e. confidence is too low).", probers[i].GetCharsetName());
				}
				else
				{
					probers[i].DumpStatus();
				}
			}
			Console.WriteLine(" SBCS Group found best match [{0}] confidence {1}.", probers[bestGuess].GetCharsetName(), confidence);
		}

		public override void Reset()
		{
			int num = 0;
			for (int i = 0; i < 13; i++)
			{
				if (probers[i] != null)
				{
					probers[i].Reset();
					isActive[i] = true;
					num++;
				}
				else
				{
					isActive[i] = false;
				}
			}
			bestGuess = -1;
			state = ProbingState.Detecting;
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
	}
}

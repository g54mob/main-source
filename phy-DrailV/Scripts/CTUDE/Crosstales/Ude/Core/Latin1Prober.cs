using System;

namespace Crosstales.Ude.Core
{
	public class Latin1Prober : CharsetProber
	{
		private const int FREQ_CAT_NUM = 4;

		private const int UDF = 0;

		private const int OTH = 1;

		private const int ASC = 2;

		private const int ASS = 3;

		private const int ACV = 4;

		private const int ACO = 5;

		private const int ASV = 6;

		private const int ASO = 7;

		private const int CLASS_NUM = 8;

		private static readonly byte[] Latin1_CharToClass = new byte[256]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
			2, 1, 1, 1, 1, 1, 1, 3, 3, 3,
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
			3, 3, 3, 1, 1, 1, 1, 1, 1, 0,
			1, 7, 1, 1, 1, 1, 1, 1, 5, 1,
			5, 0, 5, 0, 0, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 7, 1, 7, 0, 7, 5,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
			1, 1, 4, 4, 4, 4, 4, 4, 5, 5,
			4, 4, 4, 4, 4, 4, 4, 4, 5, 5,
			4, 4, 4, 4, 4, 1, 4, 4, 4, 4,
			4, 5, 5, 5, 6, 6, 6, 6, 6, 6,
			7, 7, 6, 6, 6, 6, 6, 6, 6, 6,
			7, 7, 6, 6, 6, 6, 6, 1, 6, 6,
			6, 6, 6, 7, 7, 7
		};

		private static readonly byte[] Latin1ClassModel = new byte[64]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 3,
			3, 3, 3, 3, 3, 3, 0, 3, 3, 3,
			3, 3, 3, 3, 0, 3, 3, 3, 1, 1,
			3, 3, 0, 3, 3, 3, 1, 2, 1, 2,
			0, 3, 3, 3, 3, 3, 3, 3, 0, 3,
			1, 3, 1, 1, 1, 3, 0, 3, 1, 3,
			1, 1, 3, 3
		};

		private byte lastCharClass;

		private int[] freqCounter = new int[4];

		public Latin1Prober()
		{
			Reset();
		}

		public override string GetCharsetName()
		{
			return "windows-1252";
		}

		public override void Reset()
		{
			state = ProbingState.Detecting;
			lastCharClass = 1;
			for (int i = 0; i < 4; i++)
			{
				freqCounter[i] = 0;
			}
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			byte[] array = CharsetProber.FilterWithEnglishLetters(buf, offset, len);
			for (int i = 0; i < array.Length; i++)
			{
				byte b = Latin1_CharToClass[array[i]];
				byte b2 = Latin1ClassModel[lastCharClass * 8 + b];
				if (b2 == 0)
				{
					state = ProbingState.NotMe;
					break;
				}
				freqCounter[b2]++;
				lastCharClass = b;
			}
			return state;
		}

		public override float GetConfidence()
		{
			if (state == ProbingState.NotMe)
			{
				return 0.01f;
			}
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				num2 += freqCounter[i];
			}
			if (num2 <= 0)
			{
				num = 0f;
			}
			else
			{
				num = (float)freqCounter[3] * 1f / (float)num2;
				num -= (float)freqCounter[1] * 20f / (float)num2;
			}
			if (!(num < 0f))
			{
				return num * 0.5f;
			}
			return 0f;
		}

		public override void DumpStatus()
		{
			Console.WriteLine(" Latin1Prober: {0} [{1}]", GetConfidence(), GetCharsetName());
		}
	}
}

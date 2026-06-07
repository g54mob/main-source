using System;

namespace Crosstales.Ude.Core
{
	public class HebrewProber : CharsetProber
	{
		private const byte FINAL_KAF = 234;

		private const byte NORMAL_KAF = 235;

		private const byte FINAL_MEM = 237;

		private const byte NORMAL_MEM = 238;

		private const byte FINAL_NUN = 239;

		private const byte NORMAL_NUN = 240;

		private const byte FINAL_PE = 243;

		private const byte NORMAL_PE = 244;

		private const byte FINAL_TSADI = 245;

		private const byte NORMAL_TSADI = 246;

		private const int MIN_FINAL_CHAR_DISTANCE = 5;

		private const float MIN_MODEL_DISTANCE = 0.01f;

		protected const string VISUAL_HEBREW_NAME = "ISO-8859-8";

		protected const string LOGICAL_HEBREW_NAME = "windows-1255";

		protected CharsetProber logicalProber;

		protected CharsetProber visualProber;

		protected int finalCharLogicalScore;

		protected int finalCharVisualScore;

		protected byte prev;

		protected byte beforePrev;

		public HebrewProber()
		{
			Reset();
		}

		public void SetModelProbers(CharsetProber logical, CharsetProber visual)
		{
			logicalProber = logical;
			visualProber = visual;
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			if (GetState() == ProbingState.NotMe)
			{
				return ProbingState.NotMe;
			}
			int num = offset + len;
			for (int i = offset; i < num; i++)
			{
				byte b = buf[i];
				if (b == 32)
				{
					if (beforePrev != 32)
					{
						if (IsFinal(prev))
						{
							finalCharLogicalScore++;
						}
						else if (IsNonFinal(prev))
						{
							finalCharVisualScore++;
						}
					}
				}
				else if (beforePrev == 32 && IsFinal(prev) && b != 32)
				{
					finalCharVisualScore++;
				}
				beforePrev = prev;
				prev = b;
			}
			return ProbingState.Detecting;
		}

		public override string GetCharsetName()
		{
			int num = finalCharLogicalScore - finalCharVisualScore;
			if (num >= 5)
			{
				return "windows-1255";
			}
			if (num <= -5)
			{
				return "ISO-8859-8";
			}
			float num2 = logicalProber.GetConfidence() - visualProber.GetConfidence();
			if (num2 > 0.01f)
			{
				return "windows-1255";
			}
			if (num2 < -0.01f)
			{
				return "ISO-8859-8";
			}
			if (num < 0)
			{
				return "ISO-8859-8";
			}
			return "windows-1255";
		}

		public override void Reset()
		{
			finalCharLogicalScore = 0;
			finalCharVisualScore = 0;
			prev = 32;
			beforePrev = 32;
		}

		public override ProbingState GetState()
		{
			if (logicalProber.GetState() == ProbingState.NotMe && visualProber.GetState() == ProbingState.NotMe)
			{
				return ProbingState.NotMe;
			}
			return ProbingState.Detecting;
		}

		public override void DumpStatus()
		{
			Console.WriteLine("  HEB: {0} - {1} [Logical-Visual score]", finalCharLogicalScore, finalCharVisualScore);
		}

		public override float GetConfidence()
		{
			return 0f;
		}

		protected static bool IsFinal(byte b)
		{
			if (b != 234 && b != 237 && b != 239 && b != 243)
			{
				return b == 245;
			}
			return true;
		}

		protected static bool IsNonFinal(byte b)
		{
			if (b != 235 && b != 238 && b != 240)
			{
				return b == 244;
			}
			return true;
		}
	}
}

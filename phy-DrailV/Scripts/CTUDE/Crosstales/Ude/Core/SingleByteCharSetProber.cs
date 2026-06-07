using System;

namespace Crosstales.Ude.Core
{
	public class SingleByteCharSetProber : CharsetProber
	{
		private const int SAMPLE_SIZE = 64;

		private const int SB_ENOUGH_REL_THRESHOLD = 1024;

		private const float POSITIVE_SHORTCUT_THRESHOLD = 0.95f;

		private const float NEGATIVE_SHORTCUT_THRESHOLD = 0.05f;

		private const int SYMBOL_CAT_ORDER = 250;

		private const int NUMBER_OF_SEQ_CAT = 4;

		private const int POSITIVE_CAT = 3;

		private const int NEGATIVE_CAT = 0;

		protected SequenceModel model;

		private bool reversed;

		private byte lastOrder;

		private int totalSeqs;

		private int totalChar;

		private int[] seqCounters = new int[4];

		private int freqChar;

		private CharsetProber nameProber;

		public SingleByteCharSetProber(SequenceModel model)
			: this(model, reversed: false, null)
		{
		}

		public SingleByteCharSetProber(SequenceModel model, bool reversed, CharsetProber nameProber)
		{
			this.model = model;
			this.reversed = reversed;
			this.nameProber = nameProber;
			Reset();
		}

		public override ProbingState HandleData(byte[] buf, int offset, int len)
		{
			int num = offset + len;
			for (int i = offset; i < num; i++)
			{
				byte order = model.GetOrder(buf[i]);
				if (order < 250)
				{
					totalChar++;
				}
				if (order < 64)
				{
					freqChar++;
					if (lastOrder < 64)
					{
						totalSeqs++;
						if (!reversed)
						{
							seqCounters[model.GetPrecedence(lastOrder * 64 + order)]++;
						}
						else
						{
							seqCounters[model.GetPrecedence(order * 64 + lastOrder)]++;
						}
					}
				}
				lastOrder = order;
			}
			if (state == ProbingState.Detecting && totalSeqs > 1024)
			{
				float confidence = GetConfidence();
				if (confidence > 0.95f)
				{
					state = ProbingState.FoundIt;
				}
				else if (confidence < 0.05f)
				{
					state = ProbingState.NotMe;
				}
			}
			return state;
		}

		public override void DumpStatus()
		{
			Console.WriteLine("  SBCS: {0} [{1}]", GetConfidence(), GetCharsetName());
		}

		public override float GetConfidence()
		{
			float num = 0f;
			if (totalSeqs > 0)
			{
				num = 1f * (float)seqCounters[3] / (float)totalSeqs / model.TypicalPositiveRatio;
				num = num * (float)freqChar / (float)totalChar;
				if (num >= 1f)
				{
					num = 0.99f;
				}
				return num;
			}
			return 0.01f;
		}

		public override void Reset()
		{
			state = ProbingState.Detecting;
			lastOrder = byte.MaxValue;
			for (int i = 0; i < 4; i++)
			{
				seqCounters[i] = 0;
			}
			totalSeqs = 0;
			totalChar = 0;
			freqChar = 0;
		}

		public override string GetCharsetName()
		{
			if (nameProber != null)
			{
				return nameProber.GetCharsetName();
			}
			return model.CharsetName;
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Factory.FieldData
{
	public record LiquidFeedResult(eCarrierResultFlag Flag, double Rate)
	{
		[CompilerGenerated]
		protected virtual Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public eCarrierResultFlag Flag { get; set; }

		public double Rate { get; set; }

		[CompilerGenerated]
		public override string ToString()
		{
			return null;
		}

		[CompilerGenerated]
		protected virtual bool PrintMembers(StringBuilder builder)
		{
			return false;
		}

		[CompilerGenerated]
		public virtual bool Equals(LiquidFeedResult? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected LiquidFeedResult(LiquidFeedResult original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eCarrierResultFlag Flag, out double Rate)
		{
			Flag = default(eCarrierResultFlag);
			Rate = default(double);
		}
	}
}

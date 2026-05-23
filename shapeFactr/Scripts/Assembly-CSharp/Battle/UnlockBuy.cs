using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record UnlockBuy
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

		public eShopId shopId { get; set; }

		public UnlockBuy(List<string> param)
		{
		}

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
		public virtual bool Equals(UnlockBuy? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected UnlockBuy(UnlockBuy original)
		{
		}
	}
}

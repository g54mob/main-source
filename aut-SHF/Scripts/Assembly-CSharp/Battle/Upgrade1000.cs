using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record Upgrade1000
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

		public int value { get; set; }

		public Upgrade1000(List<string> param)
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
		public virtual bool Equals(Upgrade1000? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected Upgrade1000(Upgrade1000 original)
		{
		}
	}
}

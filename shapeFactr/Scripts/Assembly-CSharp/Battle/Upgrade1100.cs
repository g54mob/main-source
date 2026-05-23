using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record Upgrade1100
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

		public Upgrade1100(List<string> parm)
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
		public virtual bool Equals(Upgrade1100? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected Upgrade1100(Upgrade1100 original)
		{
		}
	}
}

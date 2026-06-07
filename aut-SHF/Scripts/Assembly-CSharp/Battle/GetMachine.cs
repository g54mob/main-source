using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record GetMachine
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

		public eMachine getMachine { get; set; }

		public int getValue { get; set; }

		public GetMachine(List<string> param)
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
		public virtual bool Equals(GetMachine? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected GetMachine(GetMachine original)
		{
		}
	}
}

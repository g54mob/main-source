using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record ChangeMachine
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

		public eMachine toMachine { get; set; }

		public ChangeMachine(List<string> param)
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
		public virtual bool Equals(ChangeMachine? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected ChangeMachine(ChangeMachine original)
		{
		}
	}
}

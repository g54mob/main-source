using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record OneParamData<T> where T : struct
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

		public T Item1 { get; set; }

		public OneParamData(List<string> args)
		{
		}

		public OneParamData(List<string> args, int offset)
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
		public virtual bool Equals(OneParamData<T>? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected OneParamData(OneParamData<T> original)
		{
		}
	}
}

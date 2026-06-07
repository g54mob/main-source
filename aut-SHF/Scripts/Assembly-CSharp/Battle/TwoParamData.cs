using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record TwoParamData<T, U> where T : struct where U : struct
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

		public U Item2 { get; set; }

		public (T, U) GetTuple => default((T, U));

		public TwoParamData(List<string> args)
		{
		}

		public TwoParamData(IReadOnlyList<string> args, int offset)
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
		public virtual bool Equals(TwoParamData<T, U>? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected TwoParamData(TwoParamData<T, U> original)
		{
		}
	}
}

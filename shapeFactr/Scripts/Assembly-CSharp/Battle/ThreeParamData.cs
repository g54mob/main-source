using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Battle
{
	public record ThreeParamData<T, U, V> where T : struct where U : struct where V : struct
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

		public V Item3 { get; set; }

		public ThreeParamData(List<string> args)
		{
		}

		public ThreeParamData(List<string> args, int offset)
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
		public virtual bool Equals(ThreeParamData<T, U, V>? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected ThreeParamData(ThreeParamData<T, U, V> original)
		{
		}
	}
}

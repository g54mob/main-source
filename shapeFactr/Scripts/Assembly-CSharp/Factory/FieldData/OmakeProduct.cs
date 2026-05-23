using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Factory.FieldData
{
	public record OmakeProduct(eLuggage Source, int Count, eLuggage Addition)
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

		public eLuggage Source { get; set; }

		public eLuggage Addition { get; set; }

		public int Count { get; set; }

		public bool IsAddition => false;

		private int repeatCount;

		public bool CountUp(eLuggage resultBlendId, int add)
		{
			return false;
		}

		public void Clear()
		{
		}

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
		public virtual bool Equals(OmakeProduct? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected OmakeProduct(OmakeProduct original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eLuggage Source, out int Count, out eLuggage Addition)
		{
			Source = default(eLuggage);
			Count = default(int);
			Addition = default(eLuggage);
		}
	}
}

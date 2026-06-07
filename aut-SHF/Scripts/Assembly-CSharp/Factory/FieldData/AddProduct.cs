using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Factory.FieldData
{
	public record AddProduct(eLuggage Product, int Count)
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

		public eLuggage Product { get; set; }

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
		public virtual bool Equals(AddProduct? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected AddProduct(AddProduct original)
		{
		}

		[CompilerGenerated]
		public void Deconstruct(out eLuggage Product, out int Count)
		{
			Product = default(eLuggage);
			Count = default(int);
		}
	}
}

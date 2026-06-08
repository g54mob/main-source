using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace MemoryPack
{
	public record MemoryPackSerializerOptions
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

		public StringEncoding StringEncoding { get; set; }

		public IServiceProvider? ServiceProvider { get; set; }

		public static readonly MemoryPackSerializerOptions Default;

		public static readonly MemoryPackSerializerOptions Utf8;

		public static readonly MemoryPackSerializerOptions Utf16;

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
		public virtual bool Equals(MemoryPackSerializerOptions? other)
		{
			return false;
		}

		[CompilerGenerated]
		protected MemoryPackSerializerOptions(MemoryPackSerializerOptions original)
		{
		}
	}
}

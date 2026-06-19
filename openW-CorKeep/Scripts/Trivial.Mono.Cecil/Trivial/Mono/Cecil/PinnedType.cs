using System;
using Trivial.Mono.Cecil.Metadata;

namespace Trivial.Mono.Cecil
{
	public sealed class PinnedType : TypeSpecification
	{
		public override bool IsValueType
		{
			get
			{
				return false;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override bool IsPinned => true;

		public PinnedType(TypeReference type)
			: base(type)
		{
			Mixin.CheckType(type);
			etype = Trivial.Mono.Cecil.Metadata.ElementType.Pinned;
		}
	}
}

using System;
using Trivial.Mono.Cecil.Metadata;

namespace Trivial.Mono.Cecil
{
	public sealed class ByReferenceType : TypeSpecification
	{
		public override string Name => base.Name + "&";

		public override string FullName => base.FullName + "&";

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

		public override bool IsByReference => true;

		public ByReferenceType(TypeReference type)
			: base(type)
		{
			Mixin.CheckType(type);
			etype = Trivial.Mono.Cecil.Metadata.ElementType.ByRef;
		}
	}
}

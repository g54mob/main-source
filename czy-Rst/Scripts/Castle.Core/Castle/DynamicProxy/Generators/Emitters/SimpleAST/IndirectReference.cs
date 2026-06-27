using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("&{OwnerReference}")]
	internal class IndirectReference : TypeReference
	{
		public IndirectReference(TypeReference byRefReference)
			: base(byRefReference, byRefReference.Type.GetElementType())
		{
			if (!byRefReference.Type.IsByRef)
			{
				throw new ArgumentException("Expected an IsByRef reference", "byRefReference");
			}
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
		}

		public override void LoadReference(ILGenerator gen)
		{
			OpCodeUtil.EmitLoadIndirectOpCodeForType(gen, base.Type);
		}

		public override void StoreReference(ILGenerator gen)
		{
			OpCodeUtil.EmitStoreIndirectOpCodeForType(gen, base.Type);
		}

		public static TypeReference WrapIfByRef(TypeReference reference)
		{
			if (!reference.Type.IsByRef)
			{
				return reference;
			}
			return new IndirectReference(reference);
		}

		public static TypeReference[] WrapIfByRef(TypeReference[] references)
		{
			TypeReference[] array = new TypeReference[references.Length];
			for (int i = 0; i < references.Length; i++)
			{
				array[i] = WrapIfByRef(references[i]);
			}
			return array;
		}
	}
}

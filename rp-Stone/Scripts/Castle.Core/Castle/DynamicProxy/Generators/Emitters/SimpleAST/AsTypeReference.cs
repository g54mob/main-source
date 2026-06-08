using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("{reference} as {type}")]
	public class AsTypeReference : Reference
	{
		private readonly Reference reference;

		private readonly Type type;

		public AsTypeReference(Reference reference, Type type)
		{
			if (reference == null)
			{
				throw new ArgumentNullException("reference");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.reference = reference;
			this.type = type;
			if (reference == base.OwnerReference)
			{
				base.OwnerReference = null;
			}
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			reference.LoadAddressOfReference(gen);
		}

		public override void LoadReference(ILGenerator gen)
		{
			reference.LoadReference(gen);
			gen.Emit(OpCodes.Isinst, type);
		}

		public override void StoreReference(ILGenerator gen)
		{
			reference.StoreReference(gen);
		}
	}
}

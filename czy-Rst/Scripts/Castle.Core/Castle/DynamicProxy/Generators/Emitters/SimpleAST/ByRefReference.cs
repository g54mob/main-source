using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("&{localReference}")]
	internal class ByRefReference : TypeReference
	{
		private readonly LocalReference localReference;

		public ByRefReference(LocalReference localReference)
			: base(localReference.Type)
		{
			this.localReference = localReference;
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			localReference.LoadAddressOfReference(gen);
		}

		public override void LoadReference(ILGenerator gen)
		{
			localReference.LoadAddressOfReference(gen);
		}

		public override void StoreReference(ILGenerator gen)
		{
			throw new NotImplementedException();
		}
	}
}

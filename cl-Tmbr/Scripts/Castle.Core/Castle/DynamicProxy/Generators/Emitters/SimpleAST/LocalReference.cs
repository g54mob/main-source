using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("local {Type}")]
	internal class LocalReference : TypeReference
	{
		private LocalBuilder localBuilder;

		public LocalReference(Type type)
			: base(type)
		{
		}

		public override void Generate(ILGenerator gen)
		{
			localBuilder = gen.DeclareLocal(base.Type);
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloca, localBuilder);
		}

		public override void LoadReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloc, localBuilder);
		}

		public override void StoreReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Stloc, localBuilder);
		}
	}
}

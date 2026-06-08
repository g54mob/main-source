using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("local {Type}")]
	public class LocalReference : TypeReference
	{
		private LocalBuilder localbuilder;

		public LocalReference(Type type)
			: base(type)
		{
		}

		public override void Generate(ILGenerator gen)
		{
			localbuilder = gen.DeclareLocal(base.Type);
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloca, localbuilder);
		}

		public override void LoadReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloc, localbuilder);
		}

		public override void StoreReference(ILGenerator gen)
		{
			gen.Emit(OpCodes.Stloc, localbuilder);
		}
	}
}

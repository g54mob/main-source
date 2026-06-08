using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("{fieldBuilder.Name} ({fieldBuilder.FieldType})")]
	internal class FieldReference : Reference
	{
		private readonly FieldInfo field;

		private readonly FieldBuilder fieldBuilder;

		private readonly bool isStatic;

		public FieldBuilder FieldBuilder => fieldBuilder;

		public FieldInfo Reference => field;

		public FieldReference(FieldInfo field)
		{
			this.field = field;
			if ((field.Attributes & FieldAttributes.Static) != FieldAttributes.PrivateScope)
			{
				isStatic = true;
				owner = null;
			}
		}

		public FieldReference(FieldBuilder fieldBuilder)
		{
			this.fieldBuilder = fieldBuilder;
			field = fieldBuilder;
			if ((fieldBuilder.Attributes & FieldAttributes.Static) != FieldAttributes.PrivateScope)
			{
				isStatic = true;
				owner = null;
			}
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			if (isStatic)
			{
				gen.Emit(OpCodes.Ldsflda, Reference);
			}
			else
			{
				gen.Emit(OpCodes.Ldflda, Reference);
			}
		}

		public override void LoadReference(ILGenerator gen)
		{
			if (isStatic)
			{
				gen.Emit(OpCodes.Ldsfld, Reference);
			}
			else
			{
				gen.Emit(OpCodes.Ldfld, Reference);
			}
		}

		public override void StoreReference(ILGenerator gen)
		{
			if (isStatic)
			{
				gen.Emit(OpCodes.Stsfld, Reference);
			}
			else
			{
				gen.Emit(OpCodes.Stfld, Reference);
			}
		}
	}
}

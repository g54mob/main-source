using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("{fieldbuilder.Name} ({fieldbuilder.FieldType})")]
	public class FieldReference : Reference
	{
		private readonly FieldInfo field;

		private readonly FieldBuilder fieldbuilder;

		private readonly bool isStatic;

		public FieldBuilder Fieldbuilder => fieldbuilder;

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

		public FieldReference(FieldBuilder fieldbuilder)
		{
			this.fieldbuilder = fieldbuilder;
			field = fieldbuilder;
			if ((fieldbuilder.Attributes & FieldAttributes.Static) != FieldAttributes.PrivateScope)
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

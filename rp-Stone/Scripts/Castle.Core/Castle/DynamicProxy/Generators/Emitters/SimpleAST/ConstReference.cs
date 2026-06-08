using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	[DebuggerDisplay("{value}")]
	public class ConstReference : TypeReference
	{
		private readonly object value;

		public ConstReference(object value)
			: base(value.GetType())
		{
			if (!value.GetType().GetTypeInfo().IsPrimitive && !(value is string))
			{
				throw new ProxyGenerationException("Invalid type to ConstReference");
			}
			this.value = value;
		}

		public override void Generate(ILGenerator gen)
		{
		}

		public override void LoadAddressOfReference(ILGenerator gen)
		{
			throw new NotSupportedException();
		}

		public override void LoadReference(ILGenerator gen)
		{
			OpCodeUtil.EmitLoadOpCodeForConstantValue(gen, value);
		}

		public override void StoreReference(ILGenerator gen)
		{
			throw new NotImplementedException("ConstReference.StoreReference");
		}
	}
}

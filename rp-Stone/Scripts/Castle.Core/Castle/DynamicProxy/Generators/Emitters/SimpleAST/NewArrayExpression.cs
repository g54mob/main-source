using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class NewArrayExpression : Expression
	{
		private readonly Type arrayType;

		private readonly int size;

		public NewArrayExpression(int size, Type arrayType)
		{
			this.size = size;
			this.arrayType = arrayType;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldc_I4, size);
			gen.Emit(OpCodes.Newarr, arrayType);
		}
	}
}

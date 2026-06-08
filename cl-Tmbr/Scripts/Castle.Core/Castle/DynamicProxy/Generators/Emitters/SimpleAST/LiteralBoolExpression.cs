using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class LiteralBoolExpression : IExpression, IExpressionOrStatement
	{
		private readonly bool value;

		public LiteralBoolExpression(bool value)
		{
			this.value = value;
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(value ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
		}
	}
}

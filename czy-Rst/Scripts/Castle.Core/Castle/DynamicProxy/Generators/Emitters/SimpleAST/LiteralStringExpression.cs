using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class LiteralStringExpression : IExpression, IExpressionOrStatement
	{
		private readonly string value;

		public LiteralStringExpression(string value)
		{
			this.value = value;
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldstr, value);
		}
	}
}

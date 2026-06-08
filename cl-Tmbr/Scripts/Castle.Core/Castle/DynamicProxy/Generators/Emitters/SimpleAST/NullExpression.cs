using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class NullExpression : IExpression, IExpressionOrStatement
	{
		public static readonly NullExpression Instance = new NullExpression();

		protected NullExpression()
		{
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldnull);
		}
	}
}

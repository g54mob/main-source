using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class EndExceptionBlockStatement : IStatement, IExpressionOrStatement
	{
		public void Emit(ILGenerator gen)
		{
			gen.EndExceptionBlock();
		}
	}
}

using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class FinallyStatement : IStatement, IExpressionOrStatement
	{
		public void Emit(ILGenerator gen)
		{
			gen.BeginFinallyBlock();
		}
	}
}

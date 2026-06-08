using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class TryStatement : IStatement, IExpressionOrStatement
	{
		public void Emit(ILGenerator gen)
		{
			gen.BeginExceptionBlock();
		}
	}
}

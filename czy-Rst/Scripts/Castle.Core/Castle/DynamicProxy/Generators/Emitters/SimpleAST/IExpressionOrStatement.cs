using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal interface IExpressionOrStatement
	{
		void Emit(ILGenerator gen);
	}
}

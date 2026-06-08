using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class ThrowStatement : IStatement, IExpressionOrStatement
	{
		private readonly string errorMessage;

		private readonly Type exceptionType;

		public ThrowStatement(Type exceptionType, string errorMessage)
		{
			this.exceptionType = exceptionType;
			this.errorMessage = errorMessage;
		}

		public void Emit(ILGenerator gen)
		{
			ConstructorInfo constructor = exceptionType.GetConstructor(new Type[1] { typeof(string) });
			LiteralStringExpression literalStringExpression = new LiteralStringExpression(errorMessage);
			new NewInstanceExpression(constructor, literalStringExpression).Emit(gen);
			gen.Emit(OpCodes.Throw);
		}
	}
}

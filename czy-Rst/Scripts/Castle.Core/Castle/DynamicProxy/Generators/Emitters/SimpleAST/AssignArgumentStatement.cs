using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class AssignArgumentStatement : IStatement, IExpressionOrStatement
	{
		private readonly ArgumentReference argument;

		private readonly IExpression expression;

		public AssignArgumentStatement(ArgumentReference argument, IExpression expression)
		{
			this.argument = argument;
			this.expression = expression;
		}

		public void Emit(ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(argument, gen);
			expression.Emit(gen);
		}
	}
}

using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class AssignArgumentStatement : Statement
	{
		private readonly ArgumentReference argument;

		private readonly Expression expression;

		public AssignArgumentStatement(ArgumentReference argument, Expression expression)
		{
			this.argument = argument;
			this.expression = expression;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(argument, gen);
			expression.Emit(member, gen);
		}
	}
}

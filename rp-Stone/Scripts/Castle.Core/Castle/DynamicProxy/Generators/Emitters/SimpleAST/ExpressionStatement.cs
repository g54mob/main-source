using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ExpressionStatement : Statement
	{
		private readonly Expression expression;

		public ExpressionStatement(Expression expression)
		{
			this.expression = expression;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			expression.Emit(member, gen);
		}
	}
}

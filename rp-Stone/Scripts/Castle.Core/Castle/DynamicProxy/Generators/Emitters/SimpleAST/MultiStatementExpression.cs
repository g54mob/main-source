using System.Collections.Generic;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class MultiStatementExpression : Expression
	{
		private readonly List<Statement> statements = new List<Statement>();

		public void AddStatement(Statement statement)
		{
			statements.Add(statement);
		}

		public void AddExpression(Expression expression)
		{
			AddStatement(new ExpressionStatement(expression));
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			foreach (Statement statement in statements)
			{
				statement.Emit(member, gen);
			}
		}
	}
}

using System.Collections.Generic;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class BlockStatement : IStatement, IExpressionOrStatement
	{
		private readonly List<IStatement> statements = new List<IStatement>();

		public void AddStatement(IStatement statement)
		{
			statements.Add(statement);
		}

		public void Emit(ILGenerator gen)
		{
			foreach (IStatement statement in statements)
			{
				statement.Emit(gen);
			}
		}
	}
}

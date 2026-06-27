using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class ReturnStatement : IStatement, IExpressionOrStatement
	{
		private readonly IExpression expression;

		private readonly Reference reference;

		public ReturnStatement()
		{
		}

		public ReturnStatement(Reference reference)
		{
			this.reference = reference;
		}

		public ReturnStatement(IExpression expression)
		{
			this.expression = expression;
		}

		public void Emit(ILGenerator gen)
		{
			if (reference != null)
			{
				ArgumentsUtil.EmitLoadOwnerAndReference(reference, gen);
			}
			else if (expression != null)
			{
				expression.Emit(gen);
			}
			gen.Emit(OpCodes.Ret);
		}
	}
}

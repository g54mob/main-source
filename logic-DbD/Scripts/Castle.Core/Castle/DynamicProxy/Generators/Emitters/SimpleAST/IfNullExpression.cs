using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class IfNullExpression : IExpression, IExpressionOrStatement, IStatement
	{
		private readonly IExpressionOrStatement ifNotNull;

		private readonly IExpressionOrStatement ifNull;

		private readonly Reference reference;

		private readonly IExpression expression;

		public IfNullExpression(Reference reference, IExpressionOrStatement ifNull, IExpressionOrStatement ifNotNull = null)
		{
			this.reference = reference ?? throw new ArgumentNullException("reference");
			this.ifNull = ifNull;
			this.ifNotNull = ifNotNull;
		}

		public IfNullExpression(IExpression expression, IExpressionOrStatement ifNull, IExpressionOrStatement ifNotNull = null)
		{
			this.expression = expression ?? throw new ArgumentNullException("expression");
			this.ifNull = ifNull;
			this.ifNotNull = ifNotNull;
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
			Label label = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, label);
			ifNull.Emit(gen);
			gen.MarkLabel(label);
			if (ifNotNull != null)
			{
				ifNotNull.Emit(gen);
			}
		}
	}
}

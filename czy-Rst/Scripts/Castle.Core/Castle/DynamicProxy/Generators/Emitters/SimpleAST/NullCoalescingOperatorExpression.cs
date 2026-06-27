using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class NullCoalescingOperatorExpression : IExpression, IExpressionOrStatement
	{
		private readonly IExpression @default;

		private readonly IExpression expression;

		public NullCoalescingOperatorExpression(IExpression expression, IExpression @default)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			if (@default == null)
			{
				throw new ArgumentNullException("default");
			}
			this.expression = expression;
			this.@default = @default;
		}

		public void Emit(ILGenerator gen)
		{
			expression.Emit(gen);
			gen.Emit(OpCodes.Dup);
			Label label = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, label);
			gen.Emit(OpCodes.Pop);
			@default.Emit(gen);
			gen.MarkLabel(label);
		}
	}
}

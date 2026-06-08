using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class NullCoalescingOperatorExpression : Expression
	{
		private readonly Expression @default;

		private readonly Expression expression;

		public NullCoalescingOperatorExpression(Expression expression, Expression @default)
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

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			expression.Emit(member, gen);
			gen.Emit(OpCodes.Dup);
			Label label = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, label);
			gen.Emit(OpCodes.Pop);
			@default.Emit(member, gen);
			gen.MarkLabel(label);
		}
	}
}

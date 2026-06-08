using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class IfNullExpression : Expression
	{
		private readonly IILEmitter ifNotNull;

		private readonly IILEmitter ifNull;

		private readonly Reference reference;

		private readonly Expression expression;

		public IfNullExpression(Reference reference, IILEmitter ifNull, IILEmitter ifNotNull = null)
		{
			this.reference = reference ?? throw new ArgumentNullException("reference");
			this.ifNull = ifNull;
			this.ifNotNull = ifNotNull;
		}

		public IfNullExpression(Expression expression, IILEmitter ifNull, IILEmitter ifNotNull = null)
		{
			this.expression = expression ?? throw new ArgumentNullException("expression");
			this.ifNull = ifNull;
			this.ifNotNull = ifNotNull;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			if (reference != null)
			{
				ArgumentsUtil.EmitLoadOwnerAndReference(reference, gen);
			}
			else if (expression != null)
			{
				expression.Emit(member, gen);
			}
			Label label = gen.DefineLabel();
			gen.Emit(OpCodes.Brtrue_S, label);
			ifNull.Emit(member, gen);
			gen.MarkLabel(label);
			if (ifNotNull != null)
			{
				ifNotNull.Emit(member, gen);
			}
		}
	}
}

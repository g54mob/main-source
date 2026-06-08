using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ReturnStatement : Statement
	{
		private readonly Expression expression;

		private readonly Reference reference;

		public ReturnStatement()
		{
		}

		public ReturnStatement(Reference reference)
		{
			this.reference = reference;
		}

		public ReturnStatement(Expression expression)
		{
			this.expression = expression;
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
			else if (member.ReturnType != typeof(void))
			{
				OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, member.ReturnType);
			}
			gen.Emit(OpCodes.Ret);
		}
	}
}

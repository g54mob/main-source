using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class AssignStatement : Statement
	{
		private readonly Expression expression;

		private readonly Reference target;

		public AssignStatement(Reference target, Expression expression)
		{
			this.target = target;
			this.expression = expression;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(target.OwnerReference, gen);
			expression.Emit(member, gen);
			target.StoreReference(gen);
		}
	}
}

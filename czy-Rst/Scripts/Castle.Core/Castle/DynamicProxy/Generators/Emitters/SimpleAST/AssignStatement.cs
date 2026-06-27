using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class AssignStatement : IStatement, IExpressionOrStatement
	{
		private readonly IExpression expression;

		private readonly Reference target;

		public AssignStatement(Reference target, IExpression expression)
		{
			this.target = target;
			this.expression = expression;
		}

		public void Emit(ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(target.OwnerReference, gen);
			expression.Emit(gen);
			target.StoreReference(gen);
		}
	}
}

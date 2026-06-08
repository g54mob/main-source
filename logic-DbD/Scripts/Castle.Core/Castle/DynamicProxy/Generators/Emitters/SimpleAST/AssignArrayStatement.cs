using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class AssignArrayStatement : IStatement, IExpressionOrStatement
	{
		private readonly Reference targetArray;

		private readonly int targetPosition;

		private readonly IExpression value;

		public AssignArrayStatement(Reference targetArray, int targetPosition, IExpression value)
		{
			this.targetArray = targetArray;
			this.targetPosition = targetPosition;
			this.value = value;
		}

		public void Emit(ILGenerator il)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(targetArray, il);
			il.Emit(OpCodes.Ldc_I4, targetPosition);
			value.Emit(il);
			il.Emit(OpCodes.Stelem_Ref);
		}
	}
}

using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class AssignArrayStatement : Statement
	{
		private readonly Reference targetArray;

		private readonly int targetPosition;

		private readonly Expression value;

		public AssignArrayStatement(Reference targetArray, int targetPosition, Expression value)
		{
			this.targetArray = targetArray;
			this.targetPosition = targetPosition;
			this.value = value;
		}

		public override void Emit(IMemberEmitter member, ILGenerator il)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(targetArray, il);
			il.Emit(OpCodes.Ldc_I4, targetPosition);
			value.Emit(member, il);
			il.Emit(OpCodes.Stelem_Ref);
		}
	}
}

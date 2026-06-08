using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ReferenceExpression : Expression
	{
		private readonly Reference reference;

		public ReferenceExpression(Reference reference)
		{
			this.reference = reference;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(reference, gen);
		}
	}
}

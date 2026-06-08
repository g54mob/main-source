using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class AddressOfReferenceExpression : Expression
	{
		private readonly Reference reference;

		public AddressOfReferenceExpression(Reference reference)
		{
			this.reference = reference;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(reference.OwnerReference, gen);
			reference.LoadAddressOfReference(gen);
		}
	}
}

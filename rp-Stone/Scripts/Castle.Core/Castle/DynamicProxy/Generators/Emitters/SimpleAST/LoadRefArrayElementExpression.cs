using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class LoadRefArrayElementExpression : Expression
	{
		private readonly Reference arrayReference;

		private readonly ConstReference index;

		public LoadRefArrayElementExpression(int index, Reference arrayReference)
			: this(new ConstReference(index), arrayReference)
		{
		}

		public LoadRefArrayElementExpression(ConstReference index, Reference arrayReference)
		{
			this.index = index;
			this.arrayReference = arrayReference;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(arrayReference, gen);
			ArgumentsUtil.EmitLoadOwnerAndReference(index, gen);
			gen.Emit(OpCodes.Ldelem_Ref);
		}
	}
}

using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class LoadArrayElementExpression : Expression
	{
		private readonly Reference arrayReference;

		private readonly ConstReference index;

		private readonly Type returnType;

		public LoadArrayElementExpression(int index, Reference arrayReference, Type returnType)
			: this(new ConstReference(index), arrayReference, returnType)
		{
		}

		public LoadArrayElementExpression(ConstReference index, Reference arrayReference, Type returnType)
		{
			this.index = index;
			this.arrayReference = arrayReference;
			this.returnType = returnType;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(arrayReference, gen);
			ArgumentsUtil.EmitLoadOwnerAndReference(index, gen);
			gen.Emit(OpCodes.Ldelem, returnType);
		}
	}
}

using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class LoadRefArrayElementExpression : IExpression, IExpressionOrStatement
	{
		private readonly Reference arrayReference;

		private readonly LiteralIntExpression index;

		public LoadRefArrayElementExpression(int index, Reference arrayReference)
		{
			this.index = new LiteralIntExpression(index);
			this.arrayReference = arrayReference;
		}

		public void Emit(ILGenerator gen)
		{
			ArgumentsUtil.EmitLoadOwnerAndReference(arrayReference, gen);
			index.Emit(gen);
			gen.Emit(OpCodes.Ldelem_Ref);
		}
	}
}

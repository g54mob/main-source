using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class ReferencesToObjectArrayExpression : IExpression, IExpressionOrStatement
	{
		private readonly TypeReference[] args;

		public ReferencesToObjectArrayExpression(params TypeReference[] args)
		{
			this.args = args;
		}

		public void Emit(ILGenerator gen)
		{
			LocalBuilder local = gen.DeclareLocal(typeof(object[]));
			gen.Emit(OpCodes.Ldc_I4, args.Length);
			gen.Emit(OpCodes.Newarr, typeof(object));
			gen.Emit(OpCodes.Stloc, local);
			for (int i = 0; i < args.Length; i++)
			{
				gen.Emit(OpCodes.Ldloc, local);
				gen.Emit(OpCodes.Ldc_I4, i);
				TypeReference typeReference = args[i];
				ArgumentsUtil.EmitLoadOwnerAndReference(typeReference, gen);
				if (typeReference.Type.IsByRef)
				{
					throw new NotSupportedException();
				}
				if (typeReference.Type.IsValueType)
				{
					gen.Emit(OpCodes.Box, typeReference.Type);
				}
				else if (typeReference.Type.IsGenericParameter)
				{
					gen.Emit(OpCodes.Box, typeReference.Type);
				}
				gen.Emit(OpCodes.Stelem_Ref);
			}
			gen.Emit(OpCodes.Ldloc, local);
		}
	}
}

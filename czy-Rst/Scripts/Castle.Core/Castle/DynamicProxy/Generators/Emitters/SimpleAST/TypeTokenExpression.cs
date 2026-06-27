using System;
using System.Reflection.Emit;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class TypeTokenExpression : IExpression, IExpressionOrStatement
	{
		private readonly Type type;

		public TypeTokenExpression(Type type)
		{
			this.type = type;
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldtoken, type);
			gen.Emit(OpCodes.Call, TypeMethods.GetTypeFromHandle);
		}
	}
}

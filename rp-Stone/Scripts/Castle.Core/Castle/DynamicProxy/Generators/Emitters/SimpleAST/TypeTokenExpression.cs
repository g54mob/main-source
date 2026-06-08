using System;
using System.Reflection.Emit;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class TypeTokenExpression : Expression
	{
		private readonly Type type;

		public TypeTokenExpression(Type type)
		{
			this.type = type;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldtoken, type);
			gen.Emit(OpCodes.Call, TypeMethods.GetTypeFromHandle);
		}
	}
}

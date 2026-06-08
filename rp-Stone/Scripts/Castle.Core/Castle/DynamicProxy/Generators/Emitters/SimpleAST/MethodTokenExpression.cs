using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class MethodTokenExpression : Expression
	{
		private readonly MethodInfo method;

		private readonly Type declaringType;

		public MethodTokenExpression(MethodInfo method)
		{
			this.method = method;
			declaringType = method.DeclaringType;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldtoken, method);
			if (declaringType == null)
			{
				throw new GeneratorException("declaringType can't be null for this situation");
			}
			gen.Emit(OpCodes.Ldtoken, declaringType);
			MethodInfo getMethodFromHandle = MethodBaseMethods.GetMethodFromHandle;
			gen.Emit(OpCodes.Call, getMethodFromHandle);
			gen.Emit(OpCodes.Castclass, typeof(MethodInfo));
		}
	}
}

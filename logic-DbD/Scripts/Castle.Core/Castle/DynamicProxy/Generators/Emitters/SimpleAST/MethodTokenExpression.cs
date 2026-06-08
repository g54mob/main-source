using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class MethodTokenExpression : IExpression, IExpressionOrStatement
	{
		private readonly MethodInfo method;

		public MethodTokenExpression(MethodInfo method)
		{
			this.method = method;
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldtoken, method);
			gen.Emit(OpCodes.Ldtoken, method.DeclaringType);
			MethodInfo getMethodFromHandle = MethodBaseMethods.GetMethodFromHandle;
			gen.Emit(OpCodes.Call, getMethodFromHandle);
			gen.Emit(OpCodes.Castclass, typeof(MethodInfo));
		}
	}
}

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class ConstructorInvocationStatement : IStatement, IExpressionOrStatement
	{
		private readonly IExpression[] args;

		private readonly ConstructorInfo cmethod;

		public ConstructorInvocationStatement(Type baseType)
			: this(GetDefaultConstructor(baseType))
		{
		}

		public ConstructorInvocationStatement(ConstructorInfo method, params IExpression[] args)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			cmethod = method;
			this.args = args;
		}

		public void Emit(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldarg_0);
			IExpression[] array = args;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Emit(gen);
			}
			gen.Emit(OpCodes.Call, cmethod);
		}

		private static ConstructorInfo GetDefaultConstructor(Type baseType)
		{
			Type type = baseType;
			if (type.ContainsGenericParameters)
			{
				type = type.GetGenericTypeDefinition();
			}
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			return type.GetConstructor(bindingAttr, null, Type.EmptyTypes, null);
		}
	}
}

using System;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Castle.DynamicProxy.Generators.Emitters.CodeBuilders
{
	public class ConstructorCodeBuilder : AbstractCodeBuilder
	{
		private readonly Type baseType;

		public ConstructorCodeBuilder(Type baseType, ILGenerator generator)
			: base(generator)
		{
			this.baseType = baseType;
		}

		public void InvokeBaseConstructor()
		{
			Type genericTypeDefinition = baseType;
			if (genericTypeDefinition.GetTypeInfo().ContainsGenericParameters)
			{
				genericTypeDefinition = genericTypeDefinition.GetGenericTypeDefinition();
			}
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			ConstructorInfo constructor = genericTypeDefinition.GetConstructor(bindingAttr, null, new Type[0], null);
			InvokeBaseConstructor(constructor);
		}

		public void InvokeBaseConstructor(ConstructorInfo constructor)
		{
			AddStatement(new ConstructorInvocationStatement(constructor));
		}

		public void InvokeBaseConstructor(ConstructorInfo constructor, params ArgumentReference[] arguments)
		{
			AddStatement(new ConstructorInvocationStatement(constructor, ArgumentsUtil.ConvertArgumentReferenceToExpression(arguments)));
		}
	}
}

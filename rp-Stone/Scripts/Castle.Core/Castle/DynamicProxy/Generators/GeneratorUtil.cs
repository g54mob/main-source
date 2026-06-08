using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	public static class GeneratorUtil
	{
		public static void CopyOutAndRefParameters(TypeReference[] dereferencedArguments, LocalReference invocation, MethodInfo method, MethodEmitter emitter)
		{
			ParameterInfo[] parameters = method.GetParameters();
			LocalReference localReference = null;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (IsByRef(parameters[i]) && !IsReadOnly(parameters[i]))
				{
					if (localReference == null)
					{
						localReference = StoreInvocationArgumentsInLocal(emitter, invocation);
					}
					emitter.CodeBuilder.AddStatement(AssignArgument(dereferencedArguments, i, localReference));
				}
			}
			static bool IsByRef(ParameterInfo parameter)
			{
				return parameter.ParameterType.GetTypeInfo().IsByRef;
			}
			static bool IsReadOnly(ParameterInfo parameter)
			{
				if ((parameter.Attributes & (ParameterAttributes.In | ParameterAttributes.Out)) != ParameterAttributes.In)
				{
					return false;
				}
				if (parameter.GetRequiredCustomModifiers().Any((Type x) => x == typeof(InAttribute)))
				{
					return true;
				}
				if (parameter.GetCustomAttributes(inherit: false).Any((object x) => x.GetType().FullName == "System.Runtime.CompilerServices.IsReadOnlyAttribute"))
				{
					return true;
				}
				return false;
			}
		}

		private static ConvertExpression Argument(int i, LocalReference invocationArgs, TypeReference[] arguments)
		{
			return new ConvertExpression(arguments[i].Type, new LoadRefArrayElementExpression(i, invocationArgs));
		}

		private static AssignStatement AssignArgument(TypeReference[] dereferencedArguments, int i, LocalReference invocationArgs)
		{
			return new AssignStatement(dereferencedArguments[i], Argument(i, invocationArgs, dereferencedArguments));
		}

		private static AssignStatement GetArguments(LocalReference invocationArgs, LocalReference invocation)
		{
			return new AssignStatement(invocationArgs, new MethodInvocationExpression(invocation, InvocationMethods.GetArguments));
		}

		private static LocalReference StoreInvocationArgumentsInLocal(MethodEmitter emitter, LocalReference invocation)
		{
			LocalReference localReference = emitter.CodeBuilder.DeclareLocal(typeof(object[]));
			emitter.CodeBuilder.AddStatement(GetArguments(localReference, invocation));
			return localReference;
		}
	}
}

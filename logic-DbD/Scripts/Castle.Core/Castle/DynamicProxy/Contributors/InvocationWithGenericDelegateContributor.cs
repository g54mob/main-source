using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	internal class InvocationWithGenericDelegateContributor : IInvocationCreationContributor
	{
		private readonly Type delegateType;

		private readonly MetaMethod method;

		private readonly Reference targetReference;

		public InvocationWithGenericDelegateContributor(Type delegateType, MetaMethod method, Reference targetReference)
		{
			this.delegateType = delegateType;
			this.method = method;
			this.targetReference = targetReference;
		}

		public ConstructorEmitter CreateConstructor(ArgumentReference[] baseCtorArguments, AbstractTypeEmitter invocation)
		{
			return invocation.CreateConstructor(baseCtorArguments);
		}

		public MethodInfo GetCallbackMethod()
		{
			return delegateType.GetMethod("Invoke");
		}

		public MethodInvocationExpression GetCallbackMethodInvocation(AbstractTypeEmitter invocation, IExpression[] args, Reference targetField, MethodEmitter invokeMethodOnTarget)
		{
			return new MethodInvocationExpression(GetDelegate(invocation, invokeMethodOnTarget), GetCallbackMethod(), args);
		}

		public IExpression[] GetConstructorInvocationArguments(IExpression[] arguments, ClassEmitter proxy)
		{
			return arguments;
		}

		private Reference GetDelegate(AbstractTypeEmitter invocation, MethodEmitter invokeMethodOnTarget)
		{
			Type[] typeArguments = invocation.GenericTypeParams.AsTypeArray();
			Type type = delegateType.MakeGenericType(typeArguments);
			LocalReference localReference = invokeMethodOnTarget.CodeBuilder.DeclareLocal(type);
			MethodInfo closedMethodOnTarget = method.MethodOnTarget.MakeGenericMethod(typeArguments);
			invokeMethodOnTarget.CodeBuilder.AddStatement(SetDelegate(localReference, targetReference, type, closedMethodOnTarget));
			return localReference;
		}

		private AssignStatement SetDelegate(LocalReference localDelegate, Reference localTarget, Type closedDelegateType, MethodInfo closedMethodOnTarget)
		{
			MethodInvocationExpression right = new MethodInvocationExpression(null, DelegateMethods.CreateDelegate, new TypeTokenExpression(closedDelegateType), localTarget, new MethodTokenExpression(closedMethodOnTarget));
			return new AssignStatement(localDelegate, new ConvertExpression(closedDelegateType, right));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	public abstract class InvocationTypeGenerator : IGenerator<AbstractTypeEmitter>
	{
		protected readonly MetaMethod method;

		protected readonly Type targetType;

		private readonly MethodInfo callback;

		private readonly bool canChangeTarget;

		private readonly IInvocationCreationContributor contributor;

		protected InvocationTypeGenerator(Type targetType, MetaMethod method, MethodInfo callback, bool canChangeTarget, IInvocationCreationContributor contributor)
		{
			this.targetType = targetType;
			this.method = method;
			this.callback = callback;
			this.canChangeTarget = canChangeTarget;
			this.contributor = contributor;
		}

		protected abstract ArgumentReference[] GetBaseCtorArguments(Type targetFieldType, ProxyGenerationOptions proxyGenerationOptions, out ConstructorInfo baseConstructor);

		protected abstract Type GetBaseType();

		protected abstract FieldReference GetTargetReference();

		public AbstractTypeEmitter Generate(ClassEmitter @class, ProxyGenerationOptions options, INamingScope namingScope)
		{
			MethodInfo methodInfo = method.Method;
			Type[] interfaces = new Type[0];
			if (canChangeTarget)
			{
				interfaces = new Type[1] { typeof(IChangeProxyTarget) };
			}
			AbstractTypeEmitter emitter = GetEmitter(@class, interfaces, namingScope, methodInfo);
			emitter.CopyGenericParametersFromMethod(methodInfo);
			CreateConstructor(emitter, options);
			FieldReference targetReference = GetTargetReference();
			if (canChangeTarget)
			{
				ImplementChangeProxyTargetInterface(@class, emitter, targetReference);
			}
			ImplemementInvokeMethodOnTarget(emitter, methodInfo.GetParameters(), targetReference, callback);
			emitter.DefineCustomAttribute<SerializableAttribute>();
			return emitter;
		}

		protected virtual MethodInvocationExpression GetCallbackMethodInvocation(AbstractTypeEmitter invocation, Expression[] args, MethodInfo callbackMethod, Reference targetField, MethodEmitter invokeMethodOnTarget)
		{
			if (contributor != null)
			{
				return contributor.GetCallbackMethodInvocation(invocation, args, targetField, invokeMethodOnTarget);
			}
			return new MethodInvocationExpression(new AsTypeReference(targetField, callbackMethod.DeclaringType), callbackMethod, args)
			{
				VirtualCall = true
			};
		}

		protected virtual void ImplementInvokeMethodOnTarget(AbstractTypeEmitter invocation, ParameterInfo[] parameters, MethodEmitter invokeMethodOnTarget, Reference targetField)
		{
			MethodInfo callbackMethod = GetCallbackMethod(invocation);
			if (callbackMethod == null)
			{
				EmitCallThrowOnNoTarget(invokeMethodOnTarget);
				return;
			}
			Expression[] array = new Expression[parameters.Length];
			Dictionary<int, LocalReference> dictionary = new Dictionary<int, LocalReference>();
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				Type closedParameterType = invocation.GetClosedParameterType(parameterInfo.ParameterType);
				if (closedParameterType.IsByRef)
				{
					LocalReference localReference = invokeMethodOnTarget.CodeBuilder.DeclareLocal(closedParameterType.GetElementType());
					invokeMethodOnTarget.CodeBuilder.AddStatement(new AssignStatement(localReference, new ConvertExpression(closedParameterType.GetElementType(), new MethodInvocationExpression(SelfReference.Self, InvocationMethods.GetArgumentValue, new LiteralIntExpression(i)))));
					ByRefReference reference = new ByRefReference(localReference);
					array[i] = new ReferenceExpression(reference);
					dictionary[i] = localReference;
				}
				else
				{
					array[i] = new ConvertExpression(closedParameterType, new MethodInvocationExpression(SelfReference.Self, InvocationMethods.GetArgumentValue, new LiteralIntExpression(i)));
				}
			}
			if (dictionary.Count > 0)
			{
				invokeMethodOnTarget.CodeBuilder.AddStatement(new TryStatement());
			}
			MethodInvocationExpression callbackMethodInvocation = GetCallbackMethodInvocation(invocation, array, callbackMethod, targetField, invokeMethodOnTarget);
			LocalReference localReference2 = null;
			if (callbackMethod.ReturnType != typeof(void))
			{
				Type closedParameterType2 = invocation.GetClosedParameterType(callbackMethod.ReturnType);
				localReference2 = invokeMethodOnTarget.CodeBuilder.DeclareLocal(closedParameterType2);
				invokeMethodOnTarget.CodeBuilder.AddStatement(new AssignStatement(localReference2, callbackMethodInvocation));
			}
			else
			{
				invokeMethodOnTarget.CodeBuilder.AddStatement(new ExpressionStatement(callbackMethodInvocation));
			}
			AssignBackByRefArguments(invokeMethodOnTarget, dictionary);
			if (callbackMethod.ReturnType != typeof(void))
			{
				MethodInvocationExpression expression = new MethodInvocationExpression(SelfReference.Self, InvocationMethods.SetReturnValue, new ConvertExpression(typeof(object), localReference2.Type, localReference2.ToExpression()));
				invokeMethodOnTarget.CodeBuilder.AddStatement(new ExpressionStatement(expression));
			}
			invokeMethodOnTarget.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private void AssignBackByRefArguments(MethodEmitter invokeMethodOnTarget, Dictionary<int, LocalReference> byRefArguments)
		{
			if (byRefArguments.Count == 0)
			{
				return;
			}
			invokeMethodOnTarget.CodeBuilder.AddStatement(new FinallyStatement());
			foreach (KeyValuePair<int, LocalReference> byRefArgument in byRefArguments)
			{
				int key = byRefArgument.Key;
				LocalReference value = byRefArgument.Value;
				invokeMethodOnTarget.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(SelfReference.Self, InvocationMethods.SetArgumentValue, new LiteralIntExpression(key), new ConvertExpression(typeof(object), value.Type, new ReferenceExpression(value)))));
			}
			invokeMethodOnTarget.CodeBuilder.AddStatement(new EndExceptionBlockStatement());
		}

		private void CreateConstructor(AbstractTypeEmitter invocation, ProxyGenerationOptions options)
		{
			ConstructorInfo baseConstructor;
			ArgumentReference[] baseCtorArguments = GetBaseCtorArguments(targetType, options, out baseConstructor);
			ConstructorEmitter constructorEmitter = CreateConstructor(invocation, baseCtorArguments);
			constructorEmitter.CodeBuilder.InvokeBaseConstructor(baseConstructor, baseCtorArguments);
			constructorEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private ConstructorEmitter CreateConstructor(AbstractTypeEmitter invocation, ArgumentReference[] baseCtorArguments)
		{
			if (contributor == null)
			{
				return invocation.CreateConstructor(baseCtorArguments);
			}
			return contributor.CreateConstructor(baseCtorArguments, invocation);
		}

		private void EmitCallThrowOnNoTarget(MethodEmitter invokeMethodOnTarget)
		{
			ExpressionStatement stmt = new ExpressionStatement(new MethodInvocationExpression(InvocationMethods.ThrowOnNoTarget));
			invokeMethodOnTarget.CodeBuilder.AddStatement(stmt);
			invokeMethodOnTarget.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private MethodInfo GetCallbackMethod(AbstractTypeEmitter invocation)
		{
			if (contributor != null)
			{
				return contributor.GetCallbackMethod();
			}
			MethodInfo methodInfo = callback;
			if (methodInfo == null)
			{
				return null;
			}
			if (!methodInfo.IsGenericMethod)
			{
				return methodInfo;
			}
			return methodInfo.MakeGenericMethod(invocation.GetGenericArgumentsFor(methodInfo));
		}

		private AbstractTypeEmitter GetEmitter(ClassEmitter @class, Type[] interfaces, INamingScope namingScope, MethodInfo methodInfo)
		{
			string suggestedName = $"Castle.Proxies.Invocations.{methodInfo.DeclaringType.Name}_{methodInfo.Name}";
			string uniqueName = namingScope.ParentScope.GetUniqueName(suggestedName);
			return new ClassEmitter(@class.ModuleScope, uniqueName, GetBaseType(), interfaces, TypeAttributes.Public | TypeAttributes.Serializable, !@class.InStrongNamedModule);
		}

		private void ImplemementInvokeMethodOnTarget(AbstractTypeEmitter invocation, ParameterInfo[] parameters, FieldReference targetField, MethodInfo callbackMethod)
		{
			MethodEmitter invokeMethodOnTarget = invocation.CreateMethod("InvokeMethodOnTarget", typeof(void));
			ImplementInvokeMethodOnTarget(invocation, parameters, invokeMethodOnTarget, targetField);
		}

		private void ImplementChangeInvocationTarget(AbstractTypeEmitter invocation, FieldReference targetField)
		{
			MethodEmitter methodEmitter = invocation.CreateMethod("ChangeInvocationTarget", typeof(void), typeof(object));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(targetField, new ConvertExpression(targetType, methodEmitter.Arguments[0].ToExpression())));
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private void ImplementChangeProxyTarget(AbstractTypeEmitter invocation, ClassEmitter @class)
		{
			MethodEmitter methodEmitter = invocation.CreateMethod("ChangeProxyTarget", typeof(void), typeof(object));
			FieldReference fieldReference = new FieldReference(InvocationMethods.ProxyObject);
			LocalReference localReference = methodEmitter.CodeBuilder.DeclareLocal(typeof(IProxyTargetAccessor));
			methodEmitter.CodeBuilder.AddStatement(new AssignStatement(localReference, new ConvertExpression(localReference.Type, fieldReference.ToExpression())));
			MethodInfo methodInfo = typeof(IProxyTargetAccessor).GetMethod("DynProxySetTarget");
			methodEmitter.CodeBuilder.AddStatement(new ExpressionStatement(new MethodInvocationExpression(localReference, methodInfo, methodEmitter.Arguments[0].ToExpression())
			{
				VirtualCall = true
			}));
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement());
		}

		private void ImplementChangeProxyTargetInterface(ClassEmitter @class, AbstractTypeEmitter invocation, FieldReference targetField)
		{
			ImplementChangeInvocationTarget(invocation, targetField);
			ImplementChangeProxyTarget(invocation, @class);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	public class ClassProxyTargetContributor : CompositeTypeContributor
	{
		private readonly IList<MethodInfo> methodsToSkip;

		private readonly Type targetType;

		public ClassProxyTargetContributor(Type targetType, IList<MethodInfo> methodsToSkip, INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
			this.methodsToSkip = methodsToSkip;
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			ClassMembersCollector classMembersCollector = new ClassMembersCollector(targetType)
			{
				Logger = base.Logger
			};
			classMembersCollector.CollectMembersToProxy(hook);
			yield return classMembersCollector;
			foreach (Type @interface in interfaces)
			{
				InterfaceMembersOnClassCollector interfaceMembersOnClassCollector = new InterfaceMembersOnClassCollector(@interface, onlyProxyVirtual: true, targetType.GetTypeInfo().GetRuntimeInterfaceMap(@interface))
				{
					Logger = base.Logger
				};
				interfaceMembersOnClassCollector.CollectMembersToProxy(hook);
				yield return interfaceMembersOnClassCollector;
			}
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			if (methodsToSkip.Contains(method.Method))
			{
				return null;
			}
			if (!method.Proxyable)
			{
				return new MinimialisticMethodGenerator(method, overrideMethod);
			}
			if (ExplicitlyImplementedInterfaceMethod(method))
			{
				return ExplicitlyImplementedInterfaceMethodGenerator(method, @class, options, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class, options);
			GetTargetExpressionDelegate getTargetExpressionDelegate = (ClassEmitter c, MethodInfo m) => new TypeTokenExpression(targetType);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, getTargetExpressionDelegate, getTargetExpressionDelegate, overrideMethod, null);
		}

		private Type BuildInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			MethodInfo method2 = method.Method;
			if (!method.HasTarget)
			{
				return new InheritanceInvocationTypeGenerator(targetType, method, null, null).Generate(@class, options, namingScope).BuildType();
			}
			MethodBuilder methodBuilder = CreateCallbackMethod(@class, method2, method.MethodOnTarget);
			return new InheritanceInvocationTypeGenerator(methodBuilder.DeclaringType, method, methodBuilder, null).Generate(@class, options, namingScope).BuildType();
		}

		private MethodBuilder CreateCallbackMethod(ClassEmitter emitter, MethodInfo methodInfo, MethodInfo methodOnTarget)
		{
			MethodInfo methodInfo2 = methodOnTarget ?? methodInfo;
			MethodEmitter methodEmitter = emitter.CreateMethod(namingScope.GetUniqueName(methodInfo.Name + "_callback"), methodInfo2);
			if (methodInfo2.IsGenericMethod)
			{
				methodInfo2 = methodInfo2.MakeGenericMethod(methodEmitter.GenericTypeParams.AsTypeArray());
			}
			Expression[] array = new Expression[methodEmitter.Arguments.Length];
			for (int i = 0; i < methodEmitter.Arguments.Length; i++)
			{
				array[i] = methodEmitter.Arguments[i].ToExpression();
			}
			methodEmitter.CodeBuilder.AddStatement(new ReturnStatement(new MethodInvocationExpression(SelfReference.Self, methodInfo2, array)));
			return methodEmitter.MethodBuilder;
		}

		private bool ExplicitlyImplementedInterfaceMethod(MetaMethod method)
		{
			return method.MethodOnTarget.IsPrivate;
		}

		private MethodGenerator ExplicitlyImplementedInterfaceMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			Type delegateType = GetDelegateType(method, @class, options);
			IInvocationCreationContributor contributor = GetContributor(delegateType, method);
			Type invocation = new InheritanceInvocationTypeGenerator(targetType, method, null, contributor).Generate(@class, options, namingScope).BuildType();
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocation, (ClassEmitter c, MethodInfo m) => new TypeTokenExpression(targetType), overrideMethod, contributor);
		}

		private IInvocationCreationContributor GetContributor(Type @delegate, MetaMethod method)
		{
			if (!@delegate.GetTypeInfo().IsGenericType)
			{
				return new InvocationWithDelegateContributor(@delegate, targetType, method, namingScope);
			}
			return new InvocationWithGenericDelegateContributor(@delegate, method, new FieldReference(InvocationMethods.ProxyObject));
		}

		private Type GetDelegateType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			CacheKey key = new CacheKey(typeof(Delegate).GetTypeInfo(), targetType, new Type[1] { method.MethodOnTarget.ReturnType }.Concat(ArgumentsUtil.GetTypes(method.MethodOnTarget.GetParameters())).ToArray(), null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new DelegateTypeGenerator(method, targetType).Generate(@class, options, namingScope).BuildType());
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			return BuildInvocationType(method, @class, options);
		}
	}
}

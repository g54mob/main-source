using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Contributors
{
	public class ClassProxyWithTargetTargetContributor : CompositeTypeContributor
	{
		private readonly IList<MethodInfo> methodsToSkip;

		private readonly Type targetType;

		public ClassProxyWithTargetTargetContributor(Type targetType, IList<MethodInfo> methodsToSkip, INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
			this.methodsToSkip = methodsToSkip;
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			WrappedClassMembersCollector wrappedClassMembersCollector = new WrappedClassMembersCollector(targetType)
			{
				Logger = base.Logger
			};
			wrappedClassMembersCollector.CollectMembersToProxy(hook);
			yield return wrappedClassMembersCollector;
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
			if (!IsDirectlyAccessible(method))
			{
				return IndirectlyCalledMethodGenerator(method, @class, options, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class, options);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, (ClassEmitter c, MethodInfo m) => c.GetField("__target").ToExpression(), overrideMethod, null);
		}

		private Type BuildInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			if (!method.HasTarget)
			{
				return new InheritanceInvocationTypeGenerator(targetType, method, null, null).Generate(@class, options, namingScope).BuildType();
			}
			return new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget: false, null).Generate(@class, options, namingScope).BuildType();
		}

		private IInvocationCreationContributor GetContributor(Type @delegate, MetaMethod method)
		{
			if (!@delegate.GetTypeInfo().IsGenericType)
			{
				return new InvocationWithDelegateContributor(@delegate, targetType, method, namingScope);
			}
			return new InvocationWithGenericDelegateContributor(@delegate, method, new FieldReference(InvocationMethods.CompositionInvocationTarget));
		}

		private Type GetDelegateType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			CacheKey key = new CacheKey(typeof(Delegate).GetTypeInfo(), targetType, new Type[1] { method.MethodOnTarget.ReturnType }.Concat(ArgumentsUtil.GetTypes(method.MethodOnTarget.GetParameters())).ToArray(), null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new DelegateTypeGenerator(method, targetType).Generate(@class, options, namingScope).BuildType());
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			Type[] array = new Type[1] { typeof(IInvocation) };
			CacheKey key = new CacheKey(method.Method, CompositionInvocationTypeGenerator.BaseType, array, null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => BuildInvocationType(method, @class, options));
		}

		private MethodGenerator IndirectlyCalledMethodGenerator(MetaMethod method, ClassEmitter proxy, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			Type delegateType = GetDelegateType(method, proxy, options);
			IInvocationCreationContributor contributor = GetContributor(delegateType, method);
			Type invocation = new CompositionInvocationTypeGenerator(targetType, method, null, canChangeTarget: false, contributor).Generate(proxy, options, namingScope).BuildType();
			return new MethodWithInvocationGenerator(method, proxy.GetField("__interceptors"), invocation, (ClassEmitter c, MethodInfo m) => c.GetField("__target").ToExpression(), overrideMethod, contributor);
		}

		private bool IsDirectlyAccessible(MetaMethod method)
		{
			return method.MethodOnTarget.IsPublic;
		}
	}
}

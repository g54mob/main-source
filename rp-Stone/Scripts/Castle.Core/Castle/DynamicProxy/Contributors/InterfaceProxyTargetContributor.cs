using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	public class InterfaceProxyTargetContributor : CompositeTypeContributor
	{
		private readonly bool canChangeTarget;

		private readonly Type proxyTargetType;

		public InterfaceProxyTargetContributor(Type proxyTargetType, bool canChangeTarget, INamingScope namingScope)
			: base(namingScope)
		{
			this.proxyTargetType = proxyTargetType;
			this.canChangeTarget = canChangeTarget;
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			foreach (Type @interface in interfaces)
			{
				MembersCollector collectorForInterface = GetCollectorForInterface(@interface);
				collectorForInterface.Logger = base.Logger;
				collectorForInterface.CollectMembersToProxy(hook);
				yield return collectorForInterface;
			}
		}

		protected virtual MembersCollector GetCollectorForInterface(Type @interface)
		{
			return new InterfaceMembersOnClassCollector(@interface, onlyProxyVirtual: false, proxyTargetType.GetTypeInfo().GetRuntimeInterfaceMap(@interface));
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			if (!method.Proxyable)
			{
				return new ForwardingMethodGenerator(method, overrideMethod, (ClassEmitter c, MethodInfo m) => c.GetField("__target"));
			}
			Type invocationType = GetInvocationType(method, @class, options);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, (ClassEmitter c, MethodInfo m) => c.GetField("__target").ToExpression(), overrideMethod, null);
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			CacheKey key = new CacheKey(interfaces: (!canChangeTarget) ? new Type[1] { typeof(IInvocation) } : new Type[2]
			{
				typeof(IInvocation),
				typeof(IChangeProxyTarget)
			}, target: method.Method, type: CompositionInvocationTypeGenerator.BaseType, options: null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget, null).Generate(@class, options, namingScope).BuildType());
		}
	}
}

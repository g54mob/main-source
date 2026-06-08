using System;
using System.Collections.Generic;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	public class InterfaceProxyWithoutTargetContributor : CompositeTypeContributor
	{
		private readonly GetTargetExpressionDelegate getTargetExpression;

		protected bool canChangeTarget;

		public InterfaceProxyWithoutTargetContributor(INamingScope namingScope, GetTargetExpressionDelegate getTarget)
			: base(namingScope)
		{
			getTargetExpression = getTarget;
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			foreach (Type @interface in interfaces)
			{
				InterfaceMembersCollector interfaceMembersCollector = new InterfaceMembersCollector(@interface);
				interfaceMembersCollector.CollectMembersToProxy(hook);
				yield return interfaceMembersCollector;
			}
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			if (!method.Proxyable)
			{
				return new MinimialisticMethodGenerator(method, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class, options);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, getTargetExpression, overrideMethod, null);
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter emitter, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = emitter.ModuleScope;
			CacheKey key = new CacheKey(interfaces: (!canChangeTarget) ? new Type[1] { typeof(IInvocation) } : new Type[2]
			{
				typeof(IInvocation),
				typeof(IChangeProxyTarget)
			}, target: method.Method, type: CompositionInvocationTypeGenerator.BaseType, options: null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget, null).Generate(emitter, options, namingScope).BuildType());
		}
	}
}

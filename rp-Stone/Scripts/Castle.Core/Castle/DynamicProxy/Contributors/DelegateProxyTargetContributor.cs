using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Contributors
{
	public class DelegateProxyTargetContributor : CompositeTypeContributor
	{
		private readonly Type targetType;

		public DelegateProxyTargetContributor(Type targetType, INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
		}

		protected override IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook)
		{
			DelegateMembersCollector delegateMembersCollector = new DelegateMembersCollector(targetType)
			{
				Logger = base.Logger
			};
			delegateMembersCollector.CollectMembersToProxy(hook);
			yield return delegateMembersCollector;
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			Type invocationType = GetInvocationType(method, @class, options);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, (ClassEmitter c, MethodInfo m) => c.GetField("__target").ToExpression(), overrideMethod, null);
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter emitter, ProxyGenerationOptions options)
		{
			ModuleScope moduleScope = emitter.ModuleScope;
			CacheKey key = new CacheKey(method.Method, CompositionInvocationTypeGenerator.BaseType, null, null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget: false, null).Generate(emitter, options, namingScope).BuildType());
		}
	}
}

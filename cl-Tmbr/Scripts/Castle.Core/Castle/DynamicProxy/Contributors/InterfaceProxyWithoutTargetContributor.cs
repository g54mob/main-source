using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal class InterfaceProxyWithoutTargetContributor : CompositeTypeContributor
	{
		private readonly GetTargetExpressionDelegate getTargetExpression;

		protected bool canChangeTarget;

		public InterfaceProxyWithoutTargetContributor(INamingScope namingScope, GetTargetExpressionDelegate getTarget)
			: base(namingScope)
		{
			getTargetExpression = getTarget;
		}

		protected override IEnumerable<MembersCollector> GetCollectors()
		{
			foreach (Type @interface in interfaces)
			{
				yield return new InterfaceMembersCollector(@interface);
			}
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod)
		{
			if (!method.Proxyable)
			{
				return new MinimalisticMethodGenerator(method, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, getTargetExpression, overrideMethod, null);
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter emitter)
		{
			MethodInfo methodInfo = method.Method;
			if (!canChangeTarget && methodInfo.IsAbstract)
			{
				return typeof(InterfaceMethodWithoutTargetInvocation);
			}
			ModuleScope moduleScope = emitter.ModuleScope;
			CacheKey key = new CacheKey(interfaces: (!canChangeTarget) ? new Type[1] { typeof(IInvocation) } : new Type[2]
			{
				typeof(IInvocation),
				typeof(IChangeProxyTarget)
			}, target: methodInfo, type: CompositionInvocationTypeGenerator.BaseType, options: null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new CompositionInvocationTypeGenerator(methodInfo.DeclaringType, method, methodInfo, canChangeTarget, null).Generate(emitter, namingScope).BuildType());
		}
	}
}

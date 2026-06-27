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
	internal class ClassProxyWithTargetTargetContributor : CompositeTypeContributor
	{
		private readonly Type targetType;

		public ClassProxyWithTargetTargetContributor(Type targetType, INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
		}

		protected override IEnumerable<MembersCollector> GetCollectors()
		{
			yield return new WrappedClassMembersCollector(targetType)
			{
				Logger = base.Logger
			};
			foreach (Type @interface in interfaces)
			{
				yield return new InterfaceMembersOnClassCollector(@interface, onlyProxyVirtual: true, targetType.GetInterfaceMap(@interface))
				{
					Logger = base.Logger
				};
			}
		}

		protected override MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod)
		{
			if (method.Ignore)
			{
				return null;
			}
			bool flag = IsDirectlyAccessible(method);
			if (!method.Proxyable)
			{
				if (flag)
				{
					return new ForwardingMethodGenerator(method, overrideMethod, (ClassEmitter c, MethodInfo m) => c.GetField("__target"));
				}
				return IndirectlyCalledMethodGenerator(method, @class, overrideMethod, skipInterceptors: true);
			}
			if (!flag)
			{
				return IndirectlyCalledMethodGenerator(method, @class, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, (ClassEmitter c, MethodInfo m) => c.GetField("__target"), overrideMethod, null);
		}

		private Type BuildInvocationType(MetaMethod method, ClassEmitter @class)
		{
			if (!method.HasTarget)
			{
				return new InheritanceInvocationTypeGenerator(targetType, method, null, null).Generate(@class, namingScope).BuildType();
			}
			return new CompositionInvocationTypeGenerator(method.Method.DeclaringType, method, method.Method, canChangeTarget: false, null).Generate(@class, namingScope).BuildType();
		}

		private IInvocationCreationContributor GetContributor(Type @delegate, MetaMethod method)
		{
			if (!@delegate.IsGenericType)
			{
				return new InvocationWithDelegateContributor(@delegate, targetType, method, namingScope);
			}
			return new InvocationWithGenericDelegateContributor(@delegate, method, new FieldReference(InvocationMethods.CompositionInvocationTarget));
		}

		private Type GetDelegateType(MetaMethod method, ClassEmitter @class)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			CacheKey key = new CacheKey(typeof(Delegate), targetType, new Type[1] { method.MethodOnTarget.ReturnType }.Concat(ArgumentsUtil.GetTypes(method.MethodOnTarget.GetParameters())).ToArray(), null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new DelegateTypeGenerator(method, targetType).Generate(@class, namingScope).BuildType());
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			Type[] array = new Type[1] { typeof(IInvocation) };
			CacheKey key = new CacheKey(method.Method, CompositionInvocationTypeGenerator.BaseType, array, null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => BuildInvocationType(method, @class));
		}

		private MethodGenerator IndirectlyCalledMethodGenerator(MetaMethod method, ClassEmitter proxy, OverrideMethodDelegate overrideMethod, bool skipInterceptors = false)
		{
			Type delegateType = GetDelegateType(method, proxy);
			IInvocationCreationContributor contributor = GetContributor(delegateType, method);
			Type invocation = new CompositionInvocationTypeGenerator(targetType, method, null, canChangeTarget: false, contributor).Generate(proxy, namingScope).BuildType();
			IExpression interceptors;
			if (!skipInterceptors)
			{
				IExpression field = proxy.GetField("__interceptors");
				interceptors = field;
			}
			else
			{
				IExpression field = NullExpression.Instance;
				interceptors = field;
			}
			return new MethodWithInvocationGenerator(method, interceptors, invocation, (ClassEmitter c, MethodInfo m) => c.GetField("__target"), overrideMethod, contributor);
		}

		private bool IsDirectlyAccessible(MetaMethod method)
		{
			return method.MethodOnTarget.IsPublic;
		}
	}
}

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
	internal class ClassProxyTargetContributor : CompositeTypeContributor
	{
		private readonly Type targetType;

		public ClassProxyTargetContributor(Type targetType, INamingScope namingScope)
			: base(namingScope)
		{
			this.targetType = targetType;
		}

		protected override IEnumerable<MembersCollector> GetCollectors()
		{
			yield return new ClassMembersCollector(targetType)
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
			if (!method.Proxyable)
			{
				return new MinimalisticMethodGenerator(method, overrideMethod);
			}
			if (ExplicitlyImplementedInterfaceMethod(method))
			{
				return ExplicitlyImplementedInterfaceMethodGenerator(method, @class, overrideMethod);
			}
			Type invocationType = GetInvocationType(method, @class);
			GetTargetExpressionDelegate getTargetExpressionDelegate = (ClassEmitter c, MethodInfo m) => new TypeTokenExpression(targetType);
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocationType, getTargetExpressionDelegate, getTargetExpressionDelegate, overrideMethod, null);
		}

		private Type BuildInvocationType(MetaMethod method, ClassEmitter @class)
		{
			MethodInfo method2 = method.Method;
			if (!method.HasTarget)
			{
				return new InheritanceInvocationTypeGenerator(targetType, method, null, null).Generate(@class, namingScope).BuildType();
			}
			MethodBuilder methodBuilder = CreateCallbackMethod(@class, method2, method.MethodOnTarget);
			return new InheritanceInvocationTypeGenerator(methodBuilder.DeclaringType, method, methodBuilder, null).Generate(@class, namingScope).BuildType();
		}

		private MethodBuilder CreateCallbackMethod(ClassEmitter emitter, MethodInfo methodInfo, MethodInfo methodOnTarget)
		{
			MethodInfo methodInfo2 = methodOnTarget ?? methodInfo;
			MethodEmitter methodEmitter = emitter.CreateMethod(namingScope.GetUniqueName(methodInfo.Name + "_callback"), methodInfo2);
			if (methodInfo2.IsGenericMethod)
			{
				methodInfo2 = methodInfo2.MakeGenericMethod(methodEmitter.GenericTypeParams.AsTypeArray());
			}
			CodeBuilder codeBuilder = methodEmitter.CodeBuilder;
			SelfReference self = SelfReference.Self;
			MethodInfo method = methodInfo2;
			IExpression[] arguments = methodEmitter.Arguments;
			codeBuilder.AddStatement(new ReturnStatement(new MethodInvocationExpression(self, method, arguments)));
			return methodEmitter.MethodBuilder;
		}

		private bool ExplicitlyImplementedInterfaceMethod(MetaMethod method)
		{
			return method.MethodOnTarget.IsPrivate;
		}

		private MethodGenerator ExplicitlyImplementedInterfaceMethodGenerator(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod)
		{
			Type delegateType = GetDelegateType(method, @class);
			IInvocationCreationContributor contributor = GetContributor(delegateType, method);
			Type invocation = new InheritanceInvocationTypeGenerator(targetType, method, null, contributor).Generate(@class, namingScope).BuildType();
			return new MethodWithInvocationGenerator(method, @class.GetField("__interceptors"), invocation, (ClassEmitter c, MethodInfo m) => new TypeTokenExpression(targetType), overrideMethod, contributor);
		}

		private IInvocationCreationContributor GetContributor(Type @delegate, MetaMethod method)
		{
			if (!@delegate.IsGenericType)
			{
				return new InvocationWithDelegateContributor(@delegate, targetType, method, namingScope);
			}
			return new InvocationWithGenericDelegateContributor(@delegate, method, new FieldReference(InvocationMethods.ProxyObject));
		}

		private Type GetDelegateType(MetaMethod method, ClassEmitter @class)
		{
			ModuleScope moduleScope = @class.ModuleScope;
			CacheKey key = new CacheKey(typeof(Delegate), targetType, new Type[1] { method.MethodOnTarget.ReturnType }.Concat(ArgumentsUtil.GetTypes(method.MethodOnTarget.GetParameters())).ToArray(), null);
			return moduleScope.TypeCache.GetOrAddWithoutTakingLock(key, (CacheKey _) => new DelegateTypeGenerator(method, targetType).Generate(@class, namingScope).BuildType());
		}

		private Type GetInvocationType(MetaMethod method, ClassEmitter @class)
		{
			if (!method.HasTarget)
			{
				return typeof(InheritanceInvocationWithoutTarget);
			}
			return BuildInvocationType(method, @class);
		}
	}
}

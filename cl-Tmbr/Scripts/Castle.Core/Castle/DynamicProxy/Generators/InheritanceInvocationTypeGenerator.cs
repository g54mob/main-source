using System;
using System.Reflection;
using Castle.DynamicProxy.Contributors;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;
using Castle.DynamicProxy.Tokens;

namespace Castle.DynamicProxy.Generators
{
	internal class InheritanceInvocationTypeGenerator : InvocationTypeGenerator
	{
		public static readonly Type BaseType = typeof(InheritanceInvocation);

		public InheritanceInvocationTypeGenerator(Type targetType, MetaMethod method, MethodInfo callback, IInvocationCreationContributor contributor)
			: base(targetType, method, callback, canChangeTarget: false, contributor)
		{
		}

		protected override ArgumentReference[] GetBaseCtorArguments(Type targetFieldType, out ConstructorInfo baseConstructor)
		{
			baseConstructor = InvocationMethods.InheritanceInvocationConstructor;
			return new ArgumentReference[5]
			{
				new ArgumentReference(typeof(Type)),
				new ArgumentReference(typeof(object)),
				new ArgumentReference(typeof(IInterceptor[])),
				new ArgumentReference(typeof(MethodInfo)),
				new ArgumentReference(typeof(object[]))
			};
		}

		protected override Type GetBaseType()
		{
			return BaseType;
		}

		protected override FieldReference GetTargetReference()
		{
			return new FieldReference(InvocationMethods.ProxyObject);
		}
	}
}

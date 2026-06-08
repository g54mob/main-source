using System;
using System.Reflection;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Tokens
{
	public static class InvocationMethods
	{
		public static readonly ConstructorInfo CompositionInvocationConstructor = typeof(CompositionInvocation).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[5]
		{
			typeof(object),
			typeof(object),
			typeof(IInterceptor[]),
			typeof(MethodInfo),
			typeof(object[])
		}, null);

		public static readonly MethodInfo CompositionInvocationEnsureValidTarget = typeof(CompositionInvocation).GetMethod("EnsureValidTarget", BindingFlags.Instance | BindingFlags.NonPublic);

		public static readonly MethodInfo GetArgumentValue = typeof(AbstractInvocation).GetMethod("GetArgumentValue");

		public static readonly MethodInfo GetArguments = typeof(AbstractInvocation).GetMethod("get_Arguments");

		public static readonly MethodInfo GetReturnValue = typeof(AbstractInvocation).GetMethod("get_ReturnValue");

		public static readonly ConstructorInfo InheritanceInvocationConstructor = typeof(InheritanceInvocation).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[5]
		{
			typeof(Type),
			typeof(object),
			typeof(IInterceptor[]),
			typeof(MethodInfo),
			typeof(object[])
		}, null);

		public static readonly ConstructorInfo InheritanceInvocationConstructorWithSelector = typeof(InheritanceInvocation).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[7]
		{
			typeof(Type),
			typeof(object),
			typeof(IInterceptor[]),
			typeof(MethodInfo),
			typeof(object[]),
			typeof(IInterceptorSelector),
			typeof(IInterceptor[]).MakeByRefType()
		}, null);

		public static readonly MethodInfo Proceed = typeof(AbstractInvocation).GetMethod("Proceed", BindingFlags.Instance | BindingFlags.Public);

		public static readonly FieldInfo ProxyObject = typeof(AbstractInvocation).GetField("proxyObject", BindingFlags.Instance | BindingFlags.NonPublic);

		public static readonly MethodInfo SetArgumentValue = typeof(AbstractInvocation).GetMethod("SetArgumentValue");

		public static readonly MethodInfo SetGenericMethodArguments = typeof(AbstractInvocation).GetMethod("SetGenericMethodArguments", new Type[1] { typeof(Type[]) });

		public static readonly MethodInfo SetReturnValue = typeof(AbstractInvocation).GetMethod("set_ReturnValue");

		public static readonly FieldInfo CompositionInvocationTarget = typeof(CompositionInvocation).GetField("target", BindingFlags.Instance | BindingFlags.NonPublic);

		public static readonly MethodInfo ThrowOnNoTarget = typeof(AbstractInvocation).GetMethod("ThrowOnNoTarget", BindingFlags.Instance | BindingFlags.NonPublic);

		public static readonly MethodInfo EnsureValidTarget = CompositionInvocationEnsureValidTarget;

		public static readonly FieldInfo Target = CompositionInvocationTarget;
	}
}

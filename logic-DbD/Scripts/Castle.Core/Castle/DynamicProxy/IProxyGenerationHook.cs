using System;
using System.Reflection;

namespace Castle.DynamicProxy
{
	public interface IProxyGenerationHook
	{
		void MethodsInspected();

		void NonProxyableMemberNotification(Type type, MemberInfo memberInfo);

		bool ShouldInterceptMethod(Type type, MethodInfo methodInfo);
	}
}

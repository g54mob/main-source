using System;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	public class DelegateProxyGenerationHook : IProxyGenerationHook
	{
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			return obj.GetType() == typeof(DelegateProxyGenerationHook);
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode();
		}

		public void MethodsInspected()
		{
		}

		public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
		{
		}

		public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
		{
			return methodInfo.Name.Equals("Invoke");
		}
	}
}

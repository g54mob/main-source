using System;
using System.Collections.Generic;
using System.Reflection;

namespace Castle.DynamicProxy
{
	[Serializable]
	public class AllMethodsHook : IProxyGenerationHook
	{
		protected static readonly ICollection<Type> SkippedTypes = new Type[3]
		{
			typeof(object),
			typeof(MarshalByRefObject),
			typeof(ContextBoundObject)
		};

		public virtual bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
		{
			return !SkippedTypes.Contains(methodInfo.DeclaringType);
		}

		public virtual void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
		{
		}

		public virtual void MethodsInspected()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				return obj.GetType() == GetType();
			}
			return false;
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode();
		}
	}
}

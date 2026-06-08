using System;
using System.Reflection;
using Castle.DynamicProxy.Generators;

namespace Castle.DynamicProxy.Contributors
{
	public class ClassMembersCollector : MembersCollector
	{
		public ClassMembersCollector(Type targetType)
			: base(targetType)
		{
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (!ProxyUtil.IsAccessibleMethod(method))
			{
				return null;
			}
			bool flag = AcceptMethod(method, onlyVirtuals: true, hook);
			if (!flag && !method.IsAbstract)
			{
				return null;
			}
			return new MetaMethod(method, method, isStandalone, flag, !method.IsAbstract);
		}
	}
}

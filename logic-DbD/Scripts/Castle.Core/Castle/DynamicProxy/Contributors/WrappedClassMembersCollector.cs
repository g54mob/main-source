using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal class WrappedClassMembersCollector : ClassMembersCollector
	{
		public WrappedClassMembersCollector(Type type)
			: base(type)
		{
		}

		public override void CollectMembersToProxy(IProxyGenerationHook hook, IMembersCollectorSink sink)
		{
			base.CollectMembersToProxy(hook, sink);
			CollectFields(hook);
		}

		protected override MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (!ProxyUtil.IsAccessibleMethod(method))
			{
				return null;
			}
			if (!AcceptMethodPreScreen(method, onlyVirtuals: true, hook))
			{
				return null;
			}
			bool proxyable = hook.ShouldInterceptMethod(type, method);
			return new MetaMethod(method, method, isStandalone, proxyable, hasTarget: true);
		}

		protected bool IsGeneratedByTheCompiler(FieldInfo field)
		{
			return field.IsDefined(typeof(CompilerGeneratedAttribute));
		}

		protected virtual bool IsOKToBeOnProxy(FieldInfo field)
		{
			return IsGeneratedByTheCompiler(field);
		}

		private void CollectFields(IProxyGenerationHook hook)
		{
			FieldInfo[] allFields = type.GetAllFields();
			foreach (FieldInfo fieldInfo in allFields)
			{
				if (!IsOKToBeOnProxy(fieldInfo))
				{
					hook.NonProxyableMemberNotification(type, fieldInfo);
				}
			}
		}
	}
}

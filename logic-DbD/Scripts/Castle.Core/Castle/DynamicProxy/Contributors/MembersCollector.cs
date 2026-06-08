using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal abstract class MembersCollector
	{
		private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private ILogger logger = NullLogger.Instance;

		protected readonly Type type;

		public ILogger Logger
		{
			get
			{
				return logger;
			}
			set
			{
				logger = value;
			}
		}

		protected MembersCollector(Type type)
		{
			this.type = type;
		}

		public virtual void CollectMembersToProxy(IProxyGenerationHook hook, IMembersCollectorSink sink)
		{
			HashSet<MethodInfo> checkedMethods = new HashSet<MethodInfo>();
			CollectProperties();
			CollectEvents();
			CollectMethods();
			void AddEvent(EventInfo @event)
			{
				MethodInfo addMethod = @event.GetAddMethod(nonPublic: true);
				MethodInfo removeMethod = @event.GetRemoveMethod(nonPublic: true);
				MetaMethod metaMethod = null;
				MetaMethod metaMethod2 = null;
				if (addMethod != null)
				{
					metaMethod = AddMethod(addMethod, isStandalone: false);
				}
				if (removeMethod != null)
				{
					metaMethod2 = AddMethod(removeMethod, isStandalone: false);
				}
				if (metaMethod != null || metaMethod2 != null)
				{
					sink.Add(new MetaEvent(@event, metaMethod, metaMethod2, EventAttributes.None));
				}
			}
			MetaMethod AddMethod(MethodInfo method, bool isStandalone)
			{
				if (!checkedMethods.Add(method))
				{
					return null;
				}
				MetaMethod methodToGenerate = GetMethodToGenerate(method, hook, isStandalone);
				if (methodToGenerate != null)
				{
					sink.Add(methodToGenerate);
				}
				return methodToGenerate;
			}
			void AddProperty(PropertyInfo property)
			{
				MetaMethod metaMethod = null;
				MetaMethod metaMethod2 = null;
				if (property.CanRead)
				{
					MethodInfo getMethod = property.GetGetMethod(nonPublic: true);
					metaMethod = AddMethod(getMethod, isStandalone: false);
				}
				if (property.CanWrite)
				{
					MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
					metaMethod2 = AddMethod(setMethod, isStandalone: false);
				}
				if (metaMethod2 != null || metaMethod != null)
				{
					IEnumerable<CustomAttributeInfo> nonInheritableAttributes = property.GetNonInheritableAttributes();
					ParameterInfo[] indexParameters = property.GetIndexParameters();
					sink.Add(new MetaProperty(property, metaMethod, metaMethod2, nonInheritableAttributes.Select((CustomAttributeInfo a) => a.Builder), indexParameters.Select((ParameterInfo a) => a.ParameterType).ToArray()));
				}
			}
			void CollectEvents()
			{
				EventInfo[] events = type.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (EventInfo eventInfo in events)
				{
					AddEvent(eventInfo);
				}
			}
			void CollectMethods()
			{
				MethodInfo[] allInstanceMethods = MethodFinder.GetAllInstanceMethods(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo method in allInstanceMethods)
				{
					AddMethod(method, isStandalone: true);
				}
			}
			void CollectProperties()
			{
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo property in properties)
				{
					AddProperty(property);
				}
			}
		}

		protected abstract MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone);

		protected bool AcceptMethod(MethodInfo method, bool onlyVirtuals, IProxyGenerationHook hook)
		{
			if (AcceptMethodPreScreen(method, onlyVirtuals, hook))
			{
				return hook.ShouldInterceptMethod(type, method);
			}
			return false;
		}

		protected bool AcceptMethodPreScreen(MethodInfo method, bool onlyVirtuals, IProxyGenerationHook hook)
		{
			if (IsInternalAndNotVisibleToDynamicProxy(method))
			{
				return false;
			}
			bool flag = method.IsVirtual && !method.IsFinal;
			if (onlyVirtuals && !flag)
			{
				if (method.DeclaringType != typeof(MarshalByRefObject) && !method.IsGetType() && !method.IsMemberwiseClone())
				{
					Logger.DebugFormat("Excluded non-overridable method {0} on {1} because it cannot be intercepted.", method.Name, method.DeclaringType.FullName);
					hook.NonProxyableMemberNotification(type, method);
				}
				return false;
			}
			if (method.IsFinal)
			{
				Logger.DebugFormat("Excluded sealed method {0} on {1} because it cannot be intercepted.", method.Name, method.DeclaringType.FullName);
				return false;
			}
			if (!method.IsPublic && !method.IsFamily && !method.IsAssembly && !method.IsFamilyOrAssembly && !method.IsFamilyAndAssembly)
			{
				return false;
			}
			if (method.DeclaringType == typeof(MarshalByRefObject))
			{
				return false;
			}
			if (method.IsFinalizer())
			{
				return false;
			}
			return true;
		}

		private static bool IsInternalAndNotVisibleToDynamicProxy(MethodInfo method)
		{
			if (ProxyUtil.IsInternal(method))
			{
				return !ProxyUtil.AreInternalsVisibleToDynamicProxy(method.DeclaringType.Assembly);
			}
			return false;
		}
	}
}

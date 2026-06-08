using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	public abstract class MembersCollector
	{
		private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private ILogger logger = NullLogger.Instance;

		private ICollection<MethodInfo> checkedMethods = new HashSet<MethodInfo>();

		private readonly IDictionary<PropertyInfo, MetaProperty> properties = new Dictionary<PropertyInfo, MetaProperty>();

		private readonly IDictionary<EventInfo, MetaEvent> events = new Dictionary<EventInfo, MetaEvent>();

		private readonly IDictionary<MethodInfo, MetaMethod> methods = new Dictionary<MethodInfo, MetaMethod>();

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

		public IEnumerable<MetaMethod> Methods => methods.Values;

		public IEnumerable<MetaProperty> Properties => properties.Values;

		public IEnumerable<MetaEvent> Events => events.Values;

		protected MembersCollector(Type type)
		{
			this.type = type;
		}

		public virtual void CollectMembersToProxy(IProxyGenerationHook hook)
		{
			if (checkedMethods == null)
			{
				throw new InvalidOperationException($"Can't call 'CollectMembersToProxy' method twice. This usually signifies a bug in custom {typeof(ITypeContributor)}.");
			}
			CollectProperties(hook);
			CollectEvents(hook);
			CollectMethods(hook);
			checkedMethods = null;
		}

		private void CollectProperties(IProxyGenerationHook hook)
		{
			PropertyInfo[] array = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo property in array)
			{
				AddProperty(property, hook);
			}
		}

		private void CollectEvents(IProxyGenerationHook hook)
		{
			EventInfo[] array = type.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (EventInfo eventInfo in array)
			{
				AddEvent(eventInfo, hook);
			}
		}

		private void CollectMethods(IProxyGenerationHook hook)
		{
			MethodInfo[] allInstanceMethods = MethodFinder.GetAllInstanceMethods(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo method in allInstanceMethods)
			{
				AddMethod(method, hook, isStandalone: true);
			}
		}

		private void AddProperty(PropertyInfo property, IProxyGenerationHook hook)
		{
			MetaMethod metaMethod = null;
			MetaMethod metaMethod2 = null;
			if (property.CanRead)
			{
				MethodInfo getMethod = property.GetGetMethod(nonPublic: true);
				metaMethod = AddMethod(getMethod, hook, isStandalone: false);
			}
			if (property.CanWrite)
			{
				MethodInfo setMethod = property.GetSetMethod(nonPublic: true);
				metaMethod2 = AddMethod(setMethod, hook, isStandalone: false);
			}
			if (metaMethod2 != null || metaMethod != null)
			{
				IEnumerable<CustomAttributeInfo> nonInheritableAttributes = property.GetNonInheritableAttributes();
				ParameterInfo[] indexParameters = property.GetIndexParameters();
				properties[property] = new MetaProperty(property.Name, property.PropertyType, property.DeclaringType, metaMethod, metaMethod2, nonInheritableAttributes.Select((CustomAttributeInfo a) => a.Builder), indexParameters.Select((ParameterInfo a) => a.ParameterType).ToArray());
			}
		}

		private void AddEvent(EventInfo @event, IProxyGenerationHook hook)
		{
			MethodInfo addMethod = @event.GetAddMethod(nonPublic: true);
			MethodInfo removeMethod = @event.GetRemoveMethod(nonPublic: true);
			MetaMethod metaMethod = null;
			MetaMethod metaMethod2 = null;
			if (addMethod != null)
			{
				metaMethod = AddMethod(addMethod, hook, isStandalone: false);
			}
			if (removeMethod != null)
			{
				metaMethod2 = AddMethod(removeMethod, hook, isStandalone: false);
			}
			if (metaMethod != null || metaMethod2 != null)
			{
				events[@event] = new MetaEvent(@event.Name, @event.DeclaringType, @event.EventHandlerType, metaMethod, metaMethod2, EventAttributes.None);
			}
		}

		private MetaMethod AddMethod(MethodInfo method, IProxyGenerationHook hook, bool isStandalone)
		{
			if (checkedMethods.Contains(method))
			{
				return null;
			}
			checkedMethods.Add(method);
			if (methods.ContainsKey(method))
			{
				return null;
			}
			MetaMethod methodToGenerate = GetMethodToGenerate(method, hook, isStandalone);
			if (methodToGenerate != null)
			{
				methods[method] = methodToGenerate;
			}
			return methodToGenerate;
		}

		protected abstract MetaMethod GetMethodToGenerate(MethodInfo method, IProxyGenerationHook hook, bool isStandalone);

		protected bool AcceptMethod(MethodInfo method, bool onlyVirtuals, IProxyGenerationHook hook)
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
			if (!method.IsPublic && !method.IsFamily && !method.IsAssembly && !method.IsFamilyOrAssembly)
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
			return hook.ShouldInterceptMethod(type, method);
		}

		private static bool IsInternalAndNotVisibleToDynamicProxy(MethodInfo method)
		{
			if (ProxyUtil.IsInternal(method))
			{
				return !ProxyUtil.AreInternalsVisibleToDynamicProxy(method.DeclaringType.GetTypeInfo().Assembly);
			}
			return false;
		}
	}
}

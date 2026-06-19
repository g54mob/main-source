using System;
using System.Reflection;
using Loxodon.Framework.Binding.Paths;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class UniversalTargetProxyFactory : ITargetProxyFactory
	{
		private IPathParser pathParser;

		public UniversalTargetProxyFactory(IPathParser pathParser)
		{
			this.pathParser = pathParser;
		}

		public ITargetProxy CreateProxy(object target, BindingDescription description)
		{
			IProxyType proxyType = ((description.TargetType != null) ? description.TargetType.AsProxy() : target.GetType().AsProxy());
			if (TargetNameUtil.IsCollection(description.TargetName))
			{
				return CreateItemProxy(target, proxyType, description);
			}
			IProxyMemberInfo member = proxyType.GetMember(description.TargetName);
			if (member == null)
			{
				member = proxyType.GetMember(description.TargetName, BindingFlags.Instance | BindingFlags.NonPublic);
			}
			if (member == null)
			{
				throw new MissingMemberException(proxyType.Type.FullName, description.TargetName);
			}
			if (member is IProxyPropertyInfo { ValueType: var valueType } proxyPropertyInfo)
			{
				if (typeof(IObservableProperty).IsAssignableFrom(valueType))
				{
					object value = proxyPropertyInfo.GetValue(target);
					if (value == null)
					{
						throw new NullReferenceException($"The \"{proxyPropertyInfo.Name}\" property is null in class \"{proxyPropertyInfo.DeclaringType.Name}\".");
					}
					return new ObservableTargetProxy(target, (IObservableProperty)value);
				}
				if (typeof(IInteractionAction).IsAssignableFrom(valueType))
				{
					object value2 = proxyPropertyInfo.GetValue(target);
					if (value2 == null)
					{
						return null;
					}
					return new InteractionTargetProxy(target, (IInteractionAction)value2);
				}
				return new PropertyTargetProxy(target, proxyPropertyInfo);
			}
			if (member is IProxyFieldInfo { ValueType: var valueType2 } proxyFieldInfo)
			{
				if (typeof(IObservableProperty).IsAssignableFrom(valueType2))
				{
					object value3 = proxyFieldInfo.GetValue(target);
					if (value3 == null)
					{
						throw new NullReferenceException($"The \"{proxyFieldInfo.Name}\" field is null in class \"{proxyFieldInfo.DeclaringType.Name}\".");
					}
					return new ObservableTargetProxy(target, (IObservableProperty)value3);
				}
				if (typeof(IInteractionAction).IsAssignableFrom(valueType2))
				{
					object value4 = proxyFieldInfo.GetValue(target);
					if (value4 == null)
					{
						return null;
					}
					return new InteractionTargetProxy(target, (IInteractionAction)value4);
				}
				return new FieldTargetProxy(target, proxyFieldInfo);
			}
			if (member is IProxyEventInfo eventInfo)
			{
				return new EventTargetProxy(target, eventInfo);
			}
			if (member is IProxyMethodInfo methodInfo)
			{
				return new MethodTargetProxy(target, methodInfo);
			}
			return null;
		}

		private ITargetProxy CreateItemProxy(object target, IProxyType type, BindingDescription description)
		{
			Path path = pathParser.Parse(description.TargetName);
			if (path.Count < 1 || path.Count > 2)
			{
				return null;
			}
			IndexedNode indexedNode = null;
			object obj = null;
			if (path.Count == 1)
			{
				indexedNode = (IndexedNode)path[0];
				obj = target;
			}
			if (path.Count == 2)
			{
				indexedNode = (IndexedNode)path[1];
				MemberNode memberNode = (MemberNode)path[0];
				obj = GetCollectionTarget(type, target, memberNode.Name);
				if (obj == null)
				{
					throw new NullReferenceException($"Unable to bind the \"{description}\". The value of the Property or Field named \"{memberNode.Name}\" cannot be null.");
				}
			}
			IProxyType proxyType = obj.GetType().AsProxy();
			IProxyItemInfo item = proxyType.GetItem();
			if (item == null)
			{
				throw new MissingMemberException(proxyType.Type.FullName, "Item");
			}
			if (indexedNode is IntegerIndexedNode integerIndexedNode)
			{
				return new ItemTargetProxy<int>(obj, integerIndexedNode.Value, item);
			}
			if (indexedNode is StringIndexedNode stringIndexedNode)
			{
				return new ItemTargetProxy<string>(obj, stringIndexedNode.Value, item);
			}
			return null;
		}

		private static object GetCollectionTarget(IProxyType type, object target, string name)
		{
			IProxyPropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property != null)
			{
				return property.GetValue(target);
			}
			IProxyFieldInfo field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				return field.GetValue(target);
			}
			throw new MissingMemberException(type.Type.FullName, name);
		}
	}
}

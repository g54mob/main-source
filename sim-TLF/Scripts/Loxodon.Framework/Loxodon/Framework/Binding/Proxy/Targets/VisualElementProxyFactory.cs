using System;
using System.Reflection;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Framework.Observables;
using UnityEngine.UIElements;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class VisualElementProxyFactory : ITargetProxyFactory
	{
		private static readonly string REGISTER_VALUE_CHANGED_CALLBACK = "RegisterValueChangedCallback";

		public ITargetProxy CreateProxy(object target, BindingDescription description)
		{
			if (TargetNameUtil.IsCollection(description.TargetName))
			{
				return null;
			}
			if (!target.GetType().IsSubclassOfGenericTypeDefinition(typeof(INotifyValueChanged<>)))
			{
				return null;
			}
			if (REGISTER_VALUE_CHANGED_CALLBACK.Equals(description.TargetName))
			{
				return CreateValueChangedEventProxy(target);
			}
			IProxyType proxyType = ((description.TargetType != null) ? description.TargetType.AsProxy() : target.GetType().AsProxy());
			IProxyMemberInfo member = proxyType.GetMember(description.TargetName);
			if (member == null)
			{
				member = proxyType.GetMember(description.TargetName, BindingFlags.Instance | BindingFlags.NonPublic);
			}
			if (member == null)
			{
				throw new MissingMemberException(proxyType.Type.FullName, description.TargetName);
			}
			if (member is IProxyPropertyInfo proxyPropertyInfo)
			{
				if (typeof(IObservableProperty).IsAssignableFrom(proxyPropertyInfo.ValueType))
				{
					return null;
				}
				if (typeof(Clickable).IsAssignableFrom(proxyPropertyInfo.ValueType))
				{
					object value = proxyPropertyInfo.GetValue(target);
					if (value == null)
					{
						throw new NullReferenceException(proxyPropertyInfo.Name);
					}
					return new ClickableEventProxy(target, (Clickable)value);
				}
				if (!REGISTER_VALUE_CHANGED_CALLBACK.Equals(description.UpdateTrigger))
				{
					return null;
				}
				return CreateVisualElementPropertyProxy(target, proxyPropertyInfo);
			}
			if (member is IProxyFieldInfo proxyFieldInfo)
			{
				if (typeof(IObservableProperty).IsAssignableFrom(proxyFieldInfo.ValueType))
				{
					return null;
				}
				if (typeof(Clickable).IsAssignableFrom(proxyFieldInfo.ValueType))
				{
					object value2 = proxyFieldInfo.GetValue(target);
					if (value2 == null)
					{
						throw new NullReferenceException(proxyFieldInfo.Name);
					}
					return new ClickableEventProxy(target, (Clickable)value2);
				}
				if (!REGISTER_VALUE_CHANGED_CALLBACK.Equals(description.UpdateTrigger))
				{
					return null;
				}
				return CreateVisualElementFieldProxy(target, proxyFieldInfo);
			}
			return null;
		}

		protected virtual ITargetProxy CreateValueChangedEventProxy(object target)
		{
			Type propertyType = target.GetType().GetProperty("value").PropertyType;
			return Type.GetTypeCode(propertyType) switch
			{
				TypeCode.String => new ValueChangedEventProxy<string>((INotifyValueChanged<string>)target), 
				TypeCode.Boolean => new ValueChangedEventProxy<bool>((INotifyValueChanged<bool>)target), 
				TypeCode.SByte => new ValueChangedEventProxy<sbyte>((INotifyValueChanged<sbyte>)target), 
				TypeCode.Byte => new ValueChangedEventProxy<byte>((INotifyValueChanged<byte>)target), 
				TypeCode.Int16 => new ValueChangedEventProxy<short>((INotifyValueChanged<short>)target), 
				TypeCode.UInt16 => new ValueChangedEventProxy<ushort>((INotifyValueChanged<ushort>)target), 
				TypeCode.Int32 => new ValueChangedEventProxy<int>((INotifyValueChanged<int>)target), 
				TypeCode.UInt32 => new ValueChangedEventProxy<uint>((INotifyValueChanged<uint>)target), 
				TypeCode.Int64 => new ValueChangedEventProxy<long>((INotifyValueChanged<long>)target), 
				TypeCode.UInt64 => new ValueChangedEventProxy<ulong>((INotifyValueChanged<ulong>)target), 
				TypeCode.Char => new ValueChangedEventProxy<char>((INotifyValueChanged<char>)target), 
				TypeCode.Single => new ValueChangedEventProxy<float>((INotifyValueChanged<float>)target), 
				TypeCode.Double => new ValueChangedEventProxy<double>((INotifyValueChanged<double>)target), 
				TypeCode.Decimal => new ValueChangedEventProxy<decimal>((INotifyValueChanged<decimal>)target), 
				TypeCode.DateTime => new ValueChangedEventProxy<DateTime>((INotifyValueChanged<DateTime>)target), 
				_ => (ITargetProxy)Activator.CreateInstance(typeof(ValueChangedEventProxy<>).MakeGenericType(propertyType), target), 
			};
		}

		protected virtual ITargetProxy CreateVisualElementPropertyProxy(object target, IProxyPropertyInfo propertyInfo)
		{
			return propertyInfo.ValueTypeCode switch
			{
				TypeCode.String => new VisualElementPropertyProxy<string>(target, propertyInfo), 
				TypeCode.Boolean => new VisualElementPropertyProxy<bool>(target, propertyInfo), 
				TypeCode.SByte => new VisualElementPropertyProxy<sbyte>(target, propertyInfo), 
				TypeCode.Byte => new VisualElementPropertyProxy<byte>(target, propertyInfo), 
				TypeCode.Int16 => new VisualElementPropertyProxy<short>(target, propertyInfo), 
				TypeCode.UInt16 => new VisualElementPropertyProxy<ushort>(target, propertyInfo), 
				TypeCode.Int32 => new VisualElementPropertyProxy<int>(target, propertyInfo), 
				TypeCode.UInt32 => new VisualElementPropertyProxy<uint>(target, propertyInfo), 
				TypeCode.Int64 => new VisualElementPropertyProxy<long>(target, propertyInfo), 
				TypeCode.UInt64 => new VisualElementPropertyProxy<ulong>(target, propertyInfo), 
				TypeCode.Char => new VisualElementPropertyProxy<char>(target, propertyInfo), 
				TypeCode.Single => new VisualElementPropertyProxy<float>(target, propertyInfo), 
				TypeCode.Double => new VisualElementPropertyProxy<double>(target, propertyInfo), 
				TypeCode.Decimal => new VisualElementPropertyProxy<decimal>(target, propertyInfo), 
				TypeCode.DateTime => new VisualElementPropertyProxy<DateTime>(target, propertyInfo), 
				_ => (ITargetProxy)Activator.CreateInstance(typeof(VisualElementPropertyProxy<>).MakeGenericType(propertyInfo.ValueType), target, propertyInfo), 
			};
		}

		protected virtual ITargetProxy CreateVisualElementFieldProxy(object target, IProxyFieldInfo fieldInfo)
		{
			return fieldInfo.ValueTypeCode switch
			{
				TypeCode.String => new VisualElementFieldProxy<string>(target, fieldInfo), 
				TypeCode.Boolean => new VisualElementFieldProxy<bool>(target, fieldInfo), 
				TypeCode.SByte => new VisualElementFieldProxy<sbyte>(target, fieldInfo), 
				TypeCode.Byte => new VisualElementFieldProxy<byte>(target, fieldInfo), 
				TypeCode.Int16 => new VisualElementFieldProxy<short>(target, fieldInfo), 
				TypeCode.UInt16 => new VisualElementFieldProxy<ushort>(target, fieldInfo), 
				TypeCode.Int32 => new VisualElementFieldProxy<int>(target, fieldInfo), 
				TypeCode.UInt32 => new VisualElementFieldProxy<uint>(target, fieldInfo), 
				TypeCode.Int64 => new VisualElementFieldProxy<long>(target, fieldInfo), 
				TypeCode.UInt64 => new VisualElementFieldProxy<ulong>(target, fieldInfo), 
				TypeCode.Char => new VisualElementFieldProxy<char>(target, fieldInfo), 
				TypeCode.Single => new VisualElementFieldProxy<float>(target, fieldInfo), 
				TypeCode.Double => new VisualElementFieldProxy<double>(target, fieldInfo), 
				TypeCode.Decimal => new VisualElementFieldProxy<decimal>(target, fieldInfo), 
				TypeCode.DateTime => new VisualElementFieldProxy<DateTime>(target, fieldInfo), 
				_ => (ITargetProxy)Activator.CreateInstance(typeof(VisualElementFieldProxy<>).MakeGenericType(fieldInfo.ValueType), target, fieldInfo), 
			};
		}
	}
}

using System;
using Loxodon.Framework.Binding.Reflection;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public class ItemTargetProxy<TKey> : ValueTargetProxyBase
	{
		protected readonly IProxyItemInfo itemInfo;

		protected readonly TKey key;

		public override Type Type => itemInfo.ValueType;

		public override TypeCode TypeCode => itemInfo.ValueTypeCode;

		public override BindingMode DefaultMode => BindingMode.OneWay;

		public ItemTargetProxy(object target, TKey key, IProxyItemInfo itemInfo)
			: base(target)
		{
			this.key = key;
			this.itemInfo = itemInfo;
		}

		public override object GetValue()
		{
			object obj = Target;
			if (obj == null)
			{
				return null;
			}
			return itemInfo.GetValue(obj, key);
		}

		public override TValue GetValue<TValue>()
		{
			object obj = Target;
			if (obj == null)
			{
				return default(TValue);
			}
			if (!typeof(TValue).IsAssignableFrom(itemInfo.ValueType))
			{
				throw new InvalidCastException();
			}
			if (itemInfo is IProxyItemInfo<TKey, TValue> proxyItemInfo)
			{
				return proxyItemInfo.GetValue(obj, key);
			}
			return (TValue)itemInfo.GetValue(obj, key);
		}

		public override void SetValue(object value)
		{
			object obj = Target;
			if (obj != null)
			{
				itemInfo.SetValue(obj, key, value);
			}
		}

		public override void SetValue<TValue>(TValue value)
		{
			object obj = Target;
			if (obj != null)
			{
				if (itemInfo is IProxyItemInfo<TKey, TValue> proxyItemInfo)
				{
					proxyItemInfo.SetValue(obj, key, value);
				}
				else
				{
					itemInfo.SetValue(obj, key, value);
				}
			}
		}
	}
}

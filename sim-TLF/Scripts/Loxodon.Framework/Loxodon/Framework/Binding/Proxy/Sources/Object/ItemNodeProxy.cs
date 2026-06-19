using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Loxodon.Framework.Binding.Reflection;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public abstract class ItemNodeProxy<TKey> : NotifiableSourceProxyBase, IObtainable, IModifiable, INotifiable
	{
		protected TKey key;

		protected IProxyItemInfo itemInfo;

		protected bool isList;

		protected Regex regex;

		private bool disposedValue;

		public override Type Type => itemInfo.ValueType;

		public override TypeCode TypeCode => itemInfo.ValueTypeCode;

		public ItemNodeProxy(ICollection source, TKey key, IProxyItemInfo itemInfo)
			: base(source)
		{
			this.key = key;
			isList = source is IList;
			this.itemInfo = itemInfo;
			if (base.source != null && base.source is INotifyCollectionChanged)
			{
				(base.source as INotifyCollectionChanged).CollectionChanged += OnCollectionChanged;
			}
			if (!isList)
			{
				TKey val = this.key;
				regex = new Regex("\\[" + val?.ToString() + ",", RegexOptions.IgnorePatternWhitespace);
			}
		}

		protected abstract void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e);

		public virtual object GetValue()
		{
			return itemInfo.GetValue(source, key);
		}

		public virtual TValue GetValue<TValue>()
		{
			if (!typeof(TValue).IsAssignableFrom(itemInfo.ValueType))
			{
				throw new InvalidCastException();
			}
			if (itemInfo is IProxyItemInfo<TKey, TValue> proxyItemInfo)
			{
				return proxyItemInfo.GetValue(source, key);
			}
			return (TValue)itemInfo.GetValue(source, key);
		}

		public virtual void SetValue(object value)
		{
			itemInfo.SetValue(source, key, value);
		}

		public virtual void SetValue<TValue>(TValue value)
		{
			if (itemInfo is IProxyItemInfo<TKey, TValue> proxyItemInfo)
			{
				proxyItemInfo.SetValue(source, key, value);
			}
			else
			{
				itemInfo.SetValue(source, key, value);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (source != null && source is INotifyCollectionChanged)
				{
					(source as INotifyCollectionChanged).CollectionChanged -= OnCollectionChanged;
				}
				disposedValue = true;
				base.Dispose(disposing);
			}
		}
	}
}

using System;
using System.ComponentModel;
using Loxodon.Framework.Binding.Reflection;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public class PropertyNodeProxy : NotifiableSourceProxyBase, IObtainable, IModifiable, INotifiable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(PropertyNodeProxy));

		protected IProxyPropertyInfo propertyInfo;

		private bool disposedValue;

		public override Type Type => propertyInfo.ValueType;

		public override TypeCode TypeCode => propertyInfo.ValueTypeCode;

		public PropertyNodeProxy(IProxyPropertyInfo propertyInfo)
			: this(null, propertyInfo)
		{
		}

		public PropertyNodeProxy(object source, IProxyPropertyInfo propertyInfo)
			: base(source)
		{
			this.propertyInfo = propertyInfo;
			if (base.source != null)
			{
				if (base.source is INotifyPropertyChanged)
				{
					(base.source as INotifyPropertyChanged).PropertyChanged += OnPropertyChanged;
				}
				else if (log.IsWarnEnabled)
				{
					log.WarnFormat("The type {0} does not inherit the INotifyPropertyChanged interface and does not support the PropertyChanged event.", propertyInfo.DeclaringType.Name);
				}
			}
		}

		protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (string.IsNullOrEmpty(propertyName) || propertyName.Equals(propertyInfo.Name))
			{
				RaiseValueChanged();
			}
		}

		public virtual object GetValue()
		{
			return propertyInfo.GetValue(source);
		}

		public virtual TValue GetValue<TValue>()
		{
			if (propertyInfo is IProxyPropertyInfo<TValue> proxyPropertyInfo)
			{
				return proxyPropertyInfo.GetValue(source);
			}
			return (TValue)propertyInfo.GetValue(source);
		}

		public virtual void SetValue(object value)
		{
			propertyInfo.SetValue(source, value);
		}

		public virtual void SetValue<TValue>(TValue value)
		{
			if (propertyInfo is IProxyPropertyInfo<TValue> proxyPropertyInfo)
			{
				proxyPropertyInfo.SetValue(source, value);
			}
			else
			{
				propertyInfo.SetValue(source, value);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (source != null && source is INotifyPropertyChanged)
				{
					(source as INotifyPropertyChanged).PropertyChanged -= OnPropertyChanged;
				}
				disposedValue = true;
				base.Dispose(disposing);
			}
		}
	}
}

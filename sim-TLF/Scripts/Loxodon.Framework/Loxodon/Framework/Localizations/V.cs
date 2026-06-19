using System;
using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Localizations
{
	public class V<T> : IObservableProperty<T>, IObservableProperty
	{
		private readonly object _lock = new object();

		private EventHandler valueChanged;

		private string key;

		private IObservableProperty property;

		public virtual Type Type => typeof(T);

		protected IObservableProperty Property
		{
			get
			{
				if (property != null)
				{
					return property;
				}
				lock (this)
				{
					if (property == null)
					{
						property = Localization.Current.GetValue(key);
						property.ValueChanged += OnValueChanged;
					}
					return property;
				}
			}
		}

		public T Value
		{
			get
			{
				if (Property is IObservableProperty<T> observableProperty)
				{
					return observableProperty.Value;
				}
				return (T)Property.Value;
			}
			set
			{
				if (Property is IObservableProperty<T> observableProperty)
				{
					observableProperty.Value = value;
				}
				else
				{
					Property.Value = value;
				}
			}
		}

		object IObservableProperty.Value
		{
			get
			{
				return Value;
			}
			set
			{
				Value = (T)value;
			}
		}

		public event EventHandler ValueChanged
		{
			add
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Combine(valueChanged, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					valueChanged = (EventHandler)Delegate.Remove(valueChanged, value);
				}
			}
		}

		public V(string key)
		{
			this.key = key;
		}

		private void OnValueChanged(object sender, EventArgs e)
		{
			RaiseValueChanged();
		}

		protected void RaiseValueChanged()
		{
			valueChanged?.Invoke(this, EventArgs.Empty);
		}

		public static implicit operator T(V<T> data)
		{
			return data.Value;
		}

		public override string ToString()
		{
			T value = Value;
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}
	}
}

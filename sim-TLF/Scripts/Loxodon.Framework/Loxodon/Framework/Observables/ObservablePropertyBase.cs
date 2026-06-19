using System;
using System.Collections.Generic;

namespace Loxodon.Framework.Observables
{
	[Serializable]
	public abstract class ObservablePropertyBase<T>
	{
		private readonly object _lock = new object();

		private EventHandler valueChanged;

		protected T _value;

		public virtual Type Type => typeof(T);

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

		public ObservablePropertyBase()
			: this(default(T))
		{
		}

		public ObservablePropertyBase(T value)
		{
			_value = value;
		}

		protected void RaiseValueChanged()
		{
			valueChanged?.Invoke(this, EventArgs.Empty);
		}

		protected virtual bool Equals(T x, T y)
		{
			return EqualityComparer<T>.Default.Equals(x, y);
		}
	}
}

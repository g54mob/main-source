using System;
using System.Collections.Generic;

namespace Kamgam.SettingsGenerator
{
	public abstract class Connection<TValue> : IConnection<TValue>, IConnection, IQualityChangeReceiver
	{
		protected List<Action<TValue>> _onChangedListeners;

		protected TValue lastKnownValue;

		public int Order;

		public event Action<int> QualityChanged;

		public abstract TValue Get();

		public virtual TValue GetDefault()
		{
			return Get();
		}

		public virtual int GetOrder()
		{
			return Order;
		}

		public virtual void SetOrder(int order)
		{
			Order = order;
		}

		public abstract void Set(TValue value);

		public virtual void NotifyListenersIfChanged(TValue value)
		{
			if (value.Equals(lastKnownValue))
			{
				return;
			}
			lastKnownValue = value;
			if (_onChangedListeners == null)
			{
				return;
			}
			foreach (Action<TValue> onChangedListener in _onChangedListeners)
			{
				onChangedListener?.Invoke(value);
			}
		}

		public void AddChangeListener(Action<TValue> listener)
		{
			if (_onChangedListeners == null)
			{
				_onChangedListeners = new List<Action<TValue>>();
			}
			if (!_onChangedListeners.Contains(listener))
			{
				_onChangedListeners.Add(listener);
			}
		}

		public void RemoveChangeListener(Action<TValue> listener)
		{
			if (_onChangedListeners != null)
			{
				_onChangedListeners.Remove(listener);
			}
		}

		public virtual void OnQualityChanged(int qualityLevel)
		{
			this.QualityChanged?.Invoke(qualityLevel);
		}

		public virtual void Destroy()
		{
		}
	}
}

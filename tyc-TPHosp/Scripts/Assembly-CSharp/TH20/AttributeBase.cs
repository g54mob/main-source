using System;
using System.Collections.Generic;

namespace TH20
{
	public abstract class AttributeBase<T>
	{
		private class CompareCallback
		{
			public Action _callback;

			public T _value;

			public bool _valid;
		}

		protected const int EQ = 0;

		protected const int LT = -1;

		protected const int GT = 1;

		protected T _value;

		protected T _lastValue;

		protected T _min;

		protected T _max;

		[DontSave]
		private List<Action<T>> _changedCallbacks;

		[DontSave]
		private List<CompareCallback> _equalsCallbacks;

		[DontSave]
		private List<CompareCallback> _greaterThanCallbacks;

		[DontSave]
		private List<CompareCallback> _lessThanCallbacks;

		protected AttributeBase(T initialValue, T minValue, T maxValue)
		{
			_value = initialValue;
			_lastValue = initialValue;
			_min = minValue;
			_max = maxValue;
		}

		public T Value()
		{
			return _value;
		}

		public T LastValue()
		{
			return _lastValue;
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public void Destroy()
		{
			if (_changedCallbacks != null)
			{
				_changedCallbacks.Clear();
			}
			if (_equalsCallbacks != null)
			{
				_equalsCallbacks.Clear();
			}
			if (_greaterThanCallbacks != null)
			{
				_greaterThanCallbacks.Clear();
			}
			if (_lessThanCallbacks != null)
			{
				_lessThanCallbacks.Clear();
			}
		}

		public void SetValue(T newValue, bool callCallbacks)
		{
			_lastValue = _value;
			_value = newValue;
			if (callCallbacks)
			{
				ref T lastValue = ref _lastValue;
				object obj = _value;
				if (!lastValue.Equals(obj))
				{
					CheckCallbacks();
				}
			}
		}

		public void Changed(Action<T> callback)
		{
			if (_changedCallbacks == null)
			{
				_changedCallbacks = new List<Action<T>>();
			}
			_changedCallbacks.Add(callback);
		}

		public void Equals(T value, Action callback, bool checkCallback)
		{
			AddCallback(ref _equalsCallbacks, value, callback, 0, checkCallback);
		}

		public void LessThan(T value, Action callback, bool checkCallback)
		{
			AddCallback(ref _lessThanCallbacks, value, callback, -1, checkCallback);
		}

		public void GreaterThan(T value, Action callback, bool checkCallback)
		{
			AddCallback(ref _greaterThanCallbacks, value, callback, 1, checkCallback);
		}

		private void AddCallback(ref List<CompareCallback> callbacks, T value, Action callback, int compareType, bool checkCallback)
		{
			if (callbacks == null)
			{
				callbacks = new List<CompareCallback>();
			}
			bool flag = CompareValues(_value, value) == compareType;
			callbacks.Add(new CompareCallback
			{
				_callback = callback,
				_value = value,
				_valid = flag
			});
			if (flag && checkCallback)
			{
				callback.InvokeSafe();
			}
		}

		public void RemoveCallback(Action callback)
		{
			RemoveCallback(_equalsCallbacks, callback);
			RemoveCallback(_lessThanCallbacks, callback);
			RemoveCallback(_greaterThanCallbacks, callback);
		}

		public void ResetCallbackStatus()
		{
			ResetCallbacks(_equalsCallbacks, 0);
			ResetCallbacks(_lessThanCallbacks, -1);
			ResetCallbacks(_greaterThanCallbacks, 1);
		}

		private void ResetCallbacks(List<CompareCallback> callbacks, int gt)
		{
			if (callbacks != null)
			{
				for (int i = 0; i < callbacks.Count; i++)
				{
					callbacks[i]._valid = false;
				}
			}
		}

		public void RemoveCallback(Action<T> callback)
		{
			if (_changedCallbacks == null)
			{
				return;
			}
			for (int i = 0; i < _changedCallbacks.Count; i++)
			{
				if (_changedCallbacks[i] == callback)
				{
					_changedCallbacks.RemoveAt(i);
					break;
				}
			}
		}

		private void RemoveCallback(IList<CompareCallback> callbacks, Action callback)
		{
			if (callbacks == null)
			{
				return;
			}
			for (int i = 0; i < callbacks.Count; i++)
			{
				if (callbacks[i]._callback == callback)
				{
					callbacks.RemoveAt(i);
					break;
				}
			}
		}

		protected void CheckCallbacks()
		{
			if (_changedCallbacks != null)
			{
				for (int num = _changedCallbacks.Count - 1; num >= 0; num--)
				{
					_changedCallbacks[num].InvokeSafe(Value());
				}
			}
			CheckCallbacks(_equalsCallbacks, 0);
			CheckCallbacks(_lessThanCallbacks, -1);
			CheckCallbacks(_greaterThanCallbacks, 1);
		}

		private void CheckCallbacks(IList<CompareCallback> callbacks, int compareType)
		{
			if (callbacks == null)
			{
				return;
			}
			for (int num = callbacks.Count - 1; num >= 0; num--)
			{
				if (num < callbacks.Count)
				{
					CompareCallback compareCallback = callbacks[num];
					bool flag = CompareValues(_value, compareCallback._value) == compareType;
					if (flag && !compareCallback._valid)
					{
						compareCallback._callback.InvokeSafe();
					}
					compareCallback._valid = flag;
				}
			}
		}

		protected abstract int CompareValues(T lhs, T rhs);
	}
}

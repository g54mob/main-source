using System;
using System.Collections.Generic;

namespace DV.Utils
{
	public class CustomRequestSystem<T> where T : IComparable<T>
	{
		private struct Request
		{
			public int priority;

			public T value;
		}

		private Dictionary<object, Request> requests = new Dictionary<object, Request>();

		private HashSet<object> blockers = new HashSet<object>();

		private T defaultValue;

		private bool higherValueFirst;

		private bool ignorePriority;

		public T Value { get; private set; }

		public bool IsBlocked => blockers.Count > 0;

		public int RequestCount => requests.Count;

		public bool HasRequests => RequestCount > 0;

		public event Action<T> ValueChanged;

		public CustomRequestSystem(T defaultValue = default(T), bool higherValueFirst = true, bool ignorePriority = false)
		{
			this.defaultValue = defaultValue;
			this.higherValueFirst = higherValueFirst;
			this.ignorePriority = ignorePriority;
			Refresh();
		}

		public void RequestValue(object caller, T value, int priority = 0)
		{
			if (!IsBlocked)
			{
				requests[caller] = new Request
				{
					value = value,
					priority = priority
				};
				Refresh();
			}
		}

		public void RemoveValue(object caller)
		{
			if (!IsBlocked)
			{
				requests.Remove(caller);
				Refresh();
			}
		}

		public void ClearValueRequests()
		{
			requests.Clear();
			Refresh();
		}

		public void RequestBlock(object caller)
		{
			blockers.Add(caller);
		}

		public void RemoveBlock(object caller)
		{
			blockers.Remove(caller);
		}

		public void SetDefaultValue(T value)
		{
			if (!IsBlocked)
			{
				defaultValue = value;
				Refresh();
			}
		}

		public T GetDefaultValue()
		{
			return defaultValue;
		}

		public void ClearEventListeners()
		{
			this.ValueChanged = null;
		}

		private void Refresh()
		{
			int num = int.MinValue;
			T val = defaultValue;
			foreach (KeyValuePair<object, Request> request in requests)
			{
				if (request.Key == null)
				{
					continue;
				}
				T value = request.Value.value;
				int priority = request.Value.priority;
				if (ignorePriority || priority == num)
				{
					int num2 = val.CompareTo(value);
					if (num2 != 0)
					{
						if (higherValueFirst)
						{
							num2 *= -1;
						}
						val = ((num2 < 0) ? val : value);
					}
				}
				else if (priority > num)
				{
					val = value;
					num = priority;
				}
			}
			if ((Value != null || val != null) && ((Value == null && val != null) || !Value.Equals(val)))
			{
				Value = val;
				this.ValueChanged?.Invoke(Value);
			}
		}
	}
}

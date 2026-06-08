using System;

namespace HandlebarsDotNet.Runtime
{
	public sealed class GcDeferredValue<TState, T> where T : class
	{
		private readonly TState _state;

		private readonly Func<TState, T> _factory;

		private WeakReference<T> _value;

		private bool _isValueCreated;

		public T Value
		{
			get
			{
				T target;
				if (_isValueCreated)
				{
					if (_value.TryGetTarget(out target))
					{
						return target;
					}
					target = _factory(_state);
					_value.SetTarget(target);
				}
				else
				{
					target = _factory(_state);
					_value = new WeakReference<T>(target);
					_isValueCreated = true;
				}
				return target;
			}
		}

		public GcDeferredValue(TState state, Func<TState, T> factory)
		{
			_state = state;
			_factory = factory;
		}

		public override string ToString()
		{
			if (!_isValueCreated)
			{
				return "Not yet created";
			}
			if (!_value.TryGetTarget(out var target))
			{
				return "GC collected";
			}
			return target.ToString();
		}
	}
}

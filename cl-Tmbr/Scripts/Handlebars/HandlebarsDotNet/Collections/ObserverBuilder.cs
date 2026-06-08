using System;
using System.Collections.Generic;

namespace HandlebarsDotNet.Collections
{
	internal static class ObserverBuilder<T>
	{
		public static ObserverBuilder<T, TState> Create<TState>(TState state)
		{
			return new ObserverBuilder<T, TState>(state);
		}
	}
	internal class ObserverBuilder<T, TState>
	{
		private class Observer : IObserver<T>
		{
			private readonly Dictionary<Type, List<Action<T>>> _handlers;

			public Observer(Dictionary<Type, List<Action<T>>> handlers)
			{
				_handlers = handlers;
			}

			public void OnCompleted()
			{
			}

			public void OnError(Exception error)
			{
			}

			public void OnNext(T value)
			{
				if (_handlers.TryGetValue(value.GetType(), out var value2))
				{
					for (int i = 0; i < value2.Count; i++)
					{
						value2[i](value);
					}
				}
			}
		}

		private readonly TState _state;

		private readonly Dictionary<Type, List<Action<T>>> _handlers = new Dictionary<Type, List<Action<T>>>();

		public ObserverBuilder(TState state)
		{
			_state = state;
		}

		public ObserverBuilder<T, TState> OnEvent<TEvent>(Action<TEvent, TState> handler, Func<TEvent, bool> predicate = null) where TEvent : T
		{
			if (!_handlers.TryGetValue(typeof(TEvent), out var value))
			{
				value = new List<Action<T>>();
				_handlers.Add(typeof(TEvent), value);
			}
			value.Add(delegate(T @event)
			{
				Func<TEvent, bool> func = predicate;
				if (func == null || func((TEvent)(object)@event))
				{
					handler((TEvent)(object)@event, _state);
				}
			});
			return this;
		}

		public IObserver<T> Build()
		{
			return new Observer(_handlers);
		}
	}
}

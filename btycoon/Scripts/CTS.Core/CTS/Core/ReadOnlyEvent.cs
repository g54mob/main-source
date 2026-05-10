using System;

namespace CTS.Core
{
	public readonly struct ReadOnlyEvent
	{
		private readonly CTSEvent _event;

		public int Count => _event.Count;

		public ReadOnlyEvent(CTSEvent @event)
		{
			_event = @event;
		}

		public static implicit operator ReadOnlyEvent(CTSEvent @event)
		{
			return new ReadOnlyEvent(@event);
		}

		public void AddListener(Action action)
		{
			_event.AddListener(action);
		}

		public void RemoveListener(Action action)
		{
			_event.RemoveListener(action);
		}
	}
	public readonly struct ReadOnlyEvent<TArg>
	{
		private readonly CTSEvent<TArg> _event;

		public int Count => _event.Count;

		public ReadOnlyEvent(CTSEvent<TArg> @event)
		{
			_event = @event;
		}

		public static implicit operator ReadOnlyEvent<TArg>(CTSEvent<TArg> @event)
		{
			return new ReadOnlyEvent<TArg>(@event);
		}

		public void AddListener(Action<TArg> action)
		{
			_event.AddListener(action);
		}

		public void RemoveListener(Action<TArg> action)
		{
			_event.RemoveListener(action);
		}
	}
}

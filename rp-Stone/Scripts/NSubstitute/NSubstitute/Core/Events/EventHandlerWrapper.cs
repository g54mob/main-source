using System;

namespace NSubstitute.Core.Events
{
	public class EventHandlerWrapper<TEventArgs> : RaiseEventWrapper where TEventArgs : EventArgs
	{
		private readonly object? _sender;

		private readonly EventArgs? _eventArgs;

		protected override string RaiseMethodName => "Raise.EventWith";

		public EventHandlerWrapper()
			: this((object?)null, (EventArgs?)null)
		{
		}

		public EventHandlerWrapper(EventArgs? eventArgs)
			: this((object?)null, eventArgs)
		{
		}

		public EventHandlerWrapper(object? sender, EventArgs? eventArgs)
		{
			_sender = sender;
			_eventArgs = eventArgs;
		}

		public static implicit operator EventHandler(EventHandlerWrapper<TEventArgs> wrapper)
		{
			RaiseEventWrapper.RaiseEvent(wrapper);
			return null;
		}

		public static implicit operator EventHandler<TEventArgs>(EventHandlerWrapper<TEventArgs> wrapper)
		{
			RaiseEventWrapper.RaiseEvent(wrapper);
			return null;
		}

		protected override object[] WorkOutRequiredArguments(ICall call)
		{
			object obj = _sender ?? call.Target();
			EventArgs e = _eventArgs ?? GetDefaultForEventArgType(typeof(TEventArgs));
			return new object[2] { obj, e };
		}
	}
}

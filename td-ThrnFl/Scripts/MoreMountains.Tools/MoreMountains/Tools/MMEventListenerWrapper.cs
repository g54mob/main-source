using System;

namespace MoreMountains.Tools
{
	public class MMEventListenerWrapper<TOwner, TTarget, TEvent> : MMEventListener<TEvent>, MMEventListenerBase, IDisposable where TEvent : struct
	{
		private Action<TTarget> _callback;

		private TOwner _owner;

		public MMEventListenerWrapper(TOwner owner, Action<TTarget> callback)
		{
			_owner = owner;
			_callback = callback;
			RegisterCallbacks(b: true);
		}

		public void Dispose()
		{
			RegisterCallbacks(b: false);
			_callback = null;
		}

		protected virtual TTarget OnEvent(TEvent eventType)
		{
			return default(TTarget);
		}

		public void OnMMEvent(TEvent eventType)
		{
			TTarget obj = OnEvent(eventType);
			_callback?.Invoke(obj);
		}

		private void RegisterCallbacks(bool b)
		{
			if (b)
			{
				this.MMEventStartListening();
			}
			else
			{
				this.MMEventStopListening();
			}
		}
	}
}

using System;
using TwitchSDK.Interop;

namespace TwitchSDK
{
	public class EventStream<T> : BaseDisposable
	{
		private readonly EventStreamDesc Desc;

		private readonly CoreLibrary Core;

		private readonly Func<EventStreamDesc, GameTask<T>> WaitFn;

		private GameTask<T> TryGetNextEventTask;

		internal EventStream(EventStreamDesc desc, CoreLibrary core, Func<EventStreamDesc, GameTask<T>> waitFn)
		{
			Desc = desc;
			Core = core;
			WaitFn = waitFn;
		}

		public GameTask<T> WaitForEvent()
		{
			return WaitFn(Desc);
		}

		public bool TryGetNextEvent(out T result)
		{
			if (TryGetNextEventTask == null)
			{
				TryGetNextEventTask = WaitForEvent();
			}
			if (TryGetNextEventTask.IsCompleted)
			{
				_ = TryGetNextEventTask;
				result = TryGetNextEventTask.MaybeResult;
				TryGetNextEventTask = null;
				return true;
			}
			result = default(T);
			return false;
		}

		protected override void DisposeUnmanaged()
		{
			try
			{
				Core.CloseEventStream(Desc);
			}
			catch
			{
			}
		}
	}
}

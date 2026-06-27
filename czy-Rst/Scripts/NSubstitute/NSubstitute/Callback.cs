using System;
using System.Collections.Concurrent;
using NSubstitute.Callbacks;
using NSubstitute.Core;

namespace NSubstitute
{
	public class Callback
	{
		private readonly ConcurrentQueue<Action<CallInfo>> callbackQueue = new ConcurrentQueue<Action<CallInfo>>();

		private Action<CallInfo> alwaysDo = delegate
		{
		};

		private Action<CallInfo> keepDoing = delegate
		{
		};

		public static ConfiguredCallback First(Action<CallInfo> doThis)
		{
			return new ConfiguredCallback().Then(doThis);
		}

		public static Callback Always(Action<CallInfo> doThis)
		{
			return new ConfiguredCallback().AndAlways(doThis);
		}

		public static ConfiguredCallback FirstThrow<TException>(Func<CallInfo, TException> throwThis) where TException : Exception
		{
			return new ConfiguredCallback().ThenThrow(throwThis);
		}

		public static ConfiguredCallback FirstThrow<TException>(TException exception) where TException : Exception
		{
			return new ConfiguredCallback().ThenThrow((CallInfo info) => exception);
		}

		public static Callback AlwaysThrow<TException>(Func<CallInfo, TException> throwThis) where TException : Exception
		{
			return new ConfiguredCallback().AndAlways(ToCallback(throwThis));
		}

		public static Callback AlwaysThrow<TException>(TException exception) where TException : Exception
		{
			return AlwaysThrow((CallInfo _) => exception);
		}

		protected static Action<CallInfo> ToCallback<TException>(Func<CallInfo, TException> throwThis) where TException : notnull, Exception
		{
			return delegate(CallInfo ci)
			{
				if (throwThis != null)
				{
					throw throwThis(ci);
				}
			};
		}

		internal Callback()
		{
		}

		protected void AddCallback(Action<CallInfo> doThis)
		{
			callbackQueue.Enqueue(doThis);
		}

		protected void SetAlwaysDo(Action<CallInfo> always)
		{
			alwaysDo = always ?? ((Action<CallInfo>)delegate
			{
			});
		}

		protected void SetKeepDoing(Action<CallInfo> keep)
		{
			keepDoing = keep ?? ((Action<CallInfo>)delegate
			{
			});
		}

		public void Call(CallInfo callInfo)
		{
			try
			{
				CallFromStack(callInfo);
			}
			finally
			{
				alwaysDo(callInfo);
			}
		}

		private void CallFromStack(CallInfo callInfo)
		{
			if (callbackQueue.TryDequeue(out var result))
			{
				result(callInfo);
			}
			else
			{
				keepDoing(callInfo);
			}
		}
	}
}

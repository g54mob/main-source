using System;
using NSubstitute.Core;

namespace NSubstitute.Callbacks
{
	public class ConfiguredCallback : EndCallbackChain
	{
		internal ConfiguredCallback()
		{
		}

		public ConfiguredCallback Then(Action<CallInfo> doThis)
		{
			AddCallback(doThis);
			return this;
		}

		public EndCallbackChain ThenKeepDoing(Action<CallInfo> doThis)
		{
			SetKeepDoing(doThis);
			return this;
		}

		public EndCallbackChain ThenKeepThrowing<TException>(Func<CallInfo, TException> throwThis) where TException : Exception
		{
			return ThenKeepDoing(Callback.ToCallback(throwThis));
		}

		public EndCallbackChain ThenKeepThrowing<TException>(TException throwThis) where TException : Exception
		{
			return ThenKeepThrowing((CallInfo info) => throwThis);
		}

		public ConfiguredCallback ThenThrow<TException>(Func<CallInfo, TException> throwThis) where TException : Exception
		{
			AddCallback(Callback.ToCallback(throwThis));
			return this;
		}

		public ConfiguredCallback ThenThrow<TException>(TException exception) where TException : Exception
		{
			return ThenThrow((CallInfo _) => exception);
		}
	}
}

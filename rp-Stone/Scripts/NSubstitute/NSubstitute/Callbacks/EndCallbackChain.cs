using System;
using NSubstitute.Core;

namespace NSubstitute.Callbacks
{
	public class EndCallbackChain : Callback
	{
		internal EndCallbackChain()
		{
		}

		public Callback AndAlways(Action<CallInfo> doThis)
		{
			SetAlwaysDo(doThis);
			return this;
		}
	}
}

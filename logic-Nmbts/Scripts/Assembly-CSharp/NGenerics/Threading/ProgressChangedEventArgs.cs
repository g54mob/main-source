using System;
using System.ComponentModel;

namespace NGenerics.Threading
{
	public class ProgressChangedEventArgs<TState> : EventArgs
	{
		[Description("Async_ProgressChangedEventArgs_ProgressPercentage")]
		public int ProgressPercentage { get; private set; }

		[Description("Async_ProgressChangedEventArgs_UserState")]
		public TState UserState { get; private set; }

		public ProgressChangedEventArgs(int progressPercentage, TState userState)
		{
			ProgressPercentage = progressPercentage;
			UserState = userState;
		}
	}
}

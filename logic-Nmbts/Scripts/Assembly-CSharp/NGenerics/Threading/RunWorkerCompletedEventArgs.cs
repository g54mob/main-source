using System;
using System.ComponentModel;

namespace NGenerics.Threading
{
	public class RunWorkerCompletedEventArgs<TState> : AsyncCompletedEventArgs<TState>
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override TState UserState
		{
			get
			{
				RaiseExceptionIfNecessary();
				return base.UserState;
			}
		}

		public RunWorkerCompletedEventArgs(TState result, Exception error, bool cancelled)
			: base(error, cancelled, result)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FuryStudios.FurySDK.Internal
{
	public class AsyncRequestScheduler
	{
		public delegate void RequestEventHandler(IAsyncRequest request);

		protected Queue<IAsyncRequest> requestQueue;

		[CompilerGenerated]
		private RequestEventHandler OnRequestScheduled;

		[CompilerGenerated]
		private RequestEventHandler OnRequestStarted;

		[CompilerGenerated]
		private RequestEventHandler OnRequestCompleted;

		[CompilerGenerated]
		private Action OnQueueCompleted;

		public void Update()
		{
		}

		public void Schedule(IAsyncRequest request)
		{
		}

		public void AbortAll()
		{
		}
	}
}

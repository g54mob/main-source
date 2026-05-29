using System;
using System.Collections.Generic;

namespace FuryStudios.FurySDK.Internal
{
	public class AsyncRequestChain : AsyncRequest
	{
		private Queue<IAsyncRequest> childRequests;

		private bool failed;

		private Exception error;

		public override AsyncRequestChain Continue(IAsyncRequest request)
		{
			return null;
		}

		protected override void OnUpdate()
		{
		}
	}
}

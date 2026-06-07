using System;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Cloud.Coroutines
{
	public class WaitForRequestResponse<TResult> : CustomYieldInstruction
	{
		public Coherence.Log.Logger logger;

		private bool done;

		public RequestResponse<TResult> RequestResponse { get; private set; }

		public override bool keepWaiting => false;

		private void OnComplete(RequestResponse<TResult> requestResponse)
		{
		}

		public WaitForRequestResponse(Action<Action<RequestResponse<TResult>>> fn)
		{
		}
	}
}

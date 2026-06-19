using Steamworks;
using UnityEngine;

namespace TH20
{
	public class WaitForCallResult<T> : CustomYieldInstruction
	{
		public T Result;

		public bool IoFailure;

		private bool _receivedCallback;

		private CallResult<T> _callResult;

		public override bool keepWaiting => !_receivedCallback;

		public WaitForCallResult(SteamAPICall_t callback)
		{
			_callResult = new CallResult<T>();
			_callResult.Set(callback, OnCompleted);
		}

		public WaitForCallResult<T> WaitForResult()
		{
			return this;
		}

		private void OnCompleted(T result, bool iofailure)
		{
			Result = result;
			IoFailure = iofailure;
			_receivedCallback = true;
		}
	}
}

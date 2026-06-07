using System.Collections;
using System.Diagnostics;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	public class SteamCallbackCoroutine<T>
	{
		public T Result;

		public bool HasResult;

		private bool _hasArrived;

		private readonly CallResult<T> _callBack;

		public SteamCallbackCoroutine()
		{
			_callBack = CallResult<T>.Create(CallbackReturned);
			_hasArrived = false;
			HasResult = false;
		}

		public IEnumerator Start(SteamAPICall_t handle, float timeOut)
		{
			if (SteamManager.Connected)
			{
				HasResult = false;
				_hasArrived = false;
				_callBack.Set(handle);
				Stopwatch timeoutWatch = new Stopwatch();
				timeoutWatch.Start();
				while (!_hasArrived)
				{
					yield return true;
					if ((float)timeoutWatch.ElapsedMilliseconds > timeOut * 1000f)
					{
						timeoutWatch.Stop();
						_callBack.Cancel();
						HasResult = false;
						UnityEngine.Debug.LogError("Callback  timed out");
						break;
					}
				}
			}
			else
			{
				HasResult = false;
			}
		}

		private void CallbackReturned(T result, bool failure)
		{
			if (failure)
			{
				UnityEngine.Debug.LogError("Callback returned with failure");
			}
			Result = result;
			HasResult = !failure;
			_hasArrived = true;
		}
	}
}

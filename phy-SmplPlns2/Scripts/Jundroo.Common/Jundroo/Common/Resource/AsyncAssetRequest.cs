using System.Collections;
using UnityEngine;

namespace Jundroo.Common.Resource
{
	public abstract class AsyncAssetRequest<T> where T : Object
	{
		public T Asset { get; private set; }

		public bool CancellationRequested { get; private set; }

		public Coroutine Coroutine { get; private set; }

		public bool IsDone { get; private set; }

		protected AsyncAssetRequest(AsyncOperation asyncOperation)
		{
			Coroutine = AsyncAssetRequest.GetManager().StartCoroutine(AsyncLoad(asyncOperation));
		}

		public static implicit operator Coroutine(AsyncAssetRequest<T> request)
		{
			return request?.Coroutine;
		}

		public void RequestCancellation()
		{
			CancellationRequested = true;
		}

		protected abstract T LoadComplete();

		private IEnumerator AsyncLoad(AsyncOperation asyncOperation)
		{
			yield return asyncOperation;
			Asset = LoadComplete();
			IsDone = true;
			Coroutine = null;
		}
	}
	internal static class AsyncAssetRequest
	{
		private class AsyncAssetRequestManager : MonoBehaviour
		{
		}

		private static AsyncAssetRequestManager _manager;

		public static MonoBehaviour GetManager()
		{
			if (_manager == null)
			{
				_manager = new GameObject("AsyncAssetRequestManager").AddComponent<AsyncAssetRequestManager>();
				Object.DontDestroyOnLoad(_manager);
			}
			return _manager;
		}
	}
}

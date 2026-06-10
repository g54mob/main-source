using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace Cysharp.Threading.Tasks
{
	public static class UnityAsyncExtensions
	{
		public struct UnityWebRequestAsyncOperationAwaiter : ICriticalNotifyCompletion
		{
			private UnityWebRequestAsyncOperation asyncOperation;

			private Action<AsyncOperation> continuationAction;

			public bool IsCompleted => false;

			public UnityWebRequestAsyncOperationAwaiter(UnityWebRequestAsyncOperation asyncOperation)
			{
				this.asyncOperation = null;
				continuationAction = null;
			}

			public UnityWebRequest GetResult()
			{
				return null;
			}

			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		public static UnityWebRequestAsyncOperationAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOperation)
		{
			return default(UnityWebRequestAsyncOperationAwaiter);
		}
	}
}

using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseDownTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseDown()
		{
		}

		public IAsyncOnMouseDownHandler GetOnMouseDownAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseDownHandler GetOnMouseDownAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseDownAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseDownAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

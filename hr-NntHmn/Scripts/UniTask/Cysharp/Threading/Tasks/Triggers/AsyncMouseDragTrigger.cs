using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseDragTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseDrag()
		{
		}

		public IAsyncOnMouseDragHandler GetOnMouseDragAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseDragHandler GetOnMouseDragAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseDragAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseDragAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

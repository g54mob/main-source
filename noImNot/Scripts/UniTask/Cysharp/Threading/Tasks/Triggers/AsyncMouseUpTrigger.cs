using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseUpTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseUp()
		{
		}

		public IAsyncOnMouseUpHandler GetOnMouseUpAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseUpHandler GetOnMouseUpAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseUpAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseUpAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

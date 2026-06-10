using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseEnterTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseEnter()
		{
		}

		public IAsyncOnMouseEnterHandler GetOnMouseEnterAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseEnterHandler GetOnMouseEnterAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseEnterAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseEnterAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

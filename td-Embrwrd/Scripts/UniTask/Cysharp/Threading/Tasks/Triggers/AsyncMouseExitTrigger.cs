using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseExitTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseExit()
		{
		}

		public IAsyncOnMouseExitHandler GetOnMouseExitAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseExitHandler GetOnMouseExitAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseExitAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseExitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

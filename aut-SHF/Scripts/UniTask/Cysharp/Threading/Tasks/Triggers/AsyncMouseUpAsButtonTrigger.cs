using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseUpAsButtonTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseUpAsButton()
		{
		}

		public IAsyncOnMouseUpAsButtonHandler GetOnMouseUpAsButtonAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseUpAsButtonHandler GetOnMouseUpAsButtonAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseUpAsButtonAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseUpAsButtonAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

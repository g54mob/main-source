using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMouseOverTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private void OnMouseOver()
		{
		}

		public IAsyncOnMouseOverHandler GetOnMouseOverAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMouseOverHandler GetOnMouseOverAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask OnMouseOverAsync()
		{
			return default(UniTask);
		}

		public UniTask OnMouseOverAsync(CancellationToken cancellationToken)
		{
			return default(UniTask);
		}
	}
}

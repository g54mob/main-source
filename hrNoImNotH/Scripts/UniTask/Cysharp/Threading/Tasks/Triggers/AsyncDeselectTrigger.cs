using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncDeselectTrigger : AsyncTriggerBase<BaseEventData>, IDeselectHandler, IEventSystemHandler
	{
		void IDeselectHandler.OnDeselect(BaseEventData eventData)
		{
		}

		public IAsyncOnDeselectHandler GetOnDeselectAsyncHandler()
		{
			return null;
		}

		public IAsyncOnDeselectHandler GetOnDeselectAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<BaseEventData> OnDeselectAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		public UniTask<BaseEventData> OnDeselectAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<BaseEventData>);
		}
	}
}

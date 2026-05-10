using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncUpdateSelectedTrigger : AsyncTriggerBase<BaseEventData>, IUpdateSelectedHandler, IEventSystemHandler
	{
		void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
		{
		}

		public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler()
		{
			return null;
		}

		public IAsyncOnUpdateSelectedHandler GetOnUpdateSelectedAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<BaseEventData> OnUpdateSelectedAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		public UniTask<BaseEventData> OnUpdateSelectedAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<BaseEventData>);
		}
	}
}

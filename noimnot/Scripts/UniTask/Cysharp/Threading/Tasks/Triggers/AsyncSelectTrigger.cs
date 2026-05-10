using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncSelectTrigger : AsyncTriggerBase<BaseEventData>, ISelectHandler, IEventSystemHandler
	{
		void ISelectHandler.OnSelect(BaseEventData eventData)
		{
		}

		public IAsyncOnSelectHandler GetOnSelectAsyncHandler()
		{
			return null;
		}

		public IAsyncOnSelectHandler GetOnSelectAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<BaseEventData> OnSelectAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		public UniTask<BaseEventData> OnSelectAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<BaseEventData>);
		}
	}
}

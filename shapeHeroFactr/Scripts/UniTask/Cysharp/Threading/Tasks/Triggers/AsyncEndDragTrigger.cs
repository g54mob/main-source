using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncEndDragTrigger : AsyncTriggerBase<PointerEventData>, IEndDragHandler, IEventSystemHandler
	{
		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		public IAsyncOnEndDragHandler GetOnEndDragAsyncHandler()
		{
			return null;
		}

		public IAsyncOnEndDragHandler GetOnEndDragAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<PointerEventData> OnEndDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		public UniTask<PointerEventData> OnEndDragAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<PointerEventData>);
		}
	}
}

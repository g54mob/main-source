using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncBeginDragTrigger : AsyncTriggerBase<PointerEventData>, IBeginDragHandler, IEventSystemHandler
	{
		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		public IAsyncOnBeginDragHandler GetOnBeginDragAsyncHandler()
		{
			return null;
		}

		public IAsyncOnBeginDragHandler GetOnBeginDragAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<PointerEventData> OnBeginDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		public UniTask<PointerEventData> OnBeginDragAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<PointerEventData>);
		}
	}
}

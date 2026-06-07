using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncInitializePotentialDragTrigger : AsyncTriggerBase<PointerEventData>, IInitializePotentialDragHandler, IEventSystemHandler
	{
		void IInitializePotentialDragHandler.OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		public IAsyncOnInitializePotentialDragHandler GetOnInitializePotentialDragAsyncHandler()
		{
			return null;
		}

		public IAsyncOnInitializePotentialDragHandler GetOnInitializePotentialDragAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<PointerEventData> OnInitializePotentialDragAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		public UniTask<PointerEventData> OnInitializePotentialDragAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<PointerEventData>);
		}
	}
}

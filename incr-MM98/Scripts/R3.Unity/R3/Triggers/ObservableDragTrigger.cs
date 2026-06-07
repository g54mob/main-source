using UnityEngine;
using UnityEngine.EventSystems;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableDragTrigger : ObservableTriggerBase, IEventSystemHandler, IDragHandler
	{
		private Subject<PointerEventData> onDrag;

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (onDrag != null)
			{
				onDrag.OnNext(eventData);
			}
		}

		public Observable<PointerEventData> OnDragAsObservable()
		{
			return onDrag ?? (onDrag = new Subject<PointerEventData>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onDrag != null)
			{
				onDrag.OnCompleted();
			}
		}
	}
}

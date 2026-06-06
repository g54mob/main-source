using UnityEngine;
using UnityEngine.EventSystems;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservablePointerUpTrigger : ObservableTriggerBase, IEventSystemHandler, IPointerUpHandler
	{
		private Subject<PointerEventData> onPointerUp;

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (onPointerUp != null)
			{
				onPointerUp.OnNext(eventData);
			}
		}

		public Observable<PointerEventData> OnPointerUpAsObservable()
		{
			return onPointerUp ?? (onPointerUp = new Subject<PointerEventData>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onPointerUp != null)
			{
				onPointerUp.OnCompleted();
			}
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniRx.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableSelectTrigger : ObservableTriggerBase, IEventSystemHandler, ISelectHandler
	{
		private Subject<BaseEventData> onSelect;

		void ISelectHandler.OnSelect(BaseEventData eventData)
		{
			if (onSelect != null)
			{
				onSelect.OnNext(eventData);
			}
		}

		public IObservable<BaseEventData> OnSelectAsObservable()
		{
			return onSelect ?? (onSelect = new Subject<BaseEventData>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onSelect != null)
			{
				onSelect.OnCompleted();
			}
		}
	}
}

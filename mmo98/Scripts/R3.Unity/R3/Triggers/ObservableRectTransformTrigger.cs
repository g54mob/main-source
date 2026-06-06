using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableRectTransformTrigger : ObservableTriggerBase
	{
		private Subject<Unit> onRectTransformDimensionsChange;

		private Subject<Unit> onRectTransformRemoved;

		private void OnRectTransformDimensionsChange()
		{
			if (onRectTransformDimensionsChange != null)
			{
				onRectTransformDimensionsChange.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> OnRectTransformDimensionsChangeAsObservable()
		{
			return onRectTransformDimensionsChange ?? (onRectTransformDimensionsChange = new Subject<Unit>());
		}

		private void OnRectTransformRemoved()
		{
			if (onRectTransformRemoved != null)
			{
				onRectTransformRemoved.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> OnRectTransformRemovedAsObservable()
		{
			return onRectTransformRemoved ?? (onRectTransformRemoved = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onRectTransformDimensionsChange != null)
			{
				onRectTransformDimensionsChange.OnCompleted();
			}
			if (onRectTransformRemoved != null)
			{
				onRectTransformRemoved.OnCompleted();
			}
		}
	}
}

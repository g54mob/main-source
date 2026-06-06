using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableCanvasGroupChangedTrigger : ObservableTriggerBase
	{
		private Subject<Unit> onCanvasGroupChanged;

		private void OnCanvasGroupChanged()
		{
			if (onCanvasGroupChanged != null)
			{
				onCanvasGroupChanged.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> OnCanvasGroupChangedAsObservable()
		{
			return onCanvasGroupChanged ?? (onCanvasGroupChanged = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onCanvasGroupChanged != null)
			{
				onCanvasGroupChanged.OnCompleted();
			}
		}
	}
}

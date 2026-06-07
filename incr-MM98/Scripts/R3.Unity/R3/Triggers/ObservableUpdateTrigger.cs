using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableUpdateTrigger : ObservableTriggerBase
	{
		private Subject<Unit> update;

		private void Update()
		{
			if (update != null)
			{
				update?.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> UpdateAsObservable()
		{
			return update ?? (update = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (update != null)
			{
				update.OnCompleted();
			}
		}
	}
}

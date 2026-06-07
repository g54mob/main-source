using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableLateUpdateTrigger : ObservableTriggerBase
	{
		private Subject<Unit> lateUpdate;

		private void LateUpdate()
		{
			if (lateUpdate != null)
			{
				lateUpdate.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> LateUpdateAsObservable()
		{
			return lateUpdate ?? (lateUpdate = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (lateUpdate != null)
			{
				lateUpdate.OnCompleted();
			}
		}
	}
}

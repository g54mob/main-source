using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableFixedUpdateTrigger : ObservableTriggerBase
	{
		private Subject<Unit> fixedUpdate;

		private void FixedUpdate()
		{
			if (fixedUpdate != null)
			{
				fixedUpdate.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> FixedUpdateAsObservable()
		{
			return fixedUpdate ?? (fixedUpdate = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (fixedUpdate != null)
			{
				fixedUpdate.OnCompleted();
			}
		}
	}
}

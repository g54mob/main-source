using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableTriggerTrigger : ObservableTriggerBase
	{
		private Subject<Collider> onTriggerEnter;

		private Subject<Collider> onTriggerExit;

		private Subject<Collider> onTriggerStay;

		private void OnTriggerEnter(Collider other)
		{
			if (onTriggerEnter != null)
			{
				onTriggerEnter.OnNext(other);
			}
		}

		public Observable<Collider> OnTriggerEnterAsObservable()
		{
			return onTriggerEnter ?? (onTriggerEnter = new Subject<Collider>());
		}

		private void OnTriggerExit(Collider other)
		{
			if (onTriggerExit != null)
			{
				onTriggerExit.OnNext(other);
			}
		}

		public Observable<Collider> OnTriggerExitAsObservable()
		{
			return onTriggerExit ?? (onTriggerExit = new Subject<Collider>());
		}

		private void OnTriggerStay(Collider other)
		{
			if (onTriggerStay != null)
			{
				onTriggerStay.OnNext(other);
			}
		}

		public Observable<Collider> OnTriggerStayAsObservable()
		{
			return onTriggerStay ?? (onTriggerStay = new Subject<Collider>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onTriggerEnter != null)
			{
				onTriggerEnter.OnCompleted();
			}
			if (onTriggerExit != null)
			{
				onTriggerExit.OnCompleted();
			}
			if (onTriggerStay != null)
			{
				onTriggerStay.OnCompleted();
			}
		}
	}
}

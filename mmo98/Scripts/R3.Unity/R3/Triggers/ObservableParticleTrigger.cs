using UnityEngine;

namespace R3.Triggers
{
	[DisallowMultipleComponent]
	public class ObservableParticleTrigger : ObservableTriggerBase
	{
		private Subject<GameObject> onParticleCollision;

		private Subject<Unit> onParticleTrigger;

		private void OnParticleCollision(GameObject other)
		{
			if (onParticleCollision != null)
			{
				onParticleCollision.OnNext(other);
			}
		}

		public Observable<GameObject> OnParticleCollisionAsObservable()
		{
			return onParticleCollision ?? (onParticleCollision = new Subject<GameObject>());
		}

		private void OnParticleTrigger()
		{
			if (onParticleTrigger != null)
			{
				onParticleTrigger.OnNext(Unit.Default);
			}
		}

		public Observable<Unit> OnParticleTriggerAsObservable()
		{
			return onParticleTrigger ?? (onParticleTrigger = new Subject<Unit>());
		}

		protected override void RaiseOnCompletedOnDestroy()
		{
			if (onParticleCollision != null)
			{
				onParticleCollision.OnCompleted();
			}
			if (onParticleTrigger != null)
			{
				onParticleTrigger.OnCompleted();
			}
		}
	}
}

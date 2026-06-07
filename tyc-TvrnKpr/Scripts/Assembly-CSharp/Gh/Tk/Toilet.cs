using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class Toilet : Prop
	{
		[PersistenceOptIn]
		public bool isDoorOpen;

		public Transform toiletDoor;

		public Vector3 anglesToClose;

		private Tween _doorTween;

		public Actor ActorUsingToilet => null;

		public override void Start()
		{
		}

		public override float RateDesirability(Actor actor, ActorBehaviour behaviour)
		{
			return 0f;
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}

		public override void OnDestroy()
		{
		}
	}
}

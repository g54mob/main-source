using UnityEngine;

namespace Gh.Tk
{
	public class PropStatusObserver : MonoBehaviour
	{
		private enum AbortReason
		{
			PropBroken = 0,
			PropOnFire = 1,
			PropNeedsMaintenance = 2,
			PropIsInWrongZone = 3
		}

		private void Start()
		{
		}

		private static void OnActorArrived(object sender, Actor.ActorEventArgs<Prop> e)
		{
		}

		private static void OnActorNearlyArrivedAtProp(object sender, Actor.ActorEventArgs<Prop> e)
		{
		}

		private static void CheckProp(Prop prop, Actor actor)
		{
		}

		private static void AbortJobs(Prop prop, AbortReason reason, Actor actor = null)
		{
		}

		private static void OnPropIsInWrongZone(object sender, EventArgs<Prop> e)
		{
		}

		private static void OnMaintenanceNecessaryChanged(object sender, EventArgs<Prop> e)
		{
		}

		private static void OnFireChanged(object sender, EventArgs<Prop> e)
		{
		}

		private static void OnBrokenStateChanged(object sender, EventArgs<Prop> e)
		{
		}

		private static void AbortJobs(Actor actor, Prop prop, AbortReason reason)
		{
		}

		private void OnDestroy()
		{
		}
	}
}

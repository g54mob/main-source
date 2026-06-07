using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.OrbSnatcher
{
	public class OrbGoalScript : MonoBehaviour
	{
		private OrbSnatcherActivityScript _activity;

		public void Initialize(OrbSnatcherActivityScript activity)
		{
			_activity = activity;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			NetworkAircraftScript componentInParent = other.GetComponentInParent<NetworkAircraftScript>();
			if ((object)componentInParent != null && componentInParent.IsOwner && componentInParent.TryGetComponent<OrbChainScript>(out var component))
			{
				_activity.OnPlayerScored(componentInParent.Player, component);
			}
		}
	}
}

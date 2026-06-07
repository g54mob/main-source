using Assets.Scripts.Multiplayer.FlightObjects;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class CarDespawnerScript : MonoBehaviour
	{
		protected void OnTriggerEnter(Collider other)
		{
			NetworkFlightObjectVehicleScript componentInParent = other.GetComponentInParent<NetworkFlightObjectVehicleScript>();
			if (componentInParent != null && componentInParent.IsOwner)
			{
				componentInParent.Despawn();
			}
		}
	}
}

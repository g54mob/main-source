using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class ResetActiveDrones : MonoBehaviour
	{
		public void OnClick()
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ClearActiveDrones();
		}
	}
}

using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DiscardDrone : MonoBehaviour
	{
		public void OnClick()
		{
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Image == null)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DeleteDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone);
			}
		}
	}
}

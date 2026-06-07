using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ApplyDroneName : MonoBehaviour
	{
		public UILabel NameLabel;

		public void OnClick()
		{
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.DroneName = NameLabel.text;
			if (DronePartManager.Instance.ActiveDrone.DroneData.IsCompatible())
			{
				DronePartManager.Instance.SaveActiveDrone();
			}
		}
	}
}

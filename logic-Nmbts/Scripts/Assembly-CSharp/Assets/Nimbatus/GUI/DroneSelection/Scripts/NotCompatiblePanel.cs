using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class NotCompatiblePanel : MonoBehaviour
	{
		public DeleteDrone DeleteDroneButton;

		public EditDrone EditButton;

		public void Init(DroneInformationPanel droneInformationPanel, DroneData item)
		{
			EditButton.Init(item);
			DeleteDroneButton.Init(droneInformationPanel, item);
		}
	}
}

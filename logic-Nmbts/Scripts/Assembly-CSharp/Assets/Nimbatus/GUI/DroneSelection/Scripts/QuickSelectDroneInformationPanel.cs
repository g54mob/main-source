using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class QuickSelectDroneInformationPanel : MonoBehaviour
	{
		public EditDrone EditDroneButton;

		public LaunchDrone LaunchButton;

		public ShowDronePreconditions Preconditions;

		private QuickSelectPanel _parentPanel;

		public void Init(QuickSelectPanel parent)
		{
			_parentPanel = parent;
			EditDroneButton.Init(parent.GetSelectedDrone());
			LaunchButton.Init(parent.GetSelectedDrone());
			Preconditions.Init(parent.GetSelectedDrone());
		}
	}
}

using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class AcceptLaunchButton : MonoBehaviour
	{
		private LaunchDroneWindow _panel;

		public void OnClick()
		{
			_panel.LaunchDrone();
		}

		public void Init(LaunchDroneWindow panel)
		{
			_panel = panel;
		}
	}
}

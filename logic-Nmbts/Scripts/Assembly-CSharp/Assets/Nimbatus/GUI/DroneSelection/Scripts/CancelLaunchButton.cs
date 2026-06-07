using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class CancelLaunchButton : MonoBehaviour
	{
		private LaunchDroneWindow _panel;

		public void OnClick()
		{
			_panel.CancelLaunch();
		}

		public void Init(LaunchDroneWindow panel)
		{
			_panel = panel;
		}
	}
}

using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DroneUploadButton : MonoBehaviour
	{
		private DroneUploadPanel _panel;

		public void OnClick()
		{
			_panel.UploadDrone();
		}

		public void Init(DroneUploadPanel droneUploadPanel)
		{
			_panel = droneUploadPanel;
		}
	}
}

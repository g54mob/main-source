using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class CancelUpload : MonoBehaviour
	{
		private DroneUploadPanel _panel;

		public void OnClick()
		{
			_panel.CancelUpload();
		}

		public void Init(DroneUploadPanel droneUploadPanel)
		{
			_panel = droneUploadPanel;
		}
	}
}

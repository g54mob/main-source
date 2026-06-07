using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DeleteDroneButton : MonoBehaviour
	{
		private DeleteDronePanel _panel;

		public void OnClick()
		{
			_panel.DeleteDrone();
		}

		public void Init(DeleteDronePanel panel)
		{
			_panel = panel;
		}
	}
}

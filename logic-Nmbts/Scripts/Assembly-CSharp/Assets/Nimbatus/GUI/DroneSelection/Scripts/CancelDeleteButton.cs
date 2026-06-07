using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class CancelDeleteButton : MonoBehaviour
	{
		private DeleteDronePanel _panel;

		public void OnClick()
		{
			_panel.CancelDelete();
		}

		public void Init(DeleteDronePanel panel)
		{
			_panel = panel;
		}
	}
}

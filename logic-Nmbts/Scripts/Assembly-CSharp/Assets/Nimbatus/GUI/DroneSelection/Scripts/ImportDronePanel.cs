using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class ImportDronePanel : MonoBehaviour
	{
		public ImportDroneFromFile ImportButton;

		private DroneSelectionManager _manager;

		public void Init(DroneSelectionManager manager)
		{
			_manager = manager;
			ImportButton.Init(manager);
		}
	}
}

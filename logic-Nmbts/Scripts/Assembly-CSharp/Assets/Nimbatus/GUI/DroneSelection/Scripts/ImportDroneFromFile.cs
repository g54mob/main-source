using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using SFB;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class ImportDroneFromFile : MonoBehaviour
	{
		private DroneSelectionManager _manager;

		public void Init(DroneSelectionManager manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			StandaloneFileBrowser.OpenFilePanelAsync("Open Drone", "", "drn", true, OpenDrones);
		}

		private void OpenDrones(string[] paths)
		{
			foreach (string path in paths)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ImportDroneFromFile(path);
			}
			_manager.UpdateList();
			SaveManager.StoreSaveGame(false, false);
		}
	}
}

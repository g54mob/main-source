using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class EditDrone : MonoBehaviour
	{
		private DroneData _currentDroneInfo;

		public void Init(DroneData item)
		{
			_currentDroneInfo = item;
		}

		public void OnClick()
		{
			if (_currentDroneInfo != null)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(_currentDroneInfo);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.StoreDroneBackup();
				DronePartManager.ReturnScene = SceneManager.GetActiveScene().name;
				NimbatusSceneManager.LoadScene("DroneWorkshopScene");
			}
		}

		public void OnTooltip(bool show)
		{
		}
	}
}

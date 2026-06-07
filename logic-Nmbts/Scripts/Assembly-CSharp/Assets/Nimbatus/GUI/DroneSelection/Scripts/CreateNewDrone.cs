using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class CreateNewDrone : MonoBehaviour
	{
		public void OnEnable()
		{
		}

		public void OnClick()
		{
			string termTranslation = LocalizationManager.GetTermTranslation("DroneHangar/New Drone");
			DroneData data = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.CreateDrone(termTranslation);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(data);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.StoreDroneBackup();
			DronePartManager.ReturnScene = SceneManager.GetActiveScene().name;
			NimbatusSceneManager.LoadScene("DroneWorkshopScene");
		}
	}
}

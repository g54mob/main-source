using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class OpenDroneHangar : MonoBehaviour
	{
		public bool SetDroneSettings;

		public bool ShowLaunchButton;

		[ShowIf("SetDroneSettings", true)]
		public DroneSettingsObject DroneSettings;

		public void OnClick()
		{
			if (SetDroneSettings)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetDroneSettings(DroneSettings.Settings);
			}
			DroneSelectionManager.HideLaunchButton = !ShowLaunchButton;
			DroneSelectionManager.HideBackButton = false;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneIndex = 0;
			NimbatusSceneManager.SetReturnScene("DroneHangarScene", SceneManager.GetActiveScene().name);
			NimbatusSceneManager.LoadScene("DroneHangarScene");
		}
	}
}

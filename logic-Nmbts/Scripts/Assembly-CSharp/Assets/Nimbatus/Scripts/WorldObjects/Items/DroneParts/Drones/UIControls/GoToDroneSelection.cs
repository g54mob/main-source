using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.UIControls
{
	public class GoToDroneSelection : SerializedMonoBehaviour
	{
		public int DroneSlot;

		public DroneSettingsObject Settings;

		public bool ShowLaunchButton = true;

		public void OnClick()
		{
			NimbatusSceneManager.BookmarkActiveScene();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneIndex = DroneSlot;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetDroneSettings(Settings.Settings);
			DroneSelectionManager.HideLaunchButton = !ShowLaunchButton;
			DroneSelectionManager.HideBackButton = false;
			NimbatusSceneManager.SetReturnScene("DroneHangarScene", SceneManager.GetActiveScene().name);
			NimbatusSceneManager.LoadScene("DroneHangarScene");
		}
	}
}

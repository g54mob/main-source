using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.UIControls.ActiveDroneDisplay
{
	public class DroneSelectionButton : MonoBehaviour
	{
		public int DroneIndex;

		public DroneSettingsObject Settings;

		public UITexture Texture;

		public UILabel DroneName;

		public GameObject NoDroneDisplay;

		private bool _canBeSelected;

		private DroneSettings _settings;

		public void Start()
		{
			if (_settings != null)
			{
				Init();
			}
		}

		public void SetSettings(DroneSettings settings)
		{
			_settings = settings;
			Init();
		}

		public void Init()
		{
			DroneData droneInfo = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(DroneIndex);
			_canBeSelected = true;
			GetComponent<Collider>().enabled = true;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetDroneSettings(_settings);
			if (!SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions().TrueForAll((DronePrecondition p) => p.Check(droneInfo)))
			{
				droneInfo = null;
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetActiveDrone(null, DroneIndex);
			}
			if (droneInfo != null)
			{
				Texture.gameObject.SetActive(true);
				Texture.mainTexture = droneInfo.Image;
				DroneName.text = (_canBeSelected ? (LabelHelper.Orange + droneInfo.DroneName) : (LabelHelper.LightGrey + droneInfo.DroneName));
				NoDroneDisplay.SetActive(false);
			}
			else
			{
				Texture.gameObject.SetActive(false);
				DroneName.text = "";
				NoDroneDisplay.SetActive(true);
			}
		}

		public void OnClick()
		{
			if (_canBeSelected)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetDroneSettings(_settings);
				NimbatusSceneManager.BookmarkActiveScene();
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneIndex = DroneIndex;
				DroneSelectionManager.HideLaunchButton = false;
				DroneSelectionManager.HideBackButton = false;
				NimbatusSceneManager.SetReturnScene("DroneHangarScene", SceneManager.GetActiveScene().name);
				NimbatusSceneManager.LoadScene("DroneHangarScene");
			}
		}
	}
}

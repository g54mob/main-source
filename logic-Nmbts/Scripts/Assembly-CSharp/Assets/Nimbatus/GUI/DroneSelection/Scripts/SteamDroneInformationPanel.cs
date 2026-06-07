using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.UI;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.UI;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class SteamDroneInformationPanel : MonoBehaviour
	{
		public UILabel TitleLabel;

		public UILabel UserLabel;

		public UILabel DescriptionLabel;

		public UIScrollView DescriptionScrollView;

		public UITexture DroneImage;

		public DuplicateSteamDrone DuplicateSteamDrone;

		public DeployCostDisplay CostDisplay;

		public LaunchDrone LaunchDroneButton;

		public ShowDronePreconditions Preconditions;

		public MissionDescriptionUi MissionDisplay;

		private DroneSelectionManager _manager;

		private DroneData _item;

		public void Init(DroneSelectionManager droneSelectionManager, DroneData item)
		{
			_manager = droneSelectionManager;
			_item = item;
			DuplicateSteamDrone.Init(this, item);
			CostDisplay.Init(item.NumberOfParts);
			LaunchDroneButton.Init(item);
			Preconditions.Init(item);
			Preconditions.gameObject.SetActive(!DroneSelectionManager.HideLaunchButton);
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance != null && SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null)
			{
				if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission != EMissionType.None && !DroneSelectionManager.HideLaunchButton)
				{
					MissionDisplay.gameObject.SetActive(true);
					MissionDisplay.Init(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.Mission);
				}
				else
				{
					MissionDisplay.gameObject.SetActive(false);
				}
			}
			else
			{
				MissionDisplay.gameObject.SetActive(false);
			}
			TitleLabel.text = _item.DroneName;
			if (SteamManager.Initialized)
			{
				ulong userId = item.UserId;
				if (userId != 0)
				{
					string friendPersonaName = SteamFriends.GetFriendPersonaName(new CSteamID(userId));
					UserLabel.text = LabelHelper.White + LocalizationManager.GetTermTranslation("Tournaments/BuiltBy") + " " + LabelHelper.DarkOrange + friendPersonaName;
				}
			}
			DescriptionLabel.text = _item.Description;
			DescriptionScrollView.ResetPosition();
			DroneImage.mainTexture = item.Image;
			if (DroneImage.mainTexture != null)
			{
				DroneImage.mainTexture.wrapMode = TextureWrapMode.Clamp;
			}
		}

		public void DuplicateDrone(DroneData item)
		{
			_manager.DuplicateDrone(item);
		}
	}
}

using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main.MissionRewards
{
	public class MissionRewardDisplay : MonoBehaviour
	{
		private LocationData _location;

		public PlanetSettingsPanel PlanetSettingsPanel;

		public SpaceSettingsPanel SpaceSettingsPanel;

		public GameObject CustomizationButton;

		public UILabel MissionTitleLabel;

		public bool ShowDescription;

		[ShowIf("ShowDescription", true)]
		public UILabel MissionDescriptionLabel;

		public UILabel RewardLabel;

		public MissionRewardUi ItemPrefab;

		public UIGrid ContainerGrid;

		public bool AutoFill;

		public UILabel StatusLabel;

		public void Start()
		{
			if (AutoFill)
			{
				Init(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation);
			}
		}

		public void ToggleCustomizationPanel()
		{
			if (_location is PlanetLocationData)
			{
				PlanetSettingsPanel.Toggle();
			}
			else if (_location is SpaceLocationData)
			{
				SpaceSettingsPanel.Toggle();
			}
		}

		public void Init(LocationData location)
		{
			_location = location;
			BossfightLocationData bossfightLocationData = location as BossfightLocationData;
			if (_location == null || (_location.Mission == EMissionType.None && bossfightLocationData == null))
			{
				base.gameObject.SetActive(false);
				return;
			}
			base.gameObject.SetActive(true);
			MissionTitleLabel.gameObject.SetActive(true);
			MissionTitleLabel.text = ((bossfightLocationData != null) ? bossfightLocationData.GetMissionName() : SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMissionTitle(_location.Mission));
			StatusLabel.text = (_location.MissionCompleted ? (LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("GalaxyMap/Complete")) : (_location.Visitable ? (LabelHelper.White + LocalizationManager.GetTermTranslation("GalaxyMap/Incomplete")) : (LabelHelper.DarkOrange + LocalizationManager.GetTermTranslation("GalaxyMap/Failed"))));
			StatusLabel.gameObject.SetActive(true);
			if (CustomizationButton != null)
			{
				PlanetLocationData planet;
				SpaceLocationData loc;
				if (RuntimeGlobals.GameModeSettings.CustomizablePlanets && (planet = _location as PlanetLocationData) != null)
				{
					CustomizationButton.gameObject.SetActive(true);
					PlanetSettingsPanel.Init(this, planet);
					SpaceSettingsPanel.Show(false);
				}
				else if (RuntimeGlobals.GameModeSettings.CustomizablePlanets && (loc = _location as SpaceLocationData) != null)
				{
					CustomizationButton.gameObject.SetActive(true);
					SpaceSettingsPanel.Init(this, loc);
					PlanetSettingsPanel.Show(false);
				}
				else
				{
					CustomizationButton.gameObject.SetActive(false);
					PlanetSettingsPanel.Show(false);
					SpaceSettingsPanel.Show(false);
				}
			}
			if (ShowDescription)
			{
				MissionDescriptionLabel.text = ((bossfightLocationData != null) ? bossfightLocationData.GetDescription() : SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMissionDescription(_location.Mission));
			}
			ContainerGrid.transform.DestroyAllChildren();
			if (_location.MissionRewards == null || _location.MissionRewards.Count <= 0)
			{
				RewardLabel.text = "";
			}
			else
			{
				RewardLabel.text = LocalizationManager.GetTermTranslation("GalaxyMap/Reward");
				foreach (BaseReceivable missionReward in _location.MissionRewards)
				{
					MissionRewardUi missionRewardUi = Object.Instantiate(ItemPrefab, ContainerGrid.transform);
					missionRewardUi.Init(missionReward, _location.MissionCompleted);
					missionRewardUi.transform.position = ContainerGrid.transform.position;
					missionRewardUi.transform.parent = ContainerGrid.transform;
					missionRewardUi.transform.localScale = Vector3.one;
				}
			}
			ContainerGrid.Reposition();
		}
	}
}

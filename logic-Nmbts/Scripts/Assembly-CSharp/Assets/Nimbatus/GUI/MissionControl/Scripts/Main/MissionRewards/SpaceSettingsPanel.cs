using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main.MissionRewards
{
	public class SpaceSettingsPanel : MonoBehaviour
	{
		public TweenPosition CustomizationTween;

		public EnumChooser MissionChooser;

		public EnumChooser MissionDifficultyChooser;

		public EnumChooser AirResistanceChooser;

		private SpaceLocationData _spaceLoc;

		private MissionRewardDisplay _parent;

		public void Init(MissionRewardDisplay parent, SpaceLocationData loc)
		{
			_parent = parent;
			_spaceLoc = loc;
			MissionChooser.Init(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetValidMissions(loc.SpaceLocation), loc.Mission);
			MissionDifficultyChooser.Init<EMissionComplexity>(loc.MissionComplexity);
			EAirResistance airResistance = loc.AirResistance;
			AirResistanceChooser.Init<EAirResistance>(airResistance);
		}

		public void Show(bool show)
		{
			CustomizationTween.Play(show);
		}

		public void Toggle()
		{
			CustomizationTween.Toggle();
		}

		public void Update()
		{
			if (RuntimeGlobals.GameModeSettings.CustomizablePlanets && _spaceLoc != null)
			{
				EMissionType eMissionType = (EMissionType)(object)MissionChooser.SelectedOption;
				if (_spaceLoc.Mission != eMissionType)
				{
					_spaceLoc.Mission = eMissionType;
					_spaceLoc.ApplyLocationSettings();
					Init(_parent, _spaceLoc);
					_parent.Init(_spaceLoc);
				}
				_spaceLoc.AirResistance = (EAirResistance)(object)AirResistanceChooser.SelectedOption;
				_spaceLoc.MissionComplexity = (EMissionComplexity)(object)MissionDifficultyChooser.SelectedOption;
			}
		}
	}
}

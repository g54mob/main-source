using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main.MissionRewards
{
	public class PlanetSettingsPanel : MonoBehaviour
	{
		public TweenPosition CustomizationTween;

		public EnumChooser MissionChooser;

		public EnumChooser MissionDifficultyChooser;

		public EnumChooser ThemeChooser;

		public EnumChooser GravityChooser;

		public EnumChooser AirResistanceChooser;

		public EnumChooser TerrainHardnessChooser;

		private PlanetLocationData _planet;

		private MissionRewardDisplay _parent;

		public void Init(MissionRewardDisplay parent, PlanetLocationData planet)
		{
			_parent = parent;
			_planet = planet;
			MissionChooser.Init(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetValidMissions(planet.ClimateZoneType), planet.Mission);
			MissionDifficultyChooser.Init<EMissionComplexity>(planet.MissionComplexity);
			ThemeChooser.Init(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetValidThemes(planet.ClimateZoneType), planet.ThemeType);
			EGravity gravity = planet.PlanetSettings.Gravity;
			GravityChooser.Init<EGravity>(gravity);
			EAirResistance airResistance = planet.PlanetSettings.AirResistance;
			AirResistanceChooser.Init<EAirResistance>(airResistance);
			ETerrainHardness terrainStrength = planet.PlanetSettings.TerrainStrength;
			TerrainHardnessChooser.Init<ETerrainHardness>(terrainStrength);
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
			if (RuntimeGlobals.GameModeSettings.CustomizablePlanets && _planet != null)
			{
				EMissionType eMissionType = (EMissionType)(object)MissionChooser.SelectedOption;
				if (_planet.Mission != eMissionType)
				{
					_planet.Mission = eMissionType;
					_planet.ApplyLocationSettings();
					Init(_parent, _planet);
					_parent.Init(_planet);
				}
				_planet.ThemeType = (EThemeType)(object)ThemeChooser.SelectedOption;
				EGravity gravity = (EGravity)(object)GravityChooser.SelectedOption;
				_planet.PlanetSettings.Gravity = gravity;
				_planet.PlanetSettings.AirResistance = (EAirResistance)(object)AirResistanceChooser.SelectedOption;
				_planet.MissionComplexity = (EMissionComplexity)(object)MissionDifficultyChooser.SelectedOption;
				_planet.PlanetSettings.TerrainStrength = (ETerrainHardness)(object)TerrainHardnessChooser.SelectedOption;
			}
		}
	}
}

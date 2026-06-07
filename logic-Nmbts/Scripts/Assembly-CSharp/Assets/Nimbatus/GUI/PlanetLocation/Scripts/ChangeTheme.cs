using Assets.Nimbatus.GUI.DroneWorkshop.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class ChangeTheme : MonoBehaviour
	{
		public EnumChooser EnumChooser;

		public void Start()
		{
			PlanetLocationData planetLocationData;
			if ((planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as PlanetLocationData) != null)
			{
				EThemeType themeType = planetLocationData.ThemeType;
				EClimateZoneType climateZoneType = planetLocationData.ClimateZoneType;
				EnumChooser.Init(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetValidThemes(climateZoneType), themeType);
			}
		}

		public void Update()
		{
			PlanetLocationData planetLocationData;
			if ((planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as PlanetLocationData) != null)
			{
				planetLocationData.ThemeType = (EThemeType)(object)EnumChooser.SelectedOption;
			}
		}
	}
}

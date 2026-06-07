using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class SolarSystemUi : SectorUi<SolarSystem>
	{
		public SpriteRenderer Sun;

		[HideInInspector]
		public List<LocationUi> Locations;

		public override void Init()
		{
			Locations = new List<LocationUi>();
			Sun.color = Sector.SunColor;
			if (Sector.SunScale > 0f)
			{
				Sun.gameObject.transform.localScale = new Vector3(Sector.SunScale, Sector.SunScale, 1f);
			}
			foreach (LocationData location in Sector.Locations)
			{
				LocationUi locationUi = Object.Instantiate(Manager.LocationPrefab, base.transform);
				locationUi.transform.localPosition = location.Position;
				locationUi.Init(Manager, location, Sector);
				Locations.Add(locationUi);
				Manager.AddToLocations(locationUi);
				if (location == SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation)
				{
					Manager.CurrentLocation = locationUi;
					Manager.SelectedLocation = locationUi;
					Manager.FocusLocation(locationUi, true);
				}
			}
		}
	}
}

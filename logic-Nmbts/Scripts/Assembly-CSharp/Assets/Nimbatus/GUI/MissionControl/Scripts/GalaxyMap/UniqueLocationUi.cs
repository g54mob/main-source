using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class UniqueLocationUi : SectorUi<UniqueLocationSector>
	{
		[HideInInspector]
		public LocationUi LocationUiElement;

		public override void Init()
		{
			LocationUiElement = Object.Instantiate(Manager.LocationPrefab, base.transform);
			LocationUiElement.transform.localPosition = Sector.Location.Position;
			LocationUiElement.Init(Manager, Sector.Location, Sector);
			if (Sector.Location == SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation)
			{
				Manager.CurrentLocation = LocationUiElement;
				Manager.SelectedLocation = LocationUiElement;
				Manager.FocusLocation(LocationUiElement, true);
			}
			Manager.AddToLocations(LocationUiElement);
		}
	}
}

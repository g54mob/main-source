using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class DisplayLocationName : MonoBehaviour
	{
		public UILabel Label;

		public void Update()
		{
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				Label.text = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.Title.GetTranslation();
			}
			else if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation != null)
			{
				LocationData currentLocation = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation;
				BossfightLocationData bossfightLocationData;
				Label.text = (((bossfightLocationData = currentLocation as BossfightLocationData) != null) ? bossfightLocationData.GetName() : currentLocation.Name);
				if (currentLocation.IsShopLocation)
				{
					Label.color = currentLocation.LocationSetting.SpecialLocationColor;
				}
			}
		}
	}
}

using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.MapGeneration.MapEvents;
using Assets.Scripts.Managers;
using UnityEngine;

public class MapEventsManager : MonoBehaviour
{
	private MapEvents mapEvents;

	private void Start()
	{
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if (mapData.eMap == EMap.Desert)
		{
			MapEventsDesert mapEventsDesert = new MapEventsDesert();
			mapEvents = mapEventsDesert;
		}
		if (mapEvents != null)
		{
			mapEvents.Init();
		}
	}

	private void OnDestroy()
	{
		if (mapEvents != null)
		{
			mapEvents.Cleanup();
		}
	}

	private void FixedUpdate()
	{
		if (mapEvents != null)
		{
			mapEvents.Tick();
		}
	}
}

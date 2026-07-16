using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour, ISaveable
{
	public static WorldMap Instance;

	[SerializeField]
	private GameObject worldMap;

	[SerializeField]
	private GameObject worldMapButton;

	[SerializeField]
	private GameObject localMapButton;

	[SerializeField]
	private TextMeshProUGUI header;

	[SerializeField]
	private TextMeshProUGUI footer;

	private int waitingForUnlock = 1;

	private int lastUnlockedIndex;

	private int lastDiscoveredIndex;

	private bool forceWorldMapOnOpen;

	[field: SerializeField]
	public List<WorldMapZone> Zones { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		PrepareWorld(GameManager.Instance.UnlockedWorlds);
		LevelManager.Instance.LevelStarted += ZoneDiscovered;
		ZoneManager.Instance.OnNewZone += SetBackground;
		if (waitingForUnlock > lastUnlockedIndex)
		{
			forceWorldMapOnOpen = true;
			Zones[waitingForUnlock - 1].readyToUnlock = true;
			lastUnlockedIndex = waitingForUnlock - 1;
		}
		for (int i = 0; i < lastDiscoveredIndex; i++)
		{
			Zones[i].DiscoverZone();
		}
		for (int j = 0; j < lastUnlockedIndex; j++)
		{
			Zones[j].Unlock();
		}
	}

	public void SetUnlockAsLast()
	{
		lastUnlockedIndex = waitingForUnlock;
	}

	private void PrepareWorld(int worldIndex)
	{
		waitingForUnlock = worldIndex;
	}

	private void ZoneDiscovered()
	{
		if (ZoneManager.Instance.CurrentZoneIndex != 0)
		{
			Zones[ZoneManager.Instance.CurrentZoneIndex - 1].DiscoverZone();
			lastDiscoveredIndex = ZoneManager.Instance.CurrentZoneIndex;
		}
	}

	public void SetBackground(Zone zone)
	{
		worldMap.GetComponent<Image>().color = zone.Definition.BgColor;
	}

	public void OpenWorldMap()
	{
		worldMap.SetActive(value: true);
		localMapButton.SetActive(value: true);
		worldMapButton.SetActive(value: false);
		header.gameObject.SetActive(value: true);
		header.text = "World Map";
		footer.gameObject.SetActive(value: false);
	}

	public void OpenLocalMap()
	{
		if (forceWorldMapOnOpen && ZoneManager.Instance.CurrentZoneIndex > 0)
		{
			forceWorldMapOnOpen = false;
			OpenWorldMap();
			return;
		}
		worldMap.SetActive(value: false);
		localMapButton.SetActive(value: false);
		worldMapButton.SetActive(value: true);
		header.gameObject.SetActive(value: true);
		footer.gameObject.SetActive(value: true);
		if (!GameManager.Instance.RunStarted)
		{
			header.text = ZoneManager.Instance.CurrentZone.Definition.DisplayName;
			if (ZoneManager.Instance.CurrentZoneIndex == 0)
			{
				header.text = "";
			}
			else
			{
				footer.text = "Final Destination: " + ZoneManager.Instance.ZoneDefinitions[GameManager.Instance.UnlockedWorlds].DisplayName;
			}
		}
		else
		{
			header.text = "";
			if (ZoneManager.Instance.CurrentZoneIndex == 0)
			{
				footer.text = "";
			}
			else
			{
				footer.text = ZoneManager.Instance.CurrentZone.Definition.DisplayName;
			}
		}
	}

	public void CloseWorldMap()
	{
		worldMap.SetActive(value: false);
		localMapButton.SetActive(value: false);
		worldMapButton.SetActive(value: false);
		header.gameObject.SetActive(value: false);
		footer.gameObject.SetActive(value: false);
	}

	public void SetHeader(string text)
	{
		header.text = text;
	}

	public void Save(SaveDataContext saveDataContext)
	{
		MetaSavefile metaSave = saveDataContext.MetaSave;
		metaSave.lastDiscoveredWorld = lastDiscoveredIndex;
		metaSave.lastUnlockedWorld = lastUnlockedIndex;
	}

	public void Load(SaveDataContext saveDataContext, bool isNewJourney)
	{
		MetaSavefile metaSave = saveDataContext.MetaSave;
		lastDiscoveredIndex = metaSave.lastDiscoveredWorld;
		lastUnlockedIndex = metaSave.lastUnlockedWorld;
	}
}

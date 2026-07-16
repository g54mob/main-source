using System;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
	public static ZoneManager Instance;

	public ZoneDefinition[] ZoneDefinitions;

	public Zone CurrentZone;

	private int currentZoneIndex = -1;

	private ZoneDefinition currentZoneDef;

	public EnemyWave[] Waves
	{
		get
		{
			if (DifficultyManager.Instance.mixedWaves && currentZoneIndex < ZoneDefinitions.Length - 1 && CurrentZoneIndex != 3 && ZoneDefinitions[currentZoneIndex + 1] != null && UnityEngine.Random.Range(0f, 1f) <= DifficultyManager.Instance.chanceForMixedWaves)
			{
				return ZoneDefinitions[currentZoneIndex + 1].Waves;
			}
			return currentZoneDef.Waves;
		}
	}

	public GameObject BossPrefab => currentZoneDef.bossPrefab;

	public int CurrentZoneIndex => currentZoneIndex;

	public Zone GetNextZone
	{
		get
		{
			if (currentZoneIndex == ZoneDefinitions.Length - 1)
			{
				return null;
			}
			return new Zone(ZoneDefinitions[currentZoneIndex + 1]);
		}
	}

	public event Action<Zone> OnNewZone;

	public event Action<int> OnZoneLoaded;

	public int GetZoneIndex(ZoneDefinition def)
	{
		for (int i = 0; i < ZoneDefinitions.Length; i++)
		{
			if (def.ZoneName == ZoneDefinitions[i].ZoneName)
			{
				return i;
			}
		}
		return -1;
	}

	private void Awake()
	{
		Instance = this;
		Debug.Log("ZoneManager Awake");
		ZoneDefinition[] zoneDefinitions = ZoneDefinitions;
		for (int i = 0; i < zoneDefinitions.Length; i++)
		{
			zoneDefinitions[i].LoadWavesRuntime();
		}
	}

	private void Start()
	{
	}

	public void SetFirstZone()
	{
		if (!SaveManager.Instance.IsTutorialComplete)
		{
			currentZoneIndex = 0;
		}
		else if (!GameManager.Instance.IsTutorialClicked)
		{
			currentZoneIndex = 1;
		}
		else
		{
			currentZoneIndex = 0;
		}
	}

	public void SetNextZone(bool saveLevels = false)
	{
		Debug.Log("Entered SetNextZone");
		if ((currentZoneIndex > 0 && GameManager.Instance.isDemo) || currentZoneIndex + 1 >= ZoneDefinitions.Length || currentZoneIndex >= GameManager.Instance.SupportedWorlds || currentZoneIndex >= GameManager.Instance.UnlockedWorlds)
		{
			GameManager.Instance.GameOver(victory: true);
			return;
		}
		currentZoneIndex++;
		SetZone(ZoneDefinitions[currentZoneIndex], saveLevels);
	}

	public void SetZone(ZoneDefinition def, bool saveLevels = false)
	{
		Debug.Log("Entered SetZone");
		currentZoneDef = def;
		CurrentZone = new Zone(def);
		this.OnNewZone?.Invoke(CurrentZone);
		this.OnZoneLoaded?.Invoke(currentZoneIndex);
		SetTrainDustForZone(currentZoneDef.name);
		if (currentZoneDef.name == "T0_Tutorial")
		{
			Train.Instance.RemoveModulesForTutorial();
		}
		else if (currentZoneDef.name == "Z3_Viaduct")
		{
			TrackManager.Instance.ShowParallaxBackground(show: true);
		}
		else
		{
			TrackManager.Instance.ShowParallaxBackground(show: false);
		}
		if (saveLevels)
		{
			SaveManager.Instance.SaveLevels();
		}
	}

	public void SetZoneAtIndex(int index, bool saveLevels = false)
	{
		Debug.Log("Entered SetZone");
		if (ZoneDefinitions == null || ZoneDefinitions.Length <= index)
		{
			Debug.LogError($"Failed loading zone at index {index}");
			return;
		}
		currentZoneIndex = index;
		SetZoneAtCurrentZoneIndex(saveLevels);
	}

	public void SetZoneAtCurrentZoneIndex(bool saveLevels = false)
	{
		if (currentZoneIndex < 0)
		{
			currentZoneIndex = 0;
		}
		CurrentZone = new Zone(currentZoneDef = ZoneDefinitions[currentZoneIndex]);
		this.OnNewZone?.Invoke(CurrentZone);
		this.OnZoneLoaded?.Invoke(currentZoneIndex);
		SetTrainDustForZone(currentZoneDef.name);
		if (currentZoneDef.name == "T0_Tutorial")
		{
			Train.Instance.RemoveModulesForTutorial();
		}
		if (saveLevels)
		{
			SaveManager.Instance.SaveLevels();
		}
	}

	private void SetTrainDustForZone(string zoneName)
	{
		switch (zoneName)
		{
		case "T0_Tutorial":
			Train.Instance.hideDust = false;
			break;
		case "Z1_Wasteland":
			Train.Instance.hideDust = true;
			break;
		case "Z2_City":
			Train.Instance.hideDust = true;
			break;
		case "Z3_Viaduct":
			Train.Instance.hideDust = true;
			break;
		case "Z4_Snow":
			Train.Instance.hideDust = true;
			break;
		default:
			Train.Instance.hideDust = false;
			break;
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsManager : MonoBehaviour, ISavable
{
	public static GameStatsManager instance;

	[Savable("towersDamageReport", true, false)]
	private Dictionary<string, FDamageReport> towersDamageReports;

	[Savable("deadEnemies", true, false)]
	private Dictionary<string, int> deadEnemies;

	[Savable("obtainedResources", true, false)]
	private Dictionary<string, int> obtainedResources;

	public event Action<string, int> onEnemyKilled;

	private void Awake()
	{
		instance = this;
		towersDamageReports = new Dictionary<string, FDamageReport>();
		deadEnemies = new Dictionary<string, int>();
		obtainedResources = new Dictionary<string, int>();
	}

	private void Start()
	{
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += OnPlayerTowerAdded;
		LTFunctionLibrary.GetPlayerInventory().onStoreObject += OnObjectStoredInInventory;
		LTFunctionLibrary.GetSpawnersManager().onEnemyDies += OnEnemyDies;
		foreach (GameplayObject playerTower in LTFunctionLibrary.GetPlayerData().PlayerTowers)
		{
			OnPlayerTowerAdded(playerTower);
		}
	}

	public FDamageReport GetDamageReport(string towerID)
	{
		if (towersDamageReports.TryGetValue(towerID, out var value))
		{
			return value;
		}
		return null;
	}

	public FDamageReport GetTotalDamageReport()
	{
		FDamageReport fDamageReport = new FDamageReport();
		foreach (FDamageReport value in towersDamageReports.Values)
		{
			fDamageReport.AddDamageReport(value);
		}
		return fDamageReport;
	}

	public int GetKilledEnemy(string enemyID)
	{
		if (deadEnemies.TryGetValue(enemyID, out var value))
		{
			return value;
		}
		return 0;
	}

	public int GetTotalKilledEnemies()
	{
		int num = 0;
		foreach (int value in deadEnemies.Values)
		{
			num += value;
		}
		return num;
	}

	public int GetObtainedResource(string resourceID)
	{
		if (obtainedResources.TryGetValue(resourceID, out var value))
		{
			return value;
		}
		return 0;
	}

	public int GetTotalObtainedResources()
	{
		int num = 0;
		foreach (int value in obtainedResources.Values)
		{
			num += value;
		}
		return num;
	}

	public float GetObtainedResourceValue(string resourceID)
	{
		if (obtainedResources.TryGetValue(resourceID, out var value))
		{
			return LTAssetsReferences.instance.GetResourceDataById(resourceID).Value * (float)value;
		}
		return 0f;
	}

	public float GetTotalObtainedResourceValue()
	{
		float num = 0f;
		foreach (string key in obtainedResources.Keys)
		{
			num += GetObtainedResourceValue(key);
		}
		return num;
	}

	public void ReportDamage(FDamageReport report, Tower tower)
	{
		string key = ((tower == null) ? "unknown" : tower.GameplayObject.ObjectData.Id);
		if (towersDamageReports.ContainsKey(key))
		{
			towersDamageReports[key].AddDamageReport(report);
		}
		else
		{
			towersDamageReports.Add(key, report);
		}
	}

	private void OnPlayerTowerAdded(GameplayObject addedTower)
	{
		addedTower.GetComponent<TowerCombatComponent>().onDamageEnemy += OnTowerDamagesEnemy;
	}

	private void OnPlayerTowerRemoved(GameplayObject removedTower)
	{
		removedTower.GetComponent<TowerCombatComponent>().onDamageEnemy -= OnTowerDamagesEnemy;
	}

	private void OnObjectStoredInInventory(Storage<ResourceData>.StoredObjectData storedObject, int storedAmount, string storeSourceID)
	{
		if (storeSourceID != Storage_ResourceData.EStoreSource.Refund.ToString() && storeSourceID != Storage_ResourceData.EStoreSource.Effect.ToString() && storeSourceID != Storage_ResourceData.EStoreSource.Trade.ToString() && storeSourceID != Storage_ResourceData.EStoreSource.LoadGame.ToString())
		{
			if (obtainedResources.ContainsKey(storedObject.id))
			{
				obtainedResources[storedObject.id] += storedAmount;
			}
			else
			{
				obtainedResources.Add(storedObject.id, storedAmount);
			}
		}
	}

	private void OnTowerDamagesEnemy(Enemy enemy, Tower tower, FDamageData data, Vector3 vector, bool isMainDamage, object auxData, FDamageReport report)
	{
		if (report != null)
		{
			if (towersDamageReports.ContainsKey(tower.GameplayObject.ObjectData.Id))
			{
				towersDamageReports[tower.GameplayObject.ObjectData.Id].AddDamageReport(report);
			}
			else
			{
				towersDamageReports.Add(tower.GameplayObject.ObjectData.Id, report);
			}
		}
	}

	private void OnEnemyDies(Enemy enemy)
	{
		if (deadEnemies.ContainsKey(enemy.Data.Id))
		{
			deadEnemies[enemy.Data.Id]++;
		}
		else
		{
			deadEnemies.Add(enemy.Data.Id, 1);
		}
		this.onEnemyKilled?.Invoke(enemy.Data.Id, deadEnemies[enemy.Data.Id]);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething || !data.ContainsKey("towersDamageReport"))
		{
			return;
		}
		foreach (string key in (data["towersDamageReport"] as Dictionary<string, object>).Keys)
		{
			Dictionary<string, object> dataToLoad = (data["towersDamageReport"] as Dictionary<string, object>)[key] as Dictionary<string, object>;
			FDamageReport fDamageReport = new FDamageReport();
			SaveSystem.LoadObjectData(fDamageReport, dataToLoad);
			towersDamageReports.Add(key, fDamageReport);
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : Singleton<TowerManager>
{
	[SerializeField]
	private List<ABaseTower> list_Towers;

	[SerializeField]
	private Dictionary<eItemType, IngameTowerData> dict_IngameTowerData;

	[SerializeField]
	private List<TowerDamageRecord> list_TowerDamageRecord;

	[SerializeField]
	private List<ModifierData> list_GlobalPriceModifiers;

	public Action<ABaseTower, AMonsterBase> OnTowerKillMonster;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTowerChanged(List<TowerIngameData> list, int index)
	{
	}

	public void RegisterTower(ABaseTower tower)
	{
	}

	public void UnregisterTower(ABaseTower tower)
	{
	}

	public bool IsHaveAnyTowerInRange(Vector3 position, float range, float minRange = 0f)
	{
		return false;
	}

	public List<ABaseTower> GetTowersInRange(Vector3 position, float range, float minRange = 0f)
	{
		return null;
	}

	public void SetTowerDefaultTargetPriority(eItemType towerType, eTowerTargetPriority newPriorty)
	{
	}

	public eTowerTargetPriority GetTowerDefaultTargetPriority(eItemType towerType)
	{
		return default(eTowerTargetPriority);
	}

	public List<ABaseTower> GetAllTowersOnField()
	{
		return null;
	}

	public List<ABaseTower> GetAllTowersOnFieldByType(eItemType type)
	{
		return null;
	}

	public int GetTowerCardCountInHandByType(eItemType type)
	{
		return 0;
	}

	public int GetUniqueTowerTypesOnField()
	{
		return 0;
	}

	public int GetTowerCountByType(eItemType type)
	{
		return 0;
	}

	public bool HasTowerTypeOnField(eItemType type)
	{
		return false;
	}

	public ABaseTower CreateTowerAtPosition(eItemType towerType, Vector3 position, bool doActivate, Quaternion rotation = default(Quaternion), bool doRegisterToGrid = true)
	{
		return null;
	}

	public int GetTotalDamageForTowerType(eItemType towerType)
	{
		return 0;
	}

	public void RequestTrigger_TowerKilledMonster(ABaseTower tower, AMonsterBase monster)
	{
	}

	public bool IsPositionValidToPlaceTower(Vector3 position)
	{
		return false;
	}

	private bool CheckIsUpperPlacementAvaliableAtPositon(Vector3 position)
	{
		return false;
	}

	public void AddPriceModifier(eItemType towerType, int id, float modifier, eModifierType modifierType)
	{
	}

	public void RemovePriceModifier(eItemType towerType, int id)
	{
	}

	public int GetBuildCost(eItemType towerType)
	{
		return 0;
	}

	public int GetBasicBuildCost(eItemType towerType)
	{
		return 0;
	}

	public List<ABaseTower> GetSurroundingTowers(ABaseTower tower)
	{
		return null;
	}

	private void OnRequestUpgradeTower(ABaseTower tower, ABaseTower.eUpgradeType upgradeType, bool isFromPlayer)
	{
	}

	public List<ABaseTower> AddBuffToTowersWithCondition(eStatType statType, eModifierType modifierType, float value, float timeLimit = 0f, int id = -1, Func<ABaseTower, bool> ConditionChecker = null)
	{
		return null;
	}

	public void RemoveBuffFromTowers(List<ABaseTower> list_Towers, eStatType statType, int id = -1)
	{
	}

	public void AddGlobalPriceModifier(int id, float modifier, eModifierType modifierType)
	{
	}

	public void RemoveGlobalPriceModifier(int id)
	{
	}

	public float GetGlobalPriceModifier_Add()
	{
		return 0f;
	}

	public float GetGlobalPriceModifier_Multiply()
	{
		return 0f;
	}
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "GameplayObjectData", menuName = "GameKit/GameplayObjectData", order = 1)]
public class GameplayObjectData : ScriptableObject, ISavable
{
	[SerializeField]
	[Savable("id", true, false)]
	private string id = "";

	[SerializeField]
	private GameplayObject obj;

	[SerializeField]
	private EGameplayObjectType type;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private Sprite image;

	[SerializeField]
	private Sprite hotbarImage;

	[SerializeField]
	private Cost[] cost;

	[SerializeField]
	private bool canBeSold = true;

	[SerializeField]
	private GameplayObjectData[] upgradeObjects;

	[SerializeField]
	private GameplayObjectData baseObject;

	public string Id => id;

	public GameplayObject Obj => obj;

	public EGameplayObjectType Type => type;

	public LocalizedString DisplayNameLocalizedString => displayName;

	public string DisplayName => displayName.GetLocalizedString();

	public string Description => description.GetLocalizedString();

	public Sprite Image => image;

	public Sprite HotbarImage => hotbarImage;

	public GameObject Prefab => Obj.gameObject;

	public Cost[] Cost
	{
		get
		{
			return cost;
		}
		set
		{
			cost = value;
		}
	}

	public Cost[] BuyCost
	{
		get
		{
			if (type == EGameplayObjectType.Tower && !IsUpgrade())
			{
				Cost[] array = new Cost[cost.Length];
				float num = 1f;
				PlayerData playerData = LTFunctionLibrary.GetPlayerData();
				if ((object)playerData != null && playerData.CanBuildTowersOverLimit)
				{
					num = LTFunctionLibrary.GetPlayerData().GetCurrentTowersTaxesMultiplier();
				}
				for (int i = 0; i < cost.Length; i++)
				{
					if (cost[i].Resource.Id == "lightCrystal")
					{
						array[i] = new Cost(cost[i].Resource, cost[i].Amount);
					}
					else
					{
						array[i] = new Cost(cost[i].Resource, Mathf.RoundToInt((float)cost[i].Amount * num));
					}
				}
				return array;
			}
			return Cost;
		}
	}

	public Cost[] FullCost
	{
		get
		{
			if ((bool)BaseObject)
			{
				return BaseObject.FullCost.Concat(cost).ToArray();
			}
			return Cost;
		}
	}

	public bool CanBeSold
	{
		get
		{
			return canBeSold;
		}
		set
		{
			canBeSold = value;
		}
	}

	public GameplayObjectData BaseObject => baseObject;

	public GameplayObjectData[] UpgradeObjects => upgradeObjects;

	public bool IsUpgrade()
	{
		return BaseObject != null;
	}

	public int TotalValue()
	{
		int num = 0;
		for (int i = 0; i < cost.Length; i++)
		{
			num += (int)(cost[i].Resource.Value * (float)cost[i].Amount);
		}
		return num;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}

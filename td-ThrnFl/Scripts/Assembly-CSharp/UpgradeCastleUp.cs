using System.Collections.Generic;
using UnityEngine;

public class UpgradeCastleUp : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static UpgradeCastleUp instance;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int immediateWallAndTowerDiscount2 = 2;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int immediateWallAndTowerDiscount3 = 4;

	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private List<TaggedObject> allWallsAndTowers = new List<TaggedObject>();

	private void OnEnable()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		instance = this;
		if (!LocalMatchSaveLoad.CurrentlyLoadingMatch)
		{
			mustHaveTags.Add(TagManager.ETag.WallOrTower);
			DecreasePriceOfWallsAndTowers();
		}
	}

	public void OnDusk()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	private void DecreasePriceOfWallsAndTowers()
	{
		TagManager.instance.FindAllTaggedObjectsWithTags(allWallsAndTowers, mustHaveTags, mayNotHaveTags);
		for (int i = 0; i < allWallsAndTowers.Count; i++)
		{
			BuildSlot componentInParent = allWallsAndTowers[i].GetComponentInParent<BuildSlot>();
			DecreasePriceOfWallOrTower(componentInParent);
		}
	}

	public void DecreasePriceOfWallOrTower(BuildSlot _buildSlot)
	{
		if (!_buildSlot.ActivatorUpgradesThis)
		{
			if (_buildSlot.Level == 1)
			{
				_buildSlot.NextUpgradeOrBuildCost = Mathf.Max(1, _buildSlot.NextUpgradeOrBuildCost - immediateWallAndTowerDiscount2);
			}
			if (_buildSlot.Level == 2)
			{
				_buildSlot.NextUpgradeOrBuildCost = Mathf.Max(1, _buildSlot.NextUpgradeOrBuildCost - immediateWallAndTowerDiscount3);
			}
		}
	}

	public void OnDuskEarly()
	{
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}
}

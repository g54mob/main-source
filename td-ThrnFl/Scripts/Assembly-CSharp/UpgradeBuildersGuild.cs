using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeBuildersGuild : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	private static UpgradeBuildersGuild instance;

	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private List<TaggedObject> allHousesTaggedObjs = new List<TaggedObject>();

	private List<TaggedObject> allHousesTaggedObjsSorted = new List<TaggedObject>();

	private bool hasBeenUsedAlready;

	public static UpgradeBuildersGuild Instance => instance;

	private void OnEnable()
	{
		if (!mustHaveTags.Contains(TagManager.ETag.House))
		{
			mustHaveTags.Add(TagManager.ETag.House);
		}
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		instance = this;
		ManualLoad(GetComponentInParent<SaveLoadEntity>().GUID);
		if (!hasBeenUsedAlready)
		{
			StartCoroutine(UpgradeAHouseWithDelay());
			hasBeenUsedAlready = true;
		}
	}

	private void OnDisable()
	{
		instance = null;
	}

	public void OnDuskEarly()
	{
		UpgradeAHouse();
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

	public IEnumerator UpgradeAHouseWithDelay()
	{
		yield return null;
		yield return null;
		UpgradeAHouse();
	}

	private void UpgradeAHouse()
	{
		TagManager.instance.FindAllTaggedObjectsWithTags(allHousesTaggedObjs, mustHaveTags, mayNotHaveTags);
		allHousesTaggedObjsSorted = allHousesTaggedObjs.OrderBy((TaggedObject o) => (o.transform.position - base.transform.position).magnitude).ToList();
		for (int num = 0; num < allHousesTaggedObjsSorted.Count; num++)
		{
			BuildSlot componentInParent = allHousesTaggedObjs[num].GetComponentInParent<BuildSlot>();
			if (componentInParent.Level == 1)
			{
				componentInParent.TryToBuildOrUpgradeAndPay(null, _presentChoice: false);
				break;
			}
		}
	}

	public int GetIncomeChangeIfNextUpgradeIsPossible()
	{
		int result = 0;
		TagManager.instance.FindAllTaggedObjectsWithTags(allHousesTaggedObjs, mustHaveTags, mayNotHaveTags);
		allHousesTaggedObjsSorted = allHousesTaggedObjs.OrderBy((TaggedObject o) => (o.transform.position - base.transform.position).magnitude).ToList();
		for (int num = 0; num < allHousesTaggedObjsSorted.Count; num++)
		{
			BuildSlot componentInParent = allHousesTaggedObjs[num].GetComponentInParent<BuildSlot>();
			if (componentInParent.Level == 1)
			{
				result = componentInParent.upgrades[componentInParent.Level].upgradeBranches[0].goldIncomeChange;
				break;
			}
		}
		return result;
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_build_used", hasBeenUsedAlready);
	}

	private void ManualLoad(string guid)
	{
		if (MatchSaveLoadHandler.IsLoadingPermitted)
		{
			hasBeenUsedAlready = MatchSaveLoadHandler.TryLoadValue(guid, base.transform.parent.gameObject.name + "_" + base.gameObject.name + "_build_used", ref hasBeenUsedAlready);
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}
}

using System.Collections.Generic;
using UnityEngine;

public class PowerTowerPerk : MonoBehaviour
{
	[SerializeField]
	private Equippable powerTowerPerk;

	[SerializeField]
	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	[SerializeField]
	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private TagManager tagManager;

	private float attackSpeedBonus;

	private float nextRefreshIn = 0.2f;

	private TaggedObject closestTower;

	private void Start()
	{
		if (!PerkManager.IsEquipped(powerTowerPerk))
		{
			Object.Destroy(this);
			return;
		}
		tagManager = TagManager.instance;
		attackSpeedBonus = PerkManager.instance.powerTower_attackSpeedBonus;
	}

	private void Update()
	{
		nextRefreshIn -= Time.deltaTime;
		if (nextRefreshIn <= 0f)
		{
			closestTower = tagManager.FindClosestTaggedObjectWithTags(base.transform.position, mustHaveTags, mayNotHaveTags);
			nextRefreshIn = 0.2f;
		}
		if (closestTower != null)
		{
			AutoAttack[] componentsInChildren = closestTower.GetComponentsInChildren<AutoAttack>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ReduceCooldownBy(attackSpeedBonus * Time.deltaTime);
			}
			HotOilTower[] componentsInChildren2 = closestTower.GetComponentsInChildren<HotOilTower>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].ReduceCooldownBy(attackSpeedBonus * Time.deltaTime);
			}
		}
	}
}

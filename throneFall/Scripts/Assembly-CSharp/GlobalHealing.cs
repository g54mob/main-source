using System.Collections.Generic;
using UnityEngine;

public class GlobalHealing : MonoBehaviour
{
	private bool healPlayerUntisPerkActive;

	private bool healEnemyUnitsMutatorActive;

	private float healPlayerUnitsPerHeal;

	private float healEnemyUnitsPerHealPercentage;

	private float maxHealingPerEnemy;

	private float healPlayerUnitsCooldown = 1f;

	private float healEnemyUnitsCooldown = 0.1f;

	private TagManager tagManager;

	[SerializeField]
	private List<TagManager.ETag> playerUnitsMustHaveTags;

	[SerializeField]
	private List<TagManager.ETag> playerUnitsMayNotHaveTags;

	[SerializeField]
	private List<TagManager.ETag> enemyUnitsMustHaveTags;

	[SerializeField]
	private List<TagManager.ETag> enemyUnitsMayNotHaveTags;

	private List<TaggedObject> taggedObjectsFound = new List<TaggedObject>();

	private void Start()
	{
		tagManager = TagManager.instance;
		healPlayerUntisPerkActive = PerkManager.instance.HealthPotionsActive;
		healEnemyUnitsMutatorActive = PerkManager.instance.TauntThePhoenixGodActive;
		healPlayerUnitsPerHeal = PerkManager.instance.healthPotion_HealingPerSec * 2f;
		healEnemyUnitsPerHealPercentage = PerkManager.instance.phoenixGod_HealingPercentagePerSec * 2f;
		maxHealingPerEnemy = PerkManager.instance.phoenixGod_MaxHealingPerSec * 2f;
		if (!healPlayerUntisPerkActive && !healEnemyUnitsMutatorActive)
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		if (healPlayerUntisPerkActive)
		{
			healPlayerUnitsCooldown -= Time.deltaTime;
			if (healPlayerUnitsCooldown <= 0f)
			{
				healPlayerUnitsCooldown += 2f;
				tagManager.FindAllTaggedObjectsWithTags(taggedObjectsFound, playerUnitsMustHaveTags, playerUnitsMayNotHaveTags);
				foreach (TaggedObject item in taggedObjectsFound)
				{
					item.Hp.Heal(healPlayerUnitsPerHeal);
				}
			}
		}
		if (!healEnemyUnitsMutatorActive)
		{
			return;
		}
		healEnemyUnitsCooldown -= Time.deltaTime;
		if (!(healEnemyUnitsCooldown <= 0f))
		{
			return;
		}
		healEnemyUnitsCooldown += 2f;
		tagManager.FindAllTaggedObjectsWithTags(taggedObjectsFound, enemyUnitsMustHaveTags, enemyUnitsMayNotHaveTags);
		foreach (TaggedObject item2 in taggedObjectsFound)
		{
			item2.Hp.Heal(Mathf.Min(healEnemyUnitsPerHealPercentage * item2.Hp.maxHp, maxHealingPerEnemy));
		}
	}
}

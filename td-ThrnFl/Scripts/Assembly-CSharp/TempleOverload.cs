using System.Collections.Generic;
using UnityEngine;

public class TempleOverload : TempleUpgrade
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float healthPercentageLossPerSec = 0.01f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float towerDamageMulti = 1.5f;

	private List<TaggedObject> taggedObjectsTemp = new List<TaggedObject>();

	private List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	private bool effectRunning;

	private float timeTillNextTick;

	public override void EnableEffectAtDusk()
	{
		mustHaveTags.Clear();
		mustHaveTags.Add(TagManager.ETag.Tower);
		mustHaveTags.Add(TagManager.ETag.AUTO_Alive);
		TagManager.instance.FindAllTaggedObjectsWithTags(taggedObjectsTemp, mustHaveTags, mayNotHaveTags);
		effectRunning = true;
		foreach (TaggedObject item in taggedObjectsTemp)
		{
			item.GetComponentInChildren<AutoAttackTower>(includeInactive: true).DamageMultiplyer *= towerDamageMulti;
		}
	}

	private void Update()
	{
		if (!effectRunning)
		{
			return;
		}
		timeTillNextTick -= Time.deltaTime;
		if (!(timeTillNextTick <= 0f))
		{
			return;
		}
		timeTillNextTick = 2f;
		foreach (TaggedObject item in taggedObjectsTemp)
		{
			item.Hp.TakeDamage(healthPercentageLossPerSec * 2f * item.Hp.maxHp);
		}
	}

	public override void DisableEffectAtDawn()
	{
		effectRunning = false;
		base.enabled = false;
		foreach (TaggedObject item in taggedObjectsTemp)
		{
			item.GetComponentInChildren<AutoAttackTower>(includeInactive: true).DamageMultiplyer /= towerDamageMulti;
		}
	}
}

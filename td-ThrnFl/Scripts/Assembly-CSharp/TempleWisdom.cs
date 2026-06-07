using System.Collections.Generic;
using UnityEngine;

public class TempleWisdom : TempleUpgrade
{
	[SerializeField]
	private GameObject pickupCoin;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int goldForDestroyedBuilding;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float healthPercentageLossPerSec;

	private List<TaggedObject> buildings = new List<TaggedObject>();

	private float timeTillNextTick;

	private bool effectRunning;

	public override void EnableEffectAtDusk()
	{
		effectRunning = true;
		TagManager.instance.FindAllTaggedObjectsWithTag(buildings, TagManager.ETag.Building);
		foreach (TaggedObject building in buildings)
		{
			Debug.Log("Applied Gold Effect To Building!");
			building.Hp.coin = pickupCoin;
			building.Hp.coinCount += goldForDestroyedBuilding;
			building.Hp.coinSpawnOffset = 0.5f;
		}
	}

	public override void DisableEffectAtDawn()
	{
		effectRunning = false;
		foreach (TaggedObject building in buildings)
		{
			building.Hp.coinCount -= goldForDestroyedBuilding;
			building.Hp.coin = null;
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
		foreach (TaggedObject building in buildings)
		{
			if (!building.Tags.Contains(TagManager.ETag.PlayerShrine))
			{
				building.Hp.TakeDamage(healthPercentageLossPerSec * 2f * building.Hp.maxHp);
			}
		}
	}
}

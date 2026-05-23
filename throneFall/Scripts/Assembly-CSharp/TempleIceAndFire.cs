using System.Collections.Generic;
using UnityEngine;

public class TempleIceAndFire : TempleUpgrade
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float boltCooldown = 2f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float boltDamage = 1f;

	[SerializeField]
	private GameObject iceBolt;

	private float timeTillNextTick;

	private bool effectRunning;

	private TaggedObject[] closestObject = new TaggedObject[1];

	[SerializeField]
	private List<TagManager.ETag> targetMustHaveTags;

	[SerializeField]
	private List<TagManager.ETag> targetMayNotHaveTags;

	private Transform playerTransform;

	public override void EnableEffectAtDusk()
	{
		effectRunning = true;
		timeTillNextTick = boltCooldown / 2f;
		playerTransform = PlayerMovement.instance.transform;
	}

	public override void DisableEffectAtDawn()
	{
		effectRunning = false;
	}

	private void Update()
	{
		if (effectRunning)
		{
			timeTillNextTick -= Time.deltaTime;
			if (timeTillNextTick <= 0f)
			{
				timeTillNextTick = boltCooldown;
				SpawnIceBolt();
			}
		}
	}

	private void SpawnIceBolt()
	{
		TagManager.instance.FindClosestTaggedObjectsWithTags(playerTransform.position, targetMustHaveTags, targetMayNotHaveTags, closestObject, 10000000f);
		Transform transform = null;
		Object.Instantiate(position: ((!(closestObject[0] == null)) ? closestObject[0].transform : playerTransform).position, original: iceBolt, rotation: Quaternion.identity).GetComponent<SpawnAttackAfter>().damageMultiplyer *= boltDamage;
	}
}

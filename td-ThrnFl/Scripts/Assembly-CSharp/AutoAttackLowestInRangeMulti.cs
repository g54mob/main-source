using UnityEngine;

public class AutoAttackLowestInRangeMulti : AutoAttack
{
	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int attackTargets = 3;

	[SerializeField]
	public bool excludeFullHealthTargets = true;

	[SerializeField]
	private float randomizeSpawnPosition;

	[SerializeField]
	private float randomizeProjectileSpeed;

	private TaggedObject[] targets;

	public override void Start()
	{
		base.Start();
		targets = new TaggedObject[attackTargets];
	}

	public override void Update()
	{
		cooldown -= Time.deltaTime;
		if (!(cooldown <= 0f))
		{
			return;
		}
		FindAutoAttackTargets(targets);
		cooldown += cooldownDuration * (1f + (1f - 2f * Random.value) * cooldownRandomization);
		TaggedObject[] array = targets;
		foreach (TaggedObject taggedObject in array)
		{
			if (!(taggedObject == null))
			{
				Vector3 vector = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * randomizeSpawnPosition;
				float num = 1f + (Random.value - 0.5f) * randomizeProjectileSpeed;
				weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up + vector, taggedObject.Hp, Vector3.zero, base.taggedObject, damageMultiplyer, num);
				lastTargetPosition = taggedObject.transform.position;
				onAttackTriggered.Invoke();
				onCooldown = true;
			}
		}
	}

	private void FindAutoAttackTargets(TaggedObject[] outAttacks)
	{
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			targetPriorities[i].FindLowestHealthTaggedObjects(base.transform.position, outAttacks, excludeFullHealthTargets);
			if (outAttacks[i] != null)
			{
				break;
			}
		}
	}
}

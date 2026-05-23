using UnityEngine;

public class AutoAttackTwoTargets : AutoAttack
{
	private TaggedObject[] targets = new TaggedObject[2];

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
				weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, taggedObject.Hp, Vector3.zero, base.taggedObject, damageMultiplyer);
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
			targetPriorities[i].FindClosestTaggedObjects(base.transform.position, outAttacks);
			if (outAttacks[i] != null)
			{
				break;
			}
		}
	}
}

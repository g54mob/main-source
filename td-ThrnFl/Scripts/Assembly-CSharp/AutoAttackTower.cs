using System.Collections.Generic;
using UnityEngine;

public class AutoAttackTower : AutoAttack
{
	public enum ETargetingMode
	{
		TargetClosest = 0,
		TargetRandom = 1,
		TargetHighestHealth = 2,
		TargetLowestHealthDamaging = 3,
		TargetLowestHealthHealing = 4
	}

	[Header("Tower Settings")]
	public ETargetingMode targetingMode;

	public int simultaneousProjectiles;

	private List<TaggedObject> attackTargets = new List<TaggedObject>();

	[HideInInspector]
	public TaggedObject[] tempCollectionArray = new TaggedObject[1];

	public override void Update()
	{
		cooldown -= Time.deltaTime;
		if (cooldown > 0f)
		{
			return;
		}
		FindAutoAttackTargets();
		bool flag = false;
		foreach (TaggedObject attackTarget in attackTargets)
		{
			if (!(attackTarget == null))
			{
				OnAttack(attackTarget);
				flag = true;
			}
		}
		if (flag)
		{
			cooldown += cooldownDuration * (1f + (1f - 2f * Random.value) * cooldownRandomization);
			return;
		}
		cooldown += recheckTargetInterval;
		onCooldown = false;
	}

	public void FindAutoAttackTargets()
	{
		attackTargets.Clear();
		for (int i = 0; i < tempCollectionArray.Length; i++)
		{
			tempCollectionArray[i] = null;
		}
		switch (targetingMode)
		{
		case ETargetingMode.TargetClosest:
		{
			for (int l = 0; l < targetPriorities.Count; l++)
			{
				targetPriorities[l].FindClosestTaggedObjects(base.transform.position, tempCollectionArray);
				TaggedObject[] array = tempCollectionArray;
				foreach (TaggedObject taggedObject2 in array)
				{
					if (taggedObject2 == null)
					{
						break;
					}
					attackTargets.Add(taggedObject2);
					if (attackTargets.Count >= simultaneousProjectiles)
					{
						return;
					}
				}
			}
			break;
		}
		case ETargetingMode.TargetRandom:
		{
			for (int n = 0; n < targetPriorities.Count; n++)
			{
				targetPriorities[n].FindRandomObjectsInRange(base.transform.position, tempCollectionArray);
				TaggedObject[] array = tempCollectionArray;
				foreach (TaggedObject taggedObject4 in array)
				{
					if (taggedObject4 == null)
					{
						break;
					}
					attackTargets.Add(taggedObject4);
					if (attackTargets.Count >= simultaneousProjectiles)
					{
						return;
					}
				}
			}
			break;
		}
		case ETargetingMode.TargetHighestHealth:
		{
			for (int num = 0; num < targetPriorities.Count; num++)
			{
				targetPriorities[num].FindHighestMaxHealthObjectsInRange(base.transform.position, tempCollectionArray);
				TaggedObject[] array = tempCollectionArray;
				foreach (TaggedObject taggedObject5 in array)
				{
					if (taggedObject5 == null)
					{
						break;
					}
					attackTargets.Add(taggedObject5);
					if (attackTargets.Count >= simultaneousProjectiles)
					{
						return;
					}
				}
			}
			break;
		}
		case ETargetingMode.TargetLowestHealthDamaging:
		{
			for (int m = 0; m < targetPriorities.Count; m++)
			{
				targetPriorities[m].FindLowestHealthObjectsInRange(base.transform.position, tempCollectionArray, _excludeFullHealthTargets: false);
				TaggedObject[] array = tempCollectionArray;
				foreach (TaggedObject taggedObject3 in array)
				{
					if (taggedObject3 == null)
					{
						break;
					}
					attackTargets.Add(taggedObject3);
					if (attackTargets.Count >= simultaneousProjectiles)
					{
						return;
					}
				}
			}
			break;
		}
		case ETargetingMode.TargetLowestHealthHealing:
		{
			for (int j = 0; j < targetPriorities.Count; j++)
			{
				targetPriorities[j].FindLowestHealthObjectsInRange(base.transform.position, tempCollectionArray);
				TaggedObject[] array = tempCollectionArray;
				foreach (TaggedObject taggedObject in array)
				{
					if (taggedObject == null)
					{
						break;
					}
					attackTargets.Add(taggedObject);
					if (attackTargets.Count >= simultaneousProjectiles)
					{
						return;
					}
				}
			}
			break;
		}
		}
	}

	public override void OnAttack(TaggedObject target)
	{
		Vector3 attackOrigin = base.transform.position + spawnAttackHeight * Vector3.up;
		if (optionalAttackOrigin != null)
		{
			attackOrigin = optionalAttackOrigin.position;
		}
		weapon.Attack(attackOrigin, target.Hp, Vector3.zero, taggedObject, damageMultiplyer, projectileSpeedMultiplyer);
		lastTargetPosition = target.transform.position;
		onAttackTriggered.Invoke();
		onCooldown = true;
	}
}

using UnityEngine;

public class StabMA : ManualAttack
{
	public float maximumCooldownTime = 15f;

	public float minimumCooldownPercentage = 0.2f;

	private int targetsStabbed;

	private AudioSet.ClipArray caSuccessfulHit;

	private AudioSet.ClipArray caFailedHit;

	public int TargetsStabeed => targetsStabbed;

	public override void Start()
	{
		base.Start();
		caSuccessfulHit = audioSet.PlayerBowStab;
		caFailedHit = audioSet.PlayerBowStabMiss;
	}

	public override void Attack()
	{
		TaggedObject taggedObject = FindAttackTarget(_choosePreferredTargetIfPossible: true);
		Hp hp = null;
		if ((bool)taggedObject)
		{
			hp = taggedObject.Hp;
			cooldownTime = maximumCooldownTime * (minimumCooldownPercentage + hp.HpPercentage * (1f - minimumCooldownPercentage));
			cooldown = cooldownTime;
			if (timedActivationPerfectly)
			{
				cooldown *= UpgradeAssassinsTraining.instance.cooldownMultiForPerfectlyTimedAttacks;
			}
		}
		float num = 0f;
		if ((bool)hp)
		{
			num = hp.HpValue;
		}
		weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, hp, transformForAttackDirection.forward, myTaggedObj, base.AttackDamageMultiplyer);
		if ((bool)hp)
		{
			if (num > hp.HpValue)
			{
				StabSuccessful();
			}
			else
			{
				StabMissed();
			}
		}
		else if (num > 0f)
		{
			StabSuccessful();
		}
		else
		{
			StabMissed();
		}
	}

	private void StabSuccessful()
	{
		audioManager.PlaySoundAsOneShot(caSuccessfulHit, 1f, Random.Range(0.9f, 1.1f), audioSet.mixGroupFX, 5);
		targetsStabbed++;
	}

	private void StabMissed()
	{
		audioManager.PlaySoundAsOneShot(caFailedHit, 1f, Random.Range(0.9f, 1.1f), audioSet.mixGroupFX, 5);
	}

	public override TaggedObject FindAttackTarget(bool _choosePreferredTargetIfPossible = false)
	{
		if (_choosePreferredTargetIfPossible && (bool)preferredTarget && TagManager.instance.MeasureDistanceToTaggedObject(preferredTarget, base.transform.position) <= targetPriorities[0].range)
		{
			return preferredTarget;
		}
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			TaggedObject taggedObject = targetPriorities[i].FindLowestHealthObjectInRange(base.transform.position, _excludeFullHealthTargets: false);
			if (taggedObject != null)
			{
				return taggedObject;
			}
		}
		return null;
	}
}

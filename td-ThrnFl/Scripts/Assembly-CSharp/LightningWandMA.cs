using System.Collections.Generic;
using UnityEngine;

public class LightningWandMA : ManualAttack
{
	private List<TaggedObject> possibleAttackTargets = new List<TaggedObject>();

	private TagManager tagManager;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float distanceBetweenAttacks;

	public override void Start()
	{
		base.Start();
		tagManager = TagManager.instance;
	}

	public override void Attack()
	{
		if ((bool)particlesOnAttack)
		{
			particlesOnAttack.Play();
		}
		if (playOneShotOnAttack)
		{
			ThronefallAudioManager.Oneshot(oneshotOnAttack);
		}
		TaggedObject taggedObject = FindAttackTarget(_choosePreferredTargetIfPossible: true);
		if (!taggedObject)
		{
			return;
		}
		_ = taggedObject.Hp;
		lastTargetPos = taggedObject.transform.position;
		onAttack.Invoke();
		tagManager.FindAllTaggedObjectsWithTags(possibleAttackTargets, targetPriorities[0].mustHaveTags, targetPriorities[0].mayNotHaveTags);
		float range = targetPriorities[0].range;
		for (int num = possibleAttackTargets.Count - 1; num >= 0; num--)
		{
			if (tagManager.MeasureDistanceToTaggedObject(possibleAttackTargets[num], base.transform.position) > range)
			{
				possibleAttackTargets.RemoveAt(num);
			}
		}
		for (int num2 = possibleAttackTargets.Count - 1; num2 >= 0; num2--)
		{
			for (int num3 = possibleAttackTargets.Count - 1; num3 >= 0; num3--)
			{
				if (num2 != num3 && Vector3.Distance(possibleAttackTargets[num2].transform.position, possibleAttackTargets[num3].transform.position) < distanceBetweenAttacks && possibleAttackTargets[num3] != taggedObject)
				{
					possibleAttackTargets.RemoveAt(num3);
					if (num3 < num2)
					{
						num2--;
					}
				}
			}
		}
		foreach (TaggedObject possibleAttackTarget in possibleAttackTargets)
		{
			Hp hp = possibleAttackTarget.Hp;
			if ((bool)hp)
			{
				weapon.Attack(base.transform.position + spawnAttackHeight * Vector3.up, hp, transformForAttackDirection.forward, myTaggedObj, base.AttackDamageMultiplyer);
			}
		}
	}
}

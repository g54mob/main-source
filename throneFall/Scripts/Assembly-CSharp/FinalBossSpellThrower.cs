using UnityEngine;

public class FinalBossSpellThrower : AutoAttack
{
	public override void OnAttack(TaggedObject target)
	{
		Vector3 vector = base.transform.position + spawnAttackHeight * Vector3.up;
		if (optionalAttackOrigin != null)
		{
			vector = optionalAttackOrigin.position;
		}
		weapon.Attack(vector, null, target.transform.position - vector, taggedObject, damageMultiplyer, projectileSpeedMultiplyer);
		lastTargetPosition = target.transform.position;
		onAttackTriggered.Invoke();
		onCooldown = true;
	}
}

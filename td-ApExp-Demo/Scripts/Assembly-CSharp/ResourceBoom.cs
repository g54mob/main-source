using UnityEngine;

public class ResourceBoom : ResourceBox
{
	[SerializeField]
	private float boomEnemyDamage;

	[SerializeField]
	private float boomRadius;

	[SerializeField]
	private GameObject explosionPrefab;

	public override ResourceBoxData OnGrab(float gainMult)
	{
		if (base.gameObject == null)
		{
			return null;
		}
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(claw, boomRadius, boomEnemyDamage);
		claw.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(claw, claw.HealthComponent, 0f - claw.HealthComponent.HealthCurrent, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: false, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: false, DamageType.God));
		if (base.gameObject != null)
		{
			Object.Destroy(base.gameObject, 0.01f);
		}
		return new ResourceBoxData(base.transform.position, 0f, ResourceTypes.Ammo);
	}
}

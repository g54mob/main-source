using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
	[SerializeField]
	private BuildSlot buildSlot;

	[SerializeField]
	private AutoAttackTower autoAttackTower;

	[SerializeField]
	private bool overrideTargetingMode;

	[SerializeField]
	private AutoAttackTower.ETargetingMode targetingMode;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float attackCooldownMulti = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float rangeMulti = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float projectileSpeedMulti = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float damageMulti = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private int additionalArrowsToShoot;

	[SerializeField]
	private Equippable equippableForOneExtraProjectile;

	[SerializeField]
	private Weapon replaceWeapon;

	[SerializeField]
	private bool changeToHealing;

	[SerializeField]
	private bool insertTargetPriority;

	[SerializeField]
	private TargetPriority targetPriority;

	[Header("Move Spire Height")]
	[SerializeField]
	private Transform spireTransform;

	[SerializeField]
	private Transform healthBarTransform;

	[SerializeField]
	private float adjustHeight;

	public float RangeMulti => rangeMulti;

	private void OnEnable()
	{
		if (overrideTargetingMode)
		{
			autoAttackTower.targetingMode = targetingMode;
		}
		autoAttackTower.cooldownDuration *= attackCooldownMulti;
		foreach (TargetPriority targetPriority in autoAttackTower.targetPriorities)
		{
			targetPriority.range *= rangeMulti;
		}
		autoAttackTower.ProjectileSpeedMultiplyer *= projectileSpeedMulti;
		autoAttackTower.DamageMultiplyer *= damageMulti;
		if (PerkManager.IsEquipped(equippableForOneExtraProjectile))
		{
			additionalArrowsToShoot++;
		}
		if (additionalArrowsToShoot > 0)
		{
			autoAttackTower.simultaneousProjectiles += additionalArrowsToShoot;
			autoAttackTower.tempCollectionArray = new TaggedObject[autoAttackTower.simultaneousProjectiles];
		}
		if ((bool)replaceWeapon)
		{
			autoAttackTower.weapon = replaceWeapon;
		}
		if (changeToHealing)
		{
			foreach (TargetPriority targetPriority2 in autoAttackTower.targetPriorities)
			{
				List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>
				{
					TagManager.ETag.PlayerOwned,
					TagManager.ETag.AUTO_Alive
				};
				List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag> { TagManager.ETag.Building };
				targetPriority2.mustHaveTags = mustHaveTags;
				targetPriority2.mayNotHaveTags = mayNotHaveTags;
			}
		}
		if (insertTargetPriority)
		{
			float range = autoAttackTower.targetPriorities[0].range;
			autoAttackTower.targetPriorities.Insert(0, this.targetPriority);
			autoAttackTower.targetPriorities[0].range = range;
		}
		if ((bool)spireTransform)
		{
			spireTransform.position += Vector3.up * adjustHeight;
		}
		if ((bool)healthBarTransform)
		{
			healthBarTransform.position += Vector3.up * adjustHeight;
		}
		Object.Destroy(this);
	}
}

using System.Collections.Generic;
using UnityEngine;

public class AutoAttack_collisionCheck : TowerAutoAttack
{
	[SerializeField]
	private Transform[] collisionPositions;

	[SerializeField]
	private bool useRangeAsRadius;

	[SerializeField]
	private float collisionsRadius = 1f;

	[SerializeField]
	private LayerMask layersToCheck;

	[SerializeField]
	[Tooltip("Should it do damage on activate or be driven by an animation event?")]
	private bool damageOnActivate = true;

	protected TowerCombatComponent towerCC;

	protected override void Start()
	{
		base.Start();
		towerCC = abilityManager.CombatComponent as TowerCombatComponent;
		if (!damageOnActivate)
		{
			abilityManager.AnimationComponent.onAnimationDoDamage += OnAnimationDoDamage;
		}
	}

	protected override void OnActivate(FActiveAbilityInputData inputData)
	{
		if (damageOnActivate)
		{
			DoDamage();
		}
		PlayAnimation();
		ApplyCooldown();
		EndAbility();
	}

	private void DoDamage()
	{
		List<Enemy> list = new List<Enemy>();
		float radius = (useRangeAsRadius ? abilityManager.StatsComponent.GetStat(EStats.Range) : collisionsRadius);
		Transform[] array = collisionPositions;
		foreach (Transform transform in array)
		{
			Collider[] array2 = Physics.OverlapSphere(abilityManager.transform.position + transform.localPosition, radius, layersToCheck);
			foreach (Collider collider in array2)
			{
				if ((bool)collider.attachedRigidbody && collider.attachedRigidbody.gameObject.CompareTag("Enemy") && collider.attachedRigidbody.TryGetComponent<Enemy>(out var component) && towerCC.CanTargetEnemy(component))
				{
					list.AddUnique(component);
				}
			}
		}
		foreach (Enemy item in list)
		{
			FDamageData damageData = new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage), towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier);
			(abilityManager.CombatComponent as TowerCombatComponent).DoDamageToEnemy(item, damageData, item.transform.position, isMainDamage: true);
		}
	}

	protected override void OnAnimationDoDamage()
	{
		DoDamage();
	}

	private void OnDrawGizmosSelected()
	{
		if (!useRangeAsRadius)
		{
			Gizmos.color = Color.green;
			Transform[] array = collisionPositions;
			for (int i = 0; i < array.Length; i++)
			{
				Gizmos.DrawWireSphere(array[i].position, collisionsRadius);
			}
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GE_DirectDamageChain : GameplayEffect
{
	private GE_DirectDamageChainData directDamageChainData;

	private TowerCombatComponent towerCC;

	private AbilityManager abilityManager;

	private List<DirectDamageParticles> particles;

	protected override void OnInitEffect()
	{
		directDamageChainData = base.EffectData as GE_DirectDamageChainData;
		towerCC = base.Owner.GetComponent<TowerCombatComponent>();
		abilityManager = base.Owner.GetComponent<AbilityManager>();
		particles = new List<DirectDamageParticles>();
		for (int i = 0; i < directDamageChainData.ChainAmount; i++)
		{
			particles.Add(Object.Instantiate(directDamageChainData.DirectDamageParticlesPrefab, abilityManager.transform));
		}
		(abilityManager.GetAutoAttackAbility() as AutoAttack_directDamage).onDirectDamage += OnDirectDamage;
	}

	protected override void OnEndEffect()
	{
		(abilityManager.GetAutoAttackAbility() as AutoAttack_directDamage).onDirectDamage -= OnDirectDamage;
		for (int num = particles.Count - 1; num >= 0; num--)
		{
			Object.Destroy(particles[num]);
		}
	}

	private void OnDirectDamage(Enemy enemy, Vector3 targetPosition, FDamageData damageData)
	{
		if (!abilityManager)
		{
			return;
		}
		List<Enemy> list = new List<Enemy>();
		list.Add(enemy);
		Vector3 lastChainPosition = targetPosition;
		damageData.damage *= directDamageChainData.ChainDamageMultiplier;
		for (int i = 0; i < directDamageChainData.ChainAmount; i++)
		{
			Collider[] array = Physics.OverlapSphere(lastChainPosition, directDamageChainData.ChainRadius, LayerMask.GetMask("Enemy"));
			if (array == null || array.Length == 0)
			{
				break;
			}
			array = array.OrderBy((Collider c) => Vector3.SqrMagnitude(lastChainPosition - c.transform.position)).ToArray();
			Collider[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				if (array2[num].TryGetComponent<Enemy>(out var component) && !list.Contains(component) && component.CombatComponent.IsAlive() && towerCC.CanTargetEnemy(component))
				{
					towerCC.DoDamageToEnemy(component, damageData, component.CombatComponent.TargetObject.transform.position, isMainDamage: true);
					particles[list.Count - 1].StartParticles(lastChainPosition, component.CombatComponent.TargetObject.transform.position, component);
					lastChainPosition = component.transform.position;
					list.Add(component);
					break;
				}
			}
		}
	}
}

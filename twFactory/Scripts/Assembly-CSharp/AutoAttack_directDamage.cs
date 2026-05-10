using System;
using UnityEngine;

public class AutoAttack_directDamage : TowerAutoAttack
{
	[Header("Direct Damage")]
	[SerializeField]
	[Tooltip("Should it do damage on activate or be driven by an animation event?")]
	private bool damageOnActivate = true;

	[SerializeField]
	private DirectDamageParticles directDamageParticlesPrefab;

	[SerializeField]
	private Vector3 particlesEmitterLocalPosition;

	private DirectDamageParticles particles;

	protected TowerCombatComponent towerCC;

	protected Tower tower;

	public event Action<Enemy, Vector3, FDamageData> onDirectDamage;

	protected override void Awake()
	{
		base.Awake();
		particles = UnityEngine.Object.Instantiate(directDamageParticlesPrefab, abilityManager.transform);
	}

	protected override void Start()
	{
		base.Start();
		towerCC = abilityManager.CombatComponent as TowerCombatComponent;
		tower = abilityManager.GetComponent<Tower>();
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

	protected virtual bool DoDamage()
	{
		Vector3 vector = tower.Target?.CombatComponent.TargetObject.transform.position ?? tower.transform.position;
		if ((bool)tower.Target && tower.Target.CombatComponent.IsAlive())
		{
			FDamageData fDamageData = new FDamageData(abilityManager.StatsComponent.GetStat(EStats.BaseDamage), towerCC.HealthMultiplier, towerCC.ArmorMultiplier, towerCC.ShieldMultiplier);
			(abilityManager.CombatComponent as TowerCombatComponent).DoDamageToEnemy(tower.Target, fDamageData, tower.Target.transform.position, isMainDamage: true);
			particles.StartParticles(abilityManager.transform.position + particlesEmitterLocalPosition, vector, tower.Target);
			this.onDirectDamage?.Invoke(tower.Target, vector, fDamageData);
			return true;
		}
		return false;
	}

	protected override void OnAnimationDoDamage()
	{
		DoDamage();
	}
}

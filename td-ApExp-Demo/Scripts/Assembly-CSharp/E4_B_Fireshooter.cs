using UnityEngine;

public class E4_B_Fireshooter : E4_B_Servant
{
	[Header("Fireshooter Fields")]
	[SerializeField]
	private int burnAmount;

	private new void Awake()
	{
		base.Awake();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_B_Fireshooter_Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
		Burn = burnAmount;
	}

	private new void Start()
	{
		base.Start();
		Target();
	}

	private new void Update()
	{
		base.Update();
		CheckTarget();
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f))
		{
			shotTimer = timeBetweenShots;
			base.HeadAnim.Play("FireshooterHeadShoot");
			ProjectileFireshooterFireball component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<ProjectileFireshooterFireball>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.SetTarget(base.TargetUnit);
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.isEnemyProjectile = base.IsEnemy;
			component.burn = Burn;
			if (base.IsEnemy)
			{
				component.damage = base.TrainDamage;
			}
			else
			{
				component.damage = base.EnemyDamage;
			}
			soundBuilder.Play(shootSound);
			Retarget();
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
	}
}

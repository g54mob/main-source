using UnityEngine;

public class E4_B_Rocketeer : E4_B_Servant
{
	private new void Awake()
	{
		base.Awake();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_B_Rocketeer_Idle(sm, this),
			new BEMPState(sm, this, "Idle")
		};
		stateMachine.BuildStateDictionary(newStates);
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
			base.HeadAnim.Play("RocketeerHeadShoot");
			APCMissile component = Object.Instantiate(bullet, muzzleTF.position, Quaternion.identity).GetComponent<APCMissile>();
			component.IsEnemy = base.IsEnemy;
			component.TargetUnit = base.TargetUnit;
			component.parentEnemy = this;
			component.MoveSpeed = projSpeed;
			component.OnHit += base.OnTargetDamaged;
			component.RemoveFlyStraightTimer();
			component.TurnSpeed = 180f;
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

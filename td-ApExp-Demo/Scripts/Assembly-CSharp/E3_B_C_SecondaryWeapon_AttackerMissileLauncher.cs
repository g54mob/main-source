using System.Collections;
using UnityEngine;

public class E3_B_C_SecondaryWeapon_AttackerMissileLauncher : E3_B_C_SecondaryWeapon
{
	[Header("Attacker Fields")]
	[SerializeField]
	private Transform muzzle1TF;

	[SerializeField]
	private Transform muzzle2TF;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[4]
		{
			new E3_B_C_Attacker_Idle(sm, this),
			new E3_B_C_Attacker_Attack(sm, this),
			new BEMPState(sm, this, "Idle"),
			new E3_B_C_Attacker_Retreat(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
		}
	}

	public override void Shoot()
	{
		StartCoroutine(ShootCoroutine());
		IEnumerator ShootCoroutine()
		{
			StealthMissile component = Object.Instantiate(bullet, muzzle1TF.position, muzzle1TF.rotation).GetComponent<StealthMissile>();
			component.IsEnemy = base.IsEnemy;
			component.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			component.parentBomber = this;
			component.skipLaunchAnimation = true;
			yield return new WaitForSeconds(timeBetweenShots);
			StealthMissile component2 = Object.Instantiate(bullet, muzzle2TF.position, muzzle2TF.rotation).GetComponent<StealthMissile>();
			component2.IsEnemy = base.IsEnemy;
			component2.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
			component2.parentBomber = this;
			component2.skipLaunchAnimation = true;
			AttackComplete = true;
		}
	}
}

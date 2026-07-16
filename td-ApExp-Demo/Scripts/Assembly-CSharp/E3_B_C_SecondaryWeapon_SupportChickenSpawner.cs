using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_B_C_SecondaryWeapon_SupportChickenSpawner : E3_B_C_SecondaryWeapon
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
			new E3_B_C_Support_Idle(sm, this),
			new E3_B_C_Support_Attack(sm, this),
			new BEMPState(sm, this, "Idle"),
			new E3_B_C_Support_Retreat(sm, this)
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

	public override void Move()
	{
	}

	public override void Aim()
	{
	}

	public override void Shoot()
	{
		StartCoroutine(ShootCoroutine());
		IEnumerator ShootCoroutine()
		{
			List<Module> potentialTargets = new List<Module>(UnitHelper.GetRandomUnbrokenModule(this));
			foreach (Module item2 in potentialTargets)
			{
				if (item2 is ModuleCannon)
				{
					potentialTargets.Remove(item2);
					break;
				}
			}
			for (int i = 0; i < 2; i++)
			{
				if (potentialTargets.Count > 0)
				{
					E3_6_Chicken component = Object.Instantiate(bullet, muzzle1TF.position, muzzle1TF.rotation).GetComponent<E3_6_Chicken>();
					component.IsEnemy = base.IsEnemy;
					Module item = (Module)(component.TargetUnit = potentialTargets[Random.Range(0, potentialTargets.Count - 1)]);
					potentialTargets.Remove(item);
				}
				yield return new WaitForSeconds(0.5f);
			}
			AttackComplete = true;
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E3Bomber : EnemyBase
{
	[SerializeField]
	[Range(0f, 5f)]
	private float movementSpeedBoostOnHack = 3f;

	private float preHackMoveSpeed;

	protected new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E1_3MoveIntoTrain(sm, this),
			new BEMPState(sm, this, "E3MoveIntoTrain")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		base.Update();
		if (base.TargetUnit == null)
		{
			Target();
		}
	}

	public override void Target()
	{
		base.TargetUnit = null;
		Unit[] enemyUnits = UnitHelper.GetEnemyUnits(this);
		if (enemyUnits != null && enemyUnits.Length != 0)
		{
			base.TargetUnit = enemyUnits.OrderBy((Unit u) => Vector3.Distance(base.transform.position, u.transform.position), Comparer<float>.Default).FirstOrDefault();
		}
	}

	public override void Aim()
	{
		Vector3 upwards = Vector3.zero;
		if (base.TargetUnit != null)
		{
			upwards = (base.TargetUnit.transform.position - base.transform.position).normalized;
		}
		Quaternion b = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
		deathExplosion.Initialize(this, explosionScale, damage);
	}

	public void ReachedTrainExplosion()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation).GetComponent<Explosion>().Initialize(this, explosionScale, 0f, 10f);
		Object.Destroy(base.transform.gameObject);
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
		if (IsHacked)
		{
			preHackMoveSpeed = base.MoveSpeed;
			base.MoveSpeed += base.MoveSpeed * movementSpeedBoostOnHack;
		}
		else
		{
			base.MoveSpeed = preHackMoveSpeed;
		}
	}
}

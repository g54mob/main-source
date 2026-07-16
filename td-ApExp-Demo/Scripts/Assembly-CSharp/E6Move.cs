using UnityEngine;

public class E6Move : StateBaseEnemy
{
	private float randomNormalize;

	public override string Key => "Move";

	public E6Move(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
	}

	public E6Move(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.Target();
		randomNormalize = ((Random.Range(0, 2) != 0) ? 1 : (-1));
	}

	public override void UpdateState()
	{
		enemy.Shoot();
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemy.transform.RotateAround(Train.Instance.transform.position, Vector3.forward, enemy.MoveSpeed * randomNormalize * Time.deltaTime);
		enemy.Aim();
	}

	public override bool CanExit()
	{
		return false;
	}

	public override void ExitState()
	{
	}
}

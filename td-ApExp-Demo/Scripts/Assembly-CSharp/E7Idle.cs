using UnityEngine;

public class E7Idle : BIdleState
{
	public E7Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Move" };
	}

	public E7Idle(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void UpdateState()
	{
		base.UpdateState();
		Vector3 dir = new Vector3(enemy.transform.position.x, Train.Instance.Wagons[0].transform.position.y) - enemy.transform.position;
		if (enemy.RotateTowardsDirection(dir))
		{
			enemy.Anim.Play("SpriteSway", 0);
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return base.CanExit();
	}
}

using UnityEngine;

public class BMoveState : StateBaseEnemy
{
	protected bool movingAway;

	protected Vector3 enemyMoveAwayPosition;

	protected float randomSpeedModifier;

	protected float topOfView = 1.6f;

	protected float bottomOfView = -1.6f;

	public override string Key => "Move";

	public BMoveState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public BMoveState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		if (!enemy.IsDistanceToTrainCorrect())
		{
			return true;
		}
		return false;
	}

	public override void EnterState()
	{
		enemy.farStoppingDistance = Random.Range(enemy.closeStoppingDistance + 0.1f, enemy.maxStoppingDistance);
		randomSpeedModifier = Random.Range(1f, 4f);
		enemy.Anim.Play("None", 0, 0f);
	}

	public override void UpdateState()
	{
		Vector3 vector = Train.Instance.transform.position - enemy.transform.position;
		bool flag = enemy.transform.position.y < enemy.closeStoppingDistance && enemy.transform.position.y > 0f - enemy.closeStoppingDistance;
		enemy.transform.Translate(vector.normalized * ((!flag) ? 1 : (-1)) * enemy.MoveSpeed * Time.deltaTime, Space.World);
		enemy.Aim();
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
	}
}

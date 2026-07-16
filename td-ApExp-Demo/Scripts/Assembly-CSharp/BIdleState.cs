using UnityEngine;

public class BIdleState : StateBaseEnemy
{
	protected float movingTimer;

	protected float movingTime;

	protected Vector3 moveDestination;

	protected int movingDirection;

	protected int numberOfSameDirections;

	protected const int MAX_AMOUNT_OF_SAME_DIRECTIONS = 2;

	public override string Key => "Idle";

	public BIdleState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Move" };
	}

	public BIdleState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		if (!enemy.IsDistanceToTrainCorrect())
		{
			return false;
		}
		return true;
	}

	public override void EnterState()
	{
		movingTimer = 0f;
		movingTime = 0.5f;
		movingDirection = Random.Range(0, 2) * 2 - 1;
		moveDestination = enemy.transform.position + new Vector3(movingDirection, 0f, 0f);
	}

	public override void UpdateState()
	{
		movingTimer += Time.deltaTime;
		if (movingTimer >= movingTime)
		{
			movingTimer = 0f;
			moveDestination = enemy.transform.position + new Vector3(movingDirection, 0f, 0f);
			if (numberOfSameDirections > 2 || numberOfSameDirections < -2)
			{
				movingDirection *= -1;
				numberOfSameDirections += movingDirection;
			}
			else
			{
				movingDirection = Random.Range(0, 2) * 2 - 1;
				numberOfSameDirections += movingDirection;
			}
		}
		Vector2 neighborAvoidanceVector = enemy.GetNeighborAvoidanceVector();
		Vector2 target = (Vector2)moveDestination + neighborAvoidanceVector;
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target, enemy.MoveSpeed * Time.deltaTime);
		if ((!(enemy is E7Wall) && enemy.RotateTowardsDirection(Vector3.right)) || enemy is E4Cocoon)
		{
			enemy.Anim.Play("SpriteSway", 0);
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemy.empDuration <= 0f;
	}
}

using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyJumpBack : MonoBehaviour
{
	public int jumpAmount = 5;

	private Enemy myEnemy;

	private void HandleStateChange(Character c, Enemy.State newState, Enemy.State oldState)
	{
		if (oldState == Enemy.State.Attacking && newState == Enemy.State.Engaging)
		{
			int a = myEnemy.PositionX + jumpAmount;
			a = Mathf.Min(a, GameStates.Singleton.level.GetEnemyLimitX(c));
			myEnemy.PositionX = a;
		}
	}

	private void Awake()
	{
		myEnemy = GetComponent<Enemy>();
		myEnemy.OnEnemyStateChange += HandleStateChange;
	}

	private void OnDestroy()
	{
		myEnemy.OnEnemyStateChange -= HandleStateChange;
	}
}

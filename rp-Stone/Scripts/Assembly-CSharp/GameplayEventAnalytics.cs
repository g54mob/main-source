using UnityEngine;

public class GameplayEventAnalytics : MonoBehaviour
{
	private void HandleOnEnemyEngaged(Enemy enemy)
	{
		AnalyticsMacros.FirstEnemyEngaged();
		Enemy.OnEnemyEngaged -= HandleOnEnemyEngaged;
	}

	private void Awake()
	{
		Enemy.OnEnemyEngaged += HandleOnEnemyEngaged;
	}

	private void OnDestroy()
	{
		Enemy.OnEnemyEngaged -= HandleOnEnemyEngaged;
	}
}

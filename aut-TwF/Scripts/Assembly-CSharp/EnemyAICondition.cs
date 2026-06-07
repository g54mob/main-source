using LightTower;
using UnityEngine;

public abstract class EnemyAICondition : ScriptableObject
{
	public abstract bool CheckCondition(EnemyController enemyController);
}

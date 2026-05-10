using LightTower;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAICondition_DistanceFromEnd", menuName = "Tower Factory/Enemy AI/Conditions/Distance From End")]
public class EnemyAICondition_DistanceFromEnd : EnemyAICondition
{
	[SerializeField]
	[Tooltip("El valor con el que se comparan la distancia al final del camino, a la derecha del operador")]
	private int comparedToAmount;

	[SerializeField]
	private EComparison comparison;

	public override bool CheckCondition(EnemyController enemyController)
	{
		return FunctionLibrary.Compare(GetTilesFromEnd(enemyController), comparedToAmount, comparison);
	}

	private int GetTilesFromEnd(EnemyController enemyController)
	{
		return enemyController.EnemyMovement.CurrentPathTile.TilesFromEnd;
	}
}

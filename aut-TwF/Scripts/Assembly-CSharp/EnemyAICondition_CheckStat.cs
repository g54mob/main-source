using LightTower;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAICondition_CheckStat", menuName = "Tower Factory/Enemy AI/Conditions/Check Stat")]
public class EnemyAICondition_CheckStat : EnemyAICondition
{
	public enum ECheckType
	{
		Normal = 0,
		Percentage = 1
	}

	[SerializeField]
	private ECheckType checkType;

	[SerializeField]
	private EStats stat;

	[SerializeField]
	private EComparison comparison;

	[SerializeField]
	[Tooltip("El valor con el que se compara el stat. A la derecha del operador")]
	private float comparedToAmount;

	public override bool CheckCondition(EnemyController enemyController)
	{
		return FunctionLibrary.Compare(GetStatValue(enemyController), comparedToAmount, comparison);
	}

	private float GetStatValue(EnemyController enemyController)
	{
		if (checkType == ECheckType.Normal)
		{
			return (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(stat);
		}
		return stat switch
		{
			EStats.Health => (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.Health) / (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.HealthMax), 
			EStats.Armor => (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.Armor) / (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.ArmorMax), 
			EStats.Shield => (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.Shield) / (enemyController.ControlledCharacter as Enemy).StatsComponent.GetStat(EStats.ShieldMax), 
			_ => 0f, 
		};
	}
}

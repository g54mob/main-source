using UnityEngine;

[CreateAssetMenu(fileName = "GE_giveEffectToEnemyData_default", menuName = "Tower Factory/GameplayEffect/Player/Give Effect To Enemy")]
public class GE_GiveEffectToEnemyData : GameplayEffectData
{
	[Header("Give effect to enemy")]
	[SerializeField]
	private bool affectAllEnemies = true;

	[SerializeField]
	private EnemyData[] affectedEnemies;

	[SerializeField]
	private GameplayEffectData[] effectsToApply;

	public bool AffectAllEnemies => affectAllEnemies;

	public EnemyData[] AffectedEnemies => affectedEnemies;

	public GameplayEffectData[] EffectsToApply => effectsToApply;

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_GiveEffectToEnemy();
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	public bool IsAffected(EnemyData enemyData)
	{
		if (!AffectAllEnemies)
		{
			if (AffectedEnemies != null)
			{
				return affectedEnemies.Contains(enemyData);
			}
			return false;
		}
		return true;
	}
}

using System;

[Serializable]
public class MonsterDamageDebuff
{
	private AMonsterBase monster;

	private float duration;

	private float tickInterval;

	private int damagePerTick;

	private eDamageType damageType;

	private float tickTimer;

	private float totalTimer;

	private int sourceID;

	private ABaseTower fromTower;

	private static readonly float TICK_INTERVAL_POISON;

	private static readonly float TICK_INTERVAL_BURNING;

	private static readonly float TICK_INTERVAL_DEFAULT;

	public bool IsFinished { get; private set; }

	public MonsterDamageDebuff(AMonsterBase monster, float duration, float tickInterval, int damagePerTick, eDamageType damageType, int sourceID, ABaseTower fromTower = null)
	{
	}

	public void RenewDebuff(float duration, float tickInterval, int damagePerTick)
	{
	}

	public void Update(float deltaTime)
	{
	}

	public bool IsDamageType(eDamageType damageType)
	{
		return false;
	}

	public bool IsSameSource(int sourceID, eDamageType damageType)
	{
		return false;
	}

	public eDamageType GetDamageType()
	{
		return default(eDamageType);
	}

	public int GetTotalRemainingDamage()
	{
		return 0;
	}

	private void DealDamage()
	{
	}
}

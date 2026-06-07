using System;

[Serializable]
public class PoisonEffect
{
	private int totalDamage;

	private int remainingDamage;

	private ABaseTower fromTower;

	public int RemainingDamage => 0;

	public ABaseTower FromTower => null;

	public bool IsFinished => false;

	public PoisonEffect(int damage, ABaseTower tower)
	{
	}

	public void Update(int tickDamage = 1)
	{
	}

	private void SubtractDamage(int value)
	{
	}

	public int GetNextTickDamage()
	{
		return 0;
	}
}

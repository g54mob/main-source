using System;

[Serializable]
public class MstEnemyLevelEntities
{
	public int id;

	public eStageDivision division;

	public int level;

	public eEnemy enemy;

	public string description;

	public double baseFrequencyPerMinutes;

	public int maxEmissionCount;

	public float firstDelay;

	public int baseValue;

	public double enemySpan;

	public int hp;

	public int attack;

	public float speed;

	public int townAttack;

	public int shield;
}

public class Enemy
{
	public string name;

	public enemyType enemyType;

	public AI AI;

	public float attackRate;

	public float attack;

	public float defense;

	public float regen;

	public float curHP;

	public float maxHP;

	public int spriteID;

	public Enemy(string enemyname, float AR, float atk, float def, float reg, float hp, enemyType type, AI ai)
	{
		name = enemyname;
		attackRate = AR;
		attack = atk;
		defense = def;
		regen = reg;
		curHP = hp;
		maxHP = hp;
		enemyType = type;
		AI = ai;
		spriteID = 0;
	}

	public Enemy(string enemyname, float AR, float atk, float def, float reg, float hp, enemyType type, AI ai, int sprID)
	{
		name = enemyname;
		attackRate = AR;
		attack = atk;
		defense = def;
		regen = reg;
		curHP = hp;
		maxHP = hp;
		enemyType = type;
		AI = ai;
		spriteID = sprID;
	}

	public Enemy()
	{
		attackRate = 0f;
		attack = 10f;
		defense = 10f;
		regen = 1f;
		curHP = 10f;
		maxHP = 10f;
		enemyType = enemyType.normal;
		spriteID = 0;
	}

	public Enemy(Enemy oldEnemy)
	{
		name = oldEnemy.name;
		attackRate = oldEnemy.attackRate;
		attack = oldEnemy.attack;
		defense = oldEnemy.defense;
		regen = oldEnemy.regen;
		curHP = oldEnemy.curHP;
		maxHP = oldEnemy.maxHP;
		enemyType = oldEnemy.enemyType;
		AI = oldEnemy.AI;
		spriteID = oldEnemy.spriteID;
	}
}

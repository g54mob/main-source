using UnityEngine;

public class DashStatMod : StatModifier
{
	public Decoration dashVfxPrefab;

	public StatModifier applyToEnemies;

	public int aoeX = 5;

	public int aoeZ = 3;

	public float shakeCameraAmount;

	public float camShakeDuration;

	public float slowMotionDuration;

	private int keepRange = 3;

	private int minDashDistance = 11;

	private int maxDashDistance = 16;

	public int dashCooldown = 30;

	private AbilityClock clock;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (!(clock.GetPercent() >= 1f))
		{
			return;
		}
		Hero hero = GameStates.Singleton.hero;
		if (!(base.character == hero))
		{
			return;
		}
		Enemy targetEnemy = hero.GetComponent<HeroAI>().targetEnemy;
		if (!(targetEnemy != null))
		{
			return;
		}
		int num = targetEnemy.PositionX - hero.PositionX;
		if (num > maxDashDistance || num < minDashDistance)
		{
			return;
		}
		int num2 = targetEnemy.PositionY - hero.PositionY;
		if (num2 < -1 || num2 > 1)
		{
			return;
		}
		for (int i = 0; i < GameStates.Singleton.level.Enemies.Count; i++)
		{
			Enemy enemy = GameStates.Singleton.level.Enemies[i];
			if (enemy.Alive && enemy.PositionX >= hero.PositionX && enemy != targetEnemy && enemy.PositionX < targetEnemy.PositionX)
			{
				return;
			}
		}
		clock.duration = dashCooldown;
		clock.Play();
		DashTo(targetEnemy.PositionX - keepRange, targetEnemy.PositionZ);
	}

	private void DashTo(int x, int z)
	{
		Decoration decoration = Object.Instantiate(dashVfxPrefab);
		decoration.PositionX = base.character.PositionX;
		decoration.PositionY = base.character.PositionY;
		decoration.PositionZ = base.character.PositionZ;
		GameStates.Singleton.level.AddCharacter(decoration);
		base.character.PositionX = x;
		base.character.PositionZ = z;
		if (applyToEnemies != null)
		{
			float num = ComputeStatValue();
			int num2 = Mathf.FloorToInt(num * 30f);
			int num3 = 0;
			for (int i = 0; i < GameStates.Singleton.level.Enemies.Count; i++)
			{
				Enemy enemy = GameStates.Singleton.level.Enemies[i];
				if (enemy.Alive)
				{
					int num4 = Mathf.Abs(enemy.PositionX - x);
					int num5 = Mathf.Abs(enemy.PositionZ - z);
					int num6 = (enemy.CollisionWidth + 1) / 2 + aoeX;
					int num7 = (enemy.CollisionDepth + 1) / 2 + aoeZ;
					if (num4 < num6 && num5 < num7)
					{
						num3++;
						StatModifier statModifier = Object.Instantiate(applyToEnemies);
						statModifier.statData = new ItemData.Stat();
						statModifier.statData.type = ItemData.Stat.Type.Stun;
						statModifier.character = base.character;
						statModifier.sourceItem = base.sourceItem;
						statModifier.cleansable = true;
						statModifier.ticDuration = num2;
						statModifier.Init();
						enemy.AddStatModifier(statModifier);
					}
				}
			}
			float num8 = num;
			float num9 = (float)num3 * num8;
			base.character.Armor += num9;
		}
		if (shakeCameraAmount > 0f)
		{
			CameraShake.singleton.ShakeCamera(shakeCameraAmount, camShakeDuration);
		}
		if (slowMotionDuration > 0f)
		{
			SlowMotion.singleton.Add(slowMotionDuration);
		}
	}

	protected virtual void Awake()
	{
		clock = AbilityClock.GetClockForAbility(id);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		clock = null;
	}
}

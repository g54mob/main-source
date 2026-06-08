using UnityEngine;

public class AcronianCultist : Enemy
{
	private enum Behavior
	{
		Normal = 0,
		PowerUpPre = 1,
		PowerUp = 2
	}

	public int numAttacksApplyBuff = -1;

	public DebuffStatMod poisonBuff;

	public float copiesOfBuffToApply = 1f;

	public float copiesToApplyPerLevel = 0.5f;

	public AsciiAnimation poisonPowerUpVFX;

	public AsciiAnimation powerUpAnimation;

	public int powerUpTicDuration = 45;

	private Behavior behavior;

	private int behaviorElapsedTics;

	private AsciiSprite defaultIdleSprite;

	private int attackCount;

	private void SetBehavior(Behavior newBehavior)
	{
		switch (newBehavior)
		{
		case Behavior.Normal:
			idleSprite = defaultIdleSprite;
			base.MySprite = defaultIdleSprite;
			break;
		case Behavior.PowerUp:
			attackCount = 0;
			base.SetState(State.Engaging);
			idleSprite = powerUpAnimation.Sprite;
			base.MySprite = powerUpAnimation.Sprite;
			powerUpAnimation.Stop();
			powerUpAnimation.Play();
			SfxController.singleton.Play("poison_powerup");
			break;
		}
		behavior = newBehavior;
		behaviorElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		behaviorElapsedTics++;
		if (behavior == Behavior.PowerUpPre && behaviorElapsedTics >= 10)
		{
			SetBehavior(Behavior.PowerUp);
		}
		else if (behavior == Behavior.PowerUp)
		{
			if (behaviorElapsedTics == 15)
			{
				int num = Mathf.FloorToInt(copiesOfBuffToApply + copiesToApplyPerLevel * (float)level);
				for (int i = 0; i < num; i++)
				{
					ApplyDebuff(poisonBuff, this, 99999);
				}
				poisonPowerUpVFX.Play();
			}
			else if (behaviorElapsedTics >= powerUpTicDuration)
			{
				SetBehavior(Behavior.Normal);
			}
		}
		else
		{
			base.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (behavior == Behavior.PowerUp)
		{
			poisonPowerUpVFX.Sprite.Draw(r, offsetX + base.PositionX, offsetY + base.PositionZ - base.PositionY);
		}
	}

	private DebuffStatMod ApplyDebuff(DebuffStatMod debuffPrefab, Character target, int duration)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = base.weapon;
			debuffStatMod.character = target;
			debuffStatMod.element = GetElement();
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.ticDuration = duration;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for " + this);
		}
		return debuffStatMod;
	}

	private void HandleEnemyAttackEnded(Character c, Character target, Weapon w)
	{
		if (c == this && Alive && numAttacksApplyBuff > 0)
		{
			attackCount++;
			if (attackCount >= numAttacksApplyBuff)
			{
				SetBehavior(Behavior.PowerUpPre);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		defaultIdleSprite = GetComponent<AsciiSprite>();
		Character.OnCharacterAttackEnded += HandleEnemyAttackEnded;
	}

	protected override void Start()
	{
		base.Start();
		powerUpAnimation.Sprite.Load();
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterAttackEnded -= HandleEnemyAttackEnded;
		base.OnDestroy();
	}
}

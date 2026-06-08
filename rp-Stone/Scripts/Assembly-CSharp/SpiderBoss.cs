using UnityEngine;

public class SpiderBoss : Enemy
{
	private enum Behavior
	{
		ArmingClaws = 0,
		DisarmingClaws = 1,
		Bite = 2,
		Claws = 3,
		PowerUp = 4
	}

	public AsciiAnimation clawsArmingAnm;

	public AsciiAnimation clawsDisarmingAnm;

	public Weapon biteWeapon;

	public Weapon clawsWeapon;

	public AsciiSprite biteCast;

	public AsciiSprite bitePerf;

	public AsciiSprite clawsCast;

	public AsciiSprite clawsPerf;

	public int numAttacksApplyBuff = -1;

	public DebuffStatMod poisonBuff;

	public AsciiAnimation poisonPowerUpVFX;

	public int powerUpTicDuration = 15;

	private int clawsArmingTicDuration = 15;

	private Behavior behavior = Behavior.Bite;

	private int behaviorElapsedTics;

	private AsciiSprite defaultIdleSprite;

	private int attackCount;

	private void SetBehavior(Behavior newBehavior)
	{
		switch (newBehavior)
		{
		case Behavior.ArmingClaws:
			clawsArmingAnm.Stop();
			clawsArmingAnm.Play();
			idleSprite = clawsPerf;
			base.MySprite = clawsPerf;
			break;
		case Behavior.DisarmingClaws:
			clawsDisarmingAnm.Stop();
			clawsDisarmingAnm.Play();
			idleSprite = defaultIdleSprite;
			base.MySprite = defaultIdleSprite;
			break;
		case Behavior.Bite:
			base.weapon = biteWeapon;
			attackCastSprite = biteCast;
			attackPerfSprite = bitePerf;
			break;
		case Behavior.Claws:
			base.weapon = clawsWeapon;
			attackCastSprite = clawsCast;
			attackPerfSprite = clawsPerf;
			break;
		case Behavior.PowerUp:
			attackCount = 0;
			poisonPowerUpVFX.Play();
			break;
		}
		behavior = newBehavior;
		behaviorElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		behaviorElapsedTics++;
		if (behavior == Behavior.ArmingClaws)
		{
			if (behaviorElapsedTics >= clawsArmingTicDuration)
			{
				SetBehavior(Behavior.Claws);
			}
			return;
		}
		if (behavior == Behavior.DisarmingClaws)
		{
			if (behaviorElapsedTics >= clawsArmingTicDuration)
			{
				if (numAttacksApplyBuff > 0 && attackCount >= numAttacksApplyBuff)
				{
					SetBehavior(Behavior.PowerUp);
				}
				else
				{
					SetBehavior(Behavior.Bite);
				}
			}
			return;
		}
		if (behavior == Behavior.PowerUp)
		{
			if (behaviorElapsedTics == 3)
			{
				ApplyDebuff(poisonBuff, this, 99999);
			}
			else if (behaviorElapsedTics >= powerUpTicDuration)
			{
				SetBehavior(Behavior.Bite);
			}
			return;
		}
		base.UpdateTic();
		if (Alive && base.CurrentState == State.Engaging)
		{
			Hero hero = GameStates.Singleton.hero;
			int num = base.PositionX - hero.PositionX;
			if (behavior == Behavior.Bite && num > biteWeapon.baseRange && num <= clawsWeapon.baseRange)
			{
				SetBehavior(Behavior.ArmingClaws);
			}
			else if (behavior == Behavior.Claws && (num <= biteWeapon.baseRange || (numAttacksApplyBuff > 0 && attackCount >= numAttacksApplyBuff)))
			{
				SetBehavior(Behavior.DisarmingClaws);
			}
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportBoleshDefeated(this);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (behavior == Behavior.ArmingClaws)
		{
			clawsArmingAnm.Sprite.Draw(r, offsetX + base.PositionX, offsetY + base.PositionZ - base.PositionY, 1f, base.colorTint);
			return;
		}
		if (behavior == Behavior.DisarmingClaws)
		{
			clawsDisarmingAnm.Sprite.Draw(r, offsetX + base.PositionX, offsetY + base.PositionZ - base.PositionY, 1f, base.colorTint);
			return;
		}
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
		if (c == this)
		{
			attackCount++;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		defaultIdleSprite = GetComponent<AsciiSprite>();
		clawsCast.Load();
		clawsPerf.Load();
		clawsWeapon.Owner = this;
		clawsWeapon.LoadAbilities();
		SetBehavior(Behavior.Bite);
		Character.OnCharacterAttackEnded += HandleEnemyAttackEnded;
	}

	protected override void Start()
	{
		base.Start();
		clawsArmingAnm.Sprite.Load();
		clawsDisarmingAnm.Sprite.Load();
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterAttackEnded -= HandleEnemyAttackEnded;
		base.OnDestroy();
	}

	public override int GetStateNumericRepresentation()
	{
		if (behavior == Behavior.ArmingClaws || behavior == Behavior.DisarmingClaws || behavior == Behavior.PowerUp)
		{
			return (int)(100 + behavior);
		}
		if (base.CurrentState == State.Attacking)
		{
			int num = base.GetStateNumericRepresentation();
			if (behavior == Behavior.Claws)
			{
				num += 100;
			}
			else if (behavior == Behavior.Bite)
			{
				num += 110;
			}
			return num;
		}
		return base.GetStateNumericRepresentation();
	}

	public override int GetStateTimeRepresentation()
	{
		if (behavior == Behavior.ArmingClaws || behavior == Behavior.DisarmingClaws || behavior == Behavior.PowerUp)
		{
			return behaviorElapsedTics;
		}
		return base.GetStateTimeRepresentation();
	}
}

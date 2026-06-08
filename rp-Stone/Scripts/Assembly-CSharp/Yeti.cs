using UnityEngine;

public class Yeti : Enemy
{
	private enum YetiState
	{
		Asleep = 0,
		Attacking = 1,
		ApplyingChill = 2,
		SummoningWall = 3,
		Dead = 4
	}

	private int pushDistance = 16;

	private int wallOffsetX = -6;

	private int elementalOffsetX = -1;

	public AsciiSprite chillCast;

	public AsciiSprite chillPerf;

	public AsciiSprite summonWallCast;

	public AsciiSprite summonWallPerf;

	public Weapon chillWeapon;

	public Weapon summonWallWeapon;

	public Character wallPrefab;

	public Enemy iceElementalPrefab;

	public bool summonWall_1 = true;

	public bool summonWall_2 = true;

	public bool summonElemental_1 = true;

	public bool summonElemental_2 = true;

	public bool pushIfTooClose;

	private AsciiSprite defaultCast;

	private AsciiSprite defaultPerf;

	private Weapon defaultWeapon;

	private int elapsedYetiTics;

	private int lastHitpointsEvaluated;

	private YetiState yetiState { get; set; }

	private void SetYetiState(YetiState newState)
	{
		switch (newState)
		{
		case YetiState.ApplyingChill:
		case YetiState.SummoningWall:
			switch (newState)
			{
			case YetiState.ApplyingChill:
				attackCastSprite = chillCast;
				attackPerfSprite = chillPerf;
				base.weapon = chillWeapon;
				break;
			case YetiState.SummoningWall:
				attackCastSprite = summonWallCast;
				attackPerfSprite = summonWallPerf;
				base.weapon = summonWallWeapon;
				break;
			}
			base.weapon.Owner = this;
			base.weapon.LoadAbilities();
			break;
		case YetiState.Attacking:
			attackCastSprite = defaultCast;
			attackPerfSprite = defaultPerf;
			base.weapon = defaultWeapon;
			break;
		}
		yetiState = newState;
		elapsedYetiTics = 0;
	}

	protected override void SetState(State newState)
	{
		switch (newState)
		{
		case State.Sleeping:
		case State.WakingUp:
			SetYetiState(YetiState.Asleep);
			break;
		case State.Dying:
			SetYetiState(YetiState.Dead);
			break;
		default:
			if (yetiState == YetiState.Asleep)
			{
				defaultCast = attackCastSprite;
				defaultPerf = attackPerfSprite;
				defaultWeapon = base.weapon;
				SetYetiState(YetiState.ApplyingChill);
			}
			else if (base.CurrentState == State.Attacking && newState == State.Engaging)
			{
				EvaluateWeaponSwitch();
			}
			break;
		}
		if (newState != State.WakingUp || !(base.Armor > 0f))
		{
			if (newState == State.WakingUp)
			{
				base.Hitpoints = base.MaxHitpoints;
				GameStates.Singleton.hero.PauseAI(5.2f);
				GameStates.Singleton.hero.CancelAttack();
				PlayBossMusic();
				sortTiebreaker = 999;
			}
			else
			{
				sortTiebreaker = 5;
			}
			base.SetState(newState);
		}
	}

	private void EvaluateWeaponSwitch()
	{
		int num = base.MaxHitpoints * 2 / 3;
		int num2 = base.MaxHitpoints / 3;
		int num3 = base.PositionX - GameStates.Singleton.hero.PositionX;
		if ((pushIfTooClose && num3 <= 2) || num3 <= 0)
		{
			SetYetiState(YetiState.ApplyingChill);
		}
		else if (lastHitpointsEvaluated > num && num >= base.Hitpoints)
		{
			if (summonWall_1)
			{
				SetYetiState(YetiState.SummoningWall);
			}
			else
			{
				SetYetiState(YetiState.ApplyingChill);
			}
		}
		else if (lastHitpointsEvaluated > num2 && num2 >= base.Hitpoints)
		{
			if (summonWall_2)
			{
				SetYetiState(YetiState.SummoningWall);
			}
			else
			{
				SetYetiState(YetiState.ApplyingChill);
			}
		}
		else
		{
			SetYetiState(YetiState.Attacking);
		}
		lastHitpointsEvaluated = base.Hitpoints;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedYetiTics++;
		if (base.CurrentState == State.Sleeping && base.Armor <= 0f)
		{
			WakeUp();
			PlayBossMusic();
		}
		else if (base.CurrentState == State.WakingUp && base.stateElapsedTics == 40)
		{
			Hero hero = GameStates.Singleton.hero;
			int num = base.PositionX - pushDistance - hero.PositionX;
			if (num < 0)
			{
				hero.PositionX += num;
			}
		}
		else
		{
			if (yetiState != YetiState.ApplyingChill && yetiState != YetiState.SummoningWall)
			{
				return;
			}
			if (yetiState == YetiState.SummoningWall && elapsedYetiTics == 88)
			{
				SummonWall();
			}
			if (base.weapon.IsPerforming() && elapsedYetiTics % 3 == 0)
			{
				int num2 = base.PositionX - pushDistance;
				Hero hero2 = GameStates.Singleton.hero;
				if (hero2.PositionX > num2)
				{
					hero2.PositionX--;
				}
			}
		}
	}

	private void SummonWall()
	{
		Character character;
		if ((summonElemental_1 && base.Hitpoints > base.MaxHitpoints / 2) || (summonElemental_2 && base.Hitpoints < base.MaxHitpoints / 2))
		{
			character = Object.Instantiate(iceElementalPrefab);
			character.PositionX = base.PositionX + elementalOffsetX;
			character.PositionY = base.PositionY;
			character.PositionZ = base.PositionZ;
			GameStates.Singleton.level.AddCharacter(character);
			character.SetLevel(level);
		}
		character = Object.Instantiate(wallPrefab);
		character.PositionX = base.PositionX + wallOffsetX;
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ;
		GameStates.Singleton.level.AddCharacter(character);
		character.SetLevel(level);
	}

	private void PlayBossMusic()
	{
		if (MusicController.singleton.currentMusic != null && MusicController.singleton.enabled)
		{
			MusicController.singleton.currentMusic.Play(0.5f);
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		AchievementController.singleton.ReportHrimnirDefeated(this);
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == this && yetiState == YetiState.Asleep)
		{
			armorPerSecond = -10f;
			AsciiAnimation component = sleepingSprite.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.Stop();
				component.Play();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
	}

	public override int GetStateNumericRepresentation()
	{
		int num = base.GetStateNumericRepresentation();
		if (yetiState == YetiState.ApplyingChill)
		{
			num += 100;
		}
		else if (yetiState == YetiState.SummoningWall)
		{
			num += 110;
		}
		return num;
	}
}

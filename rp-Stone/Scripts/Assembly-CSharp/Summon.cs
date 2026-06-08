using System;
using UnityEngine;

public class Summon : Character
{
	public enum State
	{
		WakingUp = 0,
		Idle = 1,
		Walking = 2,
		Attacking = 3,
		Dying = 4,
		Custom = 5
	}

	public int wakeupDistance;

	public int wakeupTics;

	public AsciiSprite wakeupSprite;

	public AsciiSprite walkSprite;

	public AsciiSprite attackCastSprite;

	public AsciiSprite attackPerfSprite;

	public AsciiSprite deathSprite;

	protected AsciiSprite idleSprite;

	private Weapon _weapon;

	public string awakeSfx;

	public string deathSfx;

	private State currentState;

	private int walkCountdown;

	public Weapon sourceWeapon { get; set; }

	public Character owner { get; set; }

	public Weapon weapon
	{
		get
		{
			return _weapon;
		}
		set
		{
			_weapon = value;
		}
	}

	public State CurrentState => currentState;

	public State previousState { get; protected set; }

	public int stateElapsedTics { get; protected set; }

	public static event Action<Summon> OnSummonSummoned;

	public static event Action<Summon> OnSummonDied;

	public event Action<Summon, State, State> OnSummonStateChange;

	protected virtual void SetState(State newState)
	{
		base.MySprite = null;
		switch (newState)
		{
		case State.WakingUp:
			SfxController.singleton.Play(awakeSfx);
			if (wakeupTics <= 0)
			{
				SetState(State.Idle);
				return;
			}
			base.MySprite = wakeupSprite;
			PlayAnimationIfAvailable(base.MySprite);
			break;
		case State.Walking:
			if (walkSprite != null)
			{
				base.MySprite = walkSprite;
				PlayAnimationIfAvailable(walkSprite);
			}
			else
			{
				base.MySprite = idleSprite;
			}
			break;
		case State.Dying:
			SfxController.singleton.Play(deathSfx);
			base.MySprite = deathSprite;
			PlayAnimationIfAvailable(base.MySprite);
			break;
		}
		if (base.MySprite == null)
		{
			base.MySprite = idleSprite;
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
		if (this.OnSummonStateChange != null)
		{
			this.OnSummonStateChange(this, newState, previousState);
		}
	}

	private void PlayAnimationIfAvailable(AsciiSprite sprite)
	{
		if (sprite != null)
		{
			AsciiAnimation component = sprite.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.Play();
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (weapon != null && Alive)
		{
			weapon.UpdateTic();
		}
		stateElapsedTics++;
		Hero hero = GameStates.Singleton.hero;
		int num = hero.PositionX + wakeupDistance;
		int num2 = hero.PositionY;
		int num3 = hero.PositionZ;
		if (currentState == State.WakingUp && stateElapsedTics >= wakeupTics)
		{
			SetState(State.Idle);
		}
		else if (currentState == State.Idle)
		{
			if (TryAttack())
			{
				SetState(State.Attacking);
			}
			else if (base.PositionX != num || base.PositionY != num2 || base.PositionZ != num3)
			{
				SetState(State.Walking);
			}
		}
		else if (currentState == State.Walking)
		{
			int num4 = ComputeTicsPerMove(num, num2, num3);
			if (num4 <= 0)
			{
				base.PositionX = num;
				base.PositionY = num2;
				base.PositionZ = num3;
				SetState(State.Idle);
			}
			else if (TryAttack())
			{
				SetState(State.Attacking);
			}
			else if (stateElapsedTics >= num4)
			{
				stateElapsedTics = 0;
				if (base.PositionX > num)
				{
					base.PositionX--;
					walkCountdown = 4;
				}
				else if (base.PositionX < num)
				{
					base.PositionX++;
					walkCountdown = 4;
				}
				if (base.PositionY > num2)
				{
					base.PositionY--;
					walkCountdown = 4;
				}
				else if (base.PositionY < num2)
				{
					base.PositionY++;
					walkCountdown = 4;
				}
				if (base.PositionZ > num3)
				{
					base.PositionZ--;
					walkCountdown = 4;
				}
				else if (base.PositionZ < num3)
				{
					base.PositionZ++;
					walkCountdown = 4;
				}
				if (--walkCountdown <= 0)
				{
					SetState(State.Idle);
				}
			}
		}
		else if (currentState == State.Attacking && (weapon.IsWaiting() || weapon.IsOnCooldown()))
		{
			SetState(State.Idle);
			if (weapon.IsReady())
			{
				UpdateTic();
			}
		}
	}

	private bool TryAttack()
	{
		if (weapon != null && weapon.IsReady())
		{
			Character character = FindAttackTarget();
			if (character != null && Mathf.Abs(character.PositionZ - base.PositionZ) <= 1 && character.PositionX - weapon.range <= base.PositionX)
			{
				weapon.Attack(this);
				return true;
			}
		}
		return false;
	}

	protected virtual Character FindAttackTarget()
	{
		HeroAI component = GameStates.Singleton.hero.GetComponent<HeroAI>();
		if (component.enabled)
		{
			return component.targetEnemy;
		}
		return null;
	}

	private int ComputeTicsPerMove(int targetX, int targetY, int targetZ)
	{
		int num = Mathf.Abs(targetX - base.PositionX);
		int num2 = Mathf.Abs(targetY - base.PositionY);
		int num3 = Mathf.Abs(targetZ - base.PositionZ);
		if (num > 60 || num2 > 21 || num3 > 21)
		{
			return 0;
		}
		if (num > 2 * Mathf.Abs(wakeupDistance))
		{
			return 1;
		}
		return 2;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.WakingUp)
		{
			SetSpriteFrame(wakeupTics, stateElapsedTics);
		}
		else if (currentState == State.Attacking)
		{
			if (weapon.IsCasting())
			{
				if (attackCastSprite != null)
				{
					if (base.MySprite != attackCastSprite)
					{
						PlayAnimationIfAvailable(attackCastSprite);
					}
					base.MySprite = attackCastSprite;
					SetSpriteFrame(weapon.GetCastTics(), weapon.StateElapsedTics);
				}
			}
			else if (weapon.IsPerforming() && attackPerfSprite != null)
			{
				if (base.MySprite != attackPerfSprite)
				{
					PlayAnimationIfAvailable(attackPerfSprite);
				}
				base.MySprite = attackPerfSprite;
				SetSpriteFrame(weapon.GetPerfTics(), weapon.StateElapsedTics);
			}
		}
		base.Draw(r, offsetX, offsetY);
	}

	private void SetSpriteFrame(int totalStateTics, int elapsedTics)
	{
		if (totalStateTics > 0)
		{
			if (elapsedTics >= totalStateTics)
			{
				base.MySprite.SetFrameIndex(base.MySprite.FrameCount - 1);
			}
			else
			{
				base.MySprite.SetFrameIndex(elapsedTics * base.MySprite.FrameCount / totalStateTics);
			}
		}
		else
		{
			base.MySprite.SetFrameIndex(0);
		}
	}

	protected DebuffStatMod AddDebuff(Character target, DebuffStatMod debuffPrefab)
	{
		if (!target.Alive)
		{
			return null;
		}
		DebuffStatMod debuffStatMod = UnityEngine.Object.Instantiate(debuffPrefab);
		if (debuffStatMod != null)
		{
			debuffStatMod.sourceItem = weapon;
			debuffStatMod.character = target;
			debuffStatMod.element = GetElement();
			debuffStatMod.statData = debuffStatMod.replacementStat;
			debuffStatMod.Init();
			target.AddStatModifier(debuffStatMod);
		}
		else
		{
			Utils.LogError("Could not instantiate debuff " + debuffPrefab?.ToString() + " for summon " + this);
		}
		return debuffStatMod;
	}

	public override void Die(DeathReason reason)
	{
		base.Die(reason);
		SetState(State.Dying);
		if (Summon.OnSummonDied != null)
		{
			Summon.OnSummonDied(this);
		}
	}

	public virtual object GetCustomProperty(string propertyName)
	{
		throw new StonescriptRuntimeException("Unknown variable '" + propertyName + "' for summon " + id);
	}

	public int GetStateNumericRepresentation()
	{
		if (currentState == State.Attacking && weapon != null)
		{
			return (int)(30 + weapon.CurrentState);
		}
		return (int)currentState;
	}

	public int GetStateTimeRepresentation()
	{
		if (currentState == State.Attacking && weapon != null)
		{
			return weapon.StateElapsedTics;
		}
		return stateElapsedTics;
	}

	protected override void Awake()
	{
		base.Awake();
		weapon = GetComponentInChildren<Weapon>();
		if (weapon != null)
		{
			weapon.Owner = this;
		}
		idleSprite = base.MySprite;
		if (wakeupSprite != null)
		{
			wakeupSprite.Load();
		}
		if (walkSprite != null)
		{
			walkSprite.Load();
		}
		if (attackCastSprite != null)
		{
			attackCastSprite.Load();
		}
		if (attackPerfSprite != null)
		{
			attackPerfSprite.Load();
		}
		base.lookDirection = LookDirection.Left;
	}

	public override void Init()
	{
		base.Init();
		if (weapon != null)
		{
			weapon.LoadAbilities();
			Character.FireEquippedWeapon(this, weapon);
		}
		UpdateArmor();
		base.Armor = base.MaxArmor;
		SetState(State.WakingUp);
		if (Summon.OnSummonSummoned != null)
		{
			Summon.OnSummonSummoned(this);
		}
	}

	protected virtual void OnDestroy()
	{
		sourceWeapon = null;
		owner = null;
	}
}

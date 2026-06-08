using System;
using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class Enemy : Character
{
	public enum State
	{
		Sleeping = 0,
		WakingUp = 1,
		Engaging = 2,
		Attacking = 3,
		Dying = 4
	}

	public bool showInHud = true;

	public int distanceToCleanup = -60;

	public int ticsPerMove = 4;

	public bool immobile;

	public bool sleepIfNoWeapon = true;

	public bool hostile = true;

	public int impactDamage;

	public int wakeupDistance;

	public int wakeupTics;

	public AsciiSprite sleepingSprite;

	public AsciiSprite wakeupSprite;

	public AsciiSprite walkSprite;

	public AsciiSprite attackCastSprite;

	public AsciiSprite attackPerfSprite;

	public AsciiSprite attackCastSprite2;

	public AsciiSprite attackPerfSprite2;

	public AsciiSprite deathSprite;

	public string awakeSfx;

	public string deathSfx;

	private Vector2Int? destination;

	public Action<Enemy> OnDestinationReached;

	private bool destinationReached;

	private State currentState;

	private Character target;

	protected AsciiSprite idleSprite;

	private Weapon _weapon;

	private AsciiSprite _castSprite;

	private AsciiSprite _perfSprite;

	private IFunction destinationReachedCallbackMethod;

	private List<object> destinationReachedCallbackParameters;

	public State CurrentState => currentState;

	public State previousState { get; private set; }

	public int stateElapsedTics { get; private set; }

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

	public static event Action<Enemy> OnEnemyEngaged;

	public event Action<Enemy, State, State> OnEnemyStateChange;

	protected virtual void SetState(State newState)
	{
		base.MySprite = null;
		switch (newState)
		{
		case State.WakingUp:
			SfxController.singleton.Play(awakeSfx);
			if (wakeupTics <= 0)
			{
				SetState(State.Engaging);
				return;
			}
			base.MySprite = wakeupSprite;
			PlayAnimationIfAvailable(base.MySprite);
			break;
		case State.Engaging:
			if (target == null)
			{
				target = GameStates.Singleton.hero;
			}
			if (weapon == null && sleepIfNoWeapon)
			{
				SetState(State.Sleeping);
				return;
			}
			if (walkSprite != null)
			{
				base.MySprite = walkSprite;
				PlayAnimationIfAvailable(walkSprite);
			}
			else
			{
				base.MySprite = idleSprite;
			}
			if (Enemy.OnEnemyEngaged != null)
			{
				Enemy.OnEnemyEngaged(this);
			}
			break;
		case State.Attacking:
			if (attackCastSprite2 == null || UnityEngine.Random.Range(0f, 1f) <= 0.5f)
			{
				_castSprite = attackCastSprite;
				_perfSprite = attackPerfSprite;
			}
			else
			{
				_castSprite = attackCastSprite2;
				_perfSprite = attackPerfSprite2;
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
		if (this.OnEnemyStateChange != null)
		{
			this.OnEnemyStateChange(this, newState, previousState);
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
		if (GameStates.Singleton == null || GameStates.Singleton.hero == null)
		{
			return;
		}
		if (base.PositionX - GameStates.Singleton.hero.PositionX + base.CollisionWidth < distanceToCleanup)
		{
			Die(DeathReason.DecorationCleanup);
		}
		if (IsStunned())
		{
			return;
		}
		if (hostile && weapon != null && Alive)
		{
			weapon.UpdateTic();
		}
		stateElapsedTics++;
		if (!immobile && destination.HasValue)
		{
			if (stateElapsedTics >= ComputeTicsPerMove())
			{
				stateElapsedTics = 0;
				int x = destination.Value.x;
				int y = destination.Value.y;
				if (y < base.PositionZ)
				{
					base.PositionZ--;
				}
				else if (y > base.PositionZ)
				{
					base.PositionZ++;
				}
				if (x < base.PositionX)
				{
					base.PositionX--;
				}
				else if (x > base.PositionX)
				{
					base.PositionX++;
				}
				if (!destinationReached && base.PositionX == x && base.PositionZ == y)
				{
					destinationReached = true;
					OnDestinationReached?.Invoke(this);
				}
			}
		}
		else if (hostile && currentState == State.Sleeping && base.PositionX - GameStates.Singleton.hero.PositionX <= wakeupDistance)
		{
			target = GameStates.Singleton.hero;
			SetState(State.WakingUp);
		}
		else if (currentState == State.WakingUp && stateElapsedTics >= wakeupTics)
		{
			SetState(State.Engaging);
		}
		else if (currentState == State.Engaging)
		{
			if (target == null)
			{
				SetState(State.Sleeping);
			}
			else if (hostile && weapon != null && weapon.IsReady() && Mathf.Abs(target.PositionZ - base.PositionZ) <= 1 && target.PositionX + weapon.range + target.CollisionWidth >= base.PositionX)
			{
				SetState(State.Attacking);
				weapon.Attack(target);
				if (impactDamage > 0)
				{
					Damage damage = new Damage();
					damage.amount = impactDamage;
					damage.Owner = this;
					target.InflictDamage(damage);
				}
			}
			else if (!immobile && stateElapsedTics >= ComputeTicsPerMove())
			{
				stateElapsedTics = 0;
				if (target.PositionZ < base.PositionZ)
				{
					base.PositionZ--;
				}
				else if (target.PositionZ > base.PositionZ)
				{
					base.PositionZ++;
				}
				if (weapon != null && target.PositionX + weapon.range + target.CollisionWidth < base.PositionX)
				{
					base.PositionX--;
				}
			}
		}
		else if (hostile && currentState == State.Attacking && (weapon.IsWaiting() || weapon.IsOnCooldown()))
		{
			SetState(State.Engaging);
			if (weapon.IsReady())
			{
				UpdateTic();
			}
		}
	}

	private int ComputeTicsPerMove()
	{
		if (base.statModController != null)
		{
			return base.statModController.ModTicsPerMove(ticsPerMove);
		}
		return ticsPerMove;
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
				if (_castSprite != null)
				{
					if (base.MySprite != _castSprite)
					{
						PlayAnimationIfAvailable(_castSprite);
					}
					base.MySprite = _castSprite;
					SetSpriteFrame(weapon.GetCastTics(), weapon.StateElapsedTics);
				}
			}
			else if (weapon.IsPerforming() && _perfSprite != null)
			{
				if (base.MySprite != _perfSprite)
				{
					PlayAnimationIfAvailable(_perfSprite);
				}
				base.MySprite = _perfSprite;
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

	public bool IsAwake()
	{
		if (currentState != State.Sleeping)
		{
			return currentState != State.Dying;
		}
		return false;
	}

	public void WakeUp()
	{
		if (currentState == State.Sleeping)
		{
			target = GameStates.Singleton.hero;
			SetState(State.WakingUp);
		}
	}

	private void HandleOnCharacterTookDamage(Character character, Damage dmg)
	{
		if (!(character == this))
		{
			return;
		}
		if (currentState == State.Sleeping)
		{
			Summon summon = dmg.Owner as Summon;
			if (summon != null)
			{
				target = summon.owner;
			}
			else
			{
				target = dmg.Owner;
			}
			SetState(State.WakingUp);
		}
		if (!tags.Contains("crowd"))
		{
			return;
		}
		List<Enemy> enemies = GameStates.Singleton.level.Enemies;
		for (int i = 0; i < enemies.Count; i++)
		{
			Enemy enemy = enemies[i];
			if (!(enemy == this) && enemy.currentState == State.Sleeping && enemy.PositionX >= base.PositionX - 23 && enemy.PositionX <= base.PositionX + 23 && enemy.tags.Contains("crowd"))
			{
				enemy.target = dmg.Owner;
				enemy.SetState(State.WakingUp);
			}
		}
	}

	private void HandleOnCharacterDied(Character character, DeathReason reason, Damage damage)
	{
		if (character == this)
		{
			if (reason == DeathReason.DecorationCleanup)
			{
				Cleanup();
			}
			else
			{
				SetState(State.Dying);
			}
		}
	}

	private void HandleLifetimeEnded(Bullet bullet)
	{
		if (bullet.Owner == this && bullet.tags.Contains("melee"))
		{
			ShowFloatingText(Te.xt("MISSED"));
		}
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
		if (sleepingSprite != null)
		{
			sleepingSprite.Load();
			base.MySprite = sleepingSprite;
		}
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
		if (attackCastSprite2 != null)
		{
			attackCastSprite2.Load();
		}
		if (attackPerfSprite2 != null)
		{
			attackPerfSprite2.Load();
		}
		_castSprite = attackCastSprite;
		_perfSprite = attackPerfSprite;
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
		if (base.MaxArmor <= 0f && EventController.singleton.IsObjectiveActive("armor_damage"))
		{
			base.MaxArmor = Mathf.Max(Mathf.Abs(base.Hitpoints), 5);
		}
		UpdateArmor();
		base.Armor = base.MaxArmor;
		if (sortTiebreaker < 0)
		{
			sortTiebreaker = 5;
		}
		Character.OnCharacterTookDamage += HandleOnCharacterTookDamage;
		Character.OnCharacterDied += HandleOnCharacterDied;
		Bullet.OnLifetimeEnded += HandleLifetimeEnded;
	}

	protected virtual void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleOnCharacterTookDamage;
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Bullet.OnLifetimeEnded -= HandleLifetimeEnded;
		OnDestinationReached = (Action<Enemy>)Delegate.Remove(OnDestinationReached, new Action<Enemy>(DestinationReachedCallback));
	}

	public virtual int GetStateNumericRepresentation()
	{
		if (currentState == State.Attacking && weapon != null)
		{
			return (int)(30 + weapon.CurrentState);
		}
		return (int)currentState;
	}

	public virtual int GetStateTimeRepresentation()
	{
		if (currentState == State.Attacking && weapon != null)
		{
			return weapon.StateElapsedTics;
		}
		return stateElapsedTics;
	}

	private void DestinationReachedCallback(Enemy enemy)
	{
		base.MySprite = idleSprite;
		PlayAnimationIfAvailable(idleSprite);
		OnDestinationReached = (Action<Enemy>)Delegate.Remove(OnDestinationReached, new Action<Enemy>(DestinationReachedCallback));
		IFunction function = destinationReachedCallbackMethod;
		List<object> parameters = destinationReachedCallbackParameters;
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		function?.Invoke(parameters);
	}

	[StonescriptNativeMethod]
	public object SetDestination(List<object> parameters, InvocationContext ctx)
	{
		destination = new Vector2Int((int)parameters[0], (int)parameters[1]);
		destinationReached = false;
		OnDestinationReached = (Action<Enemy>)Delegate.Remove(OnDestinationReached, new Action<Enemy>(DestinationReachedCallback));
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		base.MySprite = walkSprite;
		PlayAnimationIfAvailable(walkSprite);
		if (parameters.Count >= 3)
		{
			if (!(parameters[2] is IFunction))
			{
				throw new RuntimeException(ctx, "SetDestination expects parameter 2 to be a function but it received something else.");
			}
			destinationReachedCallbackMethod = parameters[2] as IFunction;
			if (parameters.Count >= 4)
			{
				if (!(parameters[3] is StonescriptArray))
				{
					throw new StonescriptRuntimeException("Invalid parameter list for SetDestination callback.");
				}
				destinationReachedCallbackParameters = (parameters[3] as StonescriptArray).ToList<object>();
			}
			OnDestinationReached = (Action<Enemy>)Delegate.Combine(OnDestinationReached, new Action<Enemy>(DestinationReachedCallback));
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object ClearDestination(List<object> parameters, InvocationContext ctx)
	{
		destination = null;
		OnDestinationReached = (Action<Enemy>)Delegate.Remove(OnDestinationReached, new Action<Enemy>(DestinationReachedCallback));
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		return null;
	}

	[StonescriptNativeMethod]
	public object SetHostile(List<object> parameters, InvocationContext ctx)
	{
		hostile = (bool)parameters[0];
		return null;
	}

	[StonescriptNativeMethod]
	public object SetState(List<object> parameters, InvocationContext ctx)
	{
		if (!Enum.TryParse<State>(parameters[0] as string, out var result))
		{
			throw new StonescriptRuntimeException($"\"{parameters[0]}\" is not a valid enemy state.");
		}
		SetState(result);
		return null;
	}

	[StonescriptNativeGetter("ticsPerMove")]
	public object GetTicksPerMove()
	{
		return ticsPerMove;
	}

	[StonescriptNativeSetter("ticsPerMove")]
	public void SetTicksPerMove(object value)
	{
		ticsPerMove = (int)value;
	}

	[StonescriptNativeGetter("walkSprite")]
	public object Property_GetWalkSprite()
	{
		return walkSprite.GetComponent<SSScriptableObject>().Target;
	}

	[StonescriptNativeSetter("walkSprite")]
	public void Property_SetWalkSprite(object value)
	{
		AsciiSprite component = (value as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
		walkSprite = component;
	}
}

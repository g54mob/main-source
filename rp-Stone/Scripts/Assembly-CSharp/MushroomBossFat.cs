public class MushroomBossFat : Enemy
{
	private enum Behavior
	{
		InitialDelay = 0,
		DefenseIn = 1,
		DefenseOut = 2,
		Attacking = 3
	}

	public AsciiSprite defenseInSprite;

	public AsciiSprite defenseOutSprite;

	public AsciiSprite slamCast;

	public AsciiSprite slamPerf;

	public Weapon punchWeapon;

	public Weapon slamWeapon;

	public int initialDefenseDelay = 90;

	public float defenseArmorBase = 50f;

	public float defenseArmorPerLevel = 50f;

	public int maxDefenseDuration = 165;

	public int defenseOutDuration = 13;

	private AsciiSprite punchCast;

	private AsciiSprite punchPerf;

	private Behavior currentBehavior;

	private int behaviorElapsedTics;

	private int attackDelayRemaining;

	private void SetBehavior(Behavior newBehavior)
	{
		switch (newBehavior)
		{
		case Behavior.DefenseIn:
		{
			punchWeapon.cooldown = 100;
			slamWeapon.cooldown = 100;
			punchWeapon.UpdateAttackSpeed();
			slamWeapon.UpdateAttackSpeed();
			punchWeapon.SetState(Weapon.State.Cooldown);
			slamWeapon.SetState(Weapon.State.Cooldown);
			attackDelayRemaining = maxDefenseDuration;
			float num = defenseArmorBase + defenseArmorPerLevel * (float)level;
			num = (base.MaxArmor = num - HeavyHammerActivatedAbility.CalculateArmorLostToFatigue(this, num));
			base.Armor = base.MaxArmor;
			Character.FireOnArmorGained(this, num);
			base.MySprite = defenseInSprite;
			TryToPlayAnimation();
			break;
		}
		case Behavior.DefenseOut:
			base.Armor = 0f;
			base.MaxArmor = 0f;
			base.MySprite = defenseOutSprite;
			TryToPlayAnimation();
			break;
		case Behavior.Attacking:
			punchWeapon.cooldown = 0;
			slamWeapon.cooldown = 0;
			if (base.PositionX - GameStates.Singleton.hero.PositionX <= punchWeapon.baseRange)
			{
				base.weapon = punchWeapon;
				attackCastSprite = punchCast;
				attackPerfSprite = punchPerf;
			}
			else
			{
				base.weapon = slamWeapon;
				attackCastSprite = slamCast;
				attackPerfSprite = slamPerf;
			}
			break;
		}
		currentBehavior = newBehavior;
		behaviorElapsedTics = 0;
	}

	private void TryToPlayAnimation()
	{
		AsciiAnimation component = base.MySprite.GetComponent<AsciiAnimation>();
		if (component != null)
		{
			component.Stop();
			component.Play();
		}
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		if (base.CurrentState == State.Engaging && base.previousState == State.Attacking)
		{
			SetBehavior(Behavior.DefenseIn);
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		behaviorElapsedTics++;
		attackDelayRemaining--;
		if (currentBehavior == Behavior.InitialDelay)
		{
			if (base.CurrentState < State.Engaging)
			{
				behaviorElapsedTics = 0;
			}
			else if (behaviorElapsedTics >= initialDefenseDelay)
			{
				MushroomBoss.RestoreAI();
				SetBehavior(Behavior.DefenseIn);
			}
		}
		else if (currentBehavior == Behavior.DefenseIn && (behaviorElapsedTics >= maxDefenseDuration || base.Armor <= 0f))
		{
			SetBehavior(Behavior.DefenseOut);
		}
		else if (currentBehavior == Behavior.DefenseOut && behaviorElapsedTics >= defenseOutDuration && attackDelayRemaining <= 0)
		{
			SetBehavior(Behavior.Attacking);
		}
		if (currentBehavior != Behavior.Attacking)
		{
			punchWeapon.cooldown++;
			slamWeapon.cooldown++;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		defenseInSprite.Load();
		defenseOutSprite.Load();
		punchCast = attackCastSprite;
		punchPerf = attackPerfSprite;
		slamCast.Load();
		slamPerf.Load();
		base.weapon = punchWeapon;
		slamWeapon.Owner = this;
		slamWeapon.LoadAbilities();
	}
}

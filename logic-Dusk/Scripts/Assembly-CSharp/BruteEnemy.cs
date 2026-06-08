using UnityEngine;

public class BruteEnemy : BaseEnemy
{
	public GameObject visualObject;

	private GameObject visualDeadObject;

	public AudioSource bruteScreamSound;

	public AudioSource bruteHitSound;

	private int animStateIdle = -1;

	private int animStateWalk = -1;

	private int animStateAttack = -1;

	private int animStateDie = -1;

	private bool inDyingAnimationState;

	public override float BaseMoveSpeed
	{
		get
		{
			return 0.6f;
		}
	}

	public override float TotalHitpoints
	{
		get
		{
			return 200f;
		}
	}

	public override float AttackSpeed
	{
		get
		{
			return 3.5f;
		}
	}

	public override float AttackDamage
	{
		get
		{
			return 0f;
		}
	}

	public override float AttackRadius
	{
		get
		{
			return 3f;
		}
	}

	protected override ProjectileTypeEnum ProjectileType
	{
		get
		{
			return ProjectileTypeEnum.Large;
		}
	}

	public override float ChargeSpeed
	{
		get
		{
			return 7f;
		}
	}

	public override float ChargeAttackDamage
	{
		get
		{
			return 90f;
		}
	}

	public override float ChargeCooldown
	{
		get
		{
			return 5f;
		}
	}

	public override float ChargeStunDuration
	{
		get
		{
			return 5f;
		}
	}

	protected override EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.AttacksWhenHit | EnemyAiBehaviors.Wanders | EnemyAiBehaviors.AttacksDroneOnSight | EnemyAiBehaviors.AttractedToLures | EnemyAiBehaviors.AttacksProbes | EnemyAiBehaviors.ChargesTarget | EnemyAiBehaviors.CanMove | EnemyAiBehaviors.DetectsStealth;
		}
	}

	protected override void OnAwake()
	{
		visualDeadObject = base.transform.FindChild("brute_dead").transform.FindChild("default").gameObject;
		animStateIdle = Animator.StringToHash("Idle");
		animStateWalk = Animator.StringToHash("Walk");
		animStateAttack = Animator.StringToHash("Attack");
		animStateDie = Animator.StringToHash("Death");
		base.OnAwake();
	}

	protected override void OnStart()
	{
		_brain = new BruteBrain(this);
		_brain.Initialize();
		Transform transform = base.transform.Find("UIOverlay");
		if (transform != null)
		{
			uiOverlay = transform.gameObject;
			string text = "default";
			SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
			if (currentSkin == SkinEnum.Halloween)
			{
				text = "halloween";
			}
			Texture2D mainTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/sensorRectangle");
			uiOverlay.GetComponent<Renderer>().material.mainTexture = mainTexture;
		}
		if (!SceneLevelInput.DisableEnemyAnimation)
		{
			animator.Play(animStateIdle);
		}
		else
		{
			animator.Stop();
		}
	}

	protected override void OnDestroy()
	{
		visualObject = null;
		visualDeadObject = null;
		base.OnDestroy();
	}

	public override void EnableRenderer(bool enabled)
	{
		if (!enabled || GlobalSettings.cameraMode != CameraMode.Schematic || GlobalSettings.cheatMode)
		{
			if (visualObject != null)
			{
				visualObject.GetComponent<Renderer>().enabled = enabled;
			}
			if (visualDeadObject != null)
			{
				visualDeadObject.GetComponent<Renderer>().enabled = enabled;
			}
			if (!enabled)
			{
			}
		}
	}

	public override void Stun(float durationMin, float durationMax)
	{
		if (!IsDead)
		{
			float num = Random.Range(durationMin, durationMax);
			if (IsStunned)
			{
				base.TimeStunned = TimeStunned + num;
			}
			else
			{
				base.TimeStunned = num;
			}
			GetComponent<Renderer>().material = StunMtl;
			GetComponent<Renderer>().material.color = StunColor;
			base.IsStunned = true;
		}
		base.Stun(durationMin, durationMax);
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (!GlobalSettings.IsGamePaused)
		{
			if (!IsDead)
			{
				AttemptScan();
			}
			else if (inDyingAnimationState && animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animator.GetCurrentAnimatorStateInfo(0).length * 0.35f)
			{
				inDyingAnimationState = false;
				SwitchToDeadModel();
			}
		}
	}

	public override void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (type != DamageType.Radiation)
		{
			base.TakeDamage(damage, type, attacker);
		}
	}

	protected override void OnDamageTaken(float damage, ICombatTarget attacker)
	{
		if (IsDead)
		{
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Brute), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Brute), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Brute), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Brute), 0) + num);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Brute), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Brute), num);
			}
			if (_brain != null && _brain.StartDeathAnimation())
			{
				inDyingAnimationState = true;
			}
		}
		base.OnDamageTaken(damage, attacker);
	}
}

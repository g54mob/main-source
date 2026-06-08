using System.Collections.Generic;
using UnityEngine;

public class SwarmEnemy : BaseEnemy
{
	public const float INDIVIDUAL_FLIGHT_RADIUS = 1f;

	public const float INDIVIDUAL_FLIGHT_SPEED = 3f;

	public GameObject SimpleSwarmObjectPrefab;

	public GameObject SimpleSwarmDeadObjectPrefab;

	public AudioSource swarmContinuousSound;

	public float CurrentFlightRadius = 1f;

	public float CurrentFlightSpeed = 3f;

	private GameObject _simpleSwarmObject;

	private GameObject _simpleSwarmDeadObject;

	private ColorBlinkManager _blinkManagerForSimpleObject = new ColorBlinkManager();

	private Color _startColorForSimpleObject;

	private SwarmManager _swarmManager;

	public override float BaseMoveSpeed
	{
		get
		{
			return 1f;
		}
	}

	public override float TotalHitpoints
	{
		get
		{
			return 30f;
		}
	}

	public override float AttackSpeed
	{
		get
		{
			return 2f;
		}
	}

	public override float AttackDamage
	{
		get
		{
			return 2f;
		}
	}

	public override float AttackRadius
	{
		get
		{
			return 2f;
		}
	}

	protected override ProjectileTypeEnum ProjectileType
	{
		get
		{
			return ProjectileTypeEnum.Small;
		}
	}

	public override bool CanSeeThroughStealth
	{
		get
		{
			return _swarmManager.CanSeeThroughStealth;
		}
	}

	protected override EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.AttacksWhenHit | EnemyAiBehaviors.ChewsThroughDoors | EnemyAiBehaviors.Wanders | EnemyAiBehaviors.AttacksDroneOnSight | EnemyAiBehaviors.AttractedToLures | EnemyAiBehaviors.AttacksProbes | EnemyAiBehaviors.DetectsEnemyInAdjacentRoom | EnemyAiBehaviors.CanMove | EnemyAiBehaviors.DetectsStealth | EnemyAiBehaviors.CuriousSeeker;
		}
	}

	public override bool CanCollide
	{
		get
		{
			return _swarmManager.IsAlphaEnemy(this);
		}
	}

	public override List<ICombatTarget> SubordinateTargets
	{
		get
		{
			return _swarmManager.GetSubordinateEnemies(this);
		}
		set
		{
		}
	}

	public override GameObject MainVisibleObject
	{
		get
		{
			return _simpleSwarmObject;
		}
	}

	public SwarmManager swarmManager
	{
		get
		{
			return _swarmManager;
		}
	}

	public override Vector3 Position
	{
		get
		{
			if (_simpleSwarmObject != null)
			{
				return _simpleSwarmObject.transform.position;
			}
			return Vector3.zero;
		}
	}

	public override Collider ObjectCollider
	{
		get
		{
			return _simpleSwarmObject.GetComponent<Collider>();
		}
	}

	protected override void OnAwake()
	{
	}

	protected override void OnStart()
	{
		_brain = new SwarmDumbBrain(this);
		_brain.Initialize();
		_simpleSwarmObject = Object.Instantiate(SimpleSwarmObjectPrefab);
		_simpleSwarmDeadObject = Object.Instantiate(SimpleSwarmDeadObjectPrefab);
		_simpleSwarmObject.transform.position = base.transform.position + new Vector3(1f, 1f, -0.15f);
		_simpleSwarmDeadObject.transform.position = base.transform.position + new Vector3(1f, 1f, -0.15f);
		Transform transform = _simpleSwarmObject.transform.Find("UIOverlay");
		if (transform != null)
		{
			uiOverlay = transform.gameObject;
		}
		if (uiOverlay != null)
		{
			uiOverlay.transform.parent = null;
			string text = "default";
			SkinEnum currentSkin = GlobalSettings.GameState.CurrentSkin;
			if (currentSkin == SkinEnum.Halloween)
			{
				text = "halloween";
			}
			Texture2D mainTexture = ResourceManager.LoadAsset<Texture2D>("skins/" + text + "/ui/droneview/sensorRectangle");
			uiOverlay.GetComponent<Renderer>().material.mainTexture = mainTexture;
		}
		_simpleSwarmObject.transform.LookAt(base.transform.position);
		_simpleSwarmDeadObject.GetComponent<Renderer>().enabled = false;
		if (uiOverlay != null)
		{
			uiOverlay.transform.parent = _simpleSwarmObject.transform;
		}
		_startColorForSimpleObject = _simpleSwarmObject.GetComponent<Renderer>().material.color;
	}

	public override void OnUpdate()
	{
		if (_blinkManagerForSimpleObject.IsActive && !IsDead)
		{
			_simpleSwarmObject.GetComponent<Renderer>().material.color = _blinkManagerForSimpleObject.Update(Time.deltaTime);
			if (IsDead)
			{
				_simpleSwarmObject.GetComponent<Renderer>().material.color = DeadColor;
			}
		}
	}

	public override void Vaporize()
	{
		_simpleSwarmObject.GetComponent<Renderer>().enabled = false;
		_simpleSwarmObject.SetActive(false);
		_simpleSwarmDeadObject.GetComponent<Renderer>().enabled = false;
		_simpleSwarmDeadObject.SetActive(false);
		if (CurrentRoom != null)
		{
			CurrentRoom.DeRegisterEnemy(this);
		}
		if (CurrentCorridor != null)
		{
			CurrentCorridor.DeRegisterEnemy(this);
		}
		Object.Destroy(_simpleSwarmObject);
		base.Vaporize();
	}

	public override void EnableRenderer(bool enabled)
	{
		if (!IsDead)
		{
			if ((!enabled || GlobalSettings.cameraMode != CameraMode.Schematic || GlobalSettings.cheatMode) && _simpleSwarmObject != null)
			{
				_simpleSwarmObject.GetComponent<Renderer>().enabled = enabled;
			}
		}
		else if (_simpleSwarmDeadObject != null)
		{
			_simpleSwarmDeadObject.GetComponent<Renderer>().enabled = enabled;
		}
	}

	protected override void OnDamageTaken(float damage, ICombatTarget attacker)
	{
		_blinkManagerForSimpleObject.Start(_startColorForSimpleObject, Color.red, 0.2f, 2);
		if (IsDead)
		{
			int num = 0;
			num++;
			if (_simpleSwarmDeadObject != null)
			{
				_simpleSwarmDeadObject.transform.position = _simpleSwarmObject.transform.position;
				_simpleSwarmObject.SetActive(false);
				_simpleSwarmDeadObject.SetActive(true);
			}
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				EnableRenderer(true);
			}
		}
		_swarmManager.NotifyOfDamage(this, damage, attacker);
	}

	public void SetSwarmManager(SwarmManager swarmManager)
	{
		_swarmManager = swarmManager;
		swarmManager.asRSwarmContinuous = swarmContinuousSound;
	}

	public override void NavigateToRoomMainWaypoint(Room room)
	{
		if (_swarmManager.IsAlphaEnemy(this))
		{
			_swarmManager.NavigateToRoomMainWaypoint(room);
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

	public void SetCombatTarget(ICombatTarget target)
	{
		_brain.SetCombatTarget(target);
	}

	public override void ReconnectOverlay()
	{
		if (uiOverlay != null)
		{
			uiOverlay.transform.parent = _simpleSwarmObject.transform;
		}
	}
}

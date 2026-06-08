using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolBotEnemy : BaseEnemy
{
	private const float PITCH_MOVE_FACTOR = 1.5f;

	private const float LURE_REMEMBER_TIME = 60f;

	public Color MaterialColor = Color.white;

	public AudioSource IdleAudio;

	public AudioSource TurretFireAudio;

	private float engineNormalPitch;

	private bool isEnabledInDV;

	private bool wasMovingLastFrame;

	private GameObject _spotlight;

	private bool _lightShouldBeOn;

	private bool _updatedVisualsForDeath;

	private float _lureMemoryResetTimer;

	private List<ICombatTarget> _luresToIgnore = new List<ICombatTarget>();

	private GameObject visualObject;

	private GameObject visualDeadObject;

	public override float BaseMoveSpeed
	{
		get
		{
			return 0.7f;
		}
	}

	public override float TotalHitpoints
	{
		get
		{
			return 100f;
		}
	}

	public override float AttackSpeed
	{
		get
		{
			return 0.15f;
		}
	}

	public override float AttackDamage
	{
		get
		{
			return 3f;
		}
	}

	public override float AttackRadius
	{
		get
		{
			return 3.5f;
		}
	}

	protected override ProjectileTypeEnum ProjectileType
	{
		get
		{
			return ProjectileTypeEnum.Medium;
		}
	}

	protected override EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.AttacksWhenHit | EnemyAiBehaviors.Wanders | EnemyAiBehaviors.AttacksDroneOnSight | EnemyAiBehaviors.AttractedToLures | EnemyAiBehaviors.AttacksProbes | EnemyAiBehaviors.CanMove | EnemyAiBehaviors.AttacksSensors | EnemyAiBehaviors.DetectsStealth | EnemyAiBehaviors.ImmuneToSonic;
		}
	}

	public bool LightIsOn
	{
		get
		{
			return _lightShouldBeOn;
		}
	}

	public override GameObject MainVisibleObject
	{
		get
		{
			return visualObject;
		}
	}

	protected override void OnAwake()
	{
		base.OnAwake();
		_spotlight = base.transform.FindChild("Spotlight").gameObject;
		visualObject = base.transform.FindChild("patrolBotMesh").transform.FindChild("default").gameObject;
		visualDeadObject = base.transform.FindChild("patrolBot_dead").transform.FindChild("default").gameObject;
		visualDeadObject.GetComponent<Renderer>().enabled = false;
		TurnOnLight(false);
		AddSoundSources();
	}

	protected override void OnStart()
	{
		_brain = new PatrolBotBrain(this);
		_brain.Initialize();
		((PatrolBotBrain)_brain).StatePatrolBotCombat.asRShot = TurretFireAudio;
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
	}

	protected override void OnDestroy()
	{
		IdleAudio = null;
		TurretFireAudio = null;
		_spotlight = null;
		visualObject = null;
		visualDeadObject = null;
		base.OnDestroy();
	}

	public override void Stun(float durationMin, float durationMax)
	{
		if (!IsDead)
		{
			float num = UnityEngine.Random.Range(durationMin, durationMax);
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
		if (!GlobalSettings.IsGamePaused && !IsDead)
		{
			AttemptScan();
			if (_lureMemoryResetTimer > 0f)
			{
				_lureMemoryResetTimer -= Time.deltaTime;
				if (_lureMemoryResetTimer <= 0f)
				{
					_luresToIgnore.Clear();
				}
			}
			foreach (ICombatTarget item in _attackerThreat.Keys.ToList())
			{
				float num = Vector3.Distance(Position, item.Position);
				if (num > AttackRadius)
				{
					_attackerThreat.Remove(item);
				}
			}
			if (isEnabledInDV && !GlobalSettings.IsGamePaused)
			{
				IdleAudio.volume = GameAudio.RemoteVolume * 1f;
				if (wasMovingLastFrame)
				{
					IdleAudio.pitch = engineNormalPitch * 1.5f;
				}
				else
				{
					IdleAudio.pitch = engineNormalPitch;
				}
			}
			if (GlobalSettings.cameraMode == CameraMode.Drone && ((PatrolBotBrain)_brain).StatePatrolBotCombat.asRShot.isPlaying)
			{
				((PatrolBotBrain)_brain).StatePatrolBotCombat.asRShot.volume = GameAudio.RemoteVolume * 1f;
			}
		}
		else if (IdleAudio.isPlaying)
		{
			IdleAudio.Pause();
		}
		wasMovingLastFrame = false;
	}

	protected override void OnMove()
	{
		wasMovingLastFrame = true;
	}

	public override void EnableRenderer(bool enabled)
	{
		if (!IsDead)
		{
			if (enabled && GlobalSettings.cameraMode == CameraMode.Schematic && !GlobalSettings.cheatMode)
			{
				return;
			}
			if (visualObject != null)
			{
				Renderer component = visualObject.GetComponent<Renderer>();
				if (component != null)
				{
					component.enabled = enabled;
				}
			}
			if (_lightShouldBeOn && enabled)
			{
				TurnOnLight(true);
			}
			else
			{
				TurnOnLight(false);
			}
			if (enabled)
			{
				IdleAudio.Play();
			}
			else
			{
				IdleAudio.Pause();
			}
			isEnabledInDV = enabled;
		}
		else if (visualDeadObject != null)
		{
			Renderer component2 = visualDeadObject.GetComponent<Renderer>();
			if (component2 != null)
			{
				component2.enabled = enabled;
			}
		}
	}

	protected override void OnDamageTaken(float damage, ICombatTarget attacker)
	{
		if (!IsDead || _updatedVisualsForDeath)
		{
			return;
		}
		_updatedVisualsForDeath = true;
		TurnOnLight(false);
		if (damage < 10000f)
		{
			int num = UnityEngine.Random.Range(1, 4);
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < num; i++)
			{
				if (CurrentRoom != null)
				{
					zero.x = UnityEngine.Random.Range(base.transform.position.x - 0.5f, base.transform.position.x + 0.5f);
					zero.y = UnityEngine.Random.Range(base.transform.position.y - 0.5f, base.transform.position.y + 0.5f);
					DungeonManager.Instance.PlaceLootInRoom(CurrentRoom, false, zero);
				}
				else
				{
					System.Random rnd = new System.Random();
					DungeonManager.Instance.PlaceLootInRoom(CurrentCorridor, false, rnd);
				}
			}
		}
		if (IdleAudio.isPlaying)
		{
			IdleAudio.Stop();
		}
		int num2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.PatrolBot), 0) + 1;
		GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.PatrolBot), num2);
		GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.PatrolBot), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.PatrolBot), 0) + num2);
		if (num2 > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.PatrolBot), 0))
		{
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.PatrolBot), num2);
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			EnableRenderer(true);
		}
	}

	private bool IsInFrontalCone(ICombatTarget possibleTarget)
	{
		float num = Vector3.Distance(base.transform.position, possibleTarget.Position);
		if (num <= AttackRadius)
		{
			Vector3 to = possibleTarget.Position - base.transform.position;
			Vector3 up = base.transform.up;
			up.Normalize();
			float f = Vector3.Angle(up, to);
			if (Mathf.Abs(f) <= 45f || Mathf.Abs(f) >= 315f)
			{
				return true;
			}
		}
		return false;
	}

	protected override ICombatTarget GetLocalDroneToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget result = null;
		foreach (Drone drones in _droneManager.dronesList)
		{
			if (drones.IsDead || IsTargetHidden(drones) || !TargetIsInSameRoom(drones) || !IsInFrontalCone(drones))
			{
				continue;
			}
			result = drones;
			break;
		}
		return result;
	}

	protected override ICombatTarget GetLocalLureToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget result = null;
		foreach (ICombatTarget availableLure in _droneManager.GetAvailableLures())
		{
			if (availableLure.IsDead || IsTargetHidden(availableLure) || !TargetIsInSameRoom(availableLure) || RemembersLure(availableLure))
			{
				continue;
			}
			_lureMemoryResetTimer = 60f;
			_luresToIgnore.Add(availableLure);
			result = availableLure;
			break;
		}
		return result;
	}

	protected override ICombatTarget GetLocalSensorToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget result = null;
		foreach (ICombatTarget availableSensor in _droneManager.GetAvailableSensors())
		{
			if (availableSensor.IsDead || IsTargetHidden(availableSensor) || !TargetIsInSameRoom(availableSensor))
			{
				continue;
			}
			result = availableSensor;
			break;
		}
		return result;
	}

	protected override ICombatTarget GetLocalProbeToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget result = null;
		foreach (ICombatTarget availableProbe in _droneManager.GetAvailableProbes())
		{
			if (availableProbe.IsDead || IsTargetHidden(availableProbe) || !TargetIsInSameRoom(availableProbe) || !IsInFrontalCone(availableProbe))
			{
				continue;
			}
			result = availableProbe;
			break;
		}
		return result;
	}

	public void TurnOnLight(bool turnOn)
	{
		_lightShouldBeOn = turnOn;
		if (visualObject.GetComponent<Renderer>().enabled && turnOn)
		{
			_spotlight.SetActive(true);
		}
		else
		{
			_spotlight.SetActive(false);
		}
	}

	public bool RemembersLure(ICombatTarget lure)
	{
		return _luresToIgnore.Contains(lure);
	}

	private void AddSoundSources()
	{
		engineNormalPitch = IdleAudio.pitch;
	}
}

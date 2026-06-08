using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DronesBestFriend : BaseEnemy
{
	private Collider _collider;

	private GameObject _visibleObject;

	public AudioSource[] BarkAudio;

	public AudioSource[] GrowlAudio;

	public AudioSource[] PantAudio;

	public AudioSource[] WalkAudio;

	public AudioSource[] WhineAudio;

	private bool _initialized;

	private Dictionary<ICombatTarget, float> _ignoreTargetMemory = new Dictionary<ICombatTarget, float>();

	private bool inDyingAnimationState;

	private List<ICombatTarget> _targetsToRemove = new List<ICombatTarget>(10);

	private AudioSource _currentWalkAudio;

	private float _wagTimer;

	private bool _shouldBeVisible;

	public override float BaseMoveSpeed
	{
		get
		{
			return 0.6f;
		}
	}

	public override float AttackDamage
	{
		get
		{
			return 0f;
		}
	}

	public override Collider ObjectCollider
	{
		get
		{
			return _collider;
		}
	}

	public GameObject RearLeftFeeler { get; private set; }

	public GameObject RearRightFeeler { get; private set; }

	public bool IsWagging { get; private set; }

	public override float ChargeSpeed
	{
		get
		{
			return 3.5f;
		}
	}

	public float RunSpeed
	{
		get
		{
			return 1.8f;
		}
	}

	protected override EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.Wanders | EnemyAiBehaviors.CanMove | EnemyAiBehaviors.DetectsStealth;
		}
	}

	protected override void OnStart()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		_brain = new DbfBrain(this);
		_brain.Initialize();
		_collider = base.gameObject.GetComponent<BoxCollider>();
		Transform transform = base.transform.Find("RearFeelers");
		Transform transform2;
		if (transform != null)
		{
			transform2 = transform.transform.Find("left");
			if (transform2 != null)
			{
				RearLeftFeeler = transform2.gameObject;
			}
			transform2 = transform.transform.Find("right");
			if (transform2 != null)
			{
				RearRightFeeler = transform2.gameObject;
			}
		}
		if (RearLeftFeeler == null || RearLeftFeeler == null)
		{
			Debug.LogWarning("Could not find rear left/right feelers!");
		}
		transform2 = base.transform.Find("AnimatorContainer");
		if (transform2 != null)
		{
			transform2 = transform2.Find("dbfFBXmesh+joints");
			if (transform2 != null)
			{
				transform2 = transform2.Find("dbf:Mesh");
				if (transform2 != null)
				{
					_visibleObject = transform2.gameObject;
				}
			}
		}
		if (_visibleObject == null)
		{
			Debug.LogWarning("could not find visual object for dbf");
		}
		if (BarkAudio == null || GrowlAudio == null || PantAudio == null || WalkAudio == null || WhineAudio == null)
		{
			Debug.LogWarning("audio for dbf not initialized properly");
		}
		_initialized = true;
	}

	public override ICombatTarget SelectBestCombatTarget()
	{
		ICombatTarget combatTarget = null;
		if (combatTarget == null)
		{
			combatTarget = GetLocalDroneToAttack();
		}
		if (combatTarget == null)
		{
			combatTarget = GetLocalLureToAttack();
		}
		if (combatTarget == null)
		{
			combatTarget = GetLocalProbeToAttack();
		}
		if (combatTarget == null)
		{
			combatTarget = GetLocalEnemyToAttack();
		}
		return combatTarget;
	}

	protected ICombatTarget GetLocalEnemyToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget combatTarget = null;
		float num = float.MaxValue;
		foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
		{
			if (!(enemy == this) && !enemy.IsDead && !IsTargetHidden(enemy) && TargetIsInSameRoom(enemy) && !_ignoreTargetMemory.ContainsKey(enemy))
			{
				float num2 = Vector3.Distance(enemy.Position, Position);
				if (num2 < num || combatTarget == null)
				{
					combatTarget = enemy;
					num = num2;
				}
			}
		}
		return combatTarget;
	}

	protected override ICombatTarget GetLocalDroneToAttack()
	{
		ICombatTarget combatTarget = null;
		float num = float.MaxValue;
		foreach (Drone drones in _droneManager.dronesList)
		{
			if (!drones.IsDead && !IsTargetHidden(drones) && TargetIsInSameRoom(drones) && !_ignoreTargetMemory.ContainsKey(drones))
			{
				float num2 = Vector3.Distance(drones.Position, Position);
				if (num2 < num || combatTarget == null)
				{
					combatTarget = drones;
					num = num2;
				}
			}
		}
		return combatTarget;
	}

	protected override ICombatTarget GetLocalProbeToAttack()
	{
		ICombatTarget combatTarget = null;
		return _droneManager.GetAvailableProbes().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && TargetIsInSameRoom(x) && !_ignoreTargetMemory.ContainsKey(x));
	}

	protected override ICombatTarget GetLocalLureToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget combatTarget = null;
		combatTarget = _droneManager.GetAvailableLures().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && TargetIsInSameRoom(x) && !_ignoreTargetMemory.ContainsKey(x));
		if (CurrentRoom != null && combatTarget == null)
		{
			IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(CurrentRoom)
				where AdjacentRoomCanBeEntered(x)
				select x;
			foreach (AdjacentRoomData item in enumerable)
			{
				Room adjacentRoom;
				if (item.Room1 == CurrentRoom)
				{
					adjacentRoom = item.Room2;
				}
				else
				{
					adjacentRoom = item.Room1;
				}
				combatTarget = _droneManager.GetAvailableLures().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && x.CurrentRoom == adjacentRoom && !_ignoreTargetMemory.ContainsKey(x));
				if (combatTarget != null)
				{
					break;
				}
			}
		}
		return combatTarget;
	}

	public void StartWagging()
	{
		IsWagging = true;
		if (animator != null)
		{
			float transitionDuration = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
			animator.SetTrigger("StartWag");
			animator.CrossFade("StartWag", transitionDuration);
		}
	}

	public void StopWagging()
	{
		IsWagging = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (GlobalSettings.IsGamePaused || !GlobalSettings.MissionStarted)
		{
			return;
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic && _currentWalkAudio != null && _currentWalkAudio.isPlaying)
		{
			_currentWalkAudio.Stop();
		}
		if (_ignoreTargetMemory.Count > 0)
		{
			_targetsToRemove.Clear();
			foreach (ICombatTarget item in _ignoreTargetMemory.Keys.ToList())
			{
				float num = _ignoreTargetMemory[item];
				num -= Time.deltaTime;
				if (num <= 0f)
				{
					_targetsToRemove.Add(item);
				}
				else
				{
					_ignoreTargetMemory[item] = num;
				}
			}
			_targetsToRemove.ForEach(delegate(ICombatTarget x)
			{
				_ignoreTargetMemory.Remove(x);
			});
			_targetsToRemove.Clear();
		}
		if (_wagTimer > 0f && !IsDead)
		{
			_wagTimer -= Time.deltaTime;
		}
		else if (IsWagging)
		{
			StopWagging();
		}
		if (_currentWalkAudio != null && _currentWalkAudio.isPlaying)
		{
			_currentWalkAudio.volume = GameAudio.RemoteVolume;
		}
		if (IsDead && inDyingAnimationState && animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animator.GetCurrentAnimatorStateInfo(0).length * 0.35f)
		{
			inDyingAnimationState = false;
			SwitchToDeadModel();
		}
	}

	public void PlayBarkSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			AudioSource audioSource = CommonMethods.PickRandomItem(BarkAudio);
			if (audioSource != null)
			{
				audioSource.Play();
				audioSource.volume = GameAudio.RemoteVolume;
			}
			else
			{
				Debug.LogWarning("no bark found!");
			}
		}
	}

	public void PlayGrowlSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			AudioSource audioSource = CommonMethods.PickRandomItem(GrowlAudio);
			if (audioSource != null)
			{
				audioSource.Play();
				audioSource.volume = GameAudio.RemoteVolume;
			}
			else
			{
				Debug.LogWarning("no growl found!");
			}
		}
	}

	public void PlayWhineSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			AudioSource audioSource = CommonMethods.PickRandomItem(WhineAudio);
			if (audioSource != null)
			{
				audioSource.Play();
				audioSource.volume = GameAudio.RemoteVolume;
			}
			else
			{
				Debug.LogWarning("no whine found!");
			}
		}
	}

	public void PlayPantSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			AudioSource audioSource = CommonMethods.PickRandomItem(PantAudio);
			if (audioSource != null)
			{
				audioSource.Play();
				audioSource.volume = GameAudio.RemoteVolume;
			}
			else
			{
				Debug.LogWarning("no pant found!");
			}
		}
	}

	public void StartWalkSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			_currentWalkAudio = CommonMethods.PickRandomItem(WalkAudio);
			if (_currentWalkAudio != null)
			{
				_currentWalkAudio.Play();
				_currentWalkAudio.volume = GameAudio.RemoteVolume;
			}
			else
			{
				Debug.LogWarning("no walk sound found!");
			}
		}
	}

	public void StopWalkAudio()
	{
		if (WalkAudio != null)
		{
			for (int i = 0; i < WalkAudio.Length; i++)
			{
				WalkAudio[i].Stop();
			}
			_currentWalkAudio = null;
		}
	}

	public void PlaySniffSound()
	{
		Debug.Log("SNIFF!!! - " + Time.time);
	}

	public void StartTimedWag(float wagTime)
	{
		_wagTimer = wagTime;
		StartWagging();
	}

	public override void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		bool isDead = IsDead;
		base.TakeDamage(damage, type, attacker);
		if (!isDead && IsDead)
		{
			PlayWhineSound();
			UniverseSaveFile.Save("DBF_DIED", UniverseSaveFile.Get("DBF_DIED", 0) + 1);
		}
	}

	public void IgnoreTarget(ICombatTarget target, float duration)
	{
		_ignoreTargetMemory[target] = duration;
	}

	public override void EnableRenderer(bool enabled)
	{
		Initialize();
		_visibleObject.GetComponent<Renderer>().enabled = enabled;
		_shouldBeVisible = enabled;
	}

	protected override void OnDamageTaken(float damage, ICombatTarget attacker)
	{
		if (IsDead)
		{
			if (_brain != null && _brain.StartDeathAnimation())
			{
				inDyingAnimationState = true;
			}
			if (_currentWalkAudio != null)
			{
				_currentWalkAudio.Stop();
			}
		}
	}
}

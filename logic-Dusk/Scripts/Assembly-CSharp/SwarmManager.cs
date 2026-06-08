using System.Collections.Generic;
using UnityEngine;

public class SwarmManager
{
	private List<SwarmEnemy> _swarmEnemies = new List<SwarmEnemy>();

	private SwarmBrain _brain;

	public AudioSource asRSwarmContinuous;

	private SwarmEnemy previousAlpha;

	private List<ICombatTarget> _emptyCombatTargetList = new List<ICombatTarget>();

	public string CurrentState
	{
		get
		{
			return _brain.CurrentState;
		}
	}

	public bool IsVaporizing { get; private set; }

	public bool CanSeeThroughStealth
	{
		get
		{
			return _brain.CanSeeThroughStealth;
		}
	}

	public SwarmManager()
	{
		_brain = new SwarmBrain(this);
		_brain.Initialize();
	}

	private void OnDestroy()
	{
		RemoveSoundSources();
	}

	public void AddSwarmEnemy(SwarmEnemy swarmEnemy)
	{
		_swarmEnemies.Add(swarmEnemy);
		swarmEnemy.SetSwarmManager(this);
	}

	public void NotifyOfDamage(SwarmEnemy enemyGettingDamaged, float damage, ICombatTarget attacker)
	{
		SwarmEnemy alphaEnemy = GetAlphaEnemy();
		if (alphaEnemy != null && attacker != null && enemyGettingDamaged != alphaEnemy)
		{
			alphaEnemy.ApplyDamageAsThreat(damage, attacker);
		}
	}

	public void Update()
	{
		SwarmEnemy alphaEnemy = GetAlphaEnemy();
		if (!GlobalSettings.IsGamePaused)
		{
			if (alphaEnemy != null)
			{
				if (previousAlpha != alphaEnemy)
				{
					AddSoundSources(alphaEnemy);
					if (previousAlpha != null)
					{
						previousAlpha.gameObject.GetComponent<AudioSource>().enabled = false;
					}
					previousAlpha = alphaEnemy;
				}
				_brain.Update();
				int count = _swarmEnemies.Count;
				for (int i = 0; i < count; i++)
				{
					SwarmEnemy swarmEnemy = _swarmEnemies[i];
					if (swarmEnemy.CurrentTarget != _brain.CombatTarget)
					{
						swarmEnemy.SetCombatTarget(_brain.CombatTarget);
					}
					if (swarmEnemy != alphaEnemy && swarmEnemy.transform.position != alphaEnemy.transform.position)
					{
						swarmEnemy.SetPosition(alphaEnemy.transform.position);
					}
					if (!alphaEnemy.IsStunned && swarmEnemy.IsStunned)
					{
						swarmEnemy.ClearStun();
					}
					swarmEnemy.AttemptScan();
				}
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					if (alphaEnemy.CurrentRoom != null && !asRSwarmContinuous.isPlaying)
					{
						asRSwarmContinuous.Play();
					}
				}
				else if (GlobalSettings.cameraMode == CameraMode.Schematic && asRSwarmContinuous.isPlaying)
				{
					asRSwarmContinuous.Stop();
				}
				if (asRSwarmContinuous.isPlaying)
				{
					asRSwarmContinuous.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_Swarm, GameAudio.RemoteVolume);
				}
			}
			else if (asRSwarmContinuous != null && asRSwarmContinuous.isPlaying)
			{
				asRSwarmContinuous.Stop();
			}
		}
		else if (asRSwarmContinuous.isPlaying)
		{
			asRSwarmContinuous.Pause();
		}
	}

	public bool IsAlphaEnemy(SwarmEnemy enemy)
	{
		return GetAlphaEnemy() == enemy;
	}

	public SwarmEnemy GetAlphaEnemy()
	{
		int count = _swarmEnemies.Count;
		for (int i = 0; i < count; i++)
		{
			if (!_swarmEnemies[i].IsDead)
			{
				return _swarmEnemies[i];
			}
		}
		return null;
	}

	public void Vaporize()
	{
		if (IsVaporizing)
		{
			return;
		}
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			swarmEnemy.Vaporize();
			swarmEnemy.gameObject.GetComponent<Renderer>().enabled = false;
			swarmEnemy.gameObject.SetActive(false);
		}
		EnemyManager.Instance.ForgetSwarmManager(this);
		IsVaporizing = true;
	}

	public List<ICombatTarget> GetSubordinateEnemies(SwarmEnemy requestingEnemy)
	{
		List<ICombatTarget> list = null;
		bool flag = false;
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			if (!swarmEnemy.IsDead && !flag)
			{
				if (requestingEnemy != swarmEnemy)
				{
					break;
				}
				flag = true;
				list = new List<ICombatTarget>();
			}
			else if (!swarmEnemy.IsDead && flag)
			{
				list.Add(swarmEnemy);
			}
		}
		if (flag)
		{
			return list;
		}
		return _emptyCombatTargetList;
	}

	public void NavigateToRoomMainWaypoint(Room room)
	{
		Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room);
		_brain.ForceNavigateToWaypoint(mainRoomWaypoint);
	}

	public void SetPosition(Vector3 position)
	{
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			swarmEnemy.SetPosition(position);
		}
	}

	public void SetSwarmPosition(Vector3 newPosition)
	{
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			swarmEnemy.SetPosition(newPosition);
			swarmEnemy.MainVisibleObject.transform.position = newPosition;
		}
	}

	public void SetTravelingInShip(bool isTraveling)
	{
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			swarmEnemy.TravelingInShip = isTraveling;
		}
	}

	private void AddSoundSources(BaseEnemy enemy)
	{
		asRSwarmContinuous.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Remote_Swarm, GameAudio.RemoteVolume);
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_Swarm);
	}

	public void SetIndividualFlightSpeed(float speed)
	{
		foreach (SwarmEnemy swarmEnemy in _swarmEnemies)
		{
			swarmEnemy.CurrentFlightSpeed = speed;
		}
	}
}

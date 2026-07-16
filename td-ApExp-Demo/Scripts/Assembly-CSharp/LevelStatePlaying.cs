using System.Collections.Generic;
using UnityEngine;

public class LevelStatePlaying : LevelBaseState
{
	private LevelManager lm;

	private float sandstormTimer;

	private bool sandstormSpawned;

	private bool isDebugSpeedInUse;

	public override string Key => "Playing";

	public LevelStatePlaying(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Slowing" };
	}

	public override bool CanEnter()
	{
		isDebugSpeedInUse = false;
		if (!lm)
		{
			lm = LevelManager.Instance;
		}
		if (LevelUtils.GetLevelAtGlobalIndex(Train.Instance.TrainGlobalIndex).Index == lm.CurrentLevel.Index)
		{
			return Train.Instance.SpeedCurrent >= Train.Instance.SpeedMax;
		}
		return false;
	}

	public override void EnterState()
	{
		Debug.Log("OnLevelStarted");
		Debug.LogWarning("OnLevelStarted");
		lm = LevelManager.Instance;
		LevelManager.Instance.AdvanceToNextLevel();
		LevelManager.Instance.OnLevelStarted();
		DialogueManager.Instance.TryStartDialogueForWorldInLevel(ZoneManager.Instance.CurrentZoneIndex, lm.CurrentLevel.WorldIndex);
		if (lm.CurrentLevel.LevelType == LevelType.Boss)
		{
			EnemyManager.Instance.SpawnBoss();
		}
		List<TrackEventSwitch> switches = lm.CurrentLevel.Switches;
		if (switches != null && switches.Count > 0)
		{
			switches[0].StartEvent();
		}
		List<TrackEventResource> resources = lm.CurrentLevel.Resources;
		if (resources != null && resources.Count > 0)
		{
			resources[0].StartEvent();
		}
		PlayerManager.Instance.SetPlayerInteractablesForTrain();
		LevelManager.Instance.CurrentLevel.OnPlaying();
		if (ZoneManager.Instance.CurrentZone.Definition.name == "T0_Tutorial" || ZoneManager.Instance.CurrentZone.Definition.name == "Z1_Wasteland")
		{
			Train.Instance.hideDust = false;
		}
		sandstormTimer = lm.SandstormStartTime + lm.SandstormStartTime * DifficultyManager.Instance.stormSpawnModifier;
		sandstormSpawned = false;
	}

	public override void UpdateState()
	{
		if (lm.CurrentLevel.LevelType == LevelType.Waves)
		{
			EnemyManager.Instance.PlayUpdate();
		}
		lm.TrackEventUpdates(lm.CurrentLevel.Switches);
		lm.TrackEventUpdates(lm.CurrentLevel.Resources);
		Train.Instance.Move();
		sandstormTimer -= Time.deltaTime;
		if (sandstormTimer < 0f && !sandstormSpawned)
		{
			sandstormSpawned = true;
			lm.SpawnSandstorm();
		}
	}

	public override bool CanExit()
	{
		return lm.CurrentLevelProgress01 >= 1f;
	}

	public override void ExitState()
	{
		lm.DespawnSandstorm();
		if (isDebugSpeedInUse)
		{
			Train.Instance.SetAllModulesImmunity(Train.Instance.DebugIsImmune);
			Train.Instance.DebugSpeedOff();
			isDebugSpeedInUse = false;
		}
	}
}

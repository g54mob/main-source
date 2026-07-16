using UnityEngine;

public class LevelStateStation : LevelBaseState
{
	private bool startedFadeIn;

	public override string Key => "Station";

	public LevelStateStation(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Starting" };
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		if (LevelManager.Instance.CurrentLevel == null)
		{
			Debug.LogError("CurrentLevel is null in LevelStateStation");
			return;
		}
		Debug.Log("OnDestinationReached");
		startedFadeIn = false;
		LevelManager.Instance.CurrentLevel.GlobalStartDistance = 0f;
		if (LevelManager.Instance.SetUpNextZoneOnStation)
		{
			Debug.Log("Entered SetUpNextZoneOnStation");
			LevelManager.Instance.SetUpNextZoneOnStation = false;
			LevelManager.Instance.ResetLevelHistoryToHUB();
			LevelManager.Instance.TryAddLevelToHistory(0);
			ZoneManager.Instance.SetNextZone(saveLevels: true);
		}
		if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub)
		{
			if (ZoneManager.Instance.CurrentZoneIndex <= 0)
			{
				LevelManager.Instance.TryStartFirstLevel();
				UIManager.Instance.HUD.hideFlags = HideFlags.HideInHierarchy;
				return;
			}
			DialogueManager.Instance.TryStartDialogueForWorldInLevel(ZoneManager.Instance.CurrentZoneIndex, 0);
		}
		PlayerManager.Instance.ResolvePlayerInteractorConflict();
		LevelManager.Instance.OnDestinationReached();
	}

	public override void UpdateState()
	{
		EnemyManager.Instance.ForceEnemyTotalClear();
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
		GameManager.Instance.hubExitCollider.gameObject.SetActive(value: false);
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.interactor.whitelist = null;
		}
		Debug.Log("Exited LevelStateStation");
	}
}

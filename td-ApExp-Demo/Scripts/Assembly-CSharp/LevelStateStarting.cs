using UnityEngine;

public class LevelStateStarting : LevelBaseState
{
	public override string Key => "Starting";

	public LevelStateStarting(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Playing" };
	}

	public override void Initialize()
	{
		base.Initialize();
	}

	public override bool CanEnter()
	{
		return LevelManager.Instance.NextLevel != null;
	}

	public override void EnterState()
	{
		Debug.Log("OnLevelStateStarting");
		Debug.LogWarning("OnLevelStateStarting");
		SaveManager.Instance.ColectedLevelReward = false;
		CameraController.Instance.ZoomOut();
		LevelManager.Instance.OnLevelStarting();
		LevelManager.Instance.CurrentLevel.OnStarting();
		PlayerManager.Instance.RefreshPlayerInteractors();
		Train.Instance.RemoveSlowDebuff();
	}

	public override void UpdateState()
	{
		Train.Instance.Move();
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
		CameraController.Instance.ZoomIn();
		Train.Instance.SetRoofVisibilities(visible: false);
	}
}

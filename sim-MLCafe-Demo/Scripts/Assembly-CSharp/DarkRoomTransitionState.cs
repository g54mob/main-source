using System;

public class DarkRoomTransitionState : TransitionState
{
	private bool exit;

	private bool condition;

	private Action OnFinished;

	public override void OnEnter()
	{
		if (DarkRoomManager.GetTriggerLevelEncounter())
		{
			OnFinished = DarkRoomManager.PlayDarkRoomLevelSequence;
		}
		else if (DarkRoomManager.GetTriggerRandomDayEncounter())
		{
			OnFinished = DarkRoomManager.PlayDarkRoomDiceGameSequence;
		}
		if (OnFinished == null)
		{
			OnEnter();
			return;
		}
		SoundManager.ChangeMusic("ambient_music_darkroom");
		MouseCursorInteraction.Deactivate();
		CameraManager.SwitchActiveCameraController(CameraManager.ActiveCameraState.DarkRoomCamera);
		TransitionManager.TriggerTransitionExit(2f, OnFinished);
		condition = false;
		exit = false;
	}

	public override void OnExit()
	{
		SoundManager.ChangeMusic("ambient_music_base");
		CameraManager.SwitchActiveCameraController(CameraManager.ActiveCameraState.PlayerCamera);
		MouseCursorInteraction.Activate();
	}

	public override void OnUpdate()
	{
		if (!DarkRoomManager.IsRunningDarkRoomSequence() && !exit)
		{
			DarkRoomManager.ExitDarkRoom();
			TransitionManager.TriggerTransitionEnter(2f, delegate
			{
				condition = true;
			});
			exit = true;
		}
	}

	public override bool ExitCondition()
	{
		return condition;
	}
}

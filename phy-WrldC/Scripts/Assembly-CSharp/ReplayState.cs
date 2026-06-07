using System.Collections;
using UltimateReplay;
using UnityEngine;

public class ReplayState : State<GameManager>
{
	private ReplayController replayController;

	private bool isUIVisible;

	private bool isExiting;

	public static ReplayState Instance { get; }

	static ReplayState()
	{
		Instance = new ReplayState();
	}

	private ReplayState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		replayController = gameManager.GUIManager.ReplayController;
	}

	public override void Enter(GameManager gameManager)
	{
		isExiting = false;
		isUIVisible = true;
		replayController.view.SetVisibility(isVisible: true);
		replayController.view.SetPlayPauseButtonState(isReplayPlaying: true);
		replayController.view.GifRecordingView.SetGifViewMode(GifRecordingView.GifViewMode.New);
		gameManager.CameraManager.RestoresMainCamera();
		ReplayManager.BeginPlayback();
	}

	public override void Execute(GameManager gameManager)
	{
		if (!isExiting)
		{
			replayController.view.SetTimerSliderValue(ReplayManager.CurrentPlaybackTimeNormalized, ReplayManager.Target.Duration);
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				ExitFromReplay();
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				replayController.InvertPlayPauseStatus();
			}
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.H))
			{
				isUIVisible = !isUIVisible;
				replayController.view.SetVisibility(isUIVisible);
			}
		}
	}

	public override void Exit(GameManager gameManager)
	{
		replayController.ClearLastGifRecording();
		replayController.CheckAndSaveRecordingSettings();
	}

	public void ExitFromReplay()
	{
		if (CanExitFromState())
		{
			GameManager.Instance.StartCoroutine(ExitFromState());
		}
	}

	private IEnumerator WaitOneFrameToExit(GameManager gameManager)
	{
		yield return new WaitForEndOfFrame();
		gameManager.ExitSubState();
	}

	public IEnumerator ExitFromState()
	{
		if (ReplayManager.CurrentPlaybackTimeNormalized == 0f)
		{
			ReplayManager.SetPlaybackFrame(1f / (float)ReplayManager.Instance.recordFPS);
		}
		ReplayManager.StopPlayback();
		replayController.view.SetVisibility(isVisible: false);
		isExiting = true;
		yield return GameManager.Instance.StartCoroutine(WaitOneFrameToExit(GameManager.Instance));
	}

	public bool CanExitFromState()
	{
		int num;
		if (!replayController.IsGifRecording)
		{
			num = ((!replayController.IsGifSaving) ? 1 : 0);
			if (num != 0)
			{
				goto IL_0051;
			}
		}
		else
		{
			num = 0;
		}
		string text = LanguagesManager.Instance.GetText("warning.text.replay.gif.exit", "Can't exit while GIF is recording/saving!");
		GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
		goto IL_0051;
		IL_0051:
		return (byte)num != 0;
	}
}

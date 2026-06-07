using System;
using UltimateReplay;
using UnityEngine;

public class ActionState : State<GameManager>
{
	private ActionModeView actionModeView;

	private bool isUIVisible;

	private float[] timeScales;

	private int timeScalesIndex;

	private float originalFixedDeltaTime;

	public static ActionState Instance { get; }

	public event Action OnActionStartEvent;

	public event Action OnActionEndEvent;

	static ActionState()
	{
		Instance = new ActionState();
	}

	private ActionState()
	{
	}

	public override void Start(GameManager GAME)
	{
		actionModeView = GAME.GUIManager.ActionModeView;
		timeScales = new float[4] { 1f, 0.5f, 0.1f, 0f };
		timeScalesIndex = 0;
		originalFixedDeltaTime = Time.fixedDeltaTime;
	}

	public override void Enter(GameManager GAME)
	{
		GAME.MainCreationController.view.IsUnbreakableCreation = GAME.CheatModel.IsUnbreakableCreation;
		GAME.MainCreationController.view.IsUnlimitedAmmo = GAME.CheatModel.IsUnlimitedAmmo;
		if (GAME.GameMode == GameManager.GameModeState.Attacker)
		{
			if (GAME.LevelType != GameManager.LevelTypeState.Tutorial)
			{
				CreationModelBuilder.SaveXml(GAME.MainCreationController.model, PathNames.CurrentCreationDataAES, isFileEncrypted: true);
			}
			GAME.AttackerCreationController.view.ActiveCreation();
		}
		else if (GAME.GameMode == GameManager.GameModeState.Defender)
		{
			CreationModel defenderCreationModel = CreationCloner.Clone(GAME.DefenderCreationController.model);
			GAME.LevelController.model.DefenderCreationModel = defenderCreationModel;
			LevelModelBuilder.SaveXml(GAME.LevelController.model, PathNames.UserLevels);
		}
		GAME.DefenderCreationController.view.ActiveCreation();
		GAME.CameraManager.SaveMainCameraStatus(GAME.MainCreationController.model);
		if (GAME.GetPreviousState() != ResetLevelState.Instance)
		{
			GAME.CameraManager.FocusMainCameraOnBrainBlock(GAME.MainCreationController, shouldReplaceLastFocus: false);
		}
		GAME.LevelManager.SetLevelMode(isEditing: false);
		GAME.LevelManager.SetUpToActionDynamicObjects();
		actionModeView.SetCreationForKeyList(GAME.MainCreationController.model);
		LevelModel model = GAME.LevelController.model;
		actionModeView.SetCollectablesVisibility(model.IsThereCollectables && model.IsLevelCompleted);
		actionModeView.SetCollectablesCount(model.GoldCollectableCounter, model.GoldCollectableTotal, model.SilverCollectableCounter, model.SilverCollectableTotal);
		if (model.LevelStatus != null)
		{
			var (bestTime, starType) = model.LevelStatus.BestTimeEver();
			actionModeView.SetBestTime(bestTime, starType, model.IsThereCollectables);
		}
		else
		{
			actionModeView.SetBestTime(model.BestTime, LevelStatus.StarType.None, isStarsVisible: false);
		}
		actionModeView.SetVisibility(isVisible: true);
		isUIVisible = true;
		AudioClip actionModeClip = GAME.GameStylesData.musicStylesData.actionModeClip;
		GAME.MusicManager.PlayMusic(actionModeClip, GAME.GameStylesData.volumeStylesData.musicVolume * 0.5f);
		if (!GAME.OptionsModel.IsReplayDisabled)
		{
			ReplayManager.BeginRecording();
			float num = (float)ReplayManager.Target.MemorySize / 1024f * 15f * 60f;
			Debug.Log("Replay Size: " + num + " kb");
		}
		this.OnActionStartEvent?.Invoke();
	}

	public override void EnterFromSubState(GameManager gameManager)
	{
		base.EnterFromSubState(gameManager);
		actionModeView.SetVisibility(isVisible: true);
		if (!gameManager.OptionsModel.IsReplayDisabled)
		{
			ReplayManager.BeginRecording();
		}
	}

	public override void Execute(GameManager GAME)
	{
		if (GAME.LevelController.view != null && GAME.LevelController.view.IsLevelRunning)
		{
			actionModeView.SetCurrentTime(GAME.LevelController.view.LevelTimerCounter);
		}
		bool flag = Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R);
		if (Input.GetKeyDown(KeyCode.Escape) || flag)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GAME.SetSubState(PauseState.Instance);
			}
			else
			{
				ReplayManager.StopRecording();
				GAME.ResetLevel();
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GAME.CameraManager.FocusMainCameraOnBrainBlock(GAME.MainCreationController);
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.H))
		{
			isUIVisible = !isUIVisible;
			actionModeView.SetVisibility(isUIVisible);
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J))
		{
			GAME.LevelController.view.SetCollectablesInteractivity(isInteractive: false);
		}
	}

	private void ChangeTimeSpeed()
	{
		bool keyDown = Input.GetKeyDown(KeyCode.KeypadMinus);
		bool keyDown2 = Input.GetKeyDown(KeyCode.KeypadPlus);
		bool keyDown3 = Input.GetKeyDown(KeyCode.Equals);
		if (keyDown || keyDown2 || keyDown3)
		{
			if (keyDown)
			{
				timeScalesIndex++;
			}
			else if (keyDown2)
			{
				timeScalesIndex--;
			}
			else if (keyDown3)
			{
				timeScalesIndex = ((timeScalesIndex == 0) ? 3 : 0);
			}
			timeScalesIndex = Mathf.Clamp(timeScalesIndex, 0, timeScales.Length - 1);
			Time.timeScale = timeScales[timeScalesIndex];
			Time.fixedDeltaTime = originalFixedDeltaTime * ((Time.timeScale == 0f) ? 1f : Time.timeScale);
			Debug.Log("Time Scale Changed = " + Time.timeScale + " fixedTimeDelta = " + Time.fixedDeltaTime);
		}
	}

	public override void ExitToSubState(GameManager gameManager)
	{
		base.ExitToSubState(gameManager);
		actionModeView.SetVisibility(isVisible: false);
		if (!gameManager.OptionsModel.IsReplayDisabled)
		{
			ReplayManager.StopRecording();
		}
	}

	public override void Exit(GameManager GAME)
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = originalFixedDeltaTime;
		timeScalesIndex = 0;
		actionModeView.SetVisibility(isVisible: false);
		this.OnActionEndEvent?.Invoke();
	}
}

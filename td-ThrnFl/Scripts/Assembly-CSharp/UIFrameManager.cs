using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIFrameManager : MonoBehaviour
{
	private struct FrameStackElement
	{
		public UIFrame frame;

		public ThronefallUIElement selectedElement;

		public FrameStackElement(UIFrame _frame, ThronefallUIElement _selectedElement = null)
		{
			frame = _frame;
			selectedElement = _selectedElement;
		}
	}

	public static UIFrameManager instance;

	[SerializeField]
	private Texture2D defaultCursor;

	[SerializeField]
	private float timeBeforeHideIdleCursor = 3f;

	[SerializeField]
	private string titleFrameSceneName = "_StartMenu";

	[SerializeField]
	private UIFrame titleFrame;

	[SerializeField]
	private UIFrame overworldPauseMenuFrame;

	[SerializeField]
	private UIFrame inMatchPauseMenuFrame;

	[SerializeField]
	private UIFrame levelSelectFrame;

	[SerializeField]
	private UIFrame bonusLevelSelectFrame;

	[SerializeField]
	private UIFrame eternalTrialsSelectFrame;

	[SerializeField]
	private UIFrame eternalTrialsLoadoutPickFrame;

	[SerializeField]
	private UIFrame endOfMatchFrame;

	[SerializeField]
	private UIFrame levelUpRewardFrame;

	[SerializeField]
	private UIFrame choiceFrame;

	[SerializeField]
	private UIFrame resetControlsFrame;

	[SerializeField]
	private UIFrame inmatchPerkSelectFrame;

	private UIFrame activeFrame;

	private List<UIFrame> frames = new List<UIFrame>();

	private Player input;

	private Stack<FrameStackElement> frameStack = new Stack<FrameStackElement>();

	[SerializeField]
	private RectTransform inGameUIContainer;

	[SerializeField]
	private RectTransform onScreenMarkerContainer;

	[SerializeField]
	private TreasureChestUIHelper treasureChest;

	[SerializeField]
	private EternalTrialsStageCountDisplay eternalTrialsStageDisplay;

	[HideInInspector]
	public UnityEvent onFrameOpen = new UnityEvent();

	private SceneTransitionManager sceneTransitionManager;

	private float idleCursorClock;

	public UIFrame ActiveFrame => activeFrame;

	public RectTransform InGameUIContainer => inGameUIContainer;

	public RectTransform OnScreenMarkerContainer => onScreenMarkerContainer;

	public TreasureChestUIHelper TreasureChest => treasureChest;

	public EternalTrialsStageCountDisplay EternalTrialsStageDisplay => eternalTrialsStageDisplay;

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	private void Start()
	{
		if (SceneManager.sceneCount <= 1)
		{
			SceneManager.LoadScene(titleFrameSceneName, LoadSceneMode.Additive);
		}
		foreach (UIFrame frame in frames)
		{
			frame.Deactivate();
		}
		if (IsSceneLoaded(titleFrameSceneName))
		{
			SwitchToTitleFrame();
		}
		input = ReInput.players.GetPlayer(0);
		sceneTransitionManager = SceneTransitionManager.instance;
		sceneTransitionManager.onSceneChange.AddListener(UpdateUIBasedOnCurrentScene);
		UpdateUIBasedOnCurrentScene();
		Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
	}

	public void SwitchToTitleFrame()
	{
		ChangeActiveFrame(titleFrame);
	}

	public bool IsSceneLoaded(string sceneName)
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			if (SceneManager.GetSceneAt(i).name == sceneName)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
		if (sceneTransitionManager != null && sceneTransitionManager.SceneTransitionIsRunning)
		{
			return;
		}
		if (input.GetButtonDown("Pause Menu"))
		{
			OpenMenu();
		}
		else if (input.GetButtonDown("Cancel"))
		{
			Cancel();
		}
		if (input.GetButtonDown("Change Colorscheme") && (bool)ColorAndLightManager.Instance && !ColorAndLightManager.Instance.forbidColorschemeCycle)
		{
			ColorAndLightManager.Instance.CycleToNextColorscheme();
		}
		if (input.controllers.hasMouse && (input.controllers.Mouse.screenPositionDelta.x > 0f || input.controllers.Mouse.screenPositionDelta.y > 0f))
		{
			idleCursorClock = 0f;
			if (!Cursor.visible)
			{
				Cursor.visible = true;
			}
		}
		if (activeFrame == null || activeFrame.CurrentSelection == null || activeFrame.MouseSleeping)
		{
			idleCursorClock += Time.unscaledDeltaTime;
		}
		if (idleCursorClock > timeBeforeHideIdleCursor && Cursor.visible)
		{
			Cursor.visible = false;
		}
	}

	private void Cancel()
	{
		if (activeFrame != null && activeFrame != titleFrame && !activeFrame.canNotBeEscaped)
		{
			CloseActiveFrame();
		}
	}

	private void OpenMenu()
	{
		if (activeFrame != null && !activeFrame.canNotBeEscaped)
		{
			CloseActiveFrame();
		}
		else if (activeFrame == null && SceneManager.GetSceneByName(SceneTransitionManager.instance.levelSelectScene).IsValid())
		{
			ChangeActiveFrame(overworldPauseMenuFrame);
		}
		else if (activeFrame == null)
		{
			ChangeActiveFrame(inMatchPauseMenuFrame);
		}
	}

	public void RegisterFrame(UIFrame frame)
	{
		frames.Add(frame);
	}

	public void ChangeActiveFrame(UIFrame nextFrame)
	{
		ProcessFrameChange(nextFrame, writeOldFrameToStack: true);
	}

	public void ChangeActiveFrameKeepOldVisible(UIFrame nextFrame)
	{
		ProcessFrameChange(nextFrame, writeOldFrameToStack: true, keepOldFrameGameObjectActive: true);
	}

	private void ProcessFrameChange(UIFrame nextFrame, bool writeOldFrameToStack, bool keepOldFrameGameObjectActive = false, ThronefallUIElement firstSelected = null)
	{
		if (nextFrame != null)
		{
			if (LocalGamestate.Instance != null)
			{
				LocalGamestate.Instance.SetPlayerFreezeState(nextFrame.freezePlayer);
			}
			if (nextFrame.freezeTime)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = PlayerMovement.gameplayTimeScale;
			}
			if (activeFrame != null && writeOldFrameToStack)
			{
				frameStack.Push(new FrameStackElement(activeFrame, activeFrame.CurrentSelection));
			}
			onFrameOpen.Invoke();
		}
		else
		{
			if (LocalGamestate.Instance != null)
			{
				LocalGamestate.Instance.SetPlayerFreezeState(frozen: false);
			}
			Time.timeScale = PlayerMovement.gameplayTimeScale;
			frameStack.Clear();
		}
		if (activeFrame != null)
		{
			if (activeFrame == choiceFrame && ChoiceManager.instance.ChoiceCoroutineWaiting)
			{
				ChoiceManager.instance.CancelChoice();
			}
			activeFrame.Deactivate(keepOldFrameGameObjectActive);
		}
		if (nextFrame != null)
		{
			nextFrame.Activate(firstSelected);
		}
		activeFrame = nextFrame;
	}

	public void CloseActiveFrame()
	{
		if (!(activeFrame != null))
		{
			return;
		}
		if (frameStack.Count > 0)
		{
			FrameStackElement frameStackElement = frameStack.Pop();
			if (frameStackElement.frame.storeLastSelectedElementInFrameStack)
			{
				ProcessFrameChange(frameStackElement.frame, writeOldFrameToStack: false, keepOldFrameGameObjectActive: false, frameStackElement.selectedElement);
			}
			else
			{
				ProcessFrameChange(frameStackElement.frame, writeOldFrameToStack: false);
			}
		}
		else
		{
			ChangeActiveFrame(null);
		}
	}

	public void CloseAllFrames()
	{
		if (activeFrame != null)
		{
			frameStack.Clear();
			ChangeActiveFrame(null);
		}
	}

	public void ResetToTileScreen()
	{
		ProcessFrameChange(titleFrame, writeOldFrameToStack: false);
		frameStack.Clear();
	}

	public void QuitToDesktop()
	{
		Application.Quit();
	}

	public static bool TryOpenLevelSelect()
	{
		if (instance.activeFrame != null)
		{
			return false;
		}
		instance.ChangeActiveFrame(instance.levelSelectFrame);
		return true;
	}

	public static void ForceOpenLevelSelect()
	{
		if (!(instance.activeFrame == instance.levelSelectFrame))
		{
			instance.ChangeActiveFrame(instance.levelSelectFrame);
		}
	}

	public static bool TryOpenBonusLevelSelect()
	{
		if (instance.activeFrame != null)
		{
			return false;
		}
		instance.ChangeActiveFrame(instance.bonusLevelSelectFrame);
		return true;
	}

	public static bool TryOpenEternalTrialsSelect()
	{
		if (instance.activeFrame != null)
		{
			return false;
		}
		instance.ChangeActiveFrame(instance.eternalTrialsSelectFrame);
		return true;
	}

	public static bool OpenEternalTrialsLoadoutPick()
	{
		instance.ChangeActiveFrame(instance.eternalTrialsLoadoutPickFrame);
		return true;
	}

	public static bool OpenInMapPerkSelect()
	{
		instance.ChangeActiveFrame(instance.inmatchPerkSelectFrame);
		return true;
	}

	public static void TriggerEndOfMatch()
	{
		instance.ProcessFrameChange(instance.endOfMatchFrame, writeOldFrameToStack: false);
	}

	public static void ShowLevelUpReward()
	{
		instance.ProcessFrameChange(instance.levelUpRewardFrame, writeOldFrameToStack: true, keepOldFrameGameObjectActive: true);
	}

	private void UpdateUIBasedOnCurrentScene()
	{
		switch (sceneTransitionManager.CurrentSceneState)
		{
		case SceneTransitionManager.SceneState.InGame:
			treasureChest.gameObject.SetActive(value: true);
			eternalTrialsStageDisplay.gameObject.SetActive(value: true);
			eternalTrialsStageDisplay.Refresh();
			break;
		case SceneTransitionManager.SceneState.LevelSelect:
			treasureChest.gameObject.SetActive(value: false);
			eternalTrialsStageDisplay.gameObject.SetActive(value: false);
			break;
		case SceneTransitionManager.SceneState.MainMenu:
			treasureChest.gameObject.SetActive(value: false);
			eternalTrialsStageDisplay.gameObject.SetActive(value: false);
			break;
		}
	}

	public void PresentChoiceFrame()
	{
		ProcessFrameChange(choiceFrame, writeOldFrameToStack: false);
	}

	public static void ShowResetControlsFrame()
	{
		instance.ProcessFrameChange(instance.resetControlsFrame, writeOldFrameToStack: true, keepOldFrameGameObjectActive: true);
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MainUIManager : Singleton<MainUIManager>
{
	[HideInInspector]
	public UnityEvent<UIPanelBase> OnInGamePanelOpened = new UnityEvent<UIPanelBase>();

	[HideInInspector]
	public UnityEvent<UIPanelBase> OnInGamePanelClosed = new UnityEvent<UIPanelBase>();

	[HideInInspector]
	public UnityEvent OnPausePanelOpened = new UnityEvent();

	[HideInInspector]
	public UnityEvent OnPausePanelClosed = new UnityEvent();

	public UIPanelBase pauseMenu;

	public TutorialUI tutorialUI;

	public bool isInGamePanelOpened;

	private UIPanelBase lastOpenedUI;

	public List<UIPanelBase> inGameUIPanels = new List<UIPanelBase>();

	[SerializeField]
	private Volume postProcessVolume;

	private DepthOfField depthOfField;

	private bool isPaused;

	private int panelOpenedFrame = -1;

	[HideInInspector]
	public int panelClosedFrame = -1;

	private UserPrefencesManager userPrefencesManager;

	public static bool isInventoryActive;

	private KeyData keyData => userPrefencesManager.keyData;

	private void Start()
	{
		userPrefencesManager = Singleton<UserPrefencesManager>.Instance;
		postProcessVolume.profile.TryGet<DepthOfField>(out depthOfField);
		TrainGameManager.isInputActive = true;
		TrainGameManager.isMouseLocked = false;
		OpenBlur(show: false);
	}

	private void OnEnable()
	{
		OnInGamePanelOpened.AddListener(OpenPanel);
		OnInGamePanelClosed.AddListener(ClosePanel);
		OnPausePanelOpened.AddListener(OpenPausePanel);
		OnPausePanelClosed.AddListener(ClosePausePanel);
	}

	private void OnDisable()
	{
		OnInGamePanelOpened.RemoveListener(OpenPanel);
		OnInGamePanelClosed.RemoveListener(ClosePanel);
		OnPausePanelOpened.RemoveListener(OpenPausePanel);
		OnPausePanelClosed.RemoveListener(ClosePausePanel);
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus && !isPaused && !isInGamePanelOpened && !ChatPanelController.isInputFocused)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	private void Update()
	{
		if (isPaused || ChatPanelController.isInputFocused || (!Input.GetKeyUp(keyData.ExitKey) && (!Input.GetKeyUp(keyData.InventoryKey) || panelOpenedFrame == Time.frameCount)) || !(lastOpenedUI != null))
		{
			return;
		}
		lastOpenedUI.HidePanel();
		foreach (UIPanelBase connectedPanel in lastOpenedUI.connectedPanels)
		{
			if (!(connectedPanel == null))
			{
				Debug.Log(connectedPanel.gameObject.name);
				connectedPanel.HidePanel();
			}
		}
		OnInGamePanelClosed?.Invoke(lastOpenedUI);
		panelClosedFrame = Time.frameCount;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OpenPausePanel()
	{
		foreach (UIPanelBase inGameUIPanel in inGameUIPanels)
		{
			if (!(inGameUIPanel == null))
			{
				inGameUIPanel.HidePanel();
			}
		}
		if (tutorialUI != null)
		{
			tutorialUI.HidePanel();
		}
		isPaused = true;
	}

	private void ClosePausePanel()
	{
		if (lastOpenedUI != null)
		{
			lastOpenedUI.ShowPanel();
		}
		isPaused = false;
		if (tutorialUI != null && tutorialUI.isShown)
		{
			tutorialUI.ShowPanelWithFade();
		}
	}

	private void OpenPanel(UIPanelBase uIPanelBase)
	{
		foreach (UIPanelBase inGameUIPanel in inGameUIPanels)
		{
			if (inGameUIPanel == null || !(inGameUIPanel != uIPanelBase))
			{
				continue;
			}
			inGameUIPanel.HidePanel();
			foreach (UIPanelBase connectedPanel in inGameUIPanel.connectedPanels)
			{
				if (!(connectedPanel == null))
				{
					connectedPanel.HidePanel();
				}
			}
		}
		if (tutorialUI != null)
		{
			tutorialUI.HidePanel();
		}
		lastOpenedUI = uIPanelBase;
		panelOpenedFrame = Time.frameCount;
		isInGamePanelOpened = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		TrainGameManager.isMouseLocked = true;
		TrainGameManager.isInputActive = false;
		OpenBlur(show: true);
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.mainCanvasCG != null)
		{
			InteractionPanel.Instance.mainCanvasCG.alpha = 0f;
		}
	}

	private void ClosePanel(UIPanelBase uIPanelBase)
	{
		if (tutorialUI != null && tutorialUI.isShown)
		{
			tutorialUI.ShowPanelWithFade();
		}
		TrainGameManager.isMouseLocked = false;
		TrainGameManager.isInputActive = true;
		isInventoryActive = false;
		lastOpenedUI = null;
		isInGamePanelOpened = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		OpenBlur(show: false);
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.mainCanvasCG != null)
		{
			InteractionPanel.Instance.mainCanvasCG.alpha = 1f;
		}
	}

	public void OpenBlur(bool show)
	{
		if (!(depthOfField == null))
		{
			if (show)
			{
				float num = (float)Screen.height / 1080f;
				depthOfField.active = true;
				depthOfField.mode.value = DepthOfFieldMode.Bokeh;
				depthOfField.focusDistance.value = 0.1f;
				depthOfField.focalLength.value = 50f * num;
				depthOfField.aperture.value = 5.6f;
				depthOfField.bladeCount.value = 5;
				depthOfField.bladeCurvature.value = 1f;
				depthOfField.bladeRotation.value = 0f;
			}
			else
			{
				depthOfField.active = false;
				depthOfField.mode.value = DepthOfFieldMode.Gaussian;
				depthOfField.gaussianStart.value = 50f;
				depthOfField.gaussianEnd.value = 1000f;
				depthOfField.gaussianMaxRadius.value = 1f;
				depthOfField.highQualitySampling.value = false;
			}
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : HUDMenu
{
	[SerializeField]
	private StandardModeUI standardModeUI;

	[SerializeField]
	private EditModeUI editModeUI;

	[SerializeField]
	private BuyModeUI buyModeUI;

	[SerializeField]
	private Image pauseFrameImage;

	[SerializeField]
	private LayoutGroup timeButtonsLayoutGroup;

	[SerializeField]
	private GameObject pauseButton;

	[Header("Toggle grid button")]
	[SerializeField]
	private Image toggleGridButtonImage;

	[SerializeField]
	private Sprite showGridIcon;

	[SerializeField]
	private Sprite hideGridIcon;

	private InGameModeUI currentModeUI;

	private LTHUD ltHud;

	public LTHUD LtHud
	{
		get
		{
			if (!ltHud)
			{
				ltHud = base.Hud as LTHUD;
			}
			return ltHud;
		}
		set
		{
			ltHud = value;
		}
	}

	protected override void Start()
	{
		base.Start();
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged += OnGameSpeedChanged;
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onShowGridChanged = (Action)Delegate.Combine(lTGameManager.onShowGridChanged, new Action(OnShowGridChanged));
		ShowStandarModeUI();
		if (!(base.Hud.PlayerController as LTPlayerController).AllowPause)
		{
			ContentSizeFitter component = timeButtonsLayoutGroup.GetComponent<ContentSizeFitter>();
			timeButtonsLayoutGroup.enabled = true;
			component.enabled = true;
			pauseButton.SetActive(value: false);
			LayoutRebuilder.ForceRebuildLayoutImmediate(timeButtonsLayoutGroup.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(timeButtonsLayoutGroup.transform.parent as RectTransform);
			component.enabled = false;
			timeButtonsLayoutGroup.enabled = false;
		}
		else
		{
			timeButtonsLayoutGroup.GetComponent<ContentSizeFitter>().enabled = false;
			timeButtonsLayoutGroup.enabled = false;
		}
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetTimeManager().onGameSpeedChanged -= OnGameSpeedChanged;
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onShowGridChanged = (Action)Delegate.Remove(lTGameManager.onShowGridChanged, new Action(OnShowGridChanged));
	}

	private void OnEnable()
	{
		OnGameSpeedChanged(LTFunctionLibrary.GetTimeManager().GetGameSpeed(), Time.timeScale);
		UpdateToggleGridButtonImage();
	}

	private void OnGameSpeedChanged(TimeManager.ETimeSpeed timeSpeed, float speed)
	{
		if (timeSpeed == TimeManager.ETimeSpeed.Pause)
		{
			pauseFrameImage.enabled = true;
		}
		else
		{
			pauseFrameImage.enabled = false;
		}
	}

	private void OnShowGridChanged()
	{
		UpdateToggleGridButtonImage();
	}

	public override bool BackButtonPressed()
	{
		return currentModeUI.BackButtonPressed();
	}

	public void ShowStandarModeUI()
	{
		ShowModeUI(standardModeUI);
	}

	public void ShowEditModeUI()
	{
		ShowModeUI(editModeUI);
	}

	public void ShowBuyModeUI()
	{
		ShowModeUI(buyModeUI);
	}

	private void ShowModeUI(InGameModeUI modeUI)
	{
		if (!(currentModeUI == modeUI))
		{
			if ((bool)currentModeUI)
			{
				currentModeUI.gameObject.SetActive(value: false);
			}
			currentModeUI = modeUI;
			if ((bool)currentModeUI)
			{
				currentModeUI.gameObject.SetActive(value: true);
			}
		}
	}

	public void OnToggleGridButtonPressed()
	{
		LTFunctionLibrary.GetLTGameManager().ToggleShowFullGrid();
	}

	public void OnStoreButtonPressed()
	{
		LtHud.ShowStoreUI();
	}

	public void OnTimeButtonPausePressed()
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Pause);
	}

	public void OnTimeButtonPlayPressed()
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Play);
	}

	public void OnTimeButtonFastPressed()
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Fast);
	}

	public void OnTimeButtonVeryFastPressed()
	{
		LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.VeryFast);
	}

	private void UpdateToggleGridButtonImage()
	{
		if (LTFunctionLibrary.GetLTGameManager().IsGridVisible(LTGameManager.EShowGridMode.Full))
		{
			toggleGridButtonImage.sprite = hideGridIcon;
		}
		else
		{
			toggleGridButtonImage.sprite = showGridIcon;
		}
	}
}

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleMenu : Menu
{
	[Header("Title")]
	[SerializeField]
	private TextMeshProUGUI versionText;

	[SerializeField]
	private TextMeshProUGUI releaseText;

	[SerializeField]
	private RectTransform titleRt;

	[SerializeField]
	private GameObject buttonsRootGo;

	[SerializeField]
	private float titleTweenAngle = 5f;

	[SerializeField]
	private float titleTweenScaleVariation = 0.1f;

	[SerializeField]
	private float titleTweenSpeed = 5f;

	[SerializeField]
	private Button continueButton;

	[SerializeField]
	private TextMeshProUGUI continueText;

	[SerializeField]
	private Color continueDisabledColor;

	[SerializeField]
	private Button startNewButton;

	private bool journeyExists;

	private void Start()
	{
		if (PlayAgainHandler.Instance.playAgain)
		{
			startNewButton.onClick.Invoke();
		}
		versionText.text = "Version " + GameManager.Instance.Version;
		releaseText.text = GameManager.Instance.ReleaseDate;
		StartTweeningTitle();
		journeyExists = SaveManager.Instance.JourneyExists();
		if ((bool)continueButton)
		{
			continueButton.interactable = journeyExists;
		}
		if ((bool)continueText)
		{
			continueText.color = (journeyExists ? Color.white : continueDisabledColor);
		}
		if (journeyExists)
		{
			EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
		}
		else
		{
			EventSystem.current.SetSelectedGameObject(startNewButton.gameObject);
		}
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		if (journeyExists)
		{
			EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
		}
		else
		{
			EventSystem.current.SetSelectedGameObject(startNewButton.gameObject);
		}
	}

	private void StartTweeningTitle()
	{
		titleRt.localEulerAngles = new Vector3(0f, 0f, 0f - titleTweenAngle);
		LeanTween.value(base.gameObject, 0f - titleTweenAngle, titleTweenAngle, titleTweenSpeed).setLoopPingPong().setIgnoreTimeScale(useUnScaledTime: true)
			.setOnUpdate(delegate(float val)
			{
				titleRt.localEulerAngles = new Vector3(0f, 0f, val);
			});
		LeanTween.value(base.gameObject, 0.3f - titleTweenScaleVariation, 0.3f + titleTweenScaleVariation, titleTweenSpeed / 2f).setLoopPingPong().setIgnoreTimeScale(useUnScaledTime: true)
			.setOnUpdate(delegate(float scale)
			{
				titleRt.localScale = new Vector3(scale, scale, 1f);
			});
	}

	public void OnNewJourneyClicked()
	{
		if (!SaveManager.Instance.IsTutorialComplete)
		{
			MenuManager.Instance.OpenMenu(MenuType.SkipTutorialPrompt);
			return;
		}
		if (SaveManager.Instance.JourneyExists())
		{
			MenuManager.Instance.OpenMenu(MenuType.NewJourneyPrompt);
			return;
		}
		MenuManager.Instance.CloseAllMenus();
		GameManager.Instance.NewJourney();
	}

	public void OnSkipTutorialClicked()
	{
		SaveManager.Instance.IsTutorialComplete = true;
		MenuManager.Instance.CloseAllMenus();
		GameManager.Instance.NewJourney();
	}

	public void OnPlayTutorialClicked()
	{
		MenuManager.Instance.CloseAllMenus();
		GameManager.Instance.NewJourney();
	}

	public void OnNewJourneyConfirmClicked()
	{
		MenuManager.Instance.CloseAllMenus();
		GameManager.Instance.NewJourney();
	}

	public void OnNewJourneyCancelClicked()
	{
		startNewButton.GetComponent<TitleButton>().ForceStartHover();
	}

	public void OnContinueJourneyClicked()
	{
		MenuManager.Instance.CloseAllMenus();
		GameManager.Instance.ContinueJourney();
	}

	public void OnTutorialClicked()
	{
		MenuSettings component = MenuManager.Instance.GetMenu(MenuType.Options).gameObject.GetComponent<MenuSettings>();
		component.lastGameSpeed = component.chosenGameSpeed;
		component.SetGameSpeed(2f);
		SaveManager.Instance.settingsSavefile.ChosenGameSpeed = 2;
		GameManager.Instance.IsTutorialClicked = true;
		GameManager.Instance.NewJourney();
	}

	public void DiscordLink()
	{
		Application.OpenURL("https://discord.gg/pWWcxm3Xew");
	}

	public void TwitterLink()
	{
		Application.OpenURL("https://x.com/LlamaWareGames");
	}

	public void SteamLink()
	{
		Application.OpenURL("https://store.steampowered.com/app/3223160/Apocalypse_Express/");
	}
}

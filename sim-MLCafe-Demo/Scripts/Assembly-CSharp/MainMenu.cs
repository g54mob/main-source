using Codecks.Runtime;
using MLCN_Localization;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private GraphicRaycaster graphicRaycaster;

	[SerializeField]
	private GameObject titlescreenContent;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private GameObject modeMenu;

	[SerializeField]
	private UIContentAnimator modeAnimator;

	[SerializeField]
	private GameSelectionMenu gameSelectionMenu;

	[SerializeField]
	private UIContentAnimator gameSelectionAnimator;

	[SerializeField]
	private OptionsMenu optionsMenu;

	[SerializeField]
	private CodecksCardCreatorForm codecksCardCreatorForm;

	[SerializeField]
	private UIContentAnimator codecksAnimator;

	[SerializeField]
	private GameObject creditsMenu;

	[SerializeField]
	private UIContentAnimator creditsAnimator;

	[SerializeField]
	private ButtonField[] notAvailableModes;

	[SerializeField]
	private GameObject[] lockedModeScreens;

	[SerializeField]
	private PopupConfirmationComponent confirmationComponent;

	private void Start()
	{
		graphicRaycaster.enabled = false;
		modeMenu.SetActive(value: false);
		modeAnimator.BeginWithNormalState();
		optionsMenu.HideOptionsMenu();
		optionsMenu.GetComponent<UIContentAnimator>().BeginWithNormalState();
		codecksCardCreatorForm.HideCodecksForm();
		codecksAnimator.BeginWithNormalState();
		creditsMenu.SetActive(value: false);
		creditsAnimator.BeginWithNormalState();
		animator.OnFinishedReverse.AddListener(delegate
		{
			titlescreenContent.SetActive(value: false);
		});
		animator.OnFinishedPlay.AddListener(delegate
		{
			graphicRaycaster.enabled = true;
		});
		InputManager.OnCancelMenuWindow.AddListener(CloseSubMenus);
		TweenerManager.TweenTimeAction("ShowTitleMenu", 0.25f, delegate
		{
			ShowTitleMenu();
		});
		ButtonField[] array = notAvailableModes;
		for (int num = 0; num < array.Length; num++)
		{
			array[num].enabled = false;
		}
		GameObject[] array2 = lockedModeScreens;
		for (int num = 0; num < array2.Length; num++)
		{
			array2[num].SetActive(value: true);
		}
		Invoke("ShowDemoInfo", 0.5f);
	}

	private void ShowDemoInfo()
	{
		string localizedString = LocalizationManager.GetLocalizedString("ui_demo_introduction", LocalizationDataTable.Tables.UI);
		confirmationComponent.ShowPreLocalizedMessageForSeconds(localizedString, delegate
		{
			confirmationComponent.Hide();
		});
	}

	public void ShowTitleMenu()
	{
		graphicRaycaster.enabled = false;
		titlescreenContent.SetActive(value: true);
		animator.OnPlay();
	}

	public void HideTitleMenu()
	{
		animator.OnReverse();
	}

	public void CloseSubMenus()
	{
		modeAnimator.OnReverse();
		optionsMenu.GetComponent<UIContentAnimator>().OnReverse();
		gameSelectionAnimator.OnReverse();
		codecksAnimator.OnReverse();
		creditsAnimator.OnReverse();
		ShowTitleMenu();
	}

	public void NewGame()
	{
		HideTitleMenu();
		modeMenu.SetActive(value: true);
		modeAnimator.OnPlay();
	}

	public void StartGame(int mode)
	{
		modeAnimator.OnReverse();
		GameManager.StartNewGame(mode);
	}

	public void ContinueLastGame()
	{
		HideTitleMenu();
		GameManager.StartLastGame();
	}

	public void GameSelection()
	{
		HideTitleMenu();
		gameSelectionMenu.ShowGameSelection();
		gameSelectionAnimator.GetComponent<UIContentAnimator>().OnPlay();
	}

	public void Options()
	{
		HideTitleMenu();
		optionsMenu.ShowOptionsMenu();
		optionsMenu.GetComponent<UIContentAnimator>().OnPlay();
	}

	public void FeedbackCodecksPanel()
	{
		HideTitleMenu();
		codecksCardCreatorForm.ShowCodecksForm();
		codecksAnimator.GetComponent<UIContentAnimator>().OnPlay();
	}

	public void Credits()
	{
		HideTitleMenu();
		creditsMenu.SetActive(value: true);
		creditsAnimator.GetComponent<UIContentAnimator>().OnPlay();
	}

	public void Exit()
	{
		Application.Quit();
	}
}

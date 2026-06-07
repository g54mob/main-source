using System;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UI;
using UnityEngine;

public class GameMenuUI : MonoBehaviour
{
	[SerializeField]
	private ChooseNextPlantWindowUI chooseNextPlantWindowUI;

	[SerializeField]
	private Transform buildingUI;

	[SerializeField]
	private NewScoreUI newScoreUI;

	[SerializeField]
	private Transform journalButtonUI;

	private bool isJournalWindowActive;

	private bool isChooseNextPlantWindowActive;

	private float scrollSpeed = 0.1f;

	public static GameMenuUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		MainMenuUI.Instance.OnResumeButton += MainMenu_OnResumeButton;
		ChooseNextPlantWindowUI.Instance.OnShow += ChooseNextPlantWindowUI_OnShow;
		ChooseNextPlantWindowUI.Instance.OnNewPlantChosen += ChooseNextPlantWindowUI_OnNewPlantChosen;
		ChooseNextPlantWindowUI.Instance.OnExit += ChooseNextPlantWindowUI_OnExit;
		JournalUI.Instance.OnShow += JournalUI_OnShow;
		JournalUI.Instance.OnHide += JournalUI_OnHide;
	}

	private void JournalUI_OnHide(object sender, EventArgs e)
	{
		isJournalWindowActive = false;
	}

	private void JournalUI_OnShow(object sender, EventArgs e)
	{
		isJournalWindowActive = true;
	}

	private void ChooseNextPlantWindowUI_OnExit(object sender, EventArgs e)
	{
		isChooseNextPlantWindowActive = false;
		if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
		{
			ShowElement(buildingUI.gameObject);
			newScoreUI.Show();
		}
	}

	private void ChooseNextPlantWindowUI_OnNewPlantChosen(object sender, ChooseNextPlantWindowUI.OnNewPlantChosenEventArgs e)
	{
		isChooseNextPlantWindowActive = false;
		if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
		{
			ShowElement(buildingUI.gameObject);
			newScoreUI.Show();
		}
	}

	private void ChooseNextPlantWindowUI_OnShow(object sender, EventArgs e)
	{
		isChooseNextPlantWindowActive = true;
		if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
		{
			HideElement(buildingUI.gameObject);
			newScoreUI.Hide();
		}
	}

	private void MainMenu_OnResumeButton(object sender, MainMenuUI.OnResumeButtonEventArgs e)
	{
		if (e.toggleGameMenu)
		{
			Show();
		}
		else
		{
			Hide();
		}
	}

	private void OnDestroy()
	{
		MainMenuUI.Instance.OnResumeButton -= MainMenu_OnResumeButton;
		ChooseNextPlantWindowUI.Instance.OnShow -= ChooseNextPlantWindowUI_OnShow;
		ChooseNextPlantWindowUI.Instance.OnNewPlantChosen -= ChooseNextPlantWindowUI_OnNewPlantChosen;
		ChooseNextPlantWindowUI.Instance.OnExit -= ChooseNextPlantWindowUI_OnExit;
		JournalUI.Instance.OnShow -= JournalUI_OnShow;
		JournalUI.Instance.OnHide -= JournalUI_OnHide;
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void HideElement(GameObject gameObject)
	{
		gameObject.SetActive(value: false);
	}

	private void ShowElement(GameObject gameObject)
	{
		gameObject.SetActive(value: true);
	}

	public bool IsAnyOverlayWindowActive()
	{
		if (isJournalWindowActive || isChooseNextPlantWindowActive)
		{
			return true;
		}
		return false;
	}
}

using System;
using Infrastructure.Services;
using NewGameplayScripts;
using TMPro;
using Tasks_for_levels;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelWindowUI : MonoBehaviour
{
	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	[SerializeField]
	private NextLevelButtonUI nextLevelButtonUI;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private TextMeshProUGUI plantsText;

	[SerializeField]
	private TextMeshProUGUI tasksText;

	private bool nextLevelStarted;

	public event EventHandler OnGameFinished;

	private void Start()
	{
		nextLevelButtonUI.OnNextLevelButton += NextLevelButtonUI_OnNextLevelButton;
		noButton.onClick.AddListener(Hide);
		yesButton.onClick.AddListener(LoadNextScene);
		Hide();
	}

	private void OnDestroy()
	{
		nextLevelButtonUI.OnNextLevelButton -= NextLevelButtonUI_OnNextLevelButton;
		noButton.onClick.RemoveAllListeners();
		yesButton.onClick.RemoveAllListeners();
	}

	private void NextLevelButtonUI_OnNextLevelButton(object sender, EventArgs e)
	{
		Show();
	}

	public void LoadNextScene()
	{
		if (!nextLevelStarted)
		{
			AllServices.Container.Single<Loader>().LoadNextScene();
			nextLevelStarted = true;
		}
	}

	public void GameFinished()
	{
		this.OnGameFinished?.Invoke(this, EventArgs.Empty);
		Hide();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Show()
	{
		scoreText.text = TotalScoreCalculator.Instance.GetTotalScore().ToString();
		plantsText.text = PlantsOnSceneCollection.Instance.collection.Count.ToString();
		ITask currentTask = AllServices.Container.Single<ITaskService>().GetCurrentTask();
		if (currentTask != null)
		{
			tasksText.text = currentTask.GetFinalTasksCount();
		}
		base.gameObject.SetActive(value: true);
	}
}

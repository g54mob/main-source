using System.Collections;
using Localization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : ActiveComponent
{
	[SceneBind("RestartButton")]
	private Button _button;

	[SceneBind("CatWin")]
	private Image CatWin;

	[SceneBind("EducationalWindow")]
	private Image EducationalWindow;

	[SceneBind("EducationalWindow/EndGameBtn")]
	private Button EndGameBtn;

	[SceneBind("EducationalWindow/Youtube/Button")]
	private UrlButton Youtube;

	[SceneBind("EducationalWindow/Wiki/Button")]
	private UrlButton Wiki;

	[SceneBind("EducationalWindow/Python/Button")]
	private UrlButton Python;

	[SceneBind("EducationalWindow/Google/Button")]
	private UrlButton Google;

	[SceneBind("EducationalWindow/Coursera/Button")]
	private UrlButton Coursera;

	[SceneBind("EducationalWindow/Kaggle/Button")]
	private UrlButton Kaggle;

	[SceneBind("EducationalWindow/Arxiv/Button")]
	private UrlButton Arxiv;

	[SceneBind("EducationalWindow/Money/Button")]
	private UrlButton Money;

	[SceneBind("CatLose")]
	private Image CatLose;

	[SceneBind("LoseText")]
	private Text _loseText;

	[SceneBind("WinText")]
	private Text _winText;

	[SceneBind("Title")]
	private Text title;

	[SceneBind("ShareFeedbackButton")]
	private Button _shareButton;

	[SceneBind("Loading")]
	public RectTransform loading;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		EducationalWindow.gameObject.SetActive(value: false);
		EndGameBtn.onClick.AddListener(WinGameClick);
		Youtube.Init();
		Wiki.Init();
		Google.Init();
		Arxiv.Init();
		Coursera.Init();
		Python.Init();
		Money.Init();
		Kaggle.Init();
		loading.gameObject.SetActive(value: false);
	}

	public void Redraw(int endGame)
	{
		_button.onClick.RemoveAllListeners();
		if (endGame != -1)
		{
			_button.onClick.AddListener(OpenEducationalWindow);
			_winText.gameObject.SetActive(value: true);
			_winText.text = TextResources.GetString(ActiveComponent._staticData.EndGame[endGame].Text);
			title.text = Logic.ColorTransform("GREEN", TextResources.GetString("CONGRATULATIONS"));
			CatLose.gameObject.SetActive(value: false);
			_loseText.enabled = false;
			ActiveComponent.Sound.Play("WTL/win");
		}
		else
		{
			_button.onClick.AddListener(RestartGameClicked);
			ActiveComponent.Sound.Play("WTL/lose");
			CatWin.gameObject.SetActive(value: false);
			_winText.gameObject.SetActive(value: false);
			_loseText.enabled = true;
			title.text = Logic.ColorTransform("RED", TextResources.GetString("OPS"));
		}
	}

	private void OpenEducationalWindow()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		EducationalWindow.gameObject.SetActive(value: true);
	}

	private void WinGameClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.P.wasWin = 1;
		Logic.UpdateGameSaves();
		loading.gameObject.SetActive(value: true);
		StartCoroutine(WaitSomeTime());
	}

	private void RestartGameClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		for (int i = 0; i < ActiveComponent.Model.globalSaves.Preview.Count; i++)
		{
			if (ActiveComponent.Model.globalSaves.Preview[i].saveName == ActiveComponent.Model.curPreview.saveName)
			{
				ActiveComponent.Model.globalSaves.Preview.RemoveAt(i);
				Logic.UpdateGlobalSaves();
				break;
			}
		}
		loading.gameObject.SetActive(value: true);
		StartCoroutine(WaitSomeTime());
	}

	public IEnumerator WaitSomeTime()
	{
		Resources.UnloadUnusedAssets();
		int i = 0;
		while (i < 30)
		{
			yield return new WaitForEndOfFrame();
			int num = i + 1;
			i = num;
		}
		ActiveComponent._controller.construction.OnUnInit();
		Logic.CreateReloadObject();
		SceneManager.LoadSceneAsync("loading");
	}
}

using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class MailboxView : ActiveComponent
{
	[SceneBind("TaskLayer/Layer/Title")]
	private Text _titleText;

	[SceneBind("TaskLayer/Layer/AccLayer")]
	private RectTransform AccLayer;

	[SceneBind("TaskLayer/Layer/SpeedLayer/Speed")]
	private Text SpeedText;

	[SceneBind("TaskLayer/Layer/RewLayer/Reward")]
	private Text Reward;

	[SceneBind("TaskLayer/Layer/TimeLayer/Time")]
	private Text Time;

	[SceneBind("TaskLayer/Layer/AccLayer/Acc")]
	private Text Acc;

	[SceneBind("TaskLayer/Layer/SpeedLayer")]
	private RectTransform SpeedLayer;

	[SceneBind("TaskLayer/Layer/RewLayer")]
	private Text RewardLayer;

	[SceneBind("TaskLayer/Layer/TimeLayer")]
	private RectTransform TimeLayer;

	[SceneBind("Task")]
	private Button Task;

	[SceneBind("TaskLayer")]
	private RectTransform TaskLayer;

	[SceneBind("Arrow")]
	private RectTransform Arrow;

	[SceneBind("TaskLayer/Layer/Body")]
	private Text _bodyText;

	[SceneBind("TaskLayer/Layer/Mails")]
	private Button Mails;

	[SceneBind("TreeBtn")]
	private Button Tree;

	[SceneBind("TaskLayer/Layer/ButtonYes")]
	public Button _buttonYes;

	[SceneBind("TaskLayer/Layer/ButtonYes/Text")]
	public Text ButtonYesText;

	[SceneBind("TaskLayer/Layer/ButtonContinue")]
	private Button _buttonContinue;

	[SceneBind("TaskLayer/Layer/ButtonEdit")]
	private Button _buttonEdit;

	[SceneBind("Attention")]
	private Image Attention;

	[SceneBind("TaskLayer/Layer")]
	private Image Layer;

	[SceneBind("TaskLayer/Layer/RewLayer")]
	private Image RewLayer;

	[SceneBind("SandboxLayer")]
	private Button sandboxLayer;

	private GameObject sandBoxObj;

	public List<SandboxObjController> sandboxList = new List<SandboxObjController>();

	private void HideShowQuest()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Layer.gameObject.SetActive(!Layer.gameObject.activeSelf);
		Vector3 localScale = Arrow.gameObject.transform.localScale;
		localScale.y *= -1f;
		Arrow.gameObject.transform.localScale = localScale;
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		_buttonYes.onClick.AddListener(AcceptClick);
		_buttonContinue.onClick.AddListener(ContinueClick);
		TextResources.SetResourcesAccessHandler(ActiveComponent._staticData.TryGetText, ActiveComponent.Model);
		Mails.onClick.AddListener(OpenMailClick);
		Tree.onClick.AddListener(OpenTreeClick);
		_buttonEdit.onClick.AddListener(AcceptClick);
		sandboxLayer.onClick.AddListener(delegate
		{
			SandBoxClick(ActiveComponent.Model.P.lastOpenSandbox);
		});
		sandboxLayer.gameObject.SetActive(value: false);
		RewardLayer.gameObject.SetActive(value: false);
		Task.onClick.AddListener(HideShowQuest);
	}

	private void Resolve(State state)
	{
		Clear();
	}

	private void OnYesClicked()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(delegate
			{
				OnYesClicked();
			});
		}
		else if (ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.Is<Comics>() && !ActiveComponent._controller.construction.gameObject.activeSelf && !ActiveComponent._controller.buy.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !ActiveComponent._controller._gameOverView.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyWindow.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyStartup.gameObject.activeSelf && !ActiveComponent._controller.nicknameController.gameObject.activeSelf && !ActiveComponent._controller.AttentionDay.gameObject.activeSelf && !ActiveComponent._controller._menuView.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			QuestLine.SetCurrentQuest(ActiveComponent.Model.P.ShowFastMailTask);
			ActiveComponent._controller.OpenConstructionTask(ActiveComponent.Model.P.ShowFastMailTask);
		}
	}

	private void AcceptClick()
	{
		OnYesClicked();
	}

	private void OpenMailClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent._controller.OpenInbox(showFastMailTask: true);
	}

	private void OpenTreeClick()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenTreeClick);
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			ActiveComponent.Model.P.treeBtnTutorial = true;
			ActiveComponent._controller.OpenTree(QuestLine.GetCurrentQuest());
		}
	}

	private void ContinueClick()
	{
		OnYesClicked();
	}

	private void SandBoxClick(int id)
	{
		ActiveComponent.Model.SandboxOpen = "SANDBOX" + id;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent._controller.OpenSandBox();
	}

	public void Redraw()
	{
		sandboxLayer.gameObject.SetActive(value: false);
		Attention.gameObject.SetActive(value: false);
		Reward.gameObject.SetActive(value: false);
		_titleText.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		_buttonYes.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		_buttonContinue.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		Attention.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		_bodyText.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		Acc.gameObject.SetActive(value: false);
		Time.gameObject.SetActive(value: false);
		Reward.gameObject.SetActive(value: false);
		SpeedLayer.gameObject.SetActive(value: false);
		AccLayer.gameObject.SetActive(value: false);
		TimeLayer.gameObject.SetActive(value: false);
		Mails.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		_buttonEdit.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		Task.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		TaskLayer.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		Arrow.gameObject.SetActive(ActiveComponent.Model.P.ShowFastMailTask != null && !ActiveComponent.Model.P.ShowFastMailTask.IsCompleted());
		if (ActiveComponent.Model.P.ShowFastMailTask != null)
		{
			bool active = ActiveComponent.Model.IsQuestDone(ActiveComponent.Model.P.ShowFastMailTask.GetName());
			bool active2 = QuestLine.GetQuest(ActiveComponent.Model.P.ShowFastMailTask.GetName()).IsTaskOpened();
			RewLayer.gameObject.SetActive(value: false);
			_titleText.text = TextResources.GetString(ActiveComponent.Model.P.ShowFastMailTask.GetTexts() + "T");
			_buttonYes.gameObject.SetActive(value: true);
			ButtonYesText.text = TextResources.GetString("ACCEPT JOB");
			if (ActiveComponent.Model.P.ShowFastMailTask.GetBaseQuest().KeyName == "ONLY R PARALLEL2")
			{
				ButtonYesText.text = TextResources.GetString("PING_PONG");
			}
			_buttonContinue.gameObject.SetActive(active2);
			_buttonEdit.gameObject.SetActive(active);
			Attention.gameObject.SetActive(value: false);
			string text = "";
			text = TextResources.GetString(ActiveComponent.Model.P.ShowFastMailTask.GetTexts());
			int num = 130;
			if (text.Length > num)
			{
				text = text.Substring(0, num) + "...";
			}
			_bodyText.text = text;
			Reward.gameObject.SetActive(value: false);
			if (!ActiveComponent.Model.P.ShowFastMailTask.Is<ConstructionQuest>())
			{
				ActiveComponent.Model.P.ShowFastMailTask.Is<CarQuest>();
			}
		}
	}

	private void HideAll()
	{
	}

	private void ShowAll()
	{
	}

	public void Clear()
	{
	}
}

using System.Collections;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class InboxController : ActiveComponent
{
	[SceneBind("InboxMails")]
	public InboxTasks InboxMails;

	[SceneBind("InboxStartups")]
	public InboxStartups InboxStartups;

	[SceneBind("InboxPrivates")]
	private InboxPrivate InboxMoney;

	[SceneBind("InboxStartups/ToMails")]
	private Button FromStartupsToMails;

	[SceneBind("InboxStartups/ToMoney")]
	private Button FromStartupsToMoney;

	[SceneBind("InboxMails/ToStartups")]
	private Button FromMailsToStartups;

	[SceneBind("InboxMails/ToMoney")]
	private Button FromMailsToMoney;

	[SceneBind("InboxPrivates/ToStartups")]
	private Button FromMoneyToStartups;

	[SceneBind("InboxPrivates/ToMails")]
	private Button FromPrivatesToMails;

	[SceneBind("Back")]
	public Button InboxBack;

	[SceneBind("BackLayer")]
	private Button BackLayer;

	public State mailsState;

	public State startupsState;

	private bool back;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		dragDistance = (float)Screen.height * 5f / 100f;
		BackLayer.onClick.AddListener(BackLayerClick);
		InboxMails.Init();
		InboxStartups.Init();
		InboxMoney.Init();
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		FromStartupsToMails.onClick.AddListener(ToMails);
		FromMailsToStartups.onClick.AddListener(ToStartups);
		FromStartupsToMoney.onClick.AddListener(ToPrivates);
		FromMailsToMoney.onClick.AddListener(ToPrivates);
		FromMoneyToStartups.onClick.AddListener(ToStartups);
		FromPrivatesToMails.onClick.AddListener(ToMails);
		InboxBack.onClick.AddListener(HideInboxClick);
	}

	public void Redraw()
	{
		Clear();
		InboxMails.Redraw();
		InboxStartups.Redraw();
		InboxMoney.Redraw();
	}

	private void BackLayerClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		back = true;
	}

	public void Clear()
	{
		back = false;
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
	}

	private void HideInboxClick()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		back = true;
	}

	public IEnumerator WaitForUserAction()
	{
		while (InboxMails.state == State.Undefined && InboxStartups.state == State.Undefined && !back)
		{
			yield return new WaitForEndOfFrame();
		}
		ActiveComponent._controller.CloseInbox();
		base.gameObject.SetActive(value: false);
	}

	public void ShowBackBtn()
	{
		InboxBack.gameObject.SetActive(value: true);
	}

	public void HideBackBtn()
	{
		InboxBack.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			flag = true;
		}
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks > 0)
			{
				return;
			}
			flag = true;
		}
		if (flag)
		{
			if (InboxMails.FullWindow.gameObject.activeSelf)
			{
				InboxMails.BackClick();
				return;
			}
			if (InboxStartups.FullWindow.gameObject.activeSelf)
			{
				if (!InboxStartups.AttentionJoin.gameObject.activeSelf)
				{
					InboxStartups.BackClick();
				}
				return;
			}
			if (InboxMoney.FullWindow.gameObject.activeSelf)
			{
				InboxMoney.BackClick();
				return;
			}
			if (InboxStartups.AttentionJoin.gameObject.activeSelf && InboxStartups.FullWindow.gameObject.activeSelf)
			{
				return;
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			back = true;
		}
		CheckJoyConInput();
	}

	public void ToMails()
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		InboxBack.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
		InboxMoney.gameObject.SetActive(value: false);
		InboxMails.gameObject.SetActive(value: true);
		InboxStartups.gameObject.SetActive(value: false);
		InboxMails.HideCompleted.isOn = ActiveComponent.Model.P.hideCompletedMailsTasks == 1;
		InboxMails.Redraw();
		InboxStartups.HideCompleted.gameObject.SetActive(value: false);
		InboxMails.HideCompleted.gameObject.SetActive(value: true);
		InboxMoney.HideCompleted.gameObject.SetActive(value: false);
	}

	public void ShowFastMailTask()
	{
		SetDefState();
		InboxMoney.gameObject.SetActive(value: false);
		InboxMails.gameObject.SetActive(value: true);
		InboxStartups.gameObject.SetActive(value: false);
		InboxMails.Redraw();
		InboxMails.OpenInbox(ActiveComponent.Model.P.ShowFastMailTask, playSound: false);
	}

	private void SetDefState()
	{
		InboxBack.gameObject.SetActive(value: false);
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
	}

	public void OpenStartup(Startup st)
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		SetDefState();
		InboxMoney.gameObject.SetActive(value: false);
		InboxMails.gameObject.SetActive(value: false);
		InboxStartups.gameObject.SetActive(value: true);
		InboxStartups.Redraw();
		int st2 = 0;
		int hashCode = st.KeyName.GetHashCode();
		for (int i = 0; i < ActiveComponent.Model.P.startupQueue.Count; i++)
		{
			if (ActiveComponent.Model.P.startupQueue[i].KeyName.GetHashCode() == hashCode)
			{
				st2 = i;
			}
		}
		InboxStartups.OpenInbox(st2);
	}

	public void OpenTask(QuestLine.Quest cq)
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		SetDefState();
		InboxMoney.gameObject.SetActive(value: false);
		InboxMails.gameObject.SetActive(value: true);
		InboxStartups.gameObject.SetActive(value: false);
		InboxMails.Redraw();
		InboxMails.OpenInbox(cq, playSound: false);
	}

	public void ToStartups()
	{
		InboxBack.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
		InboxMails.gameObject.SetActive(value: false);
		InboxStartups.gameObject.SetActive(value: true);
		InboxMoney.gameObject.SetActive(value: false);
		InboxStartups.Redraw();
		InboxStartups.HideCompleted.isOn = ActiveComponent.Model.P.hideOldStartups == 1;
		InboxStartups.HideCompleted.gameObject.SetActive(value: true);
		InboxMails.HideCompleted.gameObject.SetActive(value: false);
		InboxMoney.HideCompleted.gameObject.SetActive(value: false);
	}

	public void ToPrivates()
	{
		InboxBack.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		InboxMails.state = State.Undefined;
		mailsState = State.Undefined;
		startupsState = State.Undefined;
		InboxStartups.state = State.Undefined;
		InboxMails.gameObject.SetActive(value: false);
		InboxStartups.gameObject.SetActive(value: false);
		InboxMoney.gameObject.SetActive(value: true);
		InboxMoney.Redraw();
		InboxMoney.HideCompleted.isOn = ActiveComponent.Model.P.hideOldPrivates == 1;
		InboxStartups.HideCompleted.gameObject.SetActive(value: false);
		InboxMails.HideCompleted.gameObject.SetActive(value: false);
		InboxMoney.HideCompleted.gameObject.SetActive(value: true);
	}

	protected override void LeftSwipe()
	{
		if (!InboxMoney.FullWindow.gameObject.activeInHierarchy && !InboxStartups.FullWindow.gameObject.activeInHierarchy && !InboxMails.FullWindow.gameObject.activeInHierarchy)
		{
			if (InboxStartups.gameObject.activeInHierarchy)
			{
				ToPrivates();
			}
			else if (InboxMails.gameObject.activeInHierarchy)
			{
				ToStartups();
			}
			else if (InboxMoney.gameObject.activeInHierarchy)
			{
				ToMails();
			}
		}
	}

	protected override void RightSwipe()
	{
		if (!InboxMoney.FullWindow.gameObject.activeSelf && !InboxStartups.FullWindow.gameObject.activeSelf && !InboxMails.FullWindow.gameObject.activeSelf)
		{
			if (InboxMoney.gameObject.activeInHierarchy)
			{
				ToStartups();
			}
			else if (InboxStartups.gameObject.activeInHierarchy)
			{
				ToMails();
			}
			else if (InboxMails.gameObject.activeInHierarchy)
			{
				ToPrivates();
			}
		}
	}
}

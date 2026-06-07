using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using DeepTraffic;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class InboxTasks : ActiveComponent
{
	[SceneBind("Scroll View/Viewport/Content")]
	private RectTransform Content;

	[SceneBind("FullWindow")]
	public Image FullWindow;

	[SceneBind("FullWindow/ZIPLayer")]
	public Image ZIPLayer;

	[SceneBind("FullWindow/ZIPLayer/ZIPTable")]
	public Image ZIPTable;

	[SceneBind("FullWindow/ZIPLayer/ZIP")]
	public Button ZIPBtn;

	private List<List<Image>> ImgTable = new List<List<Image>>();

	[SceneBind("FullWindow/From")]
	private Text From;

	[SceneBind("FullWindow/To")]
	private Text To;

	[SceneBind("FullWindow/Body")]
	private Text Body;

	[SceneBind("FullWindow/BodyMobile")]
	private Text BodyMobile;

	[SceneBind("FullWindow/Title")]
	private Text Title;

	[SceneBind("FullWindow/AccLayer/AccText")]
	private Text AccText;

	[SceneBind("FullWindow/AccLayer")]
	private RectTransform AccLayer;

	[SceneBind("FullWindow/SpeedLayer/SpeedText")]
	private Text SpeedText;

	[SceneBind("FullWindow/SpeedLayer")]
	private RectTransform SpeedLayer;

	[SceneBind("FullWindow/TimeLayer/TimeText")]
	private Text TimeText;

	[SceneBind("FullWindow/TimeLayer")]
	private RectTransform TimeLayer;

	[SceneBind("FullWindow/Date")]
	private Text Date;

	[SceneBind("FullWindow/RewardLayer/RewardText")]
	private Text Reward;

	[SceneBind("FullWindow/ButtonYes")]
	private Button ButtonYes;

	[SceneBind("FullWindow/ButtonYes/Text")]
	private Text ButtonYesText;

	[SceneBind("FullWindow/ButtonContinue")]
	private Button ButtonContinue;

	[SceneBind("FullWindow/GoToTree")]
	private Button GoToTree;

	[SceneBind("FullWindow/ButtonEdit")]
	private Button ButtonEdit;

	[SceneBind("FullWindow/Back")]
	private Button Back;

	[SceneBind("FullWindow/TaskNum")]
	private Text TaskNum;

	[SceneBind("FullWindow/WarningHard")]
	private Image WarningHard;

	[SceneBind("UnreadMails")]
	private UnreadController UnreadMails;

	[SceneBind("UnreadStartups")]
	private UnreadController UnreadStartups;

	[SceneBind("UnreadMoneyLetters")]
	private UnreadController UnreadMoneyLetters;

	[SceneBind("HideCompleted")]
	public Toggle HideCompleted;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Canvas/Scroll View")]
	public RectTransform ScrollRectRect;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	[SceneBind("View")]
	public RectTransform View;

	private Rect viewRect = Rect.zero;

	private GameObject taskObj;

	public State state;

	private List<GameObject> tasks = new List<GameObject>();

	private int skipFrames;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private void Update()
	{
		if (base.IsInited)
		{
			skipFrames++;
			if (skipFrames == 5)
			{
				ScrollRect.enabled = Vertical.gameObject.activeSelf;
				sizeFilter.enabled = false;
				layoutGroup.enabled = false;
			}
		}
	}

	private void UpdateVisibilityOnScreen()
	{
		if (skipFrames < 5)
		{
			return;
		}
		foreach (GameObject task in tasks)
		{
			bool flag = viewRect.Contains(task.transform.position);
			if (flag != task.gameObject.activeSelf)
			{
				task.gameObject.SetActive(flag);
			}
		}
	}

	public void OpenInbox(QuestLine.Quest cq, bool playSound)
	{
		ZIPLayer.gameObject.SetActive(cq.Is<ConstructionQuest>());
		ZIPLayer.gameObject.SetActive(value: false);
		if (playSound)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		base.transform.parent.GetComponent<InboxController>().HideBackBtn();
		FullWindow.gameObject.SetActive(value: true);
		ScrollRect.gameObject.SetActive(value: false);
		ActiveComponent.Model.OpenTaskInbox = cq;
		ButtonYes.gameObject.SetActive(value: true);
		ButtonYesText.text = TextResources.GetString("ACCEPT JOB");
		if (cq.GetBaseQuest().KeyName == "ONLY R PARALLEL2")
		{
			ButtonYesText.text = TextResources.GetString("PING_PONG");
		}
		ButtonContinue.gameObject.SetActive(value: false);
		ButtonEdit.gameObject.SetActive(value: false);
		ActiveComponent.Program.cursor.SetPosition(ButtonYes.transform.position);
		if (QuestLine.GetQuest(cq.GetName()).IsTaskOpened())
		{
			ButtonYes.gameObject.SetActive(value: false);
			ButtonContinue.gameObject.SetActive(value: true);
			ButtonEdit.gameObject.SetActive(value: false);
		}
		if (QuestLine.IsCompleted(cq.GetName()))
		{
			ButtonYes.gameObject.SetActive(value: false);
			ButtonContinue.gameObject.SetActive(value: false);
			ButtonEdit.gameObject.SetActive(value: true);
		}
		From.text = TextResources.GetString(cq.GetTexts() + "FROM");
		To.text = ActiveComponent.Model.P.playerUnit.name;
		Title.text = TextResources.GetString(cq.GetTexts() + "T");
		if (cq.GetBaseQuest().Is<ConstructionQuest>())
		{
			SpeedLayer.gameObject.SetActive(value: false);
			AccLayer.gameObject.SetActive(value: true);
			TimeLayer.gameObject.SetActive(value: true);
			AccText.text = Logic.ColorTransform("ACCURACY", Logic.GetMinAccInCosntrQuest(cq.GetBaseQuest().As<ConstructionQuest>()) + "%");
			TimeText.text = Logic.MinMaxEqualValueStringForCondition(((QuestCondition)cq.GetCondition(0)).Time, ((QuestCondition)cq.GetCondition(2)).Time, " " + TextResources.GetString("SEC"), "TIME");
			Reward.text = Logic.MinMaxEqualValueStringForCondition(cq.GetRewardFromMedal(0), cq.GetRewardFromMedal(0), "$", "MONEY");
			List<List<bool>> list = Logic.HasElemInDatasInQuest(cq.GetTableQuest());
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (list[i][j])
					{
						ImgTable[i][j].gameObject.SetActive(value: true);
						SpriteHolder zIPSpriteByKeyName = Logic.GetZIPSpriteByKeyName(cq.GetName() + "_" + j + i);
						if (zIPSpriteByKeyName != null)
						{
							ImgTable[i][j].sprite = Logic.GetSpriteByKeyName(zIPSpriteByKeyName.spriteName);
						}
						else
						{
							ImgTable[i][j].sprite = Logic.GetSpriteByKeyName(Logic.GetZIPSpriteByKeyName("DEFAULT_ZIP").spriteName);
						}
						if (cq.GetTableQuest().OnlyShape != 0)
						{
							ImgTable[i][j].color = Logic.GetColor("WHITE");
						}
					}
					else
					{
						ImgTable[i][j].gameObject.SetActive(value: false);
					}
				}
			}
		}
		else if (cq.GetBaseQuest().Is<CarQuest>())
		{
			ZIPLayer.gameObject.SetActive(value: false);
			SpeedLayer.gameObject.SetActive(value: true);
			AccLayer.gameObject.SetActive(value: false);
			TimeLayer.gameObject.SetActive(value: false);
			Reward.text = Logic.MinMaxEqualValueStringForCondition(cq.GetRewardFromMedal(0), cq.GetRewardFromMedal(0), "$", "MONEY");
		}
		Body.text = TextResources.GetString(cq.GetTexts());
		BodyMobile.text = TextResources.GetString(cq.GetTexts());
		WarningHard.gameObject.SetActive(value: false);
		Date.text = "";
		HideCompleted.gameObject.SetActive(value: false);
		ZIPLayer.gameObject.SetActive(value: false);
		AccLayer.gameObject.SetActive(value: false);
		TimeLayer.gameObject.SetActive(value: false);
		SpeedLayer.gameObject.SetActive(value: false);
	}

	private void ChangeHide(bool click)
	{
		ActiveComponent.Model.P.hideCompletedMailsTasks = 0;
		if (click)
		{
			ActiveComponent.Model.P.hideCompletedMailsTasks = 1;
		}
		Redraw();
	}

	public IEnumerator WaitForUserAction()
	{
		while (state == State.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	public void UpdateUnread()
	{
		UnreadMails.Num = Logic.GetCouUnreadTasks();
		UnreadMoneyLetters.Num = Logic.GetCouUnreadMoneyLetters();
		UnreadStartups.Num = Logic.GetCouUnreadStartups();
	}

	public void Redraw()
	{
		viewRect = Helper.GetWorldRect(View);
		ScrollRect.gameObject.SetActive(value: true);
		ScrollRect.enabled = true;
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		skipFrames = 0;
		HideCompleted.gameObject.SetActive(value: true);
		foreach (GameObject task in tasks)
		{
			Object.Destroy(task);
		}
		tasks.Clear();
		for (int num = ActiveComponent.Model.P.taskQueue.Count - 1; num >= 0; num--)
		{
			if (ActiveComponent.Model.P.hideCompletedMailsTasks != 1 || !QuestLine.GetQuest(ActiveComponent.Model.P.taskQueue[num]).IsCompleted())
			{
				GameObject gameObject = Object.Instantiate(taskObj, Content.transform.position, Content.transform.rotation).gameObject;
				gameObject.transform.SetParent(Content.transform);
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				QuestLine.Quest cq = QuestLine.GetQuest(ActiveComponent.Model.P.taskQueue[num]);
				TaskController component = gameObject.GetComponent<TaskController>();
				component.Init(cq, num);
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenInbox(cq, playSound: true);
				});
				component.Edit.onClick.AddListener(delegate
				{
					OpenInboxImmidiatly(cq);
				});
				component.Continue.onClick.AddListener(delegate
				{
					OpenInboxImmidiatly(cq);
				});
				component.Read.onClick.AddListener(delegate
				{
					OpenInbox(cq, playSound: true);
				});
				tasks.Add(gameObject);
			}
		}
		state = State.Undefined;
		FullWindow.gameObject.SetActive(value: false);
		ScrollRect.gameObject.SetActive(value: true);
		UpdateUnread();
	}

	private void OpenZIP()
	{
	}

	private void OpenTask()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenTask);
			return;
		}
		if (!QuestLine.GetQuest(ActiveComponent.Model.OpenTaskInbox.GetName()).IsTaskOpened())
		{
			Logic.SendAnalytics("INBOX_TASK_ACCEPT", new Dictionary<string, object> { 
			{
				"keyName",
				ActiveComponent.Model.OpenTaskInbox.GetName()
			} }, addDynamicGroup: true);
		}
		ActiveComponent.Model.P.ShowFastMailTask = ActiveComponent.Model.OpenTaskInbox;
		state = State.Accepted;
	}

	private void OpenInboxImmidiatly(QuestLine.Quest cq)
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(delegate
			{
				OpenInboxImmidiatly(cq);
			});
		}
		else
		{
			base.transform.parent.GetComponent<InboxController>().HideBackBtn();
			ActiveComponent.Model.OpenTaskInbox = cq;
			ActiveComponent.Model.P.ShowFastMailTask = ActiveComponent.Model.OpenTaskInbox;
			state = State.Accepted;
		}
	}

	public void BackClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		FullWindow.gameObject.SetActive(value: false);
		ScrollRect.gameObject.SetActive(value: true);
		HideCompleted.gameObject.SetActive(value: true);
		base.transform.parent.GetComponent<InboxController>().ShowBackBtn();
		Redraw();
	}

	private void OpenTaskOnTree()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenTaskOnTree);
		}
		else
		{
			BackClick();
			ActiveComponent._controller.CloseInbox();
			ActiveComponent._controller.OpenTree(ActiveComponent.Model.OpenTaskInbox, matchToNextQuest: false);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		viewRect = Helper.GetWorldRect(View);
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
		GoToTree.onClick.AddListener(OpenTaskOnTree);
		taskObj = Resources.Load("Prefabs/TaskObj") as GameObject;
		ButtonContinue.onClick.AddListener(OpenTask);
		ButtonYes.onClick.AddListener(OpenTask);
		ButtonEdit.onClick.AddListener(OpenTask);
		Back.onClick.AddListener(BackClick);
		UnreadMails.Init();
		UnreadMoneyLetters.Init();
		UnreadStartups.Init();
		ZIPBtn.onClick.AddListener(OpenZIP);
		HideCompleted.onValueChanged.AddListener(ChangeHide);
		ImgTable = new List<List<Image>>();
		BodyMobile.gameObject.SetActive(value: false);
		for (int num = 0; num < 3; num++)
		{
			ImgTable.Add(new List<Image>());
			for (int num2 = 0; num2 < 3; num2++)
			{
				ImgTable[num].Add(ZIPTable.transform.Find(num.ToString() + num2).GetComponent<Image>());
			}
		}
	}
}

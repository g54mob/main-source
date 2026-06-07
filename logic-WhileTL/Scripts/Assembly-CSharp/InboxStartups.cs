using System.Collections;
using System.Collections.Generic;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class InboxStartups : ActiveComponent
{
	[SceneBind("Scroll View/Viewport/Content")]
	private RectTransform Content;

	[SceneBind("FullWindow")]
	public Image FullWindow;

	[SceneBind("FullWindow/GetCreditBtn")]
	public Button GetCreditBtn;

	[SceneBind("FullWindow/From")]
	private Text From;

	[SceneBind("FullWindow/To")]
	private Text To;

	[SceneBind("FullWindow/Invest/Min")]
	private Text Min;

	[SceneBind("FullWindow/Invest/Max")]
	private Text Max;

	[SceneBind("FullWindow/Invest/Cur")]
	private Text Cur;

	[SceneBind("FullWindow/Body")]
	private Text Body;

	[SceneBind("FullWindow/BodyMobile")]
	private Text BodyMobile;

	[SceneBind("FullWindow/MoneyInStartup")]
	private Text Reward;

	[SceneBind("FullWindow/InvestLayer")]
	private RectTransform InvestLayer;

	[SceneBind("FullWindow/ButtonYes")]
	private Button ButtonYes;

	[SceneBind("FullWindow/ButtonNo")]
	private Button ButtonNo;

	[SceneBind("FullWindow/ButtonRework")]
	private Button ButtonRework;

	[SceneBind("FullWindow/ButtonPatch")]
	private Button ButtonPatch;

	[SceneBind("FullWindow/Back")]
	private Button Back;

	[SceneBind("FullWindow/MaxStartups")]
	private Text MaxStartups;

	[SceneBind("FullWindow/Title")]
	private Text Title;

	[SceneBind("FullWindow/Date")]
	private Text Date;

	[SceneBind("UnreadMails")]
	private UnreadController UnreadMails;

	[SceneBind("UnreadStartups")]
	private UnreadController UnreadStartups;

	[SceneBind("UnreadMoneyLetters")]
	private UnreadController UnreadMoneyLetters;

	[SceneBind("AttentionDelete/Hide")]
	public Toggle HideAcceptDelete;

	[SceneBind("AttentionDelete/Accept")]
	private Button AcceptStartupDelete;

	[SceneBind("AttentionDelete/Cancel")]
	private Button CancelStartupdelete;

	[SceneBind("AttentionDelete")]
	private Image Attention;

	[SceneBind("FullWindow/TaskNum")]
	private Text TaskNum;

	[SceneBind("FullWindow/Invest/ShareCost")]
	private Text ShareCost;

	[SceneBind("FullWindow/Total")]
	private Text Total;

	[SceneBind("FullWindow/NotEnough")]
	private Text NotEnough;

	[SceneBind("FullWindow/Invest/MoneySlider")]
	private Slider MoneySlider;

	[SceneBind("FullWindow/Invest")]
	private RectTransform Invest;

	[SceneBind("AttentionJoin")]
	public AttentionController AttentionJoin;

	[SceneBind("FullWindow/StartupClosed")]
	public RectTransform StartupClosed;

	[SceneBind("HideCompleted")]
	public Toggle HideCompleted;

	[SceneBind("FullWindow/GoToTree")]
	private Button GoToTree;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public RectTransform Vertical;

	[SceneBind("View")]
	public RectTransform View;

	private Rect viewRect = Rect.zero;

	private GameObject startupObj;

	public State state;

	private List<GameObject> startups = new List<GameObject>();

	private int skipFrames;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private int curStartup;

	private int curIdDelete;

	private void BackLayerClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.SetActive(value: false);
	}

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
		foreach (GameObject startup in startups)
		{
			bool flag = viewRect.Contains(startup.transform.position);
			if (flag != startup.gameObject.activeSelf)
			{
				startup.gameObject.SetActive(flag);
			}
		}
	}

	public void OpenInbox(int st)
	{
		GetCreditBtn.gameObject.SetActive(value: false);
		HideCompleted.gameObject.SetActive(value: false);
		StartupClosed.gameObject.SetActive(value: false);
		AttentionJoin.Redraw();
		ActiveComponent.Program.cursor.SetPosition(AttentionJoin.Accept.transform.position);
		curStartup = st;
		AttentionJoin.gameObject.SetActive(value: false);
		base.transform.parent.GetComponent<InboxController>().HideBackBtn();
		ShareCost.text = TextResources.GetString("SHARECOST") + " " + Logic.ColorTransform("MONEY", " " + ActiveComponent.Model.P.startupQueue[st].ShareCost + TextResources.GetString("#PERSHARE"));
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		FullWindow.gameObject.SetActive(value: true);
		ScrollRect.gameObject.SetActive(value: false);
		ActiveComponent.Model.OpenStartupInbox = st;
		ButtonYes.gameObject.SetActive(value: false);
		ButtonRework.gameObject.SetActive(value: false);
		ButtonPatch.gameObject.SetActive(value: false);
		MaxStartups.gameObject.SetActive(value: false);
		ButtonNo.gameObject.SetActive(value: false);
		Title.text = TextResources.GetString(ActiveComponent.Model.P.startupQueue[st].Texts + "T");
		From.text = TextResources.GetString(ActiveComponent.Model.P.startupQueue[st].Texts + "FROM");
		To.text = ActiveComponent.Model.P.playerUnit.name;
		Body.text = TextResources.GetString(ActiveComponent.Model.P.startupQueue[st].Texts);
		BodyMobile.text = TextResources.GetString(ActiveComponent.Model.P.startupQueue[st].Texts);
		Date.text = "";
		bool flag = false;
		StartupScheme startupScheme = null;
		MoneySlider.gameObject.SetActive(value: true);
		MoneySlider.maxValue = Mathf.Max(ActiveComponent.Model.P.startupQueue[st].MinShares, Mathf.Min(ActiveComponent.Model.P.Money, ActiveComponent.Model.P.startupQueue[st].ShareCost * ActiveComponent.Model.P.startupQueue[st].SharesCou) / (float)ActiveComponent.Model.P.startupQueue[st].ShareCost);
		MoneySlider.minValue = ActiveComponent.Model.P.startupQueue[st].MinShares;
		MoneySlider.value = MoneySlider.minValue;
		Min.text = ActiveComponent.Model.P.startupQueue[st].MinShares * ActiveComponent.Model.P.startupQueue[curStartup].ShareCost + "$";
		Max.text = Mathf.Max(ActiveComponent.Model.P.startupQueue[st].MinShares, Mathf.Min(ActiveComponent.Model.P.Money, ActiveComponent.Model.P.startupQueue[st].ShareCost * ActiveComponent.Model.P.startupQueue[st].SharesCou) / (float)ActiveComponent.Model.P.startupQueue[st].ShareCost) * (float)ActiveComponent.Model.P.startupQueue[curStartup].ShareCost + "$";
		MoneySlider.gameObject.SetActive(value: false);
		Min.gameObject.SetActive(value: false);
		Max.gameObject.SetActive(value: false);
		Reward.text = Logic.ColorTransform("GREEN", Max.text);
		Reward.gameObject.SetActive(ActiveComponent.Model.P.startupQueue[curStartup].TutorialStartup);
		InvestLayer.gameObject.SetActive(ActiveComponent.Model.P.startupQueue[curStartup].TutorialStartup);
		int hashCode = ActiveComponent.Model.P.startupQueue[st].KeyName.GetHashCode();
		Invest.gameObject.SetActive(value: true);
		foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
		{
			if (startup.baseStartup.KeyName.GetHashCode() == hashCode)
			{
				flag = true;
				startupScheme = startup;
				break;
			}
		}
		if (flag)
		{
			MoneySlider.gameObject.SetActive(value: false);
			Invest.gameObject.SetActive(value: false);
			if (startupScheme.released == 1)
			{
				ButtonPatch.gameObject.SetActive(value: true);
				ButtonNo.gameObject.SetActive(value: false);
			}
			else
			{
				ButtonRework.gameObject.SetActive(value: true);
				ButtonNo.gameObject.SetActive(value: false);
			}
		}
		else if (ActiveComponent.Model.P.startupQueue[st].MinShares * ActiveComponent.Model.P.startupQueue[st].ShareCost > ActiveComponent.Model.P.Money)
		{
			ButtonRework.gameObject.SetActive(value: false);
			ButtonYes.gameObject.SetActive(value: false);
			ButtonPatch.gameObject.SetActive(value: false);
			NotEnough.gameObject.SetActive(value: true);
			MaxStartups.gameObject.SetActive(value: false);
		}
		else
		{
			ButtonYes.gameObject.SetActive(ActiveComponent.Model.P.Startups.Count < ActiveComponent._staticData.Settings.MaxStartups);
			NotEnough.gameObject.SetActive(value: false);
			MaxStartups.gameObject.SetActive(ActiveComponent.Model.P.Startups.Count >= ActiveComponent._staticData.Settings.MaxStartups);
		}
		if (Logic.StartupWasDeleted(ActiveComponent.Model.P.startupQueue[st].KeyName))
		{
			StartupClosed.gameObject.SetActive(value: true);
			Invest.gameObject.SetActive(value: false);
			ButtonYes.gameObject.SetActive(value: false);
			ButtonRework.gameObject.SetActive(value: false);
			ButtonPatch.gameObject.SetActive(value: false);
			MaxStartups.gameObject.SetActive(value: false);
			ButtonNo.gameObject.SetActive(value: false);
			MoneySlider.gameObject.SetActive(value: false);
			NotEnough.gameObject.SetActive(value: false);
			GetCreditBtn.gameObject.SetActive(value: false);
		}
		if (ButtonYes.gameObject.activeSelf || ButtonRework.gameObject.activeSelf || ButtonPatch.gameObject.activeSelf)
		{
			ActiveComponent.Program.cursor.SetPosition(ButtonYes.transform.position);
		}
		else
		{
			ActiveComponent.Program.cursor.SetPosition(Back.transform.position);
		}
		HideCompleted.gameObject.SetActive(value: false);
		Invest.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.P.Money > ActiveComponent.Model.P.startupQueue[st].MinShares * ActiveComponent.Model.P.startupQueue[curStartup].ShareCost)
		{
			GetCreditBtn.gameObject.SetActive(value: false);
		}
		GetCreditBtn.interactable = ActiveComponent.Model.P.creditDepth < ActiveComponent._staticData.Settings.MaxCreditDepth;
	}

	private void ChangeHide(bool click)
	{
		ActiveComponent.Model.P.hideOldStartups = 0;
		if (click)
		{
			ActiveComponent.Model.P.hideOldStartups = 1;
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

	public void Redraw()
	{
		viewRect = Helper.GetWorldRect(View);
		sizeFilter.enabled = true;
		layoutGroup.enabled = true;
		ScrollRect.enabled = true;
		skipFrames = 0;
		AttentionJoin.gameObject.SetActive(value: false);
		foreach (GameObject startup in startups)
		{
			Object.Destroy(startup);
		}
		startups.Clear();
		for (int num = ActiveComponent.Model.P.startupQueue.Count - 1; num >= 0; num--)
		{
			if (ActiveComponent.Model.P.hideOldStartups != 1 || !ActiveComponent.Model.P.removedStartups.Contains(ActiveComponent.Model.P.startupQueue[num].KeyName))
			{
				GameObject gameObject = Object.Instantiate(startupObj, Content.transform.position, Content.transform.rotation).gameObject;
				gameObject.transform.parent = Content.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				int newI = num;
				StartupMailController component = gameObject.GetComponent<StartupMailController>();
				component.Init(ActiveComponent.Model.P.startupQueue[newI], newI);
				gameObject.GetComponent<Button>().onClick.AddListener(delegate
				{
					OpenInbox(newI);
				});
				component.ReworkBtn.onClick.AddListener(delegate
				{
					OpenInboxImmidiatly(newI);
				});
				component.PatchBtn.onClick.AddListener(delegate
				{
					OpenInboxImmidiatly(newI);
				});
				component.Read.onClick.AddListener(delegate
				{
					OpenInbox(newI);
				});
				startups.Add(gameObject);
			}
		}
		state = State.Undefined;
		FullWindow.gameObject.SetActive(value: false);
		ScrollRect.gameObject.SetActive(value: true);
		UnreadMails.Num = Logic.GetCouUnreadTasks();
		UnreadMoneyLetters.Num = Logic.GetCouUnreadMoneyLetters();
		UnreadStartups.Num = Logic.GetCouUnreadStartups();
	}

	private IEnumerator WaitAcceptJoin()
	{
		yield return StartCoroutine(AttentionJoin.WaitForUserAction());
		if (AttentionJoin.wait == BasicState.Accept)
		{
			OpenStartupFirst();
		}
		if (AttentionJoin.DontShowAgain.isOn)
		{
			ActiveComponent.Model.P.hideAttentionJoinStartup = 1;
		}
		AttentionJoin.gameObject.SetActive(value: false);
	}

	private void OpenAttentionJoin()
	{
		AttentionJoin.wait = BasicState.Undefined;
		if (ActiveComponent.Model.P.hideAttentionJoinStartup == 1 || !ActiveComponent.Model.P.startupQueue[curStartup].TutorialStartup)
		{
			OpenStartupFirst();
			return;
		}
		AttentionJoin.Redraw(hideState: false, transitionScreen: true);
		AttentionJoin.BodyText.text = TextResources.GetString("SUREJOINSTARTUP").Replace("%NUM", Logic.ColorTransform("GREEN", ActiveComponent.Model.P.startupQueue[curStartup].MinShares * ActiveComponent.Model.P.startupQueue[curStartup].ShareCost + "$"));
		AttentionJoin.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		ActiveComponent.Program.cursor.SetPosition(AttentionJoin.Accept.transform.position);
		StartCoroutine(WaitAcceptJoin());
	}

	private void DeleteStartupClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		state = State.Denied;
		Attention.gameObject.SetActive(value: false);
	}

	private void DeleteStartupCancel()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Attention.gameObject.SetActive(value: false);
	}

	public void DeleteClick()
	{
		Attention.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		HideAcceptDelete.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.P.hideCancelStartup == 1)
		{
			DeleteStartupClick();
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Attention.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		Logic.UpdateGameSaves();
	}

	private void HideDeleteClick(bool click)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.hideCancelStartup = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideCancelStartup = 0;
		}
		Logic.UpdateGameSaves();
	}

	private void OpenStartup()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenStartup);
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			state = State.Accepted;
		}
	}

	private void OpenStartupFirst()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OpenStartupFirst);
			return;
		}
		Steam.UnlockAchievement("ACHIEVEMENT_2");
		int num = (int)(MoneySlider.value * (float)ActiveComponent.Model.P.startupQueue[curStartup].ShareCost);
		if (!ActiveComponent.Model.P.startupQueue[curStartup].TutorialStartup)
		{
			num = 0;
		}
		ActiveComponent.Model.P.startupQueue[curStartup].BaseMoney += num;
		ActiveComponent.Model.P.Money -= num;
		ActiveComponent.Model.P.startupQueue[curStartup].PlayersShares = ActiveComponent.Model.P.startupQueue[curStartup].MinShares;
		Logic.SendAnalytics("INBOX_STARTUP_ENTER", new Dictionary<string, object>
		{
			{
				"keyName",
				ActiveComponent.Model.P.startupQueue[curStartup].KeyName
			},
			{ "enter money", num }
		}, addDynamicGroup: true);
		if (ActiveComponent.Model.P.startupsStatsString.ContainsKey(ActiveComponent.Model.P.startupQueue[curStartup].KeyName))
		{
			ActiveComponent.Model.P.startupsStatsString[ActiveComponent.Model.P.startupQueue[curStartup].KeyName].enterMoney = num;
		}
		else
		{
			ActiveComponent.Model.P.startupsStatsString.Add(ActiveComponent.Model.P.startupQueue[curStartup].KeyName, new StartupStat(num));
		}
		state = State.Accepted;
	}

	public void BackClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		if (!Attention.gameObject.activeSelf)
		{
			base.transform.parent.GetComponent<InboxController>().ShowBackBtn();
			FullWindow.gameObject.SetActive(value: false);
			ScrollRect.gameObject.SetActive(value: true);
		}
		else
		{
			Attention.gameObject.SetActive(value: false);
		}
		HideCompleted.gameObject.SetActive(value: true);
		Redraw();
	}

	private void OpenInboxImmidiatly(int st)
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(delegate
			{
				OpenInboxImmidiatly(st);
			});
		}
		else
		{
			base.transform.parent.GetComponent<InboxController>().HideBackBtn();
			ActiveComponent.Model.OpenStartupInbox = st;
			state = State.Accepted;
		}
	}

	private void MoneyChange(float val)
	{
		Cur.text = Logic.ColorTransform("GREEN", (int)(val * (float)ActiveComponent.Model.P.startupQueue[curStartup].ShareCost) + "$");
	}

	private void OpenCreditWindowClick()
	{
		Credit randomCredit = Logic.GetRandomCredit();
		if (randomCredit != null)
		{
			ActiveComponent.Model.P.creditDepth++;
			randomCredit = new Credit(randomCredit, ActiveComponent.Model.P.startupQueue[curStartup].MinShares * ActiveComponent.Model.P.startupQueue[curStartup].ShareCost, isTaskQuest: false);
			ActiveComponent.Model.P.credits.Add(randomCredit);
			randomCredit.CurDepth = ActiveComponent.Model.P.creditDepth;
			ActiveComponent._controller.credit.Redraw(randomCredit);
			ActiveComponent._controller.credit.gameObject.SetActive(value: true);
			StartCoroutine(ActiveComponent._controller.credit.WaitForUserAction());
			ActiveComponent.Model.P.Money += randomCredit.Money;
			Logic.UpdateGameSaves();
		}
		GetCreditBtn.gameObject.SetActive(value: false);
		OpenInbox(curStartup);
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
			ActiveComponent._controller.OpenStarupOnTree(curStartup);
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
		GetCreditBtn.onClick.AddListener(OpenCreditWindowClick);
		GoToTree.onClick.AddListener(OpenTaskOnTree);
		startupObj = Resources.Load("Prefabs/StartupObj") as GameObject;
		MoneySlider.onValueChanged.AddListener(MoneyChange);
		ButtonRework.onClick.AddListener(OpenStartup);
		ButtonYes.onClick.AddListener(OpenAttentionJoin);
		ButtonPatch.onClick.AddListener(OpenStartup);
		Back.onClick.AddListener(BackClick);
		UnreadMails.Init();
		UnreadMoneyLetters.Init();
		UnreadStartups.Init();
		AcceptStartupDelete.onClick.AddListener(DeleteStartupClick);
		HideAcceptDelete.onValueChanged.AddListener(HideDeleteClick);
		CancelStartupdelete.onClick.AddListener(DeleteStartupCancel);
		Attention.gameObject.SetActive(value: false);
		ButtonNo.onClick.AddListener(DeleteClick);
		ButtonNo.gameObject.SetActive(value: false);
		AttentionJoin.Init();
		AttentionJoin.gameObject.SetActive(value: false);
		HideCompleted.onValueChanged.AddListener(ChangeHide);
		BodyMobile.gameObject.SetActive(value: false);
	}
}

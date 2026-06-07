using System.Collections;
using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class Controller : ActiveComponent
{
	[SceneBind]
	private Logic _logic;

	[SceneBind("Inbox", true)]
	public InboxController Inbox;

	[SceneBind("Transition")]
	public TransitionControl Transition;

	[SceneBind("Tree", true)]
	public TreeController Tree;

	[SceneBind("ShowMails", true)]
	public Button ShowMails;

	[SceneBind("ShowMails/Unread")]
	public UnreadController Unread;

	[SceneBind("LearnSmthNew/Unread")]
	public UnreadController Unbought;

	[SceneBind("Mailbox", true)]
	public MailboxView _mailboxView;

	[SceneBind("DayTutorial")]
	private TutorialList DayTutorial;

	[SceneBind("StartupDieTutorial")]
	private TutorialList StartupDieTutorial;

	[SceneBind("RedUsersTutorial")]
	private TutorialList RedUsersTutorial;

	[SceneBind("RedUsersTutorial0")]
	private TutorialList RedUsersTutorial0;

	[SceneBind("Resources", true)]
	public ResourcesView _resourcesView;

	[SceneBind("Resources/DayBtn", true)]
	public RectTransform dayBtn;

	[SceneBind("Startups", true)]
	public StartupsControl _startupView;

	[SceneBind("Credit", true)]
	public CreditController credit;

	[SceneBind("NicknameWindow", true)]
	public NicknameController nicknameController;

	[SceneBind("StartupBankrupt", true)]
	public StartupBankrupt startupBankrupt;

	[SceneBind("GameOver", true)]
	public GameOverView _gameOverView;

	[SceneBind("NewGameConfirmation/ButtonYes")]
	private Button YesBtn;

	[SceneBind("NewGameConfirmation/ButtonNo")]
	private Button NoBtn;

	[SceneBind("MenuView")]
	public MenuView _menuView;

	[SceneBind("MenuView")]
	public MenuView MenuView;

	[SceneBind("MenuView/Layer")]
	public Button _menuViewLayer;

	[SceneBind("ButtonNewGame")]
	private Button _buttonNewGame;

	[SceneBind("Shop")]
	private RectTransform buyObj;

	[SceneBind("GameScreen")]
	public Image GameScreen;

	[SceneBind("GameScreen/SizeHelper")]
	public RectTransform SizeHelper;

	[SceneBind("Epoch")]
	private Text Epoch;

	[SceneBind("Cat")]
	public CatController cat;

	[SceneBind("LearnSmthNew")]
	private Button LearnSmthNew;

	[SceneBind("Shop", true)]
	public ShopController buy;

	[SceneBind("ConstructionWindow")]
	public Construction construction;

	[SceneBind("PayDay", true)]
	public PayDay payDay;

	[SceneBind("EarlyPayDay")]
	public EarlyPayDay earlyPayDay;

	[SceneBind("Newspaper")]
	public Newspaper newspaper;

	[SceneBind("SavingLayer")]
	public Saving Saving;

	[SceneBind("GainMoneyWindow")]
	public GainMoneyWindow GainMoneyWindow;

	[SceneBind("GainMoneyStartup")]
	public GainMoneyStartup GainMoneyStartup;

	[SceneBind("AttentionDay")]
	public RectTransform AttentionDay;

	[SceneBind("AttentionDay/Hide")]
	public Toggle HideAttentionDay;

	[SceneBind("AttentionDay/Accept")]
	private Button DayAccept;

	[SceneBind("AttentionDay/Cancel")]
	private Button DayCancel;

	[SceneBind("Player")]
	public InterierController Player;

	[SceneBind("UnZIPWindow")]
	public UnZIP UnZIP;

	[SceneBind("ComputerBuildingWindow")]
	public ComputerBuildingController computerBuildingController;

	[SceneBind("GoogleWindow")]
	private GoogleController googleController;

	[SceneBind("LoadingFromMenu")]
	private RectTransform loading;

	private StartupTutorialGlowHelper[] dayTutorialHelpers;

	private bool repeatMailsFlag;

	public List<AnimationActivator> animatedObjects = new List<AnimationActivator>();

	public List<ChangeUIStateEnv> randomEnvs = new List<ChangeUIStateEnv>();

	public bool objectInitFinished;

	private string replayName = string.Empty;

	private bool lose;

	private bool win;

	private bool isCurConstrTaskWasCompleted;

	private int startupsBeforeOpenCosntruction;

	public GoogleController GoogleController => googleController;

	public void RedrawUnlockTable()
	{
	}

	private void SetLang()
	{
		Redraw();
		TextResources.UpdateTexts();
	}

	private void ShowInboxClick()
	{
		OpenInbox();
	}

	public void LearnSmthNewClick(ShopController.OpenShopState state)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		buy.OpenShop(state);
		buyObj.gameObject.SetActive(value: true);
	}

	public void Redraw()
	{
		cat.Redraw();
		_resourcesView.CreditRedraw();
		Unread.Num = Logic.GetUnreadLettersNum();
		Unbought.Num = Logic.GetUnwatchedShop();
		_mailboxView.Redraw();
		Player.Redraw();
	}

	public void InitGainMoneyWindow(int reward, int profit)
	{
		GainMoneyWindow.gameObject.SetActive(value: true);
		GainMoneyWindow.Redraw(reward, profit);
	}

	private void IncDay(bool openTree = false)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		repeatMailsFlag = false;
		AttentionDay.gameObject.SetActive(value: false);
		EndDay(openTree);
		Logic.SendAnalytics("MAIN_DAY_NEXT", new Dictionary<string, object> { 
		{
			"day",
			Logic.GetDay()
		} }, addDynamicGroup: true);
	}

	public void OpenDayAttention()
	{
		IncDay();
	}

	private void CloseDayAttention()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionDay.gameObject.SetActive(value: false);
	}

	private void HideAttentionDayClick(bool click)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (click)
		{
			ActiveComponent.Model.P.hideAttentionDay = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideAttentionDay = 0;
		}
		Logic.UpdateGameSaves();
	}

	private void RunStartup()
	{
		construction.gameObject.SetActive(value: true);
		bool flag = false;
		StartupScheme curStartupInWork = null;
		int hashCode = ActiveComponent.Model.P.startupQueue[ActiveComponent.Model.OpenStartupInbox].KeyName.GetHashCode();
		foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
		{
			if (startup.baseStartup.KeyName.GetHashCode() == hashCode)
			{
				flag = true;
				curStartupInWork = startup;
				break;
			}
		}
		if (!flag)
		{
			ActiveComponent.Model.curStartup = ActiveComponent.Model.P.startupQueue[ActiveComponent.Model.OpenStartupInbox];
			ActiveComponent.Model.curStartupInWork = null;
		}
		else
		{
			ActiveComponent.Model.curStartup = ActiveComponent.Model.P.startupQueue[ActiveComponent.Model.OpenStartupInbox];
			ActiveComponent.Model.curStartupInWork = curStartupInWork;
		}
		construction.gameObject.SetActive(value: true);
		QuestLine.Quest cq = QuestLine.UpdateOrAddQuest(Logic.GetBaseQuestByKeyName(ActiveComponent.Model.curStartup.TaskKeyName));
		construction.OpenWindowInit(cq);
	}

	protected override void OnInit()
	{
		Logic.ReInitAllControllers();
		Debug.unityLogger.filterLogType = LogType.Error;
		SceneBindContainer.BindObjects(this);
		GameObject[] array = GameObject.FindGameObjectsWithTag("AnimationObject");
		for (int i = 0; i < array.Length; i++)
		{
			AnimationActivator component = array[i].GetComponent<AnimationActivator>();
			if (component != null)
			{
				component.Init();
				component.StartAnim();
				animatedObjects.Add(component);
			}
		}
		ChangeUIStateEnv[] componentsInChildren = Player.transform.GetComponentsInChildren<ChangeUIStateEnv>();
		foreach (ChangeUIStateEnv changeUIStateEnv in componentsInChildren)
		{
			changeUIStateEnv.Init();
			randomEnvs.Add(changeUIStateEnv);
		}
		componentsInChildren = cat.transform.GetComponentsInChildren<ChangeUIStateEnv>();
		foreach (ChangeUIStateEnv changeUIStateEnv2 in componentsInChildren)
		{
			changeUIStateEnv2.Init();
			randomEnvs.Add(changeUIStateEnv2);
		}
		Player.Init();
		Inbox.Init();
		Transition.Init();
		Transition.gameObject.SetActive(value: false);
		credit.Init();
		payDay.Init();
		earlyPayDay.Init();
		_startupView.Init();
		MenuView.Init();
		payDay.gameObject.SetActive(value: false);
		earlyPayDay.gameObject.SetActive(value: false);
		credit.gameObject.SetActive(value: false);
		Saving.Init();
		Saving.gameObject.SetActive(value: false);
		LearnSmthNew.onClick.AddListener(delegate
		{
			LearnSmthNewClick(ShopController.OpenShopState.Interier);
		});
		HideAttentionDay.onValueChanged.AddListener(HideAttentionDayClick);
		Tree.Init();
		Tree.gameObject.SetActive(value: false);
		DayAccept.onClick.AddListener(delegate
		{
			IncDay();
		});
		DayCancel.onClick.AddListener(CloseDayAttention);
		_menuView.gameObject.SetActive(value: false);
		newspaper.Init();
		newspaper.gameObject.SetActive(value: false);
		GainMoneyWindow.Init();
		GainMoneyWindow.gameObject.SetActive(value: false);
		GainMoneyStartup.Init();
		GainMoneyStartup.gameObject.SetActive(value: false);
		_logic.Init();
		_resourcesView.Init();
		cat.Init();
		_gameOverView.Init();
		_gameOverView.gameObject.SetActive(value: false);
		nicknameController.Init();
		nicknameController.gameObject.SetActive(value: false);
		computerBuildingController.Init();
		computerBuildingController.gameObject.SetActive(value: false);
		googleController.gameObject.SetActive(value: false);
		_mailboxView.Init();
		startupBankrupt.Init();
		startupBankrupt.gameObject.SetActive(value: false);
		construction.gameObject.SetActive(value: false);
		_buttonNewGame.onClick.AddListener(NewGame);
		buy.Init();
		buy.gameObject.SetActive(value: false);
		DayTutorial.Init();
		StartupDieTutorial.Init();
		RedUsersTutorial.Init();
		RedUsersTutorial0.Init();
		RedUsersTutorial0.gameObject.SetActive(value: false);
		buyObj.gameObject.SetActive(value: false);
		AttentionDay.gameObject.SetActive(value: false);
		Saving.gameObject.SetActive(value: false);
		Time.timeScale = 1f;
		DayTutorial.gameObject.SetActive(value: false);
		StartupDieTutorial.gameObject.SetActive(value: false);
		RedUsersTutorial.gameObject.SetActive(value: false);
		ShowMails.onClick.AddListener(ShowInboxClick);
		Inbox.gameObject.SetActive(value: false);
		Unread.Init();
		Unbought.Init();
		googleController.Init();
		googleController.gameObject.SetActive(value: false);
		GameScreen.gameObject.SetActive(value: false);
		objectInitFinished = true;
	}

	public void ResetRandomEnv()
	{
		foreach (ChangeUIStateEnv randomEnv in randomEnvs)
		{
			randomEnv.Redraw();
		}
		Player.Redraw();
		cat.Redraw();
	}

	private bool IsReplay()
	{
		return replayName.Length > 0;
	}

	private void NewGame()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		_menuView.gameObject.SetActive(value: true);
		_menuView.Redraw();
		ActiveComponent.Program.cursor.SetPosition(_menuView.Save.transform.position);
		Logic.UpdateGameSaves();
	}

	public void Run(string KEY = "WTL_saves", string replay = "")
	{
		if (Logic.cashedColors != null)
		{
			Logic.percColors.Clear();
			Logic.goodColor = Color.white;
			Logic.badColor = Color.white;
		}
		replayName = replay;
		GameScreen.gameObject.SetActive(value: true);
		Logic.loadedPrefabs.Clear();
		StartCoroutine(StartGame(KEY));
	}

	private IEnumerator StartNewOrLoad(string KEY)
	{
		Logic.LoadOrCreatePData(KEY);
		yield return null;
	}

	public void RunCorotuneCheckTutorials()
	{
		StartCoroutine(CheckDayTutorials());
	}

	public IEnumerator CheckDayTutorials()
	{
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.daysTutorial = 1;
		}
		bool flag = false;
		int i;
		for (i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
		{
			if (ActiveComponent.Model.P.Startups[i].released == 1)
			{
				flag = true;
				break;
			}
		}
		if (ActiveComponent.Model.P.daysTutorial == 0 && flag)
		{
			_startupView.SetStartupsShowState(state: true);
			DayTutorial.gameObject.SetActive(value: true);
			DayTutorial.SetActivePOI(i);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TutorialPopup");
			construction.gameObject.SetActive(value: false);
			DayTutorial.Redraw();
			StartCoroutine(DayTutorial.WaitForUserAction());
			yield return new WaitWhile(() => DayTutorial.gameObject.activeSelf);
			ActiveComponent.Model.P.daysTutorial = 1;
			DayTutorial.gameObject.SetActive(value: false);
			Logic.UpdateGameSaves();
		}
	}

	private void Update()
	{
		bool flag = Input.GetKeyDown(KeyCode.Escape);
		if (ActiveComponent.Program == null)
		{
			return;
		}
		if (ActiveComponent.Program.joyInput.bUp)
		{
			if (ActiveComponent.Model.KeyBoardTicks > 0)
			{
				return;
			}
			flag = true;
		}
		if (flag && !computerBuildingController.gameObject.activeSelf && !construction.gameObject.activeSelf && !buy.gameObject.activeSelf && !newspaper.gameObject.activeSelf && !_gameOverView.gameObject.activeSelf && !GainMoneyWindow.gameObject.activeSelf && !GainMoneyStartup.gameObject.activeSelf && !nicknameController.gameObject.activeSelf && !Inbox.gameObject.activeSelf && !_startupView.AttentionDelete.gameObject.activeSelf && !MenuView.OverrideSaveView.gameObject.activeSelf && !Tree.gameObject.activeSelf && !credit.gameObject.activeSelf && !payDay.gameObject.activeSelf && !Logic.GoogleController.gameObject.activeSelf && !StartupDieTutorial.gameObject.activeInHierarchy && !DayTutorial.gameObject.activeInHierarchy && !RedUsersTutorial.gameObject.activeInHierarchy && !RedUsersTutorial0.gameObject.activeInHierarchy)
		{
			if (newspaper.gameObject.activeSelf)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
				newspaper.closeNews.Invoke();
				newspaper.gameObject.SetActive(value: false);
			}
			else if (AttentionDay.gameObject.activeSelf)
			{
				CloseDayAttention();
			}
			else if (!_menuView.loading.gameObject.activeInHierarchy)
			{
				_menuView.AttentionExit.gameObject.SetActive(value: false);
				_menuView.gameObject.SetActive(!_menuView.gameObject.activeSelf);
				ActiveComponent.Program.cursor.SetPosition(_menuView.back.transform.position);
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			}
		}
	}

	public void LoadTask(QuestLine.Quest cq, bool replay = false)
	{
		newspaper.gameObject.SetActive(value: true);
		newspaper.Redraw(cq.name);
		construction.gameObject.SetActive(value: true);
		construction.OpenWindowInit(cq, replay);
	}

	public void ClearAfterCloseTask()
	{
		_resourcesView.InitRedraw();
		GlobalRedraw();
		construction.gameObject.SetActive(value: false);
		Time.timeScale = 1f;
		Inbox.Clear();
	}

	private IEnumerator CreditStep()
	{
		for (int i = 0; i < ActiveComponent.Model.P.credits.Count; i++)
		{
			ActiveComponent.Model.P.credits[i].DaysBack--;
			if (ActiveComponent.Model.P.credits[i].DaysBack <= 0)
			{
				payDay.Redraw(ActiveComponent.Model.P.credits[i]);
				payDay.gameObject.SetActive(value: true);
				StartCoroutine(payDay.WaitForUserAction());
				yield return new WaitWhile(() => payDay.gameObject.activeSelf);
				ActiveComponent.Model.P.Money -= ActiveComponent.Model.P.credits[i].MoneyBack;
				if (CheckEnd())
				{
					EndGame();
					break;
				}
				yield return StartCoroutine(CreditCheck(endDay: true, payDay: true));
				if (CheckEnd())
				{
					EndGame();
					break;
				}
				ActiveComponent.Model.P.credits.RemoveAt(i);
				i--;
				_resourcesView.CreditRedraw();
			}
		}
		Redraw();
	}

	private IEnumerator CreditCheck(bool endDay = false, bool payDay = false)
	{
		CheckEnd();
		if (lose)
		{
			if (!CheckEnd())
			{
				Credit curCredit = Logic.GetRandomCredit();
				if (curCredit != null)
				{
					ActiveComponent.Model.P.creditDepth++;
					curCredit = new Credit(curCredit, (int)(-ActiveComponent.Model.P.Money));
					ActiveComponent.Model.P.credits.Add(curCredit);
					curCredit.CurDepth = ActiveComponent.Model.P.creditDepth;
					credit.Redraw(curCredit);
					credit.gameObject.SetActive(value: true);
					StartCoroutine(credit.WaitForUserAction());
					yield return new WaitWhile(() => credit.gameObject.activeSelf);
					ActiveComponent.Model.P.Money += curCredit.Money;
					cat.Redraw();
					Logic.UpdateGameSaves();
					if (endDay)
					{
						ActiveComponent.Model.P.credits[ActiveComponent.Model.P.credits.Count - 1].DaysBack++;
					}
				}
			}
		}
		else if (payDay)
		{
			if (ActiveComponent.Model.P.credits.Count == 0)
			{
				ActiveComponent.Model.P.creditDepth = 0;
			}
			foreach (Credit credit in ActiveComponent.Model.P.credits)
			{
				ActiveComponent.Model.P.creditDepth = Mathf.Min(ActiveComponent.Model.P.creditDepth, credit.CurDepth);
			}
			ActiveComponent.Model.P.creditDepth = Mathf.Max(0, ActiveComponent.Model.P.creditDepth);
			ActiveComponent.Model.P.creditDepth = Mathf.Max(ActiveComponent.Model.P.creditDepth, ActiveComponent.Model.P.credits.Count);
		}
		_resourcesView.CreditRedraw();
		cat.Redraw();
	}

	public bool CheckEnd()
	{
		lose = Logic.IsLose();
		win = Logic.IsWin();
		if ((lose && ActiveComponent.Model.P.creditDepth == ActiveComponent._staticData.Settings.MaxCreditDepth) || win)
		{
			return true;
		}
		return false;
	}

	private IEnumerator StartGame(string KEY = "WTL_saves")
	{
		ActiveComponent.Program.cursor.SetActive(state: false);
		ActiveComponent.Model.LoadingSave = true;
		Epoch.text = "";
		yield return StartCoroutine(StartNewOrLoad(KEY));
		bool newSession = !Logic.DoesSaveExist(KEY);
		Inbox.gameObject.SetActive(value: false);
		_startupView.Redraw();
		ActiveComponent.Sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Gameplay");
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_RoomTone_Loop", SoundGroup.UI, loop: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Text_Loop", SoundGroup.UI, loop: true);
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
		for (int wait = 120; wait > 0; wait--)
		{
			yield return new WaitForEndOfFrame();
		}
		if (newSession && ActiveComponent.Model.curPreview.startCheckpointKeyName != ActiveComponent._staticData.Checkpoints[0].KeyName)
		{
			ActiveComponent.Model.construction = construction;
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
			nicknameController.gameObject.SetActive(value: true);
			nicknameController.Redraw();
			loading.gameObject.SetActive(value: false);
			yield return new WaitWhile(() => nicknameController.gameObject.activeSelf);
			Logic.UpdateGameSaves();
		}
		else
		{
			nicknameController.gameObject.SetActive(value: false);
		}
		loading.gameObject.SetActive(value: false);
		if (!ActiveComponent.Model.P.computerBuildingTutorialCompleted)
		{
			ActiveComponent.Model.construction = construction;
			if (ActiveComponent.Model.curPreview.startCheckpointKeyName == ActiveComponent._staticData.Checkpoints[0].KeyName)
			{
				ActiveComponent.Model.LoadingSave = false;
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
				ActiveComponent.Model.linesContainer = computerBuildingController.lineContainer.gameObject;
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
				computerBuildingController.gameObject.SetActive(value: true);
				computerBuildingController.Init();
				loading.gameObject.SetActive(value: false);
				yield return new WaitWhile(() => computerBuildingController.gameObject.activeSelf);
			}
		}
		lose = false;
		win = false;
		construction.gameObject.SetActive(value: true);
		construction.Init();
		construction.gameObject.SetActive(value: false);
		_menuView.gameObject.SetActive(value: false);
		_resourcesView.InitRedraw();
		_startupView.Redraw();
		if (ActiveComponent.Model.P.ShowFastMailTask == null)
		{
			if (ActiveComponent.Model.curPreview.startCheckpointKeyName == ActiveComponent._staticData.Checkpoints[0].KeyName)
			{
				if (!QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Checkpoints[0].ScrollToTask) || !QuestLine.IsCompleted(ActiveComponent._staticData.Checkpoints[0].ScrollToTask))
				{
					OpenTree(QuestLine.GetQuest(ActiveComponent._staticData.Checkpoints[0].ScrollToTask));
					BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(ActiveComponent._staticData.Checkpoints[0].ScrollToTask);
					QuestLine.UpdateOrAddQuest(Logic.GetBaseQuestByKeyName(ActiveComponent._staticData.Checkpoints[0].ScrollToTask));
					baseQuestByKeyName.Start();
				}
				else
				{
					OpenTree();
				}
			}
			else
			{
				OpenTree();
			}
		}
		else if (!QuestLine.GetQuest(ActiveComponent.Model.P.ShowFastMailTask.GetName()).IsCompleted())
		{
			ActiveComponent.Model.OpenTaskTree = ActiveComponent.Model.P.ShowFastMailTask;
			OpenInboxTaskFromTree();
		}
		else
		{
			OpenTree();
		}
		cat.Redraw();
		_resourcesView.CreditRedraw();
		_resourcesView.Redraw();
		Logic.UpdateGameSaves();
		ActiveComponent.Model.curPreview.version = (ActiveComponent.Model.P.version = Program.GetVersionString());
		QuestLine.SetCurrentQuest(ActiveComponent.Model.P.ShowFastMailTask);
		_mailboxView.Redraw();
		Player.Redraw();
		ResetRandomEnv();
		GlobalRedraw();
		Logic.UpdateGameSaves();
		ActiveComponent.Model.LoadingSave = false;
		ActiveComponent.Program.cursor.SetActive(ActiveComponent.Model.CurInputDeviceIsController);
	}

	public void EndGame()
	{
		GainMoneyWindow.gameObject.SetActive(value: false);
		_gameOverView.gameObject.SetActive(value: true);
		if (win)
		{
			_gameOverView.Redraw(0);
		}
		else
		{
			_gameOverView.Redraw(-1);
		}
	}

	private void GlobalRedraw()
	{
		Redraw();
		Inbox.InboxMails.UpdateUnread();
		_resourcesView.CreditRedraw();
		_mailboxView.Redraw();
		Inbox.Clear();
	}

	public void OpenInbox(bool showFastMailTask = false)
	{
		Inbox.Redraw();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		Inbox.gameObject.SetActive(value: true);
		StartCoroutine(Inbox.WaitForUserAction());
		Inbox.ToMails();
		if (showFastMailTask)
		{
			Inbox.ShowFastMailTask();
		}
	}

	public void OpenConstructionTask(QuestLine.Quest q)
	{
		isCurConstrTaskWasCompleted = q.IsCompleted();
		LoadTask(q);
		StartCoroutine(construction.WaitForUserAction());
	}

	private void OpenGainMoneyWindow()
	{
		if (QuestLine.GetCurrentQuest().GetBaseQuest().Is<ForumQuest>())
		{
			CloseGainMoneyWindow();
			return;
		}
		Debug.Log("1");
		GainMoneyWindow.gameObject.SetActive(value: true);
		GainMoneyWindow.waitAction = false;
		StartCoroutine(GainMoneyWindow.WaitForUserAction());
	}

	public void CloseGainMoneyWindow()
	{
		GainMoneyWindow.gameObject.SetActive(value: false);
		if (CheckEnd())
		{
			EndGame();
			return;
		}
		bool flag = ActiveComponent.Model.P.Days == 6 && ActiveComponent.Model.P.Startups.Count > 0;
		IncDay(flag);
		if (!flag && !QuestLine.GetCurrentQuest().GetBaseQuest().Is<ForumQuest>())
		{
			OpenTree(QuestLine.GetCurrentQuest());
		}
	}

	public void CloseConstructionTask()
	{
		ActiveComponent._controller.Player.gameObject.SetActive(value: true);
		ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
		ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
		ResetRandomEnv();
		ClearAfterCloseTask();
		Inbox.gameObject.SetActive(value: false);
		if (!isCurConstrTaskWasCompleted && QuestLine.GetCurrentQuest().IsCompleted())
		{
			OpenGainMoneyWindow();
		}
		isCurConstrTaskWasCompleted = false;
		if (CheckEnd())
		{
			EndGame();
		}
		else
		{
			StartCoroutine(CreditCheck());
		}
	}

	private void OpenStartupFromInbox()
	{
		Inbox.gameObject.SetActive(value: false);
		startupsBeforeOpenCosntruction = ActiveComponent.Model.P.Startups.Count;
		RunStartup();
		StartCoroutine(construction.WaitForUserAction());
	}

	public void RedrawBackgrounds()
	{
		ActiveComponent._controller.Player.gameObject.SetActive(value: true);
		ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
		ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
	}

	public void CloseConstructionStartup()
	{
		RedrawBackgrounds();
		ResetRandomEnv();
		_startupView.SetStartupsShowState(state: true);
		Time.timeScale = 1f;
		_startupView.Redraw();
		_resourcesView.InitRedraw();
		if (startupsBeforeOpenCosntruction < ActiveComponent.Model.P.Startups.Count)
		{
			ActiveComponent.Model.curStartup = null;
			ActiveComponent.Model.curStartupInWork = null;
			repeatMailsFlag = false;
		}
		startupsBeforeOpenCosntruction = 0;
		construction.gameObject.SetActive(value: false);
		Inbox.Redraw();
	}

	public void CloseInbox()
	{
		Redraw();
		ResetRandomEnv();
		Inbox.gameObject.SetActive(value: false);
		if (Inbox.InboxMails.state == State.Accepted)
		{
			OpenConstructionTask(ActiveComponent.Model.OpenTaskInbox);
		}
		if (Inbox.InboxStartups.state == State.Accepted)
		{
			OpenStartupFromInbox();
		}
		if (CheckEnd())
		{
			EndGame();
		}
		else
		{
			StartCoroutine(CreditCheck());
		}
	}

	private void DayStart()
	{
		lose = false;
		win = false;
		GlobalRedraw();
		if (ActiveComponent.Model.P.moneyLetters.Count > 0)
		{
			ActiveComponent.Model.P.curLetter = ActiveComponent.Model.P.moneyLetters[0];
		}
		else
		{
			ActiveComponent.Model.P.curLetter = null;
		}
		if (ActiveComponent.Model.P.startupQueue.Count > 0)
		{
			ActiveComponent.Model.curStartup = ActiveComponent.Model.P.startupQueue[0];
		}
		else
		{
			ActiveComponent.Model.curStartup = null;
		}
		_resourcesView.CreditRedraw();
		Logic.SortCredits();
		_resourcesView.Redraw();
		_resourcesView.CreditRedraw();
		if (CheckEnd())
		{
			EndGame();
		}
		Logic.UpdateGameSaves();
	}

	private void EndDay(bool openTree = false)
	{
		Random.InitState((int)Time.time);
		Random.Range(0f, 1f);
		MoneyLetter randomMoneyLetter = Logic.GetRandomMoneyLetter();
		ActiveComponent.Model.P.curLetter = null;
		if (randomMoneyLetter != null)
		{
			ActiveComponent.Model.P.wasMoneyLetters.Add(randomMoneyLetter.KeyName);
			randomMoneyLetter.Money = Random.Range(randomMoneyLetter.MinMoney, randomMoneyLetter.MaxMoney);
			ActiveComponent.Model.P.moneyLetters.Add(randomMoneyLetter);
			ActiveComponent.Model.P.curLetter = ActiveComponent.Model.P.moneyLetters[0];
		}
		Logic.AddDay();
		if (ActiveComponent.Model.P.Days % 7 == 0)
		{
			StartCoroutine(WeekEnd(openTree));
		}
		foreach (StartupScheme startup in ActiveComponent.Model.P.Startups)
		{
			startup.DayStep();
		}
		_startupView.DayStep();
		StartCoroutine(CreditStep());
		DayStart();
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.startupBadHypeTutorial = 1;
			ActiveComponent.Model.P.redUsersTurorial = 1;
			ActiveComponent.Model.P.redUsersTurorial0 = 1;
		}
		bool flag = false;
		int num = -1;
		for (num = 0; num < ActiveComponent.Model.P.Startups.Count; num++)
		{
			if (ActiveComponent.Model.P.Startups[num].released == 1)
			{
				flag = true;
				break;
			}
		}
		if (!RedUsersTutorial.gameObject.activeSelf && !DayTutorial.gameObject.activeSelf && !StartupDieTutorial.gameObject.activeSelf && ActiveComponent.Model.P.startupBadHypeTutorial == 0 && flag)
		{
			bool flag2 = false;
			int activePOI = 0;
			for (int i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
			{
				if (ActiveComponent.Model.P.Startups[i].GetHypeValue() <= 0 && ActiveComponent.Model.P.Startups[i].baseStartup.KeyName == ActiveComponent._staticData.Settings.StartupComicsTrigger)
				{
					flag2 = true;
					activePOI = i;
				}
			}
			if (flag2)
			{
				_startupView.SetStartupsShowState(state: true);
				Tree.ExitClick(playSound: false);
				StartupDieTutorial.gameObject.SetActive(value: true);
				StartupDieTutorial.SetActivePOI(activePOI);
				StartupDieTutorial.Redraw();
				StartCoroutine(StartupDieTutorial.WaitForUserAction());
				ActiveComponent.Model.P.startupBadHypeTutorial = 1;
			}
		}
		bool flag3 = false;
		int num2 = -1;
		for (num2 = 0; num2 < ActiveComponent.Model.P.Startups.Count; num2++)
		{
			if (ActiveComponent.Model.P.Startups[num2].released == 1 && ActiveComponent.Model.P.Startups[num2].baseStartup.KeyName == ActiveComponent._staticData.Settings.RedUsersTrigger && ActiveComponent.Model.P.Startups[num2].lastFailed.LastItem() > 0f && ActiveComponent.Model.P.Startups[num2].lastUsers.LastItem() > 0)
			{
				flag3 = true;
				break;
			}
		}
		if (!RedUsersTutorial.gameObject.activeSelf && !DayTutorial.gameObject.activeSelf && !StartupDieTutorial.gameObject.activeSelf && !RedUsersTutorial0.gameObject.activeSelf && ActiveComponent.Model.P.redUsersTurorial == 0 && flag3)
		{
			Tree.ExitClick(playSound: false);
			_startupView.SetStartupsShowState(state: true);
			RedUsersTutorial.gameObject.SetActive(value: true);
			RedUsersTutorial.SetActivePOI(num2);
			RedUsersTutorial.Redraw();
			StartCoroutine(RedUsersTutorial.WaitForUserAction());
			ActiveComponent.Model.P.redUsersTurorial = 1;
		}
		bool flag4 = false;
		int num3 = -1;
		for (num3 = 0; num3 < ActiveComponent.Model.P.Startups.Count; num3++)
		{
			if (ActiveComponent.Model.P.Startups[num3].released == 1 && ActiveComponent.Model.P.Startups[num3].baseStartup.KeyName == ActiveComponent._staticData.Settings.RedUsersTrigger0 && ActiveComponent.Model.P.Startups[num3].lastFailed.LastItem() > 0f && ActiveComponent.Model.P.Startups[num3].lastUsers.LastItem() > 0)
			{
				flag4 = true;
				break;
			}
		}
		if (!RedUsersTutorial0.gameObject.activeSelf && !RedUsersTutorial.gameObject.activeSelf && !DayTutorial.gameObject.activeSelf && !StartupDieTutorial.gameObject.activeSelf && ActiveComponent.Model.P.redUsersTurorial0 == 0 && flag4)
		{
			Tree.ExitClick(playSound: false);
			_startupView.SetStartupsShowState(state: true);
			RedUsersTutorial0.gameObject.SetActive(value: true);
			RedUsersTutorial0.SetActivePOI(num3);
			RedUsersTutorial0.Redraw();
			StartCoroutine(RedUsersTutorial0.WaitForUserAction());
			ActiveComponent.Model.P.redUsersTurorial0 = 1;
		}
	}

	private IEnumerator WeekEnd(bool openTree = false)
	{
		Inbox.gameObject.SetActive(value: false);
		GainMoneyStartup.gameObject.SetActive(value: true);
		int curDay = Logic.GetDay();
		for (int i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
		{
			if (ActiveComponent.Model.P.Startups[i].startDay != curDay - 1 || ActiveComponent.Model.P.Startups[i].released == 0)
			{
				GainMoneyStartup.Redraw(ActiveComponent.Model.P.Startups[i]);
				yield return StartCoroutine(GainMoneyStartup.WaitForUserAction());
			}
		}
		GainMoneyStartup.gameObject.SetActive(value: false);
		_startupView.Redraw();
		startupBankrupt.gameObject.SetActive(value: true);
		for (int i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
		{
			if (ActiveComponent.Model.P.Startups[i].baseStartup.BaseMoney < 0)
			{
				startupBankrupt.Redraw(ActiveComponent.Model.P.Startups[i]);
				StartCoroutine(startupBankrupt.WaitForUserAction());
				yield return new WaitWhile(() => startupBankrupt.gameObject.activeSelf);
				ActiveComponent.Model.P.removedStartups.Add(ActiveComponent.Model.P.Startups[i].baseStartup.KeyName);
				Logic.SendAnalytics("ALL_STARTUP_EXIT", new Dictionary<string, object>
				{
					{
						"keyName",
						ActiveComponent.Model.P.Startups[i].baseStartup.KeyName
					},
					{ "status", "bankrupt" },
					{ "money", 0 },
					{
						"patch",
						ActiveComponent.Model.P.Startups[i].patch
					},
					{
						"test runs",
						ActiveComponent.Model.P.Startups[i].testRunsInStartup
					},
					{
						"global time in startup",
						ActiveComponent.Model.P.Startups[i].timeInStartup
					},
					{
						"days",
						Logic.GetDay() - ActiveComponent.Model.P.Startups[i].startDay
					}
				});
				ActiveComponent.Model.P.Startups.RemoveAt(i);
				i--;
			}
		}
		_startupView.Redraw();
		startupBankrupt.gameObject.SetActive(value: false);
		GainMoneyStartup.gameObject.SetActive(value: false);
		ActiveComponent.Model.P.lastGainStartup = ActiveComponent.Model.P.Days;
		ActiveComponent.Model.P.Weeks++;
		ActiveComponent.Model.P.Days = 0;
		if (openTree)
		{
			OpenTree(QuestLine.GetCurrentQuest());
		}
		DayStart();
	}

	public void OpenTree(QuestLine.Quest q = null, bool matchToNextQuest = true)
	{
		if (StartupDieTutorial.gameObject.activeSelf || RedUsersTutorial.gameObject.activeSelf || RedUsersTutorial0.gameObject.activeSelf)
		{
			return;
		}
		Tree.gameObject.SetActive(value: true);
		Tree.RedrawFromQuest(q, matchToNextQuest);
		if (q != null)
		{
			if (q.quest.TaskType != "-")
			{
				StartCoroutine(Tree.WaitForUserAction());
			}
		}
		else
		{
			StartCoroutine(Tree.WaitForUserAction());
		}
		ResetRandomEnv();
	}

	public void OpenStarupOnTree(int id)
	{
		ActiveComponent._controller.Tree.gameObject.SetActive(value: true);
		ActiveComponent._controller.Tree.Redraw(ActiveComponent.Model.P.startupQueue[id].KeyName, matchToNextQuest: false);
		StartCoroutine(ActiveComponent._controller.Tree.WaitForUserAction());
	}

	private void OpenInboxTaskFromTree()
	{
		if (ActiveComponent.Model.OpenTaskTree != null)
		{
			GlobalRedraw();
			Inbox.gameObject.SetActive(value: true);
			Inbox.OpenTask(ActiveComponent.Model.OpenTaskTree);
			StartCoroutine(Inbox.WaitForUserAction());
		}
	}

	private void OpenInboxStartupFromTree()
	{
		if (ActiveComponent.Model.ShowFastStartup != null)
		{
			GlobalRedraw();
			Inbox.gameObject.SetActive(value: true);
			Inbox.OpenStartup(ActiveComponent.Model.ShowFastStartup);
			StartCoroutine(Inbox.WaitForUserAction());
		}
	}

	private void OpenStartupFromTree()
	{
		if (ActiveComponent.Model.OpenTaskTree != null)
		{
			QuestLine.SetCurrentQuest(ActiveComponent.Model.OpenTaskTree);
		}
		if (!construction.gameObject.activeSelf)
		{
			OpenInboxStartupFromTree();
		}
	}

	public void CloseTree()
	{
		if (CheckEnd())
		{
			EndGame();
			return;
		}
		StartCoroutine(CreditCheck());
		if (Tree.state == StateTreeOpen.Inbox)
		{
			OpenInboxTaskFromTree();
		}
		if (Tree.state == StateTreeOpen.Startup)
		{
			OpenStartupFromTree();
		}
		if (Tree.state != StateTreeOpen.Construction)
		{
			return;
		}
		if (!Transition.gameObject.activeSelf)
		{
			Transition.gameObject.SetActive(value: true);
			Transition.ActiveOnFade(delegate
			{
				CloseTree();
			});
		}
		else
		{
			Tree.gameObject.SetActive(value: false);
			OpenConstructionTask(ActiveComponent.Model.OpenTaskTree);
		}
	}

	public void OpenSandBox()
	{
		ActiveComponent._controller.construction.gameObject.SetActive(value: true);
		ActiveComponent.Model.SandboxOpen = "SANDBOX" + ActiveComponent.Model.P.lastOpenSandbox;
		construction.OpenWindowInit(null, false, false, "", true);
		StartCoroutine(construction.WaitForUserAction());
	}

	public void CloseSandBox()
	{
		ResetRandomEnv();
		ClearAfterCloseTask();
	}
}

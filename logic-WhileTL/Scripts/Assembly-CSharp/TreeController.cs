using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Data;
using Aux;
using DeepTraffic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : ActiveComponent
{
	private enum Purchase
	{
		WaitingForPrice = 0,
		PriceLoaded = 1,
		TimeoutLoadPrice = 2,
		WaitingForPurchase = 3,
		Success = 4,
		Fail = 5,
		TimeoutPurchase = 6
	}

	[SceneBind("ExitButton")]
	public Button ExitButton;

	[SceneBind("Scroll View/Viewport/Content")]
	public RectTransform LevelsContent;

	[SceneBind("Scroll View/Viewport/HoverContent")]
	public RectTransform HoverContent;

	[SceneBind("Scroll View/Viewport")]
	public RectTransform Viewport;

	[SceneBind("Scroll View/Viewport/Content/LinesContainer")]
	public RectTransform LinesContainer;

	[SceneBind("Scroll View/Scrollbar Vertical")]
	public Scrollbar VerticalScroll;

	[SceneBind("Scroll View/Viewport/HoverContent/WarFog")]
	public dimWFHandler WarFog;

	[SceneBind("Scroll View/Viewport/WF_RTImageHolder/WF_RTImage")]
	public MaskToAspect WF_RTImage;

	[SceneBind("Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("StartupTutorial")]
	public TutorialList StartupTutorial;

	[SceneBind("SteamReview")]
	public SteamReview SteamReview;

	[SceneBind("FeelSurvey")]
	public RectTransform FeelSurvey;

	[SceneBind("LegendColors")]
	public Button LegendColors;

	[SceneBind("LegendIcon")]
	public Button LegendIcon;

	[SceneBind("LegendIcon/RL")]
	public RectTransform RLIcon;

	[SceneBind("LegendIcon/Startup")]
	public RectTransform StartupIcon;

	[SceneBind("LegendIcon/Forum")]
	public RectTransform ForumIcon;

	[SceneBind("OpenLegendColors")]
	public Button OpenLegendColors;

	[SceneBind("LegendColors/RNN")]
	public RectTransform RNNColor;

	[SceneBind("LegendColors/NEURAL")]
	public RectTransform NEURALColor;

	[SceneBind("LegendColors/GENETIC")]
	public RectTransform GENETICColor;

	[SceneBind("LegendColors/UTILITY")]
	public RectTransform UTILITYColor;

	[SceneBind("LegendColors/BASICML")]
	public RectTransform BASICMLColor;

	[SceneBind("OpenLegendIcon")]
	public Button OpenLegendIcon;

	[SceneBind("FeelSurvey/Ok")]
	public Button FeelSurveyOk;

	[SceneBind("FeelSurvey/Cancel")]
	public Button FeelSurveyCancel;

	[SceneBind("FirstTreeTutorial")]
	public Transform firstTreeTutorial;

	[SceneBind("ShopTutorial")]
	private TutorialList shopTutorial;

	[SceneBind("ShopTutorial/Page1/ShopIcon")]
	private Transform shopTutorialShopIcon;

	[SceneBind("ShopTutorial/Page1/Tutorial_null/ShopButton")]
	private Button shopTutorialShopButton;

	[SceneBind("EpochGoalController")]
	public EpochGoalController EpochGoalController;

	[SceneBind("BuyFull")]
	public RectTransform BuyFull;

	[SceneBind("BuyFull/Accept")]
	public Button BuyFullAccept;

	[SceneBind("BuyFull/Accept/Text")]
	public Text BuyFullAcceptText;

	[SceneBind("BuyFull/Status")]
	public Text StatusText;

	[SceneBind("BuyFull/Close")]
	public Button CloseBuyFull;

	[SceneBind("PlsFinishTutorialStartup")]
	public RectTransform PlsFinishTutorialStartup;

	[SceneBind("PlsFinishTutorialStartup/Close")]
	public Button PlsFinishTutorialStartupClose;

	[SceneBind("PlsFinishTutorialStartup/GoToTutStartup")]
	public Button PlsFinishTutorialStartupGoToTutStartup;

	[SceneBind("BackTree")]
	public RectTransform BackTree;

	private Rect BackTreeRect = Rect.zero;

	[SceneBind("BackTreeSticker")]
	public RectTransform BackTreeSticker;

	private Rect BackTreeStickerRect = Rect.zero;

	private Dictionary<int, LevelTreeController> LevelsInTree = new Dictionary<int, LevelTreeController>();

	public List<TreeChain> chains = new List<TreeChain>();

	private Dictionary<int, GameObject> Epochs = new Dictionary<int, GameObject>();

	private Dictionary<int, GameObject> Stickers = new Dictionary<int, GameObject>();

	public StateTreeOpen state;

	private bool closeTreeIgnore;

	private GameObject LevelTreeObject;

	private float totalScrollHeight;

	private float viewportHeight;

	private HashSet<string> taskTypesUnlocked = new HashSet<string>();

	private List<int> activeStickers = new List<int>();

	private bool redrawInNextUpdate;

	private string progressChars = "-\\|/";

	private Purchase buyGameState;

	private float progressSpeed = 10f;

	private int checkCounter;

	public int checkRate = 3;

	private int skipFrames;

	private void DrawLinesToUnlock(string keyName)
	{
		Startup startupByKeyName = Logic.GetStartupByKeyName(keyName);
		List<UnlockGroup> list = null;
		list = ((startupByKeyName == null) ? Logic.GetBaseQuestByKeyName(keyName).ReqUnlockGroups : startupByKeyName.ReqUnlockGroups);
		if (UnlockGroup.IsUnlocked(list))
		{
			return;
		}
		LevelsInTree[keyName.GetHashCode()].HoverChainsToUnlock();
		foreach (UnlockGroup item in list)
		{
			foreach (string questsKeyName in item.questsKeyNames)
			{
				DrawLinesToUnlock(questsKeyName);
			}
		}
	}

	private void HideLinesToUnlock()
	{
		foreach (KeyValuePair<int, LevelTreeController> item in LevelsInTree)
		{
			item.Value.HideChainsToUnlock();
		}
	}

	public void OpenTaskFromTree(string keyName)
	{
		Startup startupByKeyName = Logic.GetStartupByKeyName(keyName);
		if (startupByKeyName != null)
		{
			OpenStartupMail(startupByKeyName);
			return;
		}
		BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(keyName);
		if (baseQuestByKeyName != null)
		{
			BaseGameQuestOpenTask(QuestLine.GetQuest(baseQuestByKeyName.KeyName), keyName);
		}
	}

	private void OpenStartupMail(Startup st)
	{
		if (!ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) && st.KeyName != "TUTORIAL_STARTUP" && !ActiveComponent.Model.P.removedStartups.Contains("TUTORIAL_STARTUP"))
		{
			PlsFinishTutorialStartup.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(PlsFinishTutorialStartupGoToTutStartup.transform.position);
			return;
		}
		ActiveComponent.Model.ShowFastStartup = st;
		base.gameObject.SetActive(value: false);
		ActiveComponent._controller.Player.gameObject.SetActive(value: true);
		ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
		ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
		state = StateTreeOpen.Startup;
	}

	private void OpenStartup(Startup st)
	{
		if (st == null)
		{
			return;
		}
		if (!ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial) && st.KeyName != "TUTORIAL_STARTUP" && ActiveComponent.Model.P.removedStartups.Count == 0)
		{
			PlsFinishTutorialStartup.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(PlsFinishTutorialStartupGoToTutStartup.transform.position);
			return;
		}
		QuestLine.SetCurrentQuest(st.KeyName);
		if (ActiveComponent.Model.P.usedStartups.Contains(st.KeyName))
		{
			int hashCode = st.KeyName.GetHashCode();
			foreach (GameObject startup in ActiveComponent._controller._startupView.startups)
			{
				StartupControl component = startup.GetComponent<StartupControl>();
				if (component.sch.baseStartup.KeyName.GetHashCode() == hashCode)
				{
					component.ReworkClick();
					base.gameObject.SetActive(value: true);
					state = StateTreeOpen.Startup;
					closeTreeIgnore = true;
					return;
				}
			}
			OpenStartupMail(st);
		}
		else if (AddStartup(st))
		{
			OpenStartupMail(st);
		}
	}

	public bool AddStartup(Startup st)
	{
		if (st != null)
		{
			ActiveComponent.Model.curStartupInWork = null;
			ActiveComponent.Model.P.startupQueue.Add(Logic.GetRandomStartup(st.KeyName));
			ActiveComponent.Model.P.usedStartups.Add(st.KeyName);
		}
		return st != null;
	}

	public void BaseGameQuestOpenTask(QuestLine.Quest q, string keyName)
	{
		state = StateTreeOpen.Inbox;
		ActiveComponent.Model.OpenTaskTree = q;
		if (!ActiveComponent.Model.P.taskQueue.Contains(keyName))
		{
			ActiveComponent.Model.P.taskQueue.Add(keyName);
		}
		ActiveComponent.Model.P.ShowFastMailTask = ActiveComponent.Model.OpenTaskTree;
		ActiveComponent._controller._mailboxView.Redraw();
	}

	private bool RequiersBuyGameTask(string keyName)
	{
		if (keyName == ActiveComponent._staticData.Settings.LockBuyQuest)
		{
			return true;
		}
		foreach (UnlockGroup reqUnlockGroup in Logic.GetBaseQuestByKeyName(keyName).ReqUnlockGroups)
		{
			foreach (string questsKeyName in reqUnlockGroup.questsKeyNames)
			{
				if (RequiersBuyGameTask(questsKeyName))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void StartTask(string keyName)
	{
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		Startup startupByKeyName = Logic.GetStartupByKeyName(keyName);
		if (startupByKeyName == null)
		{
			Logic.GetBaseQuestByKeyName(keyName).Start();
		}
		else
		{
			OpenStartup(startupByKeyName);
		}
	}

	public void OpenConstruction(string keyName)
	{
		state = StateTreeOpen.Construction;
		ActiveComponent.Model.OpenTaskTree = QuestLine.GetQuest(keyName);
		if (ActiveComponent.Model.OpenTaskTree.Is<ForumQuest>())
		{
			ActiveComponent.Model.P.ShowFastMailTask = null;
			base.gameObject.SetActive(value: false);
			ActiveComponent._controller.Player.gameObject.SetActive(value: true);
			ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
			ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
			return;
		}
		if (!ActiveComponent.Model.P.taskQueue.Contains(keyName))
		{
			ActiveComponent.Model.P.taskQueue.Add(keyName);
		}
		ActiveComponent.Model.P.ShowFastMailTask = ActiveComponent.Model.OpenTaskTree;
		ActiveComponent._controller._mailboxView.Redraw();
		if (state != StateTreeOpen.Construction && state != StateTreeOpen.Startup)
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent._controller.Player.gameObject.SetActive(value: true);
			ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
			ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
		}
	}

	public IEnumerator WaitForUserAction()
	{
		while (state == StateTreeOpen.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
		if (!closeTreeIgnore)
		{
			ActiveComponent._controller.CloseTree();
		}
		closeTreeIgnore = false;
		if (state != StateTreeOpen.Construction && state != StateTreeOpen.Startup)
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent._controller.Player.gameObject.SetActive(value: true);
			ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
			ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
		}
	}

	public void ExitClick(bool playSound = true)
	{
		if (playSound)
		{
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		}
		state = StateTreeOpen.Inbox;
		ActiveComponent.Model.OpenTaskTree = null;
		base.gameObject.SetActive(value: false);
		ActiveComponent._controller.Player.gameObject.SetActive(value: true);
		ActiveComponent._controller._resourcesView.gameObject.SetActive(value: true);
		ActiveComponent._controller._mailboxView.gameObject.SetActive(value: true);
	}

	public GameObject GetTaskGo(string keyName)
	{
		return LevelsInTree[keyName.GetHashCode()].gameObject;
	}

	private void GoToTutStartup()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		PlsFinishTutorialStartup.gameObject.SetActive(value: false);
		Redraw("TUTORIAL_STARTUP");
	}

	protected override void OnInit()
	{
		base.OnInit();
		LevelTreeObject = Resources.Load(Logic.GetPrefabPath("LevelTreeObject")) as GameObject;
		SceneBindContainer.BindObjects(this, base.transform);
		BackTreeRect = Helper.GetWorldRect(BackTree);
		BackTreeStickerRect = Helper.GetWorldRect(BackTreeSticker);
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		StatusText.text = "";
		shopTutorialShopButton.onClick.AddListener(delegate
		{
			shopTutorial.ForceQuit();
			ExitClick();
			Logic.Controller.LearnSmthNewClick(ShopController.OpenShopState.Hardware);
		});
		LegendColors.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			LegendColors.gameObject.SetActive(value: false);
			OpenLegendColors.gameObject.SetActive(value: true);
		});
		LegendIcon.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			LegendIcon.gameObject.SetActive(value: false);
			OpenLegendIcon.gameObject.SetActive(value: true);
		});
		OpenLegendColors.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			LegendColors.gameObject.SetActive(value: true);
			OpenLegendColors.gameObject.SetActive(value: false);
		});
		OpenLegendIcon.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			LegendIcon.gameObject.SetActive(value: true);
			OpenLegendIcon.gameObject.SetActive(value: false);
		});
		OpenLegendColors.gameObject.SetActive(value: false);
		OpenLegendIcon.gameObject.SetActive(value: false);
		PlsFinishTutorialStartupGoToTutStartup.onClick.AddListener(GoToTutStartup);
		BuyFullAccept.onClick.AddListener(BuyBtnClick);
		EpochGoalController.Init();
		shopTutorial.Init();
		StartupTutorial.Init();
		SteamReview.Init();
		FeelSurvey.gameObject.SetActive(value: false);
		SteamReview.gameObject.SetActive(value: false);
		FeelSurveyCancel.onClick.AddListener(CloseFeelSurvey);
		FeelSurveyOk.onClick.AddListener(OpenFeelSurvey);
		Transform[] componentsInChildren = LevelsContent.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.tag == "TreePlace")
			{
				if (transform.gameObject.activeSelf)
				{
					GameObject go = Object.Instantiate(LevelTreeObject, base.transform.position, base.transform.rotation);
					go.transform.SetParent(transform);
					go.name = transform.name;
					go.transform.localScale = new Vector3(1f, 1f, 1f);
					go.transform.localPosition = new Vector3(0f, 0f, 0f);
					LevelTreeController component = go.GetComponent<LevelTreeController>();
					LevelsInTree.Add(transform.gameObject.name.GetHashCode(), component);
					component.Init();
					component.startHoverEvent.AddListener(delegate
					{
						DrawLinesToUnlock(go.name);
					});
					component.endHoverEvent.AddListener(HideLinesToUnlock);
					string name = transform.gameObject.name;
					component.Mail.onClick.AddListener(delegate
					{
						OpenTaskFromTree(name);
					});
				}
				else
				{
					Object.Destroy(transform.gameObject);
				}
			}
			if (transform.tag == "Epoch")
			{
				Epochs.Add(transform.gameObject.name.GetHashCode(), transform.gameObject);
			}
		}
		componentsInChildren = HoverContent.GetComponentsInChildren<Transform>();
		foreach (Transform transform2 in componentsInChildren)
		{
			if (transform2.tag == "Epoch")
			{
				Epochs.Add(transform2.gameObject.name.GetHashCode(), transform2.gameObject);
			}
			if (transform2.tag == "Sticker")
			{
				Stickers.Add(transform2.gameObject.name.GetHashCode(), transform2.gameObject);
			}
		}
		state = StateTreeOpen.Undefined;
		ExitButton.onClick.AddListener(delegate
		{
			ExitClick();
		});
		totalScrollHeight = LinesContainer.gameObject.transform.parent.GetComponent<RectTransform>().rect.height;
		viewportHeight = LinesContainer.gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.height;
		Logic.ComicsController.gameObject.SetActive(value: false);
		firstTreeTutorial.gameObject.SetActive(value: false);
		StartupTutorial.gameObject.SetActive(value: false);
		BuyFull.gameObject.SetActive(value: false);
		CloseBuyFull.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			BuyFull.gameObject.SetActive(value: false);
		});
		PlsFinishTutorialStartupClose.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			PlsFinishTutorialStartup.gameObject.SetActive(value: false);
		});
		PlsFinishTutorialStartup.gameObject.SetActive(value: false);
		foreach (LevelTreeController value in LevelsInTree.Values)
		{
			value.transform.parent.gameObject.SetActive(value: false);
		}
	}

	public void RedrawFromQuest(QuestLine.Quest cq, bool matchToNextQuest = true)
	{
		if (cq == null)
		{
			Redraw();
		}
		else
		{
			Redraw(cq.GetName(), matchToNextQuest);
		}
	}

	public void OpenFeelSurvey()
	{
	}

	public void CloseFeelSurvey()
	{
		FeelSurvey.gameObject.SetActive(value: false);
	}

	public void Redraw(string scrollToP = null, bool matchToNextQuest = true)
	{
		BackTreeRect = Helper.GetWorldRect(BackTree);
		BackTreeStickerRect = Helper.GetWorldRect(BackTreeSticker);
		ActiveComponent._controller.Player.gameObject.SetActive(value: false);
		ActiveComponent._controller._resourcesView.gameObject.SetActive(value: false);
		ActiveComponent._controller._mailboxView.gameObject.SetActive(value: false);
		WF_RTImage.Init();
		ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
		foreach (KeyValuePair<int, GameObject> epoch in Epochs)
		{
			epoch.Value.SetActive(UnlockGroup.IsUnlocked(Logic.GetEpochByHash(epoch.Key).ReqUnlockGroups));
		}
		foreach (KeyValuePair<int, GameObject> sticker in Stickers)
		{
			bool flag = UnlockGroup.IsUnlocked(Logic.GetStickerByHash(sticker.Key).ReqUnlockGroups);
			sticker.Value.SetActive(flag);
			if (!activeStickers.Contains(sticker.Key) && flag)
			{
				activeStickers.Add(sticker.Key);
			}
		}
		Epochs[ActiveComponent._staticData.Epochs[0].KeyName.GetHashCode()].SetActive(value: true);
		taskTypesUnlocked.Clear();
		foreach (ConstructionQuest quest in ActiveComponent._staticData.Quests)
		{
			if (quest.IsTask == 1 && UnlockGroup.IsVisible(quest.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
			{
				taskTypesUnlocked.Add(quest.TaskType);
			}
		}
		foreach (ForumQuest forumQuest in ActiveComponent._staticData.ForumQuests)
		{
			if (forumQuest.VisibleToPlayer && UnlockGroup.IsVisible(forumQuest.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
			{
				taskTypesUnlocked.Add(forumQuest.TaskType);
			}
		}
		BASICMLColor.gameObject.SetActive(taskTypesUnlocked.Contains("BASICML"));
		GENETICColor.gameObject.SetActive(taskTypesUnlocked.Contains("GENETIC"));
		NEURALColor.gameObject.SetActive(taskTypesUnlocked.Contains("NEURAL"));
		RNNColor.gameObject.SetActive(taskTypesUnlocked.Contains("RNN"));
		UTILITYColor.gameObject.SetActive(taskTypesUnlocked.Contains("UTILITY"));
		Vector2 sizeDelta = LegendColors.GetComponent<RectTransform>().sizeDelta;
		sizeDelta.y = BASICMLColor.sizeDelta.y * (float)(taskTypesUnlocked.Count + 1);
		LegendColors.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		int num = 2;
		ForumIcon.gameObject.SetActive(value: false);
		RLIcon.gameObject.SetActive(value: false);
		StartupIcon.gameObject.SetActive(value: false);
		foreach (ForumQuest forumQuest2 in ActiveComponent._staticData.ForumQuests)
		{
			if (forumQuest2.VisibleToPlayer && UnlockGroup.IsVisible(forumQuest2.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
			{
				ForumIcon.gameObject.SetActive(value: true);
				num++;
				break;
			}
		}
		foreach (CarQuest carQuest in ActiveComponent._staticData.CarQuests)
		{
			if (carQuest.VisibleToPlayer && UnlockGroup.IsVisible(carQuest.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
			{
				RLIcon.gameObject.SetActive(value: true);
				num++;
				break;
			}
		}
		foreach (Startup startup in ActiveComponent._staticData.Startups)
		{
			if (startup.VisibleToPlayer && UnlockGroup.IsVisible(startup.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
			{
				StartupIcon.gameObject.SetActive(value: true);
				num++;
				break;
			}
		}
		sizeDelta = LegendIcon.GetComponent<RectTransform>().sizeDelta;
		sizeDelta.y = ForumIcon.sizeDelta.y * (float)(num + 1);
		LegendIcon.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		state = StateTreeOpen.Undefined;
		ActiveComponent.Model.OpenTaskTree = null;
		foreach (KeyValuePair<int, LevelTreeController> item in LevelsInTree)
		{
			item.Value.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
			SelectHighlighter[] componentsInChildren = item.Value.GetComponentsInChildren<SelectHighlighter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Clear();
			}
			BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(item.Value.gameObject.name);
			List<UnlockGroup> list = null;
			Startup startupByKeyName = Logic.GetStartupByKeyName(item.Value.gameObject.name);
			if (startupByKeyName != null)
			{
				list = startupByKeyName.ReqUnlockGroups;
				item.Value.Init(startupByKeyName);
			}
			else
			{
				list = baseQuestByKeyName.ReqUnlockGroups;
				item.Value.Init(Logic.GetBaseQuestByKeyName(item.Value.gameObject.name));
			}
			if (UnlockGroup.IsUnlocked(list, onlyUnlock: true))
			{
				string name = item.Value.gameObject.name;
				item.Value.GetComponentInChildren<Button>().onClick.AddListener(delegate
				{
					StartTask(name);
				});
			}
			else
			{
				bool flag2 = false;
				foreach (UnlockGroup item2 in list)
				{
					foreach (int questsHash in item2.questsHashes)
					{
						if (UnlockGroup.IsVisible(Logic.GetBaseQuestByKeyHash(questsHash).ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth))
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
				if (!flag2)
				{
					continue;
				}
			}
			if (startupByKeyName == null)
			{
				item.Value.InitChains(Logic.GetBaseQuestByKeyName(item.Value.gameObject.name), this);
			}
			else
			{
				item.Value.InitChains(startupByKeyName, this);
			}
		}
		foreach (ConstructionQuest quest2 in ActiveComponent._staticData.Quests)
		{
			if (quest2.Locked == 1)
			{
				bool isHidden = !UnlockGroup.IsVisible(quest2.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth);
				WarFog.WFHandle(quest2.KeyName, isHidden);
			}
		}
		foreach (CarQuest carQuest2 in ActiveComponent._staticData.CarQuests)
		{
			if (carQuest2.Locked == 1)
			{
				bool isHidden2 = !UnlockGroup.IsVisible(carQuest2.ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth);
				WarFog.WFHandle(carQuest2.KeyName, isHidden2);
			}
		}
		if (ActiveComponent.Model.curPreview.startCheckpointKeyName == null)
		{
			ActiveComponent.Model.curPreview.startCheckpointKeyName = "";
		}
		string text = ActiveComponent._staticData.Quests[0].KeyName;
		QuestLine.Quest currentQuest = QuestLine.GetCurrentQuest();
		if (currentQuest != null)
		{
			text = currentQuest.GetName();
		}
		if (ActiveComponent.Model.OpenTaskTree != null)
		{
			text = ActiveComponent.Model.OpenTaskTree.name;
		}
		if (scrollToP != null)
		{
			text = scrollToP;
		}
		bool flag3 = false;
		if (matchToNextQuest)
		{
			if (ActiveComponent.Model.RunTaskWhenTreeOpens != string.Empty && QuestLine.GetCurrentQuest().IsCompleted())
			{
				string nextImmediatelyQuest = Logic.GetNextImmediatelyQuest(ActiveComponent.Model.RunTaskWhenTreeOpens);
				if (nextImmediatelyQuest == "EXPERT_LEARN" && ActiveComponent.Model.curPreview.startCheckpointKeyName == ActiveComponent._staticData.Checkpoints[0].KeyName && !QuestLine.IsLoadedInMemory("EXPERT_LEARN"))
				{
					ActiveComponent._controller.nicknameController.gameObject.SetActive(value: true);
					ActiveComponent._controller.nicknameController.Redraw();
					flag3 = true;
					StartCoroutine(WaitNickname(nextImmediatelyQuest));
				}
				else if (nextImmediatelyQuest != null)
				{
					OpenNextTask(nextImmediatelyQuest);
				}
				else
				{
					BaseQuest baseQuest = QuestLine.GetCurrentQuest().GetBaseQuest();
					if (baseQuest.Main == 1)
					{
						scrollToP = GetNextMainTask(baseQuest.KeyName);
						if (scrollToP != null)
						{
							if (!QuestLine.IsLoadedInMemory(scrollToP))
							{
								text = scrollToP;
							}
							else if (QuestLine.IsLoadedInMemory(scrollToP) && !QuestLine.GetQuest(scrollToP).IsCompleted())
							{
								text = scrollToP;
							}
						}
					}
				}
				ActiveComponent.Model.RunTaskWhenTreeOpens = string.Empty;
			}
			else if (QuestLine.IsLoadedInMemory(text))
			{
				BaseQuest baseQuest2 = QuestLine.GetQuest(text).GetBaseQuest();
				if (baseQuest2.Main == 1 && QuestLine.GetQuest(text).IsCompleted())
				{
					scrollToP = GetNextMainTask(baseQuest2.KeyName);
					if (scrollToP != null)
					{
						if (!QuestLine.IsLoadedInMemory(scrollToP))
						{
							text = scrollToP;
						}
						else if (QuestLine.IsLoadedInMemory(scrollToP) && !QuestLine.GetQuest(scrollToP).IsCompleted())
						{
							text = scrollToP;
						}
					}
				}
			}
		}
		RectTransform rectTransform = null;
		int key = text.GetHashCode();
		if (!LevelsInTree.ContainsKey(key))
		{
			key = QuestLine.GetCurrentQuest().GetName().GetHashCode();
		}
		if (!LevelsInTree.ContainsKey(key))
		{
			key = LevelsInTree.Keys.ToList().LastItem();
		}
		rectTransform = LevelsInTree[key].gameObject.transform.parent.GetComponent<RectTransform>();
		Vector3 localPosition = Helper.GetSnapToPositionToBringChildIntoView(ScrollRect, rectTransform);
		ScrollRect.content.localPosition = localPosition;
		if (!flag3 && !ActiveComponent._controller.GoogleController.gameObject.activeSelf)
		{
			ActiveComponent.Program.cursor.SetPosition(LevelsInTree[key].gameObject.transform.position);
		}
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.startupTutorial = 1;
		}
		if (Logic.IsCheatActivated("UNLOCK_SR"))
		{
			OpenRewiew();
		}
		shopTutorial.gameObject.SetActive(value: false);
		if (ActiveComponent.Model.showSteamWindow && !ActiveComponent.Model.globalSaves.IsSet(SaveFlags.WatchedStreamReviewWindow))
		{
			OpenRewiew();
		}
		EpochGoalController.Redraw();
		ActiveComponent.Model.OpenTaskTree = null;
		ActiveComponent.Model.OpenTaskInbox = null;
		if (ActiveComponent._controller.CheckEnd())
		{
			state = StateTreeOpen.Inbox;
		}
		CheckTutorials();
		redrawInNextUpdate = true;
		foreach (LevelTreeController value in LevelsInTree.Values)
		{
			BackTreeRect.Contains(value.transform.position);
			value.transform.parent.gameObject.SetActive(value: true);
		}
	}

	private string GetNextMainTask(string keyName)
	{
		foreach (ConstructionQuest quest in ActiveComponent._staticData.Quests)
		{
			if (quest.ReqUnlock.Contains(keyName) && quest.Main == 1 && quest.Locked == 0 && quest.VisibleToPlayer)
			{
				return quest.KeyName;
			}
		}
		foreach (ForumQuest forumQuest in ActiveComponent._staticData.ForumQuests)
		{
			if (forumQuest.ReqUnlock.Contains(keyName) && forumQuest.Main == 1 && forumQuest.Locked == 0 && forumQuest.VisibleToPlayer)
			{
				return forumQuest.KeyName;
			}
		}
		foreach (Comics comicse in ActiveComponent._staticData.Comicses)
		{
			if (comicse.ReqUnlock.Contains(keyName) && comicse.Main == 1 && comicse.Locked == 0 && comicse.VisibleToPlayer)
			{
				return comicse.KeyName;
			}
		}
		return null;
	}

	private void OpenNextTask(string nextTask)
	{
		QuestLine.Quest quest = QuestLine.UpdateOrAddQuest(Logic.GetBaseQuestByKeyName(nextTask));
		BaseQuest baseQuest = quest.GetBaseQuest();
		if (!quest.IsCompleted() || (baseQuest.Is<ForumQuest>() && baseQuest.As<ForumQuest>().QuestKeyName == "-"))
		{
			StartTask(nextTask);
		}
	}

	private IEnumerator WaitNickname(string nextTask)
	{
		while (ActiveComponent._controller.nicknameController.gameObject.activeSelf)
		{
			yield return new WaitForEndOfFrame();
		}
		OpenNextTask(nextTask);
	}

	private void SetDisabledTutorials()
	{
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.shopTutorial = 1;
			ActiveComponent.Model.P.startupTutorial = 1;
		}
	}

	private void CheckTutorials()
	{
		if (FeelSurvey.gameObject.activeSelf)
		{
			return;
		}
		SetDisabledTutorials();
		bool flag = false;
		if (ActiveComponent.Model.P.shopTutorial == 0)
		{
			string[] array = ActiveComponent._staticData.Settings.ShopTrigger.Split(';');
			foreach (string keyName in array)
			{
				if (QuestLine.IsLoadedInMemory(keyName) && QuestLine.GetQuest(keyName).IsCompleted())
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			shopTutorialShopIcon.GetComponentInChildren<UnreadController>().Init();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TutorialPopup");
			shopTutorialShopIcon.GetComponentInChildren<UnreadController>().Num = Logic.GetUnwatchedShop();
			StartCoroutine(WaitTutorialList(shopTutorial));
			ActiveComponent.Program.cursor.SetPosition(shopTutorialShopButton.transform.position);
			ActiveComponent.Model.P.shopTutorial = 1;
		}
		else if (QuestLine.IsLoadedInMemory(ActiveComponent._staticData.Settings.StartupTutorialTrigger) && QuestLine.GetQuest(ActiveComponent._staticData.Settings.StartupTutorialTrigger).IsCompleted() && ActiveComponent.Model.P.startupTutorial == 0)
		{
			StartupTutorial.gameObject.SetActive(value: true);
			StartCoroutine(WaitTutorialList(StartupTutorial));
			ActiveComponent.Model.P.startupTutorial = 1;
		}
	}

	private void OpenRewiew()
	{
		SteamReview.gameObject.SetActive(value: true);
		SteamReview.InitRedraw();
		ActiveComponent.Model.showSteamWindow = false;
		ActiveComponent.Model.globalSaves.Set(SaveFlags.WatchedStreamReviewWindow);
		Logic.UpdateGlobalSaves();
	}

	public IEnumerator WaitTutorialList(TutorialList tutorial)
	{
		tutorial.gameObject.SetActive(value: true);
		tutorial.Redraw();
		ActiveComponent.Program.cursor.SetPosition(tutorial.GetClickPosition());
		yield return StartCoroutine(tutorial.WaitForUserAction());
		CheckTutorials();
	}

	private void ChangeValueScroll(float val)
	{
		HoverContent.localPosition = LevelsContent.localPosition;
	}

	private void TryBuy()
	{
	}

	private void TryLoadPriceAgain()
	{
		buyGameState = Purchase.WaitingForPrice;
	}

	private void BuyBtnClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (buyGameState == Purchase.PriceLoaded)
		{
			TryBuy();
		}
		if (buyGameState == Purchase.TimeoutLoadPrice)
		{
			TryLoadPriceAgain();
		}
	}

	private void UpdateVisibilityOnScreen(bool ignoreCounter = false)
	{
		if (skipFrames < 5)
		{
			return;
		}
		if (ignoreCounter)
		{
			if (checkCounter % checkRate != 0)
			{
				checkCounter++;
				return;
			}
			checkCounter = 1;
		}
		foreach (LevelTreeController value in LevelsInTree.Values)
		{
			bool flag = BackTreeRect.Contains(value.transform.position);
			if (value.transform.parent.gameObject.activeInHierarchy != flag)
			{
				value.transform.parent.gameObject.SetActive(flag);
			}
		}
		foreach (TreeChain chain in chains)
		{
			bool flag2 = chain.questIn.gameObject.activeInHierarchy || chain.questOut.gameObject.activeInHierarchy;
			if (chain.gameObject.activeInHierarchy != flag2)
			{
				chain.gameObject.SetActive(flag2);
			}
		}
		foreach (KeyValuePair<int, GameObject> sticker in Stickers)
		{
			if (activeStickers.Contains(sticker.Key))
			{
				bool flag3 = BackTreeStickerRect.Contains(sticker.Value.transform.position);
				sticker.Value.transform.gameObject.SetActive(flag3);
				if (!activeStickers.Contains(sticker.Key) && flag3)
				{
					activeStickers.Add(sticker.Key);
				}
			}
			else
			{
				sticker.Value.gameObject.SetActive(value: false);
			}
		}
	}

	public void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		skipFrames++;
		if (redrawInNextUpdate)
		{
			redrawInNextUpdate = false;
			UpdateVisibilityOnScreen(ignoreCounter: true);
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
			if (!StartupTutorial.gameObject.activeSelf && !firstTreeTutorial.gameObject.activeSelf && !SteamReview.gameObject.activeSelf && !Logic.ComicsController.gameObject.activeSelf && !Logic.GoogleController.gameObject.activeSelf && !shopTutorial.gameObject.activeSelf && !ActiveComponent._controller.nicknameController.gameObject.activeSelf)
			{
				ExitClick();
				return;
			}
			if (Logic.ComicsController.gameObject.activeSelf && Logic.ComicsController.ChooseWindow.gameObject.activeSelf)
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
				Logic.ComicsController.gameObject.SetActive(value: false);
				return;
			}
		}
		if (!firstTreeTutorial.gameObject.activeSelf && !StartupTutorial.gameObject.activeSelf && ActiveComponent.Program.joyInput.areaMove)
		{
			Vector3 areaMoveDelta = ActiveComponent.Program.joyInput.areaMoveDelta;
			areaMoveDelta.x = 0f;
			ScrollRect.content.transform.position += Logic.ModifySliderMoveDelta(areaMoveDelta);
			UpdateVisibilityOnScreen();
		}
	}
}

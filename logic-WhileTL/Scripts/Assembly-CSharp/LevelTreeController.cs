using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelTreeController : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private bool hidePopup;

	private bool hover;

	private float timer;

	public UnityEvent startHoverEvent = new UnityEvent();

	public UnityEvent endHoverEvent = new UnityEvent();

	[SceneBind("TextLayer/Text")]
	public Text Text;

	public dimWFHandler WarFog;

	[SceneBind("QuestButton")]
	private Button questButton;

	[SceneBind("MainImg")]
	public Image Main;

	[SceneBind("NewGlow")]
	public RectTransform NewGlow;

	[SceneBind("NewGlow/Car")]
	public RectTransform NewGlowCar;

	[SceneBind("NewGlow/Forum")]
	public RectTransform NewGlowForum;

	[SceneBind("NewGlow/Comics")]
	public RectTransform NewGlowComics;

	[SceneBind("NewGlow/Main")]
	public RectTransform NewGlowMain;

	[SceneBind("NewGlow/Startup")]
	public RectTransform NewGlowStartup;

	[SceneBind("Completed")]
	public Image Completed;

	[SceneBind("CarImg")]
	public Image Car;

	[SceneBind("ComicsImg")]
	public Image Comics;

	[SceneBind("StartupImg")]
	public Image Startup;

	[SceneBind("ForumImg")]
	public Image Forum;

	[SceneBind("Score")]
	public RectTransform Score;

	[SceneBind("StartupStates")]
	public Image StartupStates;

	[SceneBind("StartupStates/Released")]
	public Image StartupReleased;

	[SceneBind("StartupStates/End")]
	public Image StartupEnd;

	[SceneBind("StartupStates/Dev")]
	public Image StartupDev;

	[SceneBind("StartupStates/Bankrupt")]
	public Image StartupBankrupt;

	[SceneBind("TextLayer")]
	public Image TextLayer;

	[SceneBind("Score/2")]
	public Image Score2;

	[SceneBind("Score/1")]
	public Image Score1;

	[SceneBind("Score/3")]
	public Image Score3;

	[SceneBind("Score/ScoreLayer/ScoreText")]
	public Text ScoreText;

	[SceneBind("Mail")]
	public Button Mail;

	[SceneBind("LayerUnlock")]
	public Image LayerUnlock;

	[SceneBind("Checked")]
	public Image Checked;

	[SceneBind("Unchecked")]
	public Image Unchecked;

	[SceneBind("NotMainScore")]
	public RectTransform NotMainScore;

	[SceneBind("MainScore")]
	public RectTransform MainScore;

	[SceneBind("WarFog")]
	public Image WarFogClickBlock;

	public GameObject TreeChain;

	private List<Image> scores = new List<Image>();

	private List<RectTransform> glows = new List<RectTransform>();

	private List<GameObject> showGroups = new List<GameObject>();

	private GameObject LayerGroupUnlock;

	private GameObject TaskUnlockName;

	private GameObject GroupUnlockNum;

	private string[] colorsSwitchLayer = new string[2] { "DARKGREY", "SETTINGSGREY" };

	private string[] textColors = new string[2] { "GREEN", "BLUE" };

	private List<GameObject> gos = new List<GameObject>();

	private List<TreeChain> chains = new List<TreeChain>();

	public bool hidden;

	private float smallScale = 0.7f;

	public ConstructionQuest constr;

	private Vector2 defaultRect;

	private List<Image> imgs = new List<Image>();

	private BaseQuest cq;

	private Image curImg;

	private float scale;

	private bool completed;

	public void OnPointerEnter(PointerEventData eventData)
	{
		List<UnlockGroup> list = null;
		BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(base.gameObject.name);
		list = ((baseQuestByKeyName == null) ? Logic.GetStartupByKeyName(base.gameObject.name).ReqUnlockGroups : baseQuestByKeyName.ReqUnlockGroups);
		if (UnlockGroup.IsVisible(list, ActiveComponent._staticData.Settings.TreeVisibleDepth))
		{
			startHoverEvent.Invoke();
			if (!hidePopup)
			{
				hover = true;
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		endHoverEvent.Invoke();
		if (hover)
		{
			hover = false;
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		LayerGroupUnlock = Resources.Load("Prefabs/TreeNodeUnlockLayer") as GameObject;
		TaskUnlockName = Resources.Load("Prefabs/TreeNodeUnlockName") as GameObject;
		GroupUnlockNum = Resources.Load("Prefabs/TreeGroupUnlockNum") as GameObject;
		TreeChain = Resources.Load("Prefabs/TreeChain") as GameObject;
		WarFog = base.gameObject.transform.parent.parent.parent.parent.parent.GetComponent<TreeController>().WarFog;
		defaultRect = base.transform.GetComponent<RectTransform>().sizeDelta;
		smallScale = 0.7f;
		scores.Add(Score1);
		scores.Add(Score2);
		scores.Add(Score3);
		imgs.Add(Car);
		imgs.Add(Comics);
		imgs.Add(Main);
		imgs.Add(Forum);
		imgs.Add(Startup);
		glows.Add(NewGlowCar);
		glows.Add(NewGlowComics);
		glows.Add(NewGlowForum);
		glows.Add(NewGlowMain);
		glows.Add(NewGlowStartup);
	}

	public void HoverChainsToUnlock()
	{
		foreach (TreeChain chain in chains)
		{
			chain.SetHover(hoverTF: true);
		}
	}

	public void HideChainsToUnlock()
	{
		foreach (TreeChain chain in chains)
		{
			chain.SetHover(hoverTF: false);
		}
	}

	public void InitChains(BaseUnlockedData st, TreeController tree)
	{
		if (st == null || !st.VisibleToPlayer)
		{
			return;
		}
		foreach (TreeChain chain in chains)
		{
			Object.Destroy(chain.gameObject);
		}
		chains.Clear();
		tree.chains.Clear();
		foreach (UnlockGroup reqUnlockGroup in st.ReqUnlockGroups)
		{
			foreach (string questsKeyName in reqUnlockGroup.questsKeyNames)
			{
				GameObject taskGo = tree.GetTaskGo(questsKeyName);
				TreeChain component = Object.Instantiate(TreeChain).GetComponent<TreeChain>();
				component.transform.SetParent(tree.LinesContainer.transform);
				component.Init();
				component.SetEnds(base.gameObject, taskGo);
				chains.Add(component);
				tree.chains.Add(component);
			}
		}
	}

	private new void Init()
	{
		hidden = true;
		hidePopup = false;
		hover = false;
		Text.gameObject.SetActive(value: true);
	}

	public void Init(Startup st)
	{
		NewGlow.gameObject.SetActive(value: true);
		if (Car != null)
		{
			Object.Destroy(Car.gameObject);
		}
		if (Main != null)
		{
			Object.Destroy(Main.gameObject);
		}
		if (Forum != null)
		{
			Object.Destroy(Forum.gameObject);
		}
		if (Comics != null)
		{
			Object.Destroy(Comics.gameObject);
		}
		if (NewGlowCar != null)
		{
			Object.Destroy(NewGlowCar.gameObject);
		}
		if (NewGlowComics != null)
		{
			Object.Destroy(NewGlowComics.gameObject);
		}
		if (NewGlowForum != null)
		{
			Object.Destroy(NewGlowForum.gameObject);
		}
		if (NewGlowMain != null)
		{
			Object.Destroy(NewGlowMain.gameObject);
		}
		curImg = Startup;
		foreach (RectTransform glow in glows)
		{
			if (glow != null)
			{
				glow.gameObject.SetActive(value: false);
			}
		}
		StartupDev.gameObject.SetActive(value: false);
		StartupEnd.gameObject.SetActive(value: false);
		StartupBankrupt.gameObject.SetActive(value: false);
		StartupReleased.gameObject.SetActive(value: false);
		if (st == null)
		{
			NewGlow.gameObject.SetActive(value: false);
			SetDefaultState();
			return;
		}
		Init(st.KeyName, st.ReqUnlockGroups, st.TaskType, 0, st.Texts, st.Locked, st.VisibleToPlayer);
		questButton.enabled = UnlockGroup.IsUnlocked(st.ReqUnlockGroups, onlyUnlock: true);
		questButton.gameObject.GetComponent<SelectHighlighter>().enabled = questButton.enabled;
		Score.gameObject.SetActive(value: false);
		st.KeyName.GetHashCode();
		if (Mail != null)
		{
			Mail.gameObject.SetActive(ActiveComponent.Model.P.usedStartups.Contains(st.KeyName));
		}
		if (ActiveComponent.Model.P.usedStartups.Contains(st.KeyName))
		{
			NewGlow.gameObject.SetActive(value: false);
			StartupScheme startupScheme = ActiveComponent.Model.P.Startups.Find((StartupScheme st_i) => st_i.baseStartup.KeyName == st.KeyName);
			if (startupScheme != null)
			{
				if (startupScheme.released == 1)
				{
					StartupReleased.gameObject.SetActive(value: true);
					int num = (int)((float)startupScheme.baseStartup.PlayersShares * startupScheme.baseStartup.ShareSellCoef * ((float)startupScheme.baseStartup.BaseMoney / (float)(startupScheme.baseStartup.PlayersShares + startupScheme.baseStartup.SharesCou)));
					StartupReleased.color = ((num - ActiveComponent.Model.P.startupsStatsString[startupScheme.baseStartup.KeyName].enterMoney > 0) ? Logic.GetColor("GREEN") : Logic.GetColor("RED"));
				}
				else
				{
					StartupDev.gameObject.SetActive(value: true);
				}
			}
			else if (ActiveComponent.Model.P.removedStartups.Contains(st.KeyName))
			{
				StartupStat startupStat = ActiveComponent.Model.P.startupsStatsString[st.KeyName];
				if (Mail != null)
				{
					Mail.gameObject.SetActive(value: false);
				}
				if (startupStat.bankrupt)
				{
					StartupBankrupt.gameObject.SetActive(value: true);
					StartupBankrupt.color = Logic.GetColor("RED");
				}
				else
				{
					StartupEnd.gameObject.SetActive(value: true);
					StartupEnd.color = ((startupStat.exitMoney - startupStat.enterMoney > 0) ? Logic.GetColor("GREEN") : Logic.GetColor("RED"));
				}
			}
		}
		else
		{
			bool active = UnlockGroup.IsUnlocked(st.ReqUnlockGroups, onlyUnlock: true);
			NewGlow.gameObject.SetActive(active);
			NewGlowStartup.gameObject.SetActive(active);
		}
	}

	public void Init(BaseQuest cq)
	{
		Init();
		if (Completed != null)
		{
			Completed.gameObject.SetActive(value: false);
			NewGlow.gameObject.SetActive(value: true);
		}
		NewGlow.gameObject.SetActive(value: true);
		this.cq = cq;
		foreach (RectTransform glow in glows)
		{
			if (glow != null)
			{
				glow.gameObject.SetActive(value: false);
			}
		}
		bool flag = cq.Is<Comics>();
		if (flag)
		{
			flag = flag && !cq.As<Comics>().StoryComics;
		}
		if (Car != null)
		{
			Car.gameObject.SetActive(cq.Is<CarQuest>());
			NewGlowCar.gameObject.SetActive(Car.gameObject.activeSelf);
		}
		if (Main != null)
		{
			Main.gameObject.SetActive(cq.Is<ConstructionQuest>());
			NewGlowMain.gameObject.SetActive(Main.gameObject.activeSelf);
		}
		if (Forum != null)
		{
			Forum.gameObject.SetActive(cq.Is<ForumQuest>());
			NewGlowForum.gameObject.SetActive(Forum.gameObject.activeSelf);
		}
		if (Comics != null)
		{
			Comics.gameObject.SetActive(cq.Is<Comics>());
			NewGlowComics.gameObject.SetActive(Comics.gameObject.activeSelf);
		}
		if (NewGlowStartup != null)
		{
			Object.Destroy(NewGlowStartup.gameObject);
		}
		if (Car != null && !Car.gameObject.activeSelf)
		{
			Object.Destroy(NewGlowCar.gameObject);
			Object.Destroy(Car.gameObject);
		}
		if (Main != null && !Main.gameObject.activeSelf)
		{
			Object.Destroy(NewGlowMain.gameObject);
			Object.Destroy(Main.gameObject);
		}
		if (Forum != null && !Forum.gameObject.activeSelf)
		{
			Object.Destroy(NewGlowForum.gameObject);
			Object.Destroy(Forum.gameObject);
		}
		if (Comics != null && !Comics.gameObject.activeSelf)
		{
			Object.Destroy(NewGlowComics.gameObject);
			Object.Destroy(Comics.gameObject);
		}
		questButton.enabled = UnlockGroup.IsUnlocked(cq.ReqUnlockGroups, onlyUnlock: true);
		questButton.gameObject.GetComponent<SelectHighlighter>().enabled = questButton.enabled;
		if (cq.Is<Comics>())
		{
			questButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Tree-Comix-Click");
			});
		}
		else if (cq.Is<ForumQuest>())
		{
			questButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_TutorialClick");
			});
		}
		else
		{
			questButton.onClick.AddListener(delegate
			{
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			});
		}
		Startup.gameObject.SetActive(value: false);
		StartupStates.gameObject.SetActive(value: false);
		foreach (Image img in imgs)
		{
			if (img != null && img.gameObject.activeSelf)
			{
				curImg = img;
				break;
			}
		}
		if (cq == null)
		{
			SetDefaultState();
			return;
		}
		Init(cq.KeyName, cq.ReqUnlockGroups, cq.TaskType, cq.Main, cq.Texts, cq.Locked, cq.VisibleToPlayer);
		if (!cq.Is<BaseGameQuest>() && Mail != null)
		{
			Mail.gameObject.SetActive(value: false);
		}
	}

	private void SetDefaultState()
	{
		curImg.transform.GetComponent<RectTransform>();
		Text.text = Logic.ColorTransform("WARNING", TextResources.GetString("SOON"));
		WarFogClickBlock.gameObject.SetActive(value: true);
		hidePopup = true;
		Mail.gameObject.SetActive(value: false);
		Score.gameObject.SetActive(value: false);
		base.transform.GetComponent<Button>().enabled = false;
		curImg.color = Logic.GetColor("SETTINGSGREY");
		TextLayer.gameObject.SetActive(value: false);
	}

	public void Init(string KeyName, List<UnlockGroup> ReqUnlockGroups, string TaskType, int MainQ, string Texts, int Locked, bool visibleToPlayer)
	{
		if (Completed != null)
		{
			Completed.gameObject.SetActive(value: false);
			NewGlow.gameObject.SetActive(value: true);
		}
		if (ReqUnlockGroups.Count == 0)
		{
			hidePopup = true;
		}
		base.transform.GetComponent<RectTransform>();
		if (MainQ == 0)
		{
			curImg.transform.localScale = Vector3.one * smallScale;
			NewGlow.transform.localScale = Vector3.one * smallScale;
		}
		if (Locked == 1)
		{
			NewGlow.gameObject.SetActive(value: false);
			SetDefaultState();
			hidden = !UnlockGroup.IsVisible(ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth);
			WarFog.WFHandle(KeyName, hidden);
			if (!hidden && WarFogClickBlock != null)
			{
				Object.Destroy(WarFogClickBlock.gameObject);
			}
			Text.gameObject.SetActive(!hidden);
			base.gameObject.SetActive(visibleToPlayer);
			return;
		}
		hidden = !UnlockGroup.IsVisible(ReqUnlockGroups, ActiveComponent._staticData.Settings.TreeVisibleDepth, onlyUnlock: true);
		hidePopup = hidden;
		if (UnlockGroup.IsUnlocked(ReqUnlockGroups, onlyUnlock: true))
		{
			int numUnlocked = UnlockGroup.GetNumUnlocked(ReqUnlockGroups);
			hidePopup = hidePopup || numUnlocked >= ReqUnlockGroups.Count;
			curImg.color = Logic.GetColor(TaskType);
			QuestLine.Quest quest = QuestLine.GetQuest(KeyName);
			if (quest != null)
			{
				int num = QuestLine.GetQuest(KeyName).GetScore();
				if (KeyName == ActiveComponent._staticData.Comicses[0].KeyName)
				{
					num = 3;
				}
				if (quest.GetBaseQuest().Is<ForumQuest>())
				{
					num = 3;
				}
				for (int i = 0; i < scores.Count; i++)
				{
					scores[i].gameObject.SetActive(i == num - 1);
				}
				NewGlow.gameObject.SetActive(value: true);
				if (Car != null)
				{
					NewGlowCar.gameObject.SetActive(Car.gameObject.activeSelf);
				}
				if (Main != null)
				{
					NewGlowMain.gameObject.SetActive(Main.gameObject.activeSelf);
				}
				if (Forum != null)
				{
					NewGlowForum.gameObject.SetActive(Forum.gameObject.activeSelf);
				}
				if (Comics != null)
				{
					NewGlowComics.gameObject.SetActive(Comics.gameObject.activeSelf);
				}
				if (num > 0)
				{
					if (Completed != null)
					{
						bool flag = quest.IsCompleted();
						Completed.gameObject.SetActive(flag);
						NewGlow.gameObject.SetActive(!flag);
					}
				}
				else
				{
					NewGlow.gameObject.SetActive(value: true);
					Completed.gameObject.SetActive(value: false);
				}
			}
		}
		else
		{
			questButton.enabled = false;
			NewGlow.gameObject.SetActive(value: false);
			curImg.color = Logic.GetColor(TaskType) / 4f + new Color(0f, 0f, 0f) / 4f * 3f;
		}
		WarFog.WFHandle(KeyName, hidden);
		QuestLine.GetQuest(KeyName);
		BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(KeyName);
		if (!hidden)
		{
			if (baseQuestByKeyName == null)
			{
				WarFog.WFHandle(KeyName, hidden);
			}
			else if (baseQuestByKeyName.Is<ForumQuest>())
			{
				WarFog.WFHandle(baseQuestByKeyName.As<ForumQuest>().QuestKeyName, hidden);
			}
		}
		if (!hidden && WarFogClickBlock != null)
		{
			Object.Destroy(WarFogClickBlock.gameObject);
		}
		bool flag2 = baseQuestByKeyName != null && !baseQuestByKeyName.Is<Comics>();
		Text.gameObject.SetActive(!hidden && flag2);
		TextLayer.gameObject.SetActive(Text.gameObject.activeSelf);
		Text.text = Logic.ColorTransform("vadimText", TextResources.GetString(Texts + "SHORTT"));
		QuestLine.Quest quest2 = QuestLine.GetQuest(KeyName);
		if (Mail != null)
		{
			Mail.gameObject.SetActive(quest2 != null && QuestLine.IsLoadedInMemory(quest2.GetName()) && quest2.IsTaskOpened() && !hidden && UnlockGroup.IsUnlocked(quest2.GetBaseQuest().ReqUnlockGroups) && !quest2.IsCompleted());
		}
		Score.gameObject.SetActive(quest2 != null && quest2.IsCompleted() && !hidden);
		Score.gameObject.transform.localScale = Vector3.one;
		if (MainQ == 1)
		{
			Score.gameObject.transform.localScale = Vector3.one * 1.3f;
			Score.gameObject.transform.localPosition = MainScore.transform.localPosition;
		}
		else
		{
			Score.gameObject.transform.localPosition = NotMainScore.transform.localPosition;
		}
		_ = hidden;
		completed = ActiveComponent.Model.curPreview.IsQuestDone(KeyName);
	}

	public void InitFake(ConstructionQuest cq)
	{
		curImg = Main;
		foreach (RectTransform glow in glows)
		{
			glow.gameObject.SetActive(value: false);
		}
		NewGlowMain.gameObject.SetActive(value: true);
		Car.gameObject.SetActive(value: false);
		Startup.gameObject.SetActive(value: false);
		SetDefaultState();
		hidden = true;
		Text.gameObject.SetActive(value: false);
		curImg.color = Logic.GetColor(cq.TaskType);
		WarFogClickBlock.gameObject.SetActive(value: false);
		base.transform.GetComponent<Button>().enabled = false;
		Mail.gameObject.SetActive(value: false);
		Score.gameObject.SetActive(value: false);
		Comics.gameObject.SetActive(value: false);
		Forum.gameObject.SetActive(value: false);
		TextLayer.gameObject.SetActive(value: false);
		StartupStates.gameObject.SetActive(value: false);
		if (cq.Main == 0)
		{
			curImg.transform.localScale = Vector3.one * smallScale;
			NewGlow.transform.localScale = Vector3.one * smallScale;
		}
	}
}

using System.Collections.Generic;
using App.Data;

public class PersistentData
{
	public int saveId;

	public string unityVersion = "";

	public bool treeBtnTutorial;

	public bool hideZIP;

	public int medalTutorial;

	public int lastEpochReachedTutorial;

	public bool hideDragTooMany;

	public bool evolveBtnTutorial;

	public HashSet<int> thunderTramborine = new HashSet<int>();

	public Dictionary<string, int> activeInterierItem = new Dictionary<string, int>();

	public Dictionary<string, int> boughtShopItem = new Dictionary<string, int>();

	public int lastOpenSandbox;

	public int shopTutorial;

	public int hideCompletedMailsTasks;

	public int hideOldStartups;

	public int customTurorialGeneticWindow;

	public int hideOldPrivates;

	public int catHubTutorial;

	public int timeTutorial;

	public int startupTrainTutorial;

	public int dropDownTutorial;

	public int errorTutorial;

	public int serversTutorial;

	public int maintainAccLevelTutorial;

	public int memoryRNNTutorial;

	public int occAndAccTutorial;

	public int speedTutorial;

	public int copyTutorial;

	public int sandboxTutorial;

	public int sandboxTrainableTutorial;

	public int elemHierTutorial;

	public int lidarsSchemeTutorial;

	public int mutationRateTutorial;

	public int modelParamsTutorial;

	public int meetTheMLtutorial;

	public int firstCarTeachTutorial;

	public int DLLTutorial;

	public int geneticPopulationTutorial;

	public int crossoverTutorial;

	public int mutationTutorial;

	public bool infotutorial;

	public int lidarTutorial;

	public int firstNonForumQuestTutorial;

	public int wasWin;

	public int hideAttentionJoinStartup;

	public int startupTutorial;

	public QuestLine.Quest ShowFastMailTask;

	public List<Credit> credits = new List<Credit>();

	public int creditDepth;

	public Dictionary<string, int> watchedShop = new Dictionary<string, int>();

	public int HideAttentionBuy;

	public int basicsTutorial;

	public int HideClearAll;

	public int startupConstructionTutorial;

	public int startupComicsTutorial;

	public int startupBadHypeTutorial;

	public int redUsersTurorial;

	public int redUsersTurorial0;

	public int startupWeekTutorial;

	public int daysTutorial;

	public List<string> daysStartTask = new List<string>();

	public List<string> usedStartups = new List<string>();

	public List<string> removedStartups = new List<string>();

	public Dictionary<int, StartupStat> startupsStats = new Dictionary<int, StartupStat>();

	public Dictionary<string, StartupStat> startupsStatsString = new Dictionary<string, StartupStat>();

	public int HideBankrupt;

	public int hideDeleteStartup;

	public int hideCancelStartup;

	public int Days;

	public int Weeks;

	public int ActionPoints;

	public long Servers;

	public long Views;

	public long Money;

	public int curCat;

	public UpgradeStats upgradeStats;

	public float rememberedSpeed;

	public List<UpgradeStats> unlockedUpgrades = new List<UpgradeStats>();

	public List<CatVR> unlockedCatHats = new List<CatVR>();

	public List<Startup> startupsPrevVers = new List<Startup>();

	public List<string> startupsWasCreated = new List<string>();

	public int passedFirstQuest;

	public int showCustom;

	public string version = "";

	public MoneyLetter curLetter;

	public List<MoneyLetter> moneyLetters = new List<MoneyLetter>();

	public List<Startup> startupQueue = new List<Startup>();

	public List<string> wasMoneyLetters = new List<string>();

	public List<string> taskQueue = new List<string>();

	public Unit playerUnit;

	public int curLoadQuest;

	public int hideBought;

	public int hideLockedShop;

	public int hideAttentiondeploy;

	public int hideAttentionStartup;

	public int hideAttentionDay;

	public int maxConstructionQuest;

	public int learnedAlgos;

	public int lastGainStartup;

	public List<StartupScheme> Startups = new List<StartupScheme>();

	public List<string> extraUnlockedAlgos = new List<string>();

	public Dictionary<string, SandboxScheme> sandboxSchemes;

	public Dictionary<string, int> watchBlockTutorials = new Dictionary<string, int>();

	public bool dontShowRefreshAgentAttention;

	public bool computerBuildingTutorialCompleted;

	public bool firstTreeTutorialCompleted;

	public bool comicsTutorialCompleted;

	public HashSet<string> completedComicses = new HashSet<string>();
}

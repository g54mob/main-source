using Dorfromantik;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneInitializer : MonoBehaviour
{
	[SerializeField]
	private ElementGroupManager elementGroupManager;

	[SerializeField]
	private int fakeQuestAmount;

	[SerializeField]
	private Vector2 focusPos2D;

	[SerializeField]
	private bool randomizeBiomes;

	[SerializeField]
	private World world;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private BiomeSectionManager biomeSectionManager;

	[SerializeField]
	private PreplacedTileSectionManager preplacedTilesSectionManager;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private CustomModeConfiguration customModeConfiguration;

	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private TileGenConfiguration defaultTileGenConfiguration;

	[SerializeField]
	private RewardSystemConfiguration defaultRewardSystemConfiguration;

	[SerializeField]
	private QuestSystemConfiguration defaultQuestSystemConfiguration;

	public TileGenConfiguration DefaultTileGenConfiguration => defaultTileGenConfiguration;

	public QuestSystemConfiguration DefaultQuestSystemConfiguration => defaultQuestSystemConfiguration;

	protected void Awake()
	{
		settingsRouter.SetupEventBroadcasters();
		rewardSystem.ResetLevelAndScore();
		rewardSystem.SetConfiguration(defaultRewardSystemConfiguration);
		questManager.Reset(elementGroupManager);
		questManager.SetConfiguration(defaultQuestSystemConfiguration);
		if (OverwritingSingleton<GameSession>.Instance.GameMode.id == GameModeId.Creative)
		{
			biomeSectionManager.SetupAvailableBiomes();
		}
		else
		{
			biomeSectionManager.SetupAvailableBiomesFromPlayerPrefs();
		}
		biomeSectionManager.SetupSections(world.transform, randomizeBiomes);
		inputRouter.SetInteractionRestriction(new InteractionRestriction());
		inputRouter.SwitchToTool(ToolId.None);
		tileGenerator.SetConfiguration(defaultTileGenConfiguration);
		tileGenerator.Setup();
		vfxManager.Setup();
		for (int i = 0; i < fakeQuestAmount; i++)
		{
			questManager.AddQuest(null);
		}
		if (Singleton<MainMenuUi>.Instance == null)
		{
			sceneLoader.LoadScene("MainMenu", LoadSceneMode.Additive);
		}
	}

	private void Start()
	{
		PlayerPrefsAccessor.SetInt("TutorialStartPhase", -1);
		if (!OverwritingSingleton<GameSession>.Instance.GameMode.IsTutorial)
		{
			PlayerPrefsAccessor.SetInt("TutorialPlayed", 1);
		}
	}

	protected void OnDestroy()
	{
		biomeSectionManager.Clear();
		preplacedTilesSectionManager.Clear();
		questManager.Reset(null);
	}
}

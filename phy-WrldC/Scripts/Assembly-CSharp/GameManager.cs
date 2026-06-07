using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UltimateReplay;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum GameModeState
	{
		None = 0,
		Attacker = 1,
		Defender = 2
	}

	public enum LevelTypeState
	{
		None = 0,
		Campaign = 1,
		Sandbox = 2,
		Tutorial = 3,
		Defender = 4,
		User = 5,
		Workshop = 6,
		Test = 7
	}

	public enum WhereIsPlaceholderCreationEnum
	{
		QuickInventory = 0,
		Clipboard = 1
	}

	private FiniteStateMachine<GameManager> FSM;

	[SerializeField]
	private StartupGame startupGame;

	[SerializeField]
	private GameStylesData gameStylesData;

	[SerializeField]
	private ContentHashData contentHashData;

	[SerializeField]
	private RestrictedBlocksData restrictedBlocksData;

	public GameObject mainCameraObject;

	public GameObject blockViewCameraObject;

	public TextLevelList mainCampaignLevels;

	public TextLevelList sandboxCampaignLevels;

	public CreationThumbnailGenerator creationThumbnailGenerator;

	[Header("Folders")]
	public GameObject attackerCreationFolder;

	public GameObject defenderCreationFolder;

	public GameObject effectsFolder;

	public GameObject blockVisualizationFolder;

	[Header("Connectors")]
	public GameObject connectorGridPrefab;

	public GameObject connectorColliderPrefab;

	public GameObject connectorFixedPrefab;

	public GameObject connectorHingePrefab;

	[Header("Lines")]
	public GameObject multiConnectionsLinePrefab;

	public GameObject hingeEditorLinePrefab;

	public GameObject rulerPrefab;

	[Header("Buttons 3D")]
	public GameObject hingeJointButtonPrefab;

	public GameObject allJointsButtonPrefab;

	[Header("Audio Mixers")]
	[SerializeField]
	private AudioMixer masterAudioMixer;

	[SerializeField]
	private AudioMixer musicAudioMixer;

	[SerializeField]
	private AudioMixer effectsAudioMixer;

	[Header("Other Prefabs")]
	public GameObject transformGizmo3DPrefab;

	public GameObject blockShadowPrefab;

	public GameObject massCenterObject;

	[Header("Recyclable UI Prefabs")]
	public GameObject quickKeysGroupPrefab;

	public GameObject quickKeySlotPrefab;

	[Header("Cursors")]
	[SerializeField]
	private Texture2D loadingCursor;

	private State<GameManager> newStateAfterLevelLoad;

	private State<GameManager> newStateAfterLevelEditorLoad;

	public static GameManager Instance => Singleton<GameManager>.Instance;

	public static bool Exist => Singleton<GameManager>.Exist;

	public SchematicCollection SchematicCollection { get; private set; }

	public MaterialSchematicCollection MaterialSchematicCollection { get; private set; }

	public CreationCollectionsManager CreationCollectionsManager { get; private set; }

	public LevelPartCollectionsManager LevelPartCollectionsManager { get; private set; }

	public InventoryStatusModel InventoryStatusModel { get; set; }

	public QuickInventoryModel MainQuickInventoryModel { get; set; }

	public QuickInventoryModel DefaultQuickInventoryModel { get; set; }

	public ClipboardModel ClipboardModel { get; private set; }

	public CategoriesModel CategoriesModel { get; set; }

	public SavedCreationsModel SavedCreationsModel { get; private set; }

	public LEQuickInventoryModel LEQuickInventoryModel { get; set; }

	public LEQuickInventoryModel DefaultLEQuickInventoryModel { get; set; }

	public LECategoriesModel LECategoriesModel { get; set; }

	public LEClipboardModel LEClipboardModel { get; private set; }

	public LevelEditorToolsModel LevelEditorToolsModel { get; private set; }

	public QuickInventoryController QuickInventoryController => GUIManager.QuickInventoryController;

	public UserProfileModel UserProfileModel { get; set; }

	public OptionsModel OptionsModel { get; set; }

	public LEOptionsModel LEOptionsModel { get; set; }

	public WorkshopTrendsModel WorkshopTrendsModel { get; private set; }

	public GenericCollectionModel<LevelModel> CampaignLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> SandboxLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> TutorialLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> TemplateLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> DefenderLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> UserAndWorkshopLevelModelCollection { get; private set; }

	public GenericCollectionModel<LevelModel> SandboxCampaignModel { get; private set; }

	public LinearCampaignModel TutorialCampaignModel { get; private set; }

	public LinearCampaignModel CampaignStructureModel { get; private set; }

	public GroupCampaignModel GroupCampaignModel { get; private set; }

	public Properties InvalidSchematicHashes { get; private set; }

	public Properties InvalidLevelModelHashes { get; private set; }

	public bool IsInvalidSchOrMatPropertiesHashes { get; set; }

	public StartupGame StartupGame => startupGame;

	public GameStylesData GameStylesData => gameStylesData;

	public ContentHashData ContentHashData => contentHashData;

	public RestrictedBlocksData RestrictedBlocksData => restrictedBlocksData;

	public AudioMixer MasterAudioMixer => masterAudioMixer;

	public AudioMixer MusicAudioMixer => musicAudioMixer;

	public AudioMixer EffectsAudioMixer => effectsAudioMixer;

	public Texture2D LoadingCursor => loadingCursor;

	public GameModeState GameMode { get; set; }

	public LevelTypeState LevelType { get; set; }

	public GUIManager GUIManager { get; private set; }

	public MainCreationsManager MainCreationsManager { get; private set; }

	public LevelManager LevelManager { get; private set; }

	public LevelEditorManager LevelEditorManager { get; private set; }

	public CameraManager CameraManager { get; private set; }

	public LanguagesManager LanguagesManager { get; private set; }

	public UIAudioEffectsManager UIAudioEffectsManager { get; private set; }

	public AudioEffectsManager AudioEffectsManager { get; private set; }

	public VisualEffectsManager VisualEffectsManager { get; private set; }

	public MusicManager MusicManager { get; private set; }

	public TutorialManager TutorialManager { get; private set; }

	public ObjectPools ObjectPools { get; private set; }

	public CreationController MainCreationController => MainCreationsManager.MainCreationController;

	public CreationController AttackerCreationController => MainCreationsManager.AttackerCreationController;

	public CreationController DefenderCreationController => MainCreationsManager.DefenderCreationController;

	public LevelController LevelController { get; private set; }

	public ConstructionToolsModel ConstructionToolsModel { get; set; }

	public ConstructionCommandsModel ConstructionCommandManager { get; private set; }

	public CreationModel SelectedCreationModel { get; set; }

	public CreationModel ToSaveCreationModel { get; set; }

	public LevelModel CurrentCustomLevelModel { get; set; }

	public SpriteCollection LevelThumbnailCollection { get; private set; }

	public SpriteCollection UserAndWorkshopLevelThumbnailCollection { get; private set; }

	public TextureCollection FlagTextureCollection { get; private set; }

	public WhereIsPlaceholderCreationEnum WhereIsPlaceholderCreation { get; set; }

	public CheatModel CheatModel { get; private set; }

	public event Action UpdateAuxiliary;

	protected void Awake()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		ReplayManager.ForceAwake();
		ReplayManager.Preparer = new CustomReplayPreparer();
		GameMode = GameModeState.None;
		LevelType = LevelTypeState.None;
		GUIManager = GUIManager.Instance;
		IsInvalidSchOrMatPropertiesHashes = false;
		SchematicCollection = new SchematicCollection();
		MaterialSchematicCollection = new MaterialSchematicCollection();
		CreationCollectionsManager = new CreationCollectionsManager();
		LevelPartCollectionsManager = new LevelPartCollectionsManager();
		CampaignLevelModelCollection = new GenericCollectionModel<LevelModel>();
		SandboxLevelModelCollection = new GenericCollectionModel<LevelModel>();
		TutorialLevelModelCollection = new GenericCollectionModel<LevelModel>();
		TemplateLevelModelCollection = new GenericCollectionModel<LevelModel>();
		DefenderLevelModelCollection = new GenericCollectionModel<LevelModel>();
		UserAndWorkshopLevelModelCollection = new GenericCollectionModel<LevelModel>();
		SandboxCampaignModel = new GenericCollectionModel<LevelModel>();
		TutorialCampaignModel = new LinearCampaignModel();
		CampaignStructureModel = new LinearCampaignModel();
		GroupCampaignModel = new GroupCampaignModel();
		InvalidSchematicHashes = new Properties();
		InvalidLevelModelHashes = new Properties();
		SavedCreationsModel = new SavedCreationsModel();
		LevelController = new LevelController(null, null);
		CameraManager = new CameraManager(mainCameraObject, blockViewCameraObject);
		LanguagesManager = LanguagesManager.Instance;
		ConstructionCommandManager = new ConstructionCommandsModel();
		ConstructionToolsModel = new ConstructionToolsModel(ConstructionCommandManager);
		MainCreationsManager = new MainCreationsManager(this);
		ClipboardModel = new ClipboardModel();
		LEClipboardModel = new LEClipboardModel();
		LevelEditorToolsModel = new LevelEditorToolsModel();
		LevelThumbnailCollection = new SpriteCollection();
		UserAndWorkshopLevelThumbnailCollection = new SpriteCollection();
		FlagTextureCollection = new TextureCollection();
		WorkshopTrendsModel = new WorkshopTrendsModel();
		UIAudioEffectsManager = UIAudioEffectsManager.Instance;
		AudioEffectsManager = AudioEffectsManager.Instance;
		VisualEffectsManager = VisualEffectsManager.Instance;
		MusicManager = MusicManager.Instance;
		TutorialManager = TutorialManager.Instance;
		ObjectPools = ObjectPools.Instance;
		WhereIsPlaceholderCreation = WhereIsPlaceholderCreationEnum.QuickInventory;
		CheatModel = new CheatModel();
		SceneManager.sceneLoaded += OnLevelLoaded;
		SceneManager.sceneLoaded += OnLevelEditorLoaded;
		SceneManager.sceneUnloaded += OnLevelEditorUnloaded;
		Application.quitting += OnQuittingGame;
		FSM = new FiniteStateMachine<GameManager>(this, LoadingState.Instance);
		FSM.Update();
	}

	public void Update()
	{
		FSM.Update();
		this.UpdateAuxiliary?.Invoke();
	}

	public void ChangeState(State<GameManager> newState, bool shouldRunExit, bool shouldRunEnter = true)
	{
		try
		{
			FSM.ChangeState(newState, shouldRunExit, shouldRunEnter);
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public void ChangeState(State<GameManager> newState)
	{
		try
		{
			FSM.ChangeState(newState);
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public void RevertToPreviousState(bool shouldRunExit, bool shouldRunEnter = true)
	{
		try
		{
			FSM.RevertToPreviousState(shouldRunExit, shouldRunEnter);
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public void RevertToPreviousState()
	{
		try
		{
			FSM.RevertToPreviousState();
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public State<GameManager> GetCurrentState()
	{
		return FSM.GetCurrentState();
	}

	public State<GameManager> GetPreviousState()
	{
		return FSM.GetPreviousState();
	}

	public void SetSubState(State<GameManager> newSubState)
	{
		try
		{
			FSM.SetSubState(newSubState);
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public void ExitSubState()
	{
		FSM.ExitSubState();
	}

	public void ExitAllSubStates()
	{
		FSM.ExitAllSubStates();
	}

	public State<GameManager> GetCurrentSubState()
	{
		return FSM.GetCurrentSubState();
	}

	public void AddListenerOnStateChanged(Action<State<GameManager>> listenerHandler)
	{
		FSM.OnStateChanged += listenerHandler;
	}

	public void AddActionOnTransitionBetweenStates(State<GameManager>[] previousStates, State<GameManager>[] nextStates, Action action)
	{
		FSM.AddActionOnTransitionBetweenStates(previousStates, nextStates, action);
	}

	public void AddActionOnTransitionBetweenStates(State<GameManager> previousState, State<GameManager>[] nextStates, Action action)
	{
		FSM.AddActionOnTransitionBetweenStates(previousState, nextStates, action);
	}

	public void AddActionOnTransitionBetweenStates(State<GameManager>[] previousStates, State<GameManager> nextState, Action action)
	{
		FSM.AddActionOnTransitionBetweenStates(previousStates, nextState, action);
	}

	public void AddActionOnTransitionBetweenStates(State<GameManager> previousState, State<GameManager> nextState, Action action)
	{
		FSM.AddActionOnTransitionBetweenStates(previousState, nextState, action);
	}

	public void PlayLevel()
	{
		if (MainCreationController.model.BrainBlockModel == null)
		{
			string text = LanguagesManager.Instance.GetText("warning.text.play.companion", "Can't play without the companion block!");
			GUIManager.WarningTooltipPanel.ShowWarningText(text, -20f, 0f, WarningTooltipPanel.FloatDirection.Down);
		}
		else if (LevelManager.IsAnyBlockBodyOutside(MainCreationController.view))
		{
			string text2 = LanguagesManager.Instance.GetText("warning.text.play.outside", "Can't play with blocks outside the delimitation zone!");
			GUIManager.WarningTooltipPanel.ShowWarningText(text2, -20f, 0f, WarningTooltipPanel.FloatDirection.Down);
		}
		else if (LevelManager.IsUsingRestrictedBlocks(MainCreationController.model))
		{
			string text3 = LanguagesManager.Instance.GetText("message.header.play.restricted");
			string text4 = LanguagesManager.Instance.GetText("message.info.play.restricted");
			GUIManager.ShowMessageBox(text3, text4, delegate
			{
				ChangeState(ActionState.Instance);
			});
		}
		else
		{
			ChangeState(ActionState.Instance);
		}
	}

	public void ResetLevel()
	{
		RestoresCreationsAndLevel();
		ChangeState(ResetLevelState.Instance);
	}

	public void ResetCameraPosition()
	{
		CameraManager.OrbitCamera.SetTargetPosition(LevelManager.Instance.SelectedZone.transform.position);
		CameraManager.OrbitCamera.SetAngles(25f, 45f);
		CameraManager.OrbitCamera.SetZoomDistance(-12f);
	}

	public void RestoresCreationsAndLevel()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		CameraManager.SaveMainCameraStatus(MainCreationController.model);
		CameraManager.RestoresMainCamera();
		MainCreationsManager.RestoreLastCameraPositionForNextBuilding(shouldRestoresWorldPosition: true);
		if (GameMode == GameModeState.Attacker)
		{
			AttackerCreationController.RebuildView();
		}
		DefenderCreationController.RebuildView();
		LevelManager.RestoresDynamicObjects();
		LevelManager.RestoresCollectables();
		Debug.Log(Time.realtimeSinceStartup - realtimeSinceStartup);
	}

	public void ClearMainCreation()
	{
		ConstructionCommandManager.ExecuteNewCommand(new ClearCreationCommand(MainCreationController));
	}

	public void ClearAllCreations()
	{
		AttackerCreationController.SetModel(new CreationModel("", "", ""));
		DefenderCreationController.SetModel(new CreationModel("", "", ""));
	}

	public CreationModel GetSelectedPlaceholderCreation()
	{
		if (WhereIsPlaceholderCreation == WhereIsPlaceholderCreationEnum.QuickInventory)
		{
			return QuickInventoryController.model.GetSelectedItem();
		}
		return ClipboardModel.GetItemModel();
	}

	public void UnloadCurrentLevel()
	{
		LevelManager.BeforeUnloadLevel();
		SceneManager.UnloadSceneAsync(LevelManager.gameObject.scene.name);
	}

	public void LoadLevelAndChangeState(LevelModel levelModel, State<GameManager> newState)
	{
		LevelController.SetView(null);
		LevelController.SetModel(levelModel);
		string sceneName = levelModel.SceneName;
		newStateAfterLevelLoad = newState;
		if (SceneManager.GetSceneByName(sceneName).isLoaded)
		{
			LevelManager = LevelManager.Instance;
			LevelManager.Initialize();
			ChangeState(newStateAfterLevelLoad);
		}
		else
		{
			SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
		}
	}

	private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
	{
		if (LevelController.model != null && !(LevelController.model.SceneName != scene.name))
		{
			LevelManager = LevelManager.Instance;
			LevelManager.Initialize();
			if (newStateAfterLevelLoad != null)
			{
				ChangeState(newStateAfterLevelLoad);
				newStateAfterLevelLoad = null;
			}
			GUIManager.FadeOutFromBlack();
		}
	}

	public void UnloadLevelEditor()
	{
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("Gameplay"));
		SceneManager.UnloadSceneAsync("LevelEditor");
	}

	private void OnLevelEditorUnloaded(Scene scene)
	{
		if (!(scene.name != "LevelEditor"))
		{
			CameraManager.OrbitCamera.gameObject.SetActive(value: true);
		}
	}

	public void LoadLevelEditorAndChangeState(State<GameManager> newState)
	{
		newStateAfterLevelEditorLoad = newState;
		SceneManager.LoadScene("LevelEditor", LoadSceneMode.Additive);
	}

	private void OnLevelEditorLoaded(Scene scene, LoadSceneMode mode)
	{
		if (!(scene.name != "LevelEditor"))
		{
			SceneManager.SetActiveScene(scene);
			LevelEditorManager = LevelEditorManager.Instance;
			if (newStateAfterLevelEditorLoad != null)
			{
				ChangeState(newStateAfterLevelEditorLoad);
				newStateAfterLevelEditorLoad = null;
			}
			GUIManager.FadeOutFromBlack();
		}
	}

	private void OnQuittingGame()
	{
		SceneManager.UnloadSceneAsync("MainMenu");
		SceneManager.UnloadSceneAsync("Gameplay");
	}

	public Schematic[] GetRestrictedBlocksSchematics(LevelModel.RestrictedBlocks restrictedBlocks)
	{
		string[] restrictedBlocks2 = RestrictedBlocksData.GetRestrictedBlocks(restrictedBlocks);
		if (restrictedBlocks2 != null && restrictedBlocks2.Length != 0)
		{
			List<Schematic> list = new List<Schematic>();
			for (int i = 0; i < restrictedBlocks2.Length; i++)
			{
				Schematic schematic = SchematicCollection.GetSchematic(restrictedBlocks2[i]);
				if (schematic != null)
				{
					list.Add(schematic);
				}
			}
			return list.ToArray();
		}
		return null;
	}
}

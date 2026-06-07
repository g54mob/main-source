using System;
using System.Collections;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
	[SerializeField]
	private Camera uiCamera;

	[SerializeField]
	private GameObject tooltipsCanvasObject;

	[SerializeField]
	private GameObject normalTooltipPanelObject;

	[SerializeField]
	private GameObject warningTooltipPanelObject;

	[SerializeField]
	private GameObject blockTooltipPanelObject;

	[SerializeField]
	private GameObject levelObjectTooltipPanelObject;

	[SerializeField]
	private GameObject descriptionTooltipPanelObject;

	[SerializeField]
	private GameObject blockModelTooltipPanelObject;

	[SerializeField]
	private Canvas disableMouseCanvas;

	private MessageBoxModel defaultMessageBoxModel;

	public static GUIManager Instance => Singleton<GUIManager>.Instance;

	public static bool Exist => Singleton<GUIManager>.Exist;

	public Camera UICamera => uiCamera;

	public bool IsScreenFadedToBlack { get; private set; }

	public NormalTooltipPanel NormalTooltipPanel { get; private set; }

	public WarningTooltipPanel WarningTooltipPanel { get; private set; }

	public BlockTooltipPanel BlockTooltipPanel { get; private set; }

	public LevelObjectTooltipPanel LevelObjectTooltipPanel { get; private set; }

	public DescriptionTooltipPanel DescriptionTooltipPanel { get; private set; }

	public BlockModelTooltipPanel BlockModelTooltipPanel { get; private set; }

	public QuickInventoryView QuickInventoryView { get; private set; }

	public InventoryView InventoryView { get; private set; }

	public ClipboardView ClipboardView { get; private set; }

	public TopButtonsView TopButtonsView { get; private set; }

	public SaveAttackerCreationView SaveAttackerCreationView { get; private set; }

	public LoadCreationView LoadCreationView { get; private set; }

	public CreationWorkshopView CreationWorkshopView { get; private set; }

	public LevelStatisticsView LevelStatisticsView { get; private set; }

	public LeaderboardsWindowView LeaderboardsWindowView { get; private set; }

	public BestPlayersView BestPlayersView { get; private set; }

	public HingeEditorView HingeEditorView { get; private set; }

	public ComponentPropertiesView ComponentPropertiesView { get; private set; }

	public JointEditorView JointEditorView { get; private set; }

	public MainMenuView MainMenuView { get; private set; }

	public GroupCampaignView GroupCampaignView { get; private set; }

	public LogicEditorView LogicEditorView { get; private set; }

	public LevelCompletedView LevelCompletedView { get; private set; }

	public MessageBoxView MessageBoxView { get; private set; }

	public SaveDefenderCreationView SaveDefenderCreationView { get; private set; }

	public BlockVisualizationView BlockVisualizationView { get; private set; }

	public LevelPreviewView LevelPreviewView { get; private set; }

	public ActionModeView ActionModeView { get; private set; }

	public PauseView PauseView { get; private set; }

	public ReplayView ReplayView { get; private set; }

	public OptionsView OptionsView { get; private set; }

	public ManualView ManualView { get; private set; }

	public StepByStepView StepByStepView { get; private set; }

	public FadeInAndOutView FadeInAndOutView { get; private set; }

	public LETopButtonsView LETopButtonsView { get; private set; }

	public LEQuickInventoryView LEQuickInventoryView { get; private set; }

	public LEInventoryView LEInventoryView { get; private set; }

	public LEClipboardView LEClipboardView { get; private set; }

	public LEPropertiesView LEPropertiesView { get; private set; }

	public InspectorView InspectorView { get; private set; }

	public SaveLevelView SaveLevelView { get; private set; }

	public LoadLevelView LoadLevelView { get; private set; }

	public UserLevelWorkshopView UserLevelWorkshopView { get; private set; }

	public SaveLevelPartView SaveLevelPartView { get; private set; }

	public LEManualView LEManualView { get; private set; }

	public QuickInventoryController QuickInventoryController { get; private set; }

	public InventoryController InventoryController { get; private set; }

	public ClipboardController ClipboardController { get; private set; }

	public TopButtonsController TopButtonsController { get; private set; }

	public SaveAttackerCreationController SaveAttackerCreationController { get; private set; }

	public LoadCreationController LoadCreationController { get; private set; }

	public CreationWorkshopController CreationWorkshopController { get; private set; }

	public LevelStatisticsController LevelStatisticsController { get; private set; }

	public LeaderboardsWindowController LeaderboardsWindowController { get; private set; }

	public BestPlayersController BestPlayersController { get; private set; }

	public HingeEditorController HingeEditorController { get; private set; }

	public ComponentPropertiesController ComponentPropertiesController { get; private set; }

	public JointEditorController JointEditorController { get; private set; }

	public MainMenuController MainMenuController { get; private set; }

	public GroupCampaignController GroupCampaignController { get; private set; }

	public LogicEditorController LogicEditorController { get; private set; }

	public LevelCompletedController LevelCompletedController { get; private set; }

	public MessageBoxController MessageBoxController { get; private set; }

	public SaveDefenderCreationController SaveDefenderCreationController { get; private set; }

	public BlockVisualizationController BlockVisualizationController { get; private set; }

	public ActionModeController ActionModeController { get; private set; }

	public PauseController PauseController { get; private set; }

	public ReplayController ReplayController { get; private set; }

	public OptionsController OptionsController { get; private set; }

	public ManualController ManualController { get; private set; }

	public StepByStepController StepByStepController { get; private set; }

	public LETopButtonsController LETopButtonsController { get; private set; }

	public LEQuickInventoryController LEQuickInventoryController { get; private set; }

	public LEInventoryController LEInventoryController { get; private set; }

	public LEClipboardController LEClipboardController { get; private set; }

	public LEPropertiesController LEPropertiesController { get; private set; }

	public InspectorController InspectorController { get; private set; }

	public SaveLevelController SaveLevelController { get; private set; }

	public LoadLevelController LoadLevelController { get; private set; }

	public UserLevelWorkshopController UserLevelWorkshopController { get; private set; }

	public SaveLevelPartController SaveLevelPartController { get; private set; }

	public LEManualController LEManualController { get; private set; }

	public IEnumerator Initialize(GameManager GAME)
	{
		QuickInventoryView = GetComponent<QuickInventoryView>();
		InventoryView = GetComponent<InventoryView>();
		ClipboardView = GetComponent<ClipboardView>();
		TopButtonsView = GetComponent<TopButtonsView>();
		SaveAttackerCreationView = GetComponent<SaveAttackerCreationView>();
		LoadCreationView = GetComponent<LoadCreationView>();
		CreationWorkshopView = GetComponent<CreationWorkshopView>();
		LevelStatisticsView = GetComponent<LevelStatisticsView>();
		LeaderboardsWindowView = GetComponent<LeaderboardsWindowView>();
		BestPlayersView = GetComponent<BestPlayersView>();
		HingeEditorView = GetComponent<HingeEditorView>();
		ComponentPropertiesView = GetComponent<ComponentPropertiesView>();
		JointEditorView = GetComponent<JointEditorView>();
		MainMenuView = GetComponent<MainMenuView>();
		GroupCampaignView = GetComponent<GroupCampaignView>();
		LogicEditorView = GetComponent<LogicEditorView>();
		LevelCompletedView = GetComponent<LevelCompletedView>();
		MessageBoxView = GetComponent<MessageBoxView>();
		SaveDefenderCreationView = GetComponent<SaveDefenderCreationView>();
		BlockVisualizationView = GetComponent<BlockVisualizationView>();
		LevelPreviewView = GetComponent<LevelPreviewView>();
		ActionModeView = GetComponent<ActionModeView>();
		PauseView = GetComponent<PauseView>();
		ReplayView = GetComponent<ReplayView>();
		OptionsView = GetComponent<OptionsView>();
		ManualView = GetComponent<ManualView>();
		StepByStepView = GetComponent<StepByStepView>();
		FadeInAndOutView = GetComponent<FadeInAndOutView>();
		LETopButtonsView = GetComponent<LETopButtonsView>();
		LEQuickInventoryView = GetComponent<LEQuickInventoryView>();
		LEInventoryView = GetComponent<LEInventoryView>();
		LEClipboardView = GetComponent<LEClipboardView>();
		LEPropertiesView = GetComponent<LEPropertiesView>();
		InspectorView = GetComponent<InspectorView>();
		SaveLevelView = GetComponent<SaveLevelView>();
		LoadLevelView = GetComponent<LoadLevelView>();
		UserLevelWorkshopView = GetComponent<UserLevelWorkshopView>();
		SaveLevelPartView = GetComponent<SaveLevelPartView>();
		LEManualView = GetComponent<LEManualView>();
		BaseGUIView[] components = GetComponents<BaseGUIView>();
		BaseGUIView[] array = components;
		foreach (BaseGUIView obj in array)
		{
			obj.ParentCanvas.gameObject.SetActive(value: true);
			obj.Initialize();
		}
		QuickInventoryController = new QuickInventoryController(QuickInventoryView, GAME.MainQuickInventoryModel);
		InventoryController = new InventoryController(InventoryView, GAME.CategoriesModel);
		ClipboardController = new ClipboardController(ClipboardView, GAME.ClipboardModel, QuickInventoryView.SlotToggleGroup);
		TopButtonsController = new TopButtonsController(TopButtonsView);
		SaveAttackerCreationController = new SaveAttackerCreationController(SaveAttackerCreationView);
		LoadCreationController = new LoadCreationController(LoadCreationView, GAME.SavedCreationsModel);
		CreationWorkshopController = new CreationWorkshopController(CreationWorkshopView);
		LevelStatisticsController = new LevelStatisticsController(LevelStatisticsView, null);
		LeaderboardsWindowController = new LeaderboardsWindowController(LeaderboardsWindowView, null);
		BestPlayersController = new BestPlayersController(BestPlayersView);
		HingeEditorController = new HingeEditorController(HingeEditorView);
		ComponentPropertiesController = new ComponentPropertiesController(ComponentPropertiesView);
		JointEditorController = new JointEditorController(JointEditorView);
		MainMenuController = new MainMenuController(MainMenuView);
		GroupCampaignController = new GroupCampaignController(GroupCampaignView, GAME.GroupCampaignModel);
		LogicEditorController = new LogicEditorController(LogicEditorView, new LogicSystemModel());
		LevelCompletedController = new LevelCompletedController(LevelCompletedView, null);
		MessageBoxController = new MessageBoxController(MessageBoxView, null);
		SaveDefenderCreationController = new SaveDefenderCreationController(SaveDefenderCreationView, null);
		BlockVisualizationController = new BlockVisualizationController(BlockVisualizationView);
		ActionModeController = new ActionModeController(ActionModeView);
		PauseController = new PauseController(PauseView);
		ReplayController = new ReplayController(ReplayView);
		ManualController = new ManualController(ManualView);
		StepByStepController = new StepByStepController(StepByStepView);
		OptionsController = new OptionsController(OptionsView, GAME.OptionsModel, GAME.LanguagesManager);
		LETopButtonsController = new LETopButtonsController(LETopButtonsView);
		LEQuickInventoryController = new LEQuickInventoryController(LEQuickInventoryView, GAME.LEQuickInventoryModel);
		LEInventoryController = new LEInventoryController(LEInventoryView, GAME.LECategoriesModel);
		LEClipboardController = new LEClipboardController(LEClipboardView, GAME.LEClipboardModel, LEQuickInventoryView.SlotToggleGroup);
		LEPropertiesController = new LEPropertiesController(LEPropertiesView, GAME.LevelEditorToolsModel);
		InspectorController = new InspectorController(InspectorView);
		SaveLevelController = new SaveLevelController(SaveLevelView);
		LoadLevelController = new LoadLevelController(LoadLevelView, GAME.UserAndWorkshopLevelModelCollection);
		UserLevelWorkshopController = new UserLevelWorkshopController(UserLevelWorkshopView);
		SaveLevelPartController = new SaveLevelPartController(SaveLevelPartView);
		LEManualController = new LEManualController(LEManualView);
		array = components;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetVisibility(isVisible: false);
		}
		tooltipsCanvasObject.SetActive(value: true);
		NormalTooltipPanel = normalTooltipPanelObject.GetComponent<NormalTooltipPanel>();
		NormalTooltipPanel.gameObject.SetActive(value: true);
		NormalTooltipPanel.SetVisibility(isVisible: false);
		WarningTooltipPanel = warningTooltipPanelObject.GetComponent<WarningTooltipPanel>();
		WarningTooltipPanel.gameObject.SetActive(value: true);
		WarningTooltipPanel.SetVisibility(isVisible: false);
		BlockTooltipPanel = blockTooltipPanelObject.GetComponent<BlockTooltipPanel>();
		BlockTooltipPanel.gameObject.SetActive(value: true);
		BlockTooltipPanel.SetVisibility(isVisible: false);
		LevelObjectTooltipPanel = levelObjectTooltipPanelObject.GetComponent<LevelObjectTooltipPanel>();
		LevelObjectTooltipPanel.gameObject.SetActive(value: true);
		LevelObjectTooltipPanel.SetVisibility(isVisible: false);
		DescriptionTooltipPanel = descriptionTooltipPanelObject.GetComponent<DescriptionTooltipPanel>();
		DescriptionTooltipPanel.gameObject.SetActive(value: true);
		DescriptionTooltipPanel.SetVisibility(isVisible: false);
		BlockModelTooltipPanel = blockModelTooltipPanelObject.GetComponent<BlockModelTooltipPanel>();
		BlockModelTooltipPanel.gameObject.SetActive(value: true);
		BlockModelTooltipPanel.SetVisibility(isVisible: false);
		disableMouseCanvas.gameObject.SetActive(value: true);
		SetMouseInteractive(isInteractive: true);
		FadeInAndOutView.OnFadeInHalfCompletedEvent += OnFadeInHalfCompletedHandler;
		FadeInAndOutView.OnFadeOutHalfCompletedEvent += OnFadeOutHalfCompletedHandler;
		FadeInAndOutView.OnFadeOutCompletedEvent += OnFadeOutCompletedHandler;
		GAME.AddListenerOnStateChanged(delegate
		{
			OnStateChangedHandler();
		});
		defaultMessageBoxModel = new MessageBoxModel();
		SetPanelsVisibilityBasedStateTransition();
		yield return new WaitForEndOfFrame();
	}

	private void OnStateChangedHandler()
	{
		NormalTooltipPanel.SetVisibility(isVisible: false);
		WarningTooltipPanel.SetVisibility(isVisible: false);
		BlockTooltipPanel.SetVisibility(isVisible: false);
		DescriptionTooltipPanel.SetVisibility(isVisible: false);
		BlockModelTooltipPanel.SetVisibility(isVisible: false);
	}

	public void ShowMessageBox(string headerText, string infoText, Action confirmAction, bool isCancelEnabled = true)
	{
		defaultMessageBoxModel.HeaderText = headerText;
		defaultMessageBoxModel.InfoText = infoText;
		defaultMessageBoxModel.ConfirmAction = confirmAction;
		defaultMessageBoxModel.IsCancelEnabled = isCancelEnabled;
		MessageBoxController.SetModel(defaultMessageBoxModel);
		GameManager.Instance.SetSubState(MessageBoxState.Instance);
	}

	public void SetMouseInteractive(bool isInteractive)
	{
		disableMouseCanvas.enabled = !isInteractive;
	}

	public void FadeInToBlackAndExecuteAction(Action action, LevelModel levelModel = null)
	{
		FadeInAndOutView.SetVisibility(isVisible: true);
		FadeInAndOutView.actionToExecute = action;
		FadeInAndOutView.SetLevelModel(levelModel);
		FadeInAndOutView.FadeInToBlack();
		IsScreenFadedToBlack = true;
		GameManager.Instance.SetSubState(IdleState.Instance);
	}

	private void OnFadeInHalfCompletedHandler()
	{
		Cursor.SetCursor(GameManager.Instance.LoadingCursor, Vector2.zero, CursorMode.Auto);
	}

	public void FadeOutFromBlack()
	{
		if (IsScreenFadedToBlack)
		{
			FadeInAndOutView.FadeOutFromBlack();
		}
	}

	private void OnFadeOutHalfCompletedHandler()
	{
		if (GameManager.Instance.MainCreationsManager.IsCreationsLoaded)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
		IsScreenFadedToBlack = false;
	}

	private void OnFadeOutCompletedHandler()
	{
		IsScreenFadedToBlack = false;
	}

	private void SetPanelsVisibilityBasedStateTransition()
	{
		GameManager gameManager = GameManager.Instance;
		gameManager.AddActionOnTransitionBetweenStates(StartLevelState.Instance, LevelPreviewState.Instance, delegate
		{
			if (gameManager.LevelType == GameManager.LevelTypeState.Tutorial)
			{
				StepByStepView.SetVisibility(isVisible: false);
			}
		});
		gameManager.AddActionOnTransitionBetweenStates(LevelPreviewState.Instance, ConstructionState.Instance, delegate
		{
			if (gameManager.LevelType == GameManager.LevelTypeState.Tutorial)
			{
				StepByStepView.SetVisibility(isVisible: true);
				StepByStepView.SetVisibilityAnimation(isVisible: true);
			}
			TopButtonsView.SetVisibilityAnimation(isVisible: true);
			QuickInventoryView.SetVisibilityAnimation(isVisible: true);
			ClipboardView.SetVisibilityAnimation(isVisible: true);
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[9]
		{
			ConstructionState.Instance,
			CreationMovingState.Instance,
			GroupEditorState.Instance,
			HingeEditorState.Instance,
			ComponentPropertiesState.Instance,
			JointEditorState.Instance,
			LogicEditorState.Instance,
			ActionState.Instance,
			LevelCompletedState.Instance
		}, MenuState.Instance, delegate
		{
			if (gameManager.LevelType == GameManager.LevelTypeState.Tutorial)
			{
				StepByStepView.SetVisibility(isVisible: false);
			}
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[4]
		{
			LevelPreviewState.Instance,
			ActionState.Instance,
			ReplayState.Instance,
			LevelCompletedState.Instance
		}, ConstructionState.Instance, delegate
		{
			TopButtonsView.SetVisibility(isVisible: true);
			QuickInventoryView.SetVisibility(isVisible: true);
			ClipboardView.SetVisibility(isVisible: true);
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[3]
		{
			ConstructionState.Instance,
			CreationMovingState.Instance,
			GroupEditorState.Instance
		}, new State<GameManager>[3]
		{
			ActionState.Instance,
			LevelEditorState.Instance,
			MenuState.Instance
		}, delegate
		{
			TopButtonsView.SetVisibility(isVisible: false);
			QuickInventoryView.SetVisibility(isVisible: false);
			ClipboardView.SetVisibility(isVisible: false);
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[6]
		{
			LoadCreationState.Instance,
			LevelStatisticsState.Instance,
			HingeEditorState.Instance,
			ComponentPropertiesState.Instance,
			JointEditorState.Instance,
			LogicEditorState.Instance
		}, ConstructionState.Instance, delegate
		{
			QuickInventoryView.SetVisibility(isVisible: true);
			ClipboardView.SetVisibility(isVisible: true);
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[3]
		{
			ConstructionState.Instance,
			CreationMovingState.Instance,
			GroupEditorState.Instance
		}, new State<GameManager>[5]
		{
			LoadCreationState.Instance,
			HingeEditorState.Instance,
			ComponentPropertiesState.Instance,
			JointEditorState.Instance,
			LogicEditorState.Instance
		}, delegate
		{
			QuickInventoryView.SetVisibility(isVisible: false);
			ClipboardView.SetVisibility(isVisible: false);
		});
		gameManager.AddActionOnTransitionBetweenStates(new State<GameManager>[4]
		{
			HingeEditorState.Instance,
			ComponentPropertiesState.Instance,
			JointEditorState.Instance,
			LogicEditorState.Instance
		}, new State<GameManager>[3]
		{
			ActionState.Instance,
			LevelEditorState.Instance,
			MenuState.Instance
		}, delegate
		{
			TopButtonsView.SetVisibility(isVisible: false);
		});
	}
}

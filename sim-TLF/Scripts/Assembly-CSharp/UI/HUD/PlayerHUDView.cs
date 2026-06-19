using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Services;
using Player.Weapons;
using UI.Descriptor;
using UI.HUD.Assistant;
using UI.HUD.SystemInfo;
using UI.Inventory;
using UI.Inventory.Describer;
using UI.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.HUD
{
	public class PlayerHUDView : MonoBehaviour
	{
		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private CanvasGroup _hudCanvasGroup;

		[SerializeField]
		private Transform _craftRecipeParent;

		[SerializeField]
		private StatsView _statsView;

		[SerializeField]
		private InventoryView _inventoryView;

		[SerializeField]
		private DescriptorView _descriptorView;

		[SerializeField]
		private ToolInfoView _toolInfoView;

		[SerializeField]
		private WorldUIOutliner _worldUIHighlighter;

		[SerializeField]
		private HoldingIndicatorViewAdvanced _holdingIndicatorView;

		[SerializeField]
		private MinigamesControllerView _minigamesController;

		[SerializeField]
		private InventoryDescriberView _descriptorDescriberView;

		[SerializeField]
		private LeadTargetIndicator _leadTargetIndicator;

		[SerializeField]
		private SystemInfoMessageSender _infoMessageSender;

		[Header("Assembly part hints")]
		[Tooltip("Shown when looking at a part that is placed but not yet tightened. Contains the \"Placed\" text + tick.")]
		[SerializeField]
		private GameObject _placedHint;

		[Tooltip("Shown when looking at a part that is tightened. Contains the \"Tightened\" text + tick.")]
		[SerializeField]
		private GameObject _tightenedHint;

		[Tooltip("Shown when a tightened part unlocks further parts. Contains the \"Ready to install other parts\" text.")]
		[SerializeField]
		private GameObject _readyToInstallHint;

		private InventoryDescriberViewModel _describerViewModel;

		public Transform CraftRecipeParent => _craftRecipeParent;

		public StatsView StatsView => _statsView;

		public InventoryView InventoryView => _inventoryView;

		public RawImage InventoryViewRenderImage => _inventoryView.RenderImage;

		public RawImage InventoryViewRayLimiter => _inventoryView.RayLimiterImage;

		public DescriptorView DescriptorView => _descriptorView;

		public WorldUIOutliner WorldUIHighlighter => _worldUIHighlighter;

		public HoldingIndicatorViewModel HoldingIndicatorVM => _holdingIndicatorView.GetDataContext() as HoldingIndicatorViewModel;

		public MinigamesControllerView MinigamesController => _minigamesController;

		public LeadTargetIndicator LeadTargetIndicator => _leadTargetIndicator;

		public SystemInfoMessageSender InfoMessageSender => _infoMessageSender;

		private void Awake()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			IServiceContainer container = applicationContext.GetContainer();
			container.Register(new InventoryDescriberViewModel());
			container.Register(new ToolInfoViewModel(_toolInfoView.ToolSprites));
			container.Register(new InfoCursorsViewModel());
			container.Register(new AssistantPopupViewModel());
			container.Register(new ToolIconViewModel(_toolInfoView.ToolSprites));
			_describerViewModel = applicationContext.GetService<InventoryDescriberViewModel>();
		}

		private void OnDestroy()
		{
			IServiceContainer container = Context.GetApplicationContext().GetContainer();
			container.Unregister<InventoryDescriberViewModel>();
			container.Unregister<ToolInfoViewModel>();
			container.Unregister<InfoCursorsViewModel>();
			container.Unregister<AssistantPopupViewModel>();
			container.Unregister<ToolIconViewModel>();
		}

		private void OnEnable()
		{
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		private void OnDisable()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
		}

		public void SetAssemblyPartHints(bool placed, bool tightened, bool readyToInstall)
		{
			SetHintActive(_placedHint, placed);
			SetHintActive(_tightenedHint, tightened);
			SetHintActive(_readyToInstallHint, readyToInstall);
		}

		private static void SetHintActive(GameObject hint, bool value)
		{
			if (hint != null && hint.activeSelf != value)
			{
				hint.SetActive(value);
			}
		}

		private void Update()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, (_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : _canvas.worldCamera, out var localPoint);
			_describerViewModel.Position = localPoint;
		}

		private void OnSceneUnloaded(Scene scene)
		{
			if (scene.name == "MainMenuScene")
			{
				_hudCanvasGroup.alpha = 1f;
			}
		}
	}
}

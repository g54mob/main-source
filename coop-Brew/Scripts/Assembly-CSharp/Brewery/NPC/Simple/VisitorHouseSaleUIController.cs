using Brewery.NPC.Data;
using Property;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.NPC.Simple
{
	[RequireComponent(typeof(UIDocument))]
	public class VisitorHouseSaleUIController : MonoBehaviour, IUIPanel
	{
		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Animation")]
		[SerializeField]
		private float animationDuration;

		[Header("Haggle Settings")]
		private const int SMALL_ADJUSTMENT = 1;

		private const int LARGE_ADJUSTMENT = 10;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement overlayContainer;

		private VisualElement rootPanel;

		private Button closeButton;

		private Label visitorNameLabel;

		private VisualElement visitorPortrait;

		private VisualElement housesContainer;

		private VisualElement noHousesState;

		private Label housesCountLabel;

		private ScrollView housesScroll;

		private VisualElement sectionHeader;

		private VisualElement contentArea;

		private VisualElement hagglePanel;

		private Button haggleBackButton;

		private Label haggleHouseNameLabel;

		private Label haggleBaseValueLabel;

		private Label haggleOfferValueLabel;

		private Label haggleProfitValueLabel;

		private Button haggleMinusLargeBtn;

		private Button haggleMinusSmallBtn;

		private Button hagglePlusSmallBtn;

		private Button hagglePlusLargeBtn;

		private Label willingnessPercentLabel;

		private VisualElement willingnessBarFill;

		private Label haggleInfoText;

		private Button makeOfferButton;

		private VisualElement saleResultOverlay;

		private Label resultIcon;

		private Label resultTitle;

		private Label resultMessage;

		private VisualElement resultPriceSection;

		private Label resultPriceValue;

		private Label resultProfitValue;

		private VisualElement resultReturnInfo;

		private Label resultReturnText;

		private Button resultContinueButton;

		private VisualElement alreadyOfferedState;

		private Label alreadyOfferedMessage;

		private Label alreadyOfferedReturnTime;

		private NPCProfile currentVisitor;

		private VisitorNPCInteraction currentVisitorInteraction;

		private bool isUIVisible;

		private SampleCameraController cameraController;

		private HouseData currentHaggleHouse;

		private int currentBaseRent;

		private int currentOfferRent;

		private bool isWaitingForResult;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static VisitorHouseSaleUIController Instance { get; private set; }

		public void Close()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void SetupUI()
		{
		}

		public void ShowUI(NPCProfile visitor, VisitorNPCInteraction interaction = null)
		{
		}

		public void HideUI()
		{
		}

		private void ShowHousesList()
		{
		}

		private void ShowAlreadyOfferedState(NPCProfile visitor, bool permanentlyRefused)
		{
		}

		private void PopulateHouses()
		{
		}

		private void CreateHouseCard(HouseData house)
		{
		}

		private void ShowHagglePanel(HouseData house, int baseRent)
		{
		}

		private void HideHagglePanel()
		{
		}

		private void AdjustOffer(int amount)
		{
		}

		private void UpdateHaggleDisplay()
		{
		}

		private void UpdateHaggleInfoText(float willingness)
		{
		}

		private void UpdateMakeOfferButtonStyle(float willingness)
		{
		}

		private void OnMakeOfferClicked()
		{
		}

		private void OnHaggleResultReceived(bool success, string message, int salePrice, bool visitorWillReturn)
		{
		}

		private void ShowResultOverlay(bool success, string message, int dailyRent, bool visitorWillReturn)
		{
		}

		private void FindCameraController()
		{
		}
	}
}

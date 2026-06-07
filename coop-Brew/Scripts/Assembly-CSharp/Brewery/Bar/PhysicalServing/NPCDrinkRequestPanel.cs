using System.Collections.Generic;
using Brewery.NPC;
using Brewery.NPC.Simple;
using Brewery.Stand;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Bar.PhysicalServing
{
	public class NPCDrinkRequestPanel : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("NPC Reference")]
		[Tooltip("If null, will try to find SimpleNPCController in parent")]
		[SerializeField]
		private SimpleNPCController npcController;

		[Tooltip("If null, will try to find NPCSpeechBubbleController in siblings")]
		[SerializeField]
		private NPCSpeechBubbleController speechBubble;

		[Header("Configuration")]
		[Tooltip("If true, uses PhysicalServingConfig for all settings. If false, uses local values below.")]
		[SerializeField]
		private bool useGlobalConfig;

		[Header("Local Overrides (only used if useGlobalConfig = false)")]
		[SerializeField]
		private float showDistance;

		[SerializeField]
		private float popInDuration;

		[SerializeField]
		private float popOutDuration;

		[SerializeField]
		private int sortingOrder;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement root;

		private VisualElement panelContainer;

		private VisualElement drinkIcon;

		private Label drinkNameLabel;

		private Label drinkPriceLabel;

		private VisualElement progressBarFill;

		private bool isInitialized;

		private bool isVisible;

		private bool isAnimatingIn;

		private bool isAnimatingOut;

		private DrinkPoolEntry currentAssignment;

		private ulong npcNetworkId;

		private bool speechBubbleActive;

		private Camera localPlayerCamera;

		private float cameraSearchCooldown;

		private const float CAMERA_SEARCH_INTERVAL = 1f;

		private Vector3 baseScale;

		private bool isShowingGenericDisplay;

		private float lastDisplayedPrice;

		private float cachedBarMood;

		private const float PRICE_UPDATE_INTERVAL = 0.1f;

		private float priceUpdateTimer;

		private float nextPollTime;

		private const float POLL_INTERVAL = 0.5f;

		private NPCStandServingTarget standServingTarget;

		private float clientPaymentWaitStartTime;

		private bool clientWasWaitingForPayment;

		private int cachedPatienceTier;

		private float ShowDistance => 0f;

		private float PopInDuration => 0f;

		private float PopOutDuration => 0f;

		private int SortingOrder => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Initialize()
		{
		}

		private void OnDestroy()
		{
		}

		private void HandleSpeechBubbleVisibilityChanged(bool isShowing)
		{
		}

		private bool ShouldShowPanelIgnoringSpeechBubble()
		{
			return false;
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void UpdatePriceWithTips()
		{
		}

		private void UpdateProgressBar()
		{
		}

		private void LateUpdate()
		{
		}

		private bool ShouldShowPanel()
		{
			return false;
		}

		private void HandleBarAssignmentsChanged(Dictionary<ulong, DrinkPoolEntry> assignments)
		{
		}

		private void HandleStandAssignmentsChanged(Dictionary<ulong, DrinkPoolEntry> assignments)
		{
		}

		private void PollAssignment()
		{
		}

		private void UpdateAssignment(DrinkPoolEntry assignment)
		{
		}

		private void SetPaymentDisplayFromStandTarget()
		{
		}

		private void ClearAssignment()
		{
		}

		public void SetCorrectDrinkHighlight(bool hasCorrectDrink)
		{
		}

		private void UpdateDistanceVisibility()
		{
		}

		private float GetDistanceToLocalPlayer()
		{
			return 0f;
		}

		private void FindLocalPlayerCamera()
		{
		}

		private void ShowPanel()
		{
		}

		private void HidePanel()
		{
		}

		public void HideImmediate()
		{
		}

		private void CancelAllAnimations()
		{
		}

		public DrinkPoolEntry GetCurrentAssignment()
		{
			return default(DrinkPoolEntry);
		}

		public bool HasValidRequest()
		{
			return false;
		}

		public ulong GetNPCNetworkId()
		{
			return 0uL;
		}
	}
}

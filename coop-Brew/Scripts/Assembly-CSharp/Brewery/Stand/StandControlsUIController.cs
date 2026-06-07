using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Stand
{
	[RequireComponent(typeof(UIDocument))]
	public class StandControlsUIController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private StandStateManager stateManager;

		[SerializeField]
		private StandReputationManager repManager;

		[SerializeField]
		private StandUpgradeManager upgradeManager;

		[SerializeField]
		private StandServingManager servingManager;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private UIDocument _uiDocument;

		private UIDocumentSleeper _sleeper;

		private VisualElement _root;

		private VisualElement _collapsedHint;

		private VisualElement _expandedPanel;

		private Label _statusLabel;

		private Label _toggleLabel;

		private Button _toggleBtn;

		private VisualElement _toggleProgress;

		private VisualElement _repSection;

		private Label _repLevelLabel;

		private VisualElement _repBarFill;

		private Label _repDrinksLabel;

		private Label _upgradeCount;

		private VisualElement _upgradeInfo;

		private Label _upgradeName;

		private Label _upgradeDesc;

		private Button _upgradePurchaseBtn;

		private Label _allUpgradesLabel;

		private bool _isPlayerInArea;

		private bool _isPanelExpanded;

		private bool _isHeld;

		private float _holdStartTime;

		private bool _holdActionTriggered;

		private bool _justExpandedPanel;

		private const float HoldDuration = 1f;

		private const float ProgressShowDelay = 0.15f;

		private static GameObject _tweenTargetUI;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnInputReaderReady(InputReader reader)
		{
		}

		private void Update()
		{
		}

		public void OnPlayerEnteredStandArea()
		{
		}

		public void OnPlayerExitedStandArea()
		{
		}

		private void OnControlsStarted()
		{
		}

		private void OnControlsCanceled()
		{
		}

		private void ShowCollapsedHint()
		{
		}

		private void HideCollapsedHint()
		{
		}

		private void ExpandPanel()
		{
		}

		private void CollapsePanel()
		{
		}

		private void ResetHoldProgress()
		{
		}

		private void ToggleStandState()
		{
		}

		private void OnAction2Upgrade()
		{
		}

		private void OnPurchaseUpgrade()
		{
		}

		private void HandleStandStateChanged(bool isOpen)
		{
		}

		private void HandleRepChanged(float newRep)
		{
		}

		private void HandleRepGained(float amountGained)
		{
		}

		private void HandleRepLost(float amountLost)
		{
		}

		private static GameObject GetTweenTarget()
		{
			return null;
		}

		private void HandleUpgradeCountChanged()
		{
		}

		private void RefreshAllUI()
		{
		}

		private void UpdateStandStatus(bool isOpen)
		{
		}

		private void UpdateReputation()
		{
		}

		private void UpdateStats()
		{
		}

		private void UpdateUpgradeSection()
		{
		}
	}
}

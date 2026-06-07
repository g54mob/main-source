using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BarUpgrade;
using InventorySystem;
using Player;
using Synty.AnimationBaseLocomotion.Samples;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	[RequireComponent(typeof(UIDocument))]
	public class BarUpgradeUIController : MonoBehaviour, IUIPanel
	{
		[CompilerGenerated]
		private sealed class _003CResetUpgradeCooldown_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BarUpgradeUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CResetUpgradeCooldown_003Ed__57(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement overlayContainer;

		private VisualElement panelRoot;

		private Button closeButton;

		private VisualElement purchaseScreen;

		private Label purchaseCostLabel;

		private Label purchaseBalanceLabel;

		private Button purchaseBarButton;

		private Label purchaseErrorLabel;

		private VisualElement upgradeScreen;

		private Label progressCountLabel;

		private VisualElement progressBarFill;

		private Label balanceValueLabel;

		private VisualElement upgradeActionSection;

		private Label upgradeCostLabel;

		private Label upgradeDescriptionLabel;

		private Button upgradeButton;

		private VisualElement allCompleteSection;

		private Label completeLabel;

		private Label completeSubtitle;

		private VisualElement completeIconContainer;

		private Label hintLabel;

		private BarUpgradeManager currentUpgradeManager;

		private PlayerCurrency playerCurrency;

		private InventoryManager playerInventory;

		private bool isUIVisible;

		private bool isUpgradeOnCooldown;

		private const float UPGRADE_COOLDOWN = 0.3f;

		private SampleCameraController cameraController;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static BarUpgradeUIController Instance { get; private set; }

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

		private void SetupUI()
		{
		}

		private void FindPlayerCurrency()
		{
		}

		private void FindPlayerInventory()
		{
		}

		public void ShowUI(BarUpgradeManager upgradeManager)
		{
		}

		public void HideUI()
		{
		}

		public void ToggleUI(BarUpgradeManager upgradeManager)
		{
		}

		private void ShowPurchaseScreen()
		{
		}

		private void ShowUpgradeScreen()
		{
		}

		private void UpdatePurchaseScreenContent()
		{
		}

		private void UpdatePurchaseBalance()
		{
		}

		private void UpdateUpgradeScreenContent()
		{
		}

		private void OnPurchaseBarClicked()
		{
		}

		private void OnUpgradeButtonClicked()
		{
		}

		[IteratorStateMachine(typeof(_003CResetUpgradeCooldown_003Ed__57))]
		private IEnumerator ResetUpgradeCooldown()
		{
			return null;
		}

		private void SubscribeToManager()
		{
		}

		private void UnsubscribeFromManager()
		{
		}

		private void OnUpgradeLevelChanged(int newLevel)
		{
		}

		private void OnUpgradeAttempted(int upgradeIndex, bool success)
		{
		}

		private void OnPlayerCurrencyChanged(float newAmount)
		{
		}

		private void OnPlayerInventoryChanged()
		{
		}

		private void OnBarOwnershipChanged(bool isOwned)
		{
		}

		private void OnBarPurchaseAttempted(bool success)
		{
		}

		private void FindCameraController()
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.TradingSystem;
using Brewery.UI;
using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Quest
{
	[RequireComponent(typeof(UIDocument))]
	public class QuestDialogController : BaseBreweryUIController
	{
		[CompilerGenerated]
		private sealed class _003CHideAfterDelay_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public QuestDialogController _003C_003E4__this;

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
			public _003CHideAfterDelay_003Ed__60(int _003C_003E1__state)
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

		private const string TemplatePath = "UI/QuestDialogUI";

		private const string StylesheetPath = "UI/QuestDialogUI";

		private VisualElement dialogPanel;

		private VisualElement npcPortrait;

		private Label npcNameLabel;

		private Label questTitleLabel;

		private Label dialogueText;

		private VisualElement rewardSection;

		private VisualElement rewardIcon;

		private Label rewardLabel;

		private VisualElement unlocksSection;

		private VisualElement unlocksContainer;

		private VisualElement deliverySection;

		private VisualElement requiredItemsContainer;

		private Label deliveryStatus;

		private Button deliverButton;

		private Button continueButton;

		private VisualElement itemTooltipPanel;

		private Label tooltipItemName;

		private Label tooltipItemDescription;

		private string currentNpcId;

		private QuestStep currentStep;

		private QuestChain currentChain;

		private bool isWaitingForDelivery;

		public static QuestDialogController Instance { get; private set; }

		protected override void RegisterSingleton()
		{
		}

		protected override VisualElement GetContainer()
		{
			return null;
		}

		protected override void OnUIHiding()
		{
		}

		private void ReleaseNpcLockIfNeeded()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BuildUI()
		{
		}

		private void CreateTooltipPanel()
		{
		}

		public void ShowDialogue(string npcId, QuestStep step, QuestChain chain, Sprite portraitOverride = null)
		{
		}

		public void OnDeliverySuccess(string progressMessage = null)
		{
		}

		public void OnPartialDeliverySuccess(string progressMessage)
		{
		}

		public void OnDeliveryFailed(string reason)
		{
		}

		private void ShowDeliverySection(QuestStep step)
		{
		}

		private void HideDeliverySection()
		{
		}

		private void UpdateRewardPreview(QuestChain chain)
		{
		}

		private void UpdateUnlocksPreview(QuestChain chain)
		{
		}

		private void CreateUnlocksSection()
		{
		}

		private VisualElement CreateUnlockRow(LockedTrade trade, string currentChainId = null)
		{
			return null;
		}

		private void PopulateRequiredItems(QuestStep step)
		{
		}

		private int GetPlayerItemCount(InventoryManager inventory, RequiredItemInfo reqInfo)
		{
			return 0;
		}

		private VisualElement CreateItemRowWithProgress(RequiredItemInfo reqInfo, int playerHas, int deliveredSoFar, int remaining, bool isPartialDelivery)
		{
			return null;
		}

		private VisualElement CreateItemRowFromInfo(RequiredItemInfo reqInfo, Item item, int playerHas)
		{
			return null;
		}

		private VisualElement CreateItemRow(Item item, int playerHas, int needed)
		{
			return null;
		}

		private void OnContinueClicked()
		{
		}

		private void OnDeliverClicked()
		{
		}

		private void ShowItemTooltip(RequiredItemInfo reqInfo, Item item, MouseEnterEvent evt)
		{
		}

		private void HideItemTooltip()
		{
		}

		private void UpdateTooltipPosition(MouseMoveEvent evt)
		{
		}

		private string GetNpcDisplayName(string npcId)
		{
			return null;
		}

		private string FormatNpcId(string npcId)
		{
			return null;
		}

		private InventoryManager GetLocalPlayerInventory()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideAfterDelay_003Ed__60))]
		private IEnumerator HideAfterDelay(float delay)
		{
			return null;
		}

		protected override void HandleCustomKeys(KeyDownEvent evt)
		{
		}
	}
}

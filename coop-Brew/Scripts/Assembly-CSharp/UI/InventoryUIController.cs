using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Core;
using Brewery.Items;
using Brewery.Systems;
using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	[RequireComponent(typeof(UIDocument))]
	public class InventoryUIController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CEnsureMetadataSubscription_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InventoryUIController _003C_003E4__this;

			private float _003Cwaited_003E5__2;

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
			public _003CEnsureMetadataSubscription_003Ed__65(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CRefreshCrateBadgesDelayed_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InventoryUIController _003C_003E4__this;

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
			public _003CRefreshCrateBadgesDelayed_003Ed__62(int _003C_003E1__state)
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

		private const string NonBlockingCursorSourceId = "InventoryUI";

		[Header("UI References")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private VisualTreeAsset inventoryUITemplate;

		[Header("Style Sheet")]
		[SerializeField]
		private StyleSheet inventoryStyleSheet;

		[Header("Settings")]
		[SerializeField]
		private bool hideWhenEmpty;

		private InventoryManager inventoryManager;

		private VisualElement root;

		private VisualElement inventoryContainer;

		private VisualElement itemInfoPanel;

		private List<VisualElement> slotElements;

		private List<VisualElement> iconElements;

		private List<Label> countLabels;

		private List<VisualElement> crateBadgeContainers;

		private List<VisualElement> crateIndicators;

		private List<VisualElement> placeableIndicators;

		private List<Label> hintPillLabels;

		private List<Label> crateDepositHints;

		private int selectedSlotIndex;

		private DepositTargetType lastDepositTarget;

		private VisualElement slotsContainer;

		private VisualElement backpackSlotContainer;

		private VisualElement backpackSlot;

		private VisualElement backpackIcon;

		private int currentSlotCount;

		private VisualElement itemMetadataSection;

		private VisualElement barrelDataSection;

		private Label barrelStateLabel;

		private ProgressBar barrelProgress;

		private Label barrelTimerLabel;

		private Label barrelBottlesLabel;

		private VisualElement beerDataSection;

		private Label beerQualityLabel;

		private Label beerTagsLabel;

		private Label beerPriceLabel;

		private Label beerLegendaryLabel;

		private Label beerCatalystsLabel;

		private VisualElement catalystDataSection;

		private Label catalystTagsLabel;

		private Label catalystRarityLabel;

		private int currentHoveredSlot;

		private bool isHoveringMetadataItem;

		public static InventoryUIController Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void SetupUI()
		{
		}

		private void RebuildInventorySlots(int slotCount)
		{
		}

		private void CreateSlotElement(int index)
		{
		}

		private void RegisterSlotWithDragDrop(int index, VisualElement slotElement, VisualElement iconElement)
		{
		}

		private void OnBackpackSlotClicked(PointerDownEvent evt)
		{
		}

		private void FindInventoryManager()
		{
		}

		private void SetupWithInventoryManager(InventoryManager manager)
		{
		}

		private void OnBackpackStateChanged(bool equipped)
		{
		}

		private void OnInventorySizeChanged(int newSize)
		{
		}

		private void UpdateBackpackSlot(bool equipped)
		{
		}

		private void OnInventorySlotChanged(int slotIndex, InventorySlot slot)
		{
		}

		private void UpdateSlotUI(int slotIndex, InventorySlot slot)
		{
		}

		private void UpdateCrateBadges(int slotIndex, InventorySlot slot, VisualElement badgeContainer)
		{
		}

		public void RefreshCrateBadgesForSlot(int slotIndex)
		{
		}

		private void OnInventoryRestoreComplete()
		{
		}

		[IteratorStateMachine(typeof(_003CRefreshCrateBadgesDelayed_003Ed__62))]
		private IEnumerator RefreshCrateBadgesDelayed()
		{
			return null;
		}

		public void RefreshAllCrateBadges()
		{
		}

		private void HandleCrateMetadataChanged(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		[IteratorStateMachine(typeof(_003CEnsureMetadataSubscription_003Ed__65))]
		private IEnumerator EnsureMetadataSubscription()
		{
			return null;
		}

		private void RefreshUI()
		{
		}

		private void OnSlotHover(int slotIndex, bool isHovering)
		{
		}

		private void OnSlotPointerDown(int slotIndex, PointerDownEvent evt)
		{
		}

		public void HandleSlotLeftClick(int slotIndex)
		{
		}

		private void OnSelectedSlotChanged(int slotIndex)
		{
		}

		private void OnItemActiveSelectionChanged(bool isActivelySelected)
		{
		}

		private void OnItemEquippedStateChanged(bool isEquipped)
		{
		}

		private void Update()
		{
		}

		private DepositTargetType GetCurrentDepositTarget()
		{
			return default(DepositTargetType);
		}

		private bool CanDepositItem(Item item, DepositTargetType target)
		{
			return false;
		}

		private string GetDepositHintStyleClass(DepositTargetType target)
		{
			return null;
		}

		private void UpdateDepositHints()
		{
		}

		private void ShowBarrelMetadata(int slotIndex)
		{
		}

		private void HideAllMetadata()
		{
		}

		private void UpdateBarrelMetadataDisplay(int slotIndex)
		{
		}

		private string FormatTimeRemaining(float seconds)
		{
			return null;
		}

		private void DisplayAgingProgress(BarrelMetadata metadata)
		{
		}

		private bool TryBuildBarrelDisplayText(int slotIndex, InventorySlot slot, out string name, out string description)
		{
			name = null;
			description = null;
			return false;
		}

		private bool TryGetBarrelMetadataForSlot(ulong ownerId, int slotIndex, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		private void ShowBeerMetadata(int slotIndex)
		{
		}

		private void ShowCatalystMetadata(int slotIndex)
		{
		}

		private string FormatBrewTags(BrewTag combinedTags)
		{
			return null;
		}

		private string FormatCatalystName(string catalystId)
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}

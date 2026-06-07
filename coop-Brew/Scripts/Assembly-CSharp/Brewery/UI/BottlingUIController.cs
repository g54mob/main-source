using System.Collections.Generic;
using Brewery.Core;
using Brewery.Items;
using Brewery.Shelf;
using InventorySystem;
using PlacementSystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class BottlingUIController : BaseBreweryUIController
	{
		private struct BarrelEntry
		{
			public int SlotIndex;

			public BarrelMetadata Metadata;
		}

		private const string TemplatePath = "UI/Bottling";

		private const string StylesheetPath = "UI/Brewery";

		private VisualElement panel;

		private VisualElement bottlingBarrelGrid;

		private ScrollView bottlingBarrelScroll;

		private Label bottlingEmptyBottleLabel;

		private VisualElement emptyBottleIcon;

		private Label bottlingStatusLabel;

		private Label bottlingEmptyMessage;

		private Button bottlingBottleButton;

		private Button bottlingBottleAllButton;

		private Button bottlingCloseButton;

		private Button bottlingTabBeerButton;

		private Button bottlingTabWineButton;

		private Button bottlingTabSpiritsButton;

		private InventoryManager localInventory;

		private InputReader inputReader;

		private PlacementPreviewController placementPreview;

		private ShelfInventoryManager currentShelf;

		private readonly List<BarrelEntry> barrelEntries;

		private readonly List<VisualElement> barrelSlots;

		private int selectedBarrelSlot;

		private Item cachedEmptyBottleItem;

		private bool inventoryDirty;

		private bool awaitingClientConnect;

		private BeverageType currentTab;

		public static BottlingUIController Instance { get; private set; }

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

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void BuildUI()
		{
		}

		public void OpenBottlingUI(ShelfInventoryManager shelf, BeverageType initialTab = BeverageType.Beer)
		{
		}

		public void ShowUI()
		{
		}

		public void ToggleUI()
		{
		}

		private void SwitchTab(BeverageType tab)
		{
		}

		private void UpdateTabVisuals()
		{
		}

		private void RefreshBottlingPanel()
		{
		}

		private void SelectBarrel(int slotIndex)
		{
		}

		private void UpdateBottlingSelection()
		{
		}

		private void OnBottlingAction()
		{
		}

		public void HandleBottlingResult(bool success, int bottlesFilled, int bottlesRemaining)
		{
		}

		private void SetupEmptyBottleIcon()
		{
		}

		private void UpdateEmptyBottleDisplay()
		{
		}

		protected override void HandleCustomKeys(KeyDownEvent evt)
		{
		}

		private void OnBottleAll()
		{
		}

		private void LocateLocalInventory()
		{
		}

		private void RegisterInventory(InventoryManager manager)
		{
		}

		private void UnregisterInventory()
		{
		}

		private void OnInventoryUpdated()
		{
		}

		private void HandleClientConnected(ulong clientId)
		{
		}

		private void LocateInputReader()
		{
		}

		private void SubscribeInputReader()
		{
		}

		private void UnsubscribeInputReader()
		{
		}

		private void CacheCommonItems()
		{
		}
	}
}

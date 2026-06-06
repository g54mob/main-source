using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Buffs;
using Brewery.Core;
using Brewery.Items;
using Brewery.UI;
using InventorySystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace DevTools
{
	public class DevCheatMenuUIController : BaseBreweryUIController
	{
		private enum CheatMenuTab
		{
			All = 0,
			Tool = 1,
			Resource = 2,
			Consumable = 3,
			Equipment = 4,
			Misc = 5,
			Special = 6,
			Effects = 7,
			Furniture = 8,
			Achievements = 9,
			Stations = 10
		}

		private enum MessageType
		{
			Success = 0,
			Warning = 1
		}

		[CompilerGenerated]
		private sealed class _003CDelayedRefreshStats_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DevCheatMenuUIController _003C_003E4__this;

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
			public _003CDelayedRefreshStats_003Ed__118(int _003C_003E1__state)
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
		private sealed class _003CSetBarrelMetadataAfterAdd_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DevCheatMenuUIController _003C_003E4__this;

			public BarrelState targetState;

			public BeverageType beverageType;

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
			public _003CSetBarrelMetadataAfterAdd_003Ed__92(int _003C_003E1__state)
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

		private const string TemplatePath = "UI/DevCheatMenu";

		private const string StylesheetPath = "UI/StationUI";

		private Button allTabButton;

		private Button toolTabButton;

		private Button resourceTabButton;

		private Button consumableTabButton;

		private Button equipmentTabButton;

		private Button miscTabButton;

		private Button specialTabButton;

		private Button effectsTabButton;

		private Button furnitureTabButton;

		private Button achievementsTabButton;

		private Button stationsTabButton;

		private VisualElement allContent;

		private VisualElement toolContent;

		private VisualElement resourceContent;

		private VisualElement consumableContent;

		private VisualElement equipmentContent;

		private VisualElement miscContent;

		private VisualElement specialContent;

		private VisualElement effectsContent;

		private VisualElement furnitureContent;

		private VisualElement achievementsContent;

		private VisualElement stationsContent;

		private VisualElement allItemsGrid;

		private VisualElement toolItemsGrid;

		private VisualElement resourceItemsGrid;

		private VisualElement consumableItemsGrid;

		private VisualElement equipmentItemsGrid;

		private VisualElement miscItemsGrid;

		private VisualElement specialItemsGrid;

		private VisualElement effectsItemsGrid;

		private VisualElement furnitureItemsGrid;

		private VisualElement stationsItemsGrid;

		private Label brewingStatsLabel;

		private Label discoveriesStatsLabel;

		private Label questsStatsLabel;

		private Label currencyStatsLabel;

		private Label factionStatsLabel;

		private Label visitorStatsLabel;

		private List<CatalystEffectData> allEffects;

		private Button closeButton;

		private InventoryManager localInventory;

		private InputReader inputReader;

		private bool awaitingInventory;

		private bool _cheatsEnabled;

		[Header("Dev Shortcut")]
		[Tooltip("Enable cheats on start without typing the secret code")]
		[SerializeField]
		private bool autoEnableCheats;

		private const string SecretCode = "FANCYPANTSDRINKING";

		private const float SecretCodeTimeout = 3f;

		private string secretBuffer;

		private float lastKeyTime;

		private bool secretListenerActive;

		private CheatMenuTab currentTab;

		private readonly List<Item> allItems;

		public static DevCheatMenuUIController Instance { get; private set; }

		public bool IsCheatsEnabled => false;

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

		private void BuildUI()
		{
		}

		private void RegisterTabCallbacks()
		{
		}

		private void LocateLocalInventory()
		{
		}

		private void LoadAllItems()
		{
		}

		private void PopulateItemsGrid()
		{
		}

		private void SwitchTab(CheatMenuTab tab)
		{
		}

		protected override void HandleCustomKeys(KeyDownEvent evt)
		{
		}

		private VisualElement CreateItemButton(Item item)
		{
			return null;
		}

		private void OnItemButtonClicked(Item item, ClickEvent evt)
		{
		}

		private void ShowMessage(string message, MessageType type)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void SubscribeSecretCodeListener()
		{
		}

		private void UnsubscribeSecretCodeListener()
		{
		}

		private void OnSecretCodeChar(char c)
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void SubscribeToInputReader()
		{
		}

		private void UnsubscribeFromInputReader()
		{
		}

		public void SetCheatsEnabled(bool enabled)
		{
		}

		private void ToggleUI()
		{
		}

		private void CreateFermentingBarrelButtons()
		{
		}

		private void OnClearInventoryClicked()
		{
		}

		private VisualElement CreateSpecialBarrelButton(string displayName, string description, BeverageType beverageType, BarrelState targetState)
		{
			return null;
		}

		private void OnSpecialBarrelButtonClicked(BeverageType beverageType, BarrelState targetState, ClickEvent evt)
		{
		}

		[IteratorStateMachine(typeof(_003CSetBarrelMetadataAfterAdd_003Ed__92))]
		private IEnumerator SetBarrelMetadataAfterAdd(BeverageType beverageType, BarrelState targetState)
		{
			return null;
		}

		private void CreateStationKitButtons()
		{
		}

		private VisualElement CreateStationKitButton(string displayName, string description, Color bgColor, Action clickAction)
		{
			return null;
		}

		private void OnBoilingKitClicked()
		{
		}

		private void OnWinemakingKitClicked()
		{
		}

		private void OnStompingKitClicked()
		{
		}

		private void OnCornGrinderKitClicked()
		{
		}

		private void OnSpiritsKitClicked()
		{
		}

		private void OnBoilingKitFullClicked()
		{
		}

		private void OnWinemakingKitFullClicked()
		{
		}

		private void OnSpiritsKitFullClicked()
		{
		}

		private void CreateEffectButtons()
		{
		}

		private void TryPopulateEffectButtons()
		{
		}

		private VisualElement CreateClearBuffsButton()
		{
			return null;
		}

		private VisualElement CreateEffectButton(CatalystEffectData effect)
		{
			return null;
		}

		private string GetEffectTypeSymbol(BuffType type)
		{
			return null;
		}

		private string FormatCatalystName(string catalystId)
		{
			return null;
		}

		private void OnEffectButtonClicked(CatalystEffectData effect, ClickEvent evt)
		{
		}

		private void OnClearBuffsClicked()
		{
		}

		private void RegisterAchievementButtonCallbacks()
		{
		}

		private void RefreshAchievementStats()
		{
		}

		private void TriggerBrews(int count)
		{
		}

		private void TriggerDiscoveries(int count)
		{
		}

		private void TriggerQuestCompletions(int count)
		{
		}

		private void TriggerCompleteAllQuests()
		{
		}

		private void AddCurrency(float amount)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedRefreshStats_003Ed__118))]
		private IEnumerator DelayedRefreshStats()
		{
			return null;
		}

		private void TriggerFactionSales(string factionName, int count)
		{
		}

		private void TriggerAllFactionSales(int countPerFaction)
		{
		}

		private void ResetAchievementProgress()
		{
		}

		private void UnlockAllAchievements()
		{
		}

		private void SpawnVisitorNearPlayer()
		{
		}

		private void SpawnAllVisitorsForTesting()
		{
		}

		private void RefreshVisitorStats()
		{
		}
	}
}

using System.Collections.Generic;
using Brewery.Buffs;
using Brewery.Core;
using Brewery.NPC.TradingSystem;
using Brewery.Quest;
using Brewery.UI.Components;
using InventorySystem;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class TradingUIController : BaseBreweryUIController
	{
		private enum Tab
		{
			Trades = 0,
			Quests = 1,
			Rewards = 2
		}

		private const string TemplatePath = "UI/TradingNPCUI";

		private const string StylesheetPath = "UI/TradingNPCUI";

		private new VisualElement root;

		private VisualElement npcPortrait;

		private Label npcNameLabel;

		private Label npcDescriptionLabel;

		private VisualElement tradesContainer;

		private VisualElement noTradesMessage;

		private VisualElement itemTooltipPanel;

		private Label tooltipItemName;

		private Label tooltipItemDescription;

		private VisualElement questsContainer;

		private VisualElement noQuestsMessage;

		private Label questsBadgeText;

		private Button questsTabButton;

		private VisualElement rewardsContainer;

		private VisualElement noRewardsMessage;

		private Label playerBalanceLabel;

		private VisualElement priceModifiersBanner;

		private VisualElement skillDiscountContainer;

		private Label skillDiscountValue;

		private VisualElement buyBuffContainer;

		private Label buyBuffValue;

		private Label noModifiersLabel;

		private TradingNPCController activeNPC;

		private NPCTradingState currentState;

		private List<VisualElement> tradeCards;

		private bool isDirty;

		private Tab currentTab;

		public static TradingUIController Instance { get; private set; }

		private static TabDefinition[] TabDefinitions => null;

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

		protected override void OnDestroy()
		{
		}

		private void BuildUI()
		{
		}

		private void CreateTooltipPanel()
		{
		}

		private void CreateDevButtons()
		{
		}

		public void ShowUI(TradingNPCController npc)
		{
		}

		private void RefreshState()
		{
		}

		private void RequestStateFromServer()
		{
		}

		private void Update()
		{
		}

		private void RefreshUI()
		{
		}

		private void UpdatePriceModifiersBanner()
		{
		}

		private void UpdateNPCInfo()
		{
		}

		private void UpdatePlayerBalance()
		{
		}

		private void UpdateTradesTab()
		{
		}

		private bool HasItemRewards(TradeOffer offer)
		{
			return false;
		}

		private void ShowNoTradesMessage(bool show)
		{
		}

		private VisualElement CreateTradeCard(TradeInstance trade)
		{
			return null;
		}

		private void AppendCatalystLimitRow(VisualElement actions, TradeOffer tradeOffer)
		{
		}

		private VisualElement CreateItemSlot(Item item, int quantity, bool isReward)
		{
			return null;
		}

		private VisualElement CreateLockedTradeCard(LockedTrade trade, TradingProfile profile)
		{
			return null;
		}

		private bool CanAffordLockedTrade(LockedTrade trade, string npcId)
		{
			return false;
		}

		private void OnLockedTradeClicked(string tradeId)
		{
		}

		private void UpdateQuestsTab()
		{
		}

		private void SetQuestsTabVisible(bool visible)
		{
		}

		private void ShowNoQuestsMessage(bool show)
		{
		}

		private VisualElement CreateQuestCard(QuestChain chain, string questId, QuestAvailability availability)
		{
			return null;
		}

		private VisualElement CreateQuestUnlocksSection(QuestChain chain, bool isLocked)
		{
			return null;
		}

		private VisualElement CreateQuestUnlockRow(LockedTrade trade, bool isLocked, string progressText)
		{
			return null;
		}

		private void OnAcceptQuestClicked(string questId)
		{
		}

		private void OnTrackQuestClicked(string questId)
		{
		}

		private void UpdateRewardsTab()
		{
		}

		private void ShowNoRewardsMessage(bool show)
		{
		}

		private void OnTradeClicked(string tradeId)
		{
		}

		private bool CanAffordTrade(TradeInstance trade)
		{
			return false;
		}

		private int GetDiscountedPrice(TradeInstance trade)
		{
			return 0;
		}

		private void HandleTradeCompleted(string npcId, string tradeId)
		{
		}

		private void HandleDailyReset()
		{
		}

		private void HandleTabChanged(string tabKey)
		{
		}

		private void HandleLockedTradePurchased(string npcId, string tradeId)
		{
		}

		private void HandleNPCStateReceived(string npcId)
		{
		}

		private void HandleBuffChanged(ulong clientId, ActiveBuff buff)
		{
		}

		private void HandleBuffExpired(ulong clientId, string catalystId)
		{
		}

		private void UnsubscribeFromNPC()
		{
		}

		private bool HasAvailableTrades()
		{
			return false;
		}

		private int GetAvailableTradeCount()
		{
			return 0;
		}

		private int GetTotalCompletionsToday()
		{
			return 0;
		}

		private int GetAvailableQuestCount()
		{
			return 0;
		}

		private int GetAvailableRewardCount()
		{
			return 0;
		}

		private string FormatCatalyzedDrinkName(BaseType baseType, List<string> catalysts)
		{
			return null;
		}

		private Item GetCatalyzedDrinkItem(BaseType baseType)
		{
			return null;
		}

		private VisualElement CreateCatalyzedDrinkSlot(BaseType baseType, int quantity, List<string> catalystIds)
		{
			return null;
		}

		private int CountMatchingCatalyzedDrinks(InventoryManager inventory, BaseType baseType, List<string> requiredCatalysts)
		{
			return 0;
		}

		private bool IsNPCQuestsUnlocked()
		{
			return false;
		}

		private void ShowQuestsLockedMessage()
		{
		}

		private void ShowDemoQuestsMessage()
		{
		}

		private void ShowItemTooltip(Item item, MouseEnterEvent evt)
		{
		}

		private void HideItemTooltip()
		{
		}

		private void UpdateTooltipPosition(MouseMoveEvent evt)
		{
		}
	}
}

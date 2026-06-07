using System.Collections.Generic;
using Brewery.NPC.TradingSystem;
using InventorySystem;
using UnityEngine;

namespace Brewery.Map
{
	[RequireComponent(typeof(TradingNPCController))]
	public class TradingNPCHoverProvider : MonoBehaviour, IMapIconHoverProvider
	{
		private TradingNPCController npcController;

		[Header("Display Settings")]
		[Tooltip("Maximum number of trades to show")]
		[SerializeField]
		private int maxTradesToShow;

		private float lastStateRequestTime;

		private const float STATE_REQUEST_COOLDOWN = 2f;

		private bool isSubscribedToStateReceived;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnNPCStateReceived(string npcId)
		{
		}

		private void EnsureStateLoaded()
		{
		}

		public string GetHoverTitle()
		{
			return null;
		}

		public string GetHoverSubtitle()
		{
			return null;
		}

		public List<HoverInfoSection> GetHoverSections()
		{
			return null;
		}

		public bool ShouldShowHover()
		{
			return false;
		}

		private HoverInfoSection BuildQuestSection()
		{
			return null;
		}

		private HoverInfoSection BuildRewardsSection()
		{
			return null;
		}

		private Sprite GetRewardIcon(TradeOffer offer)
		{
			return null;
		}

		private Sprite GetRequiredIcon(TradeOffer offer)
		{
			return null;
		}

		private string GetBuyDescription(TradeInstance trade)
		{
			return null;
		}

		private string GetSellDescription(TradeInstance trade)
		{
			return null;
		}

		private string GetBarterDescription(TradeInstance trade)
		{
			return null;
		}

		private int GetCurrentQuantity(TradeInstance trade, Item item)
		{
			return 0;
		}
	}
}

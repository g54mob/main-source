using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class ShopMapMarker : MapMarker
	{
		public string configId;

		[SerializeField]
		private TextMeshProI18n _shopNameText;

		[HideInInspector]
		public string shopName;

		[HideInInspector]
		public string description;

		[HideInInspector]
		public string[] itemTypes;

		[HideInInspector]
		public string[] producedItems;

		[HideInInspector]
		public float priceModifier;

		[HideInInspector]
		public bool sellAllTiersBelow;

		[HideInInspector]
		public int tier;

		[HideInInspector]
		public bool isGeneralStore;

		[HideInInspector]
		public int maxShopItems;

		public RouteStop routeStop;

		private ContextMenuItem _currentContextMenuItem;

		public static int BaseTradeRouteLicenseCost => 0;

		public static int BaseDeliveryCostPerDay => 0;

		public static int FastDeliverySurcharge => 0;

		public static float FastDeliveryFeeMultiplier => 0f;

		public bool IsTradeRouteEstablished
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler TradeRouteEstablishedChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public override void OnClicked()
		{
		}

		public override void OnLevelChanged()
		{
		}

		private float CalculateTavernDragonEffort()
		{
			return 0f;
		}

		private float CalculateTavernRoadEffort()
		{
			return 0f;
		}

		public int CalculateTradeRouteCost()
		{
			return 0;
		}

		public int CalculateDeliveryCost()
		{
			return 0;
		}

		public int CalculateFastDeliveryCost()
		{
			return 0;
		}

		public float CalculateDeliveryTimeDaysF()
		{
			return 0f;
		}

		public float CalculateFastDeliveryTimeDaysF()
		{
			return 0f;
		}

		public IEnumerable<GameItemTemplate> GetAvailableItems()
		{
			return null;
		}

		public bool ProducesItem(GameItemTemplate template)
		{
			return false;
		}

		public void ValidateItemConfig()
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs<float> e)
		{
		}

		public override void CheckState()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void ShowVisual()
		{
		}

		public override void HideVisual()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}

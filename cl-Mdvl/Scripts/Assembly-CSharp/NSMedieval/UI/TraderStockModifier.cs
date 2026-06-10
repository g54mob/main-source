using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class TraderStockModifier : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<TraderStockModifierItem> stockModifiers = new List<TraderStockModifierItem>();

		public List<TraderStockModifierItem> StockModifiers => stockModifiers;

		public override string GetID()
		{
			return id;
		}

		public bool IsExcluded(TraderStockResource res)
		{
			foreach (TraderStockModifierItem stockModifier in stockModifiers)
			{
				if (stockModifier.IsResourceExcluded(res))
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(16, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TraderStockModifier.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(res);
						messageBuilder.AppendLiteral(" is excluded BY ");
						messageBuilder.AppendFormatted(id);
					}
					Log.Info(messageBuilder);
					isEnabled = true;
					return isEnabled;
				}
			}
			return false;
		}

		public float GetAmountModifier(TraderStockResource resource)
		{
			float num = 1f;
			foreach (TraderStockModifierItem stockModifier in stockModifiers)
			{
				if (stockModifier.Contains(resource))
				{
					num *= stockModifier.ModifyAmount;
				}
			}
			return num;
		}

		public float GetPriceModifier(TradeResource tradeResource)
		{
			float num = 1f;
			foreach (TraderStockModifierItem stockModifier in stockModifiers)
			{
				if (stockModifier.Contains(tradeResource))
				{
					num *= stockModifier.PriceModifier;
				}
			}
			return num;
		}

		public bool CanTradeResource(TradeResource resource)
		{
			foreach (TraderStockModifierItem stockModifier in StockModifiers)
			{
				if (stockModifier.CannotTrade && stockModifier.Contains(resource))
				{
					return false;
				}
			}
			return true;
		}

		public bool CanTradeResource(Resource resource)
		{
			foreach (TraderStockModifierItem stockModifier in StockModifiers)
			{
				if (stockModifier.CannotTrade && stockModifier.Contains(resource))
				{
					return false;
				}
			}
			return true;
		}
	}
}

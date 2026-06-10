using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class TraderStockModifiersContainer : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> stockModifiers;

		[NonSerialized]
		private List<TraderStockModifier> stockModifiersCache;

		[SerializeField]
		private LocKeys[] locKeys;

		public LocKeys[] LocKeys => locKeys;

		public List<TraderStockModifier> StockModifiers
		{
			get
			{
				if (stockModifiersCache == null)
				{
					stockModifiersCache = new List<TraderStockModifier>();
					foreach (string stockModifier in stockModifiers)
					{
						TraderStockModifier byID = Repository<TraderStockModifierRepository, TraderStockModifier>.Instance.GetByID(stockModifier);
						if (byID != null)
						{
							stockModifiersCache.Add(byID);
						}
					}
				}
				return stockModifiersCache;
			}
		}

		public override string GetID()
		{
			return id;
		}
	}
}

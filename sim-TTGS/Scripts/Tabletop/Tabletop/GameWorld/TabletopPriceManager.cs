using System;
using System.Collections.Generic;
using System.Linq;
using Simulator;

namespace Tabletop.GameWorld
{
	public static class TabletopPriceManager
	{
		private static Dictionary<int, float> _unpaintedMiniaturesMarketPricePercentage = new Dictionary<int, float>();

		private static Dictionary<int, float> _paintedMiniaturesMarketPricePercentage = new Dictionary<int, float>();

		public static event Action<int, bool, float> MiniatureMarketPricePercentageChanged;

		public static void Load()
		{
			TabletopSave currentSaveAs = SaveManager.GetCurrentSaveAs<TabletopSave>();
			_unpaintedMiniaturesMarketPricePercentage.Clear();
			_paintedMiniaturesMarketPricePercentage.Clear();
			List<int> miniatureProducts = currentSaveAs.miniatureProducts.miniatureProducts;
			List<float> unpaintedMarketPricePercentages = currentSaveAs.miniatureProducts.unpaintedMarketPricePercentages;
			List<float> paintedMarketPricePercentages = currentSaveAs.miniatureProducts.paintedMarketPricePercentages;
			if (!miniatureProducts.IsValid() || !unpaintedMarketPricePercentages.IsValid() || !paintedMarketPricePercentages.IsValid())
			{
				return;
			}
			int num = 0;
			foreach (int item in miniatureProducts)
			{
				float num2 = unpaintedMarketPricePercentages[num];
				if (num2 > 0f)
				{
					_unpaintedMiniaturesMarketPricePercentage[item] = num2;
				}
				float num3 = paintedMarketPricePercentages[num];
				if (num3 > 0f)
				{
					_paintedMiniaturesMarketPricePercentage[item] = num3;
				}
				num++;
			}
		}

		public static void Save()
		{
			TabletopSave currentSaveAs = SaveManager.GetCurrentSaveAs<TabletopSave>();
			currentSaveAs.miniatureProducts.StartSaveProcess();
			HashSet<int> hashSet = _unpaintedMiniaturesMarketPricePercentage.Keys.ToHashSet();
			foreach (var (item, _) in _paintedMiniaturesMarketPricePercentage)
			{
				hashSet.Add(item);
			}
			foreach (int item2 in hashSet)
			{
				float value;
				float unpaintedMarketPricePercentage = (_unpaintedMiniaturesMarketPricePercentage.TryGetValue(item2, out value) ? value : (-1f));
				float paintedMarketPricePercentage = (_paintedMiniaturesMarketPricePercentage.TryGetValue(item2, out value) ? value : (-1f));
				currentSaveAs.miniatureProducts.SaveMiniatureProductMarketPricePercentages(item2, unpaintedMarketPricePercentage, paintedMarketPricePercentage);
			}
		}

		public static bool TryGetMiniatureMarketPricePercentage(int miniatureProductDataUID, bool painted, out float percentage)
		{
			if (painted)
			{
				return _paintedMiniaturesMarketPricePercentage.TryGetValue(miniatureProductDataUID, out percentage);
			}
			return _unpaintedMiniaturesMarketPricePercentage.TryGetValue(miniatureProductDataUID, out percentage);
		}

		public static float GetMiniatureProductMarketPrice(int miniatureProductDataUID, bool painted)
		{
			int num = -miniatureProductDataUID;
			MiniatureData miniatureData = MiniatureDatabase.Get(num);
			if (miniatureData != null)
			{
				if (painted)
				{
					return PaintingSettings.GetMiniaturePrice(Collection.GetPaintMaxScore(num), miniatureData.MarketPrice);
				}
				return miniatureData.MarketPrice;
			}
			return 0f;
		}

		public static float GetMiniatureProductPrice(int miniatureProductDataUID, bool painted)
		{
			if (TryGetMiniatureMarketPricePercentage(miniatureProductDataUID, painted, out var percentage))
			{
				return percentage * GetMiniatureProductMarketPrice(miniatureProductDataUID, painted);
			}
			return 0f;
		}

		public static void SetMiniatureMarketPricePercentage(int miniatureProductData, bool painted, float percentage)
		{
			if (painted)
			{
				_paintedMiniaturesMarketPricePercentage[miniatureProductData] = percentage;
			}
			else
			{
				_unpaintedMiniaturesMarketPricePercentage[miniatureProductData] = percentage;
			}
			TabletopPriceManager.MiniatureMarketPricePercentageChanged?.Invoke(miniatureProductData, painted, percentage);
		}

		public static void Clear()
		{
			_unpaintedMiniaturesMarketPricePercentage.Clear();
			_paintedMiniaturesMarketPricePercentage.Clear();
		}
	}
}

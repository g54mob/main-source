using System;
using System.Collections.Generic;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Extensions", Scope.Project)]
	public class ShopExtensionSettings : CustomSettings<ShopExtensionSettings>
	{
		[Serializable]
		private struct ShopExtensionUnlockShopLevelFormula
		{
			[SerializeField]
			[Min(0f)]
			private int m_initialUnlockLevel;

			[SerializeField]
			[Min(0f)]
			private int m_incrementation;

			public int GetUnlockShopLevelForLevel(int currentLevel)
			{
				return m_initialUnlockLevel + m_incrementation * currentLevel;
			}
		}

		[Serializable]
		private struct ShopExtensionPriceFormula
		{
			[SerializeField]
			private float m_a;

			[SerializeField]
			private float m_b;

			[SerializeField]
			private float m_c;

			public float GetPriceForUnlockLevel(int unlockLevel)
			{
				return m_a + Mathf.Pow(m_b * (float)unlockLevel, m_c);
			}
		}

		[Serializable]
		private struct ReserveExtensionUnlockShopLevelFormula
		{
			[SerializeField]
			[Min(0f)]
			private int m_nbIterations;

			[SerializeField]
			[Min(0f)]
			private int m_incrementation;

			public readonly int NbIterations => m_nbIterations;

			public readonly int Incrementation => m_incrementation;
		}

		[Serializable]
		private struct ReserveExtensionPriceFormula
		{
			[SerializeField]
			private float m_a;

			[SerializeField]
			private float m_b;

			[SerializeField]
			private float m_c;

			public float GetPriceForUnlockLevel(int unlockLevel)
			{
				return m_a + Mathf.Pow(m_b * (float)unlockLevel, m_c);
			}
		}

		[Header("Demo")]
		[SerializeField]
		private int m_demoMaxShopExtLevel;

		[SerializeField]
		private int m_demoMaxReserveExtLevel;

		[Header("Shop Extensions")]
		[SerializeField]
		[Min(0f)]
		private int m_shopExtMaxLevel;

		[SerializeField]
		private ShopExtensionUnlockShopLevelFormula m_shopExtUnlockLevelFormula;

		[SerializeField]
		private ShopExtensionPriceFormula m_shopExtPriceFormula;

		[SerializeField]
		private List<int> m_shopExtensionMarketStoreLevels;

		[Header("Reserve Extensions")]
		[SerializeField]
		[Min(0f)]
		private int m_reserveExtMaxLevel;

		[SerializeField]
		[Min(0f)]
		private int m_reserveInitialUnlockLevel;

		[SerializeField]
		private List<ReserveExtensionUnlockShopLevelFormula> m_reserveExtUnlockLevelFormulas;

		[SerializeField]
		private ReserveExtensionPriceFormula m_reserveExtPriceFormula;

		[SerializeField]
		private List<int> m_reserveExtensionMarketStoreLevels;

		public static int ShopExtensionMaxLevel => CustomSettings<ShopExtensionSettings>.I.m_shopExtMaxLevel;

		public static int ReserveExtensionMaxLevel => CustomSettings<ShopExtensionSettings>.I.m_reserveExtMaxLevel;

		public static int ReserveExtensionInitialUnlockLevel => CustomSettings<ShopExtensionSettings>.I.m_reserveInitialUnlockLevel;

		public static bool CanExtendShop()
		{
			if (GameStateSettings.Demo)
			{
				return ShopExtensionSystem.ShopExtensionLevel < CustomSettings<ShopExtensionSettings>.I.m_demoMaxShopExtLevel;
			}
			return ShopExtensionSystem.ShopExtensionLevel < CustomSettings<ShopExtensionSettings>.I.m_shopExtMaxLevel;
		}

		public static int GetCurrentShopExtensionShopLevel()
		{
			return CustomSettings<ShopExtensionSettings>.I.m_shopExtUnlockLevelFormula.GetUnlockShopLevelForLevel(GetShopExtensionMarketStoreLevel(ShopExtensionSystem.ShopExtensionLevel));
		}

		public static float GetCurrentShopExtensionPrice()
		{
			return CustomSettings<ShopExtensionSettings>.I.m_shopExtPriceFormula.GetPriceForUnlockLevel(GetCurrentShopExtensionShopLevel());
		}

		public static int GetShopExtensionMarketStoreLevel(int shopExtLevel)
		{
			if (CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels.IsValid())
			{
				if (CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels.IsIndexValid(shopExtLevel))
				{
					return CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels[shopExtLevel];
				}
				List<int> shopExtensionMarketStoreLevels = CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels;
				return shopExtensionMarketStoreLevels[shopExtensionMarketStoreLevels.Count - 1] + shopExtLevel - CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels.Count + 1;
			}
			return shopExtLevel;
		}

		public static int GetShopExtensionLevelFromMarketStoreLevel(int marketStoreLevel)
		{
			if (!CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels.IsValid())
			{
				return marketStoreLevel;
			}
			int i = 0;
			int num = 0;
			for (; i < CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels.Count; i++)
			{
				num = CustomSettings<ShopExtensionSettings>.I.m_shopExtensionMarketStoreLevels[i];
				if (num > marketStoreLevel)
				{
					return i - 1;
				}
			}
			return marketStoreLevel - num + i - 1;
		}

		public static int GetNextShopExtensionLevel(int shopExtLevel)
		{
			return GetShopExtensionLevelFromMarketStoreLevel(GetShopExtensionMarketStoreLevel(shopExtLevel) + 1);
		}

		public static bool CanExtendReserve()
		{
			if (GameStateSettings.Demo)
			{
				return ShopExtensionSystem.ReserveExtensionLevel < CustomSettings<ShopExtensionSettings>.I.m_demoMaxReserveExtLevel;
			}
			return ShopExtensionSystem.ReserveExtensionLevel < CustomSettings<ShopExtensionSettings>.I.m_reserveExtMaxLevel;
		}

		public static int GetUnlockShopLevelForMarketStoreLevel(int marketStoreLevel)
		{
			int num = CustomSettings<ShopExtensionSettings>.I.m_reserveInitialUnlockLevel;
			for (int i = 0; i < CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas.Count; i++)
			{
				if (marketStoreLevel < CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas[i].NbIterations)
				{
					num += CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas[i].Incrementation * marketStoreLevel;
					break;
				}
				marketStoreLevel -= CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas[i].NbIterations;
				num += CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas[i].Incrementation * CustomSettings<ShopExtensionSettings>.I.m_reserveExtUnlockLevelFormulas[i].NbIterations;
			}
			return num;
		}

		public static int GetCurrentReserveExtensionShopLevel()
		{
			return GetUnlockShopLevelForMarketStoreLevel(GetReserveExtensionMarketStoreLevel(ShopExtensionSystem.ReserveExtensionLevel));
		}

		public static float GetCurrentReserveExtensionPrice()
		{
			return CustomSettings<ShopExtensionSettings>.I.m_reserveExtPriceFormula.GetPriceForUnlockLevel(GetCurrentReserveExtensionShopLevel());
		}

		public static int GetReserveExtensionMarketStoreLevel(int reserveExtLevel)
		{
			if (CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels.IsValid())
			{
				if (CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels.IsIndexValid(reserveExtLevel))
				{
					return CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels[reserveExtLevel];
				}
				List<int> reserveExtensionMarketStoreLevels = CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels;
				return reserveExtensionMarketStoreLevels[reserveExtensionMarketStoreLevels.Count - 1] + reserveExtLevel - CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels.Count + 1;
			}
			return reserveExtLevel;
		}

		public static int GetReserveExtensionLevelFromMarketStoreLevel(int marketStoreLevel)
		{
			if (!CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels.IsValid())
			{
				return marketStoreLevel;
			}
			int i = 0;
			int num = 0;
			for (; i < CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels.Count; i++)
			{
				num = CustomSettings<ShopExtensionSettings>.I.m_reserveExtensionMarketStoreLevels[i];
				if (num > marketStoreLevel)
				{
					return i - 1;
				}
			}
			return marketStoreLevel - num + i - 1;
		}

		public static int GetNextReserveExtensionLevel(int reserveExtLevel)
		{
			return GetReserveExtensionLevelFromMarketStoreLevel(GetReserveExtensionMarketStoreLevel(reserveExtLevel) + 1);
		}
	}
}

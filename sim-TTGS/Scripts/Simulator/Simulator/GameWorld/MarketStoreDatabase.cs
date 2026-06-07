using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	[CreateAssetMenu(fileName = "Market Store Database", menuName = "Tabletop/Excel Databases/Market Store")]
	public class MarketStoreDatabase : ExcelDatabase
	{
		protected enum ECSVSource
		{
			FIG_BOX = 0,
			PRODUCTS = 1,
			FURNITURES = 2
		}

		[Header("Market Store Database")]
		[SerializeField]
		private List<BaseShopBoxData> m_datas;

		private static MarketStoreDatabase _instance;

		private Dictionary<int, BaseShopBoxData> m_runtimeContent = new Dictionary<int, BaseShopBoxData>();

		public override EExcelDatabase Type => EExcelDatabase.MARKET_STORE;

		public override Type ContentType => typeof(BaseShopBoxData);

		private static MarketStoreDatabase Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = ExcelDatabaseSettings.GetDatabase(EExcelDatabase.MARKET_STORE) as MarketStoreDatabase;
					_instance.SetupContentDico();
				}
				return _instance;
			}
		}

		private void SetupContentDico()
		{
			m_runtimeContent.Clear();
			foreach (BaseShopBoxData data in m_datas)
			{
				if (data.Sellable)
				{
					m_runtimeContent.Add(data.UID, data);
					data.RegisterLocaVars();
				}
			}
		}

		public static BaseShopBoxData Get(int uid)
		{
			if (Instance.m_runtimeContent.TryGetValue(uid, out var value))
			{
				return value;
			}
			return null;
		}

		public static bool TryGet(int uid, out BaseShopBoxData data)
		{
			return Instance.m_runtimeContent.TryGetValue(uid, out data);
		}

		public static T Get<T>(int uid) where T : BaseShopBoxData
		{
			if (Instance.m_runtimeContent.TryGetValue(uid, out var value) && value is T result)
			{
				return result;
			}
			return null;
		}

		public static IEnumerable<BaseShopBoxData> Enumerate()
		{
			foreach (BaseShopBoxData data in Instance.m_datas)
			{
				yield return data;
			}
		}

		public static IEnumerable<T> Enumerate<T>() where T : BaseShopBoxData
		{
			foreach (BaseShopBoxData data in Instance.m_datas)
			{
				if (data is T val)
				{
					yield return val;
				}
			}
		}

		public static IEnumerable<BaseShopBoxData> GetDatasUnlockedAtLevel(int level)
		{
			foreach (BaseShopBoxData data in Instance.m_datas)
			{
				if (data.ShowOnUnlock && MarketStore.GetRequiredShopLevel(data) == level)
				{
					yield return data;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	[CreateAssetMenu(fileName = "Products Database", menuName = "Tabletop/Excel Databases/Products")]
	public class ProductDatabase : ExcelDatabase
	{
		protected enum ECSVSource
		{
			FIG_BOX = 0,
			PRODUCTS = 1
		}

		[SerializeField]
		private List<ProductData> m_datas;

		private static ProductDatabase _instance;

		protected Dictionary<int, ProductData> m_runtimeProducts = new Dictionary<int, ProductData>();

		public override EExcelDatabase Type => EExcelDatabase.PRODUCTS;

		public override Type ContentType => typeof(ProductData);

		private static ProductDatabase Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = ExcelDatabaseSettings.GetDatabase(EExcelDatabase.PRODUCTS) as ProductDatabase;
					_instance.SetupMiniaturesDico();
				}
				return _instance;
			}
		}

		private void SetupMiniaturesDico()
		{
			m_runtimeProducts.Clear();
			foreach (ProductData data in m_datas)
			{
				m_runtimeProducts.Add(data.UID, data);
			}
		}

		protected virtual ProductData InstanceGet(int uid)
		{
			if (m_runtimeProducts.TryGetValue(uid, out var value))
			{
				return value;
			}
			return null;
		}

		public static ProductData Get(int uid)
		{
			return Instance.InstanceGet(uid);
		}

		public static bool TryGet(int uid, out ProductData productData)
		{
			productData = Instance.InstanceGet(uid);
			return productData != null;
		}

		public static IEnumerable<ProductData> Enumerate()
		{
			foreach (ProductData data in Instance.m_datas)
			{
				yield return data;
			}
		}
	}
}

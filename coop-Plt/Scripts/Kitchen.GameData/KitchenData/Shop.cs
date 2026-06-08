using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Shop", menuName = "Kitchen/Shop Profile")]
	public class Shop : GameDataObject
	{
		public List<Appliance> Stock;

		public List<Decor> Decors;

		public ShopType Type;

		public int ItemsForSaleCount = 3;

		public int WallpapersForSaleCount = 6;

		protected override void InitialiseDefaults()
		{
			Stock = new List<Appliance>();
			Decors = new List<Decor>();
		}

		public override void SetupForGame()
		{
			if (Stock == null)
			{
				Stock = new List<Appliance>();
			}
			if (Decors == null)
			{
				Decors = new List<Decor>();
			}
		}
	}
}

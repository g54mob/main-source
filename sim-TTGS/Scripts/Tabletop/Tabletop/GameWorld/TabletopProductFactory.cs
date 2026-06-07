using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopProductFactory : ProductFactory
	{
		public override Product CreateProduct(BoughtProductInfo boughtProductInfo)
		{
			ProductData data = boughtProductInfo.Data;
			if (data.UID < 0)
			{
				MiniatureData miniatureData = MiniatureDatabase.Get(-data.UID);
				MiniatureProduct component = Object.Instantiate(miniatureData.Product).GetComponent<MiniatureProduct>();
				component.Init((MiniatureProductData)data, miniatureData, boughtProductInfo.Painted, boughtProductInfo.Price);
				return component;
			}
			return base.CreateProduct(boughtProductInfo);
		}
	}
}

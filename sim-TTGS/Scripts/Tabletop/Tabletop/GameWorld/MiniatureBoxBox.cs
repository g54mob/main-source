using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureBoxBox : StackableBox
	{
		protected override void FillStackable(ProductData data, int quantity)
		{
			if (data is MiniatureBoxProductData { Rarity: EMiniatureBoxRarity.LEGENDARY } miniatureBoxProductData && quantity == 9 && Random.value < MiniatureSettings.SuperLegendaryProba)
			{
				List<ProductData> list = new List<ProductData>();
				int num = Random.Range(0, quantity);
				for (int i = 0; i < quantity; i++)
				{
					if (i != num)
					{
						list.Add(data);
					}
					else
					{
						list.Add(MiniatureSettings.GetSuperLegendaryBox(miniatureBoxProductData.License));
					}
				}
				m_stack.PreciseFill(list);
			}
			else
			{
				base.FillStackable(data, quantity);
			}
		}
	}
}

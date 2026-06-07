using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class Stall : GroundFurniture
	{
		[SerializeField]
		private StallStand m_stand;

		public StallStand Stand => m_stand;

		public override void Load(int phase, SaveClass_Furnitures.FurnitureState state)
		{
			base.Load(phase, state);
			if (phase != 1 || !(state is SaveClass_TabletopFurnitures.StallState stallState))
			{
				return;
			}
			int num = 0;
			foreach (StallInteractable stallInteractable in Stand.GetStallInteractables())
			{
				if (stallState.miniatureProducts.IsIndexValid(num) && stallState.miniatureProducts[num].miniatureUID > 0 && ProductDatabase.Get(-stallState.miniatureProducts[num].miniatureUID) is MiniatureProductData productData)
				{
					stallInteractable.ManualPlaceMiniature(productData, stallState.miniatureProducts[num].painted);
				}
				num++;
			}
		}

		public override SaveClass_Furnitures.FurnitureState Save()
		{
			return new SaveClass_TabletopFurnitures.StallState(this);
		}
	}
}

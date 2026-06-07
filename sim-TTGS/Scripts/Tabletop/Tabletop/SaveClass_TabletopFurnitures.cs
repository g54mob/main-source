using System;
using System.Collections.Generic;
using Simulator;
using Tabletop.GameWorld;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_TabletopFurnitures : ISaveClass
	{
		[Serializable]
		public class StallState : SaveClass_Furnitures.FurnitureState
		{
			[Serializable]
			public struct StallProductState
			{
				public int miniatureUID;

				public bool painted;

				public StallProductState(int miniatureUID, bool painted)
				{
					this.miniatureUID = miniatureUID;
					this.painted = painted;
				}
			}

			public List<StallProductState> miniatureProducts;

			public StallState(Stall stall)
				: base(stall)
			{
				miniatureProducts = new List<StallProductState>();
				foreach (StallInteractable stallInteractable in stall.Stand.GetStallInteractables())
				{
					miniatureProducts.Add(new StallProductState(stallInteractable.HasAProduct(out var miniatureUID) ? miniatureUID : 0, stallInteractable.ProductPainted));
				}
			}
		}

		public List<StallState> stalls;

		public SaveClass_TabletopFurnitures()
		{
			stalls = new List<StallState>();
		}

		public void StartSaveProcess()
		{
			stalls = new List<StallState>();
		}

		public void SaveFurniture(StallState state)
		{
			stalls.Add(state);
		}

		public IEnumerable<SaveClass_Furnitures.FurnitureState> GetSavedFurnitures()
		{
			foreach (StallState stall in stalls)
			{
				yield return stall;
			}
		}
	}
}

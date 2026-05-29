using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class UI_MachineMgr_RepaintFurnitures : CTSBehaviour, IRepaint
	{
		[Inject(false)]
		private UsableFurnituresManager _furnituresManager;

		public void Repaint()
		{
			foreach (FurnitureInteractor item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<FurnitureInteractor>())
			{
				foreach (UsableFurnituresCategory value in _furnituresManager.Categories.Values)
				{
					if (!(item.Furniture.Parameters != value.CategoryData.AssociatedFurniture))
					{
						value.AddFurniture(item.Furniture);
					}
				}
			}
		}
	}
}

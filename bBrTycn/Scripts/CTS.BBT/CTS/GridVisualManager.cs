using CTS.Core;

namespace CTS
{
	public class GridVisualManager : CTSBehaviour
	{
		[Inject(false)]
		private ConstructionGrid _grid;

		protected override void OnAwake()
		{
			base.OnAwake();
			UI_ConstructionSystem.OnOpenBuildMode += OnConstructionChanged;
			UI_ConstructionSystem.OnCloseBuildMode += OnConstructionChanged;
			FurnitureShop.FurnitureShopStatusChanged += OnFurnitureShopChanged;
		}

		private void OnDestroy()
		{
			UI_ConstructionSystem.OnOpenBuildMode -= OnConstructionChanged;
			UI_ConstructionSystem.OnCloseBuildMode -= OnConstructionChanged;
			FurnitureShop.FurnitureShopStatusChanged -= OnFurnitureShopChanged;
		}

		private void OnConstructionChanged()
		{
			Recalculate();
		}

		private void OnFurnitureShopChanged(bool isOpen)
		{
			Recalculate();
		}

		public void Recalculate()
		{
			if (MonoSingleton<UI_ConstructionSystem>.Instance.IsOpen)
			{
				_grid.SetActive(active: true);
				return;
			}
			_grid.SetActive(active: false);
			_grid.ShowGridVisual(FurnitureShop.IsOpen);
		}
	}
}

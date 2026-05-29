using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_MachineMgr_FeatureIcon : UI_MachineMgr_MachinePanelFeature<IManageableFurniture>
	{
		[SerializeField]
		private Image _imageContainer;

		protected override void OnRepaint()
		{
			if (base._furniture is IManageableFurniture manageableFurniture)
			{
				_imageContainer.overrideSprite = manageableFurniture.UsableFurnitureCategoryData.CategoryIcon;
			}
		}

		protected override bool CanBeDisplayedForFurniture(IManageableFurniture furniture)
		{
			return true;
		}

		protected override void OnFurnitureSet(IManageableFurniture furniture)
		{
		}

		protected override void OnFurnitureUnset(IManageableFurniture furniture)
		{
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_MachineMgr_FeatureBackgroundImage : UI_MachineMgr_MachinePanelFeature<IManageableFurniture>
	{
		[SerializeField]
		private Image _image;

		protected override void OnRepaint()
		{
			if (base._furniture is IManageableFurniture manageableFurniture)
			{
				_image.overrideSprite = manageableFurniture.UsableFurnitureCategoryData.CategoryHeader;
			}
		}

		protected override bool CanBeDisplayedForFurniture(IManageableFurniture furniture)
		{
			return furniture.UsableFurnitureCategoryData;
		}

		protected override void OnFurnitureSet(IManageableFurniture furniture)
		{
		}

		protected override void OnFurnitureUnset(IManageableFurniture furniture)
		{
		}
	}
}

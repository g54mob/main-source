using NSMedieval.State;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class ResourceIconItemView : LayoutGroupItemView
	{
		private static readonly int iconIndex = 0;

		private static readonly int backgroundIndex = 1;

		public void SetData(string resourceId)
		{
			string iconPath = ResourceUtils.GetIconPath(resourceId);
			string iconColor = ResourceUtils.GetIconColor(resourceId);
			if (string.IsNullOrEmpty(iconColor))
			{
				SetImage(iconIndex, iconPath);
			}
			else
			{
				SetImage(iconIndex, iconPath, iconColor);
			}
			string iconBackgroundPath = ResourceUtils.GetIconBackgroundPath(resourceId);
			if (iconBackgroundPath != null && !string.IsNullOrEmpty(iconBackgroundPath))
			{
				base.GroupItems[backgroundIndex].SetActive(value: true);
				SetImage(backgroundIndex, iconBackgroundPath);
			}
			else
			{
				base.GroupItems[backgroundIndex].SetActive(value: false);
			}
		}

		public void SetData(EquipmentInstance equipment, HumanoidInstance humanoidOwner)
		{
			if (equipment != null)
			{
				string iD = equipment.Blueprint.Resource.GetID();
				SetData(iD);
				if (base.TooltipNew is EquipmentTooltipView equipmentTooltipView)
				{
					equipmentTooltipView.SetupData(equipment, humanoidOwner);
				}
			}
		}
	}
}

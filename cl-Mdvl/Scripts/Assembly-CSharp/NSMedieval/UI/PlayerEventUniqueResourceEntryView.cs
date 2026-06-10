using System;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.Model;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class PlayerEventUniqueResourceEntryView : LayoutGroupItemView
	{
		private readonly int iconIndex;

		private readonly int removeButtonIndex = 1;

		public void SetData(KeyValuePair<string, Resource> groupResourcePair, Action<KeyValuePair<string, Resource>, bool> removeCallback)
		{
			string iconPath = ResourceUtils.GetIconPath(groupResourcePair.Value.GetID());
			string iconColor = ResourceUtils.GetIconColor(groupResourcePair.Value.GetID());
			if (string.IsNullOrEmpty(iconColor))
			{
				SetImage(iconIndex, iconPath);
			}
			else
			{
				SetImage(iconIndex, iconPath, iconColor);
			}
			base.GroupItems[removeButtonIndex].GetComponent<SoundButton>().AddCleanListener(delegate
			{
				removeCallback(groupResourcePair, arg2: false);
			});
			base.TooltipNew.ClearLines();
			base.TooltipNew.SetLines(ResourceUtils.GetTooltipData(groupResourcePair.Value.GetID()));
		}
	}
}

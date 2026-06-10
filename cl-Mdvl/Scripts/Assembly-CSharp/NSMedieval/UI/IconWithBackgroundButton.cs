using NSEipix.View.UI;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class IconWithBackgroundButton : LayoutGroupItemView
	{
		private int buttonIndex;

		private int iconIndex = 1;

		private int iconBackgroundIndex = 2;

		private string iconPath;

		public string Name => iconPath;

		public SoundButton Button => base.GroupItems[buttonIndex].GetComponent<SoundButton>();

		public void SetData(string iconPath, string iconBackgroundPath, string iconColor)
		{
			this.iconPath = iconPath;
			base.GroupItems[iconBackgroundIndex].gameObject.SetActive(!string.IsNullOrEmpty(iconBackgroundPath));
			SetImage(iconIndex, iconPath, iconColor);
			if (!string.IsNullOrEmpty(iconBackgroundPath))
			{
				SetImage(iconBackgroundIndex, iconBackgroundPath);
			}
		}

		public void AddButtonListener(UnityAction callback)
		{
			Button.AddCleanListener(callback);
		}
	}
}

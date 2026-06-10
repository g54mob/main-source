using System;
using NSEipix.View.UI;
using NSMedieval.UI.Utils;
using TMPro;

namespace NSMedieval.UI
{
	public class AlmanacGroupLayoutItemView : LayoutGroupItemView
	{
		private int iconIndex;

		private int textIndex = 1;

		private int buttonIndex = 2;

		private int shownImageIndex = 3;

		private SoundButton button;

		private SoundButton Button => button = ((!button) ? base.GroupItems[buttonIndex].GetComponent<SoundButton>() : button);

		public void SetData(string textLocKey, bool isShown, Action callback)
		{
			base.GroupItems[textIndex].GetComponent<TMP_Text>().SetText(textLocKey.ToLocalized());
			base.GroupItems[shownImageIndex].SetActive(isShown);
			Button.AddCleanListener(delegate
			{
				callback();
			});
		}

		public void SetImageData(string iconPath, string iconColor = "")
		{
			SetImage(iconIndex, iconPath, iconColor);
		}

		private void Start()
		{
			Button.ButtonClickSound = "UI_AlmanacClick";
			Button.ButtonHoverSound = "UI_AlmanacHover";
		}
	}
}

using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Model;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Research
{
	[RequireComponent(typeof(ItemToUnlockTooltip))]
	public class UnlocksView : NSEipix.Base.View
	{
		[SerializeField]
		private string itemID;

		[SerializeField]
		private Image image;

		[SerializeField]
		private SoundButton button;

		private string almanacLink;

		public string ItemID => itemID;

		public void Setup(string itemID, LocKeys[] locKeys, string iconPath)
		{
			this.itemID = itemID;
			image.sprite = AssetUtils.GetSprite(iconPath);
			almanacLink = UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(locKeys));
			button.AddCleanListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			if (!(almanacLink == string.Empty))
			{
				MonoSingleton<UIController>.Instance.ShowAlmanacEntry(almanacLink);
			}
		}
	}
}

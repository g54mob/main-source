using System;
using NSEipix.View.UI;
using NSMedieval.UI.Utils;
using TMPro;

namespace NSMedieval.UI
{
	public class AlmanacSearchSubgroupItemView : LayoutGroupItemView
	{
		private int buttonIndex;

		private int textIndex = 1;

		private int shownImageIndex = 2;

		private TMP_Text textObject;

		public SoundButton Button => base.GroupItems[buttonIndex].GetComponent<SoundButton>();

		public string EntryId { get; private set; }

		public TMP_Text TextObject => textObject = ((textObject == null) ? base.GroupItems[textIndex].GetComponent<TMP_Text>() : textObject);

		public void SetData(string id, string textLocKey, bool isShown, Action callback)
		{
			EntryId = id;
			TextObject.SetText(textLocKey.ToLocalized());
			SetShown(isShown);
			Button.AddCleanListener(delegate
			{
				callback();
			});
		}

		public void SetShown(bool isShown)
		{
			base.GroupItems[shownImageIndex].SetActive(isShown);
		}

		private void Start()
		{
			Button.ButtonClickSound = "UI_AlmanacClick";
			Button.ButtonHoverSound = "UI_AlmanacHover";
		}
	}
}

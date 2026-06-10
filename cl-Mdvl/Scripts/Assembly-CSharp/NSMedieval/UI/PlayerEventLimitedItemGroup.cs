using NSEipix.View.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PlayerEventLimitedItemGroup : LayoutGroupItemView
	{
		[SerializeField]
		protected TMP_Text itemTitle;

		[SerializeField]
		protected LayoutGroupView itemGroupView;

		[SerializeField]
		protected SoundButton addNewButton;

		public void SetTitle(string title)
		{
			itemTitle.SetText(title);
		}
	}
}

using TMPro;

namespace NSMedieval.UI
{
	public class PlayerEventResourceSettingsView : LayoutGroupItemView
	{
		private readonly int titleIndex;

		private readonly int listParentIndex = 1;

		public TMP_Text Title => base.GroupItems[titleIndex].GetComponent<TMP_Text>();

		public LayoutGroupView ListParent => base.GroupItems[listParentIndex].GetComponent<LayoutGroupView>();
	}
}

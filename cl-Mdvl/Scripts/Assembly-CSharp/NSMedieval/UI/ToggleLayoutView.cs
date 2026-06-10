using NSEipix.View.UI;
using TMPro;

namespace NSMedieval.UI
{
	public class ToggleLayoutView : LayoutGroupItemView
	{
		private int toggleIndex;

		private int textIndex = 1;

		public CustomToggle Toggle => base.GroupItems[toggleIndex].GetComponent<CustomToggle>();

		public TMP_Text TextObject => base.GroupItems[textIndex].GetComponent<TMP_Text>();

		public void SetText(string text)
		{
			SetText(textIndex, text);
		}
	}
}

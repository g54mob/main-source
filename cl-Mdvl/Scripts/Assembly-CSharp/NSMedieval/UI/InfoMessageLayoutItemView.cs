using NSEipix.View.UI;

namespace NSMedieval.UI
{
	public class InfoMessageLayoutItemView : LayoutGroupItemView
	{
		private int buttonIndex = 1;

		private int closeIndex = 3;

		private SoundButton button;

		private SoundButton closeButton;

		public SoundButton GetButton => button = ((button == null) ? base.GroupItems[buttonIndex].GetComponent<SoundButton>() : button);

		public SoundButton CloseButton => closeButton = ((closeButton == null) ? base.GroupItems[closeIndex].GetComponent<SoundButton>() : closeButton);

		public void SetData(string id, string text)
		{
			SetText(text, id);
		}
	}
}

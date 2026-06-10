using NSEipix.View.UI;

namespace NSMedieval.UI
{
	public class SaveLayoutItemView : LayoutGroupItemView
	{
		private int fileNameIndex;

		private int lastPlayedIndex = 1;

		private int villageNameIndex = 2;

		private int overrideButtonIndex = 3;

		private int deleteButtonIndex = 4;

		private SoundButton overrideButton;

		private SoundButton deleteButton;

		public SoundButton OverrideButton => overrideButton = ((overrideButton == null) ? base.GroupItems[overrideButtonIndex].GetComponent<SoundButton>() : overrideButton);

		public SoundButton DeleteButton => deleteButton = ((deleteButton == null) ? base.GroupItems[deleteButtonIndex].GetComponent<SoundButton>() : deleteButton);

		public void Setup(VillageSaveInfo profile)
		{
			SetText(fileNameIndex, profile.FileName);
			SetText(lastPlayedIndex, profile.LastPlayedLocalizedString);
			SetText(villageNameIndex, profile.VillageName);
		}
	}
}

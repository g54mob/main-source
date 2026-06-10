namespace NSMedieval.UI
{
	public class TitleDescriptionLayoutItemView : LayoutGroupItemView
	{
		private readonly int titleIndex;

		private readonly int descriptionIndex = 1;

		public void SetBasicData(string title, string description)
		{
			SetText(titleIndex, title);
			SetText(descriptionIndex, description);
		}
	}
}

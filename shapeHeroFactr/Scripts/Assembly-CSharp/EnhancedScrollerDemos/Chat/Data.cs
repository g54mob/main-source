namespace EnhancedScrollerDemos.Chat
{
	public class Data
	{
		public enum CellType
		{
			Spacer = 0,
			MyText = 1,
			OtherText = 2
		}

		public CellType cellType;

		public string someText;

		public float cellSize;
	}
}

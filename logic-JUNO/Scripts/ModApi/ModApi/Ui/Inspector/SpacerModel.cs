namespace ModApi.Ui.Inspector
{
	public class SpacerModel : ItemModel
	{
		public bool DrawImage { get; private set; }

		public int Height { get; private set; }

		public SpacerModel(int height = 15, bool drawImage = true)
		{
			Height = height;
			DrawImage = drawImage;
		}
	}
}

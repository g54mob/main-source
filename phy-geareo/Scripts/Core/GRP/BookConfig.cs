using Rhizomatic;

namespace GRP
{
	public class BookConfig : Config
	{
		public bool _fetch;

		public BookHeaderConfig[] headers;

		public BookPaperConfig[] papers;

		private void OnValidate()
		{
		}

		public BookPaperContent GetContent(int index)
		{
			return null;
		}
	}
}

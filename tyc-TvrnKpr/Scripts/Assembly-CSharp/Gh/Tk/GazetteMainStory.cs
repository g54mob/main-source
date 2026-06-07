namespace Gh.Tk
{
	public class GazetteMainStory : IPersistable
	{
		public string headline;

		public string content;

		public string image;

		public GazetteMainStory()
		{
		}

		public GazetteMainStory(string headline, string content, string image)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}

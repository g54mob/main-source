using System.Collections.Generic;

namespace VampireSurvivors.Data
{
	public class AlbumData
	{
		public bool isUnlocked { get; set; }

		public string title { get; set; }

		public string icon { get; set; }

		public List<BgmType> trackList { get; set; }

		public ContentGroupType contentGroupType { get; set; }
	}
}

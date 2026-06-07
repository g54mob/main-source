using System.Collections.ObjectModel;

namespace Jundroo.ModTools.Core
{
	public class SteamPublishInfo
	{
		public string Description { get; set; }

		public string Language { get; set; }

		public string PreviewPath { get; set; }

		public ReadOnlyCollection<string> Tags { get; set; }

		public string Title { get; set; }

		public SteamVisibility Visibility { get; set; }
	}
}

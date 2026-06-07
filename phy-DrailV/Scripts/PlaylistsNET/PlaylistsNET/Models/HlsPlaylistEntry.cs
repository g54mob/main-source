using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public abstract class HlsPlaylistEntry : BasePlaylistEntry
	{
		public Dictionary<string, string> CustomProperties { get; set; }

		public List<string> Comments { get; set; }

		public HlsPlaylistEntry()
		{
			CustomProperties = new Dictionary<string, string>();
			Comments = new List<string>();
		}
	}
}

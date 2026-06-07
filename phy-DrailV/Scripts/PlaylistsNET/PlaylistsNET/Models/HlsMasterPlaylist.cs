using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public class HlsMasterPlaylist : HlsPlaylist<HlsMasterPlaylistEntry>
	{
		public List<string> Media { get; set; }

		public List<string> IFrameStreamInf { get; set; }

		public List<string> SessionData { get; set; }

		public List<string> SessionKey { get; set; }

		public HlsMasterPlaylist()
		{
			Media = new List<string>();
			IFrameStreamInf = new List<string>();
			SessionData = new List<string>();
			SessionData = new List<string>();
		}
	}
}

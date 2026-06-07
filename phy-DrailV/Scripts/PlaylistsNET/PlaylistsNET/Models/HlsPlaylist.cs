using System;
using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public abstract class HlsPlaylist<T> : BasePlaylist<T> where T : HlsPlaylistEntry
	{
		public string Name { get; set; }

		public List<string> Comments { get; set; }

		public int Version { get; set; }

		[Obsolete("The EXT-X-ALLOW-CACHE tag was removed in protocol version 7.")]
		public string AllowCache { get; set; }

		public HlsPlaylist()
		{
			Comments = new List<string>();
		}
	}
}

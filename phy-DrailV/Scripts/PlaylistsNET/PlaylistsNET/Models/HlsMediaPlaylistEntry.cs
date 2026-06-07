using System;

namespace PlaylistsNET.Models
{
	public class HlsMediaPlaylistEntry : HlsPlaylistEntry
	{
		public int Duration { get; set; }

		public string Title { get; set; }

		public int MediaSequence { get; set; }

		public bool Discontinuity { get; set; }

		public string ByteRange { get; set; }

		public string Key { get; set; }

		public string Map { get; set; }

		public DateTime? ProgramDateTime { get; set; }
	}
}

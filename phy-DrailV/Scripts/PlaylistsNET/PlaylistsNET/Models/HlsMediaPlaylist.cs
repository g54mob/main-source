namespace PlaylistsNET.Models
{
	public class HlsMediaPlaylist : HlsPlaylist<HlsMediaPlaylistEntry>
	{
		public int MediaSequence { get; set; }

		public int? TargetDuration { get; set; }

		public int? DiscontinuitySequence { get; set; }

		public string PlaylistType { get; set; }

		public bool EndList { get; set; }

		public bool IFramesOnly { get; set; }
	}
}

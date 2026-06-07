namespace PlaylistsNET.Models
{
	public class PlsPlaylist : BasePlaylist<PlsPlaylistEntry>
	{
		public int Version { get; set; }

		public int NumberOfEntries => base.PlaylistEntries.Count;

		public PlsPlaylist()
		{
			Version = 2;
		}
	}
}

using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public class BasePlaylist<T> : IBasePlaylist where T : BasePlaylistEntry
	{
		public List<T> PlaylistEntries { get; set; }

		public string Path { get; set; }

		public string FileName { get; set; }

		public List<string> GetTracksPaths()
		{
			List<string> list = new List<string>();
			foreach (T playlistEntry in PlaylistEntries)
			{
				list.Add(playlistEntry.Path);
			}
			return list;
		}

		public BasePlaylist()
		{
			PlaylistEntries = new List<T>();
		}
	}
}

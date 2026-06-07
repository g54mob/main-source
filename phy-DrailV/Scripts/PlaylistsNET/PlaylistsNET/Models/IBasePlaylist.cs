using System.Collections.Generic;

namespace PlaylistsNET.Models
{
	public interface IBasePlaylist
	{
		string Path { get; set; }

		string FileName { get; set; }

		List<string> GetTracksPaths();
	}
}

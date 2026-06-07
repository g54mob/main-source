using System;
using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class PlaylistParserFactory
	{
		public static IPlaylistParser<IBasePlaylist> GetPlaylistParser(string fileType)
		{
			fileType = fileType.Trim('.');
			try
			{
				return GetPlaylistParser((PlaylistType)Enum.Parse(typeof(PlaylistType), fileType, ignoreCase: true));
			}
			catch (ArgumentException)
			{
				throw new ArgumentException("Unsupported playlist extension: " + fileType);
			}
		}

		public static IPlaylistParser<IBasePlaylist> GetPlaylistParser(PlaylistType playlistType)
		{
			switch (playlistType)
			{
			case PlaylistType.M3U:
			case PlaylistType.M3U8:
				return new M3uContent();
			case PlaylistType.HLSMaster:
				return new HlsMasterContent();
			case PlaylistType.HlsMedia:
				return new HlsMediaContent();
			case PlaylistType.PLS:
				return new PlsContent();
			case PlaylistType.WPL:
				return new WplContent();
			case PlaylistType.ZPL:
				return new ZplContent();
			default:
				throw new ArgumentException($"Unsupported playlist type: {playlistType}");
			}
		}
	}
}

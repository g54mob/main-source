using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class M3uContent : IPlaylistParser<M3uPlaylist>, IPlaylistWriter<M3uPlaylist>
	{
		public string ToText(M3uPlaylist playlist)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (playlist.IsExtended)
			{
				stringBuilder.AppendLine("#EXTM3U");
			}
			foreach (string comment in playlist.Comments)
			{
				stringBuilder.AppendLine("#" + comment);
			}
			foreach (M3uPlaylistEntry playlistEntry in playlist.PlaylistEntries)
			{
				if (playlist.IsExtended)
				{
					foreach (string comment2 in playlistEntry.Comments)
					{
						stringBuilder.AppendLine("#" + comment2);
					}
					if (!string.IsNullOrEmpty(playlistEntry.Album))
					{
						stringBuilder.Append("#EXTALB:").Append(playlistEntry.Album).AppendLine();
					}
					if (!string.IsNullOrEmpty(playlistEntry.AlbumArtist))
					{
						stringBuilder.Append("#EXTART:").Append(playlistEntry.AlbumArtist).AppendLine();
					}
					if (playlistEntry.CustomProperties != null)
					{
						foreach (KeyValuePair<string, string> item in playlistEntry.CustomProperties.Where((KeyValuePair<string, string> x) => !string.IsNullOrEmpty(x.Value)))
						{
							stringBuilder.AppendLine("#" + item.Key + ":" + item.Value);
						}
					}
					stringBuilder.AppendLine($"#EXTINF:{(int)playlistEntry.Duration.TotalSeconds},{playlistEntry.Title}");
				}
				stringBuilder.AppendLine(playlistEntry.Path);
			}
			return stringBuilder.ToString().Trim();
		}

		public M3uPlaylist GetFromStream(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			return GetFromString(streamReader.ReadToEnd());
		}

		public M3uPlaylist GetFromString(string playlistString)
		{
			List<string> list = (from x in playlistString.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToList();
			if (list[0] != "#EXTM3U")
			{
				return GetM3u(list);
			}
			list.RemoveAt(0);
			if (!list.Any((string x) => Regex.IsMatch(x, "^#EXT-X-VERSION:\\d$")))
			{
				return GetExtM3u(list);
			}
			throw new FormatException("Playlist appears to be a HLS playlist. Use the HLS parser instead.");
		}

		private M3uPlaylist GetM3u(IEnumerable<string> playlistLines)
		{
			M3uPlaylist m3uPlaylist = new M3uPlaylist();
			foreach (string playlistLine in playlistLines)
			{
				if (Regex.Match(playlistLine, "^#(.*)$").Success)
				{
					m3uPlaylist.Comments.Add(playlistLine);
					continue;
				}
				m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry
				{
					Path = playlistLine,
					Title = "",
					Album = "",
					AlbumArtist = ""
				});
			}
			return m3uPlaylist;
		}

		private M3uPlaylist GetExtM3u(IEnumerable<string> playlistLines)
		{
			M3uPlaylist m3uPlaylist = new M3uPlaylist
			{
				IsExtended = true
			};
			M3uPlaylistEntry m3uPlaylistEntry = new M3uPlaylistEntry
			{
				Album = "",
				AlbumArtist = "",
				Title = ""
			};
			foreach (string playlistLine in playlistLines)
			{
				Match match = Regex.Match(playlistLine, "^#EXTINF:(-?\\d*),(.*)$");
				if (match.Success)
				{
					double value = (string.IsNullOrEmpty(match.Groups[1].Value) ? 0.0 : double.Parse(match.Groups[1].Value));
					m3uPlaylistEntry.Duration = TimeSpan.FromSeconds(value);
					m3uPlaylistEntry.Title = match.Groups[2].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#(EXTALB):(.*)$");
				if (match.Success)
				{
					m3uPlaylistEntry.Album = match.Groups[2].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#(EXTART):(.*)$");
				if (match.Success)
				{
					m3uPlaylistEntry.AlbumArtist = match.Groups[2].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#(EXT.*):(.*)$");
				if (match.Success)
				{
					m3uPlaylistEntry.CustomProperties.Add(match.Groups[1].Value, match.Groups[2].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#(?!EXT)(.*)$");
				if (match.Success)
				{
					m3uPlaylistEntry.Comments.Add(match.Groups[1].Value);
					continue;
				}
				m3uPlaylistEntry.Path = WebUtility.UrlDecode(playlistLine);
				m3uPlaylist.PlaylistEntries.Add(m3uPlaylistEntry);
				m3uPlaylistEntry = new M3uPlaylistEntry();
				m3uPlaylistEntry.Album = "";
				m3uPlaylistEntry.AlbumArtist = "";
				m3uPlaylistEntry.Title = "";
			}
			return m3uPlaylist;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class HlsMasterContent : IPlaylistParser<HlsMasterPlaylist>
	{
		public HlsMasterPlaylist GetFromStream(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			return GetFromString(streamReader.ReadToEnd());
		}

		public HlsMasterPlaylist GetFromString(string playlistString)
		{
			List<string> list = (from x in playlistString.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToList();
			if (list[0] != "#EXTM3U")
			{
				throw new FormatException("Playlist missing required EXTM3U tag.");
			}
			list.RemoveAt(0);
			if (!list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-VERSION:\\d$")).Any())
			{
				throw new FormatException("Playlist missing required EXT-X-VERSION tag.");
			}
			if (list.Where((string x) => Regex.IsMatch(x, "^#EXTINF:.+$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-TARGETDURATION:(\\d*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-MEDIA-SEQUENCE:(\\d*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-DISCONTINUITY-SEQUENCE:(\\d*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^EXT-X-PLAYLIST-TYPE:(.*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-ENDLIST$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-I-FRAMES-ONLY$")).Any())
			{
				throw new FormatException("Playlist appears to be a HLS Media playlist.");
			}
			return GetMasterHls(list);
		}

		private HlsMasterPlaylist GetMasterHls(List<string> playlistLines)
		{
			HlsMasterPlaylist hlsMasterPlaylist = new HlsMasterPlaylist();
			HlsMasterPlaylistEntry hlsMasterPlaylistEntry = new HlsMasterPlaylistEntry();
			foreach (string playlistLine in playlistLines)
			{
				Match match = Regex.Match(playlistLine, "^#EXT-X-VERSION:(\\d*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.Version = int.Parse(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-ALLOW-CACHE:(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.AllowCache = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-MEDIA:(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.Media.Add(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-I-FRAME-STREAM-INF:(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.IFrameStreamInf.Add(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-SESSION-DATA:(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.SessionData.Add(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-SESSION-KEY:(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylist.SessionKey.Add(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-STREAM-INF:(.*)$");
				if (match.Success)
				{
					foreach (Match item in Regex.Matches(match.Groups[1].Value, "([-A-Z]+)=(\"[^\"]+|[^,]+)"))
					{
						string text = item.Groups[2].Value.Trim('"');
						switch (item.Groups[1].Value)
						{
						case "PROGRAM-ID":
							hlsMasterPlaylistEntry.ProgramId = int.Parse(text);
							break;
						case "BANDWIDTH":
							hlsMasterPlaylistEntry.Bandwidth = int.Parse(text);
							break;
						case "AVERAGE-BANDWIDTH":
							hlsMasterPlaylistEntry.AverageBandwidth = int.Parse(text);
							break;
						case "CODECS":
							hlsMasterPlaylistEntry.Codecs.AddRange(text.Split(','));
							break;
						case "RESOLUTION":
							hlsMasterPlaylistEntry.Resolution = text;
							break;
						case "FRAME-RATE":
							hlsMasterPlaylistEntry.FrameRate = double.Parse(text);
							break;
						case "HDCP-LEVEL":
							hlsMasterPlaylistEntry.HdcpLevel = text;
							break;
						case "AUDIO":
							hlsMasterPlaylistEntry.Audio = text;
							break;
						case "VIDEO":
							hlsMasterPlaylistEntry.Video = text;
							break;
						case "SUBTITLES":
							hlsMasterPlaylistEntry.Subtitles = text;
							break;
						case "CLOSED-CAPTIONS":
							hlsMasterPlaylistEntry.ClosedCaptions = text;
							break;
						default:
							throw new FormatException("STREAM-INF tag contains unknown attribute: " + item.Groups[1].Value);
						}
					}
					continue;
				}
				match = Regex.Match(playlistLine, "^#(EXT.*):(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylistEntry.CustomProperties.Add(match.Groups[1].Value, match.Groups[2].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#(?!EXT)(.*)$");
				if (match.Success)
				{
					hlsMasterPlaylistEntry.Comments.Add(match.Groups[1].Value);
					continue;
				}
				hlsMasterPlaylistEntry.Path = playlistLine;
				hlsMasterPlaylist.PlaylistEntries.Add(hlsMasterPlaylistEntry);
				hlsMasterPlaylistEntry = new HlsMasterPlaylistEntry();
			}
			return hlsMasterPlaylist;
		}
	}
}

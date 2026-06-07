using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class HlsMediaContent : IPlaylistParser<HlsMediaPlaylist>
	{
		public HlsMediaPlaylist GetFromStream(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			return GetFromString(streamReader.ReadToEnd());
		}

		public HlsMediaPlaylist GetFromString(string playlistString)
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
			if (list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-STREAM-INF:.+$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-MEDIA:(.*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-I-FRAME-STREAM-INF:(.*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-SESSION-DATA:(.*)$")).Any() || list.Where((string x) => Regex.IsMatch(x, "^#EXT-X-SESSION-KEY:(.*)$")).Any())
			{
				throw new FormatException("Playlist appears to be a HLS Master playlist.");
			}
			return GetMediaHls(list);
		}

		private HlsMediaPlaylist GetMediaHls(List<string> playlistLines)
		{
			HlsMediaPlaylist hlsMediaPlaylist = new HlsMediaPlaylist();
			HlsMediaPlaylistEntry hlsMediaPlaylistEntry = new HlsMediaPlaylistEntry();
			foreach (string playlistLine in playlistLines)
			{
				Match match = Regex.Match(playlistLine, "^#EXT-X-VERSION:(\\d*)$");
				if (match.Success)
				{
					hlsMediaPlaylist.Version = int.Parse(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-ALLOW-CACHE:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylist.AllowCache = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-TARGETDURATION:(\\d*)$");
				if (match.Success)
				{
					hlsMediaPlaylist.TargetDuration = int.Parse(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-MEDIA-SEQUENCE:(\\d*)$");
				if (match.Success)
				{
					int mediaSequence = (hlsMediaPlaylist.MediaSequence = int.Parse(match.Groups[1].Value));
					hlsMediaPlaylistEntry.MediaSequence = mediaSequence;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-DISCONTINUITY-SEQUENCE:(\\d*)$");
				if (match.Success)
				{
					hlsMediaPlaylist.DiscontinuitySequence = int.Parse(match.Groups[1].Value);
					continue;
				}
				match = Regex.Match(playlistLine, "^EXT-X-PLAYLIST-TYPE:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylist.PlaylistType = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-ENDLIST$");
				if (match.Success)
				{
					hlsMediaPlaylist.EndList = true;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-I-FRAMES-ONLY$");
				if (match.Success)
				{
					hlsMediaPlaylist.IFramesOnly = true;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-KEY:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylistEntry.Key = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-MAP:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylistEntry.Map = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-BYTERANGE:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylistEntry.ByteRange = match.Groups[1].Value;
					continue;
				}
				match = Regex.Match(playlistLine, "^#EXT-X-PROGRAM-DATE-TIME:(.*)$");
				if (match.Success)
				{
					hlsMediaPlaylistEntry.ProgramDateTime = DateTime.Parse(match.Groups[1].Value).ToUniversalTime();
					continue;
				}
				match = Regex.Match(playlistLine, "^#(EXT-X-DISCONTINUITY)$");
				if (match.Success)
				{
					hlsMediaPlaylistEntry.Discontinuity = true;
					continue;
				}
				Match match2 = Regex.Match(playlistLine, "^#EXTINF:(-?\\d*),(.*)$");
				if (match2.Success)
				{
					hlsMediaPlaylistEntry.Duration = ((!string.IsNullOrEmpty(match2.Groups[1].Value)) ? int.Parse(match2.Groups[1].Value) : 0);
					hlsMediaPlaylistEntry.Title = match2.Groups[2].Value;
					continue;
				}
				match2 = Regex.Match(playlistLine, "^#(EXT.*):(.*)$");
				if (match2.Success)
				{
					hlsMediaPlaylistEntry.CustomProperties.Add(match2.Groups[1].Value, match2.Groups[2].Value);
					continue;
				}
				match2 = Regex.Match(playlistLine, "^#(?!EXT)(.*)$");
				if (match2.Success)
				{
					hlsMediaPlaylistEntry.Comments.Add(match2.Groups[1].Value);
					continue;
				}
				hlsMediaPlaylistEntry.Path = playlistLine;
				hlsMediaPlaylist.PlaylistEntries.Add(hlsMediaPlaylistEntry);
				hlsMediaPlaylistEntry = new HlsMediaPlaylistEntry
				{
					MediaSequence = hlsMediaPlaylistEntry.MediaSequence + 1,
					Key = hlsMediaPlaylistEntry.Key,
					Map = hlsMediaPlaylistEntry.Map
				};
			}
			return hlsMediaPlaylist;
		}
	}
}

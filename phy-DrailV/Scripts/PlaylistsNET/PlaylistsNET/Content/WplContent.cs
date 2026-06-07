using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using PlaylistsNET.Models;
using PlaylistsNET.Utils;

namespace PlaylistsNET.Content
{
	public class WplContent : IPlaylistParser<WplPlaylist>, IPlaylistWriter<WplPlaylist>
	{
		public string ToText(WplPlaylist playlist)
		{
			StringBuilder stringBuilder = new StringBuilder();
			XElement content = CreateSeqWithMedia(playlist);
			XElement xElement = new XElement("body");
			xElement.Add(content);
			XElement xElement2 = new XElement("head");
			if (!string.IsNullOrEmpty(playlist.Author))
			{
				XElement content2 = new XElement("author", playlist.Author);
				xElement2.Add(content2);
			}
			if (!string.IsNullOrEmpty(playlist.Guid))
			{
				XElement content3 = new XElement("guid", playlist.Guid);
				xElement2.Add(content3);
			}
			if (!string.IsNullOrEmpty(playlist.Generator))
			{
				xElement2.Add(CreateMeta("Generator", playlist.Generator));
			}
			if (playlist.ItemCount > 0)
			{
				xElement2.Add(CreateMeta("ItemCount", playlist.ItemCount.ToString()));
			}
			if (playlist.TotalDuration > TimeSpan.Zero)
			{
				xElement2.Add(CreateMeta("totalDuration", ((int)playlist.TotalDuration.TotalMilliseconds).ToString()));
			}
			XElement content4 = new XElement("title", playlist.Title);
			xElement2.Add(content4);
			XElement xElement3 = new XElement("smil");
			xElement3.Add(xElement2);
			xElement3.Add(xElement);
			XDocument xDocument = new XDocument();
			xDocument.Add(xElement3);
			stringBuilder.AppendLine("<?wpl version=\"1.0\"?>");
			stringBuilder.Append(xDocument.ToString());
			return stringBuilder.ToString();
		}

		public WplPlaylist GetFromStream(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			return GetFromString(streamReader.ReadToEnd());
		}

		public WplPlaylist GetFromString(string playlistString)
		{
			WplPlaylist wplPlaylist = new WplPlaylist();
			XElement xElement = XDocument.Parse(playlistString).Element("smil");
			XElement xElement2 = xElement.Element("head");
			wplPlaylist.Author = ((string)xElement2.Element("author")) ?? "";
			wplPlaylist.Guid = ((string)xElement2.Element("guid")) ?? "";
			wplPlaylist.Title = ((string)xElement2.Element("title")) ?? "";
			foreach (XElement item in xElement2.Elements("meta"))
			{
				string text = PlaylistsNET.Utils.Utils.UnEscape(item.Attribute("name")?.Value);
				string text2 = PlaylistsNET.Utils.Utils.UnEscape(item.Attribute("content")?.Value);
				switch (text)
				{
				case "Generator":
					wplPlaylist.Generator = text2;
					break;
				case "ItemCount":
				{
					int result2 = 0;
					int.TryParse(text2, out result2);
					wplPlaylist.ItemCount = result2;
					break;
				}
				case "totalDuration":
				{
					int result = 0;
					int.TryParse(text2, out result);
					wplPlaylist.TotalDuration = TimeSpan.FromMilliseconds(result);
					break;
				}
				}
			}
			foreach (XElement item2 in xElement.Elements("body").Elements("seq").Elements("media"))
			{
				string path = PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("src")?.Value);
				string trackTitle = PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("trackTitle")?.Value);
				string trackArtist = PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("trackArtist")?.Value);
				string albumTitle = PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("albumTitle")?.Value);
				string albumArtist = PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("albumArtist")?.Value);
				int result3 = 0;
				int.TryParse(PlaylistsNET.Utils.Utils.UnEscape(item2.Attribute("duration")?.Value), out result3);
				TimeSpan.FromMilliseconds(result3);
				wplPlaylist.PlaylistEntries.Add(new WplPlaylistEntry
				{
					AlbumArtist = albumArtist,
					AlbumTitle = albumTitle,
					Path = path,
					TrackArtist = trackArtist,
					TrackTitle = trackTitle
				});
			}
			return wplPlaylist;
		}

		public string Update(WplPlaylist playlist, Stream stream)
		{
			XDocument xDocument = XDocument.Load(stream);
			XElement xElement = xDocument.Element("smil");
			XElement xElement2 = xElement.Element("head");
			xElement2.Element("title").ReplaceWith(new XElement("title", playlist.Title));
			if (!string.IsNullOrEmpty(playlist.Guid))
			{
				xElement2.Element("guid").ReplaceWith(new XElement("guid", playlist.Guid));
			}
			if (!string.IsNullOrEmpty(playlist.Author))
			{
				xElement2.Element("author").ReplaceWith(new XElement("author", playlist.Author));
			}
			foreach (XElement item in xElement2.Elements("meta"))
			{
				string text = PlaylistsNET.Utils.Utils.UnEscape(item.Attribute("name")?.Value);
				PlaylistsNET.Utils.Utils.UnEscape(item.Attribute("content")?.Value);
				switch (text)
				{
				case "Generator":
					if (!string.IsNullOrEmpty(playlist.Generator))
					{
						item.SetAttributeValue("content", playlist.Generator);
					}
					break;
				case "ItemCount":
					if (playlist.ItemCount > 0)
					{
						item.SetAttributeValue("content", playlist.ItemCount);
					}
					break;
				case "totalDuration":
					if (playlist.TotalDuration > TimeSpan.Zero)
					{
						item.SetAttributeValue("content", (int)playlist.TotalDuration.TotalMilliseconds);
					}
					break;
				}
			}
			IEnumerable<XElement> enumerable = xElement.Elements("body").Elements("seq");
			XElement xElement3 = null;
			foreach (XElement item2 in enumerable)
			{
				IEnumerable<XElement> enumerable2 = item2.Elements("media");
				int num = 0;
				foreach (XElement item3 in enumerable2)
				{
					_ = item3;
					num++;
				}
				if (num > 0)
				{
					xElement3 = item2;
					break;
				}
			}
			if (xElement3 != null)
			{
				XElement content = CreateSeqWithMedia(playlist);
				xElement3.ReplaceWith(content);
			}
			return xDocument.ToString();
		}

		private XElement CreateSeqWithMedia(WplPlaylist playlist)
		{
			XElement xElement = new XElement("seq");
			foreach (WplPlaylistEntry playlistEntry in playlist.PlaylistEntries)
			{
				XElement xElement2 = new XElement("media");
				XAttribute content = new XAttribute("src", playlistEntry.Path);
				xElement2.Add(content);
				if (!string.IsNullOrEmpty(playlistEntry.AlbumArtist))
				{
					XAttribute content2 = new XAttribute("albumTitle", playlistEntry.AlbumTitle);
					xElement2.Add(content2);
				}
				if (!string.IsNullOrEmpty(playlistEntry.AlbumArtist))
				{
					XAttribute content3 = new XAttribute("albumArtist", playlistEntry.AlbumArtist);
					xElement2.Add(content3);
				}
				if (!string.IsNullOrEmpty(playlistEntry.TrackTitle))
				{
					XAttribute content4 = new XAttribute("trackTitle", playlistEntry.TrackTitle);
					xElement2.Add(content4);
				}
				if (!string.IsNullOrEmpty(playlistEntry.TrackArtist))
				{
					XAttribute content5 = new XAttribute("trackArtist", playlistEntry.TrackArtist);
					xElement2.Add(content5);
				}
				_ = playlistEntry.Duration;
				if (playlistEntry.Duration != TimeSpan.Zero)
				{
					XAttribute content6 = new XAttribute("duration", (int)playlistEntry.Duration.TotalMilliseconds);
					xElement2.Add(content6);
				}
				xElement.Add(xElement2);
			}
			return xElement;
		}

		private XElement CreateMeta(string name, string content)
		{
			XElement xElement = new XElement("meta");
			XAttribute content2 = new XAttribute("name", name);
			XAttribute content3 = new XAttribute("content", content);
			xElement.Add(content2);
			xElement.Add(content3);
			return xElement;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class PlsContent : IPlaylistParser<PlsPlaylist>, IPlaylistWriter<PlsPlaylist>
	{
		public string ToText(PlsPlaylist playlist)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			stringBuilder.AppendLine("[playlist]");
			stringBuilder.AppendLine();
			foreach (PlsPlaylistEntry playlistEntry in playlist.PlaylistEntries)
			{
				num++;
				stringBuilder.AppendLine(ToFile(playlistEntry.Path, num));
				if (!string.IsNullOrEmpty(playlistEntry.Title))
				{
					stringBuilder.AppendLine(ToTitle(playlistEntry.Title, num));
				}
				if (playlistEntry.Length != TimeSpan.Zero)
				{
					stringBuilder.AppendLine(ToLength(playlistEntry.Length, num));
				}
				stringBuilder.AppendLine();
			}
			stringBuilder.Append("NumberOfEntries=").Append(num).AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.Append("Version=2");
			return stringBuilder.ToString();
		}

		public PlsPlaylist GetFromStream(Stream stream)
		{
			StreamReader streamReader = new StreamReader(stream);
			return GetFromString(streamReader.ReadToEnd());
		}

		public PlsPlaylist GetFromString(string playlistString)
		{
			PlsPlaylist plsPlaylist = new PlsPlaylist();
			plsPlaylist.Version = 2;
			List<string> list = (from x in playlistString.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
				select x.Trim()).ToList();
			if (list.Count == 0)
			{
				return plsPlaylist;
			}
			if (list[0] != "[playlist]")
			{
				return plsPlaylist;
			}
			foreach (string item in list)
			{
				int nr = GetNr(item);
				if (item.StartsWith("File"))
				{
					string path = GetPath(item);
					PlsPlaylistEntry plsPlaylistEntry = plsPlaylist.PlaylistEntries.SingleOrDefault((PlsPlaylistEntry e) => e.Nr == nr);
					if (plsPlaylistEntry == null)
					{
						plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry
						{
							Nr = nr,
							Path = path
						});
					}
					else
					{
						plsPlaylistEntry.Path = path;
					}
				}
				else if (item.StartsWith("Title"))
				{
					string title = GetTitle(item);
					if (!string.IsNullOrEmpty(title))
					{
						PlsPlaylistEntry plsPlaylistEntry2 = plsPlaylist.PlaylistEntries.SingleOrDefault((PlsPlaylistEntry e) => e.Nr == nr);
						if (plsPlaylistEntry2 == null)
						{
							plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry
							{
								Nr = nr,
								Title = title
							});
						}
						else
						{
							plsPlaylistEntry2.Title = title;
						}
					}
				}
				else if (item.StartsWith("Length"))
				{
					TimeSpan length = GetLength(item);
					PlsPlaylistEntry plsPlaylistEntry3 = plsPlaylist.PlaylistEntries.SingleOrDefault((PlsPlaylistEntry e) => e.Nr == nr);
					if (plsPlaylistEntry3 == null)
					{
						plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry
						{
							Nr = nr,
							Length = length
						});
					}
					else
					{
						plsPlaylistEntry3.Length = length;
					}
				}
			}
			plsPlaylist.PlaylistEntries = plsPlaylist.PlaylistEntries.OrderBy((PlsPlaylistEntry e) => e.Nr).ToList();
			return plsPlaylist;
		}

		private string ToFile(string path, int nr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("File").Append(nr).Append("=")
				.Append(path);
			return stringBuilder.ToString();
		}

		private string ToTitle(string title, int nr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Title").Append(nr).Append("=")
				.Append(title);
			return stringBuilder.ToString();
		}

		private string ToLength(TimeSpan length, int nr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Length").Append(nr).Append("=")
				.Append((int)length.TotalSeconds);
			return stringBuilder.ToString();
		}

		private int GetNr(string line)
		{
			int result = -1;
			if (line.StartsWith("File"))
			{
				try
				{
					result = int.Parse(line.Substring(4, line.IndexOf('=') - 4));
				}
				catch
				{
				}
			}
			else if (line.StartsWith("Title"))
			{
				try
				{
					result = int.Parse(line.Substring(5, line.IndexOf('=') - 5));
				}
				catch
				{
				}
			}
			else if (line.StartsWith("Length"))
			{
				try
				{
					result = int.Parse(line.Substring(6, line.IndexOf('=') - 6));
				}
				catch
				{
				}
			}
			return result;
		}

		private string GetPath(string line)
		{
			string result = null;
			try
			{
				result = line.Substring(line.IndexOf('=') + 1);
			}
			catch
			{
			}
			return result;
		}

		private string GetTitle(string line)
		{
			string result = null;
			try
			{
				result = line.Substring(line.IndexOf('=') + 1);
			}
			catch
			{
			}
			return result;
		}

		private TimeSpan GetLength(string line)
		{
			TimeSpan result = TimeSpan.Zero;
			try
			{
				result = TimeSpan.FromSeconds(int.Parse(line.Substring(line.IndexOf('=') + 1)));
			}
			catch
			{
			}
			return result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using UnityEngine;

namespace DV.Radio
{
	public class PlaylistPlayer : BasePlayer
	{
		public List<string> urls = new List<string>();

		private IBasePlaylist currentPlaylist;

		private BasePlayer player;

		private bool paused;

		private int currentTrackIndex;

		private long currentTrackSeekPoint;

		public override bool IsStopped
		{
			get
			{
				if (!(player == null))
				{
					return player.IsStopped;
				}
				return true;
			}
			protected set
			{
				base.IsStopped = value;
			}
		}

		public override RadioStationInfo CurrentStationInfo
		{
			get
			{
				if ((bool)player && player is RadioPlayer)
				{
					return player.CurrentStationInfo;
				}
				return null;
			}
		}

		public override bool StopOnFocusLost
		{
			get
			{
				return base.StopOnFocusLost;
			}
			set
			{
				base.StopOnFocusLost = value;
				if ((bool)player)
				{
					player.StopOnFocusLost = value;
				}
			}
		}

		public event Action PlaylistEnded;

		public event Action<int> TrackIndexChanged;

		public void SetPlaylistFile(string playlistFilePath, int trackIndex = 0, long trackSeekPoint = 0L)
		{
			Stop();
			currentPlaylist = null;
			IBasePlaylist playlist;
			if (!IsSupportedPlaylist(playlistFilePath))
			{
				ErrorInfo_Fire("Unsupported playlist type, only .pls and .m3u files are supported");
			}
			else if (!File.Exists(playlistFilePath))
			{
				ErrorInfo_Fire("Playlist file '" + playlistFilePath + "' doesn't exist");
			}
			else if (!TryGetPlaylist(playlistFilePath, out playlist))
			{
				ErrorInfo_Fire("Couldn't load playlist file '" + playlistFilePath + "'");
			}
			else
			{
				SetPlaylist(playlist, trackIndex, trackSeekPoint);
			}
		}

		public void SetPlaylist(IBasePlaylist playlist, int trackIndex = 0, long trackSeekPoint = 0L)
		{
			if (playlist == null)
			{
				ErrorInfo_Fire("Given playlist is null");
				return;
			}
			currentPlaylist = playlist;
			urls = playlist.GetTracksPaths().ToList();
			SetSeekPosition(trackIndex, trackSeekPoint);
			if (urls.Count == 0)
			{
				ErrorInfo_Fire("Given playlist is empty");
			}
		}

		public int GetTrackIndex()
		{
			return currentTrackIndex;
		}

		public override long GetSeekPosition()
		{
			if ((bool)player)
			{
				currentTrackSeekPoint = player.GetSeekPosition();
			}
			return currentTrackSeekPoint;
		}

		public override void SetSeekPosition(long position)
		{
			SetSeekPosition(currentTrackIndex, position);
		}

		public void SetSeekPosition(int trackIndexInPlaylist, long sampleInFileToSeekTo)
		{
			currentTrackIndex = trackIndexInPlaylist;
			currentTrackSeekPoint = sampleInFileToSeekTo;
			if (currentTrackIndex > urls.Count - 1)
			{
				currentTrackIndex = urls.Count - 1;
				currentTrackSeekPoint = 0L;
			}
			else if (currentTrackIndex < 0)
			{
				currentTrackIndex = 0;
				currentTrackSeekPoint = 0L;
			}
		}

		public void Previous()
		{
			if (urls != null && urls.Count != 0)
			{
				Stop();
				currentTrackIndex--;
				currentTrackSeekPoint = 0L;
				Play();
			}
		}

		public void Next()
		{
			if (urls != null && urls.Count != 0)
			{
				Stop();
				currentTrackIndex++;
				currentTrackSeekPoint = 0L;
				Play();
			}
		}

		public override void Play()
		{
			if (paused)
			{
				player.Play();
				paused = false;
				return;
			}
			if ((bool)player)
			{
				ErrorInfo_Fire("Player is already playing");
				return;
			}
			if (urls == null || urls.Count == 0)
			{
				ErrorInfo_Fire("No playlist entries to play");
				return;
			}
			if (currentTrackIndex >= urls.Count)
			{
				currentTrackIndex = 0;
			}
			else if (currentTrackIndex < 0)
			{
				currentTrackIndex = urls.Count - 1;
			}
			string text = urls[currentTrackIndex];
			if (string.IsNullOrWhiteSpace(text))
			{
				ErrorInfo_Fire($"Bad playlist entry at index {currentTrackIndex}");
				return;
			}
			if (text.StartsWith("http"))
			{
				MakePlayer<RadioPlayer>();
				RadioStationInfo station = new RadioStationInfo(text, text, (!text.ToLower().Contains("ogg")) ? AudioFormat.MP3 : AudioFormat.OGG);
				player.audioSource = audioSource;
				((RadioPlayer)player).SetStation(station);
				player.Play();
			}
			else
			{
				text = ResolveFilePath(text, currentPlaylist.Path);
				if (!File.Exists(text))
				{
					ErrorInfo_Fire("File '" + text + "' doesn't exist");
					return;
				}
				MakePlayer<FilePlayer>();
				player.audioSource = audioSource;
				((FilePlayer)player).SetFile(text, currentTrackSeekPoint);
				player.Play();
			}
			this.TrackIndexChanged?.Invoke(currentTrackIndex);
		}

		public override void Stop()
		{
			if ((bool)player)
			{
				GetSeekPosition();
				SetupListeners(on: false);
				PlaybackStopped_Fire();
				player.Stop();
				UnityEngine.Object.Destroy(player);
				player = null;
			}
			paused = false;
		}

		public override bool Pause()
		{
			if ((bool)player && !paused)
			{
				player.Pause();
				paused = true;
				return true;
			}
			return false;
		}

		private static string GetExtension(string filePath)
		{
			return Path.GetExtension(filePath).ToLower();
		}

		private static bool IsSupportedPlaylist(string filePath)
		{
			string extension = GetExtension(filePath);
			if (!(extension == ".pls"))
			{
				return extension == ".m3u";
			}
			return true;
		}

		public static bool TryGetPlaylist(string playlistFilePath, out IBasePlaylist playlist)
		{
			playlist = null;
			if (string.IsNullOrWhiteSpace(playlistFilePath))
			{
				return false;
			}
			if (!IsSupportedPlaylist(playlistFilePath))
			{
				return false;
			}
			if (!File.Exists(playlistFilePath))
			{
				return false;
			}
			try
			{
				IPlaylistParser<IBasePlaylist> playlistParser = PlaylistParserFactory.GetPlaylistParser(GetExtension(playlistFilePath));
				using (FileStream stream = new FileStream(playlistFilePath, FileMode.Open, FileAccess.Read))
				{
					playlist = playlistParser.GetFromStream(stream);
				}
				if (playlist != null)
				{
					playlist.Path = playlistFilePath;
					playlist.FileName = Path.GetFileName(playlistFilePath);
				}
				return playlist != null;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private static string ResolveFilePath(string absoluteOrRelativePath, string playlistFilePath)
		{
			if (Path.IsPathRooted(absoluteOrRelativePath))
			{
				return absoluteOrRelativePath;
			}
			return Path.Combine(Path.GetDirectoryName(playlistFilePath), absoluteOrRelativePath);
		}

		private void MakePlayer<T>() where T : BasePlayer
		{
			if ((bool)player)
			{
				SetupListeners(on: false);
				UnityEngine.Object.Destroy(player);
				player = null;
			}
			player = base.gameObject.AddComponent<T>();
			player.stopOnFocusLost = stopOnFocusLost;
			SetupListeners(on: true);
		}

		private void PlayNextFile()
		{
			if (!paused)
			{
				if (urls == null || currentTrackIndex >= urls.Count - 1)
				{
					Stop();
					PlaybackStopped_Fire();
					this.PlaylistEnded?.Invoke();
				}
				else
				{
					Next();
				}
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				player.PlaybackStarted += PlaybackStarted_Fire;
				player.PlaybackStopped += PlayNextFile;
				player.BufferingStarted += BufferingStarted_Fire;
				player.BufferingEnded += BufferingEnded_Fire;
				player.BufferingProgress += BufferingProgress_Fire;
				player.SongInfoChanged += SongInfoChanged_Fire;
				player.ErrorInfo += ErrorInfo_Fire;
				player.StationNameChanged += StationNameChanged_Fire;
			}
			else
			{
				player.PlaybackStarted -= PlaybackStarted_Fire;
				player.PlaybackStopped -= PlayNextFile;
				player.BufferingStarted -= BufferingStarted_Fire;
				player.BufferingEnded -= BufferingEnded_Fire;
				player.BufferingProgress -= BufferingProgress_Fire;
				player.SongInfoChanged -= SongInfoChanged_Fire;
				player.ErrorInfo -= ErrorInfo_Fire;
				player.StationNameChanged -= StationNameChanged_Fire;
			}
		}
	}
}

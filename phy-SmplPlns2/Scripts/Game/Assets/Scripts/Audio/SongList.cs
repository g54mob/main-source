using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	[CreateAssetMenu(fileName = "New Song List", menuName = "SimplePlanes 2/Song List")]
	public class SongList : ScriptableObject
	{
		private List<Song> _filteredSongs = new List<Song>();

		[SerializeField]
		private List<Song> _songs = new List<Song>();

		public List<Song> Songs => _songs;

		public Song PickSong(SongTags matchTags, Span<Song> ignore)
		{
			_filteredSongs.Clear();
			foreach (Song song in Songs)
			{
				if ((song.SupportedTags & matchTags) == 0)
				{
					continue;
				}
				bool flag = false;
				Span<Song> span = ignore;
				for (int i = 0; i < span.Length; i++)
				{
					if (span[i] == song)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_filteredSongs.Add(song);
				}
			}
			if (_filteredSongs.Count == 0)
			{
				return null;
			}
			Song result = _filteredSongs[UnityEngine.Random.Range(0, _filteredSongs.Count)];
			_filteredSongs.Clear();
			return result;
		}
	}
}

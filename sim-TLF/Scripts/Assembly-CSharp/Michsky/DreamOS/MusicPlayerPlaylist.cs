using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New Music Playlist", menuName = "DreamOS/New Music Playlist")]
	public class MusicPlayerPlaylist : ScriptableObject
	{
		[Serializable]
		public class MusicItem
		{
			public string musicTitle = "Music Title";

			public string artistTitle = "Artist Title";

			public string albumTitle = "Album Title";

			public AudioClip musicClip;

			public Sprite musicCover;

			[HideInInspector]
			public bool excludeFromLibrary;

			[HideInInspector]
			public bool isModContent;
		}

		public Sprite coverImage;

		public string playlistName;

		public List<MusicItem> playlist = new List<MusicItem>();
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	[CreateAssetMenu(menuName = "MoreMountains/Audio/MMSM Playlist")]
	public class MMSMPlaylist : ScriptableObject
	{
		public enum PlayModes
		{
			PlayForever = 0,
			PlayOnce = 1,
			PlayXTimes = 2
		}

		public enum PlayOrders
		{
			Normal = 0,
			ReverseOrder = 1,
			Random = 2,
			RandomUnique = 3
		}

		[Header("Play Modes")]
		[Tooltip("the sound manager track on which to play this playlist's songs")]
		public MMSoundManager.MMSoundManagerTracks Track = MMSoundManager.MMSoundManagerTracks.Music;

		[Tooltip("the order in which to play songs (top to bottom, bottom to top, random, or random while trying to maintain playcount across songs")]
		public PlayOrders PlayOrder;

		[Tooltip("if this is true, random seed will be randomized by the system clock")]
		[MMEnumCondition("PlayOrder", new int[] { 2, 3 })]
		public bool RandomizeOrderSeed = true;

		[Tooltip("whether to play this playlist forever, only once, or play songs until total playcount reaches MaxAmountOfPlays")]
		public PlayModes PlayMode;

		[Tooltip("when in PlayXTimes mode, the max amount of plays before this playlist ends")]
		[MMEnumCondition("PlayMode", new int[] { 2 })]
		public int MaxAmountOfPlays = 10;

		[Tooltip("a playlist to switch to when reaching the end of this playlist")]
		[MMEnumCondition("PlayMode", new int[] { 1, 2 })]
		public MMSMPlaylist NextPlaylist;

		[Tooltip("the list of songs to play on this playlist")]
		public List<MMSMPlaylistSong> Songs;

		[Header("Debug")]
		[Tooltip("the total number of times songs in this playlist have been played ")]
		[MMReadOnly]
		public int PlayCount;

		protected List<int> _randomUniqueCandidates;

		public virtual void Initialization()
		{
			PlayCount = 0;
			_randomUniqueCandidates = new List<int>();
			foreach (MMSMPlaylistSong song in Songs)
			{
				song.Initialization();
			}
		}

		public virtual int PickNextIndex(int direction, int currentSongIndex, ref int queuedSongIndex, bool bypassLoop)
		{
			int num = currentSongIndex;
			if (Songs.Count == 0)
			{
				return -1;
			}
			if (queuedSongIndex != -1)
			{
				int result = queuedSongIndex;
				queuedSongIndex = -1;
				return result;
			}
			if (PlayCount >= Songs.Count && PlayMode == PlayModes.PlayOnce)
			{
				return -2;
			}
			if (PlayMode == PlayModes.PlayXTimes && PlayCount >= MaxAmountOfPlays)
			{
				return -2;
			}
			if (currentSongIndex >= 0 && currentSongIndex < Songs.Count && Songs[currentSongIndex].Options.Loop && !bypassLoop)
			{
				return currentSongIndex;
			}
			switch (PlayOrder)
			{
			case PlayOrders.Random:
				while (num == currentSongIndex)
				{
					num = UnityEngine.Random.Range(0, Songs.Count);
				}
				return num;
			case PlayOrders.RandomUnique:
			{
				bool flag = true;
				int num2 = int.MaxValue;
				_randomUniqueCandidates.Clear();
				for (int i = 0; i < Songs.Count; i++)
				{
					if (Songs[i].PlayCount <= num2 && i != currentSongIndex)
					{
						flag = false;
						num2 = Songs[i].PlayCount;
						_randomUniqueCandidates.Add(i);
					}
				}
				if (flag)
				{
					while (num == currentSongIndex)
					{
						num = UnityEngine.Random.Range(0, Songs.Count);
					}
				}
				else
				{
					int index = UnityEngine.Random.Range(0, _randomUniqueCandidates.Count);
					num = _randomUniqueCandidates[index];
				}
				return num;
			}
			case PlayOrders.ReverseOrder:
				direction = -1;
				break;
			}
			if (direction > 0)
			{
				num = (currentSongIndex + 1) % Songs.Count;
			}
			else
			{
				num = currentSongIndex - 1;
				if (num < 0)
				{
					num = Songs.Count - 1;
				}
			}
			return num;
		}

		public virtual void ResetPlayCount()
		{
			PlayCount = 0;
			foreach (MMSMPlaylistSong song in Songs)
			{
				song.PlayCount = 0;
			}
		}

		protected virtual void OnValidate()
		{
			foreach (MMSMPlaylistSong song in Songs)
			{
				if (!song.Options.Initialized)
				{
					song.Options = MMSoundManagerPlayOptions.Default;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/ReSound/Setlist", order = 361)]
	public class ReSoundSetlist : ScriptableObject
	{
		public enum ProgressionMode
		{
			weightedRandom = 0,
			random = 1,
			progression = 2
		}

		public enum StartingStyle
		{
			startWithRandomSong = 0,
			startWithInitialSong = 1
		}

		[Tooltip("The list of ReSound tracks that will play on this setlist.")]
		public List<ReSoundTrack> availableTracks;

		public ProgressionMode progressionMode;

		public StartingStyle startingStyle;

		[Tooltip("The ReSound track that will be played initially.")]
		public ReSoundTrack initialSong;

		public float minSilenceTime;

		public float maxSilenceTime;
	}
}

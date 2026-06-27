using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/ReSound/DJ", order = 361)]
	public class ReSoundDJ : ScriptableObject
	{
		public enum TransitionType
		{
			fadeToZero = 0,
			crossfade = 1,
			noFade = 2
		}

		public TransitionType transitionType;

		public float transitionTime = 5f;

		[Tooltip("All of the ReSound tracks will play ever.")]
		public List<ReSoundTrack> availableTracks;

		public bool resetOnEntry;

		public bool noSilenceMode;

		public bool preventRepeatSongs = true;
	}
}

using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class RaceTrackManager : BaseSingleton<RaceTrackManager>
	{
		[HideInInspector]
		public bool Autonomous;

		[HideInInspector]
		public List<RaceTrack> RaceTracks { get; private set; }

		[HideInInspector]
		public RaceTrack SelectedTrack { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(this);
			RaceTracks = Resources.LoadAll<RaceTrack>("RaceTracks").ToList();
		}

		public void SelectTrack(RaceTrack track)
		{
			SelectedTrack = track;
		}
	}
}

using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.RaceLocation.Scripts
{
	public class SelectTrackButton : MonoBehaviour
	{
		private RaceTrack _track;

		public bool Autonomous;

		public void Init(RaceTrack track)
		{
			_track = track;
		}

		public void OnClick()
		{
			BaseSingleton<RaceTrackManager>.Instance.SelectTrack(_track);
			BaseSingleton<RaceTrackManager>.Instance.Autonomous = Autonomous;
		}
	}
}

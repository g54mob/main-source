using Assets.Nimbatus.Scripts.GalaxyMap.Race.Timed;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class RaceCheckpoint : MonoBehaviour
	{
		private RaceManager _raceManager;

		private bool _crossed;

		private bool _initialized;

		public void Init(RaceManager rm)
		{
			_raceManager = rm;
			_initialized = true;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (_initialized && !_crossed)
			{
				_raceManager.ClearCheckpoint(this, other);
			}
		}

		public void Cross()
		{
			_crossed = true;
		}
	}
}

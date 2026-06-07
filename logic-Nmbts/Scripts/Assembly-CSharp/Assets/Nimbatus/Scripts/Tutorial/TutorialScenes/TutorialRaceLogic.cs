using Assets.Nimbatus.Scripts.Characters.Player;
using Assets.Nimbatus.Scripts.GalaxyMap.Race;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialRaceLogic : GenericTutorialLogic
	{
		public NimbatusPlayer NimbatusPlayer;

		public RaceTrack RaceTrack;

		private bool _isInitialized;

		private bool _finished;

		private void Awake()
		{
		}

		public void SetToFinished()
		{
			_finished = true;
		}

		public override void OnUpdate()
		{
			if (!_isInitialized)
			{
				NimbatusPlayer.Drone.TrackerManager.Init(NimbatusPlayer.Drone, RaceTrack.MainSpline);
				_isInitialized = true;
			}
		}

		public override bool IsCompleted()
		{
			return _finished;
		}

		public override string TutorialLabel()
		{
			return LocalizationManager.GetTermTranslation("Tutorial/CrossFinishLine");
		}

		public override Vector3 CursorPosition()
		{
			return Vector3.zero;
		}

		public override bool IsCursorVisible()
		{
			return false;
		}
	}
}

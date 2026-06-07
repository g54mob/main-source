using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowEndScreen : MonoBehaviour
	{
		private TweenPosition _tween;

		private bool _hasPlayed;

		private NimbatusMission _mission;

		public void Awake()
		{
			_tween = GetComponent<TweenPosition>();
			_mission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission;
		}

		public void Update()
		{
			if (!_hasPlayed && RuntimeGlobals.IsGameOver && !RuntimeGlobals.IsGamePaused && (_mission == null || (_mission != null && !_mission.ExitOnFinish)))
			{
				_tween.Play(true);
				_hasPlayed = true;
			}
			if (_hasPlayed && !RuntimeGlobals.IsGameOver)
			{
				_tween.Play(false);
				_hasPlayed = false;
			}
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Arena
{
	public class VersusTracker : RaceTrigger
	{
		public float MoveSpeed = 100f;

		public float TrackerTime = 3f;

		public string CatchSound;

		public string MoveSound;

		public string TimeOutSound;

		public float TimeOutSoundOffset;

		public GameObject ActiveSprite;

		public GameObject InactiveSprite;

		public Renderer ProgressBar;

		public Renderer InnerBar;

		public List<VersusSpawnPoint> SpawnPoints = new List<VersusSpawnPoint>();

		private VersusSpawnPoint _currentSpawnPoint;

		private bool _timeOutIsPlaying;

		[HideInInspector]
		public bool Active;

		private bool _initiated;

		private VersusArenaManager _manager;

		private Collider _collider;

		private float _timeLeft;

		public void Init(VersusArenaManager manager)
		{
			_initiated = true;
			_manager = manager;
			_collider = GetComponent<Collider>();
			_currentSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
			ResetTrackerTimer();
		}

		protected override void Update()
		{
			base.Update();
			if (!_initiated)
			{
				return;
			}
			if (base.transform.position != _currentSpawnPoint.transform.position)
			{
				Active = false;
				base.transform.position = Vector3.MoveTowards(base.transform.position, _currentSpawnPoint.transform.position, MoveSpeed * Time.deltaTime);
				if (base.transform.position == _currentSpawnPoint.transform.position)
				{
					ResetTrackerTimer();
					StopSoundLoop();
				}
			}
			else
			{
				Active = true;
				_timeLeft -= Time.deltaTime;
				ProgressBar.material.SetFloat("_Percentage", Mathf.Clamp01(_timeLeft / TrackerTime));
				InnerBar.material.SetFloat("_Percentage", Mathf.Clamp01(_timeLeft / TrackerTime));
				if (_timeLeft <= TimeOutSoundOffset && !_timeOutIsPlaying)
				{
					PlaySound(TimeOutSound);
					_timeOutIsPlaying = true;
				}
				if (_timeLeft <= 0f)
				{
					_manager.TrackerTimeOut();
				}
			}
			_collider.enabled = Active;
			ActiveSprite.SetActive(Active);
			InactiveSprite.SetActive(!Active);
		}

		public void OnTriggerStay(Collider other)
		{
			if (other.gameObject == _manager.LeftDrone.RootDronePart.gameObject)
			{
				_manager.TouchTracker(_manager.LeftDrone);
				if (Active)
				{
					_currentSpawnPoint = _currentSpawnPoint.GetNewSpawnPoint();
					SoundOnCatch();
				}
				Active = false;
			}
			else if (other.gameObject == _manager.RightDrone.RootDronePart.gameObject)
			{
				_manager.TouchTracker(_manager.RightDrone);
				if (Active)
				{
					_currentSpawnPoint = _currentSpawnPoint.GetNewSpawnPoint();
					SoundOnCatch();
				}
				Active = false;
			}
		}

		private void SoundOnCatch()
		{
			PlaySound(CatchSound);
			StartSoundLoop(MoveSound);
			StopSound(TimeOutSound);
			_timeOutIsPlaying = false;
		}

		private void ResetTrackerTimer()
		{
			_timeLeft = TrackerTime;
		}
	}
}

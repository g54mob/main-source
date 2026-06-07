using System;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Arena
{
	public class VersusArenaManager : BaseRaceManager
	{
		[Header("Versus Arena Manager")]
		public UILabel ScoreDisplay;

		public UILabel LeftDroneScoreDisplay;

		public UILabel RightDroneScoreDisplay;

		public int ScoreToWin = 3;

		public NimbatusDrone RightDrone;

		public NimbatusDrone LeftDrone;

		public VersusTracker Tracker;

		public Transform LeftDroneScorePivot;

		public Transform RightDroneScorePivot;

		private int _rightDroneScore;

		private int _leftDroneScore;

		private NimbatusDrone _lastScorer;

		private bool _leftDroneDead;

		private bool _rightDroneDead;

		private float _leftDroneScoreTimer;

		private float _rightDroneScoreTimer;

		private float _leftDroneScoreLerp;

		private float _rightDroneScoreLerp;

		protected override void Awake()
		{
			LeftDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0));
			RightDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(1));
			LeftDrone.RootDronePart.transform.Rotate(Vector3.forward, 180f);
			foreach (DronePart item in LeftDrone.RootDronePart.Children.Where((DronePart c) => c.GetComponent<DronePart>()))
			{
				item.ApplyRotation();
			}
			LeftDrone.RootDronePart.ValidateDroneRecursive();
			RightDrone.RootDronePart.ValidateDroneRecursive();
			LeftDrone.RootDronePart.HealthPool.HasDied += HealthPool_HasDiedLeft;
			RightDrone.RootDronePart.HealthPool.HasDied += HealthPool_HasDiedRight;
			base.Awake();
		}

		private void HealthPool_HasDiedRight(object sender, EventArgs e)
		{
			RuntimeGlobals.Camera.RemovePlayer(RightDrone.RootDronePart.transform);
			_rightDroneDead = true;
			RightDrone.RootDronePart.HealthPool.HasDied -= HealthPool_HasDiedRight;
		}

		private void HealthPool_HasDiedLeft(object sender, EventArgs e)
		{
			RuntimeGlobals.Camera.RemovePlayer(LeftDrone.RootDronePart.transform);
			_leftDroneDead = true;
			LeftDrone.RootDronePart.HealthPool.HasDied -= HealthPool_HasDiedLeft;
		}

		public void Start()
		{
			if (RuntimeGlobals.Camera != null)
			{
				RuntimeGlobals.Camera.FocusTarget = true;
				RuntimeGlobals.Camera.AddPlayer(LeftDrone.RootDronePart.transform, true, false, true);
				RuntimeGlobals.Camera.AddPlayer(RightDrone.RootDronePart.transform, true, false, false);
				RuntimeGlobals.Camera.AddTracker(Tracker.transform, true, false, false);
			}
			RuntimeGlobals.IsMovementBlocked = true;
		}

		public override void Update()
		{
			base.Update();
			if (!RaceRunning)
			{
				return;
			}
			if (ScoreDisplay != null && LeftDroneScoreDisplay != null && RightDroneScoreDisplay != null)
			{
				ScoreDisplay.text = _leftDroneScore + " : " + _rightDroneScore;
				if (_leftDroneScoreTimer > 0f)
				{
					_leftDroneScoreTimer -= Time.deltaTime * 3f;
					_leftDroneScoreTimer = Mathf.Clamp01(_leftDroneScoreTimer);
				}
				if (_rightDroneScoreTimer > 0f)
				{
					_rightDroneScoreTimer -= Time.deltaTime * 3f;
					_rightDroneScoreTimer = Mathf.Clamp01(_rightDroneScoreTimer);
				}
				_leftDroneScoreLerp = Mathf.Pow(_leftDroneScoreTimer, 4f);
				_rightDroneScoreLerp = Mathf.Pow(_rightDroneScoreTimer, 4f);
				Color color = Color.Lerp(new Color32(254, 152, 0, byte.MaxValue), Color.white, _leftDroneScoreLerp);
				Color color2 = Color.Lerp(new Color32(254, 152, 0, byte.MaxValue), Color.white, _rightDroneScoreLerp);
				if (_leftDroneScore >= ScoreToWin || _rightDroneScore >= ScoreToWin)
				{
					color = new Color32(254, 152, 0, byte.MaxValue);
					color2 = new Color32(254, 152, 0, byte.MaxValue);
				}
				string text = "[" + ColorUtility.ToHtmlStringRGBA(color) + "]";
				string text2 = "[" + ColorUtility.ToHtmlStringRGBA(color2) + "]";
				float num = ((GetCurrentWinningDrone() == LeftDrone) ? 1.3f : 1f);
				num += _leftDroneScoreLerp * 0.6f;
				LeftDroneScorePivot.localScale = new Vector3(num, num, 1f);
				LeftDroneScoreDisplay.text = text + _leftDroneScore.ToString(CultureInfo.InvariantCulture);
				float num2 = ((GetCurrentWinningDrone() == RightDrone) ? 1.3f : 1f);
				num2 += _rightDroneScoreLerp * 0.6f;
				RightDroneScorePivot.localScale = new Vector3(num2, num2, 1f);
				RightDroneScoreDisplay.text = text2 + _rightDroneScore.ToString(CultureInfo.InvariantCulture);
			}
			if (_rightDroneScore >= ScoreToWin || (_leftDroneDead && (_rightDroneScore > _leftDroneScore || (_rightDroneScore == _leftDroneScore && GetCurrentWinningDrone() == RightDrone))))
			{
				FinishRace(RightDrone);
			}
			else if (_leftDroneScore >= ScoreToWin || (_rightDroneDead && (_leftDroneScore > _rightDroneScore || (_leftDroneScore == _rightDroneScore && GetCurrentWinningDrone() == LeftDrone))))
			{
				FinishRace(LeftDrone);
			}
			else if (_leftDroneDead && _rightDroneDead)
			{
				if (GetCurrentWinningDrone() != null)
				{
					FinishRace(GetCurrentWinningDrone());
				}
				else
				{
					FinishRace(RightDrone, false);
				}
			}
		}

		private NimbatusDrone GetCurrentWinningDrone()
		{
			if (_rightDroneScore == 0 && _leftDroneScore == 0)
			{
				return null;
			}
			if (_rightDroneScore > _leftDroneScore)
			{
				return RightDrone;
			}
			if (_leftDroneScore > _rightDroneScore)
			{
				return LeftDrone;
			}
			if (_rightDroneScore > 0 && _leftDroneScore > 0 && _rightDroneScore == _leftDroneScore)
			{
				if (_lastScorer != null)
				{
					return _lastScorer;
				}
				float magnitude = (Tracker.transform.position - LeftDrone.RootDronePart.transform.position).magnitude;
				float magnitude2 = (Tracker.transform.position - RightDrone.RootDronePart.transform.position).magnitude;
				if (magnitude2 < magnitude)
				{
					return RightDrone;
				}
				if (magnitude < magnitude2)
				{
					return LeftDrone;
				}
				if (UnityEngine.Random.Range(0, 2) != 0)
				{
					return RightDrone;
				}
				return LeftDrone;
			}
			return null;
		}

		public override void WakeUp()
		{
			RightDrone.ActivatePhysics();
			LeftDrone.ActivatePhysics();
		}

		public override void OnRaceStarted()
		{
			Tracker.Init(this);
		}

		public override void OnRaceEnded(NimbatusDrone drone, bool success)
		{
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(drone == LeftDrone, LeftDrone, RightDrone, CurrentTime);
		}

		public Vector2 GetOpponentPosition(NimbatusDrone rootDrone)
		{
			if (rootDrone == LeftDrone)
			{
				return RightDrone.RootDronePart.transform.position;
			}
			if (rootDrone == RightDrone)
			{
				return LeftDrone.RootDronePart.transform.position;
			}
			return Vector3.zero;
		}

		public Vector3 GetTrackerPosition()
		{
			return Tracker.transform.position;
		}

		public void TouchTracker(NimbatusDrone drone)
		{
			if (drone == LeftDrone && Tracker.Active)
			{
				_leftDroneScore++;
				_leftDroneScoreTimer = 1f;
			}
			else if (drone == RightDrone && Tracker.Active)
			{
				_rightDroneScore++;
				_rightDroneScoreTimer = 1f;
			}
			_lastScorer = drone;
		}

		public void TrackerTimeOut()
		{
			if (RaceRunning)
			{
				if (GetCurrentWinningDrone() != null)
				{
					FinishRace(GetCurrentWinningDrone());
				}
				else
				{
					FinishRace(RightDrone, false);
				}
			}
		}
	}
}

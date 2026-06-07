using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus
{
	public class RaceVersusManager : BaseRaceManager
	{
		[Header("Race Versus Manager")]
		public RaceTrack MainTrack;

		public NimbatusDrone RightDrone;

		public RaceSpline RightDroneSpline;

		public NimbatusDrone LeftDrone;

		public RaceSpline LeftDroneSpline;

		public DeathWallManager DeathWallManager;

		private bool _leftDroneDead;

		private bool _rightDroneDead;

		protected override void Awake()
		{
			base.Awake();
			LeftDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0));
			RightDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(1));
			LeftDrone.RootDronePart.ValidateDroneRecursive();
			RightDrone.RootDronePart.ValidateDroneRecursive();
			LeftDrone.RootDronePart.HealthPool.HasDied += HealthPool_HasDiedLeft;
			RightDrone.RootDronePart.HealthPool.HasDied += HealthPool_HasDiedRight;
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
				RuntimeGlobals.Camera.AddPlayer(RightDrone.RootDronePart.transform, true, false, false);
				RuntimeGlobals.Camera.AddPlayer(LeftDrone.RootDronePart.transform, true, false, true);
			}
			RuntimeGlobals.IsMovementBlocked = true;
			RaceSpline spline = LeftDroneSpline;
			RaceSpline spline2 = RightDroneSpline;
			if (UnityEngine.Random.Range(0, 2) == 0)
			{
				Vector3 position = LeftDrone.RootDronePart.transform.position;
				Vector3 position2 = RightDrone.RootDronePart.transform.position;
				LeftDrone.RootDronePart.transform.position = position2;
				RightDrone.RootDronePart.transform.position = position;
				spline = RightDroneSpline;
				spline2 = LeftDroneSpline;
			}
			LeftDrone.TrackerManager.Init(LeftDrone, spline);
			RightDrone.TrackerManager.Init(RightDrone, spline2);
		}

		public override void Update()
		{
			base.Update();
			if (RaceRunning && _rightDroneDead && _leftDroneDead)
			{
				FinishRace(RightDrone, false);
			}
		}

		public override void WakeUp()
		{
			RightDrone.ActivatePhysics();
			LeftDrone.ActivatePhysics();
		}

		public override void OnRaceStarted()
		{
			DeathWallManager.Init(MainTrack, LeftDrone.TrackerManager, RightDrone.TrackerManager, LeftDroneSpline, RightDroneSpline);
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
	}
}

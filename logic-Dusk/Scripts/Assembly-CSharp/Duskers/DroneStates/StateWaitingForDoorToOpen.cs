using UnityEngine;

namespace Duskers.DroneStates
{
	public class StateWaitingForDoorToOpen : BaseDroneState
	{
		private const float RECHECK_PERIOD = 1f;

		private Waypoint _targetWaypoint;

		private float _roomPathReCheckTimer;

		public override string StateId
		{
			get
			{
				return "WaitingForDoor";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateWaitingForDoorToOpen(DroneBrain brain)
			: base(brain)
		{
		}

		public void Initialize(Waypoint targetWaypoint)
		{
			_targetWaypoint = targetWaypoint;
		}

		public override void Update()
		{
			_roomPathReCheckTimer -= Time.deltaTime;
			if (_roomPathReCheckTimer <= 0f)
			{
				_roomPathReCheckTimer = 1f;
				_brain.StateNavigatingPath.Initialize(_targetWaypoint);
				ChangeState(_brain.StateNavigatingPath);
			}
		}

		public override void EnterState()
		{
			_roomPathReCheckTimer = 1f;
			if (_targetWaypoint == null)
			{
				Debug.LogWarning("_targetWaypoint must be set for this state to work properly");
			}
			if (!_brain.WarnedAboutDoors)
			{
				_brain.WarnedAboutDoors = true;
				DroneManager.Instance.SendConsoleMessage(string.Format("A closed door is blocking the path for Drone {0} ({1})", _brain.ThisDrone.DroneNumber, _brain.ThisDrone.DroneName), ConsoleMessageType.Warning);
			}
		}

		public override void ExitState()
		{
			_targetWaypoint = null;
		}
	}
}

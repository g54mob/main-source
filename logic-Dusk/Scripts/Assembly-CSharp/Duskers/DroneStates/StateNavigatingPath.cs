using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.DroneStates
{
	public class StateNavigatingPath : BaseDroneState
	{
		private Waypoint _currentWaypoint;

		private List<Waypoint> _currentPath;

		private Waypoint _targetWaypoint;

		private bool _initializedObjectiveTimer;

		private float _objectiveTimer;

		private float _closestDistanceToTarget;

		public override string StateId
		{
			get
			{
				return "NavigatingPath";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateNavigatingPath(DroneBrain brain)
			: base(brain)
		{
			EventManager.Instance.SubscribeInstant(GeneralEventType.RefreshNavigation, HandleResetNavigation);
		}

		public void Initialize(Waypoint destinationWaypoint)
		{
			_targetWaypoint = destinationWaypoint;
			_currentWaypoint = null;
			_currentPath = null;
			_initializedObjectiveTimer = false;
		}

		public override void Update()
		{
			bool flag = false;
			if (_initializedObjectiveTimer && _currentPath != null && _currentPath.Count > 0)
			{
				float num = Vector3.Distance(_currentPath[0].transform.position, _brain.ThisDrone.Position);
				if (num < _closestDistanceToTarget && _closestDistanceToTarget - num > 1f)
				{
					_objectiveTimer = 4f;
					_closestDistanceToTarget = num;
				}
				_objectiveTimer -= Time.deltaTime;
				if (_objectiveTimer <= 0f)
				{
					flag = true;
				}
			}
			if (flag || (_currentPath != null && _currentPath.Count == 0))
			{
				ChangeState(_brain.StateIdle);
				if (!flag)
				{
					_brain.ThisDrone.ArrivedAtDestination();
				}
				else
				{
					_brain.ThisDrone.SendConsoleMessage(string.Format("Drone {0} ({1}) canceled navigation", _brain.ThisDrone.DroneNumber, _brain.ThisDrone.DroneName), ConsoleMessageType.Info);
				}
			}
			else
			{
				bool flag2 = _currentPath == null;
				bool flag3 = false;
				if (!flag2)
				{
					Waypoint waypoint = _currentPath[0];
					Door door = waypoint.Door;
					if (door != null && door.state == DoorState.Closed)
					{
						if (_brain.ThisDrone.CurrentRoom != null && _brain.ThisDrone.CurrentRoom != waypoint.Room)
						{
							flag3 = true;
						}
						else if (_brain.ThisDrone.CurrentRoom != null && _currentPath.Count > 1 && _currentPath[1].Room != waypoint.Room)
						{
							flag3 = true;
						}
					}
				}
				if (flag2 || flag3)
				{
					_brain.StateWaitingForDoorToOpen.Initialize(_targetWaypoint);
					ChangeState(_brain.StateWaitingForDoorToOpen);
				}
			}
			if (_currentPath == null || _currentPath.Count <= 0)
			{
				return;
			}
			_brain.WarnedAboutDoors = false;
			Waypoint waypoint2 = _currentPath[0];
			if (!_brain.ReachedTargetPosition(waypoint2.transform.position))
			{
				if (!_brain.RotateWhileNotLookingAtTarget())
				{
					if (!_initializedObjectiveTimer)
					{
						_initializedObjectiveTimer = true;
						_objectiveTimer = 4f;
						_closestDistanceToTarget = Vector3.Distance(waypoint2.transform.position, _brain.ThisDrone.Position);
					}
					_brain.SteeringBehaviors.SetTarget(waypoint2);
					if (_currentPath.Count > 1)
					{
						_brain.SteeringBehaviors.SeekOn();
					}
					else
					{
						_brain.SteeringBehaviors.ArriveOn(Deceleration.Normal);
					}
					_brain.SteeringBehaviors.WallAvoidanceOn();
					_brain.SteeringBehaviors.ObstacleAvoidanceOn();
				}
			}
			else
			{
				_initializedObjectiveTimer = false;
				_currentWaypoint = waypoint2;
				_currentPath.Remove(waypoint2);
				_brain.SteeringBehaviors.SeekOff();
				_brain.SteeringBehaviors.ArriveOff();
				_brain.SteeringBehaviors.ObstacleAvoidanceOff();
				_brain.SteeringBehaviors.LazyAvoidanceOff();
				_brain.SteeringBehaviors.WallAvoidanceOff();
				_brain.ThisDrone.PostMovement();
			}
		}

		public override void EnterState()
		{
			_brain.SteeringBehaviors.SeekOff();
			if (_targetWaypoint == null)
			{
				Debug.LogWarning("_targetWaypoint must be set for this state to work properly");
			}
			else
			{
				CalculateNavigationPath(_targetWaypoint);
			}
			if (_currentPath != null && _currentPath.Count > 0)
			{
				_brain.InitializeRotation(_currentPath[0].transform.position);
			}
		}

		public override void ExitState()
		{
			_brain.SteeringBehaviors.SeekOff();
			_targetWaypoint = null;
			_currentWaypoint = null;
			_currentPath = null;
			_brain.SteeringBehaviors.SeekOff();
			_brain.SteeringBehaviors.ArriveOff();
			_brain.SteeringBehaviors.ObstacleAvoidanceOff();
			_brain.SteeringBehaviors.LazyAvoidanceOff();
			_brain.SteeringBehaviors.WallAvoidanceOff();
			_brain.ClearRotating();
		}

		private void CalculateNavigationPath(Waypoint destinationWaypoint)
		{
			float num = 10000f;
			if (_currentWaypoint != null)
			{
				num = Vector3.Distance(_brain.ThisDrone.transform.position, _currentWaypoint.transform.position);
			}
			if ((double)num > 0.03)
			{
				IEnumerable<Waypoint> enumerable = ((!(_brain.ThisDrone.CurrentRoom != null)) ? NavigationHelper.GetWaypoints() : (from x in NavigationHelper.GetWaypoints()
					where x.Room == _brain.ThisDrone.CurrentRoom && x.ConnectedWaypoints.Count > 0
					select x));
				foreach (Waypoint item in enumerable)
				{
					if (_brain != null && _brain.ThisDrone != null && item != null)
					{
						float num2 = Vector3.Distance(_brain.ThisDrone.transform.position, item.transform.position);
						if (num2 < num)
						{
							num = num2;
							_currentWaypoint = item;
						}
					}
				}
			}
			_currentPath = NavigationHelper.FindPath(_currentWaypoint, destinationWaypoint);
			if (!HasNoCurrentPath() && _currentPath.Contains(_currentWaypoint) && _currentPath[0] != _currentWaypoint)
			{
				foreach (Waypoint item2 in _currentPath.ToList())
				{
					if (item2 != _currentWaypoint)
					{
						_currentPath.Remove(item2);
						continue;
					}
					break;
				}
			}
			if (!HasNoCurrentPath() && _currentPath.Count > 2 && _brain.ThisDrone.CurrentCorridor != null && _currentPath[0].Door.LabelSimple == _brain.ThisDrone.CurrentCorridor.door.LabelSimple && _currentPath[1].Door.LabelSimple == _brain.ThisDrone.CurrentCorridor.door.LabelSimple && _currentPath[1].Room.LabelSimple == _currentPath[2].Room.LabelSimple)
			{
				_currentPath.Remove(_currentPath.First());
			}
		}

		public bool HasNoCurrentPath()
		{
			return _currentPath == null || _currentPath.Count == 0;
		}

		private void HandleResetNavigation(object sender, EventArgs args)
		{
			if (_currentPath != null && _targetWaypoint != null)
			{
				_currentPath = null;
				_currentWaypoint = null;
				CalculateNavigationPath(_targetWaypoint);
			}
		}
	}
}

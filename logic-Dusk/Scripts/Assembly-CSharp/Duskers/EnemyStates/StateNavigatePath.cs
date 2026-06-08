using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateNavigatePath : BaseEnemyState
	{
		private Waypoint _currentWaypoint;

		private List<Waypoint> _currentPath;

		private Waypoint _targetWaypoint;

		private IState _returnState;

		private bool _firstNodeForRotating;

		private float _overrideSpeed;

		private bool _isDbf;

		public override string StateId
		{
			get
			{
				return "NavigatePath";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateNavigatePath(BaseEnemyBrain brain)
			: base(brain)
		{
			if (brain is DbfBrain)
			{
				_isDbf = true;
			}
			EventManager.Instance.SubscribeInstant(GeneralEventType.RefreshNavigation, HandleResetNavigation);
		}

		public void Initialize(Waypoint destinationWaypoint, IState returnState)
		{
			_targetWaypoint = destinationWaypoint;
			_currentWaypoint = null;
			_currentPath = null;
			_returnState = returnState;
			_overrideSpeed = 0f;
		}

		public void Initialize(Waypoint destinationWaypoint, IState returnState, float overrideSpeed)
		{
			_targetWaypoint = destinationWaypoint;
			_currentWaypoint = null;
			_currentPath = null;
			_returnState = returnState;
			_overrideSpeed = overrideSpeed;
		}

		public override void Update()
		{
			bool flag = _currentPath == null || _currentPath.Count == 0;
			bool flag2 = false;
			if (_currentPath != null && _currentPath.Count > 0)
			{
				Waypoint waypoint = _currentPath[0];
				Door door = waypoint.Door;
				if (door != null && door.state == DoorState.Closed)
				{
					if (_brain.ThisEnemy.CurrentRoom != null && _brain.ThisEnemy.CurrentRoom != waypoint.Room)
					{
						flag2 = true;
					}
					else if (_brain.ThisEnemy.CurrentRoom != null && _currentPath.Count > 1 && _currentPath[1].Room != waypoint.Room)
					{
						flag2 = true;
					}
				}
			}
			if (flag || flag2)
			{
				ChangeState(_returnState);
				return;
			}
			if (_brain.RotatesBeforeNavigate && _firstNodeForRotating && !_brain.RotateWhileNotLookingAtTarget())
			{
				_firstNodeForRotating = false;
			}
			if (_firstNodeForRotating || _currentPath == null || _currentPath.Count <= 0)
			{
				return;
			}
			Waypoint waypoint2 = _currentPath[0];
			_brain.ThisEnemy.LookAt(waypoint2.transform.position);
			bool flag3 = false;
			float num = Vector3.Distance(_brain.ThisEnemy.transform.position, waypoint2.transform.position);
			if ((double)num > 0.5)
			{
				if (_overrideSpeed > 0f)
				{
					_brain.ThisEnemy.moveForward(_overrideSpeed);
				}
				else
				{
					_brain.ThisEnemy.moveForward();
				}
				float num2 = Vector3.Distance(waypoint2.transform.position, _brain.ThisEnemy.Position);
				if (_isDbf && num2 > num)
				{
					flag3 = true;
				}
			}
			else
			{
				flag3 = true;
			}
			if (flag3)
			{
				_currentWaypoint = waypoint2;
				_currentPath.Remove(waypoint2);
			}
		}

		public void ForceReturnToPrevious()
		{
			ChangeState(_returnState);
		}

		public override void EnterState()
		{
			if (_targetWaypoint == null)
			{
				Debug.LogWarning("_targetWaypoint must be set for this state to work properly");
			}
			else
			{
				CalculateNavigationPath(_targetWaypoint);
			}
			if (_brain.RotatesBeforeNavigate && _currentPath != null && _currentPath.Count > 0)
			{
				_firstNodeForRotating = true;
				_brain.InitializeRotation(_currentPath[0].transform.position);
			}
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
			_brain.IgnoreCombatWhileNavigating = false;
			_firstNodeForRotating = false;
			_targetWaypoint = null;
			_currentWaypoint = null;
			_currentPath = null;
			_returnState = null;
			_overrideSpeed = 0f;
		}

		private void CalculateNavigationPath(Waypoint destinationWaypoint)
		{
			if (_brain.ThisEnemy == null)
			{
				Debug.LogWarning("CalcPath: Null enemy on brain?? - " + _brain.GetType().ToString());
				return;
			}
			float num = 10000f;
			if (_currentWaypoint != null)
			{
				num = Vector3.Distance(_brain.ThisEnemy.transform.position, _currentWaypoint.transform.position);
			}
			if ((double)num > 0.03)
			{
				IEnumerable<Waypoint> enumerable = ((!(_brain.ThisEnemy.CurrentRoom != null)) ? NavigationHelper.GetWaypoints() : (from x in NavigationHelper.GetWaypoints()
					where x.Room == _brain.ThisEnemy.CurrentRoom && x.ConnectedWaypoints.Count > 0
					select x));
				foreach (Waypoint item in enumerable)
				{
					if (item == null)
					{
						continue;
					}
					if (_brain.ThisEnemy == null)
					{
						Debug.LogWarning("CalcPath: Null enemy on brain?? - " + _brain.GetType().ToString());
						continue;
					}
					float num2 = Vector3.Distance(_brain.ThisEnemy.transform.position, item.transform.position);
					if (num2 < num)
					{
						num = num2;
						_currentWaypoint = item;
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
			if (!HasNoCurrentPath() && _currentPath.Count > 2 && _brain.ThisEnemy.CurrentCorridor != null && _currentPath[0].Door.LabelSimple == _brain.ThisEnemy.CurrentCorridor.door.LabelSimple && _currentPath[1].Door.LabelSimple == _brain.ThisEnemy.CurrentCorridor.door.LabelSimple && _currentPath[1].Room.LabelSimple == _currentPath[2].Room.LabelSimple)
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
			if (_currentPath != null && _targetWaypoint != null && _brain.ThisEnemy != null && !_brain.ThisEnemy.IsDead)
			{
				_currentPath = null;
				_currentWaypoint = null;
				CalculateNavigationPath(_targetWaypoint);
			}
			if (_brain.ThisEnemy == null)
			{
				Debug.LogWarning("HandleResetNavigation - _brain.ThisEnemy is null - " + _brain.GetType().ToString());
			}
		}
	}
}

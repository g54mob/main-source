using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateFlee : BaseEnemyState
	{
		private const float FLEE_CHECK_TIME_DELAY = 1f;

		private float _fleeCheckTimer;

		private Waypoint _currentRoomWaypoint;

		private float _overrideSpeed;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "Flee";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateFlee(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public void Initialize(float overrideSpeed)
		{
			_overrideSpeed = overrideSpeed;
		}

		public override void Update()
		{
			if (!_brain.ThisEnemy.ShouldLeaveCurrentRoom())
			{
				ChangeState(_brain.StatePatrol);
				return;
			}
			_fleeCheckTimer -= Time.deltaTime;
			if (!(_fleeCheckTimer <= 0f))
			{
				return;
			}
			Waypoint waypoint = PickLeastScaryAdjacentRoomToMoveTo();
			if (waypoint != null)
			{
				if (_overrideSpeed == 0f)
				{
					_brain.StateNavigatePath.Initialize(waypoint, this);
				}
				else
				{
					_brain.StateNavigatePath.Initialize(waypoint, this, _overrideSpeed);
				}
				ChangeState(_brain.StateNavigatePath);
				return;
			}
			List<Waypoint> list = (from x in NavigationHelper.GetWaypoints()
				where x.Room == _brain.ThisEnemy.CurrentRoom
				select x).ToList();
			if (list.Count > 0)
			{
				float num = 0f;
				if (_currentRoomWaypoint != null)
				{
					num = Vector3.Distance(_currentRoomWaypoint.transform.position, _brain.ThisEnemy.transform.position);
				}
				if (_currentRoomWaypoint == null || num < 0.5f)
				{
					_currentRoomWaypoint = CommonMethods.PickRandomItem(list, _random);
				}
				if (_currentRoomWaypoint != null)
				{
					_brain.ThisEnemy.DisconnectOverlay();
					_brain.ThisEnemy.LookAt(_currentRoomWaypoint.transform.position);
					_brain.ThisEnemy.ReconnectOverlay();
					_brain.ThisEnemy.moveForward();
				}
			}
			else
			{
				_fleeCheckTimer = 1f;
			}
		}

		public override void EnterState()
		{
			_fleeCheckTimer = 1f;
		}

		public override void ExitState()
		{
			_overrideSpeed = 0f;
		}

		private Waypoint PickLeastScaryAdjacentRoomToMoveTo()
		{
			Waypoint result = null;
			IEnumerable<AdjacentRoomData> allAdjacentRoomData = NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom);
			if (allAdjacentRoomData.Any((AdjacentRoomData x) => _brain.ThisEnemy.AdjacentRoomCanBeEntered(x)))
			{
				List<Room> list = new List<Room>();
				foreach (AdjacentRoomData item in allAdjacentRoomData)
				{
					if (item.ConnectingDoor.state == DoorState.Open)
					{
						if (item.Room1 != _brain.ThisEnemy.CurrentRoom)
						{
							list.Add(item.Room1);
						}
						else
						{
							list.Add(item.Room2);
						}
					}
				}
				Room room = CommonMethods.PickRandomItem(list, _random);
				if (room != null)
				{
					result = NavigationHelper.GetMainRoomWaypoint(room);
				}
			}
			return result;
		}
	}
}

using System;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StatePatrolChewDoor : BaseEnemyState
	{
		private Door _doorToChew;

		private float _doorAttackTimer;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "PatrolChewDoor";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StatePatrolChewDoor(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public void Initialize(Door doorToChew)
		{
			_doorToChew = doorToChew;
		}

		public override void Update()
		{
			if (_doorToChew != null && _doorToChew.state == DoorState.Open)
			{
				AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(_doorToChew);
				Room room = ((!(adjacentRoomData.Room1 != _brain.ThisEnemy.CurrentRoom)) ? adjacentRoomData.Room2 : adjacentRoomData.Room1);
				_brain.StatePatrolNavigatePath.Initialize(NavigationHelper.GetMainRoomWaypoint(room), _brain.StatePatrolIdle);
				ChangeState(_brain.StatePatrolNavigatePath);
				return;
			}
			if (_doorToChew != null && _doorAttackTimer > 0f)
			{
				_doorAttackTimer -= Time.deltaTime;
				if (_doorAttackTimer <= 0f)
				{
					_doorAttackTimer = 1f;
					_doorToChew.TakeDamage(1f, DamageType.Physical, _brain.ThisEnemy);
				}
			}
			Waypoint waypoint = CheckForWanderDestination();
			if (waypoint != null)
			{
				_brain.StatePatrolNavigatePath.Initialize(waypoint, _brain.StatePatrolIdle);
				ChangeState(_brain.StatePatrolNavigatePath);
			}
		}

		public override void EnterState()
		{
			if (_doorToChew == null)
			{
				Debug.LogWarning("_doorToChew cannot be null for this state");
			}
			else if (_doorToChew.onSchematic || GlobalSettings.cheatMode)
			{
				string message = string.Format("Door {0} is being attacked", _doorToChew.Label);
				SystemMessageManager.ShowSystemMessage(message, ConsoleMessageType.Warning);
			}
			_doorAttackTimer = 1f;
		}

		public override void ExitState()
		{
			_brain.LastChewedDoor = _doorToChew;
			_brain.LastChewedDoorInRoom = _brain.ThisEnemy.CurrentRoom;
			_brain.LastChewedDoorTimer = _brain.DOOR_CHEWED_REMEMBER_TIME;
			_doorToChew = null;
		}

		private Waypoint CheckForWanderDestination()
		{
			Waypoint result = null;
			if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.Wanders) && _brain.WanderCheckTimer <= 0f)
			{
				_brain.WanderCheckTimer = _brain.WANDER_CHECK_PERIOD;
				bool flag = false;
				if (_brain.WANDERYNESS == 100 || (_brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null))
				{
					flag = true;
				}
				else if (_brain.WANDERYNESS == 0)
				{
					flag = false;
				}
				else
				{
					int num = _random.Next(1, 101);
					flag = num <= _brain.WANDERYNESS;
				}
				AdjacentRoomData adjacentRoomData = null;
				if (_brain.ThisEnemy.CurrentRoom != null && NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom).Count() > 0)
				{
					adjacentRoomData = NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom).FirstOrDefault((AdjacentRoomData x) => _brain.ThisEnemy.AdjacentRoomCanBeEntered(x));
				}
				else if (_brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null)
				{
					adjacentRoomData = NavigationHelper.GetAdjacentRoomData(_brain.ThisEnemy.CurrentCorridor.door);
				}
				if (flag && adjacentRoomData != null)
				{
					result = ((!(_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1)) ? NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room1) : NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room2));
				}
			}
			return result;
		}
	}
}

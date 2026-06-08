using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StatePatrolIdle : BaseEnemyState
	{
		private int _droneMovingDoorChewChance;

		private int _droneIdleDoorChewChance;

		private int _lureDoorChewChance;

		private int _generalDoorChewChance;

		private static System.Random _random = new System.Random();

		private bool _tutorialFirstTimeWandered;

		public override string StateId
		{
			get
			{
				return "PatrolIdle";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StatePatrolIdle(BaseEnemyBrain brain)
			: base(brain)
		{
			_droneMovingDoorChewChance = Mathf.RoundToInt(4f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventSwarmChewValue);
			_droneIdleDoorChewChance = Mathf.RoundToInt(5f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventSwarmChewValue);
			_lureDoorChewChance = Mathf.RoundToInt(20f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventSwarmChewValue);
			_generalDoorChewChance = Mathf.RoundToInt(4f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventSwarmChewValue);
		}

		public override void Update()
		{
			Door door = null;
			if (_brain.LastChewedDoorTimer > 0f && _brain.LastChewedDoor != null)
			{
				if (_brain.LastChewedDoor.state == DoorState.Closed)
				{
					AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(_brain.LastChewedDoor);
					if (_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1 || _brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room2 || (_brain.ThisEnemy.CurrentCorridor != null && _brain.ThisEnemy.CurrentCorridor.door == _brain.LastChewedDoor))
					{
						door = _brain.LastChewedDoor;
					}
				}
				else if (!_brain.LastChewedDoor.corridor.containsRoom(_brain.ThisEnemy.CurrentRoom))
				{
					_brain.LastChewedDoor = null;
					_brain.LastChewedDoorInRoom = null;
				}
				else if (_brain.LastChewedDoor.corridor.getOtherRoom(_brain.LastChewedDoorInRoom) == _brain.ThisEnemy.CurrentRoom)
				{
					_brain.LastChewedDoorTimer -= Time.deltaTime;
					if (!(_brain.LastChewedDoorTimer <= 0f))
					{
						return;
					}
					_brain.LastChewedDoor = null;
					_brain.LastChewedDoorInRoom = null;
				}
			}
			if (door == null)
			{
				door = DecideDoorToChew();
			}
			if (door != null)
			{
				_brain.LastChewedDoor = door;
				_brain.LastChewedDoorTimer = _brain.DOOR_CHEWED_REMEMBER_TIME;
				_brain.StatePatrolChewDoor.Initialize(door);
				ChangeState(_brain.StatePatrolChewDoor);
				return;
			}
			Waypoint waypoint = CheckForWanderDestination();
			if (waypoint != null)
			{
				_brain.StatePatrolNavigatePath.Initialize(waypoint, this);
				ChangeState(_brain.StatePatrolNavigatePath);
			}
		}

		public override void EnterState()
		{
			if (_tutorialFirstTimeWandered && GlobalSettings.IsTutorial)
			{
				_brain.WanderCheckTimer = _brain.WANDER_CHECK_PERIOD;
			}
			_brain.StartIdleAnimation();
		}

		public override void ExitState()
		{
		}

		private Door DecideDoorToChew()
		{
			Door door = null;
			if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.ChewsThroughDoors) && _brain.ThisEnemy.CurrentRoom != null && !GlobalSettings.IsTutorial && GlobalSettings.MissionStarted)
			{
				if (_brain.DroneMovingDoorChewTimer <= 0f)
				{
					door = CheckForDoorToChewForDronePresence(true, _droneMovingDoorChewChance);
					_brain.DroneMovingDoorChewTimer = _brain.DRONE_MOVING_DOOR_CHEW_TIME;
				}
				if (door == null && _brain.DroneIdleDoorChewTimer <= 0f)
				{
					door = CheckForDoorToChewForDronePresence(false, _droneIdleDoorChewChance);
					_brain.DroneIdleDoorChewTimer = _brain.DRONE_IDLE_DOOR_CHEW_TIME;
				}
				if (door == null && _brain.LureDoorChewTimer <= 0f)
				{
					door = CheckForDoorToChewForGeneralCombatTargets(_brain.DroneManager.GetAvailableLures(), _lureDoorChewChance);
					_brain.LureDoorChewTimer = _brain.LURE_DOOR_CHEW_TIME;
				}
				if (door == null && _brain.GeneralDoorChewTimer <= 0f)
				{
					door = CheckForDoorToChewGeneral();
					_brain.GeneralDoorChewTimer = _brain.GENERAL_DOOR_CHEW_TIME;
				}
			}
			if (door != null && door.corridor.IsAirlock)
			{
				door = null;
			}
			return door;
		}

		private Door CheckForDoorToChewForDronePresence(bool checkMovingDrones, int percentChanceToChew)
		{
			int num = _random.Next(1, 101);
			bool flag = num <= percentChanceToChew;
			Door result = null;
			if (flag)
			{
				IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
					where x.ConnectingDoor != null && x.ConnectingDoor.state == DoorState.Closed && !x.ConnectingDoor.corridor.IsAirlock
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room adjacentRoom;
					if (item.Room1 == _brain.ThisEnemy.CurrentRoom)
					{
						adjacentRoom = item.Room2;
					}
					else
					{
						adjacentRoom = item.Room1;
					}
					Drone drone = _brain.DroneManager.dronesList.FirstOrDefault((Drone x) => !x.IsDead && checkMovingDrones == x.isMoving && x.CurrentRoom == adjacentRoom);
					if (drone != null)
					{
						result = item.ConnectingDoor;
						break;
					}
				}
			}
			return result;
		}

		private Door CheckForDoorToChewForGeneralCombatTargets(IEnumerable<ICombatTarget> combatTargets, int percentChanceToChew)
		{
			int num = _random.Next(1, 101);
			bool flag = num <= percentChanceToChew;
			Door result = null;
			if (flag)
			{
				IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
					where x.ConnectingDoor != null && x.ConnectingDoor.state == DoorState.Closed && !x.ConnectingDoor.corridor.IsAirlock
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room adjacentRoom;
					if (item.Room1 == _brain.ThisEnemy.CurrentRoom)
					{
						adjacentRoom = item.Room2;
					}
					else
					{
						adjacentRoom = item.Room1;
					}
					ICombatTarget combatTarget = combatTargets.FirstOrDefault((ICombatTarget x) => !x.IsDead && x.CurrentRoom == adjacentRoom);
					if (combatTarget != null)
					{
						result = item.ConnectingDoor;
						Debug.Log("lure chew");
						break;
					}
				}
			}
			return result;
		}

		private Door CheckForDoorToChewGeneral()
		{
			int num = _random.Next(1, 101);
			bool flag = num <= _generalDoorChewChance;
			Door result = null;
			if (flag)
			{
				IEnumerable<Waypoint> enumerable = from x in NavigationHelper.GetDoorWaypointsInThisRoom(_brain.ThisEnemy.CurrentRoom)
					where !x.Door.IsDead && x.Door.state == DoorState.Closed
					select x;
				int num2 = enumerable.Count();
				if (num2 > 0)
				{
					int num3 = _random.Next(0, num2);
					int num4 = 0;
					foreach (Waypoint item in enumerable)
					{
						if (num4++ == num3)
						{
							result = item.Door;
							break;
						}
					}
				}
			}
			return result;
		}

		private Waypoint CheckForWanderDestination()
		{
			Waypoint result = null;
			if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.Wanders))
			{
				bool flag = GlobalSettings.IsTutorial && !_tutorialFirstTimeWandered;
				if (_brain.WanderCheckTimer <= 0f || flag)
				{
					_brain.WanderCheckTimer = _brain.WANDER_CHECK_PERIOD;
					bool flag2 = false;
					if (_brain.WANDERYNESS == 100 || GlobalSettings.IsTutorial || (_brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null))
					{
						flag2 = true;
					}
					else if (_brain.WANDERYNESS == 0)
					{
						flag2 = false;
					}
					else
					{
						int num = _random.Next(1, 101);
						flag2 = num <= _brain.WANDERYNESS;
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
					if (flag2 && adjacentRoomData != null)
					{
						_tutorialFirstTimeWandered = true;
						result = ((!(_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1)) ? NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room1) : NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room2));
					}
				}
			}
			return result;
		}
	}
}

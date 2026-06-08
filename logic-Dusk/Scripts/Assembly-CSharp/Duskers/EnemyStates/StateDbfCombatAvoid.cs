using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfCombatAvoid : BaseEnemyState, ICombatState
	{
		private const float BACKUP_TIME_MIN = 0.4f;

		private const float BACKUP_TIME_MAX = 0.8f;

		private const int CHANCE_TO_LEAVE_ROOM = 60;

		private const int CHANCE_TO_CHOOSE_CLOSEST_DOOR = 80;

		private ICombatTarget _combatTarget;

		private DbfBrain _dbfBrain;

		private float _backupTimer;

		private static System.Random _random = new System.Random();

		private List<Door> _openDoors = new List<Door>(6);

		public override string StateId
		{
			get
			{
				return "DbfCombatAvoid";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfCombatAvoid(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			_combatTarget = target;
		}

		public override void Update()
		{
			bool flag = false;
			float num = Vector3.Distance(_combatTarget.Position, _brain.ThisEnemy.Position);
			if (num < 3f)
			{
				_brain.ThisEnemy.DisconnectOverlay();
				_brain.ThisEnemy.LookAt(_combatTarget.Position);
				_brain.ThisEnemy.ReconnectOverlay();
				Vector3 position = _brain.ThisEnemy.Position;
				_brain.ThisEnemy.moveBackwards();
				flag = ProcessRearHitDetection(position);
				if (_backupTimer > 0f)
				{
					_backupTimer -= Time.deltaTime;
				}
				if (_brain.ThisEnemy.CurrentRoom != null && (flag || _backupTimer <= 0f))
				{
					ChooseHowToFlee();
				}
			}
			else
			{
				_dbfBrain.StateDbfCombatIdle.Initialize(_combatTarget);
				ChangeState(_dbfBrain.StateDbfCombatIdle);
			}
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
			_backupTimer = UnityEngine.Random.Range(0.4f, 0.8f);
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
		}

		private bool ProcessRearHitDetection(Vector3 startPos)
		{
			bool flag = false;
			bool leftFeeler = false;
			bool rightFeeler = false;
			if (_brain.ThisEnemy.CurrentRoom != null)
			{
				flag = FeelersCollidingWithAnyWallsInRoom(_brain.ThisEnemy.CurrentRoom, out leftFeeler, out rightFeeler);
				if (!flag)
				{
					flag = FeelersCollidingWithAnyDoorInRoom(_brain.ThisEnemy.CurrentRoom, out leftFeeler, out rightFeeler);
				}
			}
			else if (_brain.ThisEnemy.CurrentCorridor != null)
			{
				flag = FeelersCollidingWithDoor(_brain.ThisEnemy.CurrentCorridor, out leftFeeler, out rightFeeler);
			}
			if (flag)
			{
				Vector3 position = startPos;
				if (rightFeeler && !leftFeeler)
				{
					position = startPos - _brain.ThisEnemy.transform.right * 0.03f;
				}
				else if (leftFeeler && !rightFeeler)
				{
					position = startPos + _brain.ThisEnemy.transform.right * 0.03f;
				}
				_brain.ThisEnemy.SetPosition(position);
				bool flag2 = false;
				if (_brain.ThisEnemy.CurrentRoom != null)
				{
					flag2 = BodyCollidingWithAnyWallsInRoom(_brain.ThisEnemy.CurrentRoom);
					if (!flag2)
					{
						flag2 = BodyCollidingWithAnyDoorInRoom(_brain.ThisEnemy.CurrentRoom);
					}
				}
				else if (_brain.ThisEnemy.CurrentCorridor != null)
				{
					flag2 = BodyCollidingWithDoor(_brain.ThisEnemy.CurrentCorridor);
				}
				if (flag2)
				{
					_brain.ThisEnemy.SetPosition(startPos);
				}
			}
			return flag;
		}

		private bool FeelersCollidingWithAnyWallsInRoom(Room room, out bool leftFeeler, out bool rightFeeler)
		{
			leftFeeler = false;
			rightFeeler = false;
			if (room.wallModels != null && room.wallModels.Count > 0)
			{
				for (int i = 0; i < room.wallModels.Count; i++)
				{
					GameObject gameObject = room.wallModels[i];
					if (!(gameObject == null))
					{
						leftFeeler = gameObject.GetComponent<Collider>().bounds.Intersects(_dbfBrain.Dbf.RearLeftFeeler.GetComponent<Collider>().bounds);
						rightFeeler = gameObject.GetComponent<Collider>().bounds.Intersects(_dbfBrain.Dbf.RearRightFeeler.GetComponent<Collider>().bounds);
						if (leftFeeler || rightFeeler)
						{
							return true;
						}
					}
				}
			}
			else
			{
				leftFeeler = PointIsInOuterSpace(_dbfBrain.Dbf.RearLeftFeeler.transform.position);
				rightFeeler = PointIsInOuterSpace(_dbfBrain.Dbf.RearRightFeeler.transform.position);
				if (leftFeeler || rightFeeler)
				{
					return true;
				}
			}
			return false;
		}

		private bool BodyCollidingWithAnyWallsInRoom(Room room)
		{
			if (room.wallModels != null && room.wallModels.Count > 0)
			{
				for (int i = 0; i < room.wallModels.Count; i++)
				{
					GameObject gameObject = room.wallModels[i];
					if (!(gameObject == null) && gameObject.GetComponent<Collider>().bounds.Intersects(_dbfBrain.Dbf.ObjectCollider.bounds))
					{
						return true;
					}
				}
			}
			else if (PointIsInOuterSpace(_dbfBrain.Dbf.transform.position))
			{
				return true;
			}
			return false;
		}

		private bool FeelersCollidingWithAnyDoorInRoom(Room room, out bool leftFeeler, out bool rightFeeler)
		{
			leftFeeler = false;
			rightFeeler = false;
			for (int i = 0; i < room.corridors.Count; i++)
			{
				Corridor corridor = room.corridors[i];
				if (!(corridor == null) && FeelersCollidingWithDoor(corridor, out leftFeeler, out rightFeeler))
				{
					return true;
				}
			}
			return false;
		}

		private bool BodyCollidingWithAnyDoorInRoom(Room room)
		{
			for (int i = 0; i < room.corridors.Count; i++)
			{
				Corridor corridor = room.corridors[i];
				if (!(corridor == null) && BodyCollidingWithDoor(corridor))
				{
					return true;
				}
			}
			return false;
		}

		private bool FeelersCollidingWithDoor(Corridor corridor, out bool leftFeeler, out bool rightFeeler)
		{
			leftFeeler = false;
			rightFeeler = false;
			if (corridor.door == null || corridor.door.sliderA == null || corridor.door.sliderB == null)
			{
				return false;
			}
			BoxCollider boxCollider = corridor.door.sliderA.gameObject.GetComponents<BoxCollider>().FirstOrDefault();
			BoxCollider boxCollider2 = corridor.door.sliderB.gameObject.GetComponents<BoxCollider>().FirstOrDefault();
			if (boxCollider != null)
			{
				leftFeeler = boxCollider.bounds.Intersects(_dbfBrain.Dbf.RearLeftFeeler.GetComponent<Collider>().bounds);
				rightFeeler = boxCollider.bounds.Intersects(_dbfBrain.Dbf.RearRightFeeler.GetComponent<Collider>().bounds);
				if (leftFeeler || rightFeeler)
				{
					return true;
				}
			}
			if (boxCollider2 != null)
			{
				leftFeeler = boxCollider2.bounds.Intersects(_dbfBrain.Dbf.RearLeftFeeler.GetComponent<Collider>().bounds);
				rightFeeler = boxCollider2.bounds.Intersects(_dbfBrain.Dbf.RearRightFeeler.GetComponent<Collider>().bounds);
				if (leftFeeler || rightFeeler)
				{
					return true;
				}
			}
			return false;
		}

		private bool BodyCollidingWithDoor(Corridor corridor)
		{
			if (corridor.door == null || corridor.door.sliderA == null || corridor.door.sliderB == null)
			{
				return false;
			}
			BoxCollider boxCollider = corridor.door.sliderA.gameObject.GetComponents<BoxCollider>().FirstOrDefault();
			BoxCollider boxCollider2 = corridor.door.sliderB.gameObject.GetComponents<BoxCollider>().FirstOrDefault();
			if (boxCollider != null && boxCollider.bounds.Intersects(_dbfBrain.Dbf.ObjectCollider.bounds))
			{
				return true;
			}
			if (boxCollider2 != null && boxCollider2.bounds.Intersects(_dbfBrain.Dbf.ObjectCollider.bounds))
			{
				return true;
			}
			return false;
		}

		private bool PointIsInOuterSpace(Vector3 testPosition)
		{
			Room[] rooms = DungeonManager.Instance.rooms;
			foreach (Room room in rooms)
			{
				Vector3 point = new Vector3(testPosition.x, testPosition.y, room.transform.position.z);
				if (room.GetComponent<Collider>().bounds.Contains(point))
				{
					return false;
				}
			}
			Corridor[] corridors = DungeonManager.Instance.corridors;
			foreach (Corridor corridor in corridors)
			{
				Vector3 point2 = new Vector3(testPosition.x, testPosition.y, corridor.transform.position.z);
				if (corridor.GetComponent<Collider>().bounds.Contains(point2))
				{
					return false;
				}
			}
			return true;
		}

		private void ChooseHowToFlee()
		{
			if (_brain.ThisEnemy.CurrentRoom == null)
			{
				return;
			}
			bool flag = false;
			_openDoors.Clear();
			foreach (Corridor corridor in _brain.ThisEnemy.CurrentRoom.corridors)
			{
				if (corridor.door.state == DoorState.Open)
				{
					_openDoors.Add(corridor.door);
					flag = true;
				}
			}
			if (flag && _random.Next(1, 101) <= 60)
			{
				Door door = null;
				if (_random.Next(1, 101) <= 80)
				{
					float num = float.MaxValue;
					foreach (Door openDoor in _openDoors)
					{
						float num2 = Vector3.Distance(_brain.ThisEnemy.Position, openDoor.Position);
						if (num2 < num)
						{
							num = num2;
							door = openDoor;
						}
					}
				}
				else
				{
					door = CommonMethods.PickRandomItem(_openDoors);
				}
				AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(door);
				Room room = ((!(adjacentRoomData.Room1 == _brain.ThisEnemy.CurrentRoom)) ? adjacentRoomData.Room1 : adjacentRoomData.Room2);
				_brain.IgnoreCombatWhileNavigating = true;
				_brain.ForceNavigateToWaypoint(NavigationHelper.GetMainRoomWaypoint(room), _dbfBrain.Dbf.RunSpeed);
				return;
			}
			BoxCollider component = _brain.ThisEnemy.CurrentRoom.gameObject.GetComponent<BoxCollider>();
			bool flag2 = false;
			Vector3 moveToPosition = Vector3.zero;
			for (int i = 0; i < 25; i++)
			{
				float x = component.bounds.min.x;
				float x2 = component.bounds.max.x;
				float y = component.bounds.min.y;
				float y2 = component.bounds.max.y;
				float x3 = UnityEngine.Random.Range(x, x2);
				float y3 = UnityEngine.Random.Range(y, y2);
				Vector3 vector = new Vector3(x3, y3, 0f);
				foreach (GameObject staticCollisionObject in _brain.ThisEnemy.CurrentRoom.StaticCollisionObjects)
				{
					Collider component2 = staticCollisionObject.GetComponent<Collider>();
					if (component2.bounds.Contains(vector))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				foreach (Drone drones in DroneManager.Instance.dronesList)
				{
					if (!(drones.CurrentRoom != _brain.ThisEnemy.CurrentRoom))
					{
						float num3 = Vector3.Distance(drones.Position, vector);
						if (num3 < 0.75f)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					continue;
				}
				foreach (Drone lootableDrones in DroneManager.Instance.LootableDronesList)
				{
					if (!(lootableDrones.CurrentRoom != _brain.ThisEnemy.CurrentRoom))
					{
						float num4 = Vector3.Distance(lootableDrones.Position, vector);
						if (num4 < 0.75f)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					moveToPosition = vector;
					break;
				}
			}
			if (!flag2)
			{
				_dbfBrain.StateDbfRunToSpot.Initialize(moveToPosition, _combatTarget);
				ChangeState(_dbfBrain.StateDbfRunToSpot);
			}
		}
	}
}

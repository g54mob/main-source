using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StatePatrolBotScan : BaseEnemyState
	{
		private const float SIT_STILL_MIN = 1f;

		private const float SIT_STILL_MAX = 3f;

		private const float MAX_IDLE_TIME = 7f;

		private float _sitStillTimer;

		private Quaternion _stopRotation;

		private float _degreesLeft;

		private float _direction;

		private bool _doneWithInitialRotation;

		private float _idleTimer;

		private static System.Random _random = new System.Random();

		private bool _tutorialFirstTimeWandered;

		private Door _doorJustOpened;

		private Dictionary<Room, float> _roomVisitHistory = new Dictionary<Room, float>();

		private Room _lastRoom;

		private PatrolBotBrain _patrolBotBrain;

		public override string StateId
		{
			get
			{
				return "PatrolBotScan";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StatePatrolBotScan(BaseEnemyBrain brain)
			: base(brain)
		{
			_patrolBotBrain = (PatrolBotBrain)brain;
			EventManager.Instance.SubscribeInstant(GeneralEventType.DoorOpened, HandleDoorOpened);
		}

		public override void Update()
		{
			if (_sitStillTimer > 0f)
			{
				_sitStillTimer -= Time.deltaTime;
				return;
			}
			if (_brain.ThisEnemy.CurrentRoom != null && _brain.ThisEnemy.CurrentRoom != _lastRoom)
			{
				if (_lastRoom != null)
				{
					_roomVisitHistory[_lastRoom] = Time.time;
				}
				_lastRoom = _brain.ThisEnemy.CurrentRoom;
				_roomVisitHistory[_brain.ThisEnemy.CurrentRoom] = Time.time;
				_doorJustOpened = null;
			}
			if (!_doneWithInitialRotation && _patrolBotBrain.CurrentDestination == null)
			{
				if (!_patrolBotBrain.ThisPatrolBot.LightIsOn)
				{
					_patrolBotBrain.ThisPatrolBot.TurnOnLight(true);
				}
				float rotationRateDelta = _brain.ThisEnemy.GetRotationRateDelta();
				_degreesLeft -= rotationRateDelta;
				if (_degreesLeft > 0f)
				{
					rotationRateDelta *= _direction;
					_brain.ThisEnemy.DisconnectOverlay();
					_brain.ThisEnemy.transform.Rotate(0f, 0f, rotationRateDelta);
					_brain.ThisEnemy.ReconnectOverlay();
					return;
				}
				_doneWithInitialRotation = true;
				if (_patrolBotBrain.ThisPatrolBot.LightIsOn)
				{
					_patrolBotBrain.ThisPatrolBot.TurnOnLight(false);
				}
				_sitStillTimer = UnityEngine.Random.Range(1f, 3f);
				_idleTimer = _sitStillTimer + 7f;
				return;
			}
			Waypoint waypoint;
			if (_patrolBotBrain.CurrentDestination == null || _patrolBotBrain.ContinuePathRetryCount++ > 4)
			{
				_patrolBotBrain.ContinuePathRetryCount = 0;
				_patrolBotBrain.CurrentDestination = null;
				waypoint = CheckForWanderDestination();
			}
			else
			{
				waypoint = _patrolBotBrain.CurrentDestination;
			}
			if (waypoint != null)
			{
				if (_patrolBotBrain.ThisPatrolBot.LightIsOn)
				{
					_patrolBotBrain.ThisPatrolBot.TurnOnLight(false);
				}
				_patrolBotBrain.CurrentDestination = waypoint;
				_brain.StatePatrolNavigatePath.Initialize(waypoint, this);
				ChangeState(_brain.StatePatrolNavigatePath);
			}
			else
			{
				_idleTimer -= Time.deltaTime;
				if (_idleTimer <= 0f)
				{
					InitScanRotation();
				}
			}
		}

		public override void EnterState()
		{
			_sitStillTimer = UnityEngine.Random.Range(1f, 3f);
			InitScanRotation();
			if (!_patrolBotBrain.ThisPatrolBot.LightIsOn)
			{
				_patrolBotBrain.ThisPatrolBot.TurnOnLight(true);
			}
			if (_patrolBotBrain.CurrentDestination != null)
			{
				float num = Vector3.Distance(_patrolBotBrain.CurrentDestination.transform.position, _brain.ThisEnemy.Position);
				if (num <= 1f)
				{
					_patrolBotBrain.CurrentDestination = null;
					_patrolBotBrain.ContinuePathRetryCount = 0;
				}
			}
		}

		public override void ExitState()
		{
		}

		private void InitScanRotation()
		{
			_doneWithInitialRotation = false;
			_degreesLeft = 360f;
			_direction = ((_random.Next(0, 2) != 0) ? (-1f) : 1f);
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
					if (_brain.WANDERYNESS == 100 || flag || (_brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null))
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
					Room room = null;
					if (flag2)
					{
						if (_brain.ThisEnemy.CurrentRoom != null && NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom).Count() > 0)
						{
							room = SelectBestWanderRoom();
						}
						else if (_brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null)
						{
							AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(_brain.ThisEnemy.CurrentCorridor.door);
							room = ((!(_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1)) ? adjacentRoomData.Room1 : adjacentRoomData.Room2);
						}
					}
					if (flag2 && room != null)
					{
						_tutorialFirstTimeWandered = true;
						result = NavigationHelper.GetMainRoomWaypoint(room);
					}
				}
			}
			return result;
		}

		private Room SelectBestWanderRoom()
		{
			IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
				where _brain.ThisEnemy.AdjacentRoomCanBeEntered(x)
				select x;
			if (enumerable.Count() == 0)
			{
				return null;
			}
			AdjacentRoomData adjacentRoomData = null;
			if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.AttractedToLures))
			{
				IEnumerable<ICombatTarget> source = from x in _brain.DroneManager.GetAvailableLures()
					where !x.IsDead && !x.IsHidden && !_patrolBotBrain.ThisPatrolBot.RemembersLure(x)
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room otherRoom;
					if (_brain.ThisEnemy.CurrentRoom == item.Room1)
					{
						otherRoom = item.Room2;
					}
					else
					{
						otherRoom = item.Room1;
					}
					if (source.Any((ICombatTarget x) => x.CurrentRoom == otherRoom))
					{
						adjacentRoomData = item;
						break;
					}
				}
			}
			if (adjacentRoomData == null && _doorJustOpened != null)
			{
				AdjacentRoomData adjacentRoomData2 = enumerable.FirstOrDefault((AdjacentRoomData x) => x.ConnectingDoor == _doorJustOpened);
				if (adjacentRoomData2 != null)
				{
					Room key = ((!(_brain.ThisEnemy.CurrentRoom == adjacentRoomData2.Room1)) ? adjacentRoomData2.Room1 : adjacentRoomData2.Room2);
					if (_roomVisitHistory.ContainsKey(key) && Time.time - _roomVisitHistory[key] > 10f)
					{
						adjacentRoomData = adjacentRoomData2;
					}
				}
			}
			if (adjacentRoomData == null)
			{
				foreach (AdjacentRoomData item2 in enumerable)
				{
					Room key2 = ((!(_brain.ThisEnemy.CurrentRoom == item2.Room1)) ? item2.Room1 : item2.Room2);
					if (!_roomVisitHistory.ContainsKey(key2))
					{
						adjacentRoomData = item2;
						break;
					}
				}
			}
			if (adjacentRoomData == null)
			{
				float num = float.MaxValue;
				foreach (AdjacentRoomData item3 in enumerable)
				{
					Room key3 = ((!(_brain.ThisEnemy.CurrentRoom == item3.Room1)) ? item3.Room1 : item3.Room2);
					if (_roomVisitHistory[key3] < num)
					{
						adjacentRoomData = item3;
						num = _roomVisitHistory[key3];
					}
				}
			}
			if (_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1)
			{
				return adjacentRoomData.Room2;
			}
			return adjacentRoomData.Room1;
		}

		private void HandleDoorOpened(object sender, EventArgs args)
		{
			GeneralEventArgs e = (GeneralEventArgs)args;
			Door door = (Door)e.Data;
			if (_brain.ThisEnemy.CurrentRoom == door)
			{
				_doorJustOpened = door;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfCombatApproach : BaseEnemyState, ICombatState
	{
		private const float GROWL_CHECK_TIME = 3f;

		private const int GROWL_CHANCE = 40;

		private const float PANT_CHECK_TIME = 7f;

		private const int PANT_CHANCE = 50;

		private ICombatTarget _combatTarget;

		private DbfBrain _dbfBrain;

		private float _growlCheckTimer;

		private float _pantCheckTimer;

		private bool _canOverride;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "DbfCombatApproach";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfCombatApproach(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public void Initialize(ICombatTarget target)
		{
			if (target == null)
			{
				Debug.Log("Initializing w/ null??");
			}
			_combatTarget = target;
		}

		public override void Update()
		{
			if (!_brain.ThisEnemy.TargetIsInSameRoom(_combatTarget))
			{
				Waypoint waypoint = null;
				IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(_brain.ThisEnemy.CurrentRoom)
					where _brain.ThisEnemy.AdjacentRoomCanBeEntered(x)
					select x;
				foreach (AdjacentRoomData item in enumerable)
				{
					Room room = ((!(item.Room1 == _brain.ThisEnemy.CurrentRoom)) ? item.Room1 : item.Room2);
					if (_combatTarget.CurrentRoom == room)
					{
						waypoint = NavigationHelper.GetMainRoomWaypoint(room);
						break;
					}
				}
				if (waypoint != null)
				{
					_brain.StateCombatNavigate.Initialize(waypoint, _combatTarget, _dbfBrain.StateDbfCombatIdle);
					ChangeState(_brain.StateCombatNavigate);
				}
				return;
			}
			if (!_brain.RotatesBeforeAttack || !_brain.RotateWhileNotLookingAtTarget())
			{
				Approach();
			}
			_growlCheckTimer -= Time.deltaTime;
			if (_growlCheckTimer <= 0f)
			{
				_growlCheckTimer = 3f;
				int num = _random.Next(1, 101);
				if (num < 40)
				{
					_dbfBrain.Dbf.PlayGrowlSound();
					_pantCheckTimer = 7f;
				}
			}
			_pantCheckTimer -= Time.deltaTime;
			if (_pantCheckTimer <= 0f)
			{
				_pantCheckTimer = 7f;
				int num2 = _random.Next(1, 101);
				if (num2 < 50)
				{
					_dbfBrain.Dbf.PlayPantSound();
					_growlCheckTimer = 3f;
				}
			}
		}

		private void Approach()
		{
			Vector3 vector = _combatTarget.Position;
			bool flag = false;
			if (_canOverride && _brain.ThisEnemy.CurrentRoom != _combatTarget.CurrentRoom && _brain.ThisEnemy.CurrentCorridor != _combatTarget.CurrentCorridor)
			{
				Vector3 overrideDestination;
				flag = GetOverrideDestination(_brain.ThisEnemy, _combatTarget, out overrideDestination);
				if (flag)
				{
					vector = overrideDestination;
				}
			}
			float num = Vector3.Distance(vector, _brain.ThisEnemy.Position);
			float num2 = 3f;
			if (flag)
			{
				num2 = 0.2f;
			}
			if (num > num2)
			{
				_brain.ThisEnemy.DisconnectOverlay();
				_brain.ThisEnemy.LookAt(vector);
				_brain.ThisEnemy.ReconnectOverlay();
				_brain.ThisEnemy.moveForward();
				float num3 = Vector3.Distance(vector, _brain.ThisEnemy.Position);
				if (num3 > num)
				{
					_canOverride = false;
				}
			}
			else if (!flag)
			{
				_dbfBrain.StateDbfCombatIdle.Initialize(_combatTarget);
				ChangeState(_dbfBrain.StateDbfCombatIdle);
			}
			else
			{
				_canOverride = false;
			}
		}

		public override void EnterState()
		{
			if (_combatTarget == null)
			{
				Debug.LogWarning("_combatTarget must not be null" + _combatTarget);
			}
			_growlCheckTimer = 3f;
			_pantCheckTimer = 7f;
			_brain.InitializeRotation(_combatTarget.Position);
			_canOverride = true;
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
		}

		private static bool GetOverrideDestination(ICombatTarget thisEnemy, ITargetLocation combatTargetLocation, out Vector3 overrideDestination)
		{
			bool result = false;
			overrideDestination = Vector3.zero;
			Waypoint bestDoorWaypoint = GetBestDoorWaypoint(thisEnemy, combatTargetLocation);
			if (bestDoorWaypoint != null)
			{
				if (combatTargetLocation.CurrentRoom != null && thisEnemy.CurrentCorridor != null)
				{
					if (thisEnemy.CurrentCorridor.door.IsHorizontal)
					{
						overrideDestination = new Vector3(combatTargetLocation.CurrentRoom.transform.position.x, bestDoorWaypoint.transform.position.y, bestDoorWaypoint.transform.position.z);
					}
					else
					{
						overrideDestination = new Vector3(bestDoorWaypoint.transform.position.x, combatTargetLocation.CurrentRoom.transform.position.y, bestDoorWaypoint.transform.position.z);
					}
				}
				else
				{
					overrideDestination = bestDoorWaypoint.transform.position;
				}
				result = true;
			}
			return result;
		}

		private static Waypoint GetBestDoorWaypoint(ICombatTarget thisEnemy, ITargetLocation combatTargetLocation)
		{
			Waypoint waypoint = null;
			if (thisEnemy.CurrentRoom != null && combatTargetLocation.CurrentCorridor != null)
			{
				AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(combatTargetLocation.CurrentCorridor.door);
				if (adjacentRoomData != null)
				{
					float num = 0f;
					foreach (Waypoint connectingWaypoint in adjacentRoomData.ConnectingWaypoints)
					{
						if (!(connectingWaypoint.Door == null))
						{
							float num2 = Vector3.Distance(thisEnemy.Position, connectingWaypoint.transform.position);
							if (waypoint == null || num2 < num)
							{
								num = num2;
								waypoint = connectingWaypoint;
							}
						}
					}
				}
			}
			else if (thisEnemy.CurrentCorridor != null && combatTargetLocation.CurrentRoom != null)
			{
				AdjacentRoomData adjacentRoomData2 = NavigationHelper.GetAdjacentRoomData(thisEnemy.CurrentCorridor.door);
				float num3 = 0f;
				foreach (Waypoint connectingWaypoint2 in adjacentRoomData2.ConnectingWaypoints)
				{
					if (!(connectingWaypoint2.Door == null))
					{
						float num4 = Vector3.Distance(combatTargetLocation.Position, connectingWaypoint2.transform.position);
						if (waypoint == null || num4 < num3)
						{
							num3 = num4;
							waypoint = connectingWaypoint2;
						}
					}
				}
			}
			return waypoint;
		}
	}
}

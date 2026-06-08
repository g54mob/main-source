using System;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfPatrolIdle : BaseEnemyState
	{
		private const float SNIFF_CHECK_TIME = 5f;

		private const int SNIFF_CHANCE = 65;

		private static System.Random _random = new System.Random();

		private float _checkForSniffTimer;

		private DbfBrain _dbfBrain;

		public override string StateId
		{
			get
			{
				return "DbfPatrolIdle";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfPatrolIdle(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public override void Update()
		{
			Waypoint waypoint = CheckForWanderDestination();
			if (waypoint != null)
			{
				_brain.StatePatrolNavigatePath.Initialize(waypoint, this);
				ChangeState(_brain.StatePatrolNavigatePath);
				return;
			}
			_checkForSniffTimer -= Time.deltaTime;
			if (_checkForSniffTimer <= 0f)
			{
				_checkForSniffTimer = 5f;
				int num = _random.Next(1, 101);
				if (num <= 65)
				{
					ChangeState(_dbfBrain.StateDbfSniffAround);
				}
			}
		}

		public override void EnterState()
		{
			_checkForSniffTimer = 5f;
			_brain.StartIdleAnimation();
		}

		public override void ExitState()
		{
		}

		private Waypoint CheckForWanderDestination()
		{
			Waypoint result = null;
			if (_brain.ThisEnemy.HasBehavior(EnemyAiBehaviors.Wanders))
			{
				bool flag = _brain.ThisEnemy.CurrentRoom == null && _brain.ThisEnemy.CurrentCorridor != null;
				if (_brain.WanderCheckTimer <= 0f || flag)
				{
					_brain.WanderCheckTimer = _brain.WANDER_CHECK_PERIOD;
					bool flag2 = false;
					if (_brain.WANDERYNESS == 100 || GlobalSettings.IsTutorial || flag)
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
						result = ((!(_brain.ThisEnemy.CurrentRoom == adjacentRoomData.Room1)) ? NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room1) : NavigationHelper.GetMainRoomWaypoint(adjacentRoomData.Room2));
					}
				}
			}
			return result;
		}
	}
}

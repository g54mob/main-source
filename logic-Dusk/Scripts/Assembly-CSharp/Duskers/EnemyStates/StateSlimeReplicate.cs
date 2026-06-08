using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateSlimeReplicate : BaseEnemyState
	{
		private const float DRONE_CHECK_DELAY = 1f;

		private float _droneCheckTimer;

		private SlimeBrain _slimeBrain;

		private EnemyManager _enemyManager;

		private static System.Random _random = new System.Random();

		public override string StateId
		{
			get
			{
				return "SlimeReplicate";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateSlimeReplicate(BaseEnemyBrain brain)
			: base(brain)
		{
			_slimeBrain = (SlimeBrain)brain;
			_enemyManager = EnemyManager.Instance;
		}

		public override void Update()
		{
			_droneCheckTimer -= Time.deltaTime;
			if (_droneCheckTimer <= 0f)
			{
				_droneCheckTimer = 1f;
				ICombatTarget droneInRoom = GetDroneInRoom();
				if (droneInRoom != null)
				{
					SlimeEnemy slime = _enemyManager.ClosestEnemySlime(droneInRoom.Position, droneInRoom.CurrentRoom);
					_slimeBrain.PassBrainToSlime(slime);
					_slimeBrain.StateSlimeCombat.Initialize(droneInRoom);
					ChangeState(_slimeBrain.StateSlimeCombat);
					return;
				}
			}
			if (_slimeBrain.GeneralReplicateTimer <= 0f)
			{
				_slimeBrain.GeneralReplicateTimer = 20f;
				int num = _random.Next(1, 101);
				if (num <= 100)
				{
					_slimeBrain.SlimeEnemy.ReplicateSlime();
				}
			}
		}

		public override void EnterState()
		{
			_droneCheckTimer = 1f;
		}

		public override void ExitState()
		{
			_droneCheckTimer = 0f;
		}

		public ICombatTarget GetDroneInRoom()
		{
			ICombatTarget result = null;
			foreach (Drone drones in _slimeBrain.DroneManager.dronesList)
			{
				if (!drones.IsDead && !drones.IsHidden && drones.CurrentRoom == _slimeBrain.SlimeEnemy.CurrentRoom)
				{
					result = drones;
					break;
				}
			}
			return result;
		}
	}
}

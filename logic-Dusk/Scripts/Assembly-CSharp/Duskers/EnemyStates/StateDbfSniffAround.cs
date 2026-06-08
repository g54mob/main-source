using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateDbfSniffAround : BaseEnemyState
	{
		private const float HOLD_POSITION_TIME = 3f;

		private static System.Random _random = new System.Random();

		private Vector3 _moveToPosition = Vector3.zero;

		private float _holdPositionTimer;

		private DbfBrain _dbfBrain;

		private bool _closestWeCanGet;

		public override string StateId
		{
			get
			{
				return "DbfSniffAround";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateDbfSniffAround(BaseEnemyBrain brain)
			: base(brain)
		{
			_dbfBrain = (DbfBrain)brain;
		}

		public override void Update()
		{
			if (_moveToPosition == Vector3.zero)
			{
				ChangeState(_dbfBrain.StateDbfPatrolIdle);
			}
			else
			{
				if (_brain.RotateWhileNotLookingAtTarget())
				{
					return;
				}
				float num = Vector3.Distance(_moveToPosition, _brain.ThisEnemy.Position);
				if (!_closestWeCanGet && num > 0.75f)
				{
					_brain.ThisEnemy.moveForward();
					float num2 = Vector3.Distance(_moveToPosition, _brain.ThisEnemy.Position);
					if (num2 > num)
					{
						_closestWeCanGet = true;
						_dbfBrain.Dbf.PlayPantSound();
					}
				}
				else
				{
					_holdPositionTimer -= Time.deltaTime;
					if (_holdPositionTimer <= 0f)
					{
						ChangeState(_dbfBrain.StateDbfPatrolIdle);
					}
				}
			}
		}

		public override void EnterState()
		{
			_moveToPosition = ChooseMoveToPosition();
			_holdPositionTimer = 3f;
			_closestWeCanGet = false;
			_brain.InitializeRotation(_moveToPosition);
			_brain.StartWalkAnimation();
		}

		public override void ExitState()
		{
		}

		private Vector3 ChooseMoveToPosition()
		{
			if (_brain.ThisEnemy.CurrentRoom == null)
			{
				return Vector3.zero;
			}
			GameObject gameObject = null;
			if (_brain.ThisEnemy.CurrentRoom.environmentModels != null && _brain.ThisEnemy.CurrentRoom.environmentModels.Count > 0 && _brain.ThisEnemy.CurrentRoom.environmentModelsLarge != null && _brain.ThisEnemy.CurrentRoom.environmentModelsLarge.Count > 0)
			{
				gameObject = ((_random.Next(0, 2) != 0) ? CommonMethods.PickRandomItem(_brain.ThisEnemy.CurrentRoom.environmentModelsLarge) : CommonMethods.PickRandomItem(_brain.ThisEnemy.CurrentRoom.environmentModels));
			}
			else if (_brain.ThisEnemy.CurrentRoom.environmentModelsLarge != null && _brain.ThisEnemy.CurrentRoom.environmentModelsLarge.Count > 0)
			{
				gameObject = CommonMethods.PickRandomItem(_brain.ThisEnemy.CurrentRoom.environmentModelsLarge);
			}
			else if (_brain.ThisEnemy.CurrentRoom.environmentModels != null && _brain.ThisEnemy.CurrentRoom.environmentModels.Count > 0)
			{
				gameObject = CommonMethods.PickRandomItem(_brain.ThisEnemy.CurrentRoom.environmentModels);
			}
			if (gameObject != null)
			{
				return gameObject.transform.position;
			}
			return Vector3.zero;
		}
	}
}

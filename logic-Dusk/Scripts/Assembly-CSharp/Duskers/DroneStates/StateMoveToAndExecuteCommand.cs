using UnityEngine;

namespace Duskers.DroneStates
{
	public class StateMoveToAndExecuteCommand : BaseDroneState
	{
		private const float COMMAND_HELP_PROCESS_DELAY = 0.1f;

		private GameObject _targetObject;

		private ExecutedCommand _commandToExecute;

		private CollisionType _collisionType;

		private float _commandHelpTextProcessTimer;

		private bool _initializedObjectiveTimer;

		private float _objectiveTimer;

		private float _closestDistanceToTarget;

		public override string StateId
		{
			get
			{
				return "MoveAndExecuteCommand";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateMoveToAndExecuteCommand(DroneBrain brain)
			: base(brain)
		{
		}

		public void Initialize(GameObject gameObject, ExecutedCommand command, CollisionType collisionType)
		{
			_targetObject = gameObject;
			_commandToExecute = command;
			_collisionType = collisionType;
			_initializedObjectiveTimer = false;
			if (_targetObject != null)
			{
				_brain.InitializeRotation(_targetObject.transform.position);
			}
		}

		public override void Update()
		{
			if (!(_targetObject != null))
			{
				return;
			}
			bool flag = false;
			if (_initializedObjectiveTimer)
			{
				float num = Vector3.Distance(_targetObject.transform.position, _brain.ThisDrone.Position);
				if (num < _closestDistanceToTarget && _closestDistanceToTarget - num > 1f)
				{
					_objectiveTimer = 4f;
					_closestDistanceToTarget = num;
				}
				_objectiveTimer -= Time.deltaTime;
				if (_objectiveTimer <= 0f && !_targetObject.GetComponent<Collider>().bounds.Intersects(_brain.ThisDrone.GetComponent<Collider>().bounds))
				{
					_brain.ThisDrone.SetUnderPlayerControl();
					_brain.ThisDrone.SendConsoleMessage(string.Format("Drone {0} ({1}) canceled navigation", _brain.ThisDrone.DroneNumber, _brain.ThisDrone.DroneName), ConsoleMessageType.Info);
					ChangeState(_brain.StateIdle);
					return;
				}
			}
			switch (_collisionType)
			{
			case CollisionType.BoundsIntesect:
				flag = _targetObject.GetComponent<Collider>().bounds.Intersects(_brain.ThisDrone.GetComponent<Collider>().bounds);
				break;
			case CollisionType.Proximity:
				flag = Vector3.Distance(_targetObject.transform.position, _brain.ThisDrone.Position) <= _brain.Proximity;
				break;
			default:
				flag = _targetObject.GetComponent<Collider>().bounds.Contains(_brain.ThisDrone.GetComponent<Collider>().bounds.center);
				break;
			}
			if (!flag)
			{
				if (_brain.RotateWhileNotLookingAtTarget())
				{
					return;
				}
				if (!_initializedObjectiveTimer)
				{
					_initializedObjectiveTimer = true;
					_objectiveTimer = 4f;
					_closestDistanceToTarget = Vector3.Distance(_targetObject.transform.position, _brain.ThisDrone.Position);
				}
				_brain.SteeringBehaviors.SetTarget(_targetObject);
				_brain.SteeringBehaviors.ArriveOn(Deceleration.Normal);
				_brain.SteeringBehaviors.ObstacleAvoidanceOn();
				if (_commandToExecute == null || _commandToExecute.Command.CommandNameLower != "pry")
				{
					_brain.SteeringBehaviors.WallAvoidanceOn();
				}
				if (_commandHelpTextProcessTimer <= 0f)
				{
					if (_commandToExecute != null)
					{
						HelpTextManager.Instance.ProcessExecutedCommand(_commandToExecute.Command.CommandName);
					}
					_commandHelpTextProcessTimer = 0.1f;
				}
				else
				{
					_commandHelpTextProcessTimer -= Time.deltaTime;
				}
			}
			else
			{
				_initializedObjectiveTimer = false;
				_brain.SteeringBehaviors.ArriveOff();
				_brain.SteeringBehaviors.ObstacleAvoidanceOff();
				_brain.SteeringBehaviors.LazyAvoidanceOff();
				_brain.SteeringBehaviors.WallAvoidanceOff();
				ExecutedCommand commandToExecute = _commandToExecute;
				ChangeState(_brain.StateIdle);
				if (commandToExecute != null)
				{
					commandToExecute.Handled = false;
					_brain.ThisDrone.ExecuteCommandAfterState(commandToExecute);
				}
				_brain.ThisDrone.PostMovement();
			}
		}

		public override void EnterState()
		{
			_commandHelpTextProcessTimer = 0f;
			if (_targetObject == null || _commandToExecute == null)
			{
				Debug.LogWarning("_targetObject and _commandToExecute must be set for this state to work properly");
			}
		}

		public override void ExitState()
		{
			_targetObject = null;
			_commandToExecute = null;
			_brain.SteeringBehaviors.ArriveOff();
			_brain.SteeringBehaviors.ObstacleAvoidanceOff();
			_brain.SteeringBehaviors.LazyAvoidanceOff();
			_brain.SteeringBehaviors.WallAvoidanceOff();
			_brain.ClearRotating();
		}
	}
}

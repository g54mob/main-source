using BehaviorDesigner.Runtime.Tasks;

namespace TH20
{
	public class InteractionController : MustCallDestroy, INavPathResult
	{
		private Character _character;

		private ObjectInteraction _interaction;

		private readonly bool _autoEnd;

		private bool _waitingForExit;

		private bool _roomItemRemoved;

		private int _lastQueuePosition = -1;

		private EPathStatus _pathStatus;

		private bool _waitingForInteraction;

		private bool _movingToInteractionStart;

		private float _coolDownTime;

		public bool InteractionStarted { get; private set; }

		public ObjectInteraction Interaction => _interaction;

		public InteractionController(Character character, ObjectInteraction interaction, bool autoEnd)
		{
			_character = character;
			_interaction = interaction;
			_autoEnd = autoEnd;
			_waitingForExit = false;
			_waitingForInteraction = false;
			_movingToInteractionStart = false;
			InteractionStarted = false;
			_pathStatus = EPathStatus.Success;
			if (interaction.IsAvailable(_character))
			{
				MoveToInteractionStart();
			}
			else
			{
				WaitForInteractionToBeFree();
			}
		}

		public override void Destroy()
		{
			_character.NavPath.ClearExistingCallback(this);
			if (_character != null && _interaction != null)
			{
				_interaction.StopWaitingForInteraction(_character);
				if (!InteractionStarted && _interaction.Reserved == _character)
				{
					_interaction.FreeInteraction(_character);
				}
			}
			_character = null;
			_interaction = null;
			base.Destroy();
		}

		private void WaitForInteractionToBeFree()
		{
			int num = _interaction.PositionToStandInQueue(_character, includeInterator: false);
			if (_waitingForInteraction && _lastQueuePosition == num)
			{
				return;
			}
			_waitingForInteraction = true;
			_movingToInteractionStart = false;
			_interaction.WaitForInteraction(_character);
			num = _interaction.PositionToStandInQueue(_character, includeInterator: false);
			if (num != _lastQueuePosition)
			{
				_lastQueuePosition = num;
				_interaction.GetQueueTransform(_character, num, out var position, out var rotation);
				if (_interaction.Definition.IgnoreStartRotation)
				{
					_character.NavPath.MoveTo(position, null, 0.1f);
				}
				else
				{
					_character.NavPath.MoveTo(position, rotation, null, 0.1f);
				}
			}
		}

		private void MoveToInteractionStart()
		{
			if (!_movingToInteractionStart)
			{
				_interaction.ReserveInteraction(_character);
				_interaction.StopWaitingForInteraction(_character);
				if (_interaction.Definition.IgnoreStartRotation)
				{
					_character.NavPath.MoveTo(_interaction.WorldStartPosition, this, 0.1f);
				}
				else
				{
					_character.NavPath.MoveTo(_interaction.WorldStartPosition, _interaction.WorldStartRotation, this);
				}
				_lastQueuePosition = -1;
				_waitingForInteraction = false;
				_movingToInteractionStart = true;
				_pathStatus = EPathStatus.Success;
			}
		}

		public void OnStartPath()
		{
		}

		public void OnPathComplete(EPathStatus pathStatus)
		{
			_movingToInteractionStart = false;
			if (_interaction == null || InteractionStarted)
			{
				return;
			}
			_pathStatus = pathStatus;
			switch (pathStatus)
			{
			case EPathStatus.Success:
				if (_interaction.Reserved != _character || !_interaction.IsAvailable(_character))
				{
					WaitForInteractionToBeFree();
					break;
				}
				_character.Position = _interaction.WorldStartPosition;
				if (!_interaction.Definition.IgnoreStartRotation)
				{
					_character.RotationY = _interaction.WorldStartRotation;
				}
				InteractionStarted = _interaction.StartInteraction(_character);
				break;
			case EPathStatus.Failure:
				_coolDownTime = GameTime.time;
				_character.Level.CharacterEvents.OnInteractionNavFailure.InvokeSafe(_character, _interaction.ParentRoomItem);
				break;
			}
		}

		public TaskStatus OnUpdate()
		{
			if (_interaction == null || _roomItemRemoved)
			{
				return TaskStatus.Failure;
			}
			if (_coolDownTime > 0f)
			{
				if (_coolDownTime + GameAlgorithms.Config.NavFailCoolDownTime < GameTime.time)
				{
					_coolDownTime = 0f;
					WaitForInteractionToBeFree();
					_pathStatus = EPathStatus.Success;
				}
				return TaskStatus.Running;
			}
			if (_interaction.HasBeenDestroyed() || _character.HasBeenDestroyed() || _pathStatus == EPathStatus.Failure)
			{
				if (InteractionStarted && _interaction.Interactor == _character)
				{
					_interaction.EndInteraction(_character);
				}
				return TaskStatus.Failure;
			}
			bool flag = _interaction.IsAvailable(_character);
			if (_waitingForInteraction)
			{
				if (flag)
				{
					MoveToInteractionStart();
				}
				else
				{
					WaitForInteractionToBeFree();
				}
				return TaskStatus.Running;
			}
			if (!InteractionStarted)
			{
				if (!flag)
				{
					WaitForInteractionToBeFree();
					return TaskStatus.Running;
				}
				if (_pathStatus == EPathStatus.Interrupted)
				{
					MoveToInteractionStart();
					return TaskStatus.Running;
				}
				if (_character.NavPath.IsNavigating())
				{
					return TaskStatus.Running;
				}
			}
			if (_interaction.Interactor != null && _interaction.Interactor != _character)
			{
				return TaskStatus.Failure;
			}
			if (_interaction.Interactor == null)
			{
				return TaskStatus.Success;
			}
			if (!_autoEnd)
			{
				return TaskStatus.Success;
			}
			if (!_waitingForExit)
			{
				_waitingForExit = true;
				_interaction.RequestExit();
			}
			if (!_interaction.HasFinished())
			{
				return TaskStatus.Running;
			}
			_interaction.EndInteraction(_character);
			return TaskStatus.Success;
		}

		public void OnRoomItemRemoved()
		{
			_roomItemRemoved = true;
		}
	}
}

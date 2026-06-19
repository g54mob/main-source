using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/SaveIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RestoreStateOnFailure : CharacterDecorator
	{
		public class SaveState : BaseSaveState
		{
			public TaskStatus executionStatus;

			public string _state;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private TaskStatus _executionStatus;

		private string _state;

		public override void OnStart()
		{
			base.OnStart();
			_state = base.Character.GetState();
			_executionStatus = TaskStatus.Inactive;
			base.Character.SetState(null);
		}

		public override void OnEnd()
		{
			TryRestoreCharacterState();
			base.OnEnd();
		}

		public override void OnBehaviorBeginDestroy()
		{
			TryRestoreCharacterState();
			base.OnBehaviorBeginDestroy();
		}

		private void TryRestoreCharacterState()
		{
			if (_state != null && base.CharacterUnsafe != null)
			{
				base.CharacterUnsafe.SetState(_state);
				_state = null;
			}
		}

		public override TaskStatus OnUpdate()
		{
			return _executionStatus;
		}

		public override bool CanExecute()
		{
			return _executionStatus == TaskStatus.Inactive;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			_executionStatus = childStatus;
			if (_executionStatus != TaskStatus.Success)
			{
				TryRestoreCharacterState();
			}
			_state = null;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				executionStatus = _executionStatus,
				_state = _state
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_executionStatus = saveState.executionStatus;
			_state = saveState._state;
		}
	}
}

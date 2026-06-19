using System;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PushBehaviour : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public int _behaviourID;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("Behaviour")]
		public SharedBehaviour _behaviour;

		[Tooltip("Pause behaviour when pushed onto stack by other behaviour")]
		public bool _pauseBehaviour = true;

		[Tooltip("Restart behaviour when popped from top of stack")]
		public bool _restartBehaviour = true;

		[Tooltip("Restart character behaviour when stack is empty")]
		public bool _restartMainBehaviour = true;

		[Tooltip("Variables")]
		public SharedNamedVariable[] _variables;

		private int _behaviourID;

		public override TaskStatus OnUpdate()
		{
			if (_behaviour.Value == null)
			{
				return TaskStatus.Failure;
			}
			_behaviourID = base.Character.PushBehaviourTree(_behaviour.Value, _pauseBehaviour, _restartBehaviour, _restartMainBehaviour, delegate(CharacterBehaviorTree bt)
			{
				SharedNamedVariable[] variables = _variables;
				foreach (SharedNamedVariable sharedNamedVariable in variables)
				{
					bt.SetVariableValue(sharedNamedVariable.Value.name, sharedNamedVariable.Value.value);
				}
			});
			SetupFinishedEvent();
			return TaskStatus.Success;
		}

		private void SetupFinishedEvent()
		{
			CharacterBehaviorTree behaviourTree = base.Character.GetBehaviourTreeFromStack(_behaviourID);
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate
			{
				CharacterBehaviorTree characterBehaviorTree2 = behaviourTree;
				characterBehaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(characterBehaviorTree2.OnFinishedEvent, finishedEvent);
				base.Character.PopBehaviourTree(_behaviourID);
			};
			CharacterBehaviorTree characterBehaviorTree = behaviourTree;
			characterBehaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(characterBehaviorTree.OnFinishedEvent, finishedEvent);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_behaviourID != 0)
			{
				Character character = base.Character;
				character.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character.PostRestoreFromSaveCallback, new System.Action(SetupFinishedEvent));
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_behaviourID = _behaviourID
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_behaviourID = saveState._behaviourID;
		}
	}
}

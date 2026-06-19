using System;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStartIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TriggerAction : CharacterAction, IAnimationEndEvent
	{
		public class SaveState : BaseSaveState
		{
			public bool _started;

			public int _behaviourTreeID;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[SerializeField]
		private SharedInstance_TH20TH20_CharacterActionDefinition _action;

		[SerializeField]
		private SharedCharacterActionRef _actionOverride;

		private ExternalBehavior _behaviour;

		private RuntimeAnimatorController _animGraph;

		private bool _started;

		private int _behaviourTreeID;

		public override void OnStart()
		{
			base.OnStart();
			_started = false;
			_behaviourTreeID = 0;
			_behaviour = null;
			_animGraph = null;
			if (base.Character.RoomUsing == null)
			{
				return;
			}
			CharacterActionDefinition action = GetAction();
			if (action != null)
			{
				if (action.GetBehaviour(base.Character, out _behaviour, out _animGraph))
				{
					StartAction(action);
				}
				base.Character.Level.CharacterEvents.TriggerGlobalCharacterAction(base.Character, base.Character.RoomUsing, base.Character.Position, action);
			}
		}

		private CharacterActionDefinition GetAction()
		{
			CharacterActionDefinition result = null;
			if (_actionOverride != null && _actionOverride.Value != null)
			{
				result = _actionOverride.Get;
			}
			else if (_action != null && _action.Instance != null)
			{
				result = _action.Instance;
			}
			return result;
		}

		public override void OnEnd()
		{
			CleanupAction();
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			if (base.Character.RoomUsing != null && (!(_behaviour == null) || !(_animGraph == null)))
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}

		private void StartAction(CharacterActionDefinition actionPlaying)
		{
			_started = true;
			base.Character.Interrupt();
			if (_behaviour != null)
			{
				StartBehaviourTree(actionPlaying);
			}
			else if (_animGraph != null)
			{
				StartAnimationGraph();
			}
		}

		private void CleanupAction()
		{
			if (_started)
			{
				_started = false;
				if (_behaviour != null)
				{
					CleanupBehaviourTree();
				}
				else if (_animGraph != null)
				{
					CleanupAnimationGraph();
				}
				base.Character.Resume();
			}
		}

		private void StartAnimationGraph()
		{
			base.Character.PushAnimationGraph(_animGraph, 0f, this);
		}

		private void CleanupAnimationGraph()
		{
			base.Character.PopAnimationGraph(_animGraph, 0f);
			_animGraph = null;
		}

		public void OnAnimationEndEvent()
		{
			CleanupAction();
		}

		private void StartBehaviourTree(CharacterActionDefinition actionPlaying)
		{
			_behaviourTreeID = base.Character.PushBehaviourTree(_behaviour, pauseWhenPushed: true, restartWhenPopped: false, actionPlaying.RestartPreviousBehaviour, delegate(CharacterBehaviorTree bt)
			{
				bt.SetVariable("Character", new CharacterRef(base.Character));
			});
			CharacterBehaviorTree behaviourTreeFromStack = base.Character.GetBehaviourTreeFromStack(_behaviourTreeID);
			behaviourTreeFromStack.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviourTreeFromStack.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnBehaviourTreeFinished));
		}

		private void CleanupBehaviourTree()
		{
			CharacterBehaviorTree characterBehaviorTree = ((_behaviour == null) ? null : base.Character.GetBehaviourTreeFromStack(_behaviourTreeID));
			if (characterBehaviorTree != null)
			{
				characterBehaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(characterBehaviorTree.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnBehaviourTreeFinished));
				base.Character.PopBehaviourTree(_behaviourTreeID);
			}
			_behaviour = null;
			_behaviourTreeID = 0;
		}

		private void OnBehaviourTreeFinished(bool success, GameObject owner)
		{
			CleanupAction();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (!_started)
			{
				return;
			}
			CharacterActionDefinition action = GetAction();
			if (action == null)
			{
				return;
			}
			action.GetBehaviour(base.Character, out _behaviour, out _animGraph);
			if (_animGraph != null)
			{
				base.Character.FixupAnimationEndEvent(this, _animGraph);
			}
			else
			{
				if (!(_behaviour != null) || _behaviourTreeID == 0)
				{
					return;
				}
				Character character = base.Character;
				character.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (System.Action)delegate
				{
					CharacterBehaviorTree behaviourTreeFromStack = base.Character.GetBehaviourTreeFromStack(_behaviourTreeID);
					if (behaviourTreeFromStack != null)
					{
						behaviourTreeFromStack.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviourTreeFromStack.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnBehaviourTreeFinished));
					}
				});
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_started = _started,
				_behaviourTreeID = _behaviourTreeID
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_started = saveState._started;
			_behaviourTreeID = saveState._behaviourTreeID;
		}
	}
}

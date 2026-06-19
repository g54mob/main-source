using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class SatisfyNeedsComponent : EntityTickComponent
	{
		private enum EState
		{
			Searching = 0,
			Found = 1,
			Waiting = 2,
			Playing = 3
		}

		private EState _state;

		private Character _character;

		private CharacterAttributes.Type _need;

		private int _behaviourTreeID;

		[DontSave]
		private ExternalBehavior _behaviour;

		[DontSave]
		private RuntimeAnimatorController _animGraph;

		private CharacterModifierMicroBehaviour _microBehaviour;

		private Room _room;

		private ObjectInteraction _interaction;

		private ObjectInteraction _waitingForInteraction;

		private bool _waitingForTurnToFace;

		private float _startDelayTime;

		private bool _restartPreviousBehaviourAfterAction;

		private float _needValueBeforeSatisfaction;

		private float _lastTimeNeedsCheckRan;

		private float _lastTimeLookedForBetterNeed;

		private Dictionary<CharacterModifierMicroBehaviour, float> _microBehaviourHistory = new Dictionary<CharacterModifierMicroBehaviour, float>();

		private List<CharacterModifierMicroBehaviour> _microBehavioursCache = new List<CharacterModifierMicroBehaviour>(32);

		private EState State
		{
			get
			{
				return _state;
			}
			set
			{
				_state = value;
			}
		}

		public bool SatisfyingNeed
		{
			get
			{
				if (State != EState.Searching)
				{
					return State != EState.Found;
				}
				return false;
			}
		}

		public CharacterAttributes.Type CurrentNeedBeingSatisfied => _need;

		public bool StandInQueue
		{
			get
			{
				if (!(_animGraph != null))
				{
					return State != EState.Playing;
				}
				return true;
			}
		}

		public ExternalBehavior ExternalBehaviour
		{
			get
			{
				CharacterBehaviorTree characterBehaviorTree = ((_behaviourTreeID != 0) ? _character.GetBehaviourTreeFromStack(_behaviourTreeID) : null);
				if (!(characterBehaviorTree != null))
				{
					return null;
				}
				return characterBehaviorTree.ExternalBehavior;
			}
		}

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			_lastTimeNeedsCheckRan = GameTime.unscaledTime + RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f);
		}

		public override void Destroy()
		{
			CleanupAction(success: true);
			base.Destroy();
		}

		public override void Tick()
		{
			if (_character.ReasonForLeaving != Character.ReasonForLeavingHospital.None || ((State == EState.Searching || State == EState.Playing) && GameTime.unscaledTime - _lastTimeNeedsCheckRan < 2f))
			{
				return;
			}
			_lastTimeNeedsCheckRan = GameTime.unscaledTime + RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f);
			switch (State)
			{
			case EState.Searching:
				if (_character.CanSatisfyNeeds() && (FindBehaviour() || FindMicroBehaviour()))
				{
					State = EState.Found;
					_startDelayTime = GameTime.time + RandomUtils.GlobalRandomInstance.NextFloat(GameAlgorithms.Config.MinDelayNeedStartTime, GameAlgorithms.Config.MaxDelayNeedStartTime);
					BuildEvents buildEvents = base.Level.BuildEvents;
					buildEvents.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents.OnRoomClosed, new Action<Room>(OnRoomClosed));
					BuildEvents buildEvents2 = base.Level.BuildEvents;
					buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
					BuildEvents buildEvents3 = base.Level.BuildEvents;
					buildEvents3.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents3.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
				}
				break;
			case EState.Found:
				if (!(GameTime.time >= _startDelayTime))
				{
					break;
				}
				if (_character.CanSatisfyNeeds())
				{
					_waitingForInteraction = _character.Interaction;
					if (_waitingForInteraction != null)
					{
						State = EState.Waiting;
						_waitingForInteraction.RequestExit();
					}
					else if (_character.GetComponent<TurnToFaceComponent>() != null)
					{
						State = EState.Waiting;
						_waitingForTurnToFace = true;
					}
					else
					{
						StartAction();
					}
				}
				else
				{
					CleanupAction(success: false);
				}
				break;
			case EState.Waiting:
				if (_waitingForTurnToFace)
				{
					if (_character.GetComponent<TurnToFaceComponent>() == null)
					{
						_waitingForTurnToFace = false;
						StartAction();
					}
				}
				else if (_waitingForInteraction != null)
				{
					if (_waitingForInteraction.HasFinished())
					{
						if (_waitingForInteraction.Interactor == _character)
						{
							_waitingForInteraction.EndInteraction(_character);
						}
						_waitingForInteraction = null;
						StartAction();
					}
				}
				else
				{
					CleanupAction(success: false);
				}
				break;
			case EState.Playing:
				if (_interaction != null && !_interaction.ParentRoomItem.IsFunctional())
				{
					CleanupAction(success: false);
				}
				else if (_character is Patient && _character.HasBeenCalledIntoRoom())
				{
					CleanupAction(success: false);
				}
				else if ((_animGraph != null || _interaction != null) && _character.Animator.IsInState("Exit"))
				{
					CleanupAction(success: true);
				}
				else
				{
					LookForBetterNeedInteraction();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private bool FindBehaviour()
		{
			bool result = false;
			if (GameAlgorithms.GetCharacterNeedInteraction(_character, out _need, out _behaviour, out _interaction, out _room))
			{
				_needValueBeforeSatisfaction = _character.GetAttributes().GetAttribute((int)_need).Value();
				_restartPreviousBehaviourAfterAction = true;
				result = true;
			}
			return result;
		}

		private bool FindMicroBehaviour()
		{
			_microBehavioursCache.Clear();
			if (_character.ModifiersComponent != null)
			{
				_character.ModifiersComponent.IterateModifiersOfType(this, delegate(SatisfyNeedsComponent param, CharacterModifierMicroBehaviour modifier)
				{
					if (param.IsMicroBehaviourValid(modifier))
					{
						param._microBehavioursCache.Add(modifier);
					}
				});
			}
			if (_microBehavioursCache.Count > 0)
			{
				_microBehaviour = _microBehavioursCache.RandomItem();
				if (_microBehaviour.Action != null)
				{
					CharacterActionDefinition instance = _microBehaviour.Action.Instance;
					base.Level.CharacterEvents.TriggerGlobalCharacterAction(_character, _character.RoomUsing, _character.Position, instance);
					if (instance.GetBehaviour(_character, out _behaviour, out _animGraph))
					{
						_restartPreviousBehaviourAfterAction = instance.RestartPreviousBehaviour;
						_room = _character.RoomUsing;
						_microBehavioursCache.Clear();
						_ = _behaviour != null;
						return true;
					}
					RecordMicroBehaviourTime();
				}
			}
			_microBehavioursCache.Clear();
			return false;
		}

		private void LookForBetterNeedInteraction()
		{
			if (!(GameTime.time - _lastTimeLookedForBetterNeed > 4f))
			{
				return;
			}
			_lastTimeLookedForBetterNeed = GameTime.time;
			bool flag = _character.ReservedInteraction == _interaction || _character.Interaction == _interaction;
			bool flag2 = _character.IsInteractingWithRoomDoor();
			if (_need == CharacterAttributes.Type.None || !(_behaviour != null) || flag || !_character.InteractionInterruptable || flag2 || _interaction == null || !_interaction.IsInQueue(_character))
			{
				return;
			}
			bool urgent = _needValueBeforeSatisfaction > GameAlgorithms.Config.UrgentNeedThreshold;
			Room roomOut;
			ObjectInteraction bestInteractionThatSatisfiesNeed = GameAlgorithms.GetBestInteractionThatSatisfiesNeed(_character, _need, urgent, out roomOut);
			if (bestInteractionThatSatisfiesNeed == null || bestInteractionThatSatisfiesNeed == _interaction)
			{
				return;
			}
			CleanupBehaviourTree();
			_room = roomOut;
			_interaction = bestInteractionThatSatisfiesNeed;
			ExternalBehavior externalBehavior = ((_room != null) ? _room.Definition.GetSatisfactionOverride(_need, bestInteractionThatSatisfiesNeed.ParentRoomItem) : null);
			if (_need == CharacterAttributes.Type.Toilet && _character.Visual.CustomisationOption?.BehaviourSatisfyToiletOverride != null)
			{
				externalBehavior = _character.Visual.CustomisationOption.BehaviourSatisfyToiletOverride;
			}
			_behaviour = ((externalBehavior != null) ? externalBehavior : _character.Definition.GetSatisfactionBehaviour(_need));
			if (_need == CharacterAttributes.Type.Nausea)
			{
				CustomisationOption customisationOption = _character.Visual.CustomisationOption;
				if ((object)customisationOption != null && customisationOption.DisallowNauseaFulfilment)
				{
					_behaviour = null;
					return;
				}
			}
			StartBehaviourTree();
		}

		private bool IsMicroBehaviourValid(CharacterModifierMicroBehaviour behaviour)
		{
			if (!_microBehaviourHistory.ContainsKey(behaviour))
			{
				_microBehaviourHistory.Add(behaviour, GameTime.time + behaviour.Frequency());
			}
			return GameTime.time >= _microBehaviourHistory[behaviour];
		}

		private void StartAction()
		{
			if (_behaviour != null || _animGraph != null)
			{
				State = EState.Playing;
				_lastTimeLookedForBetterNeed = GameTime.time;
				_character.NavPath.Halt();
				_character.Interruptable = false;
				_character.EnableBehaviour(enabled: false);
				if (_behaviour != null)
				{
					StartBehaviourTree();
				}
				else if (_animGraph != null)
				{
					StartAnimationGraph();
				}
			}
			else
			{
				CleanupAction(success: false);
			}
		}

		private void CleanupAction(bool success)
		{
			if (State == EState.Playing)
			{
				if (success && _need != CharacterAttributes.Type.None)
				{
					AttributeFloat attribute = _character.GetAttributes().GetAttribute((int)_need);
					if (attribute.Value() >= _needValueBeforeSatisfaction)
					{
						attribute.Modify(-100f, 1f);
					}
				}
				CleanupBehaviourTree();
				CleanupAnimationGraph();
				RecordMicroBehaviourTime();
				_character.Interruptable = true;
				_character.EnableBehaviour(enabled: true);
			}
			State = EState.Searching;
			_room = null;
			_behaviour = null;
			_animGraph = null;
			_microBehaviour = null;
			_interaction = null;
			_waitingForInteraction = null;
			_need = CharacterAttributes.Type.None;
			if (GetOwner() != null)
			{
				BuildEvents buildEvents = base.Level.BuildEvents;
				buildEvents.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents.OnRoomClosed, new Action<Room>(OnRoomClosed));
				BuildEvents buildEvents2 = base.Level.BuildEvents;
				buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
				BuildEvents buildEvents3 = base.Level.BuildEvents;
				buildEvents3.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents3.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			}
		}

		private void RecordMicroBehaviourTime()
		{
			if (_microBehaviour != null)
			{
				_microBehaviourHistory[_microBehaviour] = GameTime.time + _microBehaviour.Frequency();
			}
		}

		private void StartAnimationGraph()
		{
			_character.PushAnimationGraph(_animGraph, 0.25f);
		}

		private void CleanupAnimationGraph()
		{
			if (_animGraph != null)
			{
				_character.PopAnimationGraph(_animGraph, 0.25f);
				_animGraph = null;
			}
		}

		private void StartBehaviourTree()
		{
			_behaviourTreeID = _character.PushBehaviourTree(_behaviour, pauseWhenPushed: true, restartWhenPopped: false, _restartPreviousBehaviourAfterAction, delegate(CharacterBehaviorTree bt)
			{
				bt.SetVariable("Character", new CharacterRef(_character));
				bt.SetVariable("Room", new RoomRef(_room));
				bt.SetVariable("Interaction", new ObjectInteractionRef(_interaction));
			});
			CharacterBehaviorTree behaviourTreeFromStack = _character.GetBehaviourTreeFromStack(_behaviourTreeID);
			behaviourTreeFromStack.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviourTreeFromStack.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnFinishedEvent));
			if (_interaction != null)
			{
				_interaction.WaitForInteraction(_character);
			}
		}

		private void CleanupBehaviourTree()
		{
			CharacterBehaviorTree characterBehaviorTree = ((_behaviourTreeID != 0) ? _character.GetBehaviourTreeFromStack(_behaviourTreeID) : null);
			if (characterBehaviorTree != null)
			{
				characterBehaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(characterBehaviorTree.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnFinishedEvent));
				_character.PopBehaviourTree(_behaviourTreeID);
			}
			if (_interaction != null)
			{
				_interaction.StopWaitingForInteraction(_character);
				_interaction = null;
			}
			_room = null;
			_behaviour = null;
			_behaviourTreeID = 0;
		}

		private void OnFinishedEvent(bool success, GameObject owner)
		{
			_character.GetBehaviourTreeFromStack(_behaviourTreeID);
			CleanupAction(success);
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			if (roomBeingEdited == _room)
			{
				roomBeingEdited.ExitRoom(_character);
				CleanupAction(success: false);
			}
		}

		private void OnRoomClosed(Room room)
		{
			if (room == _room)
			{
				room.ExitRoom(_character);
				CleanupAction(success: false);
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_interaction != null && _interaction.ParentRoomItem == roomItem)
			{
				if (_interaction != null && _interaction.Reserved == _character)
				{
					_character.NavPath.Halt();
				}
				CleanupAction(success: false);
			}
		}

		public void Interrupt()
		{
			CleanupAction(success: false);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			if (_microBehaviour != null)
			{
				_microBehaviour.Action.Instance.GetBehaviour(_character, out _behaviour, out _animGraph);
			}
			if (_behaviourTreeID == 0)
			{
				return;
			}
			Character character = _character;
			character.PostRestoreFromSaveCallback = (Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (Action)delegate
			{
				CharacterBehaviorTree behaviourTreeFromStack = _character.GetBehaviourTreeFromStack(_behaviourTreeID);
				if (behaviourTreeFromStack != null)
				{
					behaviourTreeFromStack.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviourTreeFromStack.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(OnFinishedEvent));
				}
				else
				{
					OnFinishedEvent(success: false, null);
					_character.Idle();
				}
			});
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}
	}
}

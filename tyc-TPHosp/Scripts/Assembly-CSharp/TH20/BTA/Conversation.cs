using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionConversation.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class Conversation : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public int _listenerPtrID;

			public int _conversationItemPtrID;

			public int _talkerBehaviourId;

			public int _listenerBehaviourId;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Conversation to spawn")]
		public SharedInstance_TH20TH20_RoomItemDefinition _conversationDefinition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Listener (none = choose random character)")]
		public SharedCharacterRef _listenerRef;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Choose a random character within this radius")]
		public float _characterWithinRadius;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Choose a location within this radius for conversation")]
		public float _locationWithinRadius;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Restart talkers behaviour when conversation ends")]
		public bool _restartTalkerBehaviour = true;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Restart listeners behaviour when conversation ends")]
		public bool _restartListenerBehaviour = true;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Conversation behaviour tree")]
		public ExternalBehavior _behaviour;

		[SerializeField]
		private ConversationFilterType _filterType = new ConversationFilterType();

		[SerializeField]
		private ConversationFilterStaffType _filterStaffType = new ConversationFilterStaffType();

		[SerializeField]
		private ConversationFilterIllness _filterIllness = new ConversationFilterIllness();

		[SerializeField]
		private ConversationFilterTrait _filterTrait = new ConversationFilterTrait();

		private EntityPtr<Character> _listenerPtr = new EntityPtr<Character>();

		private EntityPtr<RoomItem> _conversationItemPtr = new EntityPtr<RoomItem>();

		private int _talkerBehaviourId;

		private int _listenerBehaviourId;

		private static List<Character> _listenerCache = new List<Character>(128);

		private static List<ObjectInteraction> _objectInteractionCache = new List<ObjectInteraction>(128);

		public override void OnStart()
		{
			base.OnStart();
			Character character = base.Character;
			Character character2 = (_listenerRef.IsValid() ? _listenerRef.Get : null);
			_talkerBehaviourId = 0;
			_listenerBehaviourId = 0;
			if (character.CanSatisfyNeeds() || (character.SatisfyNeedsComponent != null && base.Owner.ExternalBehavior == character.SatisfyNeedsComponent.ExternalBehaviour))
			{
				TH20.Level level = character.Level;
				RoomItemDefinition instance = _conversationDefinition.Instance;
				if (character2 == null)
				{
					_listenerCache.Clear();
					float num = MathUtils.Square(_characterWithinRadius);
					foreach (Character allCharacter in level.CharacterManager.AllCharacters)
					{
						if (character.Position.SquareDistance2D(allCharacter.Position) < num && allCharacter != character && allCharacter.RoomUsing == character.RoomUsing && allCharacter.CanSatisfyNeeds() && allCharacter.CanPlayReactions() && _filterType.IsValid(allCharacter) && _filterStaffType.IsValid(allCharacter) && _filterIllness.IsValid(allCharacter) && _filterTrait.IsValid(allCharacter))
						{
							_listenerCache.Add(allCharacter);
						}
					}
					if (_listenerCache.Count != 0)
					{
						character2 = _listenerCache.RandomItem();
					}
					_listenerCache.Clear();
				}
				if (character2 != null)
				{
					if (character.RoomUsing != null && RoomAlgorithms.GetRandomFreeTileWithinRadius(character.RoomUsing.FloorPlan, character.Position, _locationWithinRadius, out var worldPositionOut))
					{
						Quaternion quaternion = Quaternion.LookRotation(character2.Position - character.Position);
						RoomItem roomItem = RoomItemAlgorithms.SpawnItem(instance, worldPositionOut, 0f, quaternion.eulerAngles.y, level, character.RoomUsing);
						if (roomItem != null)
						{
							ObjectInteraction interaction = GetInteraction(roomItem, character, "Talk");
							ObjectInteraction interaction2 = GetInteraction(roomItem, character2, "Listen");
							if (interaction != null && interaction2 != null)
							{
								_conversationItemPtr.Set(roomItem);
								_talkerBehaviourId = StartConversation(roomItem, character, character2, _restartTalkerBehaviour, interaction, interaction2);
								_listenerBehaviourId = StartConversation(roomItem, character2, character, _restartListenerBehaviour, interaction2, interaction);
								BuildEvents buildEvents = level.BuildEvents;
								buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
								CharacterEvents characterEvents = level.CharacterEvents;
								characterEvents.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSendHomeRequested));
							}
							else
							{
								character2 = null;
								level.BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
							}
						}
						else
						{
							character2 = null;
						}
					}
					else
					{
						character2 = null;
					}
				}
			}
			_listenerPtr.Set(character2);
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			RoomItem roomItem = _conversationItemPtr.Get(base.Character.Level);
			if (roomItem != null)
			{
				GridCoord gridCoord = roomItem.WorldPosition.ToGridCoord();
				if (room.FloorPlan.WorldBounds.IsInBounds(gridCoord) && RoomAlgorithms.RoomContainsWorldCoord(room.FloorPlan, gridCoord))
				{
					EndConversation();
				}
			}
		}

		private void OnPatientSendHomeRequested(Patient patient)
		{
			if (patient != null)
			{
				_ = base.Character.Level;
				Character character = base.Character;
				Character character2 = _listenerPtr.Get(base.Character.Level);
				if (patient == character || patient == character2)
				{
					EndConversation();
				}
			}
		}

		private ObjectInteraction GetInteraction(RoomItem conversation, Character character, string interactionName)
		{
			_objectInteractionCache.Clear();
			InteractionAlgorithms.GetInteractionsByName(conversation, interactionName, (ObjectInteraction objectInteraction) => objectInteraction.Valid && objectInteraction.IsAvailable(character), _objectInteractionCache);
			ObjectInteraction result = ((_objectInteractionCache.Count == 0) ? null : _objectInteractionCache.RandomItem());
			_objectInteractionCache.Clear();
			return result;
		}

		private int StartConversation(RoomItem conversation, Character character, Character otherCharacter, bool restartBehaviour, ObjectInteraction interaction, ObjectInteraction otherInteraction)
		{
			character.NavPath.Halt();
			character.Interruptable = false;
			character.EnableBehaviour(enabled: false);
			int num = character.PushBehaviourTree(_behaviour, pauseWhenPushed: true, restartWhenPopped: true, restartBehaviour, delegate(CharacterBehaviorTree bt)
			{
				bt.SetVariable("Character", new CharacterRef(character));
				bt.SetVariable("OtherCharacter", new CharacterRef(otherCharacter));
				bt.SetVariable("Interaction", new ObjectInteractionRef(interaction));
				bt.SetVariable("OtherInteraction", new ObjectInteractionRef(otherInteraction));
				bt.SetVariable("Conversation", new ItemRef(conversation));
			});
			BindConversationEndEvent(character, num);
			return num;
		}

		private void EndConversation()
		{
			TH20.Level level = base.Character.Level;
			RoomItem roomItem = _conversationItemPtr.Get(level);
			if (roomItem != null)
			{
				Character character = _listenerPtr.Get(level);
				_conversationItemPtr.Set(null);
				BehaviourEnded(base.Character, _talkerBehaviourId);
				BehaviourEnded(character, _listenerBehaviourId);
				roomItem.EndAllInteractions(immediately: true);
				level.BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
				BuildEvents buildEvents = level.BuildEvents;
				buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
				CharacterEvents characterEvents = level.CharacterEvents;
				characterEvents.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSendHomeRequested));
			}
		}

		private void BindConversationEndEvent(Character character, int behaviourTreeID)
		{
			CharacterBehaviorTree behaviourTree = character.GetBehaviourTreeFromStack(behaviourTreeID);
			if (behaviourTree == null)
			{
				EndConversation();
				return;
			}
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate
			{
				CharacterBehaviorTree characterBehaviorTree2 = behaviourTree;
				characterBehaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(characterBehaviorTree2.OnFinishedEvent, finishedEvent);
				character.PopBehaviourTree(behaviourTreeID);
				EndConversation();
			};
			CharacterBehaviorTree characterBehaviorTree = behaviourTree;
			characterBehaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(characterBehaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void BehaviourEnded(Character character, int behaviourTreeID)
		{
			character.Interruptable = true;
			character.EnableBehaviour(enabled: true);
			if (behaviourTreeID == _talkerBehaviourId)
			{
				_talkerBehaviourId = 0;
			}
			else if (behaviourTreeID == _listenerBehaviourId)
			{
				_listenerBehaviourId = 0;
			}
		}

		public override void OnEnd()
		{
			EndConversation();
			_listenerPtr.Set(null);
			_conversationItemPtr.Set(null);
			_talkerBehaviourId = 0;
			_listenerBehaviourId = 0;
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			Character character = _listenerPtr.Get(base.Character.Level);
			RoomItem roomItem = _conversationItemPtr.Get(base.Character.Level);
			if (base.Character.GetComponent<EntityNavFailedComponent>() != null)
			{
				return TaskStatus.Failure;
			}
			if (character == null || character.GetComponent<EntityNavFailedComponent>() != null)
			{
				return TaskStatus.Failure;
			}
			if (roomItem == null)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_talkerBehaviourId != 0 && _listenerBehaviourId != 0)
			{
				Character talker = base.Character;
				Character listener = _listenerPtr.Get(base.Character.Level);
				Character character = talker;
				character.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (System.Action)delegate
				{
					BindConversationEndEvent(talker, _talkerBehaviourId);
				});
				Character character2 = listener;
				character2.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character2.PostRestoreFromSaveCallback, (System.Action)delegate
				{
					BindConversationEndEvent(listener, _listenerBehaviourId);
				});
				BuildEvents buildEvents = base.Character.Level.BuildEvents;
				buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
				CharacterEvents characterEvents = base.Character.Level.CharacterEvents;
				characterEvents.OnPatientSendHomeRequested = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSendHomeRequested, new Action<Patient>(OnPatientSendHomeRequested));
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_listenerPtrID = _listenerPtr.ID,
				_conversationItemPtrID = _conversationItemPtr.ID,
				_talkerBehaviourId = _talkerBehaviourId,
				_listenerBehaviourId = _listenerBehaviourId
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_listenerPtr.ID = saveState._listenerPtrID;
			_conversationItemPtr.ID = saveState._conversationItemPtrID;
			_talkerBehaviourId = saveState._talkerBehaviourId;
			_listenerBehaviourId = saveState._listenerBehaviourId;
		}
	}
}

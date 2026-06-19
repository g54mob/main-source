#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using FullSerializerSave;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class Character : Entity, ICursorSelectable, IStatusIconEmitter, IAttributesInterface, fsISerializationCallbacks, INavPathResult, IMultipleHighlight
	{
		public enum Sex
		{
			Male = 0,
			Female = 1,
			None = 2
		}

		public enum ReasonForLeavingHospital
		{
			None = 0,
			IneffectiveTreatment = 1,
			Cured = 2,
			SentHomeByPlayer = 3,
			RageQuit = 4,
			Fired = 5,
			Resigned = 6,
			NoDiagnosisRoomsDefined = 7
		}

		protected interface IModeChange
		{
			bool Update();

			int Priority();
		}

		private class BehaviourStackEntry
		{
			public int ID;

			public ExternalBehavior Behaviour;

			public CharacterBehaviorTree BehaviourTree;

			public bool PauseWhenPushed;

			public bool RestartWhenPopped;

			public bool RestartMainBehaviour;

			public override string ToString()
			{
				return BehaviourTree.ToString();
			}
		}

		private class SavedBehaviourStackEntry
		{
			public int ID;

			public ExternalBehavior Behaviour;

			public CharacterBehaviorTree.SavedState SavedState;

			public bool PauseWhenPushed;

			public bool RestartWhenPopped;

			public bool RestartMainBehaviour;
		}

		private class GetAttributeMultiplierParam
		{
			public CharacterAttributes.Type Type;

			public float Multiplier;
		}

		private class GetIdleAnimOverrideParam
		{
			public int Priority;

			public IdleAnimation Anim;
		}

		private class GetLocomotionAnimGraphParam
		{
			public int Priority;

			public CharacterModifierLocoAnimationGraph Modifier;
		}

		private class GetWalkAnimOverrideParam
		{
			public int Priority;

			public WalkAnimation Anim;
		}

		private class AnimationStackEntry
		{
			public RuntimeAnimatorController AnimGraph;

			[DontSave]
			public IAnimationEndEvent EndEvent;
		}

		public class InteractionControllerCollection
		{
			private int _lastID;

			private readonly Dictionary<int, InteractionController> _contents = new Dictionary<int, InteractionController>();

			public Dictionary<int, InteractionController> Contents => _contents;

			public int Add(InteractionController item)
			{
				_lastID++;
				_contents[_lastID] = item;
				return _lastID;
			}

			public bool Contains(int id)
			{
				return _contents.ContainsKey(id);
			}

			public void Destroy(int id)
			{
				if (_contents.TryGetValue(id, out var value))
				{
					value.Destroy();
					_contents.Remove(id);
				}
			}

			public void Remove(int id)
			{
				_contents.Remove(id);
			}

			public InteractionController Get(int id)
			{
				return _contents[id];
			}
		}

		private readonly VisualManager _visualManager;

		private byte _emoteID;

		private readonly Sex _sex;

		private CharacterName _name;

		[DontSave]
		private BoxCollider _collider;

		protected double _totalTimeInHospital;

		private double _lastVisitedRoomTime;

		private IModeChange _modeChange;

		private Vector3 _positionForSave;

		private Quaternion _rotationForSave;

		private Vector3 _position;

		private float _maxSpeedMultiplier = 1f;

		private float _walkAnimMultiplier = 1f;

		private int _currentMovementModifierPriority = -1;

		private bool _newBehaviour;

		[CanBeNull]
		private ExternalBehavior _behaviour;

		private int BehaviourTreeDisablersCount;

		protected bool BehaviorTreeEnabled;

		private readonly GetAttributeMultiplierParam _getAttributeMultiplierParam = new GetAttributeMultiplierParam();

		private readonly GetIdleAnimOverrideParam _getIdleAnimOverrideParam = new GetIdleAnimOverrideParam();

		private readonly GetLocomotionAnimGraphParam _getLocomotionAnimGraphParam = new GetLocomotionAnimGraphParam();

		private readonly GetWalkAnimOverrideParam _getWalkAnimOverrideParam = new GetWalkAnimOverrideParam();

		private int _nextBehaviourID;

		[DontSave]
		private List<BehaviourStackEntry> _behaviourStack;

		[DontSave]
		private BehaviourStackEntry _behaviourStackPop;

		private CharacterBehaviorTree.SavedState _savedBehaviourState;

		private List<SavedBehaviourStackEntry> _savedBehaviourStack;

		protected readonly CharacterAttributes _attributes;

		private int _interruptable;

		private readonly CharacterAnimationEvents _characterAnimationEvents;

		[DontSave]
		private IAnimationEndEvent _animationEndEvent;

		private List<AnimationStackEntry> _animationStack = new List<AnimationStackEntry>();

		private AnimatorSavedState _animatorStateForSave;

		private RuntimeAnimatorController _animationGraphForSave;

		private readonly InteractionControllerCollection _interactionControllers = new InteractionControllerCollection();

		protected static List<IdleAnimation> IdleAnims = new List<IdleAnimation>();

		private float _statusIconCheckTime;

		private InWorldMenuObject _activeMenu;

		private string _state;

		[DontSave]
		public Action PostRestoreFromSaveCallback;

		private string _debugName;

		private float _lastTimeAttributesUpdated;

		private float _nextTimeAttributesUpdated;

		private int _disallowInteractionsCount;

		[DontSave]
		private static List<int> _controllersToRemove = new List<int>();

		[DontSave]
		public GameObject GameObject { get; private set; }

		[DontSave]
		public Transform Transform { get; private set; }

		public Room GoingToRoom { get; protected set; }

		public bool GoingToRoomSetByPlayer { get; set; }

		public Room QueuingAtRoom { get; set; }

		public ReasonUseRoom ReasonUsingRoom { get; private set; }

		public ReasonForLeavingHospital ReasonForLeaving { get; private set; }

		public double TotalTimeInHospital => _totalTimeInHospital;

		public int DaysInHospital => (int)(TotalTimeInHospital / (double)GameAlgorithms.Config.SecondsPerDay);

		public int MoneySpent { get; set; }

		public Vector3 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
				Transform.position = value;
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return Transform.rotation;
			}
			set
			{
				Transform.rotation = value;
			}
		}

		public float RotationY
		{
			get
			{
				return Transform.rotation.eulerAngles.y;
			}
			set
			{
				float.IsNaN(value);
				Transform.rotation = Quaternion.Euler(0f, value, 0f);
			}
		}

		public CharacterVisual Visual { get; private set; }

		public byte EmoteID => _emoteID;

		public float MovementSpeed { get; set; }

		public float WalkSpeed => Definition._walkSpeed * _walkAnimMultiplier;

		public string PostFixName { protected get; set; }

		public CharacterName CharacterName => _name;

		public string Name => _name.GetCharacterName(PostFixName);

		public CharacterDefinition Definition { get; private set; }

		protected bool ShowDebugInfo { get; private set; }

		public NavPath NavPath { get; private set; }

		public bool NavPathComplete { get; private set; }

		public EPathStatus NavPathResult { get; private set; }

		public CharacterTraits Traits { get; protected set; }

		protected ExternalBehavior CurrentBehaviour => _behaviour;

		[DontSave]
		public CharacterBehaviorTree BehaviorTree { get; private set; }

		public bool AttributesEnabled
		{
			get
			{
				if (_attributes != null)
				{
					return _attributes.Enabled;
				}
				return false;
			}
		}

		[CanBeNull]
		public AttributeFloat Happiness { get; private set; }

		public float TemperatureValue { get; private set; }

		public float TemperatureComfort { get; private set; }

		public float AttractivenessValue { get; private set; }

		public float AttractivenessComfort { get; private set; }

		public bool Interruptable
		{
			protected get
			{
				return _interruptable == 0;
			}
			set
			{
				if (value)
				{
					_interruptable--;
				}
				else
				{
					_interruptable++;
				}
			}
		}

		public bool InteractionInterruptable
		{
			get
			{
				if (Interaction != null)
				{
					return Interaction.CanInterrupt();
				}
				return true;
			}
		}

		[DontSave]
		public Animator Animator { get; private set; }

		[DontSave]
		public AnimationEventListener AnimationEventListener { get; private set; }

		[DontSave]
		private AnimationEventCharacterListener AnimationEventCharacterListener { get; set; }

		[DontSave]
		private CharacterAnimationController CharacterAnimationController { get; set; }

		public RuntimeAnimatorController AnimationGraph
		{
			get
			{
				if (!(Animator != null))
				{
					return null;
				}
				return Animator.runtimeAnimatorController;
			}
			private set
			{
				if (Animator != null)
				{
					_animationGraphForSave = value;
					Animator.runtimeAnimatorController = value;
					if (AnimationEventListener != null)
					{
						AnimationEventListener.OnAnimGraphChanged();
					}
					if (_characterAnimationEvents != null)
					{
						_characterAnimationEvents.OnAnimGraphChanged();
					}
				}
			}
		}

		public ObjectInteraction Interaction { get; set; }

		public ObjectInteraction ReservedInteraction { get; set; }

		public ObjectInteraction WaitingForInteraction { get; set; }

		public InteractionControllerCollection InteractionControllers => _interactionControllers;

		public Sex Gender => _sex;

		public Room RoomUsing { get; private set; }

		[CanBeNull]
		public SatisfyNeedsComponent SatisfyNeedsComponent { get; private set; }

		[CanBeNull]
		public CharacterModifiersComponent ModifiersComponent { get; private set; }

		protected bool SatisfyingNeed
		{
			get
			{
				if (SatisfyNeedsComponent != null)
				{
					return SatisfyNeedsComponent.SatisfyingNeed;
				}
				return false;
			}
		}

		public bool StandInQueue
		{
			get
			{
				if (ReservedInteraction == null && SatisfyNeedsComponent != null)
				{
					return SatisfyNeedsComponent.StandInQueue;
				}
				return false;
			}
		}

		public bool Selectable { private get; set; }

		public bool Highlightable { private get; set; }

		public bool Teleporting { private get; set; }

		public bool LockedInRoom { private get; set; }

		public bool CalledIntoRoom { private get; set; }

		public Room RoomCalledInto
		{
			get
			{
				if (GoingToRoom != null && GoingToRoom.CharacterEntering == this)
				{
					return GoingToRoom;
				}
				if (QueuingAtRoom != null && QueuingAtRoom.CharacterEntering == this)
				{
					return QueuingAtRoom;
				}
				if (Interaction != null && Interaction.ParentRoomItem.Definition.ItemType == RoomItemDefinition.Type.Door && Interaction.Name == "Enter")
				{
					return Interaction.ParentRoomItem.OwningRoom;
				}
				return null;
			}
		}

		public bool DisallowInteractions
		{
			get
			{
				return _disallowInteractionsCount > 0;
			}
			set
			{
				if (value)
				{
					_disallowInteractionsCount++;
				}
				else
				{
					_disallowInteractionsCount--;
				}
			}
		}

		public void SetUserSpecifiedName(string userSpecifiedName)
		{
			_name.SetUserSpecifiedName(userSpecifiedName);
			base.Level.CharacterEvents.OnCharacterRenamed.InvokeSafe(this);
		}

		public string GetUserSpecifiedName()
		{
			return _name.GetUserSpecifiedName();
		}

		public override string ToString()
		{
			return _debugName;
		}

		public Character(CharacterDefinition definition, Level level, VisualManager visualManager, Sex sex, CharacterName name, int id, Vector3 position, bool navDisabled)
			: base(definition, level)
		{
			Definition = definition;
			_emoteID = (byte)UnityEngine.Random.Range(1, 2);
			_sex = sex;
			_name = name;
			PostFixName = "";
			_debugName = Definition._name + "_" + id.ToString().PadLeft(3, '0') + ": " + _name.GetCharacterFirstNameDebug() + " " + _name.GetCharacterLastNameDebug();
			GameObject = ((Definition.Prefab != null) ? UnityEngine.Object.Instantiate(Definition.Prefab) : new GameObject());
			Transform = GameObject.transform;
			GameObject.name = _debugName;
			Position = position;
			Selectable = true;
			Highlightable = true;
			Teleporting = false;
			LockedInRoom = false;
			Animator = GameObject.AddComponent<Animator>();
			Animator.avatar = Definition._avatar;
			Animator.applyRootMotion = true;
			Animator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
			Visual = new CharacterVisual(Definition, _sex, GameObject, Animator, level);
			AnimationGraph = GetLocomotionAnimGraph();
			CharacterAnimationController = GameObject.AddComponent<CharacterAnimationController>();
			CharacterAnimationController.Character = this;
			AnimationEventListener = GameObject.AddComponent<AnimationEventListener>();
			AnimationEventCharacterListener = GameObject.AddComponent<AnimationEventCharacterListener>();
			AnimationEventCharacterListener.Character = this;
			_characterAnimationEvents = new CharacterAnimationEvents(this, level);
			float num = 1.75f;
			float num2 = 0.5f;
			_collider = GameObject.AddComponent<BoxCollider>();
			_collider.size = new Vector3(num2, num, num2);
			_collider.center = new Vector3(0f, num * 0.5f, 0f);
			_collider.isTrigger = true;
			GameObject.tag = "Character";
			NavPath = new NavPath(this, navDisabled);
			_behaviourStack = new List<BehaviourStackEntry>();
			BehaviorTree = GameObject.AddComponent<CharacterBehaviorTree>();
			BehaviorTree.StartWhenEnabled = false;
			BehaviorTree.PauseWhenDisabled = true;
			BehaviorTree.RestartWhenComplete = false;
			BehaviorTree.ResetValuesOnRestart = false;
			BehaviorTreeEnabled = true;
			SatisfyNeedsComponent = GetComponent<SatisfyNeedsComponent>();
			ModifiersComponent = GetComponent<CharacterModifiersComponent>();
			_attributes = new CharacterAttributes(this);
			if (Definition._attributes != null)
			{
				CharacterAttributes.Definition[] attributes = Definition._attributes;
				foreach (CharacterAttributes.Definition definition2 in attributes)
				{
					AttributeFloat attributeFloat = new AttributeFloat(RandomUtils.GlobalRandomInstance.NextFloat(definition2._initialMinValue, definition2._initialMaxValue), 0f, 100f);
					_attributes.Add(definition2._type, attributeFloat);
					attributeFloat.GreaterThan(GameAlgorithms.Config.UrgentNeedThreshold, UrgentNeed, checkCallback: true);
				}
			}
			Happiness = _attributes.GetAttribute(CharacterAttributes.Type.Happiness);
			_visualManager = visualManager;
			_visualManager.RoomLightingManager.RegisterCharacter(this);
			if (ModifiersComponent != null)
			{
				ModifiersComponent.AddModifiers(Definition._defaultCharacterModifiers);
			}
			SetStatusIconCheckTime();
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomMissingRequiredItem = (Action<Room>)Delegate.Combine(buildEvents3.OnRoomMissingRequiredItem, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents4 = base.Level.BuildEvents;
			buildEvents4.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents4.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents5 = base.Level.BuildEvents;
			buildEvents5.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents5.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			InitializeComponents();
			ResetNextAndLastAttributeTimes();
		}

		public override void RestoreFromSave()
		{
			_ = Time.realtimeSinceStartup;
			if (_emoteID == 0)
			{
				_emoteID = (byte)UnityEngine.Random.Range(1, 2);
			}
			GameObject = ((Definition.Prefab != null) ? UnityEngine.Object.Instantiate(Definition.Prefab) : new GameObject());
			Transform = GameObject.transform;
			GameObject.name = _debugName;
			Position = _positionForSave;
			Rotation = _rotationForSave;
			_ = Time.realtimeSinceStartup;
			Animator = GameObject.AddComponent<Animator>();
			Animator.avatar = Definition._avatar;
			Animator.applyRootMotion = true;
			Animator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
			Visual.RestoreFromSave(GameObject, Animator, base.Level);
			RegenerateVisualIfNeeded();
			AnimationGraph = _animationGraphForSave;
			CharacterAnimationController = GameObject.AddComponent<CharacterAnimationController>();
			CharacterAnimationController.Character = this;
			AnimationEventListener = GameObject.AddComponent<AnimationEventListener>();
			AnimationEventCharacterListener = GameObject.AddComponent<AnimationEventCharacterListener>();
			AnimationEventCharacterListener.Character = this;
			_characterAnimationEvents.RestoreFromSave();
			Visual.RestoreModules();
			float num = 1.75f;
			float num2 = 0.5f;
			_collider = GameObject.AddComponent<BoxCollider>();
			_collider.size = new Vector3(num2, num, num2);
			_collider.center = new Vector3(0f, num * 0.5f, 0f);
			_collider.isTrigger = true;
			GameObject.tag = "Character";
			NavPath.RestoreFromSave();
			_ = Time.realtimeSinceStartup;
			_behaviourStack = new List<BehaviourStackEntry>();
			BehaviorTree = GameObject.AddComponent<CharacterBehaviorTree>();
			BehaviorTree.StartWhenEnabled = false;
			BehaviorTree.PauseWhenDisabled = true;
			BehaviorTree.RestartWhenComplete = false;
			BehaviorTree.ResetValuesOnRestart = false;
			_visualManager.RoomLightingManager.RegisterCharacter(this);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomMissingRequiredItem = (Action<Room>)Delegate.Combine(buildEvents3.OnRoomMissingRequiredItem, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents4 = base.Level.BuildEvents;
			buildEvents4.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents4.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents5 = base.Level.BuildEvents;
			buildEvents5.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents5.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			if ((bool)_behaviour)
			{
				bool behaviorTreeEnabled = BehaviorTreeEnabled;
				int behaviourTreeDisablersCount = BehaviourTreeDisablersCount;
				BehaviorTreeEnabled = true;
				BehaviourTreeDisablersCount = 0;
				SetBehaviour(_behaviour);
				if (_savedBehaviourState != null)
				{
					BehaviorTree.Load(_savedBehaviourState);
				}
				else
				{
					Logging.Error(LogChannels.SaveDebug, "Restoring a Character that has no _savedBehaviourState - must have been destroyed before saving.");
				}
				if (_savedBehaviourStack != null)
				{
					foreach (SavedBehaviourStackEntry item in _savedBehaviourStack)
					{
						int behaviourID = PushBehaviourTree(item.Behaviour, item.PauseWhenPushed, item.RestartWhenPopped, item.RestartMainBehaviour, null);
						GetBehaviourStackEntry(behaviourID).ID = item.ID;
					}
					for (int i = 0; i < _behaviourStack.Count; i++)
					{
						_behaviourStack[i].BehaviourTree.Load(_savedBehaviourStack[i].SavedState);
					}
				}
				else
				{
					Logging.Error(LogChannels.SaveDebug, "Restoring a Character that has no _savedBehaviourStack - must have been destroyed before saving.");
				}
				BehaviorTreeEnabled = behaviorTreeEnabled;
				BehaviourTreeDisablersCount = behaviourTreeDisablersCount;
				if (!BehaviorTreeEnabled)
				{
					EnableBehaviourInternal(enabled: false);
				}
			}
			else
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, new Action(FixupMissingBehaviour));
			}
			_savedBehaviourState = null;
			_savedBehaviourStack = null;
			if (Interaction != null)
			{
				if (Interaction.ParentRoomItem != null)
				{
					Interaction.RestoreCurrentInteraction(_animatorStateForSave);
				}
				else
				{
					Logging.Error(LogChannels.Save, "Character has interaction with destroyed room item; removing interaction.");
					Interaction.InterruptInteraction(this, characterDestroyed: false);
					Interaction = null;
				}
			}
			if (ReservedInteraction != null && ReservedInteraction.ParentRoomItem == null)
			{
				Logging.Error(LogChannels.Save, "Character has reserved interaction with destroyed room item; removing reserved interaction.");
				ReservedInteraction = null;
			}
			_ = Time.realtimeSinceStartup;
			base.RestoreFromSave();
			_ = Time.realtimeSinceStartup;
			Quaternion rotation = Rotation;
			Vector3 position = Position;
			if (_animatorStateForSave != null)
			{
				_animatorStateForSave.Restore(Animator);
				_animatorStateForSave = null;
			}
			else
			{
				Logging.Error("Restoring a Character that has no _animatorStateForSave - must have been destroyed before saving.");
			}
			Rotation = rotation;
			Position = position;
			_attributes.Iterate(delegate(AttributeFloat attribute)
			{
				attribute.GreaterThan(GameAlgorithms.Config.UrgentNeedThreshold, UrgentNeed, checkCallback: false);
			});
			RemoveComponents<BlendAnimationControllerComponent>();
			Selectable = GetComponent<DisableSelectionComponent>() == null;
			Highlightable = GetComponent<DisableHighlightComponent>() == null;
			Teleporting = GetComponent<TeleportCharacterComponent>() != null;
			LockedInRoom = GetComponent<LockCharacterInRoomComponent>() != null;
			Level level2 = base.Level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, (Action)delegate
			{
				if (RoomUsing != null && !base.Level.WorldState.AllRooms.Contains(RoomUsing))
				{
					Logging.Warning(LogChannels.AI, "Found {0} using a destroyed room", this);
					RoomUsing.Destroy();
					RoomUsing = null;
					if (LockedInRoom)
					{
						LockedInRoom = false;
						RemoveComponents<LockCharacterInRoomComponent>();
					}
				}
				if (Interaction != null && Interaction.HasFinished())
				{
					Interaction.EndInteraction(this);
				}
				if (BehaviourTreeDisablersCount != 0 && SatisfyNeedsComponent != null && !SatisfyNeedsComponent.SatisfyingNeed && _animationStack.Count == 0 && _behaviourStack.Count == 0 && !NavPath.IsNavigating() && (!(this is Patient patient) || !patient.IsAEPatient || patient.HasArrivedAndDisembarked()))
				{
					Logging.Warning(LogChannels.Behaviour, "Fixing up disabled behaviour for {0}", this);
					while (BehaviourTreeDisablersCount != 0)
					{
						EnableBehaviour(enabled: true);
					}
				}
			});
		}

		public virtual void FixupMissingBehaviour()
		{
			Logging.Warning(LogChannels.Behaviour, "Fixing up {0} as they failed to load correctly", this);
			CancelModeChange();
			if (SatisfyNeedsComponent != null)
			{
				SatisfyNeedsComponent.Interrupt();
			}
			if (Interaction != null)
			{
				Interaction.InterruptInteraction(this, characterDestroyed: false);
			}
			if (GetComponent<GhostComponent>() != null)
			{
				Idle();
			}
		}

		public override void Destroy()
		{
			_attributes.Destroy();
			NavPath.Destroy();
			RemoveComponents<EntityComponent>();
			if (ModifiersComponent != null && !ModifiersComponent.HasBeenDestroyed())
			{
				ModifiersComponent.Destroy();
				ModifiersComponent = null;
			}
			if (SatisfyNeedsComponent != null && !SatisfyNeedsComponent.HasBeenDestroyed())
			{
				SatisfyNeedsComponent.Destroy();
				SatisfyNeedsComponent = null;
			}
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomClosed, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomMissingRequiredItem = (Action<Room>)Delegate.Remove(buildEvents3.OnRoomMissingRequiredItem, new Action<Room>(OnRoomBecameInvalid));
			BuildEvents buildEvents4 = base.Level.BuildEvents;
			buildEvents4.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents4.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			BuildEvents buildEvents5 = base.Level.BuildEvents;
			buildEvents5.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents5.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			_characterAnimationEvents.Destroy();
			if (_behaviourStack != null)
			{
				BehaviourStackEntry[] array = _behaviourStack.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					CharacterBehaviorTree behaviourTree = array[i].BehaviourTree;
					base.Level.BehaviourTreePool.Set(behaviourTree, null);
					behaviourTree.OnDestroy();
					UnityEngine.Object.Destroy(behaviourTree);
				}
				_behaviourStack.Clear();
			}
			if (BehaviorTree != null)
			{
				base.Level.BehaviourTreePool.Set(BehaviorTree, null);
				BehaviorTree.OnDestroy();
			}
			if (ReservedInteraction != null)
			{
				ReservedInteraction.StopWaitingForInteraction(this);
				ReservedInteraction.FreeInteraction(this);
			}
			if (Interaction != null)
			{
				Interaction.StopWaitingForInteraction(this);
				Interaction.InterruptInteraction(this, characterDestroyed: true);
			}
			UnityEngine.Object.Destroy(GameObject);
			_visualManager.RoomLightingManager.UnregisterCharacter(this);
			Visual.Destroy();
			base.Level.StatusIconManager.DestroyStatusIcon(this);
			base.Destroy();
		}

		public void SetBehaviour(ExternalBehavior behaviour)
		{
			if (!(BehaviorTree == null))
			{
				while (_behaviourStack.Count != 0)
				{
					PopBehaviourTree(_behaviourStack[_behaviourStack.Count - 1].ID);
				}
				if (_behaviour != null)
				{
					BehaviourFinished(success: false, GameObject);
				}
				base.Level.BehaviourTreePool.Set(BehaviorTree, behaviour);
				_newBehaviour = true;
				_behaviour = behaviour;
				if (behaviour != null && BehaviorTree != null)
				{
					BehaviorTree.BehaviorName = behaviour.name;
					CharacterBehaviorTree behaviorTree = BehaviorTree;
					behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(BehaviourFinished));
					SetBehaviourVariables(BehaviorTree);
				}
				if (!BehaviorTreeEnabled && BehaviorTree != null && BehaviorTree.ExternalBehavior != null)
				{
					BehaviorTree.DisableBehavior(pause: true);
				}
			}
		}

		private void CheckForNewBehaviour()
		{
			if (_newBehaviour && _behaviour != null)
			{
				if (BehaviorTreeEnabled && !BehaviorManager.instance.IsBehaviorEnabled(BehaviorTree))
				{
					BehaviorTree.EnableBehavior();
				}
				_newBehaviour = false;
			}
		}

		private void BehaviourFinished(bool success, GameObject owner)
		{
			_ = _behaviour == null;
			_behaviour = null;
			CharacterBehaviorTree behaviorTree = BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree.OnFinishedEvent, new CharacterBehaviorTree.FinishedEvent(BehaviourFinished));
		}

		public void EnableBehaviour(bool enabled)
		{
			int behaviourTreeDisablersCount = BehaviourTreeDisablersCount;
			if (enabled)
			{
				if (BehaviourTreeDisablersCount <= 0)
				{
					Logging.Warning("Enabling {0} behaviour when it hasn't already been disabled; mismatched calls to EnableBehaviour.", this);
				}
				else
				{
					BehaviourTreeDisablersCount--;
				}
			}
			else
			{
				BehaviourTreeDisablersCount++;
			}
			if (behaviourTreeDisablersCount == 0 && BehaviourTreeDisablersCount > 0)
			{
				EnableBehaviourInternal(enabled: false);
			}
			else if (behaviourTreeDisablersCount > 0 && BehaviourTreeDisablersCount == 0)
			{
				EnableBehaviourInternal(enabled: true);
			}
		}

		private void EnableBehaviourInternal(bool enabled)
		{
			BehaviorTreeEnabled = enabled;
			if (BehaviorTree.ExternalBehavior != null)
			{
				if (enabled)
				{
					BehaviorTree.EnableBehavior();
				}
				else
				{
					BehaviorTree.DisableBehavior(pause: true);
				}
			}
		}

		protected virtual void SetBehaviourVariables(CharacterBehaviorTree behaviorTree)
		{
			behaviorTree.SetVariable("Character", new CharacterRef(this));
		}

		public virtual void Update(float deltaTime)
		{
			_totalTimeInHospital += deltaTime;
			if (deltaTime > 0f)
			{
				NavPath.Update();
			}
			if (deltaTime > 0f)
			{
				CheckForNewBehaviour();
			}
			if (Interaction != null && deltaTime > 0f)
			{
				Interaction.ApplyCharacterInteractingAttributeModifiers(deltaTime);
				Interaction.SetActorsHidden(Visual.HiddenModeEnable);
			}
			float time = GameTime.time;
			if (_nextTimeAttributesUpdated < time)
			{
				UpdateAttributes(time - _lastTimeAttributesUpdated);
				ResetNextAndLastAttributeTimes();
			}
			if ((double)GameTime.unscaledTime - base.Level.GameTime.PausedDuration - (double)_statusIconCheckTime > (double)GameAlgorithms.Config.CharacterStatusIconCheckTime)
			{
				UpdateStatusIcon();
				SetStatusIconCheckTime();
			}
			UpdateRoomUsing();
			if (_modeChange != null && deltaTime > 0f && _modeChange.Update())
			{
				_modeChange = null;
			}
			if (Traits != null && deltaTime > 0f)
			{
				Traits.Update(this);
			}
			if (_animationEndEvent != null && AnimationGraph != null && Animator.IsInState("Exit"))
			{
				_animationEndEvent.OnAnimationEndEvent();
				_animationEndEvent = null;
			}
			Visual.Update();
			if (Transform != null)
			{
				_position = Transform.position;
			}
		}

		public virtual bool ShouldBehaviourAllowExitingOfRoom(Room roomExiting)
		{
			return true;
		}

		public bool IsInteractingWithRoomDoor()
		{
			bool result = false;
			if ((Interaction != null && Interaction.IsRoomDoorInteraction()) || (ReservedInteraction != null && ReservedInteraction.IsRoomDoorInteraction()) || (WaitingForInteraction != null && WaitingForInteraction.IsRoomDoorInteraction()))
			{
				result = true;
			}
			return result;
		}

		protected virtual void UpdateAttributes(float deltaTime)
		{
			if (!_attributes.Enabled)
			{
				return;
			}
			CalculateEnvironmentalValues(HospitalAttributeMap.Attribute.Attractiveness);
			CalculateEnvironmentalValues(HospitalAttributeMap.Attribute.Temperature);
			AttributeFloat attribute = _attributes.GetAttribute(CharacterAttributes.Type.Hygiene);
			if (attribute != null)
			{
				HospitalAttributeMap hospitalAttributeMap = base.Level.WorldState.HospitalAttributeMaps[2];
				float num = (hospitalAttributeMap.GetMapAttribute(Position) + 1f) * 50f;
				float num2 = attribute.Value();
				float num3 = num - num2;
				if (num3 < 0f)
				{
					float environmentHygieneMultiplier = Definition.EnvironmentHygieneMultiplier;
					attribute.Modify(num3 * environmentHygieneMultiplier * deltaTime, GetAttributeMultiplier(CharacterAttributes.Type.Hygiene));
					hospitalAttributeMap.OnCharacterUpdated.InvokeSafe();
				}
			}
			AttributeFloat attribute2 = _attributes.GetAttribute(CharacterAttributes.Type.Temperature);
			if (attribute2 != null)
			{
				HospitalAttributeMap hospitalAttributeMap2 = base.Level.WorldState.HospitalAttributeMaps[0];
				float num4 = ((TemperatureValue + 1f) / 2f * 100f - attribute2.Value()) * Definition.EnvironmentTemperatureMultiplier;
				attribute2.Modify(num4 * deltaTime, GetAttributeMultiplier(CharacterAttributes.Type.Temperature));
				hospitalAttributeMap2.OnCharacterUpdated.InvokeSafe();
			}
		}

		private void ResetNextAndLastAttributeTimes()
		{
			_nextTimeAttributesUpdated = (_lastTimeAttributesUpdated = GameTime.time) + RandomUtils.GlobalRandomInstance.NextFloat(0.5f, 1f);
		}

		private void UpdateRoomUsing()
		{
			if (!Teleporting && !LockedInRoom && GameObject.activeSelf)
			{
				Room roomAtWorldCoord = base.Level.WorldState.GetRoomAtWorldCoord(Position.ToGridCoord(), includeHospital: true, includeClosedPlots: false);
				if (roomAtWorldCoord != RoomUsing)
				{
					LeftRoom();
					VisitRoom(roomAtWorldCoord);
				}
			}
		}

		public void ForceUpdateRoomUsing(Room room)
		{
			if (room != RoomUsing)
			{
				LeftRoom();
				VisitRoom(room);
			}
		}

		public virtual void DebugGUI()
		{
		}

		public virtual void DebugDraw()
		{
			if (ShowDebugInfo)
			{
				NavPath.DrawPath();
			}
		}

		public bool RayCast(Ray ray, out RaycastHit hit)
		{
			if (_collider != null && _collider.Raycast(ray, out hit, 400f))
			{
				return true;
			}
			hit = default(RaycastHit);
			return false;
		}

		public void Interrupt()
		{
			NavPath.Halt();
			CheckForNewBehaviour();
			EnableBehaviour(enabled: false);
			if (_behaviourStack.Count != 0)
			{
				_behaviourStack[_behaviourStack.Count - 1].BehaviourTree.DisableBehavior(pause: true);
			}
			if (ReservedInteraction != null)
			{
				ReservedInteraction.FreeInteraction(this);
			}
			if (Interaction != null)
			{
				Interaction.EndInteraction(this);
			}
			RemoveComponents<AttachActorToCharacterComponent>();
		}

		public void Resume()
		{
			EnableBehaviour(enabled: true);
			if (_behaviourStack.Count != 0)
			{
				_behaviourStack[_behaviourStack.Count - 1].BehaviourTree.EnableBehavior();
			}
		}

		public virtual void Idle()
		{
			if (NavPath != null && !NavPath.HasBeenDestroyed())
			{
				NavPath.Halt();
			}
			GoingToRoom = null;
			SetBehaviour(Definition._behaviourIdle);
		}

		public bool IsPlayingInteraction(string name)
		{
			if (Interaction != null)
			{
				return Interaction.Name == name;
			}
			return false;
		}

		protected bool IsMale()
		{
			return _sex == Sex.Male;
		}

		private void VisitRoom(Room room)
		{
			RoomUsing = room;
			if (room != null)
			{
				_lastVisitedRoomTime = _totalTimeInHospital;
				base.Level.CharacterEvents.OnVisitRoom.InvokeSafe(this, room);
			}
		}

		private void LeftRoom()
		{
			if (RoomUsing != null)
			{
				base.Level.CharacterEvents.OnLeaveRoom.InvokeSafe(this, RoomUsing, _totalTimeInHospital - _lastVisitedRoomTime);
				RoomUsing = null;
			}
		}

		public AttributesManager GetAttributesManager()
		{
			return base.Level.AttributesManager;
		}

		public Attributes GetAttributes()
		{
			return _attributes;
		}

		public void GetAttributeNames(out string[] names)
		{
			names = CharacterAttributes.TypeNames;
		}

		public void GetAttributeHashCodes(out int[] hashCodes)
		{
			hashCodes = CharacterAttributes.TypeHashCodes;
		}

		public CharacterAttributes GetCharacterAttributes()
		{
			return _attributes;
		}

		public virtual float GetAttributeModifierOverTime(string attributeName)
		{
			return Definition.GetAttributeModifer((CharacterAttributes.Type)_attributes.StringToEnumValue(attributeName));
		}

		public float GetAttributeMultiplier(int type)
		{
			return GetAttributeMultiplier((CharacterAttributes.Type)type);
		}

		public float GetAttributeMultiplier(CharacterAttributes.Type type)
		{
			if (!CanUpdateAttribute(type))
			{
				return 0f;
			}
			_getAttributeMultiplierParam.Type = type;
			_getAttributeMultiplierParam.Multiplier = 1f;
			if (ModifiersComponent != null)
			{
				ModifiersComponent.IterateModifiersOfType(_getAttributeMultiplierParam, delegate(GetAttributeMultiplierParam param, CharacterModifierAtrributeMultiplier modifier)
				{
					if (modifier.Type == param.Type)
					{
						param.Multiplier += modifier.Modifier;
					}
				});
			}
			return Mathf.Max(_getAttributeMultiplierParam.Multiplier, 0f);
		}

		protected virtual bool CanUpdateAttribute(CharacterAttributes.Type type)
		{
			return true;
		}

		public void PushAnimationGraph(RuntimeAnimatorController animationGraph, float blendTime = 0f, IAnimationEndEvent endEvent = null)
		{
			if (!HasBeenDestroyed())
			{
				if (GameTime.deltaTime > 0f && blendTime > 0f)
				{
					GetOrAddComponent<BlendAnimationControllerComponent>().Init(blendTime);
				}
				else
				{
					RemoveComponents<BlendAnimationControllerComponent>();
				}
			}
			_animationStack.Add(new AnimationStackEntry
			{
				AnimGraph = AnimationGraph,
				EndEvent = _animationEndEvent
			});
			AnimationGraph = animationGraph;
			_animationEndEvent = endEvent;
		}

		public void PopAnimationGraph(RuntimeAnimatorController animationGraph, float blendTime, bool isolate = false)
		{
			if (AnimationGraph != animationGraph)
			{
				foreach (AnimationStackEntry item in _animationStack)
				{
					if (item.AnimGraph == animationGraph)
					{
						IAnimationEndEvent endEvent = item.EndEvent;
						_animationStack.Remove(item);
						if (endEvent != null)
						{
							item.EndEvent = null;
							endEvent.OnAnimationEndEvent();
						}
						break;
					}
				}
			}
			else
			{
				if (GameTime.deltaTime > 0f && blendTime > 0f && !HasBeenDestroyed())
				{
					GetOrAddComponent<BlendAnimationControllerComponent>().Init(blendTime);
				}
				AnimationStackEntry animationStackEntry = _animationStack.Pop();
				AnimationGraph = animationStackEntry.AnimGraph;
				_animationEndEvent = animationStackEntry.EndEvent;
			}
			if (isolate)
			{
				while (_animationStack.Count > 0)
				{
					AnimationStackEntry animationStackEntry2 = _animationStack.Pop();
					AnimationGraph = animationStackEntry2.AnimGraph;
					_animationEndEvent = animationStackEntry2.EndEvent;
				}
			}
		}

		public int PushBehaviourTree(ExternalBehavior behaviour, bool pauseWhenPushed, bool restartWhenPopped, bool restartMainBehaviour, Action<CharacterBehaviorTree> initialiseVariables)
		{
			CharacterBehaviorTree characterBehaviorTree = GameObject.AddComponent<CharacterBehaviorTree>();
			characterBehaviorTree.StartWhenEnabled = false;
			characterBehaviorTree.PauseWhenDisabled = true;
			characterBehaviorTree.RestartWhenComplete = false;
			characterBehaviorTree.ResetValuesOnRestart = false;
			base.Level.BehaviourTreePool.Set(characterBehaviorTree, behaviour);
			characterBehaviorTree.BehaviorName = behaviour.name;
			initialiseVariables?.InvokeSafe(characterBehaviorTree);
			if (_behaviourStack.Count == 0)
			{
				EnableBehaviour(enabled: false);
			}
			else
			{
				BehaviourStackEntry behaviourStackEntry = _behaviourStack[_behaviourStack.Count - 1];
				if (behaviourStackEntry.PauseWhenPushed)
				{
					behaviourStackEntry.BehaviourTree.DisableBehavior(pause: true);
				}
			}
			characterBehaviorTree.EnableBehavior();
			int num = ++_nextBehaviourID;
			_behaviourStack.Add(new BehaviourStackEntry
			{
				ID = num,
				Behaviour = behaviour,
				BehaviourTree = characterBehaviorTree,
				PauseWhenPushed = pauseWhenPushed,
				RestartWhenPopped = restartWhenPopped,
				RestartMainBehaviour = restartMainBehaviour
			});
			return num;
		}

		public void PopBehaviourTree(int behaviourID)
		{
			if (_behaviourStackPop != null && _behaviourStackPop.ID == behaviourID)
			{
				return;
			}
			BehaviourStackEntry behaviourStackEntry = GetBehaviourStackEntry(behaviourID);
			if (behaviourStackEntry == null)
			{
				Logging.Error(LogChannels.Behaviour, "Trying to pop stack behaviour tree {0} that isn't on {1}", behaviourID, this);
				return;
			}
			BehaviourStackEntry behaviourStackEntry2 = _behaviourStack[_behaviourStack.Count - 1];
			bool num = behaviourStackEntry2 == behaviourStackEntry;
			_behaviourStackPop = behaviourStackEntry;
			_behaviourStack.Remove(behaviourStackEntry);
			CharacterBehaviorTree behaviourTree = behaviourStackEntry.BehaviourTree;
			base.Level.BehaviourTreePool.Set(behaviourTree, null);
			behaviourTree.OnDestroy();
			UnityEngine.Object.Destroy(behaviourTree);
			_behaviourStackPop = null;
			if (!num)
			{
				return;
			}
			if (_behaviourStack.Count == 0)
			{
				EnableBehaviour(enabled: true);
				if (behaviourStackEntry2.RestartMainBehaviour)
				{
					BehaviorManager.instance.EnableBehavior(BehaviorTree);
					BehaviorManager.instance.RestartBehavior(BehaviorTree);
					if (!BehaviorTreeEnabled)
					{
						BehaviorTree.DisableBehavior(pause: true);
					}
				}
				else if (BehaviorTreeEnabled)
				{
					BehaviorManager.instance.EnableBehavior(BehaviorTree);
				}
			}
			else
			{
				behaviourStackEntry2 = _behaviourStack[_behaviourStack.Count - 1];
				if (behaviourStackEntry2.RestartWhenPopped)
				{
					BehaviorManager.instance.EnableBehavior(behaviourStackEntry2.BehaviourTree);
					BehaviorManager.instance.RestartBehavior(behaviourStackEntry2.BehaviourTree);
				}
				else if (behaviourStackEntry2.PauseWhenPushed)
				{
					BehaviorManager.instance.EnableBehavior(behaviourStackEntry2.BehaviourTree);
				}
			}
		}

		private BehaviourStackEntry GetBehaviourStackEntry(int behaviourID)
		{
			if (_behaviourStackPop != null && _behaviourStackPop.ID == behaviourID)
			{
				return _behaviourStackPop;
			}
			foreach (BehaviourStackEntry item in _behaviourStack)
			{
				if (item.ID == behaviourID)
				{
					return item;
				}
			}
			return null;
		}

		public CharacterBehaviorTree GetBehaviourTreeFromStack(int behaviourID)
		{
			BehaviourStackEntry behaviourStackEntry = GetBehaviourStackEntry(behaviourID);
			if (behaviourStackEntry == null)
			{
				Logging.Warning(LogChannels.Behaviour, "Trying to get invalid stack behaviour tree {0} for {1}", behaviourID, this);
				return null;
			}
			return behaviourStackEntry.BehaviourTree;
		}

		protected virtual string GetInteractionPostfix()
		{
			if (!IsMale())
			{
				return "_F";
			}
			return null;
		}

		private RuntimeAnimatorController GetLocomotionAnimGraph()
		{
			if (ModifiersComponent != null)
			{
				_getLocomotionAnimGraphParam.Priority = 0;
				_getLocomotionAnimGraphParam.Modifier = null;
				ModifiersComponent.IterateModifiersOfType(_getLocomotionAnimGraphParam, delegate(GetLocomotionAnimGraphParam param, CharacterModifierLocoAnimationGraph characterModifierLocoAnimationGraph)
				{
					if (param.Priority <= characterModifierLocoAnimationGraph.Priority)
					{
						param.Priority = characterModifierLocoAnimationGraph.Priority;
						param.Modifier = characterModifierLocoAnimationGraph;
					}
				});
				RemoveLocoMovementSpeedModifier();
				if (_getLocomotionAnimGraphParam.Modifier != null)
				{
					CharacterModifierLocoAnimationGraph modifier = _getLocomotionAnimGraphParam.Modifier;
					RuntimeAnimatorController runtimeAnimatorController = FindAnimationGraph(ref modifier.LocoGraphs);
					_getLocomotionAnimGraphParam.Modifier = null;
					if (runtimeAnimatorController != null)
					{
						if (modifier.MovementSpeedModifierSettings.HasValue)
						{
							ApplyMovementModifier(modifier.MovementSpeedModifierSettings.Value);
						}
						return runtimeAnimatorController;
					}
				}
			}
			return FindAnimationGraph(ref Definition._locomotionAnimGraph);
		}

		public void RefreshLocoAnimationGraph()
		{
			if (!(Animator != null))
			{
				return;
			}
			RuntimeAnimatorController locomotionAnimGraph = GetLocomotionAnimGraph();
			if (AnimationGraph != locomotionAnimGraph)
			{
				if (_animationStack.Count == 0)
				{
					AnimationGraph = locomotionAnimGraph;
				}
				else
				{
					_animationStack[0].AnimGraph = locomotionAnimGraph;
				}
			}
		}

		public RuntimeAnimatorController FindAnimationGraph(ref RuntimeAnimatorController[] animGraphs, bool returnNullOnFailure = false)
		{
			if (animGraphs == null || animGraphs.Length == 0)
			{
				return null;
			}
			string interactionPostfix = GetInteractionPostfix();
			if (!string.IsNullOrEmpty(interactionPostfix))
			{
				RuntimeAnimatorController[] array = animGraphs;
				foreach (RuntimeAnimatorController runtimeAnimatorController in array)
				{
					if (runtimeAnimatorController.name.EndsWith(interactionPostfix))
					{
						return runtimeAnimatorController;
					}
				}
			}
			if (!returnNullOnFailure)
			{
				return animGraphs[0];
			}
			return null;
		}

		protected void LeaveQueue()
		{
			if (QueuingAtRoom != null)
			{
				QueuingAtRoom.RemoveFromQueue(this);
				QueuingAtRoom = null;
			}
		}

		public virtual void GotoRoom(Room room, ReasonUseRoom reason, bool setByPlayer, int queueIndex = -1)
		{
			LeaveQueue();
			SetBehaviour(Definition._behaviourGotoRoom);
			BehaviorTree.SetVariable("Room", new RoomRef(room));
			BehaviorTree.SetVariable("Reason", new ReasonUseRoomRef(reason));
			BehaviorTree.SetVariable("Queue Index", queueIndex);
			GoingToRoomSetByPlayer = setByPlayer;
			GoingToRoom = room;
			ReasonUsingRoom = reason;
		}

		public virtual bool IsSelectable()
		{
			return Selectable;
		}

		public bool HasTooltip()
		{
			return true;
		}

		public virtual bool CanHighlight()
		{
			return Highlightable;
		}

		public void ToggleDebugInfo()
		{
			ShowDebugInfo = !ShowDebugInfo;
		}

		public Renderer GetHighlightGameObject()
		{
			return null;
		}

		public void GetMultipleHighlightGameObjects(List<Renderer> result)
		{
			if (Visual.RetroModeVisible)
			{
				Visual.RetroGameObject.GetComponentsInChildren(result);
				return;
			}
			result.Clear();
			foreach (CharModule.ModuleInstance moduleInstance in Visual.ModuleInstances)
			{
				Renderer renderer = moduleInstance.Renderer;
				if (renderer.enabled && renderer.gameObject.activeInHierarchy)
				{
					result.Add(renderer);
				}
			}
			if (Visual.MaskInstances == null)
			{
				return;
			}
			foreach (CharModule.ModuleInstance maskInstance in Visual.MaskInstances)
			{
				Renderer renderer2 = maskInstance.Renderer;
				if (renderer2.enabled && renderer2.gameObject.activeInHierarchy)
				{
					result.Add(renderer2);
				}
			}
		}

		public Vector3 GetMenuAnchorPosition()
		{
			return Position;
		}

		public GameObject GetCameraTrackObject()
		{
			return GameObject;
		}

		public virtual bool CanDragHoldSelect()
		{
			return false;
		}

		public void SetActiveMenu(InWorldMenuObject menu)
		{
			_activeMenu = menu;
		}

		public InWorldMenuObject GetActiveMenu()
		{
			return _activeMenu;
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			if (!room.FloorPlan.HospitalMap.Plot.Built || !Visual.IsActive() || RoomUsing == null || !RoomUsing.Definition.IsHospitalOrBay || GetComponent<GhostComponent>() != null)
			{
				return;
			}
			Vector3 vector = GetComponent<TeleportCharacterComponent>()?.Destination ?? ((Transform != null) ? Transform.position : Position);
			GridCoord gridCoord = vector.ToGridCoord();
			if (room.FloorPlan.WorldBounds.IsInBounds(gridCoord))
			{
				if (RoomAlgorithms.RoomContainsWorldPosition(room.FloorPlan, vector, 0.5f))
				{
					TeleportOutOfRoom(room);
				}
				else if (!room.FloorPlan.HospitalMap.PositionConnectsToEntrance(gridCoord))
				{
					TeleportOutOfRoom(room);
				}
			}
		}

		public void TeleportOutOfRoom(Room room)
		{
			if (RoomUsing == null)
			{
				return;
			}
			if (RoomAlgorithms.FindNearestFreeTile(RoomUsing.FloorPlan.HospitalMap.FloorPlan, Position, out var result))
			{
				if (RoomUsing == room)
				{
					room.ExitRoom(this);
					LeftRoom();
				}
				result += RandomUtils.RandomXZVector(-0.5f, 0.5f);
				GetOrAddComponent<TeleportCharacterComponent>().SetDestination(result);
			}
			else
			{
				Logging.Warning(LogChannels.AI, "Failed to teleport {0} out of room {1}", this, room);
			}
		}

		protected virtual void DestinationRoomInvalid(Room room)
		{
			Idle();
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			if ((Visual.IsActive() && roomBeingEdited == GoingToRoom) || roomBeingEdited == RoomUsing || roomBeingEdited == QueuingAtRoom)
			{
				CalledIntoRoom = false;
				roomBeingEdited.ExitRoom(this);
				roomBeingEdited.RemoveFromQueue(this);
				DestinationRoomInvalid(roomBeingEdited);
			}
		}

		protected virtual void OnRoomBecameInvalid(Room room)
		{
			if (!Visual.IsActive())
			{
				return;
			}
			RoomDefinition roomDefinition = null;
			if (room == GoingToRoom)
			{
				roomDefinition = room.Definition;
			}
			else if (room == RoomUsing)
			{
				roomDefinition = room.Definition;
			}
			else if (room == QueuingAtRoom)
			{
				roomDefinition = room.Definition;
			}
			if (roomDefinition != null)
			{
				DestinationRoomInvalid(room);
				if (Interaction != null && Interaction.ParentRoomItem.OwningRoom == room)
				{
					Interaction.RequestExit();
				}
			}
		}

		public virtual void EvictedFromRoom(Room room)
		{
			Room room2 = ((GoingToRoom != null) ? GoingToRoom : room);
			int queueIndex = ((RoomUsing != room) ? (-1) : 0);
			if (!room2.IsOpen)
			{
				Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(base.Level.WorldState, room2.Definition._type, GetUseRoomType(), this);
				if (bestRoomOfType != null)
				{
					room2 = bestRoomOfType;
				}
			}
			GotoRoom(room2, ReasonUsingRoom, setByPlayer: false, queueIndex);
		}

		public void ReturnToRoomQueue()
		{
			GotoRoom(GoingToRoom, ReasonUsingRoom, setByPlayer: false, 0);
		}

		public virtual bool AllowedToLeaveHospital()
		{
			if (RoomUsing != null && !IsIdleInHospital())
			{
				return IsInUnstaffedRoom();
			}
			return true;
		}

		public virtual void LeaveHospital(ReasonForLeavingHospital reason)
		{
			CancelModeChange();
			ReasonForLeaving = reason;
			if (GoingToRoom != null)
			{
				GoingToRoom.RemoveFromQueue(this);
				GoingToRoom = null;
			}
			LeaveQueue();
			if (!(this is Patient patient) || !patient.IsSendHomeAnachronistic())
			{
				_attributes.Enabled = false;
			}
			else
			{
				patient.InterruptNeedSatisfaction();
			}
			RemoveComponents<WaitForRoomToBeBuiltComponent>();
			RemoveComponents<CharacterCheckInComponent>();
			SetBehaviour(Definition._behaviourLeaveHospital);
		}

		protected bool IsIdleInHospital()
		{
			if (!Interruptable)
			{
				return false;
			}
			if (SatisfyingNeed)
			{
				return false;
			}
			if (RoomUsing == null)
			{
				return false;
			}
			if (RoomUsing?.FloorPlan?.Door != null && !RoomUsing.Definition.IsHospitalOrBay && RoomUsing.FloorPlan.Door.Interactions.Count != 0)
			{
				return false;
			}
			if (Interaction?.ParentRoomItem?.OwningRoom != null)
			{
				RoomItem parentRoomItem = Interaction.ParentRoomItem;
				bool flag = !parentRoomItem.OwningRoom.Definition.IsHospitalOrBay;
				bool flag2 = parentRoomItem.Definition.ItemType != RoomItemDefinition.Type.ServingHatch;
				if (flag && flag2)
				{
					return false;
				}
			}
			if (HasBeenCalledIntoRoom())
			{
				return false;
			}
			return true;
		}

		protected bool IsInUnstaffedRoom()
		{
			if (RoomUsing != null)
			{
				return !RoomUsing.IsStaffed();
			}
			return false;
		}

		public IdleAnimation GetIdleAnimOverride()
		{
			_getIdleAnimOverrideParam.Anim = IdleAnimation.Max;
			_getIdleAnimOverrideParam.Priority = 0;
			if (ModifiersComponent != null)
			{
				ModifiersComponent.IterateModifiersOfType(_getIdleAnimOverrideParam, delegate(GetIdleAnimOverrideParam param, CharacterModifierIdleOverride modifier)
				{
					if (param.Priority <= modifier.Priority)
					{
						param.Anim = modifier.Animation;
						param.Priority = modifier.Priority;
					}
				});
			}
			return _getIdleAnimOverrideParam.Anim;
		}

		public WalkAnimation GetWalkAnimOverride()
		{
			_getWalkAnimOverrideParam.Anim = WalkAnimation.Max;
			_getWalkAnimOverrideParam.Priority = 0;
			if (ModifiersComponent != null)
			{
				ModifiersComponent.IterateModifiersOfType(_getWalkAnimOverrideParam, delegate(GetWalkAnimOverrideParam param, CharacterModifierWalkOverride modifier)
				{
					if (param.Priority <= modifier.Priority)
					{
						param.Anim = modifier.Animation;
						param.Priority = modifier.Priority;
					}
				});
			}
			return _getWalkAnimOverrideParam.Anim;
		}

		public virtual IdleAnimation GetIdleAnim()
		{
			IdleAnims.Clear();
			IdleAnims.Add(IdleAnimation.Normal);
			IdleAnims.Add(IdleAnimation.LookLeft);
			IdleAnims.Add(IdleAnimation.LookRight);
			IdleAnims.Add(IdleAnimation.HandsHips);
			if (RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f) <= GameAlgorithms.Config.ChanceOfNeedsIdle)
			{
				switch (GameAlgorithms.GetCharacterUrgentNeed(this))
				{
				case CharacterAttributes.Type.Hunger:
					IdleAnims.Add(IdleAnimation.Hungry);
					break;
				case CharacterAttributes.Type.Thirst:
					IdleAnims.Add(IdleAnimation.Thirsty);
					break;
				case CharacterAttributes.Type.Toilet:
					IdleAnims.Add(IdleAnimation.Toilet);
					break;
				case CharacterAttributes.Type.Boredom:
					IdleAnims.Add(IdleAnimation.Bored);
					break;
				}
			}
			IdleAnimation result = IdleAnims.RandomItem();
			IdleAnims.Clear();
			return result;
		}

		public virtual WalkAnimation GetWalkAnim()
		{
			return WalkAnimation.Normal;
		}

		public Vector3 GetStatusIconPosition()
		{
			if (Visual != null && Visual.HeadSocket != null)
			{
				return Visual.HeadSocket.position - Vector3.up * 1.5f;
			}
			return Position;
		}

		public bool IsStatusIconEmitterVisible()
		{
			if (GetComponent<DisableStatusIconComponent>() != null)
			{
				return false;
			}
			if (GameObject != null)
			{
				return GameObject.activeSelf;
			}
			return false;
		}

		private void UrgentNeed()
		{
			base.Level.CharacterEvents.OnCharacterUrgentNeed.InvokeSafe(this, GameAlgorithms.GetCharacterUrgentNeed(this));
		}

		public virtual bool CanSatisfyNeeds()
		{
			if (SatisfyingNeed || !Interruptable || !InteractionInterruptable || !_attributes.Enabled)
			{
				return false;
			}
			if (HasBeenCalledIntoRoom() || LockedInRoom)
			{
				return false;
			}
			CharacterCheckInComponent component = GetComponent<CharacterCheckInComponent>();
			if (component != null && component.Reception != null)
			{
				return false;
			}
			return true;
		}

		private void CalculateEnvironmentalValues(HospitalAttributeMap.Attribute attribute)
		{
			CharacterDefinition.EnvironmentHappiness environmentHappinessModifier = Definition.GetEnvironmentHappinessModifier(attribute);
			float mapAttribute = base.Level.WorldState.HospitalAttributeMaps[(int)attribute].GetMapAttribute(Position);
			mapAttribute = (float)MathUtils.Clamp(mapAttribute, -1.0, 1.0);
			float num = MathUtils.CalculateRangeModifier(mapAttribute, environmentHappinessModifier.StableMin, environmentHappinessModifier.StableMax, environmentHappinessModifier.MultiplierBelow, environmentHappinessModifier.MultiplierAbove, environmentHappinessModifier.StableValue);
			switch (attribute)
			{
			case HospitalAttributeMap.Attribute.Temperature:
				TemperatureValue = mapAttribute;
				TemperatureComfort = num;
				break;
			case HospitalAttributeMap.Attribute.Attractiveness:
				AttractivenessValue = mapAttribute;
				AttractivenessComfort = num;
				break;
			}
		}

		private void SetStatusIconCheckTime()
		{
			_statusIconCheckTime = GameTime.unscaledTime - (float)base.Level.GameTime.PausedDuration + (float)RandomUtils.GlobalRandomInstance.Next(-10, 10);
		}

		protected void UpdateStatusIcon()
		{
			StatusIcon.Type statusIcon = GetStatusIcon();
			if (statusIcon != StatusIcon.Type.Invalid)
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, statusIcon);
			}
		}

		public virtual StatusIcon.Type GetStatusIcon()
		{
			if (Happiness != null && Happiness.Value() < GameAlgorithms.Config.PatientLowHappiness)
			{
				return StatusIcon.Type.Unhappy;
			}
			CharacterDefinition.EnvironmentHappiness environmentHappinessModifier = Definition.GetEnvironmentHappinessModifier(HospitalAttributeMap.Attribute.Temperature);
			if (TemperatureValue < environmentHappinessModifier.StableMin)
			{
				return StatusIcon.Type.Cold;
			}
			if (TemperatureValue > environmentHappinessModifier.StableMax)
			{
				return StatusIcon.Type.Hot;
			}
			return StatusIcon.Type.Invalid;
		}

		public virtual float GetMaxMovementSpeed()
		{
			return Definition._maxSpeed * _maxSpeedMultiplier;
		}

		public void SetMovementMultipliers(CharacterModifierMovementSpeed movementSpeedModifier)
		{
			if (movementSpeedModifier != null && movementSpeedModifier.Priority >= _currentMovementModifierPriority)
			{
				ApplyMovementModifier(movementSpeedModifier);
			}
		}

		private void RemoveLocoMovementSpeedModifier()
		{
			_currentMovementModifierPriority = int.MinValue;
			RemoveMovementMultiplier();
		}

		public void RemoveMovementMultiplier()
		{
			if (ModifiersComponent == null || _currentMovementModifierPriority == int.MaxValue)
			{
				return;
			}
			int num = int.MinValue;
			CharacterModifierMovementSpeed movementSpeedModifier = null;
			foreach (CharacterModifier modifier in ModifiersComponent.Modifiers)
			{
				if (modifier is CharacterModifierMovementSpeed characterModifierMovementSpeed && num < characterModifierMovementSpeed.Priority)
				{
					num = characterModifierMovementSpeed.Priority;
					movementSpeedModifier = characterModifierMovementSpeed;
				}
			}
			ApplyMovementModifier(movementSpeedModifier);
		}

		private void ApplyMovementModifier(CharacterModifierMovementSpeed movementSpeedModifier)
		{
			if (movementSpeedModifier == null)
			{
				_currentMovementModifierPriority = int.MinValue;
				_maxSpeedMultiplier = 1f;
				_walkAnimMultiplier = 1f;
				NavPath.SetMaxSpeed(GetMaxMovementSpeed());
				NavPath.SetAcceleration(Definition._accelerationSpeed * 1f);
			}
			else
			{
				_currentMovementModifierPriority = movementSpeedModifier.Priority;
				_maxSpeedMultiplier = movementSpeedModifier.Multiplier;
				_walkAnimMultiplier = movementSpeedModifier.WalkAnimMultiplier;
				NavPath.SetMaxSpeed(GetMaxMovementSpeed());
				NavPath.SetAcceleration(Definition._accelerationSpeed * movementSpeedModifier.AccelerationMultiplier);
			}
		}

		private void ApplyMovementModifier(MovementSpeedModifierSettings movementSpeedModifier)
		{
			_currentMovementModifierPriority = int.MaxValue;
			_maxSpeedMultiplier = movementSpeedModifier.MaxSpeedMultiplier;
			_walkAnimMultiplier = movementSpeedModifier.WalkAnimMultiplier;
			NavPath.SetMaxSpeed(GetMaxMovementSpeed());
			NavPath.SetAcceleration(Definition._accelerationSpeed * movementSpeedModifier.AccelerationMultiplier);
		}

		public virtual bool CanPlayReactions()
		{
			if (GetComponent<DisableReactionsComponent>() == null)
			{
				return InteractionInterruptable;
			}
			return false;
		}

		public RuntimeAnimatorController GetTeleportAnimGraph()
		{
			if (!IsMale())
			{
				return Definition._teleportAnimationGraph[1];
			}
			return Definition._teleportAnimationGraph[0];
		}

		void fsISerializationCallbacks.OnBeforeSerialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnBeforeSerializeInstance(Type storageType)
		{
			if (GameObject == null)
			{
				return;
			}
			_positionForSave = Position;
			_rotationForSave = Rotation;
			if (float.IsNaN(_positionForSave.x) || float.IsNaN(_positionForSave.z))
			{
				Logging.Error(LogChannels.SaveDebug, "Saving character {0} with NaN position {1}", this, _positionForSave);
			}
			if (NavPath != null)
			{
				NavPath.OnBeforeSave();
			}
			_animatorStateForSave = new AnimatorSavedState(Animator);
			if (BehaviorTree == null)
			{
				Logging.Error(LogChannels.SaveDebug, "Saving {0} with a null BehaviorTree.", this);
				return;
			}
			if (_behaviour == null)
			{
				Logging.Error(LogChannels.SaveDebug, "Saving {0} with a null _behaviour.", this);
				return;
			}
			if (_behaviour.name != BehaviorTree.ExternalBehavior.name)
			{
				Logging.Error(LogChannels.SaveDebug, "Saving {0} with mismatched _behaviour and BehaviourTree.ExternalBehaviour ({1} and {2}) - this shouldn't be able to happen", this, _behaviour.name, BehaviorTree.ExternalBehavior.name);
			}
			_savedBehaviourState = BehaviorTree.Save();
			_savedBehaviourStack = new List<SavedBehaviourStackEntry>();
			foreach (BehaviourStackEntry item2 in _behaviourStack)
			{
				SavedBehaviourStackEntry item = new SavedBehaviourStackEntry
				{
					ID = item2.ID,
					Behaviour = item2.Behaviour,
					SavedState = item2.BehaviourTree.Save(),
					PauseWhenPushed = item2.PauseWhenPushed,
					RestartMainBehaviour = item2.RestartMainBehaviour,
					RestartWhenPopped = item2.RestartWhenPopped
				};
				_savedBehaviourStack.Add(item);
			}
		}

		void fsISerializationCallbacks.OnAfterSerialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterSerializeInstance(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserializeInstance(Type storageType)
		{
		}

		public bool HasBeenCalledIntoRoom()
		{
			if (!CalledIntoRoom)
			{
				return RoomCalledInto != null;
			}
			return true;
		}

		public void SetState(string state)
		{
			_state = state;
		}

		public string GetState()
		{
			if (_state == null)
			{
				return "NULL";
			}
			return _state;
		}

		public bool IsInState(string state)
		{
			return _state == state;
		}

		public void OnStartPath()
		{
			NavPathComplete = false;
		}

		public void OnPathComplete(EPathStatus status)
		{
			NavPathComplete = true;
			NavPathResult = status;
		}

		public void FixupAnimationEndEvent(IAnimationEndEvent endEvent, RuntimeAnimatorController animGraph)
		{
			if (animGraph == AnimationGraph)
			{
				_animationEndEvent = endEvent;
				return;
			}
			foreach (AnimationStackEntry item in _animationStack)
			{
				if (animGraph == item.AnimGraph)
				{
					item.EndEvent = endEvent;
				}
			}
		}

		public int GetQueuePosition()
		{
			if (QueuingAtRoom != null)
			{
				return QueuingAtRoom.PositionInQueue(this);
			}
			return -1;
		}

		protected bool ChangeMode(IModeChange newMode)
		{
			if (_modeChange != null && _modeChange.GetType() == newMode.GetType())
			{
				return false;
			}
			if (_modeChange == null || newMode.Priority() >= _modeChange.Priority())
			{
				_modeChange = newMode;
				return true;
			}
			return false;
		}

		protected bool IsModeChangeActive<T>() where T : IModeChange
		{
			return _modeChange is T;
		}

		protected IModeChange GetActiveModeChange()
		{
			return _modeChange;
		}

		public bool HasPendingModeChange()
		{
			return _modeChange != null;
		}

		public void CancelModeChange()
		{
			if (_modeChange != null)
			{
				_modeChange = null;
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (Interaction != null && Interaction.ParentRoomItem == roomItem && Interaction.IsInteracting(this))
			{
				Interaction.InterruptInteraction(this, characterDestroyed: false);
			}
			if (ReservedInteraction != null && ReservedInteraction.ParentRoomItem == roomItem)
			{
				ReservedInteraction.FreeInteraction(this);
			}
			foreach (KeyValuePair<int, InteractionController> content in _interactionControllers.Contents)
			{
				InteractionController value = content.Value;
				ObjectInteraction interaction = value.Interaction;
				if (interaction != null && interaction.ParentRoomItem == roomItem)
				{
					value.Destroy();
					_controllersToRemove.Add(content.Key);
				}
			}
			foreach (int item in _controllersToRemove)
			{
				_interactionControllers.Remove(item);
			}
			_controllersToRemove.Clear();
		}

		public bool IsOrphaned()
		{
			if (base.Level.CharacterManager.AllCharacters.Contains(this))
			{
				return base.Level.EntityManager.GetEntityByID(base.ID) != this;
			}
			return true;
		}

		public virtual RoomUseType GetUseRoomType()
		{
			return RoomUseType.Any;
		}

		public virtual void OnCharacterAttributeModified(CharacterAttributes.Type modifierType)
		{
		}

		public virtual void OnCharacterUsedItem(RoomItem item)
		{
		}

		public virtual void RegenerateVisualIfNeeded()
		{
		}
	}
}

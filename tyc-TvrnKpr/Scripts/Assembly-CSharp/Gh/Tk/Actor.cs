using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Conversations;
using Pathfinding;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class Actor : GameObjectX, IDisplayNameConfigurable
	{
		protected class AnimationParameterTreeNode
		{
			public List<AnimationParameterTreeNode> Children;

			public List<string> Values;

			public string Key { get; set; }

			public string KeyType { get; set; }

			public AnimationParameterTreeNode(string keyType, string key)
			{
			}

			public AnimationParameterTreeNode AddNodeIfNeeded(string keyType, string key)
			{
				return null;
			}

			public AnimationParameterTreeNode GetNode(string keyType, string key)
			{
				return null;
			}
		}

		public enum SubIdleStates
		{
			Unwell = 0,
			Rain = 1,
			Sandstorm = 2,
			Sad = 3,
			Angry = 4
		}

		public class ActorEventArgs<T> : EventArgs<T>
		{
			public Actor Actor { get; set; }

			public ActorEventArgs(T item, Actor actor)
				: base(default(T))
			{
			}
		}

		public static HashSet<Actor> AllActors;

		protected GameObject _model;

		private GameObject _shadowCard;

		private EnergyStat _energyStat;

		private MovementSpeedComponent _movementSpeedComponent;

		[PersistenceOptIn]
		private string _highLevelTaskDescriptionKey;

		[PersistenceOptIn]
		private string _currentTaskDescriptionKey;

		[PersistenceOptIn]
		public bool IsSleepingInBed;

		[PersistenceOptIn]
		private bool _isSleeping;

		[PersistenceOptIn]
		internal ValueWithModifiers _workSpeed;

		public static string DefaultFightReason;

		private bool _hasAllAccessPass;

		private float _radius;

		[PersistenceOptIn]
		private float _rotationSpeed;

		[PersistenceOptIn]
		private Quaternion _lastRotation;

		private float _currentAnimatorMovementSpeed;

		private float _currentAnimatorRotationSpeed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _currentWaitAnimation;

		protected List<string> ThoughtTopics;

		private GameObject _currentSelectionHighlight;

		private Color? _selectionHighlightDefaultColor;

		private Color? _selectionHighlightEmissionColor;

		private bool _isAudioDescriptionInitialised;

		public static EventHandler<ActorEventArgs<Prop>> NearlyArrivedAtProp;

		[PersistenceOptIn]
		public bool IsConfused;

		private Transform _headBoneTransform;

		private string _animationPreference;

		private Transform _neckBone;

		private Transform _chestBone;

		private Transform _propRightBone;

		private Transform _propLeftBone;

		[PersistenceOptIn]
		private Dictionary<string, int> _enabledAnimationParameters;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private List<GameItem> _temporaryAttachedItems;

		[PersistenceOptIn]
		private float _startedCrossFadingTimestamp;

		private const float _crossFadeTime = 0.25f;

		private static Dictionary<Type, AnimationParameterTreeNode> _animationParameterTrees;

		[PersistenceOptIn]
		private List<float> _currentSubIdleStates;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _currentIdleTransition;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isTransitionOutInProgress;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _isTransitionInInProgress;

		[PersistenceOptIn]
		private float _currentEmotionalXStep;

		[PersistenceOptIn]
		private float _currentEmotionalYStep;

		[PersistenceOptIn]
		private float _currentEmotionalXValue;

		[PersistenceOptIn]
		private float _currentEmotionalYValue;

		[PersistenceOptIn]
		private float _currentEmotionalXTarget;

		[PersistenceOptIn]
		private float _currentEmotionalYTarget;

		[PersistenceOptIn]
		private EmotionalState _currentBaseEmotionalState;

		[PersistenceOptIn]
		private EmotionalState _currentOverrideEmotionalState;

		[PersistenceOptIn]
		private EmotionalState _currentTargetEmotionalState;

		public ActorData Data { get; set; }

		public string AnimationPreference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsWearingShoes { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsWearingPyjama { get; set; }

		private GameObject ShadowCard => null;

		public FollowerEntity FollowerEntity { get; private set; }

		public IEnumerable<ActorBehaviour> Behaviours => null;

		protected IEnumerable<ActorBehaviour> InterruptBehaviours => null;

		protected IEnumerable<ActorBehaviour> PrioritizedBehaviours => null;

		public IEnumerable<ActorAttribute> Attributes => null;

		public IEnumerable<ActorSkill> Skills => null;

		public EnergyStat EnergyStat => null;

		public float Energy
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MovementSpeedComponent MovementSpeedComponent => null;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public AccessPoint CurrentAccessPoint { get; set; }

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public AccessPoint PreferredAccessPoint { get; set; }

		public string HighlevelTaskDescriptionKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CurrentTaskDescriptionKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public string WaitReason { get; set; }

		[PersistenceOptIn]
		public bool IsWaiting { get; set; }

		[PersistenceOptIn]
		public bool IsImpatiencePaused { get; set; }

		[PersistenceOptIn]
		public bool IsManuallyHandlingOutOfPatienceState { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsTalkingSuppressed { get; set; }

		[PersistenceOptIn]
		public bool IsSitting { get; private set; }

		public bool IsSleeping
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSick => false;

		public float WorkSpeedFactor => 0f;

		public float MoveSpeed => 0f;

		public bool IsMoving => false;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsOnLeave { get; set; }

		public bool IsInFight => false;

		[PersistenceOptIn]
		public bool HasAllAccessPass
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float RotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public string CurrentTopic { get; private set; }

		[PersistenceOptIn]
		public bool IsStandingUp { get; internal set; }

		[PersistenceOptIn]
		public bool IsSittingDown { get; internal set; }

		[PersistenceOptIn]
		public bool HasArrivedAtDestination { get; internal set; }

		[PersistenceOptIn]
		public bool HasWaitedTurn { get; internal set; }

		public bool CanMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float RotationY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Transform NeckBone => null;

		public Transform ChestBone => null;

		public Transform PropRightBone => null;

		public Transform PropLeftBone => null;

		public bool IsInEmotionalStateTransition => false;

		public event EventHandler<EventArgs<string>> HighLevelTaskDescriptionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler CurrentTaskDescriptionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs> SleepingOrStandingEventChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<Ingredient>> ConsumeItem
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<Prop>> ActorArrivedAtProp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<Prop>> ActorUseProp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<Prop>> ActorLeftProp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Actor>> ActorEnteringTavern
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Actor>> ActorLeavingTavern
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Actor>> ActorSpawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Actor>> ActorDespawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Actor>> ManualInstructionGiven
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<bool>> SleepingStatusChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ActorEventArgs<ActorAttribute>> AttributeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Staff>> StaffWageChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<EventArgs<Staff>> CurrentRoleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Actor()
		{
		}

		public virtual void SetData(ActorData actorData)
		{
		}

		public string GetFullDisplayNameKey()
		{
			return null;
		}

		public override string GetDisplayNameKey(bool withTypePrefix = true)
		{
			return null;
		}

		protected override string GetDefaultDisplayNameKey()
		{
			return null;
		}

		public override void SetDisplayName(string newName)
		{
		}

		protected override GameObject CreateUIModel()
		{
			return null;
		}

		public float GetRotationDuration(Quaternion rot)
		{
			return 0f;
		}

		public void EnableModel()
		{
		}

		public void DisableModel()
		{
		}

		public T GetBehaviour<T>() where T : ActorBehaviour
		{
			return null;
		}

		public T GetAttribute<T>() where T : ActorAttribute
		{
			return null;
		}

		public T GetSkill<T>() where T : ActorSkill
		{
			return null;
		}

		public void CheckAndCleanUpPreferredAccessPoint()
		{
		}

		public void LeaveCurrentAccessPoint()
		{
		}

		public bool IsStillOnTheWayToTarget()
		{
			return false;
		}

		public bool IsTalking()
		{
			return false;
		}

		public bool IsTalkingAllowed()
		{
			return false;
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public void SetIsSitting(bool isSitting)
		{
		}

		public void StartUseCurrentProp(string usageKey = "use")
		{
		}

		public void StopUseCurrentProp(string usageKey = "use")
		{
		}

		public void DestroyDrinksAndFoodInInventory()
		{
		}

		public override void Init()
		{
		}

		private void OnSleepOrStandingChanged(object sender, EventArgs e)
		{
		}

		protected virtual void InitNavigation()
		{
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void UpdateFootstepSounds()
		{
		}

		private void OnSpawnedItemAdded(object sender, EventArgs<SpawnedItem> e)
		{
		}

		private void InitRaceLayerOnSpawnedItem(SpawnedItem item)
		{
		}

		public FightTornado StartFight(string reasonKey = null)
		{
			return null;
		}

		public void SaySomething(string textKey, Color? color = null)
		{
		}

		public void AdjustMoney(int adjustment, string category, string reasonKey, bool playFloatingText = true)
		{
		}

		public virtual void InvalidateActorModel()
		{
		}

		protected virtual void ChangeModel(string model)
		{
		}

		public void SwapModel(string model)
		{
		}

		public void AppendModel(GameObject model)
		{
		}

		public Transform GetPelvisTransform()
		{
			return null;
		}

		protected void UpdateStateBasedAttachments()
		{
		}

		public void ReplaceSkinnedModel(GameObject newModelPrefab)
		{
		}

		public override void OnDestroy()
		{
		}

		public override bool InjectJob(Job job)
		{
			return false;
		}

		public void ReplaceJob(Job originalJob, Job newJob)
		{
		}

		public float GetVelocity()
		{
			return 0f;
		}

		private void UpdateRotationSpeed()
		{
		}

		protected override void UpdateInternal()
		{
		}

		public void SetMovementSpeed(float speed)
		{
		}

		public void SetRotationSpeed(float speed)
		{
		}

		private void CheckForContagiousDiseases()
		{
		}

		public void BecomeSick()
		{
		}

		public void Wait(string reason, string animation = null)
		{
		}

		internal void StopWaiting()
		{
		}

		public Activity Think(string thought = null, Action finishAction = null)
		{
			return null;
		}

		public bool IsFacingTowards(Actor other)
		{
			return false;
		}

		public override Vector3 GetStatusIconPosition(bool worldSpace = false)
		{
			return default(Vector3);
		}

		public GameObject InstantiateParticleEffect(GameObject effect)
		{
			return null;
		}

		public string GetLocationNameKey()
		{
			return null;
		}

		public override void SaveState(IDataStore data)
		{
		}

		public override void RestoreState(IDataStore data)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override bool StartDropInventoryJob()
		{
			return false;
		}

		public void ArrivedAt(Prop prop)
		{
		}

		public void LeftProp(Prop prop)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public Transform GetSelectionHighlightTransform()
		{
			return null;
		}

		public override bool IsHighlighted()
		{
			return false;
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public void PlayCharacterEmote()
		{
		}

		public void PlayCharacterEmote(string phonetic)
		{
		}

		public override void PlaySoundEvent(string eventName)
		{
		}

		public void ApplyBasicRTPCValues()
		{
		}

		protected override void InitStatusIcon()
		{
		}

		protected Transform GetHeadBoneTransform()
		{
			return null;
		}

		public bool CanSee(GameObjectX gox, float maxDistance)
		{
			return false;
		}

		public IEnumerable<Room> GetValidRoomsForBehaviourName(string behaviour = null)
		{
			return null;
		}

		public IEnumerable<Room> GetValidRoomsForBehaviour(Behaviour behaviour = null)
		{
			return null;
		}

		public IEnumerable<Prop> GetValidPropsForBehaviourName(string behaviour = null)
		{
			return null;
		}

		public IEnumerable<Prop> GetValidPropsForBehaviour(ActorBehaviour behaviour = null)
		{
			return null;
		}

		public IEnumerable<T> GetValidPropsForBehaviour<T>(ActorBehaviour behaviour = null) where T : Prop
		{
			return null;
		}

		public IEnumerable<T> GetValidPropsForBehaviourName<T>(string behaviour = null) where T : Prop
		{
			return null;
		}

		public void TeleportActorIntoRoom(Room room)
		{
		}

		public void SpawnItemOnAP(GameObject obj, string childTransformName)
		{
		}

		public void StopLooking()
		{
		}

		protected override bool ShouldShowNameTag()
		{
			return false;
		}

		public override void MarkToDestroy()
		{
		}

		public bool CanReach(TileData tileData)
		{
			return false;
		}

		public void EnableCarrying(string animationParameter, GameObjectX gox)
		{
		}

		public void DisableAllCarrying()
		{
		}

		internal void DisableCarrying(string animationParameter, GameObjectX gox)
		{
		}

		public void StopCarrying(GameItem item)
		{
		}

		public void StartCarrying(GameItem item)
		{
		}

		public bool IsCarrying(GameItem item)
		{
			return false;
		}

		public void Carry(string prefabTypeIdentifier)
		{
		}

		public void Carry(GameObject gameObject)
		{
		}

		private void AttachToPickupBone(GameObject gameObject)
		{
		}

		public void AttachToPickupBoneTemporary(GameItem item)
		{
		}

		public void RemoveFromPickupBoneTemporary(GameItem item)
		{
		}

		public void RemoveTemporaryItemsFromPickupBone()
		{
		}

		public void StopCarry(string prefabTypeIdentifier)
		{
		}

		public void ResetRoot()
		{
		}

		internal virtual void RestartAI(bool withRestartAnimation = true)
		{
		}

		public void CrossFadeToIdle()
		{
		}

		protected override IEnumerable<string> GetAvailableAnimations(GameObjectX gox, string activity, AccessPoint ap = null, int position = -1, GameItem gameItem = null, AccessPoint tap = null)
		{
			return null;
		}

		private IEnumerable<string> GetAnimations(string activity, AccessPoint ap, int position, GameItem gameItem, string propType, string propTypeOverride, AnimationParameterTreeNode tree, string gameItemAnimationKeyOverride, AccessPoint tap)
		{
			return null;
		}

		private IEnumerable<string> GetAnimations(string activity, AccessPoint ap, int position, string gameItemVisualKey, string propType, AnimationParameterTreeNode tree, AccessPoint tap)
		{
			return null;
		}

		private AnimationParameterTreeNode FilterTraitsAnimationPreferencesAndRace(AnimationParameterTreeNode node)
		{
			return null;
		}

		private IEnumerable<string> FilterPropType(IEnumerable<string> anims, string propType)
		{
			return null;
		}

		private IEnumerable<string> ApplyAnimationFilters(IEnumerable<string> anims)
		{
			return null;
		}

		private IEnumerable<string> FilterPositionIndex(IEnumerable<string> anims, int positionIndex)
		{
			return null;
		}

		private IEnumerable<string> FilterRace(IEnumerable<string> anims)
		{
			return null;
		}

		private IEnumerable<string> FilterTraitVariants(IEnumerable<string> anims)
		{
			return null;
		}

		private IEnumerable<string> FilterAnimationPreference(IEnumerable<string> anims)
		{
			return null;
		}

		public string GetPickupParameter(GameItem toPickup)
		{
			return null;
		}

		private string GetPickupParameter(PrefabTypeIdentifier prefabTypeIdentifier)
		{
			return null;
		}

		private string GetCurrentPropType()
		{
			return null;
		}

		public string GetConsumeParameter(GameItem item, bool idle)
		{
			return null;
		}

		protected AnimationParameterTreeNode GetAnimationParameterTree(Type type = null)
		{
			return null;
		}

		protected virtual void FillAnimationParameters()
		{
		}

		private void FillAnimationParameters(AnimationParameterTreeNode node, IEnumerable<string> parameters)
		{
		}

		public void SetTargetIdleState(SubIdleStates state)
		{
		}

		public void UnsetTargetIdleState(SubIdleStates state)
		{
		}

		public void UpdateIdleState()
		{
		}

		public void SetBaseEmotionalState(EmotionalState state)
		{
		}

		public void SetEmotionalStateOverride(EmotionalState state)
		{
		}

		private void SetEmotionalStateInternal(EmotionalState state)
		{
		}

		private void UpdateEmotionalState()
		{
		}

		private void UpdateEmotionalValue(ref float value, ref float step, float target, string animationParam, float delta)
		{
		}

		private static (float, float) GetEmotionalStateTargetValues(EmotionalState state)
		{
			return default((float, float));
		}

		public void CheckCarryingHand()
		{
		}

		public void DisableSittingParameters()
		{
		}

		public void DisableParametersForWalking()
		{
		}

		internal void OnConsumeItem(object source, Ingredient item)
		{
		}

		protected void RaiseActorArrived(object source, Prop prop)
		{
		}

		internal void RaiseActorUseProp(object source, Prop prop)
		{
		}

		protected void RaiseActorLeft(object source, Prop prop)
		{
		}

		internal static void RaiseActorEnteringTavern(object source, Actor actor)
		{
		}

		internal static void RaiseActorLeavingTavern(object source, Actor actor)
		{
		}

		internal static void RaiseActorSpawned(object source, Actor actor)
		{
		}

		internal static void RaiseActorDespawned(object source, Actor actor)
		{
		}

		internal void RaiseManualInstructionGivenEvent()
		{
		}

		internal void RaiseSleepingStatusChangedEvent()
		{
		}

		internal void RaiseAttributeChangedEvent(ActorAttribute attribute)
		{
		}

		internal void RaiseWageChangedEvent()
		{
		}

		internal void RaiseCurrentRoleChanged()
		{
		}
	}
}

#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class ObjectInteraction : MustCallDestroy
	{
		private const string ExitNode = "Exit";

		private const string ExitFlag = "Exit";

		private const string AttachEvent = "Attach";

		private const string DetachEvent = "Detach";

		private const string ModifyEvent = "Modify";

		private readonly InteractionDefinition _definition;

		[DontSave]
		private FinanceManager _financeManager;

		[DontSave]
		private RoomItem _parentRoomItem;

		[DontSave]
		private bool _actorsHidden;

		private Character _reserved;

		private Character _interactor;

		private readonly List<Character> _waitingForInteraction;

		private bool _objectAttached;

		[DontSave]
		private Transform _prevRoot;

		[DontSave]
		private Transform _propSocket;

		private Vector3 _prevLocalPosition;

		private Quaternion _prevLocalRotation;

		private RuntimeAnimatorController _prevObjectAnimationGraph;

		private AnimatorSavedState _objectAnimatorSavedState;

		[DontSave]
		private List<AnimationParameterSync> _animationParameterSyncs;

		private bool _attributesModified;

		[DontSave]
		private List<GameObject> _additionalActors;

		[DontSave]
		private Transform _startSocket;

		private readonly string _startSocketName;

		private readonly string _particleEffectName;

		private float _financeMultiplier;

		private RoomItemReceptionComponent _receptionComponent;

		private Dictionary<string, int> _pendingVariables;

		private LookAtComponent _disabledLookAtComponent;

		public bool Valid
		{
			get
			{
				if (!ValidStartPosition)
				{
					return false;
				}
				SharedInstance<RoomItemState> validState = Definition.ValidState;
				if (validState != null && validState.Instance != null)
				{
					RoomItemStateComponent component = _parentRoomItem.GetComponent<RoomItemStateComponent>();
					if (component != null && !component.IsInState(validState.Instance))
					{
						return false;
					}
				}
				return true;
			}
		}

		public bool ValidStartPosition { get; set; }

		public string Name => _definition.Name;

		public Character Interactor => _interactor;

		public Character Reserved => _reserved;

		public Vector3 StartPosition
		{
			get
			{
				if (!(_startSocket != null))
				{
					return Vector3.zero;
				}
				return _startSocket.position;
			}
		}

		public Vector3 WorldStartPosition
		{
			get
			{
				if (_startSocket != null)
				{
					return Quaternion.Euler(0f, _parentRoomItem.WorldRotation, 0f) * _startSocket.position + _parentRoomItem.WorldPosition;
				}
				return _parentRoomItem.WorldPosition;
			}
		}

		public Quaternion StartRotation
		{
			get
			{
				if (!(_startSocket != null))
				{
					return Quaternion.identity;
				}
				return _startSocket.rotation;
			}
		}

		public float WorldStartRotation
		{
			get
			{
				if (_startSocket != null)
				{
					return _startSocket.rotation.eulerAngles.y + _parentRoomItem.WorldRotation;
				}
				return _parentRoomItem.WorldRotation;
			}
		}

		public InteractionAttributeModifier.Type Type => _definition.Type;

		private Animator ObjectAnimator
		{
			get
			{
				if (_parentRoomItem.Visual == null)
				{
					return null;
				}
				return _parentRoomItem.Visual.Animator;
			}
		}

		public RoomItem ParentRoomItem => _parentRoomItem;

		public bool DestroyOnFinish { private get; set; }

		public InteractionDefinition Definition => _definition;

		public List<Character> Queue
		{
			get
			{
				if (_receptionComponent == null)
				{
					return _waitingForInteraction;
				}
				return _receptionComponent.Queue;
			}
		}

		public string StartSocketName => _startSocketName;

		public override string ToString()
		{
			return $"<b>{_definition.Name}</b> ({_parentRoomItem} - {_startSocketName})";
		}

		public ObjectInteraction(RoomItem roomItem, InteractionDefinition definition, string startSocket, string particleEffectName, FinanceManager financeManager)
		{
			_definition = definition;
			_startSocketName = startSocket;
			_particleEffectName = particleEffectName;
			_parentRoomItem = roomItem;
			_financeManager = financeManager;
			_waitingForInteraction = new List<Character>();
			_animationParameterSyncs = new List<AnimationParameterSync>();
			_pendingVariables = new Dictionary<string, int>();
			_startSocket = GetSocket(_parentRoomItem.Prefab.transform, _startSocketName);
			if (Definition.Name == "CheckIn")
			{
				_receptionComponent = _parentRoomItem.GetComponent<RoomItemReceptionComponent>();
			}
		}

		public void RestoreFromSave(FinanceManager financeManager, RoomItem parentRoomItem)
		{
			_financeManager = financeManager;
			_parentRoomItem = parentRoomItem;
			_startSocket = GetSocket(_parentRoomItem.Prefab.transform, _startSocketName);
			_animationParameterSyncs = new List<AnimationParameterSync>();
			if (_pendingVariables == null)
			{
				_pendingVariables = new Dictionary<string, int>();
			}
			if (_reserved != null && _reserved.IsOrphaned())
			{
				Level level = _reserved.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					_reserved.Level.CharacterManager.DestroyOrphan(_reserved);
					_reserved = null;
				});
			}
			if (_interactor != null && _interactor.IsOrphaned())
			{
				Level level2 = _interactor.Level;
				level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, (Action)delegate
				{
					_interactor.Level.CharacterManager.DestroyOrphan(_interactor);
					_interactor = null;
				});
			}
			if (_disabledLookAtComponent != null && _disabledLookAtComponent.GetOwner() == null)
			{
				_disabledLookAtComponent.Destroy();
				_disabledLookAtComponent = null;
			}
		}

		public void SetActorsHidden(bool hidden)
		{
			if (_actorsHidden != hidden)
			{
				_actorsHidden = hidden;
				SetActorsHiddenInternal(_actorsHidden);
			}
		}

		private void SetActorsHiddenInternal(bool hidden)
		{
			List<Renderer> list = new List<Renderer>();
			foreach (GameObject additionalActor in _additionalActors)
			{
				additionalActor.GetComponentsInChildren(includeInactive: true, list);
				foreach (Renderer item in list)
				{
					item.enabled = !hidden;
				}
			}
		}

		public void RestoreCurrentInteraction(AnimatorSavedState savedState)
		{
			if (_interactor == null)
			{
				return;
			}
			if (HasCharacterInteraction())
			{
				_interactor.AnimationEventListener.RegisterEvent("Attach", AttachObject);
				_interactor.AnimationEventListener.RegisterEvent("Detach", DetachObject);
				_interactor.AnimationEventListener.RegisterEvent("Modify", ApplyAttributeModifiers);
			}
			Animator masterAnimator = (Definition.SyncParametersFromObject ? ObjectAnimator : _interactor.Animator);
			Animator slaveAnimator = (Definition.SyncParametersFromObject ? _interactor.Animator : ObjectAnimator);
			if (_definition.UseObjectParameterSync)
			{
				CreateAnimationParameterSync(masterAnimator, slaveAnimator, sync: false);
			}
			CreateAdditionalActors(_interactor);
			if (_interactor.Animator != null && _interactor.Animator.runtimeAnimatorController != null)
			{
				foreach (GameObject additionalActor in _additionalActors)
				{
					Animator componentInChildren = additionalActor.GetComponentInChildren<Animator>();
					if (componentInChildren != null)
					{
						savedState.Restore(componentInChildren);
					}
				}
			}
			if (_objectAttached)
			{
				_objectAttached = false;
				AttachObject();
			}
		}

		public override void Destroy()
		{
			if (_interactor != null)
			{
				EndInteraction(_interactor);
			}
			else if (_reserved != null)
			{
				FreeInteraction(_reserved);
			}
			base.Destroy();
		}

		public bool IsRoomDoorInteraction()
		{
			if (ParentRoomItem != null)
			{
				return ParentRoomItem.Definition.ItemType == RoomItemDefinition.Type.Door;
			}
			return false;
		}

		public bool IsAvailable(Character character)
		{
			if (Definition.Deprecated)
			{
				return false;
			}
			if (character.DisallowInteractions)
			{
				return false;
			}
			if (_parentRoomItem.Visual != null && _parentRoomItem.Definition.SingleInteractor && _parentRoomItem.IsAnyoneInteracting(character))
			{
				return false;
			}
			if (_definition.Exclusive && (_parentRoomItem.HasAnyoneReservedInteraction(_definition.Name, character) || _parentRoomItem.HasAnyoneReservedInteractionSocket(_startSocketName, character)))
			{
				return false;
			}
			if ((Type == InteractionAttributeModifier.Type.Maintain || Type == InteractionAttributeModifier.Type.Upgrade) && _parentRoomItem.IsAnyoneInteracting(character))
			{
				return false;
			}
			if (_parentRoomItem.IsBeingRepaired(character))
			{
				return false;
			}
			if (_reserved == null || _reserved == character)
			{
				return true;
			}
			if (_interactor != null && _interactor != character)
			{
				return false;
			}
			float num = WorldStartPosition.SquareDistance2D(character.Position);
			float num2 = WorldStartPosition.SquareDistance2D(_reserved.Position);
			if (_receptionComponent != null && num2 < MathUtils.Square(GameAlgorithms.Config.MaxQueueDistance) && num < MathUtils.Square(GameAlgorithms.Config.MaxQueueDistance))
			{
				int queuePosition = _receptionComponent.GetQueuePosition(character);
				int queuePosition2 = _receptionComponent.GetQueuePosition(_reserved);
				return queuePosition < queuePosition2;
			}
			return num < num2;
		}

		public void ReserveInteraction(Character character)
		{
			if (character.Interaction != null && character.Interaction != this)
			{
				Logging.Error(LogChannels.Interaction, "{0} trying to reserve {1} when they're already interacting with {2}", character, this, character.Interaction);
			}
			if (_reserved != null && _reserved != character)
			{
				Character reserved = _reserved;
				FreeInteraction(reserved);
			}
			_reserved = character;
			character.ReservedInteraction = this;
		}

		public void FreeInteraction(Character character)
		{
			if (_reserved != null && _reserved != character)
			{
				Logging.Error(LogChannels.Interaction, "{0} trying to free interaction {1} when they haven't reserved it! {2} has reservation", character, this, _reserved);
			}
			else
			{
				_reserved = null;
				character.ReservedInteraction = null;
				EnableLookAt();
			}
		}

		public bool IsInteracting(Character character)
		{
			if (character == _interactor)
			{
				return character.Interaction == this;
			}
			return false;
		}

		private RuntimeAnimatorController GetAnimGraphForCharacter(Character character)
		{
			if (_definition.AnimGraphsAlternate != null && _definition.AnimGraphsAlternate.Length != 0)
			{
				CustomisationOption customisationOption = character.Visual.CustomisationOption;
				if ((object)customisationOption != null && customisationOption.UseAlternateInteractionAnimGraphs)
				{
					return character.FindAnimationGraph(ref _definition.AnimGraphsAlternate);
				}
			}
			return character.FindAnimationGraph(ref _definition.AnimGraphs);
		}

		private RuntimeAnimatorController GetAnimGraphForObject(Character character)
		{
			RuntimeAnimatorController runtimeAnimatorController = character.FindAnimationGraph(ref _definition.ObjectAnimGraphEx, returnNullOnFailure: true);
			if (runtimeAnimatorController != null)
			{
				return runtimeAnimatorController;
			}
			if (_definition.ObjectAnimGraphAlternate != null)
			{
				CustomisationOption customisationOption = character.Visual.CustomisationOption;
				if ((object)customisationOption != null && customisationOption.UseAlternateInteractionAnimGraphs)
				{
					return _definition.ObjectAnimGraphAlternate;
				}
			}
			return _definition.ObjectAnimGraph;
		}

		public bool StartInteraction(Character character)
		{
			if (_reserved != character)
			{
				Logging.Error(LogChannels.Interaction, "{0} trying to start interaction for {1} without reservation", character, this);
				return false;
			}
			if (_interactor != null && _interactor != character)
			{
				Logging.Error(LogChannels.Interaction, "{0} trying to start interaction for {1} when {2} is already interacting", character, this, _interactor);
				return false;
			}
			if (_interactor == character)
			{
				return true;
			}
			if (HasCharacterInteraction())
			{
				RuntimeAnimatorController animGraphForCharacter = GetAnimGraphForCharacter(character);
				character.PushAnimationGraph(animGraphForCharacter, 0.25f);
				if (Definition.DisableLookAt)
				{
					_disabledLookAtComponent = character.GetComponent<LookAtComponent>();
					if (_disabledLookAtComponent != null)
					{
						_disabledLookAtComponent.SetEnabled(enabled: false);
					}
				}
				if (Definition.DisableNavAgent)
				{
					character.NavPath.RemoveFromNavWorld();
				}
				character.AnimationEventListener.RegisterEvent("Attach", AttachObject);
				character.AnimationEventListener.RegisterEvent("Detach", DetachObject);
				character.AnimationEventListener.RegisterEvent("Modify", ApplyAttributeModifiers);
				SetVariables(character.Animator);
			}
			if (HasObjectInteraction())
			{
				RuntimeAnimatorController animGraphForObject = GetAnimGraphForObject(character);
				_prevObjectAnimationGraph = _parentRoomItem.Visual.AnimationGraph;
				_objectAnimatorSavedState = new AnimatorSavedState(_parentRoomItem.Visual.Animator);
				_parentRoomItem.Visual.AnimationGraph = animGraphForObject;
				ObjectAnimator.Rebind();
				if (_parentRoomItem.Definition.InteractionsAlwayAnimate)
				{
					_parentRoomItem.Visual.Animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
				}
				SetVariables(_parentRoomItem.Visual.Animator);
			}
			Animator masterAnimator = (Definition.SyncParametersFromObject ? ObjectAnimator : character.Animator);
			Animator slaveAnimator = (Definition.SyncParametersFromObject ? character.Animator : ObjectAnimator);
			if (_definition.UseObjectParameterSync)
			{
				CreateAnimationParameterSync(masterAnimator, slaveAnimator, sync: true);
			}
			CreateAdditionalActors(character);
			_interactor = character;
			character.Interaction = this;
			_attributesModified = false;
			if (!Definition.DisableNavAgent)
			{
				character.NavPath.BecomeKinematic();
			}
			if (_definition.Type != InteractionAttributeModifier.Type.Maintain || _parentRoomItem.MaintenanceLevel == null)
			{
				_financeMultiplier = 1f;
			}
			else
			{
				_financeMultiplier = _parentRoomItem.MaintenanceLevel.Value() / 100f;
			}
			EnableParticleEffect(enable: true);
			_parentRoomItem.OnInteractionStarted.InvokeSafe(character);
			_pendingVariables.Clear();
			return true;
		}

		private void CreateAnimationParameterSync(Animator masterAnimator, Animator slaveAnimator, bool sync)
		{
			if (masterAnimator != null && slaveAnimator != null)
			{
				AnimationParameterSync animationParameterSync = masterAnimator.gameObject.AddComponent<AnimationParameterSync>();
				AnimationParameterSync animationParameterSync2 = slaveAnimator.gameObject.AddComponent<AnimationParameterSync>();
				animationParameterSync.Setup(masterAnimator, slaveAnimator, sync);
				animationParameterSync2.Setup(masterAnimator, slaveAnimator, sync);
				_animationParameterSyncs.Add(animationParameterSync);
				_animationParameterSyncs.Add(animationParameterSync2);
			}
		}

		private void CreateAdditionalActors(Character parent)
		{
			if (_definition.Extras == null)
			{
				return;
			}
			Animator animator = parent.Animator;
			Transform transform = parent.GameObject.transform;
			_additionalActors = new List<GameObject>();
			AdditionalActor[] extras = _definition.Extras;
			foreach (AdditionalActor additionalActor in extras)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(additionalActor._prefab);
				if (additionalActor._animGraph != null)
				{
					Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
					if (componentInChildren != null)
					{
						componentInChildren.runtimeAnimatorController = additionalActor._animGraph;
						CreateAnimationParameterSync(animator, componentInChildren, sync: true);
					}
					else
					{
						Logging.Error(LogChannels.Interaction, "{0} expects additional actor to have an Animator component", this);
					}
				}
				gameObject.transform.position = transform.position;
				gameObject.transform.rotation = transform.rotation;
				gameObject.transform.localScale = transform.localScale;
				_additionalActors.Add(gameObject);
			}
		}

		public void RequestExit()
		{
			if (_interactor != null)
			{
				if (HasCharacterInteraction() && _interactor.Animator.HasParameter("Exit"))
				{
					_interactor.Animator.SetBool("Exit", value: true);
				}
				if (HasObjectInteraction() && ObjectAnimator.HasParameter("Exit"))
				{
					ObjectAnimator.SetBool("Exit", value: true);
				}
			}
		}

		public bool HasFinished()
		{
			if (_interactor == null)
			{
				return true;
			}
			bool flag = false;
			if (!HasObjectInteraction())
			{
				flag = true;
			}
			else
			{
				RuntimeAnimatorController animGraphForObject = GetAnimGraphForObject(_interactor);
				RuntimeAnimatorController runtimeAnimatorController = ObjectAnimator.runtimeAnimatorController;
				if (runtimeAnimatorController == null || runtimeAnimatorController != animGraphForObject || ObjectAnimator.IsInState("Exit"))
				{
					flag = true;
				}
				if (!ObjectAnimator.HasParameter("Exit"))
				{
					flag = true;
				}
			}
			bool flag2 = !HasCharacterInteraction() || _interactor.Animator.IsInState("Exit");
			return flag && flag2;
		}

		private bool HasCharacterInteraction()
		{
			if (_definition.AnimGraphs != null)
			{
				return _definition.AnimGraphs.Length != 0;
			}
			return false;
		}

		private bool HasObjectInteraction()
		{
			if (_definition.ObjectAnimGraph != null)
			{
				return ObjectAnimator != null;
			}
			return false;
		}

		public void EndInteraction(Character character)
		{
			EndInteractionInner(character, characterDestroyed: false, interrupted: false);
		}

		public void InterruptInteraction(Character character, bool characterDestroyed)
		{
			EndInteractionInner(character, characterDestroyed, interrupted: true);
		}

		private void EndInteractionInner(Character character, bool characterDestroyed, bool interrupted)
		{
			if (_interactor == null || (_interactor != null && _interactor != character))
			{
				Logging.Error(LogChannels.Interaction, "{0} trying to end interaction {1} when not interacting", character, this);
			}
			else
			{
				if (!characterDestroyed && !interrupted)
				{
					character.OnCharacterUsedItem(ParentRoomItem);
				}
				if (!characterDestroyed && !_attributesModified && !interrupted)
				{
					ApplyAttributeModifiers();
				}
				FreeInteraction(character);
				DetachObject();
				_animationParameterSyncs.ClearAndDestroy();
				_additionalActors.ClearAndDestroy();
				EnableParticleEffect(enable: false);
				if (DestroyOnFinish && !interrupted)
				{
					_interactor = null;
					_prevObjectAnimationGraph = null;
					_objectAnimatorSavedState = null;
					if (_parentRoomItem != null && !_parentRoomItem.HasBeenDestroyed())
					{
						character.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_parentRoomItem);
					}
				}
				else
				{
					if (_parentRoomItem != null && HasObjectInteraction() && _objectAnimatorSavedState != null)
					{
						if (_parentRoomItem.Definition.InteractionsAlwayAnimate)
						{
							_parentRoomItem.Visual.Animator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
						}
						_parentRoomItem.Visual.AnimationGraph = _prevObjectAnimationGraph;
						_objectAnimatorSavedState.Restore(_parentRoomItem.Visual.Animator);
						_prevObjectAnimationGraph = null;
						_objectAnimatorSavedState = null;
						if (_parentRoomItem.Visual.GameObject != null)
						{
							RoomItemMaintenanceVisualComponent component = _parentRoomItem.Visual.GameObject.GetComponent<RoomItemMaintenanceVisualComponent>();
							if (component != null)
							{
								component.MaintenanceLevelChanged(_parentRoomItem.MaintenanceLevel.Value());
							}
						}
					}
					if (_parentRoomItem != null && Definition.EndState.NotNull())
					{
						_parentRoomItem.GetComponent<RoomItemStateComponent>()?.SetState(Definition.EndState.Instance);
					}
				}
				_interactor = null;
				character.Interaction = null;
				if (HasCharacterInteraction())
				{
					if (!characterDestroyed)
					{
						RuntimeAnimatorController animGraphForCharacter = GetAnimGraphForCharacter(character);
						character.PopAnimationGraph(animGraphForCharacter, interrupted ? 0f : 0.25f);
						if (interrupted && _parentRoomItem != null)
						{
							character.Position = WorldStartPosition;
						}
					}
					if (Definition.DisableNavAgent)
					{
						character.NavPath.PutBackInNavWorld();
					}
					character.AnimationEventListener.UnregisterEvent("Attach", AttachObject);
					character.AnimationEventListener.UnregisterEvent("Detach", DetachObject);
					character.AnimationEventListener.UnregisterEvent("Modify", ApplyAttributeModifiers);
				}
				if (!Definition.DisableNavAgent)
				{
					character.NavPath.StopBeingKinematic();
				}
			}
			EnableLookAt();
		}

		public void EnableLookAt()
		{
			if (_disabledLookAtComponent != null)
			{
				if (!_disabledLookAtComponent.HasBeenDestroyed())
				{
					_disabledLookAtComponent.SetEnabled(enabled: true);
				}
				_disabledLookAtComponent = null;
			}
		}

		private Transform GetSocket(Transform obj, string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			return obj.FindChildRecursively(name);
		}

		private Transform GetCharacterAttachSocket(Character character, InteractionDefinition.Socket socket)
		{
			return socket switch
			{
				InteractionDefinition.Socket.LeftHand => character.Visual.LeftSocket, 
				InteractionDefinition.Socket.RightHand => character.Visual.RightSocket, 
				_ => null, 
			};
		}

		private void AttachObject(AnimationEvent animationEvent = null)
		{
			if (_objectAttached)
			{
				return;
			}
			Transform characterAttachSocket = GetCharacterAttachSocket(_interactor, _definition.SocketAttach);
			if (characterAttachSocket != null)
			{
				_propSocket = GetSocket(_parentRoomItem.Visual.GameObject.transform, _definition.SocketProp);
				if (_propSocket != null)
				{
					_prevRoot = _propSocket.parent;
					_prevLocalPosition = _propSocket.localPosition;
					_prevLocalRotation = _propSocket.localRotation;
					_propSocket.localPosition = Vector3.zero;
					_propSocket.localRotation = Quaternion.identity;
					_propSocket.SetParent(characterAttachSocket, worldPositionStays: false);
					_objectAttached = true;
				}
			}
		}

		private void DetachObject(AnimationEvent animationEvent = null)
		{
			if (_objectAttached && _prevRoot != null && _propSocket != null)
			{
				_propSocket.SetParent(_prevRoot, worldPositionStays: false);
				_propSocket.localPosition = _prevLocalPosition;
				_propSocket.localRotation = _prevLocalRotation;
				_prevRoot = null;
				_propSocket = null;
				_objectAttached = false;
			}
			_objectAttached = false;
		}

		private void ApplyAttributeModifiers(AnimationEvent animationEvent = null)
		{
			_attributesModified = true;
			if (_parentRoomItem.Definition.InteractionAttributeModifiers == null)
			{
				return;
			}
			InteractionAttributeModifier[] interactionAttributeModifiers = _parentRoomItem.Definition.InteractionAttributeModifiers;
			foreach (InteractionAttributeModifier interactionAttributeModifier in interactionAttributeModifiers)
			{
				if (interactionAttributeModifier._interactionType != _definition.Type || (!string.IsNullOrEmpty(interactionAttributeModifier._interactionName) && !(interactionAttributeModifier._interactionName == Name)))
				{
					continue;
				}
				CharacterAttributeModifier[] characterModifiers = interactionAttributeModifier._characterModifiers;
				foreach (CharacterAttributeModifier characterAttributeModifier in characterModifiers)
				{
					if (_interactor != null && characterAttributeModifier.Apply(_interactor))
					{
						_interactor.OnCharacterAttributeModified(characterAttributeModifier.Type);
					}
				}
				ObjectAttributeModifier[] objectModifiers = interactionAttributeModifier._objectModifiers;
				for (int j = 0; j < objectModifiers.Length; j++)
				{
					objectModifiers[j].Apply(_parentRoomItem);
				}
				if (interactionAttributeModifier._characterStatusEffects != null)
				{
					SharedInstance<CharacterStatusEffectDefinition>[] characterStatusEffects = interactionAttributeModifier._characterStatusEffects;
					foreach (SharedInstance<CharacterStatusEffectDefinition> sharedInstance in characterStatusEffects)
					{
						if (_interactor != null && _interactor.ModifiersComponent != null)
						{
							_interactor.ModifiersComponent.AddStatusEffect(sharedInstance.Instance);
						}
					}
				}
				SharedInstance<FinanceModifier> financeModifier = interactionAttributeModifier._financeModifier;
				if (_interactor != null && financeModifier != null && financeModifier.Instance != null)
				{
					_financeManager.ModifyBalanceFromObjectInteraction(_interactor, _parentRoomItem, financeModifier.Instance, _financeMultiplier);
				}
				CharacterAttributeModifier[] characterModifiersRandom = interactionAttributeModifier._characterModifiersRandom;
				if (characterModifiersRandom != null && characterModifiersRandom.Length != 0)
				{
					CharacterAttributeModifier characterAttributeModifier2 = characterModifiersRandom.RandomItem();
					if (_interactor != null)
					{
						characterAttributeModifier2.Apply(_interactor);
					}
				}
			}
		}

		public void ApplyCharacterInteractingAttributeModifiers(float deltaTime)
		{
			if (_parentRoomItem.Definition.InteractionAttributeModifiers == null)
			{
				return;
			}
			CharacterAttributes characterAttributes = _interactor.GetCharacterAttributes();
			InteractionAttributeModifier[] interactionAttributeModifiers = _parentRoomItem.Definition.InteractionAttributeModifiers;
			foreach (InteractionAttributeModifier interactionAttributeModifier in interactionAttributeModifiers)
			{
				if (interactionAttributeModifier._interactionType != _definition.Type || (!string.IsNullOrEmpty(interactionAttributeModifier._interactionName) && !(interactionAttributeModifier._interactionName == Name)) || interactionAttributeModifier._characterModifiersWhileInteracting == null)
				{
					continue;
				}
				CharacterAttributeModifier[] characterModifiersWhileInteracting = interactionAttributeModifier._characterModifiersWhileInteracting;
				foreach (CharacterAttributeModifier characterAttributeModifier in characterModifiersWhileInteracting)
				{
					AttributeFloat attribute = characterAttributes.GetAttribute(characterAttributeModifier.Type);
					if (attribute != null)
					{
						float attributeMultiplier = _interactor.GetAttributeMultiplier(characterAttributeModifier.Type);
						attribute.Modify(characterAttributeModifier.Amount() * deltaTime, attributeMultiplier);
					}
				}
			}
		}

		public void SetBool(string name, bool value)
		{
			if (HasCharacterInteraction() && _interactor.Animator.HasParameter(name))
			{
				_interactor.Animator.SetBool(name, value);
			}
			if (HasObjectInteraction() && ObjectAnimator.HasParameter(name))
			{
				ObjectAnimator.SetBool(name, value);
			}
		}

		public void SetTrigger(string name)
		{
			if (HasCharacterInteraction() && _interactor != null && _interactor.Animator.HasParameter(name))
			{
				_interactor.Animator.SetTrigger(name);
			}
			if (HasObjectInteraction() && ObjectAnimator.HasParameter(name))
			{
				ObjectAnimator.SetTrigger(name);
			}
		}

		public void WaitForInteraction(Character character)
		{
			if (_waitingForInteraction.AddUnique(character))
			{
				character.WaitingForInteraction = this;
			}
			if (_parentRoomItem.Definition.ShowQueuePositions)
			{
				character.Level.StatusIconManager.ShowStatusIcon(_parentRoomItem, StatusIcon.Type.StaffRequired);
			}
		}

		public void StopWaitingForInteraction(Character character)
		{
			if (_waitingForInteraction.Remove(character))
			{
				character.WaitingForInteraction = null;
			}
		}

		public int GetQueueLength()
		{
			return Queue.Count;
		}

		public bool QueueFull()
		{
			if (GetQueueLength() >= _definition.MaxQueue)
			{
				return true;
			}
			return false;
		}

		public int GetQueuePosition(Character character, bool includeInterator)
		{
			if (_receptionComponent != null)
			{
				return _receptionComponent.GetQueuePosition(character);
			}
			if (!includeInterator)
			{
				return _waitingForInteraction.IndexOf(character);
			}
			if (character == _interactor || character == _reserved)
			{
				return 0;
			}
			return _waitingForInteraction.IndexOf(character) + ((_interactor != null || _reserved != null) ? 1 : 0);
		}

		public int PositionToStandInQueue(Character character, bool includeInterator)
		{
			if (_receptionComponent != null)
			{
				return _receptionComponent.PositionToStandInQueue(character);
			}
			if (includeInterator)
			{
				if (character != _interactor && character != _reserved)
				{
					return _waitingForInteraction.IndexOf(character);
				}
				return 0;
			}
			return _waitingForInteraction.IndexOf(character);
		}

		public bool IsInQueue(Character character)
		{
			return GetQueuePosition(character, includeInterator: false) >= 0;
		}

		public void GetQueueTransform(Character character, int queuePosition, out Vector3 position, out float rotation)
		{
			Level level = character.Level;
			Room roomAtWorldCoord = level.WorldState.GetRoomAtWorldCoord(WorldStartPosition, includeHospital: true, includeClosedPlots: false);
			if (roomAtWorldCoord == null)
			{
				position = character.Position;
				rotation = character.RotationY;
				return;
			}
			FloorPlan floorPlan = roomAtWorldCoord.FloorPlan;
			Vector3 vector = -MathUtils.MakeDirectionVector(WorldStartRotation);
			rotation = WorldStartRotation;
			position = WorldStartPosition + (queuePosition + 1) * vector;
			if (queuePosition >= _definition.MaxQueue || !RoomAlgorithms.RoomContainsWorldCoord(floorPlan, position.ToGridCoord()) || !level.WorldState.NavMesh.IsValidLocation(position))
			{
				if (RoomAlgorithms.GetRandomFreeTileWithinRadius(floorPlan, WorldStartPosition + 2f * vector, 10f, out position))
				{
					position += RandomUtils.RandomXZVector(-0.25f, 0.25f);
					rotation = MathUtils.YawRotation(WorldStartPosition - position);
				}
				else if ((floorPlan.Definition._type == RoomDefinition.Type.Cafe || floorPlan.Definition._type == RoomDefinition.Type.Toilets) && RoomAlgorithms.GetRandomFreeTileWithinRadius(floorPlan.HospitalMap.FloorPlan, floorPlan.Door.WorldPosition, 10f, out position))
				{
					position += RandomUtils.RandomXZVector(-0.25f, 0.25f);
					rotation = MathUtils.YawRotation(WorldStartPosition - position);
				}
				else
				{
					position = character.Position;
					rotation = character.RotationY;
				}
			}
		}

		public bool CanInterrupt()
		{
			return _definition.CanInterrupt;
		}

		public void RefreshSockets()
		{
			_startSocket = GetSocket(_parentRoomItem.Prefab.transform, _startSocketName);
		}

		private void EnableParticleEffect(bool enable)
		{
			if (_parentRoomItem == null || _parentRoomItem.Visual == null || _parentRoomItem.Visual.GameObject == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(_particleEffectName))
			{
				ParticleEffectControlComponent component = _parentRoomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				if (component != null)
				{
					component.EnableEffect(_particleEffectName, enable);
				}
			}
			if (enable || Definition.GlobalParticleEffects.IsEmpty())
			{
				return;
			}
			ParticleEffectControlComponent component2 = _parentRoomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
			if (component2 != null)
			{
				string[] globalParticleEffects = Definition.GlobalParticleEffects;
				foreach (string effectName in globalParticleEffects)
				{
					component2.EnableEffect(effectName, enable: false);
				}
			}
		}

		public void AddPendingVariable(string parameter, int value)
		{
			if (_pendingVariables.ContainsKey(parameter))
			{
				_pendingVariables[parameter] = value;
			}
			else
			{
				_pendingVariables.Add(parameter, value);
			}
		}

		private void SetVariables(Animator animator)
		{
			if (!(animator != null))
			{
				return;
			}
			foreach (KeyValuePair<string, int> pendingVariable in _pendingVariables)
			{
				if (animator.HasParameter(pendingVariable.Key))
				{
					animator.SetInteger(pendingVariable.Key, pendingVariable.Value);
				}
			}
		}
	}
}

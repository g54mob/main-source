using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FIMSpace.AnimationTools;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	public class RagdollHandler : IRagdollAnimator2HandlerOwner
	{
		public enum EReferencePoseReport
		{
			NoReferencePose = 0,
			ReferencePoseOK = 1,
			ReferencePoseChanged = 2,
			ReferencePoseError = 3
		}

		public class OptimizationHandler
		{
			private RagdollHandler ragdollHandler;

			public OptimizationHandler(RagdollHandler ragdoll)
			{
				ragdollHandler = ragdoll;
			}

			public void TurnOffTick(float delta)
			{
				if (!(ragdollHandler.LODBlend <= 0f))
				{
					ragdollHandler.LODBlend = Mathf.MoveTowards(ragdollHandler.LODBlend, 0f, delta * 5f);
				}
			}

			public void TurnOnTick(float delta)
			{
				if (ragdollHandler.LODBlend < 1f)
				{
					ragdollHandler.LODBlend = Mathf.MoveTowards(ragdollHandler.LODBlend, 1f, delta * 4f);
				}
			}
		}

		public enum EAnimatingMode
		{
			[Tooltip("Turning off ragdoll animator calculations and turning off physical dummy so it will not react with physical objects on the scene.\nDoes the same thing as setting ragdollAnimator.enabled = false")]
			Off = 0,
			[Tooltip("Ragdoll animator mode for full body animation matching, but attached with its main bone to the animated character pose.")]
			Standing = 1,
			[Tooltip("Unlocked main physical bone and letting it fall on the ground with the rest of the body.")]
			Falling = 2,
			[Tooltip("Ragdoll will fall on the ground and turn itself off (and set kinematic) when dummy stops falling and moving.")]
			Sleep = 3
		}

		public enum ERagdollNoLimitAngles
		{
			AllLimits = 0,
			NoLimitsOnStandingMode = 1,
			NoLimits = 2
		}

		[HideInInspector]
		public int _Editor_SelectedChain = -1;

		[HideInInspector]
		public EBoneChainCategory _Editor_ChainCategory;

		private bool afterForcing;

		private Vector3? _providedAnchorVelocity;

		private Vector3 _motionInfluenceOffset;

		private Vector3 _lastFixedPosition;

		protected List<RA2AttachableObject> attachables = new List<RA2AttachableObject>();

		private Dictionary<Transform, Transform> _helperAttachableGeneratingDictionary;

		private RagdollChainBone _playmodeAnchorBone;

		public RagdollPose StoredReferenceTPose = new RagdollPose();

		internal readonly Dictionary<string, RagdollChainBone> nameTransformBoneDictionary = new Dictionary<string, RagdollChainBone>();

		internal readonly Dictionary<Transform, RagdollChainBone> physicalTransformBoneDictionary = new Dictionary<Transform, RagdollChainBone>();

		internal readonly Dictionary<Transform, RagdollChainBone> animatorTransformBoneDictionary = new Dictionary<Transform, RagdollChainBone>();

		internal readonly List<Transform> allBonesList = new List<Transform>();

		internal readonly Dictionary<ERagdollBoneID, RagdollChainBone> boneIDDictionary = new Dictionary<ERagdollBoneID, RagdollChainBone>();

		private bool wasEnsuredCollisionsIgnore;

		[Tooltip("Can be used to switch using all added extra features ON or OFF")]
		public bool UseExtraFeatures = true;

		public List<RagdollAnimatorFeatureHelper> ExtraFeatures = new List<RagdollAnimatorFeatureHelper>();

		private List<Action> OnFallModeSwitchActions = new List<Action>();

		private List<Action> AlwaysUpdateActions = new List<Action>();

		private List<Action> UpdateActions = new List<Action>();

		private List<Action> PreLateUpdateActions = new List<Action>();

		private List<Action> LateUpdateActions = new List<Action>();

		private List<Action> PostLateUpdateActions = new List<Action>();

		private List<Action> FixedUpdateActions = new List<Action>();

		private List<Action<RA2BoneCollisionHandler, Collision>> OnCollisionEnterActions = new List<Action<RA2BoneCollisionHandler, Collision>>();

		private List<Action<RA2BoneTriggerCollisionHandler, Collider>> OnTriggerEnterActions = new List<Action<RA2BoneTriggerCollisionHandler, Collider>>();

		[Tooltip("Helper information for a few algorithms, to call methods with humanoid / quadruped in mind")]
		[HideInInspector]
		public bool IsHumanoid = true;

		[SerializeField]
		[HideInInspector]
		private Transform dummyContainer;

		[SerializeField]
		[HideInInspector]
		internal List<RagdollChainBone.InBetweenBone> inBetweenPreGenerateMemory;

		internal Dictionary<Transform, RagdollChainBone.InBetweenBone> skeletonFillExtraBones;

		[SerializeField]
		[HideInInspector]
		internal List<RagdollChainBone.InBetweenBone> skeletonFillExtraBonesList;

		private bool wasInReconstructionMode;

		protected bool _dummyIndicatorsWasPrepared;

		protected bool _sourceIndicatorsWasPrepared;

		[Tooltip("Multiplier for springs, springs damping, hard matching and few other forces responsible for physical animation matching.\nCall User_UpdateJointsPlayParameters() after changing this variable.")]
		[Range(0f, 1f)]
		public float MusclesPower = 1f;

		internal float musclesPowerMultiplier = 1f;

		[Tooltip("Main unity's joints spring drive value towards desired pose when using animation matching")]
		public float SpringsValue = 1500f;

		[Tooltip("Value for springs power when switching to Fall Mode from Standing Mode. Zero or lower means springs on fall will use main Springs Power Value.")]
		public float SpringsOnFall;

		public float? OverrideSpringsValueOnFall;

		[Tooltip("Main unity's joints damping value for animation matching springs")]
		public float DampingValue = 40f;

		[Tooltip("Damping Value when switching to fall mode")]
		public float DampingValueOnFall;

		[Tooltip("Forcing limbs to match with animator pose, can nicely help out animation matching. (It adds a bit cpu cost to the overall component performance, you can try debug button for insight)")]
		[Range(0f, 1f)]
		public float HardMatching;

		[Tooltip("Applying hard animation matching for ragdoll bone positions")]
		public bool HardMatchPositions;

		[Tooltip("Applying hard animation matching for ragdoll bone positions also during fall mode")]
		public bool HardMatchPositionsOnFall;

		[Tooltip("Use if you want to keep rotation hard matching stronger but position hard matching weaker")]
		public float PositionHardMatchingMultiplier = 1f;

		[Tooltip("Hard matching during falling mode is usually not needed, so you can switch it off or make it weaker then.")]
		[Range(0f, 1f)]
		public float HardMatchingOnFalling;

		[Tooltip("[Only for standing mode] Set zero to compensate body physics reaction on character body movement in world, set 1 to be affected with natural physics reaction to bones movement.")]
		[Range(0f, 1f)]
		public float MotionInfluence = 1f;

		internal bool disableHardMatching;

		internal bool disableInterpolation;

		internal bool onlyDiscreteDetection;

		[Range(0f, 1f)]
		[Tooltip("How strictly anchor bone (pelvis) should stick to its animator position when using Standing Animating mode")]
		public float AnchorBoneSpring = 1f;

		[NonSerialized]
		public float AnchorBoneSpringMultiplier = 1f;

		[Tooltip("When Anchor Bone Spring is set to the max, allowing to switch anchor rigidbody kinematic on standing mode, for max stability.\nIs Kinematic disables velocity memory on the rigidody, you can use anchor limit to maintain similar effect on the anchor but keep the velocity.")]
		public bool MakeAnchorKinematicOnMaxSpring;

		[Tooltip("With kinematic anchor, you can make character movement unaffected by physical forces")]
		public bool UnaffectedMovement;

		[Tooltip("(Standing mode) If anchor will get stuck far away from the main object, it will be teleported towards desired controlled position.")]
		public bool AutoUnstuck;

		[Tooltip("(Standing Mode) Freezing hips rigidbody rotation, so it will not be rotated due to collisions. It is actually solving anchor collision jitter in many cases.")]
		public bool LockAnchorRotation = true;

		[Tooltip("(has effect only with 'No Limits On Standing Mode') Enabling joint rotation limits for anchor bone. Can be used instead of kinematic anchor bone for more controlled stability.")]
		public bool AnchorJointLimits;

		[Tooltip("If Anchor Attach set to zero should be treated as fall mode")]
		public bool FallOnZeroAnchor = true;

		internal float anchorBoneSpringPositionMultiplier = 1f;

		private bool fixedInitialized;

		internal bool disableUpdating;

		private bool _wasDisableUpdating;

		private EAnimatingMode _lastAnimatingMode = (EAnimatingMode)(-1);

		private float delta = 0.001f;

		private float finalBlend = 1f;

		[NonSerialized]
		[Tooltip("Using gravity for the anchor bone during free fall")]
		public bool AnchorUseGravity = true;

		private EAnimatingMode _lastActionAnimatingState = (EAnimatingMode)(-1);

		private float _sleepDuration;

		private float _sleepStableTime;

		private bool _wasSleepDisable;

		private bool wasDummyDisabled;

		private float? user_overrideMusclesPower;

		[NonSerialized]
		public float CustomRagdollBlendMultiplier = 1f;

		protected float _sd_fadeIn;

		[Tooltip("Main transform of your character object. You can left it empty to treat this object as base transform. You can use it, when you want to add Ragdoll Animator to the object, which is not your character controller object (for example add it in child objects) then you can assign the character controller object here.")]
		public Transform BaseTransform;

		[Tooltip("Animator of the character (optional)")]
		public Animator Mecanim;

		[Tooltip("Enter on selected option to display its description as tooltip")]
		public ERagdollLogic RagdollLogic;

		[NonSerialized]
		public Transform HelperOwnerTransform;

		[Tooltip("Multiplicator value for all of the colliders")]
		[Range(0.1f, 2f)]
		public float RagdollSizeMultiplier = 1f;

		[Tooltip("Multiplicator value for colliders size excluding bone-forward axis")]
		[Range(0.1f, 2f)]
		public float RagdollThicknessMultiplier = 1f;

		[Tooltip("Value which is distributed over ragdoll bones rigidbodies as fractional value.")]
		public float ReferenceMass = 50f;

		[Tooltip("Target rigidbodies interpolation mode.")]
		public RigidbodyInterpolation RigidbodiesInterpolation = RigidbodyInterpolation.Interpolate;

		[Tooltip("Target rigidbodies collision detection mode.")]
		public CollisionDetectionMode RigidbodiesDetectionMode;

		[Tooltip("Reference value for rigidbodies Drag Parameter")]
		public float RigidbodyDragValue;

		[Tooltip("Reference value for rigidbodies Angular Drag Parameter")]
		public float RigidbodyAngularDragValue = 0.2f;

		[Tooltip("Reference value for Unity Joints rotation limit parameters. It can make change behaviour of unity physical joints.")]
		public float JointContactDistance;

		[Tooltip("Reference value for Unity Joints rotation limit parameters. It can make change behaviour of unity physical joints.")]
		public float JointBounciness;

		[Tooltip("Reference value for Unity Joints rotation limit parameters. It can make joint limit ranges softer.")]
		public float JointLimitSpring;

		[Tooltip("Reference value for Unity Joints rotation limit parameters. It can make joint limit ranges softer and slower.")]
		public float JointLimitDamper;

		[Tooltip("Joint's connected mass multiplier value, can help taming jiggle animation by lowering this value, but if bone chains are long, it can generate glitches when set too low!")]
		[Range(0f, 1.5f)]
		public float ConnectedMassMultiply = 0.5f;

		[Tooltip("Gives better falling animation feeling when set around value = 1")]
		[Range(0f, 1.5f)]
		public float MassMultiplyOnFalling = 1f;

		[Tooltip("Use to smooth change connected mass joints value instead of instant change.\n\nInstant change can produce issue on character get up action, when being pushed far away from initial position (unity physics glitch)")]
		public float ConnectedMassTransition;

		[Tooltip("Physical Material which will be applied to the generated colliders (not changing if set none)")]
		public PhysicMaterial CollidersPhysicMaterial;

		[Tooltip("Physical Material which will be applied to the generated colliders when switched to free fall (not changing on fall if set none)")]
		public PhysicMaterial PhysicMaterialOnFall;

		[Tooltip("(set zero to use deafault project value)\nIf you want to use 'Hard Matching' it's recommended to set this value higher.")]
		public float MaxAngularVelocity = 50f;

		[Tooltip("(set zero to use deafault project value)\nUse if you want to limit max force applied on the ragdoll bones. If in your game you use extreme forces on the bones, this can help you keep bone impacts more stable.")]
		public float MaxVelocity;

		[Tooltip("Disabling gravity on standing mode sometimes can give more stable motion.")]
		public bool NoGravityOnStanding;

		[Tooltip("(set zero to use deafault project value)\nIt should make overlapping colliders push-out move smoother.")]
		public float MaxDepenetrationVelocity;

		[Tooltip("Switching unity joint 'ProjectionMode' parameter for all ragdoll rigidbodies")]
		public JointProjectionMode ProjectionMode;

		[Tooltip("Switching unity joint 'UsePreProcessing' parameter for all ragdoll rigidbodies")]
		public bool PreProcessing;

		[Tooltip("Blend of applied physical pose on the main character skeleton.")]
		[FPD_Suffix(0f, 1f, FPD_SuffixAttribute.SuffixMode.From0to100, "%", true, 0)]
		public float RagdollBlend = 1f;

		[Tooltip("Type of main behaviour for the component. Check tooltips of each state for description.")]
		[SerializeField]
		protected EAnimatingMode animatingMode = EAnimatingMode.Standing;

		private bool animatingModeChanged;

		[Tooltip("Can increase precision of animation matching.\nTurning on using extra joints on chain-skipped bones and dummy bones without direct connection with parent bones. It will make physics cost a bit more and can generate GC when switching AnimatingState from 'Standing' mode to other.")]
		public bool UseReconstruction;

		[Range(1f, 24f)]
		[Tooltip("Quality of unity physical iterations. Unity recommends value between 10-20 for ragdolls. Don't increase it too high if you use many ragdolls.")]
		public int UnitySolverIterations = 12;

		[Tooltip("It needs to be enabled if your character has no animations, otherwise character libs will fall on without muscles power.\nIf your character is animated all the time, turn it off to save some performance.")]
		public bool Calibrate = true;

		[Tooltip("If your animator have enabled 'AnimatePhysics' update mode, you should enable it here too (switches automatically if having assigned 'Mecanim' field)")]
		public bool AnimatePhysics;

		[Tooltip("If joints position changes in case of hard collisions, should the positions be applied also to the animator bones?")]
		public bool ApplyPositions;

		[Tooltip("Turning off all calculations when ragdoll blend is set to zero. It can cause jiggle when blend is greater than zero again.")]
		public bool OptimizeOnZeroBlend;

		[Tooltip("If generated ragdoll dummy object should not be visible in the scene view to make scene hierarchy cleaner")]
		public bool HideDummyInSceneView;

		[Tooltip("Checking ragdoll dummy bones colliders bounds and ignoring collisions between ones which are overlapping")]
		public bool IgnoreBoundedColliders = true;

		[Tooltip("Target layer for the generated ragdoll dummy object")]
		[FPD_Layers]
		public int RagdollDummyLayer;

		[Tooltip("Enable if you want to update character ragdoll animation in unscaled delta time (unaffected by Time.scale)")]
		public bool UnscaledTime;

		[Tooltip("Making ragdoll initialization / re-enabling, without model jiggle. (slider = fade time in seconds)\nIt is not triggered when switching back from Sleep animating mode")]
		[Range(0f, 1f)]
		public float FadeInAnimation;

		[Tooltip("Triggering Physics.IgnoreCollision between dummy colliders and on all colliders found in the source skeleton")]
		public bool IgnoreSourceSkeletonColliders = true;

		[Tooltip("To make default animation matching be precise, Ragdoll Animator needs to wait few fixed update frames, but if you use just hard matching settings, you can disable it to make first frames of ragdoll animator quicker.")]
		public bool WaitForInit = true;

		[Tooltip("If your animations are exceeding the physical joints rotation limits, making animation not possible to reach target pose when physics are ON, you can allow joints to rotate regardless the angle limits to improve animation matching a bit. So limits should be on when falling mode to prevent rotating joints in weird angles.")]
		public ERagdollNoLimitAngles AnimationMatchLimits = ERagdollNoLimitAngles.NoLimitsOnStandingMode;

		[Tooltip("Generated ragdoll dummy will be put inside this transform as child object.\n\nAssign main character object for ragdoll to react with character movement rigidbody motion, set other for no motion reaction.")]
		public Transform TargetParentForRagdollDummy;

		[HideInInspector]
		public float BoundedCollidersIgnoreScaleup = 1.2f;

		[Range(1f, 6f)]
		[Tooltip("Quality of unity rigidbody velocity iterations. 1 is default for unity projects.")]
		public int UnityVelocitySolverIterations;

		[Tooltip("If sleep mode should automatically disable mecanim unity animator on Ragdoll Animator disable during sleep mode.")]
		public bool DisableMecanimOnSleep = true;

		internal Coroutine _Coro_FadeMuscles;

		internal Coroutine _Coro_FadeMusclesMul;

		private readonly WaitForFixedUpdate _fixedWait = new WaitForFixedUpdate();

		internal Coroutine standUpCoroutine;

		private Vector3 _hipsFreezeUpdatePosition;

		private Vector3 _hipsFreezeActivePosition;

		private Quaternion _hipsFreezeUpdateRotation;

		private Quaternion _hipsFreezeActiveRotation;

		[NonSerialized]
		public bool LegsBlendInRequest;

		internal Coroutine _coro_legsBlendRequest;

		[SerializeField]
		private List<RagdollBonesChain> chains = new List<RagdollBonesChain>();

		private int fixedFramesElapsed;

		[SerializeField]
		[HideInInspector]
		private GameObject parentObject;

		private bool animatePhysics;

		private bool scheduledFixedUpdate = true;

		public Rigidbody AnchorParent { get; private set; }

		public List<RA2AttachableObject> Attachables => attachables;

		public RagdollChainBone GetAnchorBoneController
		{
			get
			{
				if (!WasInitialized)
				{
					return GetChain(ERagdollChainType.Core).BoneSetups[0];
				}
				return _playmodeAnchorBone;
			}
		}

		public bool DummyWasGenerated => Dummy_Container != null;

		public Transform Dummy_Container
		{
			get
			{
				return dummyContainer;
			}
			private set
			{
				dummyContainer = value;
			}
		}

		public RagdollAnimatorDummyReference DummyReference { get; private set; }

		public List<RagdollChainBone.InBetweenBone> SkeletonFillExtraBonesList => skeletonFillExtraBonesList;

		public float targetMusclesPower { get; private set; } = 1f;

		internal float GetCurrentMainSpringsValue
		{
			get
			{
				if (!IsInFallingMode)
				{
					return SpringsValue;
				}
				if (!(SpringsOnFall <= 0f))
				{
					return SpringsOnFall;
				}
				return SpringsValue;
			}
		}

		public float AnchorBoneAttach
		{
			get
			{
				return AnchorBoneSpring * AnchorBoneSpringMultiplier;
			}
			set
			{
				AnchorBoneSpring = value;
			}
		}

		public float Delta => delta;

		public float? User_OverrideMusclesPower
		{
			get
			{
				return user_overrideMusclesPower;
			}
			set
			{
				user_overrideMusclesPower = value;
				CalculateRagdollBlend();
				User_UpdateJointsPlayParameters(reset: false);
			}
		}

		public int ForcingKinematicAnchor { get; private set; }

		public float LODBlend { get; protected set; } = 1f;

		public float StandUpTransitionBlend { get; protected set; } = 1f;

		public float LastStandingModeAtTime { get; protected set; } = -1f;

		internal float FadeInBlend { get; private set; } = 1f;

		public bool InstantConnectedMassChange => ConnectedMassTransition <= 0f;

		public EAnimatingMode AnimatingMode
		{
			get
			{
				return animatingMode;
			}
			set
			{
				if (value != animatingMode)
				{
					animatingMode = value;
					animatingModeChanged = true;
					OnAnimatingModeChange();
				}
			}
		}

		public bool IsInStandingMode
		{
			get
			{
				if (AnimatingMode == EAnimatingMode.Standing)
				{
					if (FallOnZeroAnchor)
					{
						if (FallOnZeroAnchor)
						{
							return AnchorBoneSpring > 0f;
						}
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsInFallingMode
		{
			get
			{
				if (AnimatingMode == EAnimatingMode.Standing)
				{
					if (FallOnZeroAnchor)
					{
						return AnchorBoneSpring <= 0f;
					}
					return false;
				}
				return true;
			}
		}

		public bool IsFallingOrSleep
		{
			get
			{
				if (!IsInFallingMode)
				{
					return AnimatingMode == EAnimatingMode.Sleep;
				}
				return true;
			}
		}

		internal Vector3 anchorToRootLocal { get; private set; } = Vector3.zero;

		internal Quaternion anchorToRootLocalRot { get; private set; } = Quaternion.identity;

		public bool IsStandUpCoroutineRunning { get; private set; }

		public bool GetUpCall_StandingRestore { get; private set; }

		RagdollHandler IRagdollAnimator2HandlerOwner.GetRagdollHandler => this;

		public List<RagdollBonesChain> Chains => chains;

		public bool WasInitialized { get; private set; }

		public MonoBehaviour Caller { get; private set; }

		public GameObject ParentObject => ParentObject;

		public bool WasPreGeneratedDummy { get; private set; }

		public float CalculateScaleReferenceValue()
		{
			float result = 1f;
			Transform anchorSourceBone = GetAnchorSourceBone();
			if ((bool)anchorSourceBone)
			{
				Transform parent = anchorSourceBone.parent;
				while (parent != null && !((parent.position - anchorSourceBone.position).sqrMagnitude > 0.05f))
				{
					parent = parent.parent;
				}
				if (parent != null)
				{
					return Vector3.Distance(parent.position, anchorSourceBone.position);
				}
			}
			return result;
		}

		private void FixedUpdateAnchorBone()
		{
			RagdollChainBone playmodeAnchorBone = _playmodeAnchorBone;
			UpdateAnchorParent();
			RefreshAnchorKinematicState();
			if (AnimatingMode != EAnimatingMode.Standing)
			{
				return;
			}
			if (!playmodeAnchorBone.GameRigidbody.isKinematic)
			{
				float num = AnchorBoneSpring * AnchorBoneSpringMultiplier;
				if (AutoUnstuck && num > 0f && Time.unscaledTime - LastStandingModeAtTime > 0.1f)
				{
					float num2 = _playmodeAnchorBone.MainBoneCollider.bounds.size.magnitude * 1f;
					if (Vector3.Distance(playmodeAnchorBone.GameRigidbody.position, playmodeAnchorBone.BoneProcessor.AnimatorPosition) > num2)
					{
						ForcingKinematicAnchor = 2;
					}
				}
				if (!(num > 0f))
				{
					return;
				}
				float num3 = Mathf.LerpUnclamped(0f, 1f, num);
				float num4 = 1f - num3;
				num4 *= num4;
				num4 = 1f - num4;
				float forceMultiply = num4;
				playmodeAnchorBone.BoneProcessor.UpdateFixedPositionDelta();
				if (LockAnchorRotation)
				{
					playmodeAnchorBone.GameRigidbody.rotation = Quaternion.Slerp(playmodeAnchorBone.GameRigidbody.rotation, playmodeAnchorBone.BoneProcessor.AnimatorRotation, Time.fixedDeltaTime * 60f);
				}
				else
				{
					playmodeAnchorBone.GameRigidbody.AddRigidbodyTorqueToRotateTowards(playmodeAnchorBone.BoneProcessor.AnimatorRotation, forceMultiply);
				}
				if (_providedAnchorVelocity.HasValue)
				{
					if (Vector3.Distance(playmodeAnchorBone.PhysicalDummyBone.position, playmodeAnchorBone.SourceBone.position) < playmodeAnchorBone.BaseColliderSetup.CalculateSize().magnitude * 0.05f)
					{
						playmodeAnchorBone.GameRigidbody.velocity = _providedAnchorVelocity.Value;
						_providedAnchorVelocity = null;
						return;
					}
					_providedAnchorVelocity = null;
				}
				RagdollHandlerUtilities.AddAccelerationTowardsWorldPosition(playmodeAnchorBone.GameRigidbody, playmodeAnchorBone.BoneProcessor.LastMatchingRigidodyOrigin, playmodeAnchorBone.BoneProcessor.FixedPositionDelta, num3 * num3 * num3 * anchorBoneSpringPositionMultiplier, UnscaledTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
			}
			else
			{
				playmodeAnchorBone.BoneProcessor.AverageTranslationDataRequest();
				ApplyAnchorKinematicPosition();
			}
		}

		public void ForceSyncRoot(bool applyUsingAnchor = false)
		{
			if (applyUsingAnchor)
			{
				Vector3 position = GetAnchorBoneController.SourceBone.position;
				Quaternion rotation = _playmodeAnchorBone.SourceBone.rotation;
				if (UnaffectedMovement)
				{
					_playmodeAnchorBone.PhysicalDummyBone.position = position;
					_playmodeAnchorBone.PhysicalDummyBone.rotation = rotation;
				}
				else
				{
					_playmodeAnchorBone.GameRigidbody.MovePosition(position);
					_playmodeAnchorBone.GameRigidbody.MoveRotation(rotation);
				}
			}
			else
			{
				Vector3 vector = GetAnchorBoneController.SourceBone.position - dummyContainer.position;
				Quaternion quaternion = GetAnchorBoneController.SourceBone.rotation * Quaternion.Inverse(dummyContainer.rotation);
				dummyContainer.position += vector;
				dummyContainer.rotation *= quaternion;
			}
		}

		private void RefreshAnchorKinematicState()
		{
			RagdollChainBone playmodeAnchorBone = _playmodeAnchorBone;
			bool isKinematic = playmodeAnchorBone.GameRigidbody.isKinematic;
			if (ForcingKinematicAnchor > 0)
			{
				ForcingKinematicAnchor--;
				ChangeAnchorKinematicState(isKinematic: true);
				afterForcing = true;
				return;
			}
			if (AnimatingMode == EAnimatingMode.Standing)
			{
				if (AnchorBoneSpring * AnchorBoneSpringMultiplier >= 1f)
				{
					if (MakeAnchorKinematicOnMaxSpring)
					{
						ChangeAnchorKinematicState(isKinematic: true);
					}
					else
					{
						ChangeAnchorKinematicState(isKinematic: false);
					}
				}
				else
				{
					ChangeAnchorKinematicState(isKinematic: false);
				}
				if (afterForcing)
				{
					afterForcing = false;
					playmodeAnchorBone.GameRigidbody.collisionDetectionMode = (playmodeAnchorBone.UseIndividualParameters ? playmodeAnchorBone.OverrideDetectionMode : RigidbodiesDetectionMode);
				}
			}
			else if (animatingModeChanged || afterForcing)
			{
				afterForcing = false;
				if (!_playmodeAnchorBone.GameRigidbody.isKinematic)
				{
					playmodeAnchorBone.GameRigidbody.collisionDetectionMode = (playmodeAnchorBone.UseIndividualParameters ? playmodeAnchorBone.OverrideDetectionMode : RigidbodiesDetectionMode);
				}
				else
				{
					ChangeAnchorKinematicState(isKinematic: false);
				}
			}
			if (animatingModeChanged && IsFallingOrSleep && playmodeAnchorBone.GameRigidbody.isKinematic != isKinematic && !playmodeAnchorBone.GameRigidbody.isKinematic)
			{
				Vector3 vector = playmodeAnchorBone.BoneProcessor.AverageTranslationDataRequestRaw() / Time.fixedDeltaTime;
				playmodeAnchorBone.GameRigidbody.velocity = vector;
				if ((bool)Caller)
				{
					Caller.StartCoroutine(_IE_FreezeRigidbodyVelocityFor(playmodeAnchorBone.GameRigidbody, vector, 3));
				}
			}
		}

		private void ChangeAnchorKinematicState(bool isKinematic)
		{
			if (_playmodeAnchorBone.GameRigidbody.isKinematic == isKinematic)
			{
				return;
			}
			_playmodeAnchorBone.GameRigidbody.isKinematic = isKinematic;
			_playmodeAnchorBone.GameRigidbody.collisionDetectionMode = (_playmodeAnchorBone.UseIndividualParameters ? _playmodeAnchorBone.OverrideDetectionMode : RigidbodiesDetectionMode);
			if (isKinematic)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					if (chain.Detach)
					{
						foreach (RagdollChainBone boneSetup in chain.BoneSetups)
						{
							boneSetup.PhysicalDummyBone.SetParent(_playmodeAnchorBone.PhysicalDummyBone, worldPositionStays: true);
						}
					}
				}
				return;
			}
			foreach (RagdollBonesChain chain2 in chains)
			{
				if (!chain2.Detach)
				{
					continue;
				}
				foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
				{
					boneSetup2.PhysicalDummyBone.SetParent(dummyContainer, worldPositionStays: true);
				}
			}
		}

		private void ApplyAnchorKinematicPosition()
		{
			Vector3 animatorPosition = _playmodeAnchorBone.BoneProcessor.AnimatorPosition;
			Quaternion animatorRotation = _playmodeAnchorBone.BoneProcessor.AnimatorRotation;
			if (UnaffectedMovement)
			{
				_playmodeAnchorBone.PhysicalDummyBone.position = animatorPosition;
				_playmodeAnchorBone.PhysicalDummyBone.rotation = animatorRotation;
			}
			else
			{
				_playmodeAnchorBone.GameRigidbody.MovePosition(animatorPosition);
				_playmodeAnchorBone.GameRigidbody.MoveRotation(animatorRotation);
			}
		}

		private void AnchorJointRestoreRotationLock()
		{
			RagdollChainBone playmodeAnchorBone = _playmodeAnchorBone;
			if (playmodeAnchorBone.Joint.angularXMotion != ConfigurableJointMotion.Free)
			{
				playmodeAnchorBone.Joint.angularXMotion = ConfigurableJointMotion.Free;
				playmodeAnchorBone.Joint.angularYMotion = ConfigurableJointMotion.Free;
				playmodeAnchorBone.Joint.angularZMotion = ConfigurableJointMotion.Free;
			}
			if (playmodeAnchorBone.Joint.connectedBody == AnchorParent)
			{
				playmodeAnchorBone.Joint.connectedBody = null;
			}
		}

		private void UpdateAnchorParent()
		{
			RagdollChainBone playmodeAnchorBone = _playmodeAnchorBone;
			if (!IsFallingOrSleep)
			{
				if (LockAnchorRotation)
				{
					if (!playmodeAnchorBone.GameRigidbody.freezeRotation)
					{
						playmodeAnchorBone.GameRigidbody.freezeRotation = true;
					}
				}
				else if (AnchorJointLimits)
				{
					if (AnchorParent == null)
					{
						GameObject gameObject = new GameObject("Generated " + Dummy_Container.name + " Parent");
						gameObject.transform.SetParent(Dummy_Container, worldPositionStays: true);
						ResetCoords(gameObject.transform);
						AnchorParent = gameObject.AddComponent<Rigidbody>();
						AnchorParent.isKinematic = true;
						playmodeAnchorBone.Joint.autoConfigureConnectedAnchor = false;
					}
					if (AnchorParent.interpolation != RigidbodiesInterpolation)
					{
						AnchorParent.interpolation = RigidbodiesInterpolation;
					}
					if (AnchorParent.isKinematic)
					{
						AnchorParent.transform.position = playmodeAnchorBone.BoneProcessor.AnimatorPosition;
						AnchorParent.transform.rotation = playmodeAnchorBone.BoneProcessor.AnimatorRotation;
					}
					else
					{
						AnchorParent.position = playmodeAnchorBone.BoneProcessor.AnimatorPosition;
						AnchorParent.rotation = playmodeAnchorBone.BoneProcessor.AnimatorRotation;
					}
					if (playmodeAnchorBone.Joint.angularXMotion != ConfigurableJointMotion.Limited)
					{
						playmodeAnchorBone.Joint.angularXMotion = ConfigurableJointMotion.Limited;
						playmodeAnchorBone.Joint.angularYMotion = ConfigurableJointMotion.Limited;
						playmodeAnchorBone.Joint.angularZMotion = ConfigurableJointMotion.Limited;
					}
					if (playmodeAnchorBone.Joint.connectedBody == null && AnchorBoneSpring * AnchorBoneSpringMultiplier >= 1f)
					{
						playmodeAnchorBone.PhysicalDummyBone.position = playmodeAnchorBone.BoneProcessor.AnimatorPosition;
						playmodeAnchorBone.PhysicalDummyBone.rotation = playmodeAnchorBone.BoneProcessor.AnimatorRotation;
						playmodeAnchorBone.Joint.connectedBody = AnchorParent;
					}
				}
				if (!LockAnchorRotation && playmodeAnchorBone.GameRigidbody.freezeRotation)
				{
					playmodeAnchorBone.GameRigidbody.freezeRotation = false;
				}
			}
			else
			{
				if ((bool)AnchorParent)
				{
					AnchorJointRestoreRotationLock();
				}
				if (LockAnchorRotation && playmodeAnchorBone.GameRigidbody.freezeRotation)
				{
					playmodeAnchorBone.GameRigidbody.freezeRotation = false;
				}
			}
		}

		public void User_ProvideAnchorVelocity(Vector3 velocity)
		{
			_providedAnchorVelocity = velocity;
		}

		private void UpdateMotionInfluence()
		{
			if (!IsInStandingMode)
			{
				_lastFixedPosition = _playmodeAnchorBone.BoneProcessor.AnimatorPosition;
				_motionInfluenceOffset = Vector3.zero;
				return;
			}
			if (MotionInfluence == 1f)
			{
				_motionInfluenceOffset = Vector3.zero;
				_lastFixedPosition = _playmodeAnchorBone.BoneProcessor.AnimatorPosition;
				return;
			}
			Vector3 vector = _motionInfluenceOffset * (1f - MotionInfluence);
			_motionInfluenceOffset = Vector3.zero;
			if (vector.sqrMagnitude < 1E-05f)
			{
				return;
			}
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollBoneProcessor runtimeBoneProcessor in chain.RuntimeBoneProcessors)
				{
					runtimeBoneProcessor.rigidbody.transform.position += vector;
					runtimeBoneProcessor.rigidbody.AddForce(vector, ForceMode.VelocityChange);
				}
			}
		}

		public bool IsWearingAttachable(RA2AttachableObject attachable)
		{
			if (attachable == null)
			{
				return false;
			}
			return attachables.Contains(attachable);
		}

		public void WearAttachable(RA2AttachableObject attachable, Transform targetAnimatorBone)
		{
			if (attachable == null || targetAnimatorBone == null)
			{
				return;
			}
			if (!ContainsAnimatorBoneTransform(targetAnimatorBone))
			{
				Debug.Log("[Ragdoll Animator 2] Ragdoll Dummy is not built with " + targetAnimatorBone.name + " source bone!\nAdd it in the Ragdoll Construct first.");
				return;
			}
			RagdollChainBone ragdollChainBone = DictionaryGetBoneSetupBySourceBone(targetAnimatorBone);
			if (ragdollChainBone == null)
			{
				return;
			}
			Vector3 inertiaTensor = ragdollChainBone.GameRigidbody.inertiaTensor;
			Quaternion inertiaTensorRotation = ragdollChainBone.GameRigidbody.inertiaTensorRotation;
			Vector3 centerOfMass = ragdollChainBone.GameRigidbody.centerOfMass;
			foreach (Collider attachableCollider in attachable.AttachableColliders)
			{
				IgnoreCollisionWith(attachableCollider);
			}
			attachable.OnStartAttachingToRagdoll(this, ragdollChainBone);
			attachable.transform.position = targetAnimatorBone.TransformPoint(attachable.TargetLocalPosition);
			attachable.transform.rotation = targetAnimatorBone.rotation * Quaternion.Euler(attachable.TargetLocalRotation);
			Transform transform = AttachableGeneratePhysicsOn(attachable, ragdollChainBone);
			RagdollBonesChain chain = GetChain(ragdollChainBone);
			if (!attachable.KeepColliderOnAnimator)
			{
				foreach (Collider attachableCollider2 in attachable.AttachableColliders)
				{
					attachableCollider2.enabled = false;
				}
			}
			attachable.transform.SetParent(targetAnimatorBone, worldPositionStays: true);
			if (attachable.AddCollisionIndicators)
			{
				attachable.gameObject.AddComponent<RagdollAnimator2BoneIndicator>().Initialize(this, ragdollChainBone.BoneProcessor, chain, isAnimatorBone: true, attachable);
				transform.gameObject.AddComponent<RagdollAnimator2BoneIndicator>().Initialize(this, ragdollChainBone.BoneProcessor, chain, isAnimatorBone: false, attachable);
			}
			attachables.Add(attachable);
			if (attachable.Mass == 0f && attachable.DoNotChangeInertiaTensor)
			{
				ragdollChainBone.GameRigidbody.inertiaTensor = inertiaTensor;
				ragdollChainBone.GameRigidbody.inertiaTensorRotation = inertiaTensorRotation;
				ragdollChainBone.GameRigidbody.centerOfMass = centerOfMass;
			}
		}

		private Transform AttachableGeneratePhysicsOn(RA2AttachableObject attachable, RagdollChainBone dummyBone)
		{
			GameObject gameObject = new GameObject(attachable.name + ":Attachable Physics");
			gameObject.transform.position = attachable.transform.position;
			gameObject.transform.rotation = attachable.transform.rotation;
			gameObject.transform.localScale = attachable.transform.lossyScale;
			gameObject.layer = (attachable.ChangeObjectLayer ? RagdollDummyLayer : attachable.gameObject.layer);
			List<Collider> list = new List<Collider>();
			foreach (Collider attachableCollider in attachable.AttachableColliders)
			{
				if (attachableCollider.transform == attachable.transform)
				{
					Collider collider = gameObject.AddComponent(attachableCollider.GetType()) as Collider;
					RagdollBonesChain.CopyColliderSettingTo(attachableCollider, collider);
					list.Add(collider);
					continue;
				}
				if (_helperAttachableGeneratingDictionary == null)
				{
					_helperAttachableGeneratingDictionary = new Dictionary<Transform, Transform>();
				}
				_helperAttachableGeneratingDictionary.TryGetValue(attachableCollider.transform, out var value);
				if (value == null)
				{
					value = new GameObject(attachableCollider.name + ":Attachable Physics")
					{
						layer = (attachable.ChangeObjectLayer ? RagdollDummyLayer : attachableCollider.gameObject.layer)
					}.transform;
					value.localScale = attachableCollider.transform.lossyScale;
					value.SetParent(gameObject.transform, worldPositionStays: true);
					value.position = attachableCollider.transform.position;
					value.rotation = attachableCollider.transform.rotation;
					if (_helperAttachableGeneratingDictionary.ContainsKey(attachableCollider.transform))
					{
						_helperAttachableGeneratingDictionary[attachableCollider.transform] = value;
					}
					else
					{
						_helperAttachableGeneratingDictionary.Add(attachableCollider.transform, value);
					}
				}
				Collider collider2 = value.gameObject.AddComponent(attachableCollider.GetType()) as Collider;
				list.Add(collider2);
				RagdollBonesChain.CopyColliderSettingTo(attachableCollider, collider2);
			}
			Physics.SyncTransforms();
			foreach (Collider item in list)
			{
				IgnoreCollisionWithUsingBounds(item, 1.25f);
			}
			foreach (Collider item2 in list)
			{
				foreach (Collider attachableCollider2 in attachable.AttachableColliders)
				{
					Physics.IgnoreCollision(item2, attachableCollider2, ignore: true);
				}
			}
			attachable.OnAttachToRagdoll(gameObject, this, dummyBone, list);
			gameObject.transform.SetParent(dummyBone.PhysicalDummyBone, worldPositionStays: true);
			gameObject.transform.localPosition = attachable.TargetLocalPosition;
			gameObject.transform.localRotation = Quaternion.Euler(attachable.TargetLocalRotation);
			if (attachable.Mass > 0f)
			{
				Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
				rigidbody.interpolation = RigidbodiesInterpolation;
				rigidbody.collisionDetectionMode = RigidbodiesDetectionMode;
				rigidbody.mass = attachable.Mass;
				FixedJoint fixedJoint = null;
				fixedJoint = gameObject.AddComponent<FixedJoint>();
				fixedJoint.connectedBody = dummyBone.GameRigidbody;
				fixedJoint.connectedMassScale = attachable.ConnectedMassMultiplier;
				fixedJoint.massScale = attachable.MassScale;
				attachable.OnGeneratePhysicsComponents(rigidbody, fixedJoint);
			}
			return gameObject.transform;
		}

		public void UnwearAttachable(RA2AttachableObject attachable)
		{
			if (!IsWearingAttachable(attachable))
			{
				return;
			}
			attachable.transform.SetParent(null, worldPositionStays: true);
			attachable.RemoveFromCurrentDummy();
			if (!attachable.KeepColliderOnAnimator)
			{
				foreach (Collider attachableCollider in attachable.AttachableColliders)
				{
					attachableCollider.enabled = true;
				}
			}
			foreach (Collider attachableCollider2 in attachable.AttachableColliders)
			{
				IgnoreCollisionWith(attachableCollider2, ignore: false);
			}
			RagdollAnimator2BoneIndicator component = attachable.GetComponent<RagdollAnimator2BoneIndicator>();
			if ((bool)component)
			{
				UnityEngine.Object.Destroy(component);
			}
			attachables.Remove(attachable);
		}

		public void RemoveBoneFromRuntimeCalculations(RagdollChainBone b)
		{
			allBonesList.Remove(b.SourceBone);
			allBonesList.Remove(b.PhysicalDummyBone);
			animatorTransformBoneDictionary.Remove(b.SourceBone);
			nameTransformBoneDictionary.Remove(b.SourceBone.name);
			physicalTransformBoneDictionary.Remove(b.PhysicalDummyBone);
		}

		public void RestoreBoneToRuntimeCalculations(RagdollChainBone b)
		{
			if (!allBonesList.Contains(b.SourceBone))
			{
				allBonesList.Add(b.SourceBone);
			}
			if (!allBonesList.Contains(b.PhysicalDummyBone))
			{
				allBonesList.Add(b.PhysicalDummyBone);
			}
			if (!animatorTransformBoneDictionary.ContainsKey(b.SourceBone))
			{
				animatorTransformBoneDictionary.Add(b.SourceBone, b);
			}
			if (!nameTransformBoneDictionary.ContainsKey(b.SourceBone.name))
			{
				nameTransformBoneDictionary.Add(b.SourceBone.name, b);
			}
			if (!physicalTransformBoneDictionary.ContainsKey(b.PhysicalDummyBone))
			{
				physicalTransformBoneDictionary.Add(b.PhysicalDummyBone, b);
			}
		}

		internal void UpdateAttachables()
		{
			foreach (RA2AttachableObject attachable in attachables)
			{
				attachable.UpdateOnRagdoll();
			}
		}

		internal void FixedUpdateAttachables()
		{
			foreach (RA2AttachableObject attachable in attachables)
			{
				attachable.FixedUpdateTick();
			}
		}

		public Transform GetAnchorSourceBone()
		{
			if (WasInitialized)
			{
				return _playmodeAnchorBone.SourceBone;
			}
			RagdollBonesChain chain = GetChain(ERagdollChainType.Core);
			if (chain == null)
			{
				return null;
			}
			if (chain.BoneSetups.Count == 0)
			{
				return null;
			}
			return chain.BoneSetups[0].SourceBone;
		}

		public EReferencePoseReport ValidateReferencePose()
		{
			try
			{
				if (StoredReferenceTPose.BonePoses.Count < 2 || StoredReferenceTPose.LastBaseTransform == null)
				{
					return EReferencePoseReport.NoReferencePose;
				}
				if (StoredReferenceTPose.CheckIfAnyDiffers(GetBaseTransform()))
				{
					return EReferencePoseReport.ReferencePoseChanged;
				}
				return EReferencePoseReport.ReferencePoseOK;
			}
			catch (Exception exception)
			{
				Debug.Log("[Ragdoll Animator 2] Reference Pose Error! Check Error Log!");
				Debug.LogException(exception);
				return EReferencePoseReport.ReferencePoseError;
			}
		}

		public bool IsBaseSetupValid()
		{
			return GetAnchorSourceBone() != null;
		}

		public bool IsRagdollConstructionValid()
		{
			if (Chains.Count > 1)
			{
				return true;
			}
			if (chains.Count == 1)
			{
				for (int i = 0; i < chains[0].BoneSetups.Count; i++)
				{
					if (chains[0].BoneSetups[i].SourceBone == null)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void EnsureChainsHasParentHandler()
		{
			for (int i = 0; i < chains.Count; i++)
			{
				chains[i].SetParentHandler(this);
			}
		}

		public RagdollBonesChain AddNewBonesChain(string targetName, ERagdollChainType targetType)
		{
			RagdollBonesChain ragdollBonesChain = new RagdollBonesChain(this);
			ragdollBonesChain.SetParentHandler(this);
			ragdollBonesChain.ChainName = targetName;
			ragdollBonesChain.ChainType = targetType;
			Chains.Add(ragdollBonesChain);
			return ragdollBonesChain;
		}

		public int GetIndexOfChain(RagdollBonesChain chain)
		{
			for (int i = 0; i < chains.Count; i++)
			{
				if (chains[i] == chain)
				{
					return i;
				}
			}
			return -1;
		}

		public bool HasChain(RagdollBonesChain chain)
		{
			return GetIndexOfChain(chain) > -1;
		}

		public RagdollBonesChain GetChain(ERagdollChainType type)
		{
			for (int i = 0; i < chains.Count; i++)
			{
				if (chains[i].ChainType == type)
				{
					return chains[i];
				}
			}
			return null;
		}

		public RagdollBonesChain GetChain(int index)
		{
			if (index < 0 || index >= chains.Count)
			{
				return null;
			}
			return chains[index];
		}

		public RagdollBonesChain GetChain(ERagdollChainType type, RagdollBonesChain restrictedTo)
		{
			Transform baseTransform = GetBaseTransform();
			for (int i = 0; i < chains.Count; i++)
			{
				if (chains[i].ChainType != type)
				{
					continue;
				}
				if (restrictedTo != null && BaseTransform != null)
				{
					if (chains[i] == restrictedTo || chains[i].BoneSetups.Count != restrictedTo.BoneSetups.Count || chains[i].BoneSetups.Count == 0 || chains[i].BoneSetups[0].SourceBone == null || restrictedTo.BoneSetups[0].SourceBone == null || baseTransform == null)
					{
						continue;
					}
					Vector3 vector = BaseTransform.InverseTransformPoint(chains[i].BoneSetups[0].SourceBone.position);
					Vector3 vector2 = BaseTransform.InverseTransformPoint(restrictedTo.BoneSetups[0].SourceBone.position);
					if (Mathf.Abs(vector.z - vector2.z) > chains[i].CalculateLength() * 0.11f)
					{
						continue;
					}
				}
				return chains[i];
			}
			return null;
		}

		public RagdollBonesChain GetChain(RagdollChainBone member)
		{
			for (int i = 0; i < chains.Count; i++)
			{
				for (int j = 0; j < chains[i].BoneSetups.Count; j++)
				{
					if (chains[i].BoneSetups[j] == member)
					{
						return chains[i];
					}
				}
			}
			return null;
		}

		public RagdollChainBone FindAnimatorBoneTransformChainBone(Transform bone)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				if (!chain.ContainsAnimatorBoneTransform(bone))
				{
					continue;
				}
				for (int i = 0; i < chain.BoneSetups.Count; i++)
				{
					if (chain.BoneSetups[i].SourceBone == bone)
					{
						return chain.BoneSetups[i];
					}
				}
			}
			return null;
		}

		public RagdollBonesChain FindAnimatorBoneTransformOwnerChain(Transform bone)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				if (chain.ContainsAnimatorBoneTransform(bone))
				{
					return chain;
				}
			}
			return null;
		}

		public bool ContainsAnimatorBoneTransform(Transform bone)
		{
			if (!WasInitialized)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					if (chain.ContainsAnimatorBoneTransform(bone))
					{
						return true;
					}
				}
				return false;
			}
			return DictionaryContainsAnimatorBone(bone);
		}

		public bool ContainsPhysicalBoneTransform(Transform bone)
		{
			if (!WasInitialized)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					if (chain.ContainsDummyBoneTransform(bone))
					{
						return true;
					}
				}
				return false;
			}
			return DictionaryContainsDummyBone(bone);
		}

		public bool ContainsAnimatorBoneTransform(string name)
		{
			if (!WasInitialized)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					if (chain.ContainsAnimatorBoneTransform(name))
					{
						return true;
					}
				}
				return false;
			}
			return DictionaryContainsAnimatorBone(name);
		}

		public bool ContainsBoneTransform(Transform bone)
		{
			if (!WasInitialized)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					if (chain.ContainsDummyBoneTransform(bone))
					{
						return true;
					}
				}
				foreach (RagdollBonesChain chain2 in chains)
				{
					if (chain2.ContainsAnimatorBoneTransform(bone))
					{
						return true;
					}
				}
				return false;
			}
			return DictionaryContainsBone(bone);
		}

		public RagdollChainBone DummyStructure_FindConnectionBone(RagdollBonesChain childChain)
		{
			if (childChain.ChainType == ERagdollChainType.Core)
			{
				return null;
			}
			if (childChain.BoneSetups.Count == 0)
			{
				return null;
			}
			if (childChain.BoneSetups[0].SourceBone == null)
			{
				return null;
			}
			Transform transform = childChain.BoneSetups[0].SourceBone;
			while (transform != null)
			{
				transform = transform.parent;
				RagdollChainBone ragdollChainBone = FindAnimatorBoneTransformChainBone(transform);
				if (ragdollChainBone != null)
				{
					return ragdollChainBone;
				}
			}
			if (childChain.ChainType != ERagdollChainType.Core)
			{
				RagdollBonesChain chain = GetChain(ERagdollChainType.Core, null);
				if (chain.BoneSetups.Count > 0)
				{
					return chain.BoneSetups[0];
				}
				Debug.Log("[Ragdoll Animator Setup] Can't define right Core bone chain!");
			}
			return null;
		}

		public void PrepareBonesDicationaries()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (!nameTransformBoneDictionary.ContainsKey(boneSetup.SourceBone.name))
					{
						nameTransformBoneDictionary.Add(boneSetup.SourceBone.name, boneSetup);
					}
					physicalTransformBoneDictionary.Add(boneSetup.PhysicalDummyBone, boneSetup);
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						if (collider.UsingExtraTransform && (bool)collider.ColliderExtraTransform && !physicalTransformBoneDictionary.ContainsKey(collider.ColliderExtraTransform))
						{
							physicalTransformBoneDictionary.Add(collider.ColliderExtraTransform, boneSetup);
						}
					}
					animatorTransformBoneDictionary.Add(boneSetup.SourceBone, boneSetup);
					if (!boneIDDictionary.ContainsKey(boneSetup.BoneID))
					{
						boneIDDictionary.Add(boneSetup.BoneID, boneSetup);
					}
					allBonesList.Add(boneSetup.SourceBone);
					allBonesList.Add(boneSetup.PhysicalDummyBone);
				}
			}
		}

		private bool DictionaryContainsAnimatorBone(Transform sourceSkeletonBone)
		{
			return animatorTransformBoneDictionary.ContainsKey(sourceSkeletonBone);
		}

		private bool DictionaryContainsAnimatorBone(string transformName)
		{
			return nameTransformBoneDictionary.ContainsKey(transformName);
		}

		private bool DictionaryContainsDummyBone(Transform sceneBone)
		{
			return physicalTransformBoneDictionary.ContainsKey(sceneBone);
		}

		private bool DictionaryContainsBone(Transform sceneBone)
		{
			return allBonesList.Contains(sceneBone);
		}

		internal RagdollChainBone DictionaryGetBoneControllerBySourceBoneName(string boneName)
		{
			if (nameTransformBoneDictionary.TryGetValue(boneName, out var value))
			{
				return value;
			}
			return null;
		}

		internal RagdollChainBone DictionaryGetBoneSetupByBoneID(ERagdollBoneID id)
		{
			switch (id)
			{
			case ERagdollBoneID.Chest:
				if (!boneIDDictionary.ContainsKey(id))
				{
					id = ERagdollBoneID.UpperChest;
				}
				break;
			case ERagdollBoneID.UpperChest:
				if (!boneIDDictionary.ContainsKey(id))
				{
					id = ERagdollBoneID.Chest;
				}
				break;
			}
			if (boneIDDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		internal RagdollChainBone DictionaryGetBoneSetupBySourceBone(Transform sourceSkeletonBone)
		{
			if (animatorTransformBoneDictionary.TryGetValue(sourceSkeletonBone, out var value))
			{
				return value;
			}
			return null;
		}

		internal RagdollChainBone DictionaryGetBoneControllerByRagdollBone(Transform sceneBone)
		{
			if (physicalTransformBoneDictionary.TryGetValue(sceneBone, out var value))
			{
				return value;
			}
			return null;
		}

		public void IgnoreCollisionWith(Collider coll, bool ignore = true)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				chain.IgnoreCollisionsWith(coll, ignore);
			}
		}

		public void IgnoreCollisionWith(List<Collider> coll, bool ignore = true)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						foreach (Collider item in coll)
						{
							collider.IgnoreCollisionWith(item, ignore);
						}
					}
				}
			}
		}

		public void IgnoreCollisionWithUsingBounds(Collider coll, float boundsScale = 1.2f, bool ignore = true)
		{
			Bounds bounds = coll.bounds;
			bounds.size *= boundsScale;
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						if ((bool)collider.GameCollider && collider.GameCollider.bounds.Intersects(bounds))
						{
							Physics.IgnoreCollision(coll, collider.GameCollider, ignore);
							if (collider.ColliderType == RagdollChainBone.EColliderType.Other && (bool)collider.OtherReference)
							{
								Physics.IgnoreCollision(coll, collider.OtherReference, ignore);
							}
						}
					}
				}
			}
		}

		internal void EnsureCollisionsIgnoreSetup()
		{
			if (!wasEnsuredCollisionsIgnore)
			{
				wasEnsuredCollisionsIgnore = true;
				EnsureRelatedCollidersIgnore();
				if (IgnoreSourceSkeletonColliders)
				{
					User_FindAllCollidersInsideAndIgnoreTheirCollisionWithDummyColliders(GetBaseTransform());
				}
				if (IgnoreBoundedColliders)
				{
					EnsureRelatedCollidersIgnoreUsingBounds();
				}
			}
		}

		public void CopyChainsSettingsOf(RagdollHandler copyChainsSetupOf)
		{
			for (int i = 0; i < copyChainsSetupOf.chains.Count; i++)
			{
				RagdollBonesChain ragdollBonesChain = copyChainsSetupOf.chains[i];
				if (i >= chains.Count)
				{
					break;
				}
				RagdollBonesChain ragdollBonesChain2 = chains[i];
				if (ragdollBonesChain2.ChainType == ragdollBonesChain.ChainType)
				{
					ragdollBonesChain2.PasteExtraSettingsOfOtherChain(ragdollBonesChain);
					ragdollBonesChain2.PastePhysicsSettingsOfOtherChain(ragdollBonesChain);
					ragdollBonesChain2.PasteColliderSettingsOfOtherChain(ragdollBonesChain);
				}
			}
		}

		public int GetAllBonesCount()
		{
			int num = 0;
			foreach (RagdollBonesChain chain in chains)
			{
				num += chain.BoneSetups.Count;
			}
			return num;
		}

		public bool CheckIfBoneDuplicatesExistsInTheBoneSetups()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollBonesChain chain2 in chains)
					{
						if (chain2 == chain)
						{
							continue;
						}
						foreach (RagdollChainBone boneSetup2 in chain2.BoneSetups)
						{
							if (boneSetup.SourceBone == boneSetup2.SourceBone)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public void AddRagdollFeature(RagdollAnimatorFeatureBase featureReference)
		{
			RagdollAnimatorFeatureHelper ragdollAnimatorFeatureHelper = new RagdollAnimatorFeatureHelper();
			ragdollAnimatorFeatureHelper.FeatureReference = featureReference;
			if (WasInitialized)
			{
				ragdollAnimatorFeatureHelper.Init(this);
				if (ragdollAnimatorFeatureHelper.RuntimeFeature != null && ragdollAnimatorFeatureHelper.RuntimeFeature.Initialized)
				{
					ExtraFeatures.Add(ragdollAnimatorFeatureHelper);
				}
			}
			else
			{
				ExtraFeatures.Add(ragdollAnimatorFeatureHelper);
			}
		}

		public void AddRagdollFeature<T>() where T : RagdollAnimatorFeatureBase
		{
			AddRagdollFeature(ScriptableObject.CreateInstance<T>());
		}

		public void RemoveRagdollFeature(RagdollAnimatorFeatureHelper helper)
		{
			helper.DisposeRagdollFeature();
			ExtraFeatures.Remove(helper);
		}

		public T GetExtraFeature<T>() where T : RagdollAnimatorFeatureBase
		{
			for (int i = 0; i < ExtraFeatures.Count; i++)
			{
				if (!(ExtraFeatures[i].FeatureReference == null) && ExtraFeatures[i].FeatureReference is T)
				{
					return ExtraFeatures[i].ActiveFeature as T;
				}
			}
			return null;
		}

		public RagdollAnimatorFeatureHelper GetExtraFeatureHelper<T>() where T : RagdollAnimatorFeatureBase
		{
			for (int i = 0; i < ExtraFeatures.Count; i++)
			{
				if (!(ExtraFeatures[i].FeatureReference == null) && ExtraFeatures[i].FeatureReference is T)
				{
					return ExtraFeatures[i];
				}
			}
			return null;
		}

		public RagdollAnimatorFeatureHelper GetExtraFeatureHelper(Type type)
		{
			for (int i = 0; i < ExtraFeatures.Count; i++)
			{
				if (!(ExtraFeatures[i].FeatureReference == null) && ExtraFeatures[i].FeatureReference.GetType() == type)
				{
					return ExtraFeatures[i];
				}
			}
			return null;
		}

		public RagdollAnimatorFeatureHelper GetExtraFeatureHelper(string customName)
		{
			for (int i = 0; i < ExtraFeatures.Count; i++)
			{
				if (ExtraFeatures[i].CustomName == customName)
				{
					return ExtraFeatures[i];
				}
			}
			return null;
		}

		protected void CallExtraFeaturesOnInitialize()
		{
			foreach (RagdollAnimatorFeatureHelper extraFeature in ExtraFeatures)
			{
				if (extraFeature != null && !(extraFeature.FeatureReference == null))
				{
					extraFeature.Init(this);
				}
			}
			for (int num = ExtraFeatures.Count - 1; num >= 0; num--)
			{
				RagdollAnimatorFeatureHelper ragdollAnimatorFeatureHelper = ExtraFeatures[num];
				if (ragdollAnimatorFeatureHelper != null)
				{
					if (ragdollAnimatorFeatureHelper.RuntimeFeature == null)
					{
						ExtraFeatures[num].DisposeRagdollFeature();
						ExtraFeatures.RemoveAt(num);
					}
					else if (!ragdollAnimatorFeatureHelper.RuntimeFeature.Initialized)
					{
						ExtraFeatures[num].DisposeRagdollFeature();
						ExtraFeatures.RemoveAt(num);
					}
				}
			}
		}

		protected void CallExtraFeaturesOnEnable()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (RagdollAnimatorFeatureHelper extraFeature in ExtraFeatures)
			{
				if (extraFeature.Enabled && !(extraFeature.FeatureReference == null))
				{
					extraFeature.RuntimeFeature.OnEnableRagdoll();
				}
			}
		}

		protected void CallExtraFeaturesOnDisable()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (RagdollAnimatorFeatureHelper extraFeature in ExtraFeatures)
			{
				if (extraFeature.Enabled && !(extraFeature.FeatureReference == null))
				{
					extraFeature.RuntimeFeature.OnDisableRagdoll();
				}
			}
		}

		internal void AddToOnFallModeSwitchActions(Action action)
		{
			if (!OnFallModeSwitchActions.Contains(action))
			{
				OnFallModeSwitchActions.Add(action);
			}
		}

		internal void RemoveFromOnFallModeSwitchActions(Action action)
		{
			if (OnFallModeSwitchActions.Contains(action))
			{
				OnFallModeSwitchActions.Remove(action);
			}
		}

		protected void CallOnFallModeSwitchActions()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action onFallModeSwitchAction in OnFallModeSwitchActions)
			{
				onFallModeSwitchAction();
			}
		}

		internal void AddToAlwaysUpdateLoop(Action action)
		{
			if (!AlwaysUpdateActions.Contains(action))
			{
				AlwaysUpdateActions.Add(action);
			}
		}

		internal void RemoveFromAlwaysUpdateLoop(Action action)
		{
			if (AlwaysUpdateActions.Contains(action))
			{
				AlwaysUpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesAlwaysUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action alwaysUpdateAction in AlwaysUpdateActions)
			{
				alwaysUpdateAction();
			}
		}

		public void AddToUpdateLoop(Action action)
		{
			if (!UpdateActions.Contains(action))
			{
				UpdateActions.Add(action);
			}
		}

		public void RemoveFromUpdateLoop(Action action)
		{
			if (UpdateActions.Contains(action))
			{
				UpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action updateAction in UpdateActions)
			{
				updateAction();
			}
		}

		public void AddToPreLateUpdateLoop(Action action)
		{
			if (!PreLateUpdateActions.Contains(action))
			{
				PreLateUpdateActions.Add(action);
			}
		}

		public void RemoveFromPreLateUpdateLoop(Action action)
		{
			if (PreLateUpdateActions.Contains(action))
			{
				PreLateUpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesPreLateUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action preLateUpdateAction in PreLateUpdateActions)
			{
				preLateUpdateAction();
			}
		}

		public void AddToLateUpdateLoop(Action action)
		{
			if (!LateUpdateActions.Contains(action))
			{
				LateUpdateActions.Add(action);
			}
		}

		public void RemoveFromLateUpdateLoop(Action action)
		{
			if (LateUpdateActions.Contains(action))
			{
				LateUpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesLateUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action lateUpdateAction in LateUpdateActions)
			{
				lateUpdateAction();
			}
		}

		public void AddToPostLateUpdateLoop(Action action)
		{
			if (!PostLateUpdateActions.Contains(action))
			{
				PostLateUpdateActions.Add(action);
			}
		}

		public void RemoveFromPostLateUpdateLoop(Action action)
		{
			if (PostLateUpdateActions.Contains(action))
			{
				PostLateUpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesPostLateUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action postLateUpdateAction in PostLateUpdateActions)
			{
				postLateUpdateAction();
			}
		}

		public void AddToFixedUpdateLoop(Action action)
		{
			if (!FixedUpdateActions.Contains(action))
			{
				FixedUpdateActions.Add(action);
			}
		}

		public void RemoveFromFixedUpdateLoop(Action action)
		{
			if (FixedUpdateActions.Contains(action))
			{
				FixedUpdateActions.Remove(action);
			}
		}

		protected void CallExtraFeaturesFixedUpdateLoops()
		{
			if (!UseExtraFeatures)
			{
				return;
			}
			foreach (Action fixedUpdateAction in FixedUpdateActions)
			{
				fixedUpdateAction();
			}
		}

		public void AddToDummyBoneCollisionEnterActions(Action<RA2BoneCollisionHandler, Collision> action)
		{
			if (!OnCollisionEnterActions.Contains(action))
			{
				OnCollisionEnterActions.Add(action);
			}
		}

		public void RemoveFromDummyBoneCollisionEnterActions(Action<RA2BoneCollisionHandler, Collision> action)
		{
			if (OnCollisionEnterActions.Contains(action))
			{
				OnCollisionEnterActions.Remove(action);
			}
		}

		public void AddToTriggerEnterActions(Action<RA2BoneTriggerCollisionHandler, Collider> action)
		{
			if (!OnTriggerEnterActions.Contains(action))
			{
				OnTriggerEnterActions.Add(action);
			}
		}

		public void RemoveFromDummyBoneCollisionEnterActions(Action<RA2BoneTriggerCollisionHandler, Collider> action)
		{
			if (OnTriggerEnterActions.Contains(action))
			{
				OnTriggerEnterActions.Remove(action);
			}
		}

		public void TryFindBones(bool logResultReport = true)
		{
			if ((bool)Mecanim && Mecanim.isHuman)
			{
				IsHumanoid = true;
				chains.Clear();
				AddNewBonesChain("Core", ERagdollChainType.Core);
				chains[0].BoneSetups = new List<RagdollChainBone>();
				chains[0].AddNewBone(ERagdollBoneID.Hips, RagdollChainBone.EColliderType.Box);
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.Chest))
				{
					chains[0].AddNewBone(ERagdollBoneID.Chest, RagdollChainBone.EColliderType.Box);
				}
				else if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.Spine))
				{
					chains[0].AddNewBone(ERagdollBoneID.Spine, RagdollChainBone.EColliderType.Box);
				}
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.UpperChest))
				{
					chains[0].AddNewBone(ERagdollBoneID.Chest, RagdollChainBone.EColliderType.Box);
				}
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.Head))
				{
					chains[0].AddNewBone(ERagdollBoneID.Head);
				}
				AddNewBonesChain("Left Arm", ERagdollChainType.LeftArm);
				chains[1].BoneSetups = new List<RagdollChainBone>();
				chains[1].AddNewBone(ERagdollBoneID.LeftUpperArm);
				chains[1].AddNewBone(ERagdollBoneID.LeftLowerArm);
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.LeftHand))
				{
					chains[1].AddNewBone(ERagdollBoneID.LeftHand, RagdollChainBone.EColliderType.Box);
				}
				AddNewBonesChain("Right Arm", ERagdollChainType.RightArm);
				chains[2].BoneSetups = new List<RagdollChainBone>();
				chains[2].AddNewBone(ERagdollBoneID.RightUpperArm);
				chains[2].AddNewBone(ERagdollBoneID.RightLowerArm);
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.RightHand))
				{
					chains[2].AddNewBone(ERagdollBoneID.RightHand, RagdollChainBone.EColliderType.Box);
				}
				AddNewBonesChain("Left Leg", ERagdollChainType.LeftLeg);
				chains[3].BoneSetups = new List<RagdollChainBone>();
				chains[3].AddNewBone(ERagdollBoneID.LeftUpperLeg);
				chains[3].AddNewBone(ERagdollBoneID.LeftLowerLeg);
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.LeftFoot))
				{
					chains[3].AddNewBone(ERagdollBoneID.LeftFoot, RagdollChainBone.EColliderType.Box);
				}
				AddNewBonesChain("Right Leg", ERagdollChainType.RightLeg);
				chains[4].BoneSetups = new List<RagdollChainBone>();
				chains[4].AddNewBone(ERagdollBoneID.RightUpperLeg);
				chains[4].AddNewBone(ERagdollBoneID.RightLowerLeg);
				if ((bool)Mecanim.GetBoneTransform(HumanBodyBones.RightFoot))
				{
					chains[4].AddNewBone(ERagdollBoneID.RightFoot, RagdollChainBone.EColliderType.Box);
				}
				if (logResultReport)
				{
					_EditorDisplayDialog("Generated Dummy Structure", "Automatically generated dummy structure, using Mecanim Humanoid references.\n\nThat doesn't mean all is ready. You will need to do few corrections to the colliders and adjust bone physics settings for best results.");
				}
				return;
			}
			chains.Clear();
			AddNewBonesChain("Core", ERagdollChainType.Core);
			chains[0].BoneSetups = new List<RagdollChainBone>();
			chains[0].AddNewBone(null, RagdollChainBone.EColliderType.Box);
			SkeletonRecognize.SkeletonInfo skeletonInfo = new SkeletonRecognize.SkeletonInfo(GetBaseTransform(), null, chains[0].BoneSetups[0].SourceBone);
			chains.Clear();
			RagdollBonesChain ragdollBonesChain = AddNewBonesChain("Core", ERagdollChainType.Core);
			ragdollBonesChain.BoneSetups = new List<RagdollChainBone>();
			ragdollBonesChain.AddNewBone(assignSuggestion: false);
			ragdollBonesChain.BoneSetups[0].BaseColliderSetup.ColliderType = RagdollChainBone.EColliderType.Box;
			ragdollBonesChain.BoneSetups[0].SourceBone = skeletonInfo.ProbablyHips;
			for (int i = 0; i < skeletonInfo.ProbablySpineChainShort.Count; i++)
			{
				ragdollBonesChain.AddNewBone(assignSuggestion: false);
				ragdollBonesChain.BoneSetups[ragdollBonesChain.BoneSetups.Count - 1].BaseColliderSetup.ColliderType = RagdollChainBone.EColliderType.Box;
				ragdollBonesChain.BoneSetups[ragdollBonesChain.BoneSetups.Count - 1].SourceBone = skeletonInfo.ProbablySpineChainShort[i];
			}
			if ((bool)skeletonInfo.ProbablyHead && !ragdollBonesChain.ContainsAnimatorBoneTransform(skeletonInfo.ProbablyHead))
			{
				ragdollBonesChain.AddNewBone(assignSuggestion: false);
				ragdollBonesChain.BoneSetups[ragdollBonesChain.BoneSetups.Count - 1].BaseColliderSetup.ColliderType = RagdollChainBone.EColliderType.Capsule;
				ragdollBonesChain.BoneSetups[ragdollBonesChain.BoneSetups.Count - 1].SourceBone = skeletonInfo.ProbablyHead;
			}
			string text = "";
			if (logResultReport && skeletonInfo.WhatIsIt == SkeletonRecognize.EWhatIsIt.Unknown)
			{
				text = "?";
			}
			IsHumanoid = skeletonInfo.WhatIsIt == SkeletonRecognize.EWhatIsIt.Humanoidal;
			for (int j = 0; j < skeletonInfo.ProbablyRightLegs.Count; j++)
			{
				List<Transform> list = skeletonInfo.ProbablyRightLegs[j];
				for (int k = 0; k < skeletonInfo.ProbablySpineChain.Count; k++)
				{
					if (list.Contains(skeletonInfo.ProbablySpineChain[k]))
					{
						list.Remove(skeletonInfo.ProbablySpineChain[k]);
					}
				}
				RagdollBonesChain ragdollBonesChain2 = AddNewBonesChain("Right Leg" + text, ERagdollChainType.RightLeg);
				ragdollBonesChain2.BoneSetups = new List<RagdollChainBone>();
				for (int l = 0; l < list.Count; l++)
				{
					ragdollBonesChain2.AddNewBone(assignSuggestion: false);
					ragdollBonesChain2.BoneSetups[l].BaseColliderSetup.ColliderType = ((l == list.Count - 1 && l > 1) ? RagdollChainBone.EColliderType.Box : RagdollChainBone.EColliderType.Capsule);
					ragdollBonesChain2.BoneSetups[l].SourceBone = list[l];
				}
			}
			for (int m = 0; m < skeletonInfo.ProbablyLeftLegs.Count; m++)
			{
				List<Transform> list2 = skeletonInfo.ProbablyLeftLegs[m];
				for (int n = 0; n < skeletonInfo.ProbablySpineChain.Count; n++)
				{
					if (list2.Contains(skeletonInfo.ProbablySpineChain[n]))
					{
						list2.Remove(skeletonInfo.ProbablySpineChain[n]);
					}
				}
				RagdollBonesChain ragdollBonesChain3 = AddNewBonesChain("Left Leg" + text, ERagdollChainType.LeftLeg);
				ragdollBonesChain3.BoneSetups = new List<RagdollChainBone>();
				for (int num = 0; num < list2.Count; num++)
				{
					ragdollBonesChain3.AddNewBone(assignSuggestion: false);
					ragdollBonesChain3.BoneSetups[num].BaseColliderSetup.ColliderType = ((num == list2.Count - 1 && num > 1) ? RagdollChainBone.EColliderType.Box : RagdollChainBone.EColliderType.Capsule);
					ragdollBonesChain3.BoneSetups[num].SourceBone = list2[num];
				}
			}
			for (int num2 = 0; num2 < skeletonInfo.ProbablyRightArms.Count; num2++)
			{
				List<Transform> list3 = skeletonInfo.ProbablyRightArms[num2];
				for (int num3 = 0; num3 < skeletonInfo.ProbablySpineChain.Count; num3++)
				{
					if (list3.Contains(skeletonInfo.ProbablySpineChain[num3]))
					{
						list3.Remove(skeletonInfo.ProbablySpineChain[num3]);
					}
				}
				RagdollBonesChain ragdollBonesChain4 = AddNewBonesChain("Right Arm" + text, ERagdollChainType.RightArm);
				ragdollBonesChain4.BoneSetups = new List<RagdollChainBone>();
				for (int num4 = 0; num4 < list3.Count; num4++)
				{
					ragdollBonesChain4.AddNewBone(assignSuggestion: false);
					ragdollBonesChain4.BoneSetups[num4].BaseColliderSetup.ColliderType = ((num4 == list3.Count - 1 && num4 > 1) ? RagdollChainBone.EColliderType.Box : RagdollChainBone.EColliderType.Capsule);
					ragdollBonesChain4.BoneSetups[num4].SourceBone = list3[num4];
				}
			}
			for (int num5 = 0; num5 < skeletonInfo.ProbablyLeftArms.Count; num5++)
			{
				List<Transform> list4 = skeletonInfo.ProbablyLeftArms[num5];
				for (int num6 = 0; num6 < skeletonInfo.ProbablySpineChain.Count; num6++)
				{
					if (list4.Contains(skeletonInfo.ProbablySpineChain[num6]))
					{
						list4.Remove(skeletonInfo.ProbablySpineChain[num6]);
					}
				}
				RagdollBonesChain ragdollBonesChain5 = AddNewBonesChain("Left Arm" + text, ERagdollChainType.LeftArm);
				ragdollBonesChain5.BoneSetups = new List<RagdollChainBone>();
				for (int num7 = 0; num7 < list4.Count; num7++)
				{
					ragdollBonesChain5.AddNewBone(assignSuggestion: false);
					ragdollBonesChain5.BoneSetups[num7].BaseColliderSetup.ColliderType = ((num7 == list4.Count - 1 && num7 > 1) ? RagdollChainBone.EColliderType.Box : RagdollChainBone.EColliderType.Capsule);
					ragdollBonesChain5.BoneSetups[num7].SourceBone = list4[num7];
				}
			}
			foreach (RagdollBonesChain chain in chains)
			{
				chain.TryIdentifyBoneIDs();
			}
			if (logResultReport)
			{
				if (skeletonInfo.WhatIsIt == SkeletonRecognize.EWhatIsIt.Humanoidal)
				{
					_EditorDisplayDialog("Generated Dummy Structure", "Automatically generated dummy structure, using predicted transforms.\nAlgorithm detected skeleton structure matching with Humanoid.\nYou probably will need to do adjustements!\n\nCheck if limbs and it's bone references are right!\nYou will need to do colliders corrections and adjust bone physics settings.\n\n" + skeletonInfo.GetLog());
				}
				else if (skeletonInfo.WhatIsIt == SkeletonRecognize.EWhatIsIt.Quadroped)
				{
					_EditorDisplayDialog("Generated Dummy Structure", "Automatically generated dummy structure, using predicted transforms.\nAlgorithm detected skeleton structure matching with Quadroped.\nYou will need to do adjustements!\n\nChecking if right limbs and bones was added IS REQUIRED. You will need to do colliders corrections and adjust bone physics settings.\n\n" + skeletonInfo.GetLog());
				}
				else
				{
					_EditorDisplayDialog("Generated Dummy Structure", "Automatically generated dummy structure, using predicted transforms.\nAlgorithm couldn't specify type of the skeleton.\nPredicted limbs are added, BUT MOST LIKELY THEY'RE WRONG, and you should define ragdoll skeleton manually!\n\n" + skeletonInfo.GetLog());
				}
			}
		}

		public void TryAutoFindChainFirstBone(RagdollBonesChain chain)
		{
			if (chain.BoneSetups.Count == 0)
			{
				chain.AddNewBone(assignSuggestion: false, RagdollChainBone.EColliderType.Box);
			}
			else if (chain.BoneSetups[0].SourceBone != null)
			{
				return;
			}
			if (chain.ChainType == ERagdollChainType.Core)
			{
				if ((bool)Mecanim && Mecanim.isHuman)
				{
					chain.BoneSetups[0].SourceBone = Mecanim.GetBoneTransform(HumanBodyBones.Hips);
					return;
				}
				SkeletonRecognize.SkeletonInfo skeletonInfo = new SkeletonRecognize.SkeletonInfo(GetBaseTransform());
				if ((bool)skeletonInfo.ProbablyHips)
				{
					chain.BoneSetups[0].SourceBone = skeletonInfo.ProbablyHips;
				}
			}
			else if (chain.ChainType.IsLeg())
			{
				if ((bool)Mecanim && Mecanim.isHuman)
				{
					if (chain.ChainType == ERagdollChainType.LeftLeg)
					{
						chain.BoneSetups[0].SourceBone = Mecanim.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
					}
					else
					{
						chain.BoneSetups[0].SourceBone = Mecanim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
					}
					return;
				}
				SkeletonRecognize.SkeletonInfo skeletonInfo2 = new SkeletonRecognize.SkeletonInfo(GetBaseTransform());
				if (chain.ChainType == ERagdollChainType.LeftLeg)
				{
					if (skeletonInfo2.LeftLegs > 0 && skeletonInfo2.ProbablyLeftLegs.Count > 0)
					{
						chain.BoneSetups[0].SourceBone = skeletonInfo2.ProbablyLeftLegs[0][0];
					}
				}
				else if (skeletonInfo2.RightLegs > 0 && skeletonInfo2.ProbablyRightLegs.Count > 0)
				{
					chain.BoneSetups[0].SourceBone = skeletonInfo2.ProbablyRightLegs[0][0];
				}
			}
			else
			{
				if (!chain.ChainType.IsArm())
				{
					return;
				}
				if ((bool)Mecanim && Mecanim.isHuman)
				{
					if (chain.ChainType == ERagdollChainType.LeftArm)
					{
						chain.BoneSetups[0].SourceBone = Mecanim.GetBoneTransform(HumanBodyBones.LeftUpperArm);
					}
					else
					{
						chain.BoneSetups[0].SourceBone = Mecanim.GetBoneTransform(HumanBodyBones.RightUpperArm);
					}
					return;
				}
				SkeletonRecognize.SkeletonInfo skeletonInfo3 = new SkeletonRecognize.SkeletonInfo(GetBaseTransform());
				if (chain.ChainType == ERagdollChainType.LeftArm)
				{
					if (skeletonInfo3.LeftArms > 0 && skeletonInfo3.ProbablyLeftArms.Count > 0)
					{
						chain.BoneSetups[0].SourceBone = skeletonInfo3.ProbablyLeftArms[0][0];
					}
				}
				else if (skeletonInfo3.RightArms > 0 && skeletonInfo3.ProbablyRightArms.Count > 0)
				{
					chain.BoneSetups[0].SourceBone = skeletonInfo3.ProbablyRightArms[0][0];
				}
			}
		}

		private void _EditorDisplayDialog(string title, string description)
		{
		}

		public void GenerateDummyHierarchy()
		{
			if (DummyWasGenerated)
			{
				return;
			}
			if (WaitForInit || UseReconstruction)
			{
				ApplyTPoseOnModel(syncTransforms: true);
			}
			Dummy_Container = CreateTransform(parentObject.name + "-Ragdoll", RagdollDummyLayer);
			SetCoordsLike(Dummy_Container, parentObject.transform);
			skeletonFillExtraBones = new Dictionary<Transform, RagdollChainBone.InBetweenBone>();
			inBetweenPreGenerateMemory = new List<RagdollChainBone.InBetweenBone>();
			for (int i = 0; i < chains.Count; i++)
			{
				RagdollBonesChain ragdollBonesChain = chains[i];
				if (ragdollBonesChain.BoneSetups.Count != 0)
				{
					ragdollBonesChain.GenerateDummyLimb(this);
				}
			}
			GetChain(ERagdollChainType.Core).BoneSetups[0].IsAnchor = true;
			skeletonFillExtraBonesList = new List<RagdollChainBone.InBetweenBone>();
			foreach (KeyValuePair<Transform, RagdollChainBone.InBetweenBone> skeletonFillExtraBone in skeletonFillExtraBones)
			{
				skeletonFillExtraBonesList.Add(skeletonFillExtraBone.Value);
			}
			for (int j = 0; j < chains.Count; j++)
			{
				chains[j].RefreshRagdollComponents();
			}
			for (int k = 0; k < chains.Count; k++)
			{
				RagdollBonesChain ragdollBonesChain2 = chains[k];
				RagdollChainBone connectionBone = ragdollBonesChain2.ConnectionBone;
				ragdollBonesChain2.RefreshJointsParentingDefault(connectionBone);
			}
		}

		private void GenerateJustSkeletonComponentsLogic()
		{
			RagdollHandlerUtilities.AddCollidersOnTheCharacterBones(this);
			RagdollHandlerUtilities.AddPhysicsComponentsOnTheCharacterBones(this);
			SwitchDummyPhysics(enable: true);
		}

		public void ApplyPreGenerateDummyChanges()
		{
			this.User_UpdateAllBonesParametersAfterManualChanges();
			skeletonFillExtraBones = new Dictionary<Transform, RagdollChainBone.InBetweenBone>();
			foreach (RagdollChainBone.InBetweenBone item in inBetweenPreGenerateMemory)
			{
				skeletonFillExtraBones.Add(item.SourceBone, item);
			}
			skeletonFillExtraBonesList = new List<RagdollChainBone.InBetweenBone>();
			foreach (KeyValuePair<Transform, RagdollChainBone.InBetweenBone> skeletonFillExtraBone in skeletonFillExtraBones)
			{
				skeletonFillExtraBonesList.Add(skeletonFillExtraBone.Value);
			}
			if (WaitForInit || UseReconstruction)
			{
				ApplyTPoseOnModel(syncTransforms: true);
			}
			GetChain(ERagdollChainType.Core).BoneSetups[0].IsAnchor = true;
		}

		private void GenerateInBetweenBonesPhysics()
		{
			if (!wasInReconstructionMode)
			{
				wasInReconstructionMode = true;
				Caller.StartCoroutine(IEGenerateInBetweenBonesPhysics());
			}
		}

		private IEnumerator IEGenerateInBetweenBonesPhysics()
		{
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
			{
				skeletonFillExtraBones.GenerateRigidbody();
			}
			yield return null;
			ApplyTPoseOnModel(syncTransforms: true);
			for (int i = 0; i < chains.Count; i++)
			{
				RagdollBonesChain ragdollBonesChain = chains[i];
				RagdollChainBone connectionBone = ragdollBonesChain.ConnectionBone;
				ragdollBonesChain.RefreshJointsParentingWithInBetweenBones(connectionBone);
			}
			foreach (RagdollBonesChain chain in chains)
			{
				chain.ConfigureJointsAnchors();
			}
		}

		private void DiscardInBetweenBonesPhysics()
		{
			if (wasInReconstructionMode)
			{
				wasInReconstructionMode = false;
				Caller.StartCoroutine(IEDiscardInBetweenBonesPhysics());
			}
		}

		private IEnumerator IEDiscardInBetweenBonesPhysics()
		{
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
			{
				skeletonFillExtraBones.DestroyPhysicalComponents();
			}
			yield return null;
			ApplyTPoseOnModel(syncTransforms: true);
			for (int i = 0; i < chains.Count; i++)
			{
				RagdollBonesChain ragdollBonesChain = chains[i];
				RagdollChainBone connectionBone = ragdollBonesChain.ConnectionBone;
				ragdollBonesChain.RefreshJointsParentingDefault(connectionBone);
			}
			foreach (RagdollBonesChain chain in chains)
			{
				chain.ConfigureJointsAnchors();
			}
			this.User_SetAllKinematic(kinematic: false);
		}

		public void FinalizePhysicalDummySetup()
		{
			EnsureCollisionsIgnoreSetup();
			for (int i = 0; i < chains.Count; i++)
			{
				RagdollBonesChain ragdollBonesChain = chains[i];
				if (ragdollBonesChain.ConnectionBone == null)
				{
					ragdollBonesChain.DefineConnectionBone(this);
				}
				RagdollChainBone connectionBone = ragdollBonesChain.ConnectionBone;
				ragdollBonesChain.RefreshBonesParentBoneVariable(connectionBone);
			}
			Dummy_Container.SetParent(TargetParentForRagdollDummy, worldPositionStays: true);
			if (HideDummyInSceneView)
			{
				dummyContainer.hideFlags = HideFlags.HideInHierarchy;
			}
			DummyReference = Dummy_Container.gameObject.AddComponent<RagdollAnimatorDummyReference>();
			DummyReference.Initialize(Caller, this);
			for (int j = 0; j < chains.Count; j++)
			{
				chains[j].CompletePlaymodeInitialization();
			}
			foreach (RagdollBonesChain chain in chains)
			{
				chain.ConfigureJointsAnchors();
			}
			this.User_UpdateAllBonesParametersAfterManualChanges();
			this.User_UpdateLayersAfterManualChanges();
			foreach (RagdollBonesChain chain2 in chains)
			{
				chain2.DetachBones(this);
			}
			ResetSleepMode();
			if (AnimatingMode == EAnimatingMode.Standing && UseReconstruction)
			{
				GenerateInBetweenBonesPhysics();
			}
		}

		public void EnsureRelatedCollidersIgnore()
		{
			_ = GetAnchorBoneController;
			foreach (RagdollBonesChain chain in chains)
			{
				chain.EnsureCollisionIgnoreBetweenChildBones();
			}
		}

		public void EnsureRelatedCollidersIgnoreUsingBounds()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				chain.EnsureCollisionIgnoreBetweenBonesUsingBounds(chains, BoundedCollidersIgnoreScaleup);
			}
		}

		public void StoreReferenceTPose()
		{
			StoredReferenceTPose.ClearPose();
			Transform baseTransform = GetBaseTransform();
			for (int i = 0; i < chains.Count; i++)
			{
				for (int j = 0; j < chains[i].BoneSetups.Count; j++)
				{
					RagdollChainBone ragdollChainBone = chains[i].BoneSetups[j];
					StoredReferenceTPose.UpdateBone(ragdollChainBone.SourceBone, baseTransform);
					if (j >= chains[i].BoneSetups.Count - 1)
					{
						continue;
					}
					RagdollChainBone ragdollChainBone2 = chains[i].BoneSetups[j + 1];
					if (!(ragdollChainBone2.SourceBone.parent == chains[i].BoneSetups[j].SourceBone))
					{
						Transform parent = ragdollChainBone2.SourceBone.parent;
						while (parent != null && parent != chains[i].BoneSetups[j].SourceBone)
						{
							StoredReferenceTPose.UpdateBone(parent, baseTransform);
							parent = parent.parent;
						}
					}
				}
				if (chains[i].ChainType != ERagdollChainType.Core)
				{
					RagdollChainBone ragdollChainBone3 = DummyStructure_FindConnectionBone(chains[i]);
					Transform parent2 = chains[i].BoneSetups[0].SourceBone.parent;
					while (parent2 != ragdollChainBone3.SourceBone && parent2 != null)
					{
						StoredReferenceTPose.UpdateBone(parent2, baseTransform);
						parent2 = parent2.parent;
					}
				}
			}
			OnChange();
		}

		public void ApplyTPoseOnModel()
		{
			ApplyTPoseOnModel(syncTransforms: true);
		}

		public void ApplyTPoseOnModel(bool syncTransforms)
		{
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				return;
			}
			EReferencePoseReport eReferencePoseReport = ValidateReferencePose();
			if (eReferencePoseReport == EReferencePoseReport.ReferencePoseError || eReferencePoseReport == EReferencePoseReport.NoReferencePose)
			{
				return;
			}
			StoredReferenceTPose.CheckForNulls();
			StoredReferenceTPose.ApplyPose(GetBaseTransform());
			if (WasInitialized)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					foreach (RagdollChainBone boneSetup in chain.BoneSetups)
					{
						if (chain.Detach || boneSetup.IsAnchor)
						{
							boneSetup.PhysicalDummyBone.position = boneSetup.SourceBone.position;
							boneSetup.PhysicalDummyBone.rotation = boneSetup.SourceBone.rotation;
						}
						else
						{
							boneSetup.PhysicalDummyBone.localPosition = boneSetup.SourceBone.localPosition;
							boneSetup.PhysicalDummyBone.localRotation = boneSetup.SourceBone.localRotation;
						}
						boneSetup.GameRigidbody.position = boneSetup.PhysicalDummyBone.position;
						boneSetup.GameRigidbody.rotation = boneSetup.PhysicalDummyBone.rotation;
						if (!boneSetup.GameRigidbody.isKinematic)
						{
							boneSetup.GameRigidbody.velocity = Vector3.zero;
						}
						if (!boneSetup.GameRigidbody.isKinematic)
						{
							boneSetup.GameRigidbody.angularVelocity = Vector3.zero;
						}
					}
				}
				foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
				{
					skeletonFillExtraBones.DummyBone.localPosition = skeletonFillExtraBones.SourceBone.localPosition;
					skeletonFillExtraBones.DummyBone.localRotation = skeletonFillExtraBones.SourceBone.localRotation;
					if ((bool)skeletonFillExtraBones.rigidbody)
					{
						skeletonFillExtraBones.rigidbody.position = skeletonFillExtraBones.DummyBone.position;
						skeletonFillExtraBones.rigidbody.velocity = Vector3.zero;
						skeletonFillExtraBones.rigidbody.rotation = skeletonFillExtraBones.DummyBone.rotation;
						skeletonFillExtraBones.rigidbody.angularVelocity = Vector3.zero;
					}
				}
			}
			if (syncTransforms)
			{
				Physics.SyncTransforms();
			}
			OnChange();
		}

		public void SwitchPreGeneratedDummy()
		{
			if (DummyWasGenerated)
			{
				UnityEngine.Object.DestroyImmediate(Dummy_Container.gameObject);
				return;
			}
			GenerateDummyHierarchy();
			dummyContainer.SetParent(parentObject.transform, worldPositionStays: true);
		}

		internal RagdollChainBone.InBetweenBone GetParentConnectionBoneTo(Transform physicalDummyBone)
		{
			for (int i = 0; i < skeletonFillExtraBonesList.Count; i++)
			{
				if (skeletonFillExtraBonesList[i].DummyBone == physicalDummyBone.parent)
				{
					return skeletonFillExtraBonesList[i];
				}
			}
			return null;
		}

		internal void PrepareDummyBonesCollisionIndicators(bool collectCollisions, bool useSelfCollision = true)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					for (int i = 0; i < boneSetup.Colliders.Count; i++)
					{
						if (boneSetup.Colliders[i].GameCollider == null)
						{
							continue;
						}
						RagdollAnimator2BoneIndicator ragdollAnimator2BoneIndicator = boneSetup.Colliders[i].GameCollider.GetComponent<RagdollAnimator2BoneIndicator>();
						if (boneSetup.DisableCollisionEvents)
						{
							if (ragdollAnimator2BoneIndicator == null)
							{
								ragdollAnimator2BoneIndicator = boneSetup.Colliders[i].GameCollider.gameObject.AddComponent<RagdollAnimator2BoneIndicator>();
								ragdollAnimator2BoneIndicator.Initialize(this, boneSetup.BoneProcessor, chain);
							}
							continue;
						}
						if ((bool)ragdollAnimator2BoneIndicator && !(ragdollAnimator2BoneIndicator is RA2BoneCollisionHandler))
						{
							UnityEngine.Object.Destroy(ragdollAnimator2BoneIndicator);
							ragdollAnimator2BoneIndicator = null;
						}
						RA2BoneCollisionHandler rA2BoneCollisionHandler;
						if (ragdollAnimator2BoneIndicator == null)
						{
							rA2BoneCollisionHandler = boneSetup.Colliders[i].GameCollider.gameObject.AddComponent<RA2BoneCollisionHandler>();
							rA2BoneCollisionHandler.Initialize(this, boneSetup.BoneProcessor, chain);
							if (boneSetup.GameRigidbody.gameObject != boneSetup.Colliders[i].GameCollider.gameObject && boneSetup.GameRigidbody.GetComponent<RA2BoneCollisionHandler>() == null)
							{
								RA2BoneCollisionHandler rA2BoneCollisionHandler2 = boneSetup.GameRigidbody.gameObject.AddComponent<RA2BoneCollisionHandler>();
								rA2BoneCollisionHandler2.Initialize(this, boneSetup.BoneProcessor, chain);
								if (collectCollisions)
								{
									rA2BoneCollisionHandler2.EnableSavingEnteredCollisionsList();
								}
								rA2BoneCollisionHandler2.UseSelfCollisions = useSelfCollision;
							}
						}
						else
						{
							rA2BoneCollisionHandler = boneSetup.Colliders[i].GameCollider.GetComponent<RA2BoneCollisionHandler>();
						}
						if (collectCollisions)
						{
							rA2BoneCollisionHandler.EnableSavingEnteredCollisionsList();
						}
						rA2BoneCollisionHandler.UseSelfCollisions = useSelfCollision;
					}
				}
			}
			_dummyIndicatorsWasPrepared = true;
		}

		internal void PrepareSourceBonesCollisionIndicators(bool triggerHandlers, bool enableCollisionCollecting = false, bool useSelfCollision = false)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					RagdollAnimator2BoneIndicator ragdollAnimator2BoneIndicator = boneSetup.SourceBone.GetComponent<RagdollAnimator2BoneIndicator>();
					boneSetup.RefreshCollider(chain, IsFallingOrSleep, onSource: true);
					if (boneSetup.DisableCollisionEvents)
					{
						if (ragdollAnimator2BoneIndicator == null)
						{
							ragdollAnimator2BoneIndicator = boneSetup.SourceBone.gameObject.AddComponent<RagdollAnimator2BoneIndicator>();
							ragdollAnimator2BoneIndicator.Initialize(this, boneSetup.BoneProcessor, chain, isAnimatorBone: true);
						}
					}
					else if (triggerHandlers)
					{
						if ((bool)ragdollAnimator2BoneIndicator && !(ragdollAnimator2BoneIndicator is RA2BoneTriggerCollisionHandler))
						{
							UnityEngine.Object.Destroy(ragdollAnimator2BoneIndicator);
							ragdollAnimator2BoneIndicator = null;
						}
						RA2BoneTriggerCollisionHandler rA2BoneTriggerCollisionHandler;
						if (ragdollAnimator2BoneIndicator == null)
						{
							rA2BoneTriggerCollisionHandler = boneSetup.SourceBone.gameObject.AddComponent<RA2BoneTriggerCollisionHandler>();
							rA2BoneTriggerCollisionHandler.Initialize(this, boneSetup.BoneProcessor, chain, isAnimatorBone: true);
						}
						else
						{
							rA2BoneTriggerCollisionHandler = boneSetup.SourceBone.GetComponent<RA2BoneTriggerCollisionHandler>();
						}
						if (enableCollisionCollecting)
						{
							rA2BoneTriggerCollisionHandler.EnableSavingEnteredCollisionsList();
						}
						rA2BoneTriggerCollisionHandler.UseSelfCollisions = useSelfCollision;
					}
					else
					{
						if ((bool)ragdollAnimator2BoneIndicator && !(ragdollAnimator2BoneIndicator is RA2BoneCollisionHandler))
						{
							UnityEngine.Object.Destroy(ragdollAnimator2BoneIndicator);
							ragdollAnimator2BoneIndicator = null;
						}
						RA2BoneCollisionHandler rA2BoneCollisionHandler;
						if (ragdollAnimator2BoneIndicator == null)
						{
							rA2BoneCollisionHandler = boneSetup.SourceBone.gameObject.AddComponent<RA2BoneCollisionHandler>();
							rA2BoneCollisionHandler.Initialize(this, boneSetup.BoneProcessor, chain, isAnimatorBone: true);
						}
						else
						{
							rA2BoneCollisionHandler = boneSetup.SourceBone.GetComponent<RA2BoneCollisionHandler>();
						}
						rA2BoneCollisionHandler.UseSelfCollisions = useSelfCollision;
						if (enableCollisionCollecting)
						{
							rA2BoneCollisionHandler.EnableSavingEnteredCollisionsList();
						}
					}
				}
			}
			_sourceIndicatorsWasPrepared = true;
		}

		public void User_ResetOverrideBlends()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				chain.User_ResetOverrideBlends();
			}
		}

		public void StoreCalibrationPose()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				chain.StoreCalibrationPose();
			}
		}

		public void RestoreCalibrationPose()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				chain.RestoreCalibrationPose();
			}
		}

		public void ForceFixedReinitialization()
		{
			ForcingKinematicAnchor = 2;
			fixedInitialized = false;
			fixedFramesElapsed = 0;
		}

		private void CheckIfShouldBeUpdated()
		{
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				disableUpdating = true;
				_lastAnimatingMode = animatingMode;
				return;
			}
			disableUpdating = false;
			if (LODBlend <= 0f)
			{
				disableUpdating = true;
				_wasDisableUpdating = true;
				_lastAnimatingMode = animatingMode;
				return;
			}
			if (OptimizeOnZeroBlend && RagdollBlend < 1E-06f)
			{
				disableUpdating = true;
				_wasDisableUpdating = true;
				_lastAnimatingMode = animatingMode;
				return;
			}
			if (AnimatingMode == EAnimatingMode.Off)
			{
				disableUpdating = true;
				_wasDisableUpdating = true;
				_lastAnimatingMode = animatingMode;
				return;
			}
			if (AnimatingMode == EAnimatingMode.Sleep)
			{
				SleepModeUpdate();
			}
			if (_wasDisableUpdating != disableUpdating && !disableUpdating)
			{
				if (!_wasSleepDisable)
				{
					ResetFadeInBlend();
				}
				if (!IsInFallingMode || (_lastAnimatingMode == EAnimatingMode.Off && animatingMode != EAnimatingMode.Off))
				{
					this.User_ForceMatchPhysicalBonesWithAnimator(syncPositions: true);
					Caller?.StartCoroutine(_IE_CallForFixedFrames(delegate
					{
						GetAnchorBoneController.BoneProcessor.ResetPoseParameters();
					}, 3));
					this.User_WarpRefresh();
				}
				foreach (RagdollBonesChain chain in chains)
				{
					foreach (RagdollChainBone boneSetup in chain.BoneSetups)
					{
						boneSetup.BoneProcessor.ResetPoseParameters();
					}
				}
				animatingModeChanged = true;
				_wasSleepDisable = false;
				_wasDisableUpdating = false;
			}
			_lastAnimatingMode = animatingMode;
		}

		private void CalculateRagdollBlend()
		{
			finalBlend = GetTotalBlend();
			RefreshTargetMusclesPower();
		}

		public void RefreshTargetMusclesPower()
		{
			if (User_OverrideMusclesPower.HasValue)
			{
				targetMusclesPower = User_OverrideMusclesPower.Value;
			}
			else
			{
				targetMusclesPower = MusclesPower * musclesPowerMultiplier;
			}
		}

		public void OnEnable()
		{
			if (!WasInitialized)
			{
				return;
			}
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				SwitchDummyPhysics(enable: true);
			}
			else
			{
				if (dummyContainer == null)
				{
					return;
				}
				ResetFadeInBlend();
				GetAnchorBoneController.BoneProcessor.ResetPoseParameters();
				ForcingKinematicAnchor = 2;
				GetAnchorBoneController.GameRigidbody.isKinematic = true;
				if (!dummyContainer.gameObject.activeInHierarchy)
				{
					if (UseReconstruction)
					{
						ApplyTPoseOnModel(syncTransforms: true);
					}
					fixedFramesElapsed = 0;
					fixedInitialized = false;
					dummyContainer.gameObject.SetActive(value: true);
				}
				if (!disableUpdating)
				{
					SwitchDummyPhysics(enable: true);
				}
				if (animatingMode != EAnimatingMode.Standing)
				{
					animatingModeChanged = true;
				}
				CallExtraFeaturesOnEnable();
				this.User_WarpRefresh();
			}
		}

		public void OnDisable()
		{
			if (WasInitialized)
			{
				if (RagdollLogic == ERagdollLogic.JustBoneComponents)
				{
					SwitchDummyPhysics(enable: false);
				}
				else if (!(dummyContainer == null))
				{
					SwitchDummyPhysics(enable: false);
					CallExtraFeaturesOnDisable();
				}
			}
		}

		public void OnCreatorDestroy()
		{
			if (WasInitialized && DummyWasGenerated)
			{
				UnityEngine.Object.Destroy(Dummy_Container.gameObject);
			}
		}

		public void UpdateTick()
		{
			CheckIfShouldBeUpdated();
			_wasDisableUpdating = disableUpdating;
			UpdateAnimatePhysicsVariable();
			CallExtraFeaturesAlwaysUpdateLoops();
			if (disableUpdating)
			{
				return;
			}
			CallExtraFeaturesUpdateLoops();
			if (!animatePhysics)
			{
				delta = (UnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
				CalculateRagdollBlend();
				if (fixedInitialized && Calibrate)
				{
					PreCalibrate();
				}
			}
		}

		public void LateUpdateTick()
		{
			if (disableUpdating)
			{
				return;
			}
			if (animatePhysics)
			{
				if (!scheduledFixedUpdate)
				{
					return;
				}
				scheduledFixedUpdate = false;
			}
			if (!fixedInitialized)
			{
				return;
			}
			CallExtraFeaturesPreLateUpdateLoops();
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
			{
				skeletonFillExtraBones.CaptureAnimator();
			}
			foreach (RagdollBonesChain chain in chains)
			{
				chain.CaptureAnimator();
			}
			CallExtraFeaturesLateUpdateLoops();
			CalculateFadeIn();
			ApplyAnchorBonePositionAfterAnimationCapture();
			foreach (RagdollBonesChain chain2 in chains)
			{
				chain2.ApplyPhysicalRotationsToTheSkeleton(finalBlend);
			}
			if (ApplyPositions)
			{
				for (int i = 1; i < chains[0].RuntimeBoneProcessors.Count; i++)
				{
					chains[0].RuntimeBoneProcessors[i].ApplyPhysicalPositionToTheBone(finalBlend);
				}
				for (int j = 1; j < chains.Count; j++)
				{
					chains[j].ApplyPhysicalPositionToTheSkeleton(finalBlend);
				}
			}
			UpdateAttachables();
			CallExtraFeaturesPostLateUpdateLoops();
			_motionInfluenceOffset += GetAnchorBoneController.BoneProcessor.AnimatorPosition - _lastFixedPosition;
			_lastFixedPosition = GetAnchorBoneController.BoneProcessor.AnimatorPosition;
		}

		public void FixedUpdateTick()
		{
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				return;
			}
			SwitchDummyPhysics(!disableUpdating);
			if (disableUpdating)
			{
				return;
			}
			if (fixedFramesElapsed < 2)
			{
				if (WaitForInit)
				{
					ForcingKinematicAnchor = 2;
					fixedInitialized = false;
					fixedFramesElapsed++;
					ApplyTPoseOnModel(syncTransforms: true);
					return;
				}
				fixedFramesElapsed = 3;
				this.User_ForceMatchPhysicalBonesWithAnimator(syncPositions: true);
				fixedInitialized = true;
			}
			else if (!fixedInitialized)
			{
				fixedInitialized = true;
				this.User_ForceMatchPhysicalBonesWithAnimator(syncPositions: true);
				ForcingKinematicAnchor = 0;
			}
			scheduledFixedUpdate = true;
			if (animatePhysics)
			{
				if (Calibrate)
				{
					PreCalibrate();
				}
				delta = (UnscaledTime ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime);
				CalculateRagdollBlend();
			}
			CallExtraFeaturesFixedUpdateLoops();
			FixedUpdateAnchorBone();
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
			{
				skeletonFillExtraBones.SyncWithAnimator();
			}
			UpdatePhysicalAnimationMatching();
			UpdateMotionInfluence();
			FixedUpdateAttachables();
			if (InstantConnectedMassChange)
			{
				return;
			}
			float num = Time.fixedDeltaTime * ConnectedMassTransition;
			if (animatingMode == EAnimatingMode.Falling)
			{
				num *= 4f;
			}
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (!(boneSetup.Joint == null))
					{
						boneSetup.Joint.connectedMassScale = Mathf.MoveTowards(boneSetup.Joint.connectedMassScale, boneSetup.TargetConnectedMassScale, num);
					}
				}
			}
		}

		private void ApplyAnchorBonePositionAfterAnimationCapture()
		{
			float num = finalBlend * _playmodeAnchorBone.BoneBlendMultiplier;
			if (num <= 0f)
			{
				return;
			}
			if (!_playmodeAnchorBone.GameRigidbody.isKinematic)
			{
				Vector3 position = _playmodeAnchorBone.PhysicalDummyBone.position;
				Quaternion rotation = _playmodeAnchorBone.PhysicalDummyBone.rotation;
				if (num >= 1f)
				{
					_playmodeAnchorBone.SourceBone.position = position;
					_playmodeAnchorBone.SourceBone.rotation = rotation;
					return;
				}
				position = Vector3.LerpUnclamped(_playmodeAnchorBone.SourceBone.position, position, num);
				_playmodeAnchorBone.SourceBone.position = position;
				rotation = Quaternion.SlerpUnclamped(_playmodeAnchorBone.SourceBone.rotation, rotation, num);
				_playmodeAnchorBone.SourceBone.rotation = rotation;
			}
			else if (AnimatingMode == EAnimatingMode.Standing)
			{
				_playmodeAnchorBone.SourceBone.position = _playmodeAnchorBone.PhysicalDummyBone.position;
				_playmodeAnchorBone.SourceBone.rotation = _playmodeAnchorBone.PhysicalDummyBone.rotation;
			}
			else
			{
				Vector3 position2 = Vector3.LerpUnclamped(_playmodeAnchorBone.SourceBone.position, _playmodeAnchorBone.PhysicalDummyBone.position, num);
				_playmodeAnchorBone.SourceBone.position = position2;
				Quaternion rotation2 = Quaternion.SlerpUnclamped(_playmodeAnchorBone.SourceBone.rotation, _playmodeAnchorBone.PhysicalDummyBone.rotation, num);
				_playmodeAnchorBone.SourceBone.rotation = rotation2;
			}
		}

		private void OnAnimatingModeChange()
		{
			if (AnimatingMode == EAnimatingMode.Standing)
			{
				LastStandingModeAtTime = Time.unscaledTime;
				if (UseReconstruction)
				{
					GenerateInBetweenBonesPhysics();
				}
				if ((bool)PhysicMaterialOnFall && (bool)CollidersPhysicMaterial)
				{
					this.User_ChangeAllCollidersPhysicMaterial(CollidersPhysicMaterial);
				}
			}
			else
			{
				if (UseReconstruction)
				{
					DiscardInBetweenBonesPhysics();
				}
				if ((bool)PhysicMaterialOnFall && (bool)CollidersPhysicMaterial)
				{
					this.User_ChangeAllCollidersPhysicMaterial(PhysicMaterialOnFall);
				}
				if (GetAnchorBoneController.GameRigidbody.useGravity != AnchorUseGravity)
				{
					GetAnchorBoneController.GameRigidbody.useGravity = AnchorUseGravity;
				}
			}
			ResetSleepMode();
			CallOnFallModeSwitchActions();
			_lastActionAnimatingState = AnimatingMode;
			RefreshAllChainsDynamicParameters();
			User_UpdateJointsPlayParameters(reset: false);
			RefreshAnchorKinematicState();
			animatingModeChanged = false;
		}

		private void UpdatePhysicalAnimationMatching()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollBoneProcessor runtimeBoneProcessor in chain.RuntimeBoneProcessors)
				{
					runtimeBoneProcessor.AnimationJointMatchingUpdate(chain);
				}
				bool flag = false;
				if (chain.AlternativeTensors)
				{
					flag = true;
					if (IsInFallingMode && !chain.AlternativeTensorsOnFall)
					{
						flag = false;
					}
				}
				if (flag)
				{
					chain.tensorsSwitched = true;
					foreach (RagdollBoneProcessor runtimeBoneProcessor2 in chain.RuntimeBoneProcessors)
					{
						runtimeBoneProcessor2.ApplyAlternativeTensor();
					}
				}
				else
				{
					if (!chain.tensorsSwitched)
					{
						continue;
					}
					foreach (RagdollBoneProcessor runtimeBoneProcessor3 in chain.RuntimeBoneProcessors)
					{
						runtimeBoneProcessor3.rigidbody.ResetInertiaTensor();
					}
					chain.tensorsSwitched = false;
				}
			}
			if (HardMatching <= 0f || disableHardMatching)
			{
				return;
			}
			if (AnimatingMode == EAnimatingMode.Standing)
			{
				foreach (RagdollBonesChain chain2 in chains)
				{
					foreach (RagdollBoneProcessor runtimeBoneProcessor4 in chain2.RuntimeBoneProcessors)
					{
						runtimeBoneProcessor4.StoreHardMatchFactor(chain2, HardMatching);
						runtimeBoneProcessor4.AnimationRotationHardMatchingStandUpdate(runtimeBoneProcessor4.storedHardMatch);
					}
				}
				if (!HardMatchPositions)
				{
					return;
				}
				float num = Mathf.InverseLerp(0.2f, 1f, Time.unscaledTime - LastStandingModeAtTime) * (0.7f * PositionHardMatchingMultiplier);
				if (!(num > 0f))
				{
					return;
				}
				{
					foreach (RagdollBonesChain chain3 in chains)
					{
						foreach (RagdollBoneProcessor runtimeBoneProcessor5 in chain3.RuntimeBoneProcessors)
						{
							runtimeBoneProcessor5.HardMatchBonePosition(runtimeBoneProcessor5.storedHardMatch * num);
						}
					}
					return;
				}
			}
			if (HardMatchingOnFalling <= 0f)
			{
				return;
			}
			foreach (RagdollBonesChain chain4 in chains)
			{
				foreach (RagdollBoneProcessor runtimeBoneProcessor6 in chain4.RuntimeBoneProcessors)
				{
					runtimeBoneProcessor6.StoreHardMatchFactor(chain4, HardMatchingOnFalling, targetMusclesPower);
					runtimeBoneProcessor6.AnimationRotationHardMatchingFallUpdate(runtimeBoneProcessor6.storedHardMatch);
				}
			}
			if (!HardMatchPositions || !HardMatchPositionsOnFall)
			{
				return;
			}
			foreach (RagdollBonesChain chain5 in chains)
			{
				foreach (RagdollBoneProcessor runtimeBoneProcessor7 in chain5.RuntimeBoneProcessors)
				{
					runtimeBoneProcessor7.HardMatchBonePosition(runtimeBoneProcessor7.storedHardMatch * PositionHardMatchingMultiplier);
				}
			}
		}

		public void User_UpdateJointsPlayParameters(bool reset)
		{
			float num;
			float num2;
			if (AnimatingMode == EAnimatingMode.Standing)
			{
				num = DampingValue;
				num2 = GetCurrentMainSpringsValue;
			}
			else
			{
				num = DampingValueOnFall;
				num2 = ((!OverrideSpringsValueOnFall.HasValue) ? GetCurrentMainSpringsValue : OverrideSpringsValueOnFall.Value);
			}
			RefreshTargetMusclesPower();
			float num3 = targetMusclesPower * targetMusclesPower;
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (!boneSetup.IsAnchor)
					{
						boneSetup.SetJointMatchingParameters(num3 * num2 * chain.MusclesForce * boneSetup.ForceMultiplier + boneSetup.MusclesBoost * num2 * targetMusclesPower, num * targetMusclesPower);
					}
				}
				if (!WasInitialized || chain.AlternativeTensors)
				{
					continue;
				}
				foreach (RagdollChainBone boneSetup2 in chain.BoneSetups)
				{
					boneSetup2.GameRigidbody.ResetInertiaTensor();
				}
			}
		}

		internal bool UnlimitedRotationOnStandingModeCheck()
		{
			if (AnimationMatchLimits == ERagdollNoLimitAngles.AllLimits)
			{
				return false;
			}
			if (AnimationMatchLimits == ERagdollNoLimitAngles.NoLimits)
			{
				return true;
			}
			if (AnimatingMode != EAnimatingMode.Standing)
			{
				return false;
			}
			if (AnimationMatchLimits == ERagdollNoLimitAngles.NoLimitsOnStandingMode)
			{
				return true;
			}
			return false;
		}

		internal void OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision coll)
		{
			foreach (Action<RA2BoneCollisionHandler, Collision> onCollisionEnterAction in OnCollisionEnterActions)
			{
				onCollisionEnterAction(hitted, coll);
			}
		}

		internal void OnTriggerEnterEvent(RA2BoneTriggerCollisionHandler hitted, Collider coll)
		{
			foreach (Action<RA2BoneTriggerCollisionHandler, Collider> onTriggerEnterAction in OnTriggerEnterActions)
			{
				onTriggerEnterAction(hitted, coll);
			}
		}

		private void ResetSleepMode()
		{
			_sleepDuration = 0f;
			_sleepStableTime = 0f;
		}

		private void SleepModeUpdate()
		{
			_sleepDuration += delta;
			if (_sleepDuration < 2f)
			{
				return;
			}
			float magnitude = this.User_GetChainBonesAverageTranslation(ERagdollChainType.Core).magnitude;
			float num = 1f + _sleepDuration * 0.003f;
			if (magnitude > 0.03f * num)
			{
				_sleepStableTime = 0f;
				return;
			}
			if (this.User_GetChainAngularVelocity(ERagdollChainType.Core).magnitude > 0.5f * num * this.User_CoreLowTranslationFactor(magnitude))
			{
				_sleepStableTime = 0f;
				return;
			}
			_sleepStableTime += delta;
			if (!(_sleepStableTime < 1f * Mathf.Max(0.0001f, 1f - _sleepDuration * 0.0005f)))
			{
				if (DisableMecanimOnSleep && (bool)Mecanim)
				{
					Mecanim.enabled = false;
				}
				AnimatingMode = EAnimatingMode.Off;
				_wasSleepDisable = true;
			}
		}

		public void PreCalibrate()
		{
			if (ApplyPositions)
			{
				if (IsInStandingMode)
				{
					foreach (RagdollBonesChain chain in chains)
					{
						chain.Calibrate();
					}
					return;
				}
				{
					foreach (RagdollBonesChain chain2 in chains)
					{
						foreach (RagdollBoneProcessor runtimeBoneProcessor in chain2.RuntimeBoneProcessors)
						{
							runtimeBoneProcessor.Calibrate();
						}
					}
					return;
				}
			}
			if (IsInStandingMode)
			{
				_playmodeAnchorBone.BoneProcessor.Calibrate();
				{
					foreach (RagdollBonesChain chain3 in chains)
					{
						chain3.CalibrateJustRotation();
					}
					return;
				}
			}
			foreach (RagdollBonesChain chain4 in chains)
			{
				foreach (RagdollBoneProcessor runtimeBoneProcessor2 in chain4.RuntimeBoneProcessors)
				{
					runtimeBoneProcessor2.CalibrateRotation();
				}
			}
		}

		public void RefreshAllChainsDynamicParameters()
		{
			bool isFallingOrSleep = IsFallingOrSleep;
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshDynamicPhysicalParameters(chain, isFallingOrSleep, InstantConnectedMassChange);
					boneSetup.RefreshJointLimitSwitch(chain);
				}
			}
		}

		public void RefreshAllChainsRigidbodyOptimizationParameters()
		{
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.RefreshRigidbodyOptimizationParameters(this);
				}
			}
		}

		public List<Collider> User_GetAllDummyColliders()
		{
			List<Collider> list = new List<Collider>();
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					foreach (RagdollChainBone.ColliderSetup collider in boneSetup.Colliders)
					{
						if (!(collider.GameCollider == null) && !list.Contains(collider.GameCollider))
						{
							list.Add(collider.GameCollider);
						}
					}
				}
			}
			return list;
		}

		public List<Rigidbody> User_GetDummyRigidbodies()
		{
			List<Rigidbody> list = new List<Rigidbody>();
			if (!WasInitialized)
			{
				return list;
			}
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					Rigidbody component = boneSetup.PhysicalDummyBone.GetComponent<Rigidbody>();
					if ((bool)component)
					{
						list.Add(component);
					}
				}
			}
			return list;
		}

		public void User_FindAllCollidersInsideAndIgnoreTheirCollisionWithDummyColliders(Transform root, bool ignore = true)
		{
			List<Collider> list = User_GetAllDummyColliders();
			List<Collider> list2 = new List<Collider>();
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].GetComponents(list2);
				foreach (Collider item in list2)
				{
					foreach (Collider item2 in list)
					{
						Physics.IgnoreCollision(item, item2, ignore);
					}
				}
			}
		}

		public void SwitchDummyPhysics(bool enable)
		{
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				foreach (RagdollBonesChain chain in Chains)
				{
					foreach (RagdollChainBone boneSetup in chain.BoneSetups)
					{
						Rigidbody component = boneSetup.SourceBone.GetComponent<Rigidbody>();
						component.detectCollisions = enable;
						component.isKinematic = !enable;
						Collider collider = boneSetup.SourceBone.GetComponent<Collider>();
						ConfigurableJoint component2 = boneSetup.SourceBone.GetComponent<ConfigurableJoint>();
						if ((bool)component2)
						{
							JointDrive slerpDrive = component2.slerpDrive;
							slerpDrive.positionSpring = GetCurrentMainSpringsValue;
							component2.slerpDrive = slerpDrive;
						}
						if (collider == null)
						{
							collider = boneSetup.SourceBone.GetComponentInChildren<Collider>();
						}
						if ((bool)collider)
						{
							collider.enabled = enable;
						}
					}
				}
				return;
			}
			if ((wasDummyDisabled && !enable) || (!wasDummyDisabled && enable))
			{
				return;
			}
			wasDummyDisabled = !enable;
			foreach (RagdollBonesChain chain2 in chains)
			{
				chain2.SwitchPhysics(enable);
			}
			if (enable)
			{
				RefreshAnchorKinematicState();
			}
		}

		public RaycastHit ProbeGroundBelowHips(LayerMask mask, float? distance = null, Vector3? worldUp = null)
		{
			return ProbeGroundBelow(GetAnchorBoneController, mask, distance, worldUp);
		}

		public RaycastHit ProbeGroundBelow(RagdollChainBone bone, LayerMask mask, float? distance = null, Vector3? worldUp = null)
		{
			Vector3 vector = ((!worldUp.HasValue) ? Vector3.up : worldUp.Value);
			if (!distance.HasValue)
			{
				distance = bone.MainBoneCollider.bounds.size.magnitude + 0.01f;
			}
			Physics.Raycast(new Ray(bone.PhysicalDummyBone.position, -vector), out var hitInfo, distance.Value, mask, QueryTriggerInteraction.Ignore);
			return hitInfo;
		}

		public RaycastHit ProbeGroundBelowSpherecast(RagdollChainBone bone, LayerMask mask, float radius, float? distance = null, Vector3? worldUp = null)
		{
			Vector3 vector = ((!worldUp.HasValue) ? Vector3.up : worldUp.Value);
			if (!distance.HasValue)
			{
				distance = bone.MainBoneCollider.bounds.size.magnitude + 0.01f;
			}
			Physics.SphereCast(bone.PhysicalDummyBone.position + vector * radius, radius, -vector, out var hitInfo, distance.Value + radius, mask, QueryTriggerInteraction.Ignore);
			return hitInfo;
		}

		public RaycastHit ProbeGroundBelowBoxcast(RagdollChainBone bone, LayerMask mask, Vector3 scale, Quaternion rotation, float? distance = null, Vector3? worldUp = null)
		{
			Vector3 vector = ((!worldUp.HasValue) ? Vector3.up : worldUp.Value);
			if (!distance.HasValue)
			{
				distance = bone.MainBoneCollider.bounds.size.magnitude + 0.01f;
			}
			Physics.BoxCast(bone.PhysicalDummyBone.position + vector * scale.y, scale, -vector, out var hitInfo, rotation, distance.Value + scale.y, mask, QueryTriggerInteraction.Ignore);
			return hitInfo;
		}

		public void CallOnAllRagdollBones(Action<RagdollChainBone> action)
		{
			foreach (RagdollBonesChain chain in chains)
			{
				if (chain == null)
				{
					continue;
				}
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (boneSetup != null && !(boneSetup.SourceBone == null))
					{
						action(boneSetup);
					}
				}
			}
		}

		public void CallOnAllInBetweenBones(Action<RagdollChainBone.InBetweenBone> action)
		{
			foreach (RagdollChainBone.InBetweenBone skeletonFillExtraBones in skeletonFillExtraBonesList)
			{
				if (skeletonFillExtraBones != null && !(skeletonFillExtraBones.SourceBone == null))
				{
					action(skeletonFillExtraBones);
				}
			}
		}

		public static Transform CreateTransform(string name, int targetLayer)
		{
			return new GameObject(name)
			{
				layer = targetLayer
			}.transform;
		}

		public static Transform CreateTransform(Transform copyOf)
		{
			Transform transform = CreateTransform(copyOf.name, copyOf.gameObject.layer);
			SetCoordsLike(transform, copyOf);
			return transform;
		}

		public static void ResetCoords(Transform transform, bool scaleToo = true)
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			if (scaleToo)
			{
				transform.localScale = Vector3.one;
			}
		}

		public static void SetCoordsLike(Transform toChange, Transform coordsLike)
		{
			toChange.SetPositionAndRotation(coordsLike.position, coordsLike.rotation);
			toChange.localScale = coordsLike.lossyScale;
		}

		public static void SetConfigurableJointMotionLock(ConfigurableJoint joint, ConfigurableJointMotion motion)
		{
			joint.xMotion = motion;
			joint.yMotion = motion;
			joint.zMotion = motion;
		}

		public static void SetConfigurableJointAngularMotionLock(ConfigurableJoint joint, ConfigurableJointMotion motion)
		{
			joint.angularXMotion = motion;
			joint.angularYMotion = motion;
			joint.angularZMotion = motion;
		}

		private float ComputePositionDifferenceFactor(RagdollChainBone bone, Vector3 targetPosition)
		{
			float num = Vector3.Distance(bone.GameRigidbody.position, targetPosition);
			num /= bone.MainBoneCollider.bounds.size.magnitude;
			if (num > 1f)
			{
				num = 1f;
			}
			float num2 = 1f - num;
			return num2 * num2;
		}

		public RagdollChainBone CheckIfAnyBoneCollidesWith(Collider platformCollider)
		{
			if (!_dummyIndicatorsWasPrepared)
			{
				Debug.Log("[Ragdoll Animator 2] Bone Collision Indicators Are Required (Extra Feature) to use 'CheckIfCollidesWith' !");
				return null;
			}
			foreach (RagdollBonesChain chain in chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					if (!(boneSetup.BoneProcessor.IndicatorComponent == null))
					{
						RA2BoneCollisionHandler rA2BoneCollisionHandler = boneSetup.BoneProcessor.IndicatorComponent as RA2BoneCollisionHandler;
						if (!(rA2BoneCollisionHandler == null) && rA2BoneCollisionHandler.Colliding && rA2BoneCollisionHandler.IsCollidingWith(platformCollider))
						{
							return boneSetup;
						}
					}
				}
			}
			return null;
		}

		public bool CheckIfCollidesWith(Collider platformCollider)
		{
			return CheckIfAnyBoneCollidesWith(platformCollider) != null;
		}

		internal void StoreAnchorHelperCoords()
		{
			Transform baseTransform = GetBaseTransform();
			anchorToRootLocal = GetAnchorBoneController.SourceBone.InverseTransformPoint(baseTransform.position);
			anchorToRootLocalRot = GetAnchorBoneController.SourceBone.rotation.QToLocal(baseTransform.rotation);
			foreach (RagdollBonesChain chain in Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.StoreHelperReferenceValues(baseTransform);
				}
			}
		}

		private void Debug_DrawRagdollPoseRays()
		{
			CallOnAllRagdollBones(delegate(RagdollChainBone b)
			{
				Debug.DrawLine(b.PhysicalDummyBone.position, b.PhysicalDummyBone.parent.position, Color.green, 1.01f);
			});
		}

		private void Debug_DrawAnimatorPoseRays()
		{
			CallOnAllRagdollBones(delegate(RagdollChainBone b)
			{
				Debug.DrawLine(b.SourceBone.position, b.SourceBone.parent.position, Color.blue, 1.01f);
			});
		}

		public void ApplyAllPropertiesToOtherRagdoll(RagdollHandler copyTo)
		{
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			Type[] source = new Type[2]
			{
				typeof(RagdollBonesChain),
				typeof(RagdollChainBone)
			};
			int[] source2 = new int[2]
			{
				"DummyWasGenerated".GetHashCode(),
				"LODBlend".GetHashCode()
			};
			int hashCode = "ExtraFeatures".GetHashCode();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (!source.Contains(propertyInfo.PropertyType) && !propertyInfo.PropertyType.IsAssignableFrom(typeof(Component)) && !propertyInfo.PropertyType.IsSubclassOf(typeof(Component)))
				{
					int hashCode2 = propertyInfo.Name.GetHashCode();
					if ((hashCode2 == hashCode || !propertyInfo.PropertyType.IsGenericType || !(propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))) && !source2.Contains(hashCode2) && !propertyInfo.Name.StartsWith("_Ed") && !propertyInfo.Name.StartsWith("m_") && propertyInfo.CanWrite)
					{
						object value = propertyInfo.GetValue(this);
						propertyInfo.SetValue(copyTo, value);
					}
				}
			}
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!source.Contains(fieldInfo.FieldType) && !fieldInfo.FieldType.IsAssignableFrom(typeof(Component)) && !fieldInfo.FieldType.IsSubclassOf(typeof(Component)))
				{
					int hashCode3 = fieldInfo.Name.GetHashCode();
					if ((hashCode3 == hashCode || !fieldInfo.FieldType.IsGenericType || !(fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(List<>))) && !source2.Contains(hashCode3) && !fieldInfo.Name.StartsWith("_Ed") && !fieldInfo.Name.StartsWith("m_"))
					{
						object value2 = fieldInfo.GetValue(this);
						fieldInfo.SetValue(copyTo, value2);
					}
				}
			}
		}

		private void OnChange()
		{
		}

		public float GetTotalBlend()
		{
			return RagdollBlend * CustomRagdollBlendMultiplier * LODBlend * StandUpTransitionBlend * FadeInBlend;
		}

		private void ResetFadeInBlend()
		{
			if (FadeInAnimation > 0f)
			{
				FadeInBlend = 0f;
			}
			else
			{
				FadeInBlend = 1f;
			}
		}

		private void CalculateFadeIn()
		{
			if (FadeInBlend < 1f)
			{
				FadeInBlend = Mathf.SmoothDamp(FadeInBlend, 1.01f, ref _sd_fadeIn, FadeInAnimation, 1000000f, delta);
				if (FadeInBlend > 1f)
				{
					FadeInBlend = 1f;
				}
				RefreshAllChainsDynamicParameters();
			}
		}

		public Transform GetBaseTransform()
		{
			if ((bool)BaseTransform)
			{
				return BaseTransform;
			}
			if (parentObject == null)
			{
				return null;
			}
			return parentObject.transform;
		}

		internal IEnumerator _IE_SetPhysicalImpact(Rigidbody limb, Vector3 powerDirection, float duration, ForceMode forceMode = ForceMode.Impulse, float delay = 0f, int waitFixedFrames = 0)
		{
			float elapsed = -0.0001f;
			if (waitFixedFrames > 0)
			{
				int f = 0;
				while (f < waitFixedFrames)
				{
					f++;
					yield return _fixedWait;
				}
			}
			if (delay > 0f)
			{
				yield return new WaitForSeconds(delay);
			}
			powerDirection *= GetFixedDeltaMultiplicator();
			while (elapsed < duration)
			{
				RagdollHandlerUtilities.ApplyLimbImpact(limb, powerDirection, forceMode);
				elapsed += Time.fixedDeltaTime;
				yield return _fixedWait;
			}
		}

		internal IEnumerator _IE_SetChainPhysicalImpact(RagdollBonesChain chain, Vector3 powerDirection, float duration, ForceMode forceMode = ForceMode.Impulse)
		{
			float elapsed = -0.0001f;
			powerDirection *= GetFixedDeltaMultiplicator();
			while (elapsed < duration)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					boneSetup.GameRigidbody.AddForce(powerDirection, forceMode);
				}
				elapsed += Time.fixedDeltaTime;
				yield return _fixedWait;
			}
		}

		public static float GetFixedDeltaMultiplicator()
		{
			return Time.fixedDeltaTime / 0.02f;
		}

		internal IEnumerator _IE_SetPhysicalImpactAll(Vector3 powerDirection, float duration, ForceMode forceMode = ForceMode.Impulse)
		{
			float elapsed = -0.0001f;
			powerDirection *= GetFixedDeltaMultiplicator();
			while (elapsed < duration)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					foreach (RagdollChainBone boneSetup in chain.BoneSetups)
					{
						boneSetup.GameRigidbody.AddForce(powerDirection, forceMode);
					}
				}
				elapsed += Time.fixedDeltaTime;
				yield return _fixedWait;
			}
		}

		internal IEnumerator _IE_SetPhysicalTorque(Vector3 rotationPower, float duration, bool relativeSpace = true, ForceMode forceMode = ForceMode.Impulse)
		{
			float elapsed = -0.0001f;
			rotationPower *= GetFixedDeltaMultiplicator();
			while (elapsed < duration)
			{
				foreach (RagdollBonesChain chain in chains)
				{
					foreach (RagdollChainBone boneSetup in chain.BoneSetups)
					{
						if (relativeSpace)
						{
							boneSetup.GameRigidbody.AddRelativeTorque(rotationPower, forceMode);
						}
						else
						{
							boneSetup.GameRigidbody.AddTorque(rotationPower, forceMode);
						}
					}
				}
				elapsed += Time.fixedDeltaTime;
				yield return _fixedWait;
			}
		}

		internal IEnumerator _IE_SetPhysicalTorque(Rigidbody limb, Vector3 rotationPower, float duration, bool relativeSpace = true, ForceMode forceMode = ForceMode.Impulse)
		{
			float elapsed = -0.0001f;
			rotationPower *= GetFixedDeltaMultiplicator();
			while (elapsed < duration)
			{
				if (relativeSpace)
				{
					limb.AddRelativeTorque(rotationPower, forceMode);
				}
				else
				{
					limb.AddTorque(rotationPower, forceMode);
				}
				elapsed += Time.fixedDeltaTime;
				yield return _fixedWait;
			}
		}

		internal IEnumerator _IE_FadeMusclesPower(float targetMusclesForce = 0f, float duration = 0.75f, float delay = 0f, bool disableMecanimAtEnd = false)
		{
			if (delay > 0f)
			{
				yield return new WaitForSeconds(delay);
			}
			float startMusclesForce = MusclesPower;
			float elapsed = -0.0001f;
			while (elapsed < duration)
			{
				elapsed += delta;
				if (elapsed > duration)
				{
					elapsed = duration;
				}
				MusclesPower = Mathf.LerpUnclamped(startMusclesForce, targetMusclesForce, elapsed / duration);
				User_UpdateJointsPlayParameters(reset: false);
				yield return null;
			}
			MusclesPower = targetMusclesForce;
			if (disableMecanimAtEnd && (bool)Mecanim)
			{
				Mecanim.enabled = false;
			}
		}

		internal IEnumerator _IE_FadeMusclesPowerMultiplicator(float targetMusclesForce = 0f, float duration = 0.75f, float delay = 0f)
		{
			if (delay > 0f)
			{
				yield return new WaitForSeconds(delay);
			}
			float startMusclesForce = musclesPowerMultiplier;
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += delta;
				if (elapsed > duration)
				{
					elapsed = duration;
				}
				musclesPowerMultiplier = Mathf.LerpUnclamped(startMusclesForce, targetMusclesForce, elapsed / duration);
				User_UpdateJointsPlayParameters(reset: false);
				yield return null;
			}
			musclesPowerMultiplier = targetMusclesForce;
			User_UpdateJointsPlayParameters(reset: false);
		}

		internal IEnumerator _IE_TransitionToStandingMode(float duration, float animatorFadeOffFor = 0.6f, float animatorTransitionDelay = 0.1f, float freezeSourceAnimatedHips = 0f, float delay = 0f, bool isOnLegsRestoreCall = false, float? targetMusclesPower = null, float? targetHardMatching = null)
		{
			IsStandUpCoroutineRunning = true;
			GetUpCall_StandingRestore = isOnLegsRestoreCall;
			if (delay > 0f)
			{
				yield return new WaitForSeconds(delay);
			}
			if (duration < 0f)
			{
				duration = 0f;
			}
			AnchorBoneSpringMultiplier = 0f;
			AnimatingMode = EAnimatingMode.Standing;
			LastStandingModeAtTime = Time.unscaledTime;
			StandUpTransitionBlend = 1f;
			if (freezeSourceAnimatedHips > 0f && Caller != null)
			{
				Caller.StartCoroutine(IEFreezeAnchor(freezeSourceAnimatedHips));
			}
			yield return null;
			yield return _fixedWait;
			float startMusclesForce = MusclesPower;
			float startHardMatching = HardMatchingOnFalling;
			float elapsed = -0.0001f;
			while (elapsed < duration)
			{
				if (AnimatingMode != EAnimatingMode.Standing)
				{
					StandUpTransitionBlend = 1f;
					IsStandUpCoroutineRunning = false;
					yield break;
				}
				elapsed += delta;
				float num = elapsed / duration;
				if (num > 1f)
				{
					break;
				}
				if (animatorFadeOffFor > 0f && num > animatorTransitionDelay)
				{
					if (num < animatorFadeOffFor)
					{
						StandUpTransitionBlend = Mathf.MoveTowards(StandUpTransitionBlend, 0f, delta * (1f / (duration * animatorFadeOffFor)) * 1.5f);
					}
					else
					{
						StandUpTransitionBlend = Mathf.MoveTowards(StandUpTransitionBlend, 1f, delta * (1f / (duration * animatorFadeOffFor)) * 2f);
					}
				}
				AnchorBoneSpringMultiplier = Mathf.LerpUnclamped(0f, 1f, num * num);
				if (targetMusclesPower.HasValue)
				{
					MusclesPower = Mathf.LerpUnclamped(startMusclesForce, targetMusclesPower.Value, num);
				}
				if (targetHardMatching.HasValue)
				{
					HardMatching = Mathf.LerpUnclamped(startHardMatching, targetHardMatching.Value, num);
				}
				User_UpdateJointsPlayParameters(reset: false);
				yield return null;
			}
			AnchorBoneSpringMultiplier = 1f;
			if (targetMusclesPower.HasValue)
			{
				MusclesPower = targetMusclesPower.Value;
			}
			if (targetHardMatching.HasValue)
			{
				HardMatching = targetHardMatching.Value;
			}
			if (animatorFadeOffFor > 0f)
			{
				while (StandUpTransitionBlend < 1f)
				{
					StandUpTransitionBlend = Mathf.MoveTowards(StandUpTransitionBlend, 1f, delta * (1f / (duration * animatorFadeOffFor)) * 2f);
					yield return null;
				}
			}
			IsStandUpCoroutineRunning = false;
		}

		private IEnumerator IEFreezeAnchor(float duration)
		{
			yield return null;
			RagdollChainBone getAnchorBoneController = GetAnchorBoneController;
			_hipsFreezeUpdatePosition = getAnchorBoneController.SourceBone.position;
			_hipsFreezeUpdateRotation = getAnchorBoneController.SourceBone.rotation;
			Vector3 initFreezePos = _hipsFreezeUpdatePosition;
			Quaternion initFreezeRot = _hipsFreezeUpdateRotation;
			AddToPreLateUpdateLoop(HipsFreezeUpdate);
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				float num = elapsed / duration;
				if (num > 0.5f)
				{
					num = (num - 0.5f) * 2f;
					_hipsFreezeUpdatePosition = Vector3.Lerp(initFreezePos, _hipsFreezeActivePosition, num);
					_hipsFreezeUpdateRotation = Quaternion.Slerp(initFreezeRot, _hipsFreezeActiveRotation, num);
				}
				yield return null;
			}
			RemoveFromPreLateUpdateLoop(HipsFreezeUpdate);
		}

		private void HipsFreezeUpdate()
		{
			RagdollChainBone getAnchorBoneController = GetAnchorBoneController;
			_hipsFreezeActivePosition = getAnchorBoneController.SourceBone.position;
			_hipsFreezeActiveRotation = getAnchorBoneController.SourceBone.rotation;
			getAnchorBoneController.SourceBone.SetPositionAndRotation(_hipsFreezeUpdatePosition, _hipsFreezeUpdateRotation);
		}

		public void RequestLegsBlendFor(float duration)
		{
			if (_coro_legsBlendRequest != null)
			{
				Caller.StopCoroutine(_coro_legsBlendRequest);
			}
			_coro_legsBlendRequest = Caller.StartCoroutine(IERequestLegsBlend(duration));
		}

		private IEnumerator IERequestLegsBlend(float duration)
		{
			LegsBlendInRequest = true;
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += delta;
				yield return null;
			}
			LegsBlendInRequest = false;
		}

		internal IEnumerator _IE_CallAfter(float delay, Action act, int waitExtraFixedSteps = 0)
		{
			if (waitExtraFixedSteps > 0)
			{
				for (int i = 0; i < waitExtraFixedSteps; i++)
				{
					yield return _fixedWait;
				}
			}
			if (act != null)
			{
				if (delay > 0f)
				{
					yield return new WaitForSeconds(delay);
				}
				act();
			}
		}

		internal IEnumerator _IE_CallForFixedFrames(Action act, int framesToCall = 0)
		{
			if (act != null)
			{
				for (int i = 0; i < framesToCall; i++)
				{
					act();
					yield return _fixedWait;
				}
			}
		}

		internal IEnumerator _IE_FreezeRigidbodyVelocityFor(Rigidbody rig, Vector3 velo, int framesToCall = 0)
		{
			for (int i = 0; i < framesToCall; i++)
			{
				rig.velocity = velo;
				yield return _fixedWait;
			}
		}

		internal IEnumerator _IE_RefreshBonesAfterTeleport(int frames)
		{
			int c = 0;
			while (c < frames)
			{
				GetAnchorBoneController.BoneProcessor.ResetPoseParameters();
				this.User_ForceMatchPhysicalBonesWithAnimator(syncPositions: true);
				CallOnAllRagdollBones(delegate(RagdollChainBone b)
				{
					if (!b.GameRigidbody.isKinematic)
					{
						b.GameRigidbody.velocity = Vector3.zero;
						b.GameRigidbody.angularVelocity = Vector3.zero;
					}
				});
				c++;
				yield return null;
			}
		}

		internal IEnumerator _IE_RefreshBonesAfterTeleportFixed(int frames)
		{
			int c = 0;
			while (c < frames)
			{
				GetAnchorBoneController.BoneProcessor.ResetPoseParameters();
				this.User_ForceMatchPhysicalBonesWithAnimator(syncPositions: true);
				CallOnAllRagdollBones(delegate(RagdollChainBone b)
				{
					if (!b.GameRigidbody.isKinematic)
					{
						b.GameRigidbody.velocity = Vector3.zero;
						b.GameRigidbody.angularVelocity = Vector3.zero;
					}
				});
				c++;
				yield return _fixedWait;
			}
		}

		public void HandledBy(GameObject gameObject)
		{
			if (!WasInitialized)
			{
				parentObject = gameObject;
			}
		}

		public void Initialize(MonoBehaviour caller, GameObject creator)
		{
			if (WasInitialized)
			{
				return;
			}
			BaseTransform = GetBaseTransform();
			Caller = caller;
			parentObject = creator;
			if (!IsBaseSetupValid() || !IsRagdollConstructionValid())
			{
				Debug.Log("[Ragdoll Animator 2] The Ragdoll Setup for " + creator.name + " is not valid! Component will be disabled.");
				animatingMode = EAnimatingMode.Off;
				return;
			}
			EnsureChainsHasParentHandler();
			if (RagdollLogic == ERagdollLogic.JustBoneComponents)
			{
				if (animatingMode != EAnimatingMode.Sleep)
				{
					animatingMode = EAnimatingMode.Falling;
				}
				GenerateJustSkeletonComponentsLogic();
				disableUpdating = true;
				WasInitialized = true;
				return;
			}
			WasPreGeneratedDummy = DummyWasGenerated;
			if (DummyWasGenerated)
			{
				ApplyPreGenerateDummyChanges();
			}
			else
			{
				GenerateDummyHierarchy();
			}
			_playmodeAnchorBone = GetAnchorBoneController;
			ForcingKinematicAnchor = 2;
			if (AnimatingMode == EAnimatingMode.Standing)
			{
				LastStandingModeAtTime = Time.unscaledTime;
			}
			else
			{
				animatingModeChanged = true;
			}
			_motionInfluenceOffset = Vector3.zero;
			_lastFixedPosition = GetAnchorSourceBone().position;
			_lastAnimatingMode = animatingMode;
			CalculateRagdollBlend();
			FinalizePhysicalDummySetup();
			ResetFadeInBlend();
			User_UpdateJointsPlayParameters(reset: true);
			PrepareBonesDicationaries();
			StoreAnchorHelperCoords();
			CallExtraFeaturesOnInitialize();
			if ((bool)Mecanim && !IsHumanoid)
			{
				IsHumanoid = Mecanim.isHuman;
			}
			WasInitialized = true;
		}

		private void UpdateAnimatePhysicsVariable()
		{
			if ((bool)Mecanim)
			{
				animatePhysics = Mecanim.updateMode == AnimatorUpdateMode.AnimatePhysics;
			}
			else
			{
				animatePhysics = AnimatePhysics;
			}
		}
	}
}

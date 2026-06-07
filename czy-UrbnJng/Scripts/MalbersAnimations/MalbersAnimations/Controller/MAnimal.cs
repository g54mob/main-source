using System;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller")]
	[DefaultExecutionOrder(-10)]
	[SelectionBase]
	[AddComponentMenu("Malbers/Animal Controller/Animal")]
	public class MAnimal : MonoBehaviour, IAnimatorListener, ICharacterMove, IGravity, IObjectCore, IRandomizer, IMAnimator, ISleepController, IMDamagerSet, ILockCharacter, IAnimatorStateCycle, ICharacterAction, IDeltaRootMotion
	{
		[Serializable]
		public class StateCache
		{
			public bool active = true;

			public State state;

			public int priority;
		}

		[HideInInspector]
		[SerializeField]
		private bool ShowOnPlay;

		[HideInInspector]
		[SerializeField]
		private int PivotPosDir;

		[HideInInspector]
		[SerializeField]
		private int SelectedState;

		[HideInInspector]
		[SerializeField]
		private int SelectedStance;

		[HideInInspector]
		[SerializeField]
		internal bool ShowStateInInspector;

		[HideInInspector]
		[SerializeField]
		private int Editor_Tabs1;

		[HideInInspector]
		[SerializeField]
		private int Editor_Tabs2;

		[HideInInspector]
		[SerializeField]
		private int SelectedMode;

		[HideInInspector]
		[SerializeField]
		private int Mode_Tabs1;

		[HideInInspector]
		[SerializeField]
		private int Ability_Tabs;

		[HideInInspector]
		[SerializeField]
		private int Editor_EventTabs;

		[HideInInspector]
		[SerializeField]
		private bool showPivots = true;

		[HideInInspector]
		[SerializeField]
		private bool showModeList = true;

		[HideInInspector]
		[SerializeField]
		private bool showStateList = true;

		[HideInInspector]
		[SerializeField]
		private bool ShowOnGUIData;

		[HideInInspector]
		[SerializeField]
		internal bool debugStates;

		[HideInInspector]
		[SerializeField]
		internal bool debugStances;

		[HideInInspector]
		[SerializeField]
		internal bool debugModes;

		[HideInInspector]
		[SerializeField]
		internal bool debugGizmos = true;

		[HideInInspector]
		[SerializeField]
		private int Runtime_Tabs1;

		[HideInInspector]
		[SerializeField]
		private int Runtime_Tabs2;

		public Transform t;

		private Vector3 GizmoDeltaPos = Vector3.zero;

		private bool defaultKinematic;

		private bool sameAnimTag;

		private const float zero = 0.005f;

		public bool InGroundChanger;

		internal bool GroundRootPosition = true;

		private GameObject MainFronHit;

		private bool isDebrisFront;

		private Vector3 vectorSmoothDamp = Vector3.zero;

		private float UpDownAdditive;

		private bool UsingUpDownExternal;

		private bool inTurnLimit;

		public List<StateCache> states_C = new List<StateCache>();

		public List<State> states = new List<State>();

		public List<Stance> Stances;

		public List<Mode> modes = new List<Mode>();

		internal Dictionary<int, Mode> modes_Dict;

		public Action<MAnimal> PreInput = delegate
		{
		};

		public Action<MAnimal> PreStateMovement = delegate
		{
		};

		public Action<MAnimal> PostStateMovement = delegate
		{
		};

		private List<int> animatorHashParams;

		public static List<MAnimal> Animals;

		public static MAnimal MainAnimal;

		public bool CloneStates = true;

		public StateID OverrideStartState;

		public State activeState;

		public State lastState;

		public State queueState;

		protected State Pin_State;

		public HashSet<Mode> ModeQueueInput;

		public HashSet<Ability> AbilityQueueInput;

		[SerializeField]
		public LayerReference groundLayer = new LayerReference(1);

		[Tooltip("Distance from Animal Hip to the ground. It is Recomended to use the Y value of the Hip Pivot")]
		public float height = 1f;

		public IInputSource InputSource;

		[SerializeField]
		private Vector3 center;

		[SerializeField]
		private StanceID currentStance;

		[SerializeField]
		private StanceID defaultStance;

		private StanceID StartingStance;

		[Tooltip("Global multiplier for the Animator Speed")]
		public FloatReference AnimatorSpeed = new FloatReference(1f);

		[Tooltip("Local Time Multiplier for the Animal. Cool Slowmo Stuffs")]
		public FloatReference m_TimeMultiplier = new FloatReference(1f);

		[SerializeField]
		private BoolReference alwaysForward = new BoolReference(value: false);

		[Tooltip("Sets to Zero the Z on the Movement Axis when this is set to true")]
		[SerializeField]
		private BoolReference lockForwardMovement = new BoolReference(value: false);

		[Tooltip("Sets to Zero the X on the Movement Axis when this is set to true")]
		[SerializeField]
		private BoolReference lockHorizontalMovement = new BoolReference(value: false);

		[Tooltip("Sets to Zero the Y on the Movement Axis when this is set to true")]
		[SerializeField]
		private BoolReference lockUpDownMovement = new BoolReference(value: false);

		public Vector3 MovementAxis;

		public Vector3 MovementAxisRaw;

		public Vector3 RawInputAxis;

		public Vector3 MovementAxisSmoothed;

		public Vector3 Move_Direction;

		private bool movementDetected;

		public BoolReference useCameraInput = new BoolReference(value: true);

		public BoolReference useCameraUp = new BoolReference();

		private bool usingMoveWithDirection;

		public TransformReference m_MainCamera = new TransformReference();

		[SerializeField]
		private bool additivePosLog;

		[SerializeField]
		private bool additiveRotLog;

		[ContextMenuItem("Debug AdditivePos", "DebLogAdditivePos")]
		public BoolReference isPlayer = new BoolReference(value: true);

		private Vector3 InertiaPPS;

		internal Vector3 additivePosition;

		private Quaternion additiveRotation;

		[SerializeField]
		private BoolReference SmoothVertical = new BoolReference(value: true);

		[Tooltip("Global turn multiplier to increase rotation on the animal")]
		public FloatReference TurnMultiplier = new FloatReference(0f);

		[Tooltip("Smooth Damp Value to Turn in place, when using LookAt Direction Instead of Move()")]
		public FloatReference inPlaceDamp = new FloatReference(2f);

		public FloatReference AlignPosLerp = new FloatReference(15f);

		public FloatReference AlignPosDelta = new FloatReference(2.5f);

		public FloatReference AlignRotDelta = new FloatReference(2.5f);

		public FloatReference AlignRotLerp = new FloatReference(15f);

		[Tooltip("When the Animal is grounded the Controller will check every X frame for the Ground... Higher values: better performance -> less acurancy")]
		public IntReference AlignCycle = new IntReference(1);

		[Tooltip("Tag your small rocks, debris,steps and stair objects  with this Tag. It will help the animal to recognize better the Terrain")]
		public StringReference DebrisTag = new StringReference("Stair");

		[Tooltip("Maximun and Minimun Angle on the terrain the animal can walk. If the Terrain Angle is higher than the Max value: the animal will stop moving, if is lower than the Min Value: the animal will fall")]
		[MinMaxRange(-90f, 90f)]
		public RangedFloat TerrainSlopeLimit = new RangedFloat(-50f, 45f);

		[Range(10f, 90f)]
		[Tooltip("Maximun and Minimun Angle on the terrain the animal can walk. If the Terrain Angle is higher than the Max value: the animal will slideDown")]
		public float SlopeLimit = 50f;

		[Tooltip("Angle on the terrain to start Sliding Down")]
		[Min(0f)]
		public float slideThreshold = 10f;

		[Tooltip("When the Animal gets to a Slide Because the Slope, This is the amount of pushing down")]
		public float slideAmount = 0.5f;

		[Tooltip("Damp Value to activate the sliding effect, Lower Value Faster to achieve the sliding")]
		public float slideDamp = 15f;

		public Transform Rotator;

		public Transform RootBone;

		private GameObject RotatorOffset;

		[SerializeField]
		private BoolReference grounded = new BoolReference(value: false);

		[RequiredField]
		public Animator Anim;

		[RequiredField]
		public Rigidbody RB;

		private float rb_angularDrag;

		private float rb_Drag;

		public IntReference StartWithMode = new IntReference(0);

		internal Mode activeMode;

		private bool m_IsPreparingMode;

		private int m_ModeIDAbility;

		[SerializeField]
		private BoolReference sleep = new BoolReference(value: false);

		private bool inTimeline;

		[Tooltip("Set the Animal to Kinematic when is in a Timeline")]
		public bool kinematicTimeline = true;

		public BoolEvent OnStrafe = new BoolEvent();

		[SerializeField]
		private BoolReference m_strafe = new BoolReference(value: false);

		[SerializeField]
		private BoolReference m_CanStrafe = new BoolReference(value: false);

		[SerializeField]
		private BoolReference m_StrafeNormalize = new BoolReference(value: false);

		[SerializeField]
		private FloatReference m_StrafeLerp = new FloatReference(5f);

		public Aim Aimer;

		internal RaycastHit hit_Hip;

		internal RaycastHit hit_Chest;

		public List<MPivots> pivots = new List<MPivots>();

		public MPivots Pivot_Hip;

		public MPivots Pivot_Chest;

		public bool Has_Pivot_Hip;

		public bool Has_Pivot_Chest;

		private bool Starting_PivotChest;

		public List<MSpeedSet> speedSets;

		private MSpeedSet currentSpeedSet = new MSpeedSet();

		internal MSpeedSet defaultSpeedSet = new MSpeedSet
		{
			name = "Default Set",
			Speeds = new List<MSpeed>(1)
			{
				new MSpeed("Default", 1f, 4f, 4f)
			}
		};

		public bool CustomSpeed;

		public MSpeed currentSpeedModifier = MSpeed.Default;

		public MSpeed SprintSpeed = MSpeed.Default;

		protected int speedIndex;

		private bool JustChangedSpeedSet;

		private OnEnterExitSpeed OldEnterExitSpeed;

		internal bool sprint;

		internal bool realSprint;

		[SerializeField]
		private Vector3Reference m_gravityDir = new Vector3Reference(Vector3.down);

		[SerializeField]
		private FloatReference m_gravityPower = new FloatReference(9.8f);

		private float defaultGravityPower;

		[SerializeField]
		private IntReference m_gravityTime = new IntReference(10);

		[Tooltip("Clamp Gravity Speed. Zero will ignore this")]
		[SerializeField]
		private FloatReference m_clampGravitySpeed = new FloatReference(20f);

		public BoolReference ground_Changes_Gravity = new BoolReference(value: false);

		[Range(0f, 180f)]
		[Tooltip("Slow the Animal when the Turn Angle is ouside this limit")]
		public float TurnLimit = 120f;

		private bool rootMotion = true;

		[Tooltip("Enable Disable the Rootmotion completely on th controller")]
		public BoolReference GlobalRootMotion = new BoolReference(value: true);

		public FloatReference rayCastRadius = new FloatReference(0.05f);

		public IntReference animalType = new IntReference(0);

		private bool useAdditivePos;

		private bool freemovement;

		private bool useGravity;

		private Vector3 LockMovementAxis;

		private bool useOrientToGround;

		[SerializeField]
		[Tooltip("Global Orient to ground. Disable This for Humanoids")]
		private BoolReference m_OrientToGround = new BoolReference(value: true);

		[SerializeField]
		[Tooltip("Locks Input on the Animal, Ignore inputs like Jumps, Attacks, Actions etc")]
		private BoolReference lockInput = new BoolReference(value: false);

		[SerializeField]
		[Tooltip("Locks the Movement entries on the animal. (Horizontal, Vertical,Up Down)")]
		private BoolReference lockMovement = new BoolReference(value: false);

		[SerializeField]
		private BoolReference useSprintGlobal = new BoolReference(value: true);

		internal AnimatorStateInfo m_CurrentState;

		internal AnimatorStateInfo m_NextState;

		public int currentAnimTag;

		public Transform platform;

		public List<IMDamager> Attack_Triggers;

		[Tooltip("Main Collider of the Animal Controller (Usually attached to the Root GameObject)")]
		[ContextMenuItem("Find Main Collider", "FindMainCollider")]
		public CapsuleCollider MainCollider;

		private OverrideCapsuleCollider MainCapsuleDefault;

		[Tooltip("Internal Colliders included in the Character (usually head, spine and limbs colliders)")]
		[ContextMenuItem("Find Internal Colliders", "FindInternalColliders")]
		public List<Collider> colliders = new List<Collider>();

		public IntEvent OnAnimationChange;

		public BoolEvent OnInputLocked = new BoolEvent();

		public BoolEvent OnMovementLocked = new BoolEvent();

		public BoolEvent OnSprintEnabled = new BoolEvent();

		public BoolEvent OnGrounded = new BoolEvent();

		public BoolEvent OnMovementDetected = new BoolEvent();

		public BoolEvent OnFreeMovement = new BoolEvent();

		public IntEvent OnStateProfile = new IntEvent();

		public Int2Event OnModeStart = new Int2Event();

		public Int2Event OnModeEnd = new Int2Event();

		public IntEvent OnStanceChange = new IntEvent();

		public SpeedModifierEvent OnSpeedChange = new SpeedModifierEvent();

		public Vector3Event OnTeleport = new Vector3Event();

		public Vector3Event OnPreTeleport = new Vector3Event();

		public BoolEvent OnGroundChangesGravity = new BoolEvent();

		public IntEvent OnStateActivate = new IntEvent();

		public IntEvent OnStateChange = new IntEvent();

		public List<OnEnterExitState> OnEnterExitStates;

		public List<OnEnterExitStance> OnEnterExitStances;

		public List<OnEnterExitSpeed> OnEnterExitSpeeds;

		[SerializeField]
		[Tooltip("Forward (Z) Movement for the Animator")]
		private string m_Vertical = "Vertical";

		[SerializeField]
		[Tooltip("Horizontal (X) Movement for the Animator")]
		private string m_Horizontal = "Horizontal";

		[SerializeField]
		[Tooltip("Vertical (Y) Movement for the Animator")]
		private string m_UpDown = "UpDown";

		[SerializeField]
		[Tooltip("Vertical (Y) Difference between Target and Current UpDown")]
		private string m_DeltaUpDown = "DeltaUpDown";

		[SerializeField]
		[Tooltip("Is the animal on the Ground? ")]
		private string m_Grounded = "Grounded";

		[SerializeField]
		[Tooltip("Is the animal moving?")]
		private string m_Movement = "Movement";

		[SerializeField]
		[Tooltip("Active/Current State the animal is")]
		private string m_State = "State";

		[SerializeField]
		[Tooltip("Trigger to Notify the Activation of a State")]
		private string m_StateOn = "StateOn";

		[SerializeField]
		[Tooltip("State profile to have multiple ways of playing a State")]
		private string m_StateProfile = "StateProfile";

		[SerializeField]
		[Tooltip("Trigger to Notify the Activation of a Mode")]
		private string m_ModeOn = "ModeOn";

		[SerializeField]
		[Tooltip("The Active State can have multiple status to change inside the State itself")]
		private string m_StateStatus = "StateEnterStatus";

		[SerializeField]
		[Tooltip("The Active State can use this parameter to activate exiting animations")]
		private string m_StateExitStatus = "StateExitStatus";

		[SerializeField]
		[Tooltip("Float value for the States to be used when needed")]
		private string m_StateFloat = "StateFloat";

		[SerializeField]
		[Tooltip("Last State the animal was")]
		private string m_LastState = "LastState";

		[SerializeField]
		[Tooltip("Active State Time for the States Animations")]
		private string m_StateTime = "StateTime";

		[SerializeField]
		[Tooltip("Speed Multiplier for the Animations")]
		private string m_SpeedMultiplier = "SpeedMultiplier";

		[SerializeField]
		[Tooltip("Active Mode the animal is... The Value is the Mode ID plus the Ability Index. Example Action Eat = 4002")]
		private string m_Mode = "Mode";

		[SerializeField]
		[Tooltip("Store the Modes Status (Available=0  Started=1  Looping=-1 Interrupted=-2)")]
		private string m_ModeStatus = "ModeStatus";

		[SerializeField]
		[Tooltip("Mode Float Value, Used to have a float Value for the modes to be used when needed")]
		private string m_ModePower = "ModePower";

		[SerializeField]
		[Tooltip("Sprint Value")]
		private string m_Sprint = "Sprint";

		[SerializeField]
		[Tooltip("Active/Current stance of the animal")]
		private string m_Stance = "Stance";

		[SerializeField]
		[Tooltip("Previus/Last stance of the animal")]
		private string m_LastStance = "LastStance";

		[SerializeField]
		[Tooltip("Normalized value of the Slope of the Terrain")]
		private string m_Slope = "Slope";

		[SerializeField]
		[Tooltip("Type of animal for the Additive corrective pose")]
		private string m_Type = "Type";

		[SerializeField]
		[Tooltip("Random Value for Animations States with multiple animations")]
		private string m_Random = "Random";

		[SerializeField]
		[Tooltip("Target Angle calculated from the current forward  direction to the desired direction")]
		private string m_DeltaAngle = "DeltaAngle";

		[SerializeField]
		[Tooltip("Does the Animal Uses Strafe")]
		private string m_Strafe = "Strafe";

		internal int hash_Vertical;

		internal int hash_Horizontal;

		internal int hash_UpDown;

		internal int hash_DeltaUpDown;

		internal int hash_Movement;

		internal int hash_Grounded;

		internal int hash_SpeedMultiplier;

		internal int hash_DeltaAngle;

		internal int hash_State;

		internal int hash_StateOn;

		internal int hash_StateProfile;

		internal int hash_StateEnterStatus;

		internal int hash_StateExitStatus;

		internal int hash_StateFloat;

		internal int hash_StateTime;

		internal int hash_LastState;

		internal int hash_Mode;

		internal int hash_ModeOn;

		internal int hash_ModeStatus;

		internal int hash_ModePower;

		internal int hash_Stance;

		internal int hash_LastStance;

		internal int hash_Slope;

		internal int hash_Sprint;

		internal int hash_Random;

		internal int hash_Strafe;

		public Stance Pin_Stance { get; set; }

		public int StateEnterStatus { get; set; }

		public int StateExitStatus { get; set; }

		public bool ModeNotAllowMovement
		{
			get
			{
				if (IsPlayingMode && !ActiveMode.AllowMovement)
				{
					return Grounded;
				}
				return false;
			}
		}

		public float Mode_Multiplier
		{
			get
			{
				if (!IsPlayingMode)
				{
					return 1f;
				}
				return ActiveMode.PositionMultiplier;
			}
		}

		public Vector3 TargetSpeed { get; internal set; }

		public GroundSpeedChanger GroundChanger { get; set; }

		public Vector3 DeltaPlatformPos { get; private set; }

		public Quaternion DeltaPlatformRot { get; private set; }

		public Action<int, bool> SetBoolParameter { get; set; } = delegate
		{
		};

		public Action<int, float> SetFloatParameter { get; set; } = delegate
		{
		};

		public Action<int, int> SetIntParameter { get; set; } = delegate
		{
		};

		public Action<int> SetTriggerParameter { get; set; } = delegate
		{
		};

		public Action<int> StateCycle { get; set; }

		public bool QueueReleased
		{
			get
			{
				if (QueueState != null && QueueState.OnActiveQueue)
				{
					return !QueueState.OnQueue;
				}
				return false;
			}
		}

		public State QueueState
		{
			get
			{
				return queueState;
			}
			internal set
			{
				queueState = value;
			}
		}

		public State LastState
		{
			get
			{
				return lastState;
			}
			internal set
			{
				if (!(value == null))
				{
					lastState = value;
					LastState.ExitState();
					int arg = ((QueueState == null) ? lastState.ID.ID : QueueState.ID.ID);
					SetIntParameter(hash_LastState, arg);
				}
			}
		}

		public bool JustActivateState { get; internal set; }

		public StateID ActiveStateID { get; private set; }

		public float State_Float { get; private set; }

		public State ActiveState
		{
			get
			{
				return activeState;
			}
			internal set
			{
				if (activeState == value)
				{
					currentAnimTag = 0;
				}
				bool strafe = Strafe;
				activeState = value;
				if (value == null)
				{
					return;
				}
				JustActivateState = true;
				this.Delay_Action(delegate
				{
					JustActivateState = false;
				});
				ActiveStateID = activeState.ID;
				OnStateActivate.Invoke(activeState.ID);
				SetIntParameter(hash_State, activeState.ID.ID);
				Sprint = sprint;
				TryAnimParameter(hash_StateOn);
				TryAnimParameter(hash_StateProfile, activeState.StateProfile);
				OnStateProfile.Invoke(activeState.StateProfile);
				if (strafe != Strafe)
				{
					StrafeLogic();
				}
				if (HasStances && ActiveStance != null && !ActiveStance.CanBeUsedOnState(ActiveStateID))
				{
					ActiveStance.SetPersistent(value: false);
					if (ActiveStance.OnQueueState(ActiveStateID))
					{
						ActiveStance.Queued = true;
					}
					Stance_Reset();
				}
				foreach (State state in states)
				{
					state.NewStateActivated(activeState.ID);
				}
				foreach (Stance stance in Stances)
				{
					stance.NewStateActivated(activeState.ID);
				}
				Set_Sleep_FromStates(activeState);
				Check_Queue_States(activeState.ID);
				if (IsPlayingMode && ActiveMode.StateCanInterrupt(ActiveStateID))
				{
					Mode_Interrupt();
				}
				else
				{
					CheckCacheModeInput();
				}
			}
		}

		public LayerMask GroundLayer => groundLayer.Value;

		public float Height
		{
			get
			{
				return height * ScaleFactor;
			}
			set
			{
				height = value;
			}
		}

		public float ScaleFactor => base.transform.localScale.y;

		public Vector3 Center
		{
			get
			{
				return base.transform.TransformPoint(center);
			}
			private set
			{
				center = value;
			}
		}

		public bool HasStances { get; private set; }

		public Stance ActiveStance { get; set; }

		public Stance LastActiveStance { get; set; }

		public int LastStanceID { get; private set; }

		public StanceID DefaultStanceID
		{
			get
			{
				return defaultStance;
			}
			set
			{
				defaultStance = value;
			}
		}

		public StanceID Stance
		{
			get
			{
				return currentStance;
			}
			set
			{
				if (!(value == currentStance) && !(value == null) && !(value == currentStance))
				{
					SetAdvancedStance(value);
				}
			}
		}

		public float TimeMultiplier
		{
			get
			{
				return m_TimeMultiplier.Value;
			}
			set
			{
				m_TimeMultiplier.Value = value;
			}
		}

		public Vector3 RawRotateDirAxis { get; set; }

		public bool UseRawInput { get; set; }

		public bool AlwaysForward
		{
			get
			{
				return alwaysForward.Value;
			}
			set
			{
				alwaysForward.Value = value;
				MovementAxis.z = (alwaysForward.Value ? 1 : 0);
				MovementDetected = AlwaysForward;
			}
		}

		public bool MovementDetected
		{
			get
			{
				return movementDetected;
			}
			internal set
			{
				if (movementDetected != value)
				{
					movementDetected = value;
					OnMovementDetected.Invoke(value);
					SetBoolParameter(hash_Movement, MovementDetected);
				}
			}
		}

		public bool DefaultCameraInput { get; private set; }

		public bool UseCameraUp
		{
			get
			{
				return useCameraUp.Value;
			}
			set
			{
				useCameraUp.Value = value;
			}
		}

		public bool UseCameraInput
		{
			get
			{
				return useCameraInput.Value;
			}
			set
			{
				BoolReference boolReference = useCameraInput;
				bool value2 = (UsingMoveWithDirection = value);
				boolReference.Value = value2;
			}
		}

		public bool DefaulCameraInput { get; set; }

		public bool UsingMoveWithDirection
		{
			get
			{
				return usingMoveWithDirection;
			}
			set
			{
				if (usingMoveWithDirection != value)
				{
					usingMoveWithDirection = value;
				}
			}
		}

		public bool Rotate_at_Direction { get; set; }

		public Transform MainCamera => m_MainCamera.Value;

		public Vector3 InertiaPositionSpeed
		{
			get
			{
				return InertiaPPS;
			}
			set
			{
				InertiaPPS = value;
			}
		}

		public Vector3 AdditivePosition
		{
			get
			{
				return additivePosition;
			}
			set
			{
				additivePosition = value;
			}
		}

		public Quaternion AdditiveRotation
		{
			get
			{
				return additiveRotation;
			}
			set
			{
				additiveRotation = value;
			}
		}

		public Vector3 Position
		{
			get
			{
				return t.position;
			}
			set
			{
				_ = t.position;
				t.position = value;
			}
		}

		public Vector3 LastPosition { get; internal set; }

		public Quaternion Rotation
		{
			get
			{
				return t.rotation;
			}
			set
			{
				t.rotation = value;
			}
		}

		public float AdditiveRotationMultiplier { get; set; } = 1f;

		public Vector3 DeltaPos { get; internal set; }

		public Vector3 Inertia => DeltaPos / DeltaTime;

		public Vector3 UpInertia { get; internal set; }

		public float DeltaAngle { get; internal set; }

		public Vector3 PitchDirection { get; internal set; }

		public float PitchAngle { get; internal set; }

		public float Bank { get; internal set; }

		public float VerticalSmooth
		{
			get
			{
				return MovementAxisSmoothed.z;
			}
			internal set
			{
				MovementAxisSmoothed.z = value;
			}
		}

		public float HorizontalSmooth
		{
			get
			{
				return MovementAxisSmoothed.x;
			}
			internal set
			{
				MovementAxisSmoothed.x = value;
			}
		}

		public float UpDownSmooth
		{
			get
			{
				return MovementAxisSmoothed.y;
			}
			internal set
			{
				MovementAxisSmoothed.y = value;
			}
		}

		public float DeltaUpDown { get; internal set; }

		public bool UseSmoothVertical
		{
			get
			{
				return SmoothVertical.Value;
			}
			set
			{
				SmoothVertical.Value = value;
			}
		}

		public float DeltaTime { get; private set; }

		public float AlignPosLerpDelta { get; internal set; }

		public float AlignRotLerpDelta { get; internal set; }

		public float MainPivotSlope { get; private set; }

		public Vector3 SlopeDirection { get; private set; }

		public Vector3 SlopeNormal { get; internal set; }

		public float SlopeNormalized => TerrainSlope / SlopeLimit;

		public float SlopeDirectionAngle { get; internal set; }

		public float SlopeAngleDifference { get; internal set; }

		public Vector3 SlopeDirectionSmooth { get; set; }

		public Vector3 SurfaceNormal { get; internal set; }

		public float TerrainSlope { get; private set; }

		public bool DeepSlope => SlopeDirectionAngle > SlopeLimit;

		public float HorizontalSpeed { get; internal set; }

		public Vector3 HorizontalVelocity { get; internal set; }

		public bool Grounded
		{
			get
			{
				return grounded.Value;
			}
			set
			{
				if (grounded.Value != value)
				{
					grounded.Value = value;
					if (!value)
					{
						SetPlatform(null);
						SlopeNormal = UpVector;
					}
					else
					{
						Gravity_ResetValues();
						UpInertia_Clear();
						GravityExtraPower = 1f;
						Force_Reset();
						UpDownAdditive = 0f;
						UsingUpDownExternal = false;
						GravityMultiplier = 1f;
						ExternalForceAirControl = true;
						UseGravity = false;
					}
					SetBoolParameter(hash_Grounded, grounded.Value);
					OnGrounded.Invoke(value);
				}
			}
		}

		public Vector3 ExternalForce { get; set; }

		public Vector3 CurrentExternalForce { get; set; }

		public float ExternalForceAcel { get; set; }

		public bool ExternalForceAirControl { get; set; }

		public bool HasExternalForce => ExternalForce != Vector3.zero;

		public Vector3 Up => t.up;

		public Vector3 Right => t.right;

		public Vector3 Forward => t.forward;

		public int ModeStatus { get; private set; }

		public float ModePower { get; set; }

		public bool IsPlayingMode => activeMode != null;

		public bool IsPreparingMode
		{
			get
			{
				return m_IsPreparingMode;
			}
			internal set
			{
				m_IsPreparingMode = value;
			}
		}

		public double ModeActivationTime { get; set; }

		public bool InZone => Zone != null;

		public IZone Zone { get; set; }

		public int LastModeID { get; set; }

		public int LastAbilityIndex { get; set; }

		public bool IgnoreModeGravity { get; private set; }

		public bool ModePersistentState { get; private set; }

		public bool IgnoreModeGrounded { get; private set; }

		public Mode ActiveMode
		{
			get
			{
				return activeMode;
			}
			internal set
			{
				Mode mode = activeMode;
				activeMode = value;
				ModeTime = 0f;
				if (activeMode != null)
				{
					ActiveModeID = activeMode.ID;
					OnModeStart.Invoke(ActiveModeID, activeMode.ActiveAbility.Index);
					ModeStart(activeMode.ID, activeMode.ActiveAbility.Index);
					ActiveState.OnModeStart(activeMode);
					IgnoreModeGravity = value.ActiveAbility.IgnoreGravity;
					IgnoreModeGrounded = value.ActiveAbility.IgnoreGrounded;
					ModePersistentState = value.ActiveAbility.Persistent;
				}
				else
				{
					ActiveModeID = 0;
					ResetModeOn();
					IgnoreModeGravity = false;
					IgnoreModeGrounded = false;
					ModePersistentState = false;
				}
				if (mode != null)
				{
					LastModeID = mode.ID;
					LastAbilityIndex = mode.AbilityIndex;
					OnModeEnd.Invoke(mode.ID, LastAbilityIndex);
					ModeEnd(mode.ID, LastAbilityIndex);
					ActiveState.OnModeEnd(mode);
				}
			}
		}

		public int ModeAbility
		{
			get
			{
				return m_ModeIDAbility;
			}
			set
			{
				m_ModeIDAbility = value;
				SetIntParameter(hash_Mode, m_ModeIDAbility);
			}
		}

		public float ModeTime { get; internal set; }

		public int ActiveModeID { get; private set; }

		public Mode Pin_Mode { get; private set; }

		public bool Sleep
		{
			get
			{
				return sleep.Value;
			}
			set
			{
				bool flag = Sleep;
				sleep.Value = value;
				if (!value && flag)
				{
					MTools.ResetFloatParameters(Anim);
					ResetController();
				}
				bool flag2 = (LockMovement = value);
				LockInput = flag2;
				if (Sleep)
				{
					Reset_Movement();
					TryAnimParameter(hash_Random, 0);
					if ((bool)Rotator)
					{
						Rotator.localRotation = Quaternion.identity;
					}
					Bank = 0f;
					PitchAngle = 0f;
					PitchDirection = Vector3.forward;
				}
			}
		}

		public bool InTimeline
		{
			get
			{
				return inTimeline;
			}
			set
			{
				if (value && InTimeline)
				{
					TryActivateState();
					Gravity_ResetValues();
					if ((bool)RB)
					{
						RB.isKinematic = defaultKinematic;
					}
				}
				inTimeline = value;
				if (inTimeline && kinematicTimeline && (bool)RB)
				{
					RB.isKinematic = true;
				}
			}
		}

		public bool StrafeNormalize => m_StrafeNormalize.Value;

		public bool Strafe
		{
			get
			{
				if (m_CanStrafe.Value && m_strafe.Value && (bool)ActiveStance.CanStrafe)
				{
					return ActiveState.CanStrafe;
				}
				return false;
			}
			set
			{
				if (value != m_strafe.Value)
				{
					m_strafe.Value = value;
					StrafeLogic();
				}
			}
		}

		public bool CanStrafe
		{
			get
			{
				return m_CanStrafe.Value;
			}
			set
			{
				m_CanStrafe.Value = value;
			}
		}

		public float StrafeDeltaValue { get; internal set; }

		public int AlignUniqueID { get; private set; }

		public bool MainRay { get; private set; }

		public bool FrontRay { get; private set; }

		public Vector3 Main_Pivot_Point
		{
			get
			{
				if (Has_Pivot_Chest)
				{
					return Pivot_Chest.World(t);
				}
				if (Has_Pivot_Hip)
				{
					return Pivot_Hip.World(t);
				}
				return t.TransformPoint(new Vector3(0f, Height, 0f));
			}
		}

		public bool NoPivot
		{
			get
			{
				if (!Has_Pivot_Chest)
				{
					return !Has_Pivot_Hip;
				}
				return false;
			}
		}

		public float Pivot_Multiplier { get; private set; }

		public Vector3 DesiredRBVelocity { get; internal set; }

		public Vector3 DeltaVelocity { get; internal set; }

		public bool CurrentSpeedSetIsLocked => CurrentSpeedSet.LockSpeed;

		public MSpeed CurrentSpeedModifier
		{
			get
			{
				if (CurrentSpeedSetIsLocked)
				{
					return CurrentSpeedSet.LockedSpeedModifier;
				}
				if (Sprint && !CustomSpeed)
				{
					return SprintSpeed;
				}
				return currentSpeedModifier;
			}
			internal set
			{
				currentSpeedModifier = value;
				OnSpeedChange.Invoke(CurrentSpeedModifier);
				EnterSpeedEvent(CurrentSpeedIndex);
				ActiveState?.SpeedModifierChanged(CurrentSpeedModifier, CurrentSpeedIndex);
			}
		}

		public int CurrentSpeedIndex
		{
			get
			{
				if (CurrentSpeedSetIsLocked)
				{
					return CurrentSpeedSet.LockIndex;
				}
				if (Sprint && !CustomSpeed)
				{
					return CurrentSpeedSet.SprintIndex;
				}
				return speedIndex;
			}
			internal set
			{
				if (!CustomSpeed && CurrentSpeedSet != null)
				{
					List<MSpeed> speeds = CurrentSpeedSet.Speeds;
					int num = Mathf.Clamp(value, 1, speeds.Count);
					if (num > (int)CurrentSpeedSet.TopIndex)
					{
						num = CurrentSpeedSet.TopIndex;
					}
					num = Mathf.Clamp(value, 1, num);
					speedIndex = num;
					int num2 = Mathf.Clamp(CurrentSpeedSet.SprintIndex, 1, speeds.Count);
					CurrentSpeedModifier = speeds[speedIndex - 1];
					SprintSpeed = speeds[num2 - 1];
					if (CurrentSpeedSet != null)
					{
						CurrentSpeedSet.CurrentIndex = speedIndex;
					}
				}
			}
		}

		public MSpeedSet CurrentSpeedSet
		{
			get
			{
				return currentSpeedSet;
			}
			internal set
			{
				if (value.name != currentSpeedSet.name)
				{
					SetTargetSpeed();
					currentSpeedSet = value;
					speedIndex = -1;
					JustChangedSpeedSet = true;
					CurrentSpeedIndex = currentSpeedSet.CurrentIndex;
					JustChangedSpeedSet = false;
					EnterSpeedEvent(CurrentSpeedIndex);
				}
			}
		}

		internal float SpeedMultiplier { get; set; }

		public bool Sprint
		{
			get
			{
				if (UseSprintState && sprint && UseSprint && !CurrentSpeedSetIsLocked)
				{
					return MovementDetected;
				}
				return false;
			}
			set
			{
				bool flag = UseSprintState && value && UseSprint && !CurrentSpeedSetIsLocked && MovementDetected;
				sprint = value;
				if (realSprint != flag)
				{
					realSprint = flag;
					OnSprintEnabled.Invoke(realSprint);
					TryAnimParameter(hash_Sprint, realSprint);
					int index = CurrentSpeedIndex;
					MSpeed sprintSpeed = CurrentSpeedModifier;
					if (realSprint)
					{
						sprintSpeed = SprintSpeed;
						index = CurrentSpeedSet.SprintIndex;
					}
					OnSpeedChange.Invoke(SprintSpeed);
					EnterSpeedEvent(index);
					ActiveState?.SpeedModifierChanged(sprintSpeed, index);
				}
			}
		}

		internal int CurrentCycle { get; private set; }

		public int StartGravityTime
		{
			get
			{
				return m_gravityTime.Value;
			}
			internal set
			{
				m_gravityTime.Value = value;
			}
		}

		public float ClampGravitySpeed
		{
			get
			{
				return m_clampGravitySpeed.Value;
			}
			internal set
			{
				m_clampGravitySpeed.Value = value;
			}
		}

		public float GravityMultiplier { get; internal set; }

		public float GravityTime { get; internal set; }

		public float GravityPower
		{
			get
			{
				return m_gravityPower.Value * (GravityMultiplier * ActiveState.GravityMultiplier);
			}
			set
			{
				m_gravityPower.Value = value;
			}
		}

		public Vector3 GravityStoredVelocity { get; internal set; }

		public Vector3 GravityOffset { get; internal set; }

		public float GravityExtraPower { get; internal set; }

		public Vector3 Gravity
		{
			get
			{
				return m_gravityDir.Value;
			}
			set
			{
				m_gravityDir.Value = value;
			}
		}

		public Vector3 UpVector => -m_gravityDir.Value;

		public float RayCastRadius => rayCastRadius.Value + 0.001f;

		public bool UseAdditivePos
		{
			get
			{
				return useAdditivePos;
			}
			set
			{
				useAdditivePos = value;
				if (!useAdditivePos)
				{
					ResetInertiaSpeed();
				}
			}
		}

		public bool UseAdditiveRot { get; internal set; }

		public bool UseSprintState { get; internal set; }

		public bool UseCustomRotation { get; set; }

		public bool FreeMovement
		{
			get
			{
				return freemovement;
			}
			set
			{
				if (freemovement != value)
				{
					freemovement = value;
					OnFreeMovement.Invoke(value);
				}
			}
		}

		public bool UseSprint
		{
			get
			{
				return useSprintGlobal;
			}
			set
			{
				useSprintGlobal.Value = value;
				Sprint = sprint;
			}
		}

		public bool CanSprint
		{
			get
			{
				return UseSprint;
			}
			set
			{
				UseSprint = value;
			}
		}

		public bool LockInput
		{
			get
			{
				return lockInput.Value;
			}
			set
			{
				lockInput.Value = value;
				OnInputLocked.Invoke(lockInput);
			}
		}

		public bool RootMotion
		{
			get
			{
				if (rootMotion)
				{
					return GlobalRootMotion.Value;
				}
				return false;
			}
			set
			{
				rootMotion = value;
			}
		}

		public Vector3 DeltaRootMotion { get; set; }

		public bool UseGravity
		{
			get
			{
				return useGravity;
			}
			set
			{
				useGravity = value;
				if (!useGravity)
				{
					Gravity_ResetValues();
				}
			}
		}

		public bool LockMovement
		{
			get
			{
				return lockMovement;
			}
			set
			{
				lockMovement.Value = value;
				OnMovementLocked.Invoke(lockMovement);
				if (lockMovement.Value)
				{
					Reset_Movement();
				}
			}
		}

		public bool LockForwardMovement
		{
			get
			{
				return lockForwardMovement;
			}
			set
			{
				lockForwardMovement.Value = value;
				LockMovementAxis.z = ((!value) ? 1 : 0);
			}
		}

		public bool LockHorizontalMovement
		{
			get
			{
				return lockHorizontalMovement;
			}
			set
			{
				lockHorizontalMovement.Value = value;
				LockMovementAxis.x = ((!value) ? 1 : 0);
			}
		}

		public bool LockUpDownMovement
		{
			get
			{
				return lockUpDownMovement;
			}
			set
			{
				lockUpDownMovement.Value = value;
				LockMovementAxis.y = ((!value) ? 1 : 0);
			}
		}

		public bool UseOrientToGround
		{
			get
			{
				if (useOrientToGround)
				{
					return m_OrientToGround.Value;
				}
				return false;
			}
			set
			{
				useOrientToGround = value;
			}
		}

		public bool GlobalOrientToGround
		{
			get
			{
				return m_OrientToGround.Value;
			}
			set
			{
				m_OrientToGround.Value = value;
				if (Has_Pivot_Hip)
				{
					Has_Pivot_Chest = value && Pivot_Chest != null;
				}
			}
		}

		public bool InTransition => m_NextState.fullPathHash != 0;

		public AnimatorStateInfo AnimState { get; private set; }

		public int AnimStateTag
		{
			get
			{
				return currentAnimTag;
			}
			internal set
			{
				if (value != currentAnimTag)
				{
					currentAnimTag = value;
					activeState.AnimationTagEnter(value);
				}
			}
		}

		public Vector3 Last_Platform_Pos { get; set; }

		public Quaternion Last_Platform_Rot { get; set; }

		public bool DisablePosition { get; set; }

		public bool DisableRotation { get; set; }

		public float StateTime { get; private set; }

		public Action<int> OnState { get; set; } = delegate
		{
		};

		public Action<int> OnStance { get; set; } = delegate
		{
		};

		public Action<int, int> ModeStart { get; set; } = delegate
		{
		};

		public Action<int, int> ModeEnd { get; set; } = delegate
		{
		};

		public bool IsPlayingAction => IsPlayingMode;

		public int RandomID { get; private set; }

		public int RandomPriority { get; private set; }

		public bool Randomizer { get; set; }

		Transform IAnimatorListener.transform => base.transform;

		Transform IObjectCore.transform => base.transform;

		GameObject ICharacterAction.gameObject => base.gameObject;

		public virtual void ResetInputSource()
		{
			UpdateInputSource(connect: false);
			UpdateInputSource(connect: true);
		}

		public virtual void UpdateInputSource(bool connect)
		{
			if (InputSource == null)
			{
				InputSource = base.gameObject.FindInterface<IInputSource>();
			}
			if (InputSource == null)
			{
				return;
			}
			foreach (State state in states)
			{
				state.ConnectInput(InputSource, connect);
			}
			foreach (Mode mode in modes)
			{
				mode.ConnectInput(InputSource, connect);
			}
			foreach (Stance stance in Stances)
			{
				stance.ConnectInput(InputSource, connect);
			}
		}

		public virtual void SetMainPlayer()
		{
			if ((bool)MainAnimal)
			{
				MainAnimal.isPlayer.Value = false;
			}
			isPlayer.Value = true;
			MainAnimal = this;
		}

		public virtual void DisableMainPlayer()
		{
			if (MainAnimal == this)
			{
				MainAnimal = null;
			}
		}

		public virtual void Teleport(Transform newPos)
		{
			if ((bool)newPos)
			{
				Teleport(newPos.position);
			}
		}

		public virtual void TeleportRot(Transform newPos)
		{
			if ((bool)newPos)
			{
				Rotation = newPos.rotation;
				Teleport(newPos.position);
			}
		}

		public virtual void Teleport(Vector3 newPos)
		{
			OnPreTeleport.Invoke(newPos);
			Teleport_Internal(newPos);
			OnTeleport.Invoke(newPos);
		}

		internal void Teleport_Internal(Vector3 newPos)
		{
			Position = newPos;
			LastPosition = Position;
			SetPlatform(null);
		}

		private void Debuging(string value, string color1 = "white")
		{
		}

		public virtual void Gravity_ResetDirection()
		{
			Gravity_DirectionFromGround(value: false);
		}

		public virtual void Gravity_ResetPower()
		{
			GravityPower = defaultGravityPower;
		}

		public virtual void Gravity_DirectionFromGround(bool value)
		{
			ground_Changes_Gravity.Value = value;
			OnGroundChangesGravity.Invoke(value);
			if (!value)
			{
				UseCameraInput = DefaultCameraInput;
				Gravity = Vector3.down;
			}
		}

		internal virtual void Gravity_ResetValues()
		{
			GravityTime = (int)m_gravityTime;
			GravityStoredVelocity = Vector3.zero;
			GravityOffset = Vector3.zero;
		}

		internal void ResetUPVector()
		{
			if ((bool)RB && !RB.isKinematic)
			{
				RB.velocity = Vector3.ProjectOnPlane(RB.velocity, UpVector);
			}
			AdditivePosition = Vector3.ProjectOnPlane(AdditivePosition, UpVector);
			DeltaPos = Vector3.ProjectOnPlane(DeltaPos, UpVector);
			InertiaPositionSpeed = Vector3.ProjectOnPlane(InertiaPositionSpeed, UpVector);
			DeltaVelocity = Vector3.ProjectOnPlane(DeltaVelocity, UpVector);
			Gravity_ResetValues();
		}

		public virtual void ResetGravityValues()
		{
			Gravity_ResetValues();
		}

		public virtual void ResetDeltaRootMotion()
		{
			Reset_Movement();
		}

		public virtual void AlignToGravity()
		{
			Quaternion rotation = Quaternion.FromToRotation(t.up, UpVector) * Rotation;
			Rotation = rotation;
		}

		public virtual void GroundChangesGravity(bool value)
		{
			Gravity_DirectionFromGround(value);
		}

		public virtual void Stance_Toggle(StanceID NewStance)
		{
			if (NewStance == null)
			{
				Debug.LogError("The Stance you are trying to Toggle is NULL. Please check your reference!");
			}
			else
			{
				Stance = ((Stance.ID == NewStance.ID) ? DefaultStanceID : NewStance);
			}
		}

		public virtual void Stance_Set(StanceID id)
		{
			Stance = id;
		}

		public virtual void Stance_SetPersistent(StanceID ID)
		{
			Stance stance = Stance_Get(ID);
			if (stance != null)
			{
				Stance_Set(ID);
				if (ActiveStance.ID == ID || stance.Queued)
				{
					stance.SetPersistent(value: true);
				}
			}
		}

		public virtual void Stance_ResetPersistent(StanceID ID)
		{
			Stance stance = Stance_Get(ID);
			stance?.SetPersistent(value: false);
			stance?.SetQueued(value: false);
			Stance_Reset();
		}

		public virtual void Stance_Activate(StanceID id)
		{
			Stance = id;
		}

		public virtual void Stance_SetDefault(StanceID id)
		{
			DefaultStanceID = id;
		}

		public virtual Stance Stance_Get(StanceID id)
		{
			return Pin_Stance = Stances.Find((Stance x) => x.ID == id);
		}

		public virtual void Stance_Set(int id)
		{
			Stance stance = Stances.Find((Stance x) => x.ID.ID == id);
			if (stance != null)
			{
				Stance = stance.ID;
			}
		}

		public virtual void Stance_Enable(StanceID id)
		{
			Stance_Get(id)?.Enable(value: true);
		}

		public virtual void Stance_Disable(StanceID id)
		{
			Stance_Get(id)?.Enable(value: false);
		}

		public virtual void Stance_Enable(StanceID id, bool val)
		{
			Stance_Get(id)?.Enable(val);
		}

		public virtual void Stance_Enable_Temporal(StanceID id)
		{
			Stance_Get(id)?.Disable_Temp_Restore();
		}

		public virtual void Stance_Disable_Temporal(StanceID id)
		{
			Stance_Get(id)?.Disable_Temp();
		}

		public virtual void Stance_Persistent(StanceID id, bool val)
		{
			Stance_Get(id)?.SetPersistent(val);
		}

		public virtual void Stance_PersistentOn(StanceID id)
		{
			Stance_Persistent(id, val: true);
		}

		public virtual void Stance_Activate_Persistent(StanceID id)
		{
			Stance_Get(id);
			if (Pin_Stance != null)
			{
				Stance_Set(Pin_Stance.ID);
				Pin_Stance.SetPersistent(value: true);
			}
		}

		public virtual void Stance_ResetPersistent()
		{
			ActiveStance.SetPersistent(value: false);
			Stance_Reset();
		}

		public virtual void Stance_SetLast(int id)
		{
			LastStanceID = id;
			TryAnimParameter(hash_LastStance, LastStanceID);
		}

		public virtual void LastState_Reset()
		{
			TryAnimParameter(hash_LastState, -1);
		}

		public virtual void Stance_Reset()
		{
			Stance = defaultStance;
		}

		public virtual void Stance_Reset_To_Default()
		{
			Stance_Reset();
		}

		public virtual void Stance_ResetDefaultValue()
		{
			DefaultStanceID = StartingStance;
		}

		public virtual void Stance_RestoreDefault()
		{
			DefaultStanceID = StartingStance;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			foreach (State state in states)
			{
				state.ReceiveMessages(message, value);
			}
			return this.InvokeWithParams(message, value);
		}

		public void SetAnimatorSpeed(float value)
		{
			Anim.speed = (AnimatorSpeed = value);
		}

		public virtual void SetAnimParameter(int hash, int value)
		{
			Anim.SetInteger(hash, value);
		}

		public virtual void SetAnimParameter(int hash, float value)
		{
			Anim.SetFloat(hash, value);
		}

		public virtual void SetAnimParameter(int hash, bool value)
		{
			Anim.SetBool(hash, value);
		}

		public virtual void SetAnimParameter(int hash)
		{
			Anim.SetTrigger(hash);
		}

		public virtual void ResetAnimTrigger(int hash)
		{
			Anim.ResetTrigger(hash);
		}

		public virtual void TryAnimParameter(int Hash, float value)
		{
			if (Hash != 0)
			{
				SetFloatParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash, int value)
		{
			if (Hash != 0)
			{
				SetIntParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash, bool value)
		{
			if (Hash != 0)
			{
				SetBoolParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash)
		{
			if (Hash != 0)
			{
				SetTriggerParameter(Hash);
			}
		}

		public void SetRandom(int value, int priority)
		{
			if (base.enabled && !Sleep && priority >= RandomPriority)
			{
				RandomPriority = priority;
				RandomID = (Randomizer ? value : 0);
				TryAnimParameter(hash_Random, RandomID);
			}
		}

		public void ResetRandomPriority(int priority)
		{
			if (priority >= RandomPriority)
			{
				RandomPriority = 0;
			}
		}

		public virtual void EnterTag(string tag)
		{
			AnimStateTag = Animator.StringToHash(tag);
		}

		public void State_SetFloat(float value)
		{
			State_Float = value;
			SetFloatParameter(hash_StateFloat, State_Float);
		}

		public void State_SetFloat(float value, float smoothValue)
		{
			State_Float = Mathf.Lerp(State_Float, value, smoothValue * DeltaTime);
			SetFloatParameter(hash_StateFloat, State_Float);
		}

		public void State_Replace(State NewState)
		{
			State state = states.Find((State s) => s.ID == NewState.ID);
			if (NewState == state)
			{
				state.Enable(value: true);
				return;
			}
			if (CloneStates)
			{
				State state2 = (State)ScriptableObject.CreateInstance(NewState.GetType());
				state2 = UnityEngine.Object.Instantiate(NewState);
				state2.name = state2.name.Replace("(Clone)", "(C)");
				NewState = state2;
			}
			if ((bool)state)
			{
				bool isActiveState = state.IsActiveState;
				int index = states.IndexOf(state);
				int priority = state.Priority;
				if (CloneStates)
				{
					UnityEngine.Object.Destroy(state);
				}
				state = NewState;
				state.AwakeState(this);
				state.Priority = priority;
				state.InitializeState();
				states[index] = state;
				UpdateInputSource(connect: true);
				if (isActiveState)
				{
					state.ForceActivate();
					AnimStateTag = -1;
				}
			}
		}

		public virtual void State_Force(StateID ID)
		{
			State_Force(ID.ID);
		}

		public bool HasState(StateID ID)
		{
			return HasState(ID.ID);
		}

		public bool HasState(int ID)
		{
			return State_Get(ID) != null;
		}

		public bool HasState(string statename)
		{
			return states.Exists((State s) => s.name == statename);
		}

		public virtual void State_SetEnterStatus(int status)
		{
			StateEnterStatus = status;
			SetIntParameter(hash_StateEnterStatus, status);
		}

		public virtual void State_SetStatus(int status)
		{
			State_SetEnterStatus(status);
		}

		public virtual void State_SetExitStatus(int ExitStatus)
		{
			StateExitStatus = ExitStatus;
			TryAnimParameter(hash_StateExitStatus, ExitStatus);
		}

		public virtual void State_Enable(StateID ID)
		{
			State_Enable(ID.ID);
		}

		public virtual void State_Disable(StateID ID)
		{
			State_Disable(ID.ID);
		}

		public virtual void State_Enable(int ID)
		{
			State_Get(ID)?.Enable(value: true);
			StateCache stateCache = states_C.Find((StateCache x) => (int)x.state.ID == ID);
			if (stateCache != null)
			{
				stateCache.active = true;
			}
		}

		public virtual void State_Disable(int ID)
		{
			State_Get(ID)?.Enable(value: false);
			StateCache stateCache = states_C.Find((StateCache x) => (int)x.state.ID == ID);
			if (stateCache != null)
			{
				stateCache.active = true;
			}
		}

		public virtual void ActiveState_Persisent(bool value)
		{
			ActiveState.IsPersistent = value;
		}

		public virtual void State_Force(int ID)
		{
			State_Force(ID, -1);
		}

		public virtual void State_Force(int ID, int enterStatus)
		{
			State_Get(ID)?.ForceActivate(enterStatus);
		}

		public virtual void State_AllowExit()
		{
			ActiveState.AllowExit();
		}

		public virtual void State_Allow_Exit(StateID ID)
		{
			State_Allow_Exit(ID.ID);
		}

		public virtual void State_Allow_Exit(int nextState)
		{
			if (ActiveState.AllowExit() && nextState != -1)
			{
				State_Activate(nextState);
			}
		}

		public virtual void State_Allow_Exit(int nextState, int exitStatus)
		{
			if (ActiveState.AllowExit())
			{
				State_SetExitStatus(exitStatus);
				if (nextState != -1)
				{
					State_Activate(nextState);
				}
			}
		}

		public virtual void State_Active_IsPersistent(bool value)
		{
			ActiveState.IsPersistent = value;
		}

		public virtual void State_InputTrue(StateID ID)
		{
			State_Get(ID)?.SetInput(value: true);
		}

		public virtual void State_InputFalse(StateID ID)
		{
			State_Get(ID)?.SetInput(value: false);
		}

		public virtual void State_Activate(StateID ID)
		{
			State_Activate(ID.ID);
		}

		public virtual void State_Try(StateID ID)
		{
			State_TryActivate(ID.ID);
		}

		public virtual bool State_TryActivate(int ID)
		{
			State state = State_Get(ID);
			if ((bool)state && state.CanBeActivated)
			{
				if (state.TryActivate())
				{
					return state.TryOverride;
				}
				return false;
			}
			return false;
		}

		public virtual void State_Activate(int ID)
		{
			State NewState = State_Get(ID);
			if (!NewState)
			{
				return;
			}
			if (JustActivateState)
			{
				this.Delay_Action(() => ActiveState.IsPending, delegate
				{
					CanActivateState(NewState);
				});
			}
			else
			{
				CanActivateState(NewState);
			}
			static void CanActivateState(State newState)
			{
				if (newState.CanBeActivated)
				{
					newState.Activate();
				}
			}
		}

		public virtual void State_Activate(int ID, int StateStatus)
		{
			State NewState = State_Get(ID);
			if (!NewState)
			{
				return;
			}
			if (JustActivateState)
			{
				this.Delay_Action(() => ActiveState.IsPending, delegate
				{
					CanActivateState(NewState);
				});
			}
			else
			{
				CanActivateState(NewState);
			}
			void CanActivateState(State newState)
			{
				if (newState.CanBeActivated)
				{
					newState.Activate(StateStatus);
				}
			}
		}

		public virtual State State_Get(int ID)
		{
			return states.Find((State s) => (int)s.ID == ID);
		}

		public virtual T State_Get<T>() where T : State
		{
			return states.Find((State s) => s is T) as T;
		}

		public virtual State State_Get(StateID ID)
		{
			if (ID == null)
			{
				return null;
			}
			return State_Get(ID.ID);
		}

		public virtual void State_Reset(int ID)
		{
			State_Get(ID)?.ResetState();
		}

		public virtual void State_Reset(StateID ID)
		{
			State_Reset(ID.ID);
		}

		public virtual void State_Pin(StateID stateID)
		{
			State_Pin(stateID.ID);
		}

		public virtual void State_Pin(int stateID)
		{
			Pin_State = State_Get(stateID);
		}

		public virtual void State_Pin_ByInput(bool input)
		{
			Pin_State?.ActivatebyInput(input);
		}

		public virtual void State_Pin_ByInputToggle()
		{
			Pin_State?.ActivatebyInput(!Pin_State.InputValue);
		}

		public virtual void State_Activate_by_Input(StateID stateID, bool input)
		{
			State_Activate_by_Input(stateID.ID, input);
		}

		public virtual void State_Activate_by_Input(int stateID, bool input)
		{
			State_Pin(stateID);
			State_Pin_ByInput(input);
		}

		public virtual void State_Pin_ExitStatus(int stateExitStatus)
		{
			if (Pin_State != null && Pin_State.IsActiveState)
			{
				State_SetExitStatus(stateExitStatus);
			}
		}

		public virtual T Mode_Get<T>() where T : Mode
		{
			return modes.Find((Mode s) => s is T) as T;
		}

		public bool HasMode(ModeID ID)
		{
			return HasMode(ID.ID);
		}

		public bool HasMode(int ID)
		{
			return Mode_Get(ID) != null;
		}

		public virtual Mode Mode_Get(ModeID ModeID)
		{
			if (ModeID == null)
			{
				return null;
			}
			return Mode_Get(ModeID.ID);
		}

		public virtual Mode Mode_Get(int ModeID)
		{
			if (modes_Dict == null)
			{
				CacheAllModes();
			}
			if (modes_Dict.TryGetValue(ModeID, out var value))
			{
				return value;
			}
			return null;
		}

		public virtual void Mode_SetPower(float value)
		{
			ModePower = value;
			TryAnimParameter(hash_ModePower, ModePower);
		}

		public virtual void Mode_Activate(ModeID ModeID)
		{
			Mode_Activate(ModeID.ID, -99);
		}

		public virtual void Mode_Activate(ModeID ModeID, int AbilityIndex)
		{
			Mode_Activate(ModeID.ID, AbilityIndex);
		}

		public virtual void Mode_Activate_By_Input(ModeID ModeID, bool InputValue)
		{
			Mode_Get(ModeID.ID).ActivatebyInput(InputValue);
		}

		public virtual void Mode_Activate(int ModeID)
		{
			if (ModeID != 0)
			{
				int num = Mathf.Abs(ModeID / 1000);
				int abilityIndex = ((num == 0) ? (-99) : (ModeID % 1000));
				Mode_Activate(num, abilityIndex);
			}
		}

		public virtual void Mode_Activate(int ModeID, int AbilityIndex)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				Pin_Mode.TryActivate(AbilityIndex);
			}
			else
			{
				Debug.LogWarning("You are trying to Activate a Mode but here's no Mode with the ID or is Disabled: " + ModeID);
			}
		}

		public virtual void Mode_Activate(int ModeID, int AbilityIndex, AbilityStatus status)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				Ability ability = Pin_Mode.GetAbility(AbilityIndex);
				if (ability != null)
				{
					ability.Status = status;
				}
				Pin_Mode.TryActivate(AbilityIndex);
			}
			else
			{
				Debug.LogWarning("You are trying to Activate a Mode but here's no Mode with the ID or is Disabled: " + ModeID);
			}
		}

		public virtual bool Mode_ForceActivate(ModeID ModeID, int AbilityIndex)
		{
			return Mode_ForceActivate(ModeID.ID, AbilityIndex);
		}

		public virtual void Mode_ForceActivate(ModeID ModeID)
		{
			Mode_ForceActivate(ModeID.ID, 0);
		}

		public virtual bool Mode_ForceActivate(int ModeID, int AbilityIndex)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				return Pin_Mode.ForceActivate(AbilityIndex);
			}
			return false;
		}

		public virtual bool Mode_ForceActivate(int ModeID, int AbilityIndex, AbilityStatus status, float time = 0f)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				return Pin_Mode.ForceActivate(AbilityIndex, status, time);
			}
			return false;
		}

		public virtual bool Mode_ForceActivate(int ModeID, int AbilityIndex, AbilityStatus status, float time = 0f, float power = 0f)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				Mode_SetPower(power);
				return Pin_Mode.ForceActivate(AbilityIndex, status, time);
			}
			return false;
		}

		public virtual void Mode_ForceActivate(int ModeID)
		{
			if (ModeID != 0)
			{
				int num = Mathf.Abs(ModeID / 1000);
				if (num == 0)
				{
					Mode_ForceActivate(ModeID, 0);
				}
				else
				{
					Mode_ForceActivate(num, ModeID % 1000);
				}
			}
		}

		public bool Mode_TryActivate(int ModeID, int AbilityIndex = -99)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				return Pin_Mode.TryActivate(AbilityIndex);
			}
			return false;
		}

		public bool Mode_TryActivate(int ModeID, int AbilityIndex, AbilityStatus status, float time = 0f)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Pin_Mode = mode;
				return Pin_Mode.TryActivate(AbilityIndex, status, time);
			}
			return false;
		}

		public virtual void Mode_Stop()
		{
			if (IsPlayingMode)
			{
				activeMode.InputValue = false;
				ActiveMode.ResetMode();
				Mode_Interrupt();
				ActiveMode = null;
				ModeTime = 0f;
				IsPreparingMode = false;
			}
			else
			{
				ModeAbility = 0;
				SetModeStatus(0);
			}
		}

		public virtual void SprintUpdate()
		{
			Sprint = sprint;
		}

		public virtual void Sprint_Set(bool value)
		{
			Sprint = value;
		}

		public virtual void Mode_Interrupt()
		{
			IsPreparingMode = false;
			ModeAbility = 0;
			SetModeStatus(Int_ID.Interrupted);
			ResetModeOn();
		}

		private void ResetModeOn()
		{
			if (hash_ModeOn != 0)
			{
				Anim.ResetTrigger(hash_ModeOn);
			}
		}

		public virtual void Mode_Disable_All()
		{
			foreach (Mode mode in modes)
			{
				mode.Disable();
			}
		}

		public virtual void Mode_Enable_All()
		{
			foreach (Mode mode in modes)
			{
				mode.Enable();
			}
		}

		public virtual void Mode_Disable(ModeID id)
		{
			Mode_Disable((int)id);
		}

		public virtual void Mode_Disable(int id)
		{
			Mode_Get(id)?.Disable();
		}

		public virtual void Mode_Disable(string mod)
		{
			foreach (Mode mode in modes)
			{
				if (mod.Contains(mode.Name))
				{
					mode.Disable();
				}
			}
		}

		public virtual void Mode_Enable(string mod)
		{
			foreach (Mode mode in modes)
			{
				if (mod.Contains(mode.Name))
				{
					mode.Enable();
				}
			}
		}

		public virtual void Mode_Enable(ModeID id)
		{
			Mode_Enable(id.ID);
		}

		public virtual void Mode_Enable(int id)
		{
			Mode_Get(id)?.Enable();
		}

		public virtual void Mode_Enable_Temporal(int id)
		{
			Mode_Get(id)?.Enable_Temporal();
		}

		public virtual void Mode_Enable_Temporal(ModeID id)
		{
			Mode_Enable_Temporal(id.ID);
		}

		public virtual void Mode_Disable_Temporal(ModeID id)
		{
			Mode_Disable_Temporal((int)id);
		}

		public virtual void Mode_Disable_Temporal(int id)
		{
			Mode_Get(id)?.Disable_Temporal();
		}

		public virtual void Mode_Ability_Disable(string abilityName)
		{
			foreach (Mode mode in modes)
			{
				foreach (Ability ability in mode.Abilities)
				{
					if (abilityName.Contains(ability.Name))
					{
						ability.Active = false;
					}
				}
			}
		}

		public virtual void Mode_Ability_Enable(string abilityName)
		{
			foreach (Mode mode in modes)
			{
				foreach (Ability ability in mode.Abilities)
				{
					if (abilityName.Contains(ability.Name))
					{
						ability.Active = true;
					}
				}
			}
		}

		public virtual void Mode_ActiveAbilityIndex(int Mode, int ActiveAbility)
		{
			Mode_Get(Mode).SetAbilityIndex(ActiveAbility);
		}

		public virtual void Mode_Pin(ModeID ID)
		{
			if (Pin_Mode == null || !(Pin_Mode.ID == ID))
			{
				Mode mode = Mode_Get(ID);
				Pin_Mode = null;
				if (mode != null && mode.Active)
				{
					Pin_Mode = mode;
				}
			}
		}

		public virtual void Mode_Pin_Ability(int AbilityIndex)
		{
			if (AbilityIndex != 0)
			{
				Pin_Mode?.SetAbilityIndex(AbilityIndex);
			}
		}

		public virtual bool Mode_Ability_Enable(int ModeID, int AbilityID, bool enable)
		{
			Mode mode = Mode_Get(ModeID);
			if (mode != null)
			{
				Ability ability = mode.GetAbility(AbilityID);
				if (ability != null)
				{
					ability.Active = enable;
					return true;
				}
			}
			return false;
		}

		public virtual void Mode_Pin_Ability_Enable(int AbilityIndex)
		{
			if (AbilityIndex != 0)
			{
				Ability ability = Pin_Mode?.GetAbility(AbilityIndex);
				if (ability != null)
				{
					ability.Active = true;
				}
			}
		}

		public virtual void Mode_Pin_Ability_Disable(int AbilityIndex)
		{
			if (AbilityIndex != 0)
			{
				Ability ability = Pin_Mode?.GetAbility(AbilityIndex);
				if (ability != null)
				{
					ability.Active = false;
				}
			}
		}

		public virtual void Mode_Ability_Disable(int IndexCombined)
		{
			Ability ability = Mode_AbilitybyIndexCombined(IndexCombined);
			if (ability != null)
			{
				ability.Active = false;
			}
		}

		public virtual void Mode_Ability_Enable(int IndexCombined)
		{
			Ability ability = Mode_AbilitybyIndexCombined(IndexCombined);
			if (ability != null)
			{
				ability.Active = true;
			}
		}

		public virtual Ability Mode_AbilitybyName(string name)
		{
			for (int i = 0; i < modes.Count; i++)
			{
				for (int j = 0; j < modes[i].Abilities.Count; j++)
				{
					if (modes[i].Abilities[j].Name == name)
					{
						return modes[i].Abilities[j];
					}
				}
			}
			return null;
		}

		public virtual Ability Mode_AbilitybyIndexCombined(int IndexCombined)
		{
			return modes.Find((Mode m) => (int)m.ID == IndexCombined / 1000)?.Abilities.Find((Ability ab) => (int)ab.Index == IndexCombined % 1000);
		}

		public virtual void Mode_Pin_Disable_Ability(int AbilityIndex)
		{
			Mode_Pin_Ability_Disable(AbilityIndex);
		}

		public virtual void Mode_Pin_Status(int aMode)
		{
			if (Pin_Mode == null)
			{
				return;
			}
			foreach (Ability ability in Pin_Mode.Abilities)
			{
				ability.Status = (AbilityStatus)aMode;
			}
		}

		public virtual void Mode_Pin_Time(float time)
		{
			if (Pin_Mode == null)
			{
				return;
			}
			foreach (Ability ability in Pin_Mode.Abilities)
			{
				ability.AbilityTime = time;
			}
		}

		public virtual void Mode_Pin_Enable(bool value)
		{
			Pin_Mode?.SetActive(value);
		}

		public virtual void Mode_Pin_Enable_Invert(bool value)
		{
			Pin_Mode?.SetActive(!value);
		}

		public virtual void Mode_Pin_Input(bool value)
		{
			Pin_Mode?.ActivatebyInput(value);
		}

		public virtual void Mode_Pin_Activate()
		{
			Pin_Mode?.TryActivate();
		}

		public virtual void Mode_Pin_AbilityActivate(int AbilityIndex)
		{
			Pin_Mode?.TryActivate(AbilityIndex);
		}

		public virtual void Strafe_Toggle()
		{
			Strafe = !Strafe;
		}

		public virtual void Move(Vector3 direction)
		{
			UsingMoveWithDirection = true;
			UseRawInput = false;
			Rotate_at_Direction = false;
			RawRotateDirAxis = Vector3.zero;
			DeltaAngle = 0f;
			RawInputAxis = direction;
		}

		public virtual void Move(Vector2 move)
		{
			Move(new Vector3(move.x, 0f, move.y));
		}

		public virtual void MoveWorld(Vector2 move)
		{
			MoveWorld(new Vector3(move.x, 0f, move.y));
		}

		public virtual void StopMoving()
		{
			RawInputAxis = Vector3.zero;
			RawRotateDirAxis = Vector3.zero;
			DeltaAngle = 0f;
		}

		public virtual void Reset_Movement()
		{
			float deltaAngle = (HorizontalSpeed = 0f);
			DeltaAngle = deltaAngle;
			Vector3 vector = (DeltaRootMotion = Vector3.zero);
			Vector3 vector3 = (HorizontalVelocity = vector);
			Vector3 vector5 = (DeltaPos = vector3);
			Vector3 vector7 = (TargetSpeed = vector5);
			Vector3 movementAxisSmoothed = (InertiaPositionSpeed = vector7);
			Vector3 rawInputAxis = (RawRotateDirAxis = (MovementAxisSmoothed = movementAxisSmoothed));
			RawInputAxis = rawInputAxis;
			LastPosition = Position;
		}

		public virtual void Lock(bool value)
		{
			LockInput = value;
			LockMovement = value;
		}

		public virtual void AddInertia(ref Vector3 Inertia, float speed = 1f)
		{
			AdditivePosition += Inertia;
			Inertia = Vector3.Lerp(Inertia, Vector3.zero, DeltaTime * speed);
		}

		public virtual void SpeedUp()
		{
			Speed_Add(1);
		}

		public virtual void SpeedDown()
		{
			Speed_Add(-1);
		}

		public virtual MSpeedSet SpeedSet_Get(string name)
		{
			MSpeedSet mSpeedSet = speedSets.Find((MSpeedSet x) => x.name == name);
			if (mSpeedSet == null)
			{
				foreach (State state in states)
				{
					mSpeedSet = state.SpeedSets.Find((MSpeedSet x) => x.name == name);
					if (mSpeedSet != null)
					{
						break;
					}
				}
			}
			return mSpeedSet;
		}

		public virtual MSpeed Speed_GetModifier(string name, int index)
		{
			MSpeedSet mSpeedSet = SpeedSet_Get(name);
			if (mSpeedSet != null && index < mSpeedSet.Speeds.Count)
			{
				return mSpeedSet[index - 1];
			}
			return MSpeed.Default;
		}

		public virtual void SetCustomSpeed(MSpeed customSpeed, bool keepInertiaSpeed = false)
		{
			CustomSpeed = true;
			CurrentSpeedModifier = customSpeed;
			if (keepInertiaSpeed)
			{
				SetTargetSpeed();
				InertiaPositionSpeed = TargetSpeed;
			}
		}

		private void Speed_Add(int change)
		{
			CurrentSpeedIndex += change;
		}

		public virtual void Speed_CurrentIndex_Set(int speedIndex)
		{
			CurrentSpeedIndex = speedIndex;
		}

		public virtual void Speed_CurrentIndex_Set(IntVar speedIndex)
		{
			CurrentSpeedIndex = speedIndex;
		}

		public virtual void Speed_Lock(bool lockSpeed)
		{
			CurrentSpeedSet.LockSpeed = lockSpeed;
		}

		public virtual void Speed_Lock(string SpeedSetName, bool lockSpeed)
		{
			Speed_Lock(SpeedSetName, lockSpeed, 0);
		}

		public virtual void Speed_Lock(string SpeedSetName, bool lockSpeed, int LockIndex)
		{
			MSpeedSet mSpeedSet = SpeedSet_Get(SpeedSetName);
			if (mSpeedSet != null)
			{
				if (LockIndex != 0)
				{
					mSpeedSet.LockIndex = Mathf.Clamp(LockIndex, 1, mSpeedSet.Speeds.Count);
				}
				mSpeedSet.LockSpeed = lockSpeed;
				if (lockSpeed)
				{
					OnSpeedChange.Invoke(mSpeedSet.LockedSpeedModifier);
					EnterSpeedEvent(CurrentSpeedIndex);
				}
			}
		}

		public virtual void SpeedSet_Lock(string SpeedSetName)
		{
			Speed_Lock(SpeedSetName, lockSpeed: true, 0);
		}

		public virtual void SpeedSet_Unlock(string SpeedSetName)
		{
			Speed_Lock(SpeedSetName, lockSpeed: false, 0);
		}

		public virtual void SpeedSet_Set_Active(string SpeedSetName, int activeIndex)
		{
			MSpeedSet mSpeedSet = SpeedSet_Get(SpeedSetName);
			if (mSpeedSet != null)
			{
				mSpeedSet.CurrentIndex = activeIndex;
				if (CurrentSpeedSet == mSpeedSet)
				{
					CurrentSpeedIndex = activeIndex;
					mSpeedSet.StartVerticalIndex = activeIndex;
				}
			}
			else
			{
				CurrentSpeedIndex = activeIndex;
				Debug.Log($"SpeedSet_Set_Active: {activeIndex}");
			}
		}

		public virtual void Speed_Update_Current()
		{
			CurrentSpeedIndex = CurrentSpeedIndex;
		}

		public virtual void Speed_SetTopIndex(int topIndex)
		{
			CurrentSpeedSet.TopIndex = topIndex;
			Speed_Update_Current();
		}

		public virtual void Speed_SetTopIndex(string SpeedSetName, int topIndex)
		{
			MSpeedSet mSpeedSet = SpeedSet_Get(SpeedSetName);
			if (mSpeedSet != null)
			{
				mSpeedSet.TopIndex = topIndex;
				Speed_Update_Current();
			}
		}

		public virtual void Zone_Activate()
		{
			if (!Sleep && !LockInput && InZone)
			{
				Zone.ActivateZone(this);
			}
		}

		public virtual void SpeedSet_Set_Active(string SpeedSetName, string activeSpeed)
		{
			MSpeedSet mSpeedSet = speedSets.Find((MSpeedSet x) => x.name.ToLower() == SpeedSetName.ToLower());
			if (mSpeedSet != null)
			{
				int num = mSpeedSet.Speeds.FindIndex((MSpeed x) => x.name.ToLower() == activeSpeed.ToLower());
				if (num != -1)
				{
					mSpeedSet.CurrentIndex = num + 1;
					if (CurrentSpeedSet == mSpeedSet)
					{
						CurrentSpeedIndex = num + 1;
						mSpeedSet.StartVerticalIndex = CurrentSpeedIndex;
					}
				}
			}
			else
			{
				Debug.LogWarning("There's no Speed Set called : " + SpeedSetName);
			}
		}

		public virtual void Force_Add(Vector3 Direction, float Force, float Aceleration, bool ResetGravity, bool ForceAirControl = true, float LimitForce = 0f)
		{
			Vector3 currentExternalForce = CurrentExternalForce + GravityStoredVelocity;
			if (LimitForce > 0f && currentExternalForce.magnitude > LimitForce)
			{
				currentExternalForce = currentExternalForce.normalized * LimitForce;
			}
			CurrentExternalForce = currentExternalForce;
			ExternalForce = Direction.normalized * Force;
			ExternalForceAcel = Aceleration;
			if ((int)ActiveState.ID == StateEnum.Fall)
			{
				(ActiveState as Fall).FallCurrentDistance = 0f;
			}
			if (ResetGravity)
			{
				Gravity_ResetValues();
			}
			ExternalForceAirControl = ForceAirControl;
		}

		public virtual void Force_Remove(float Aceleration = 0f)
		{
			ExternalForceAcel = Aceleration;
			ExternalForce = Vector3.zero;
		}

		internal void Force_Reset()
		{
			CurrentExternalForce = Vector3.zero;
			ExternalForce = Vector3.zero;
			ExternalForceAcel = 0f;
		}

		public virtual void DisableSelf(float time)
		{
			this.Delay_Action(time, delegate
			{
				base.enabled = false;
			});
		}

		public bool CheckIfGrounded()
		{
			AlignRayCasting();
			if (MainRay && FrontRay && !DeepSlope)
			{
				hit_Hip.distance = Height * 2f;
				return Grounded = true;
			}
			return false;
		}

		public virtual void UpInertia_Store()
		{
			UpInertia = Vector3.Project(Inertia, UpVector);
		}

		public virtual void UpInertia_Apply()
		{
			if (!(UpInertia == Vector3.zero))
			{
				Position += UpInertia * DeltaTime;
			}
		}

		public virtual void UpInertia_Clear()
		{
			UpInertia = Vector3.zero;
		}

		public bool CheckIfGrounded_Height()
		{
			AlignRayCasting(Height);
			if (MainRay && FrontRay && !DeepSlope)
			{
				return Grounded = true;
			}
			return false;
		}

		public void Always_Forward(bool value)
		{
			AlwaysForward = value;
		}

		public virtual void ActivateDamager(int ID, int prof)
		{
			if (Sleep || !base.enabled)
			{
				return;
			}
			if (ID == -1)
			{
				foreach (IMDamager attack_Trigger in Attack_Triggers)
				{
					attack_Trigger.DoDamage(value: true, prof);
				}
				return;
			}
			if (ID == 0)
			{
				foreach (IMDamager attack_Trigger2 in Attack_Triggers)
				{
					attack_Trigger2.DoDamage(value: false, prof);
				}
				return;
			}
			List<IMDamager> list = Attack_Triggers.FindAll((IMDamager x) => x.Index == ID);
			if (list == null)
			{
				return;
			}
			foreach (IMDamager item in list)
			{
				item.DoDamage(value: true, prof);
			}
		}

		public void DamagerAnimationStart(int hash)
		{
		}

		public void DamagerAnimationEnd(int hash)
		{
		}

		public void FindInternalColliders()
		{
			if (colliders != null && colliders.Count != 0)
			{
				return;
			}
			List<Collider> list = GetComponentsInChildren<Collider>(includeInactive: true).ToList();
			colliders = new List<Collider>();
			foreach (Collider item in list)
			{
				if (!(item.gameObject == base.gameObject) && !item.isTrigger)
				{
					colliders.Add(item);
				}
			}
		}

		public void FindMainCollider()
		{
			if (MainCollider == null)
			{
				MainCollider = GetComponent<CapsuleCollider>();
			}
		}

		private void SetDefaultMainColliderValues()
		{
			if ((bool)MainCollider)
			{
				MainCapsuleDefault = new OverrideCapsuleCollider(MainCollider);
			}
			MainCapsuleDefault.modify = (CapsuleModifier)(-1);
		}

		public void Reset_MainCollider()
		{
			MainCapsuleDefault.Modify(MainCollider);
		}

		public virtual void EnableColliders(bool active)
		{
			foreach (Collider collider in colliders)
			{
				if ((bool)collider && !(collider.transform == base.transform))
				{
					collider.enabled = active;
				}
			}
		}

		public virtual void DisableAnimal()
		{
			base.enabled = false;
			GetComponent<IInputSource>()?.Enable(val: false);
		}

		public void SetTimeline(bool isonTimeline)
		{
			if (debugStates)
			{
				Debug.Log($"[{base.name}] Set Timeline {isonTimeline}", this);
			}
			Sleep = isonTimeline;
			InTimeline = isonTimeline;
			RB.isKinematic = isonTimeline;
			Mode_Stop();
			if (isonTimeline)
			{
				return;
			}
			foreach (Mode mode in modes)
			{
				mode.InputValue = false;
			}
			foreach (State state in states)
			{
				state.InputValue = false;
			}
			foreach (Stance stance in Stances)
			{
				stance.InputValue = false;
			}
		}

		public void ResetInertiaSpeed()
		{
			InertiaPositionSpeed = TargetSpeed;
		}

		public void ResetInertiaSpeed(Vector3 newTargetSpeed)
		{
			Vector3 inertiaPositionSpeed = (TargetSpeed = newTargetSpeed);
			InertiaPositionSpeed = inertiaPositionSpeed;
		}

		public void UseCameraBasedInput()
		{
			UseCameraInput = true;
		}

		private void ChechUnscaledParent(Transform character)
		{
			if (!(character.parent == null))
			{
				if (character.parent.transform.localScale != Vector3.one)
				{
					Debug.LogWarning("The Character is parented to an Object with an Uneven Scale. Unparenting");
					character.parent = null;
				}
				else
				{
					ChechUnscaledParent(character.parent);
				}
			}
		}

		private void UpdateCacheState()
		{
			if (states_C != null && states_C.Count != 0 && states_C.Count == states.Count)
			{
				return;
			}
			states_C = new List<StateCache>();
			foreach (State state in states)
			{
				states_C.Add(new StateCache
				{
					active = state.Active,
					priority = state.Priority,
					state = state
				});
			}
		}

		public void UpdateRotatorParent()
		{
			Vector3 localScale = t.localScale;
			t.localScale = Vector3.one;
			if (Rotator != null)
			{
				if (RootBone == null)
				{
					if ((bool)Anim.avatar && Anim.avatar.isHuman)
					{
						RootBone = Anim.GetBoneTransform(HumanBodyBones.Hips).parent;
					}
					else
					{
						RootBone = Anim.avatarRoot;
					}
					if (RootBone == null)
					{
						Debug.LogWarning("Make sure the Root Bone is Set on the Advanced Tab -> Misc -> RootBone. This is the Character's Avatar root bone");
					}
				}
				if (RootBone != null && !RootBone.SameHierarchy(Rotator))
				{
					if (Rotator.position != RootBone.position)
					{
						RotatorOffset = new GameObject("Offset");
						RotatorOffset.transform.SetPositionAndRotation(Position, Rotation);
						RotatorOffset.layer = base.gameObject.layer;
						RotatorOffset.transform.SetParent(Rotator);
						RootBone.SetParent(RotatorOffset.transform);
						RotatorOffset.transform.localScale = Vector3.one;
					}
					else
					{
						RootBone.parent = Rotator;
					}
				}
				Rotator.gameObject.layer = base.gameObject.layer;
			}
			t.localScale = localScale;
		}

		public void Awake()
		{
			if (Anim == null)
			{
				Anim = this.FindComponent<Animator>();
			}
			if (RB == null)
			{
				RB = this.FindComponent<Rigidbody>();
			}
			if (Aimer == null)
			{
				Aimer = this.FindComponent<Aim>();
			}
			if (InputSource == null)
			{
				InputSource = this.FindInterface<IInputSource>();
			}
			DefaultCameraInput = UseCameraInput;
			t = base.transform;
			AdditivePosition = Vector3.zero;
			AdditiveRotation = Quaternion.identity;
			defaultGravityPower = m_gravityPower;
			ModeQueueInput = new HashSet<Mode>();
			AbilityQueueInput = new HashSet<Ability>();
			GroundRootPosition = true;
			ChechUnscaledParent(t);
			UpdateRotatorParent();
			GetHashIDs();
			SetPivots();
			CalculateCenter();
			foreach (MSpeedSet speedSet in speedSets)
			{
				speedSet.CurrentIndex = speedSet.StartVerticalIndex;
			}
			if ((bool)Anim)
			{
				Anim.speed = (float)AnimatorSpeed * TimeMultiplier;
				ModeBehaviour[] behaviours = Anim.GetBehaviours<ModeBehaviour>();
				if (behaviours != null)
				{
					ModeBehaviour[] array = behaviours;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].InitializeBehaviour(this);
					}
				}
				else if (modes != null && modes.Count > 0)
				{
					Debug.LogWarning("Please check your Animator Controller. There's no Mode Behaviors Attached to it. Re-import the Animator again");
				}
			}
			if (defaultStance == null)
			{
				defaultStance = ScriptableObject.CreateInstance<StanceID>();
				defaultStance.name = "Default";
				defaultStance.ID = 0;
			}
			StartingStance = defaultStance;
			FindInternalColliders();
			SetDefaultMainColliderValues();
			for (int j = 0; j < states.Count; j++)
			{
				if (!(states[j] == null))
				{
					if (CloneStates)
					{
						State state = UnityEngine.Object.Instantiate(states[j]);
						state.name = state.name.Replace("(Clone)", "(Runtime)");
						states[j] = state;
						states[j].Active = states_C[j].active;
						states[j].Priority = states_C[j].priority;
					}
					states[j].AwakeState(this);
					if (states[j].Priority == 0)
					{
						Debug.LogWarning("State [" + states[j].name + "] has priotity [0]. Please set a proper priority value", states[j]);
					}
				}
			}
			if (!CloneStates)
			{
				Debug.LogWarning("[" + base.name + "] has [ClonesStates] disabled. If multiple characters use the same states, it will cause issues. Use this only for runtime changes on a single character", this);
			}
			AwakeAllModes();
			if (Stances == null)
			{
				Stances = new List<Stance>();
			}
			HasStances = Stances.Count > 0;
			if (HasStances)
			{
				foreach (Stance stance in Stances)
				{
					stance.AwakeStance(this);
				}
				LastActiveStance = Stance_Get(DefaultStanceID);
				ActiveStance = LastActiveStance;
			}
			currentSpeedSet = defaultSpeedSet;
			AlignUniqueID = UnityEngine.Random.Range(0, 99999);
			if (CanStrafe && !Aimer)
			{
				Debug.LogWarning("This character can strafe but there's no Aim component. Please add the Aim component");
			}
			if (Anim.avatar == null)
			{
				Debug.LogWarning("There's no Avatar on the Animator", Anim);
			}
			if ((bool)RB)
			{
				defaultKinematic = RB.isKinematic;
			}
			DefaulCameraInput = UseCameraInput;
			UpdateCacheState();
			if (height == 1f)
			{
				CalculateCenter(updateHeight: true);
			}
		}

		private void AwakeAllModes()
		{
			modes_Dict = new Dictionary<int, Mode>();
			for (int i = 0; i < modes.Count; i++)
			{
				modes[i].Priority = modes.Count - i;
				modes[i].AwakeMode(this);
				modes_Dict.Add(modes[i].ID.ID, modes[i]);
			}
		}

		private void CacheAllModes()
		{
			modes_Dict = new Dictionary<int, Mode>();
			for (int i = 0; i < modes.Count; i++)
			{
				modes_Dict.Add(modes[i].ID.ID, modes[i]);
			}
		}

		public virtual void ResetController()
		{
			FindCamera();
			UpdateDamagerSet();
			if (MainCollider != null)
			{
				MainCollider.enabled = true;
			}
			GravityExtraPower = 1f;
			ModeQueueInput = new HashSet<Mode>();
			AbilityQueueInput = new HashSet<Ability>();
			LockMovement = false;
			LockInput = false;
			foreach (State state in states)
			{
				state.InitializeState();
				state.InputValue = false;
				state.ResetState();
				state.CurrentExitTime = (0f - (float)state.ExitCooldown) * 5f;
				state.EnterCooldown = (0f - (float)state.EnterCooldown) * 5f;
			}
			foreach (Stance stance in Stances)
			{
				stance.Reset();
			}
			if ((bool)RB)
			{
				RB.useGravity = false;
				RB.constraints = RigidbodyConstraints.FreezeRotation;
				RB.drag = 0f;
				RB.angularDrag = 0f;
				RB.isKinematic = defaultKinematic;
			}
			EnableColliders(active: true);
			CheckIfGrounded();
			lastState = null;
			if (states == null || states.Count == 0)
			{
				Debug.LogError("The Animal must have at least one State added", this);
				return;
			}
			if (OverrideStartState != null)
			{
				if (State_Get(OverrideStartState) != null)
				{
					State_Force(OverrideStartState);
				}
				else
				{
					OverrideStartState = null;
					CleanStateStart();
				}
			}
			else
			{
				CleanStateStart();
			}
			JustActivateState = true;
			this.Delay_Action(delegate
			{
				JustActivateState = false;
			});
			StanceID id = currentStance;
			currentStance = null;
			Stance_Set(id);
			State_SetFloat(0f);
			UsingMoveWithDirection = UseCameraInput;
			activeMode = null;
			if (IsPlayingMode)
			{
				Mode_Stop();
			}
			if (StartWithMode.Value != 0)
			{
				if (StartWithMode.Value / 1000 == 0)
				{
					Mode_Activate(StartWithMode.Value);
				}
				else
				{
					int modeID = StartWithMode.Value / 1000;
					int num = StartWithMode.Value % 1000;
					if (num == 0)
					{
						num = -99;
					}
					Mode_Activate(modeID, num);
				}
			}
			LastPosition = Position;
			GravityMultiplier = 1f;
			Vector3 vector = (SlopeDirectionSmooth = (MovementAxisSmoothed = Vector3.zero));
			Vector3 vector3 = (InertiaPositionSpeed = vector);
			Vector3 movementAxisRaw = (AdditivePosition = vector3);
			MovementAxis = (MovementAxisRaw = movementAxisRaw);
			LockMovementAxis = new Vector3((!LockHorizontalMovement) ? 1 : 0, (!LockUpDownMovement) ? 1 : 0, (!LockForwardMovement) ? 1 : 0);
			UseRawInput = true;
			UseAdditiveRot = true;
			UseAdditivePos = true;
			Grounded = true;
			Randomizer = true;
			AlwaysForward = AlwaysForward;
			StrafeLogic();
			GlobalOrientToGround = GlobalOrientToGround;
			SpeedMultiplier = 1f;
			CurrentCycle = 0;
			Gravity_ResetValues();
			int hash = TryOptionalParameter(m_Type);
			TryAnimParameter(hash, animalType);
			if ((bool)Rotator)
			{
				Rotator.localRotation = Quaternion.identity;
			}
			Bank = 0f;
			PitchAngle = 0f;
			PitchDirection = Vector3.forward;
			if (!GlobalOrientToGround)
			{
				DisablePivotChest();
			}
			void CleanStateStart()
			{
				List<State> list = states;
				activeState = list[list.Count - 1];
				ActiveStateID = activeState.ID;
				activeState.Activate();
				lastState = activeState;
				activeState.IsPending = false;
				activeState.CanExit = true;
				activeState.General.Modify(this);
				activeState.InCoreAnimation = true;
				activeState.DisableModes_Temp(disable: true, activeState.DisableModes);
			}
		}

		public virtual void FindCamera()
		{
			if (MainCamera == null)
			{
				m_MainCamera.UseConstant = true;
				Camera camera = MTools.FindMainCamera();
				if ((bool)camera)
				{
					m_MainCamera.Value = camera.transform;
				}
			}
		}

		[ContextMenu("Set Pivots")]
		public void SetPivots()
		{
			Pivot_Hip = pivots.Find((MPivots item) => item.name.ToUpper() == "HIP");
			Pivot_Chest = pivots.Find((MPivots item) => item.name.ToUpper() == "CHEST");
			Has_Pivot_Hip = Pivot_Hip != null;
			Has_Pivot_Chest = Pivot_Chest != null;
			Starting_PivotChest = Has_Pivot_Chest;
			if (Has_Pivot_Hip)
			{
				Pivot_Multiplier = Pivot_Hip.multiplier;
			}
			if (Has_Pivot_Chest)
			{
				Pivot_Multiplier = Mathf.Max(Pivot_Multiplier, Pivot_Chest.multiplier);
			}
			if (NoPivot)
			{
				Pivot_Multiplier = Height;
			}
			if (!Application.isPlaying)
			{
				MTools.SetDirty(this);
			}
		}

		public void OnEnable()
		{
			if (Animals == null)
			{
				Animals = new List<MAnimal>();
			}
			Animals.Add(this);
			ResetInputSource();
			if ((bool)isPlayer)
			{
				SetMainPlayer();
			}
			SetBoolParameter = (Action<int, bool>)Delegate.Combine(SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			SetIntParameter = (Action<int, int>)Delegate.Combine(SetIntParameter, new Action<int, int>(SetAnimParameter));
			SetFloatParameter = (Action<int, float>)Delegate.Combine(SetFloatParameter, new Action<int, float>(SetAnimParameter));
			SetTriggerParameter = (Action<int>)Delegate.Combine(SetTriggerParameter, new Action<int>(SetAnimParameter));
			if (!alwaysForward.UseConstant && alwaysForward.Variable != null)
			{
				BoolVar variable = alwaysForward.Variable;
				variable.OnValueChanged = (Action<bool>)Delegate.Combine(variable.OnValueChanged, new Action<bool>(Always_Forward));
			}
			ResetController();
			Sleep = false;
		}

		public void OnDisable()
		{
			Animals?.Remove(this);
			UpdateInputSource(connect: false);
			DisableMainPlayer();
			MTools.ResetFloatParameters(Anim);
			if ((bool)RB && !RB.isKinematic)
			{
				RB.velocity = Vector3.zero;
			}
			if (!alwaysForward.UseConstant && alwaysForward.Variable != null)
			{
				BoolVar variable = alwaysForward.Variable;
				variable.OnValueChanged = (Action<bool>)Delegate.Remove(variable.OnValueChanged, new Action<bool>(Always_Forward));
			}
			if (states != null)
			{
				foreach (State state in states)
				{
					if (state != null)
					{
						state.ExitState();
					}
				}
			}
			if (IsPlayingMode)
			{
				ActiveMode?.ResetMode();
				Mode_Stop();
			}
			OverrideStartState = ActiveStateID;
			ActiveState?.EnterExitEvent?.OnExit.Invoke();
			SetBoolParameter = (Action<int, bool>)Delegate.Remove(SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			SetIntParameter = (Action<int, int>)Delegate.Remove(SetIntParameter, new Action<int, int>(SetAnimParameter));
			SetFloatParameter = (Action<int, float>)Delegate.Remove(SetFloatParameter, new Action<int, float>(SetAnimParameter));
			SetTriggerParameter = (Action<int>)Delegate.Remove(SetTriggerParameter, new Action<int>(SetAnimParameter));
			StopAllCoroutines();
		}

		public void CalculateCenter(bool updateHeight = false)
		{
			if (Has_Pivot_Hip)
			{
				if (updateHeight)
				{
					height = Pivot_Hip.position.y;
				}
				Center = Pivot_Hip.position;
			}
			else if (Has_Pivot_Chest)
			{
				if (updateHeight)
				{
					height = Pivot_Chest.position.y;
				}
				Center = Pivot_Chest.position;
			}
			if (Has_Pivot_Chest && Has_Pivot_Hip)
			{
				Center = (Pivot_Chest.position + Pivot_Hip.position) / 2f;
			}
			center.y = 0f;
			if (!Application.isPlaying)
			{
				MTools.SetDirty(this);
			}
		}

		public void UpdateDamagerSet()
		{
			Attack_Triggers = GetComponentsInChildren<IMDamager>(includeInactive: true).ToList();
			foreach (IMDamager attack_Trigger in Attack_Triggers)
			{
				attack_Trigger.Owner = base.gameObject;
			}
		}

		protected virtual void GetHashIDs()
		{
			if (!(Anim == null))
			{
				animatorHashParams = new List<int>();
				AnimatorControllerParameter[] parameters = Anim.parameters;
				foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
				{
					animatorHashParams.Add(animatorControllerParameter.nameHash);
				}
				hash_Vertical = Animator.StringToHash(m_Vertical);
				hash_Horizontal = Animator.StringToHash(m_Horizontal);
				hash_SpeedMultiplier = Animator.StringToHash(m_SpeedMultiplier);
				hash_Movement = Animator.StringToHash(m_Movement);
				hash_Grounded = Animator.StringToHash(m_Grounded);
				hash_State = Animator.StringToHash(m_State);
				hash_StateEnterStatus = Animator.StringToHash(m_StateStatus);
				hash_LastState = Animator.StringToHash(m_LastState);
				hash_StateFloat = Animator.StringToHash(m_StateFloat);
				hash_Mode = Animator.StringToHash(m_Mode);
				hash_ModeStatus = Animator.StringToHash(m_ModeStatus);
				hash_ModeOn = Animator.StringToHash(m_ModeOn);
				hash_StateOn = Animator.StringToHash(m_StateOn);
				hash_StateExitStatus = TryOptionalParameter(m_StateExitStatus);
				hash_SpeedMultiplier = TryOptionalParameter(m_SpeedMultiplier);
				hash_UpDown = TryOptionalParameter(m_UpDown);
				hash_DeltaUpDown = TryOptionalParameter(m_DeltaUpDown);
				hash_Slope = TryOptionalParameter(m_Slope);
				hash_DeltaAngle = TryOptionalParameter(m_DeltaAngle);
				hash_Sprint = TryOptionalParameter(m_Sprint);
				hash_StateTime = TryOptionalParameter(m_StateTime);
				hash_Strafe = TryOptionalParameter(m_Strafe);
				hash_Stance = TryOptionalParameter(m_Stance);
				hash_LastStance = TryOptionalParameter(m_LastStance);
				hash_Random = TryOptionalParameter(m_Random);
				hash_ModePower = TryOptionalParameter(m_ModePower);
				hash_StateProfile = TryOptionalParameter(m_StateProfile);
			}
		}

		private int TryOptionalParameter(string param)
		{
			int num = Animator.StringToHash(param);
			if (!animatorHashParams.Contains(num))
			{
				return 0;
			}
			return num;
		}

		protected virtual void CacheAnimatorState()
		{
			m_CurrentState = Anim.GetCurrentAnimatorStateInfo(0);
			m_NextState = Anim.GetNextAnimatorStateInfo(0);
			if (m_NextState.fullPathHash != 0)
			{
				if (m_CurrentState.fullPathHash != AnimState.fullPathHash && m_CurrentState.tagHash == m_NextState.tagHash)
				{
					if (!sameAnimTag)
					{
						sameAnimTag = true;
						currentAnimTag = -1;
					}
				}
				else
				{
					sameAnimTag = false;
				}
				AnimStateTag = m_NextState.tagHash;
				AnimState = m_NextState;
			}
			else
			{
				if (m_CurrentState.fullPathHash != AnimState.fullPathHash)
				{
					AnimStateTag = m_CurrentState.tagHash;
				}
				AnimState = m_CurrentState;
			}
			float stateTime = StateTime;
			StateTime = Mathf.Repeat(AnimState.normalizedTime, 1f);
			if (stateTime > StateTime)
			{
				StateCycle?.Invoke(ActiveStateID);
			}
		}

		internal virtual void UpdateAnimatorParameters()
		{
			SetFloatParameter(hash_Vertical, VerticalSmooth);
			SetFloatParameter(hash_Horizontal, HorizontalSmooth);
			TryAnimParameter(hash_UpDown, UpDownSmooth);
			TryAnimParameter(hash_DeltaUpDown, DeltaUpDown);
			TryAnimParameter(hash_DeltaAngle, DeltaAngle);
			TryAnimParameter(hash_Slope, SlopeNormalized);
			TryAnimParameter(hash_SpeedMultiplier, SpeedMultiplier);
			TryAnimParameter(hash_StateTime, StateTime);
		}

		private void MoveRotator()
		{
			if (!FreeMovement && (bool)Rotator)
			{
				if (PitchAngle != 0f || Bank != 0f)
				{
					float num = 0.005f;
					float num2 = DeltaTime * (float)CurrentSpeedSet.PitchLerpOff;
					Rotator.localRotation = Quaternion.Slerp(Rotator.localRotation, Quaternion.identity, num2);
					PitchAngle = Mathf.Lerp(PitchAngle, 0f, num2);
					Bank = Mathf.Lerp(Bank, 0f, num2);
					if (Mathf.Abs(PitchAngle) < num && Mathf.Abs(Bank) < num)
					{
						float bank = (PitchAngle = 0f);
						Bank = bank;
						Rotator.localRotation = Quaternion.identity;
					}
				}
			}
			else
			{
				CalculatePitchDirectionVector();
			}
		}

		public virtual void FreeMovementRotator(float Ylimit, float bank)
		{
			CalculatePitch(Ylimit);
			CalculateBank(bank);
			CalculateRotator();
		}

		internal virtual void CalculateRotator()
		{
			if ((bool)Rotator)
			{
				Rotator.localEulerAngles = new Vector3(PitchAngle, 0f, Bank);
			}
		}

		internal virtual void CalculateBank(float bank)
		{
			Bank = Mathf.Lerp(Bank, (0f - bank) * Mathf.Clamp(HorizontalSmooth, -1f, 1f), DeltaTime * (float)CurrentSpeedSet.BankLerp);
		}

		internal virtual void CalculatePitch(float Pitch)
		{
			float num = 0f;
			if (MovementAxis != Vector3.zero)
			{
				num = 90f - Vector3.Angle(UpVector, PitchDirection);
				num = Mathf.Clamp(0f - num, 0f - Pitch, Pitch);
			}
			float num2 = DeltaTime * (float)CurrentSpeedSet.PitchLerpOn;
			PitchAngle = Mathf.Lerp(PitchAngle, Strafe ? (Pitch * VerticalSmooth) : num, num2);
			DeltaUpDown = Mathf.Lerp(DeltaUpDown, 0f - Mathf.DeltaAngle(PitchAngle, num), num2 * 2f);
			if (Mathf.Abs(DeltaUpDown) < 0.01f)
			{
				DeltaUpDown = 0f;
			}
		}

		internal virtual void CalculatePitchDirectionVector()
		{
			Vector3 b = ((Move_Direction != Vector3.zero) ? Move_Direction : Forward);
			PitchDirection = Vector3.Lerp(PitchDirection, b, DeltaTime * (float)CurrentSpeedSet.PitchLerpOn * 2f);
		}

		public void SetTargetSpeed()
		{
			if (!UseAdditivePos || ModeNotAllowMovement)
			{
				TargetSpeed = Vector3.zero;
				return;
			}
			Vector3 vector = ActiveState.Speed_Direction();
			if (Has_Pivot_Chest && !Has_Pivot_Hip)
			{
				vector = Quaternion.FromToRotation(Up, SlopeNormal) * vector;
			}
			float num = (Strafe ? CurrentSpeedModifier.strafeSpeed.Value : CurrentSpeedModifier.position.Value);
			if (InGroundChanger)
			{
				float num2 = (RootMotion ? (Anim.deltaPosition / DeltaTime).magnitude : 0f);
				num = num + GroundChanger.Position + num2;
			}
			if (Strafe)
			{
				vector = Forward * VerticalSmooth + Right * HorizontalSmooth;
				if (FreeMovement)
				{
					vector += Up * UpDownSmooth;
				}
			}
			else
			{
				if (VerticalSmooth < 0f && CurrentSpeedSet != null)
				{
					vector *= 0f - CurrentSpeedSet.BackSpeedMult.Value;
					num = CurrentSpeedSet[0].position;
					if (InGroundChanger)
					{
						float num3 = (RootMotion ? (Anim.deltaPosition / DeltaTime).magnitude : 0f);
						num = num + GroundChanger.Position + num3;
					}
				}
				if (FreeMovement)
				{
					float num4 = Mathf.Clamp01(Mathf.Max(Mathf.Abs(UpDownSmooth), Mathf.Abs(VerticalSmooth)));
					vector *= num4;
				}
				else
				{
					vector *= VerticalSmooth;
				}
			}
			if (vector.magnitude > 1f)
			{
				vector.Normalize();
			}
			TargetSpeed = DeltaTime * Mode_Multiplier * ScaleFactor * num * vector;
			HorizontalVelocity = Vector3.ProjectOnPlane(Inertia + SlopeDirectionSmooth, SlopeNormal);
			HorizontalSpeed = HorizontalVelocity.magnitude;
			if (debugGizmos)
			{
				MDebug.Draw_Arrow(Position + GizmoDeltaPos, TargetSpeed, Color.green);
			}
		}

		protected virtual void AdditionalSpeed(float time)
		{
			MSpeed mSpeed = CurrentSpeedModifier;
			FloatReference floatReference = (Strafe ? mSpeed.lerpStrafe : mSpeed.lerpPosition);
			if (InGroundChanger)
			{
				floatReference = GroundChanger.Lerp;
			}
			InertiaPositionSpeed = (((float)floatReference > 0f) ? Vector3.Lerp(InertiaPositionSpeed, UseAdditivePos ? TargetSpeed : Vector3.zero, time * (float)floatReference) : TargetSpeed);
			AdditivePosition += InertiaPositionSpeed;
			if (float.IsNaN(InertiaPositionSpeed.x) || float.IsNaN(InertiaPositionSpeed.y) || float.IsNaN(InertiaPositionSpeed.z))
			{
				InertiaPositionSpeed = TargetSpeed;
			}
			if (debugGizmos)
			{
				MDebug.Draw_Arrow(Position + GizmoDeltaPos + Vector3.one * 0.02f, 2f * ScaleFactor * InertiaPositionSpeed, new Color(0.8f, 0.5f, 0f));
			}
		}

		protected virtual void AdditionalRotation(float time)
		{
			if (IsPlayingMode && !ActiveMode.AllowRotation)
			{
				return;
			}
			float num = (float)CurrentSpeedModifier.rotation * AdditiveRotationMultiplier;
			if ((double)VerticalSmooth < 0.01 && !CustomSpeed && CurrentSpeedSet != null)
			{
				num = CurrentSpeedSet[0].rotation;
			}
			if (num < 0f || !MovementDetected)
			{
				return;
			}
			float num2 = (IsPlayingMode ? ActiveMode.RotatioMultiplier : 1f);
			if (UsingMoveWithDirection)
			{
				if (DeltaAngle != 0f)
				{
					Quaternion b = Quaternion.Euler(0f, DeltaAngle * num2, 0f);
					Quaternion quaternion = Quaternion.Slerp(Quaternion.identity, b, (num + 1f) / 4f * (((float)TurnMultiplier + 1f) * time));
					AdditiveRotation *= quaternion;
				}
			}
			else
			{
				float num3 = num * 10f * num2;
				float num4 = Mathf.Clamp(HorizontalSmooth, -1f, 1f) * (float)((MovementAxis.z >= 0f) ? 1 : (-1));
				AdditiveRotation *= Quaternion.Euler(0f, num3 * num4 * time, 0f);
				Quaternion b2 = Quaternion.Euler(0f, num4 * ((float)TurnMultiplier + 1f), 0f);
				Quaternion quaternion2 = Quaternion.Slerp(Quaternion.identity, b2, time * (num + 1f));
				AdditiveRotation *= quaternion2;
			}
		}

		internal void SetMaxMovementSpeed()
		{
			float num = CurrentSpeedModifier.Vertical;
			float num2 = 1f;
			if (Strafe)
			{
				num2 = num;
			}
			VerticalSmooth = MovementAxis.z * num;
			HorizontalSmooth = MovementAxis.x * num2;
			UpDownSmooth = MovementAxis.y;
		}

		internal void MovementSystem()
		{
			float num = CurrentSpeedModifier.Vertical;
			float num2 = 1f;
			float num3 = DeltaTime * (float)CurrentSpeedSet.PitchLerpOn;
			float num4 = DeltaTime * (float)CurrentSpeedModifier.lerpPosAnim;
			float num5 = DeltaTime * (float)CurrentSpeedModifier.lerpRotAnim;
			float num6 = DeltaTime * (float)CurrentSpeedModifier.lerpAnimator;
			if (Strafe)
			{
				num2 = num;
			}
			if (ModeNotAllowMovement)
			{
				MovementAxis = Vector3.zero;
			}
			float num7 = MovementAxis.z;
			float num8;
			if (Rotate_at_Direction)
			{
				float currentVelocity = 0f;
				num7 = 0f;
				num8 = Mathf.SmoothDamp(HorizontalSmooth, MovementAxis.x, ref currentVelocity, (float)inPlaceDamp * DeltaTime);
			}
			else
			{
				num8 = Mathf.Lerp(HorizontalSmooth, MovementAxis.x * num2, num5);
			}
			VerticalSmooth = ((num4 > 0f) ? Mathf.Lerp(VerticalSmooth, num7 * num, num4) : (MovementAxis.z * num));
			HorizontalSmooth = ((num5 > 0f) ? num8 : (MovementAxis.x * num2));
			UpDownSmooth = ((num4 > 0f) ? Mathf.Lerp(UpDownSmooth, MovementAxis.y, num3) : MovementAxis.y);
			SpeedMultiplier = ((num6 > 0f) ? Mathf.Lerp(SpeedMultiplier, CurrentSpeedModifier.animator.Value, num6) : CurrentSpeedModifier.animator.Value);
			if (Mathf.Abs(VerticalSmooth) < 0.005f)
			{
				VerticalSmooth = 0f;
			}
			if (Mathf.Abs(HorizontalSmooth) < 0.005f)
			{
				HorizontalSmooth = 0f;
			}
			if (Mathf.Abs(UpDownSmooth) < 0.005f)
			{
				UpDownSmooth = 0f;
			}
		}

		public void SetPlatform(Transform newPlatform)
		{
			if (!(platform != newPlatform))
			{
				return;
			}
			GroundRootPosition = true;
			platform = newPlatform;
			if (platform != null)
			{
				GroundSpeedChanger component = newPlatform.GetComponent<GroundSpeedChanger>();
				if ((bool)component)
				{
					GroundRootPosition = false;
					GroundChanger?.OnExit?.React(this);
					GroundChanger = component;
					GroundChanger.OnEnter?.React(this);
				}
				else
				{
					GroundChanger?.OnExit?.React(this);
					GroundChanger = null;
				}
				Last_Platform_Pos = platform.position;
				Last_Platform_Rot = platform.rotation;
			}
			else
			{
				GroundChanger?.OnExit?.React(this);
				GroundChanger = null;
				DeltaPlatformPos = Vector3.zero;
				DeltaPlatformRot = Quaternion.identity;
				MainPivotSlope = 0f;
				ResetSlopeValues();
			}
			InGroundChanger = GroundChanger != null;
			foreach (State state in states)
			{
				state.OnPlataformChanged(platform);
			}
		}

		public void PlatformMovement()
		{
			if (!(platform == null) && !platform.gameObject.isStatic)
			{
				DeltaPlatformPos = platform.position - Last_Platform_Pos;
				Quaternion quaternion = Quaternion.Inverse(Last_Platform_Rot);
				DeltaPlatformRot = quaternion * platform.rotation;
				if (DeltaPlatformRot != Quaternion.identity)
				{
					Vector3 vector = t.DeltaPositionFromRotate(platform.position, DeltaPlatformRot);
					DeltaPlatformPos += vector;
				}
				Position += DeltaPlatformPos;
				Rotation *= DeltaPlatformRot;
				Last_Platform_Pos = platform.position;
				Last_Platform_Rot = platform.rotation;
			}
		}

		internal virtual void AlignRayCasting(float distance = 0f)
		{
			bool mainRay = (FrontRay = false);
			MainRay = mainRay;
			hit_Chest = new RaycastHit
			{
				normal = Vector3.zero
			};
			hit_Hip = default(RaycastHit);
			ref RaycastHit reference = ref hit_Chest;
			float distance2 = (hit_Hip.distance = Height);
			reference.distance = distance2;
			if (distance == 0f)
			{
				distance = Pivot_Multiplier * ScaleFactor;
			}
			if (Physics.Raycast(Main_Pivot_Point, -Up, out hit_Chest, distance, GroundLayer, QueryTriggerInteraction.Ignore))
			{
				if (MTools.Layer_in_LayerMask(hit_Chest.collider.gameObject.layer, groundLayer.Value) && hit_Chest.collider.transform.SameHierarchy(base.transform))
				{
					Debug.LogWarning("The Internal Collider [" + hit_Chest.collider.name + "] is on the Ground Layer Mask. Please change the Layer of the gameobject", hit_Chest.collider);
				}
				FrontRay = true;
				if (MainFronHit != hit_Chest.transform.gameObject)
				{
					MainFronHit = hit_Chest.transform.gameObject;
					isDebrisFront = MainFronHit.CompareTag(DebrisTag);
				}
				if (isDebrisFront)
				{
					MainPivotSlope = 0f;
					hit_Chest.normal = UpVector;
					ResetSlopeValues();
				}
				else
				{
					SlopeNormal = hit_Chest.normal;
					MainPivotSlope = Vector3.SignedAngle(SlopeNormal, UpVector, Right);
					SlopeDirection = Vector3.ProjectOnPlane(Gravity, SlopeNormal).normalized;
					SlopeDirectionAngle = 90f - Vector3.Angle(Gravity, SlopeDirection);
					if (Mathf.Approximately(SlopeDirectionAngle, 90f))
					{
						SlopeDirectionAngle = 0f;
					}
				}
				if (debugGizmos)
				{
					MDebug.DrawRay(hit_Chest.point + GizmoDeltaPos, 0.2f * ScaleFactor * SlopeNormal, Color.green);
					MDebug.DrawWireSphere(Main_Pivot_Point + GizmoDeltaPos + -Up * (hit_Chest.distance - RayCastRadius), Color.green, RayCastRadius * ScaleFactor);
					MDebug.Draw_Arrow(hit_Chest.point + GizmoDeltaPos, SlopeDirection * 0.5f, Color.black, 0f, 0.1f);
				}
				SetPlatform(hit_Chest.transform);
				AddForceToGround(hit_Chest.collider, hit_Chest.point);
			}
			else
			{
				SetPlatform(null);
			}
			if (Has_Pivot_Hip && Has_Pivot_Chest)
			{
				Vector3 vector = Pivot_Hip.World(t);
				MDebug.DrawWireSphere(vector, Color.yellow, RayCastRadius * ScaleFactor);
				if (Physics.Raycast(vector, -Up, out hit_Hip, distance, GroundLayer, QueryTriggerInteraction.Ignore))
				{
					if (MTools.Layer_in_LayerMask(hit_Hip.collider.gameObject.layer, groundLayer.Value) && hit_Hip.collider.transform.SameHierarchy(base.transform))
					{
						Debug.LogWarning($"The Internal Collider [{hit_Hip.collider}] is on the Ground Layer Mask. Please change the Layer of the gameobject", hit_Hip.collider);
					}
					MainRay = true;
					if (debugGizmos)
					{
						MDebug.DrawRay(hit_Hip.point + GizmoDeltaPos, 0.2f * ScaleFactor * hit_Hip.normal, Color.green);
						MDebug.DrawWireSphere(vector + GizmoDeltaPos + -Up * (hit_Hip.distance - RayCastRadius), Color.green, RayCastRadius * ScaleFactor);
					}
					SetPlatform(hit_Hip.transform);
					AddForceToGround(hit_Hip.collider, hit_Hip.point);
					if (!FrontRay)
					{
						hit_Chest = hit_Hip;
					}
				}
				else
				{
					MainRay = false;
					SetPlatform(null);
					if (FrontRay)
					{
						MovementAxis.z = 1f;
						hit_Hip = hit_Chest;
					}
				}
			}
			else
			{
				MainRay = FrontRay;
				hit_Hip = hit_Chest;
			}
			if ((bool)ground_Changes_Gravity)
			{
				Gravity = -hit_Hip.normal;
			}
			CalculateSurfaceNormal();
		}

		public void ResetSlopeValues()
		{
			SlopeDirection = Vector3.zero;
			SlopeDirectionSmooth = Vector3.ProjectOnPlane(SlopeDirectionSmooth, UpVector);
			SlopeDirectionAngle = 0f;
		}

		private void AddForceToGround(Collider collider, Vector3 point)
		{
			collider.attachedRigidbody?.AddForceAtPosition(Gravity * (RB.mass / 2f), point, ForceMode.Force);
		}

		internal virtual void CalculateSurfaceNormal()
		{
			if (Has_Pivot_Hip)
			{
				Vector3 vector;
				if (!Has_Pivot_Chest)
				{
					vector = (SurfaceNormal = hit_Hip.normal);
				}
				else
				{
					Vector3 normalized = (hit_Chest.point - hit_Hip.point).normalized;
					Vector3 normalized2 = Vector3.Cross(UpVector, normalized).normalized;
					SurfaceNormal = Vector3.Cross(normalized, normalized2).normalized;
					vector = SurfaceNormal;
					SlopeNormal = SurfaceNormal;
					if (!MainRay && FrontRay)
					{
						SurfaceNormal = hit_Chest.normal;
					}
				}
				TerrainSlope = Vector3.SignedAngle(vector, UpVector, Right);
			}
			else
			{
				TerrainSlope = Vector3.SignedAngle(hit_Hip.normal, UpVector, Right);
				SurfaceNormal = UpVector;
			}
		}

		public virtual void AlignRotation(bool align, float time, float smoothness)
		{
			AlignRotation(align ? SurfaceNormal : UpVector, time, smoothness);
		}

		public virtual void AlignRotation(Vector3 alignNormal, float time, float Smoothness)
		{
			AlignRotLerpDelta = Mathf.Lerp(AlignRotLerpDelta, Smoothness, time * (float)AlignRotDelta * 4f);
			Quaternion quaternion = Quaternion.FromToRotation(Up, alignNormal) * Rotation;
			Quaternion b = Quaternion.Inverse(Rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, time * AlignRotLerpDelta);
			Rotation *= quaternion2;
		}

		public virtual void AlignRotation(Vector3 from, Vector3 to, float time, float Smoothness)
		{
			AlignRotLerpDelta = Mathf.Lerp(AlignRotLerpDelta, Smoothness, time * (float)AlignRotDelta * 4f);
			Quaternion quaternion = Quaternion.FromToRotation(from, to) * Rotation;
			Quaternion b = Quaternion.Inverse(Rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, time * AlignRotLerpDelta);
			Rotation *= quaternion2;
		}

		internal void AlignPosition(float time)
		{
			if (MainRay || FrontRay)
			{
				AlignPosition(hit_Hip.distance, time);
			}
		}

		internal void AlignPosition(float distance, float time)
		{
			float b = Height - distance;
			if (!Mathf.Approximately(distance, Height))
			{
				AlignPosLerpDelta = Mathf.Lerp(AlignPosLerpDelta, (float)AlignPosLerp * 2f, time * (float)AlignPosDelta);
				float num = Mathf.Lerp(0f, b, time * AlignPosLerpDelta);
				Vector3 vector = Rotation * new Vector3(0f, num, 0f);
				Position += vector;
				hit_Hip.distance += num;
			}
		}

		private void SlopeMovement()
		{
			SlopeAngleDifference = 0f;
			float num;
			float num2;
			float num3;
			if (InGroundChanger)
			{
				num = GroundChanger.SlideThreshold;
				num2 = GroundChanger.SlideAmount;
				num3 = GroundChanger.SlideDamp;
			}
			else
			{
				num = slideThreshold;
				num2 = slideAmount;
				num3 = slideDamp;
			}
			float num4 = SlopeLimit - num;
			if (SlopeDirectionAngle > num4)
			{
				SlopeAngleDifference = (SlopeDirectionAngle - num4) / (SlopeLimit - num4);
				SlopeAngleDifference = Mathf.Clamp01(SlopeAngleDifference);
			}
			if (Grounded)
			{
				SlopeDirectionSmooth = Vector3.ProjectOnPlane(SlopeDirectionSmooth, SlopeNormal);
			}
			SlopeDirectionSmooth = Vector3.SmoothDamp(SlopeDirectionSmooth, num2 * SlopeAngleDifference * SlopeDirection, ref vectorSmoothDamp, DeltaTime * num3);
			if (debugGizmos)
			{
				MDebug.Draw_Arrow(Position + GizmoDeltaPos, SlopeDirectionSmooth * 2f, Color.yellow);
			}
			if (SlopeDirectionSmooth != Vector3.zero)
			{
				Position += SlopeDirectionSmooth;
			}
		}

		internal virtual void AlignPosition_Distance(float distance)
		{
			float y = Height - distance;
			AdditivePosition += Rotation * new Vector3(0f, y, 0f);
		}

		public virtual void AlignPosition()
		{
			float y = Height - hit_Hip.distance;
			AdditivePosition += Rotation * new Vector3(0f, y, 0f);
			InertiaPositionSpeed = Vector3.ProjectOnPlane(RB.velocity * DeltaTime, UpVector);
			ResetUPVector();
		}

		protected virtual void TryActivateState()
		{
			if (ActiveState.IsPersistent || ModePersistentState || JustActivateState)
			{
				return;
			}
			foreach (State state in states)
			{
				if (!(state == ActiveState) && (!ActiveState.IgnoreLowerStates || ActiveState.Priority <= state.Priority) && (state.UniqueID + CurrentCycle) % (int)state.TryLoop == 0 && !ActiveState.IsPending && ActiveState.CanExit && state.Active && !state.OnEnterCoolDown && !state.IsSleep && !state.OnQueue && !state.OnHoldByReset && state.TryActivate() && state.TryOverride)
				{
					state.Activate();
					break;
				}
			}
		}

		protected virtual void TryExitActiveState()
		{
			if (ActiveState.CanExit && !ActiveState.IsPersistent)
			{
				ActiveState.TryExitState(DeltaTime);
			}
		}

		protected virtual void OnAnimatorMove()
		{
			OnAnimalMove();
		}

		protected virtual void OnAnimalMove()
		{
			CurrentCycle = (CurrentCycle + 1) % 999999999;
			DeltaTime = ((Anim.updateMode == AnimatorUpdateMode.AnimatePhysics) ? Time.fixedDeltaTime : Time.deltaTime);
			DeltaPos = Position - LastPosition + DeltaPlatformPos;
			if (Sleep || InTimeline)
			{
				Anim.ApplyBuiltinRootMotion();
				return;
			}
			CacheAnimatorState();
			ResetValues();
			if (ActiveState == null)
			{
				return;
			}
			Anim.speed = (float)AnimatorSpeed * TimeMultiplier;
			DeltaTime = ((Anim.updateMode == AnimatorUpdateMode.AnimatePhysics) ? Time.fixedDeltaTime : Time.deltaTime);
			PreInput(this);
			ActiveState.InputAxisUpdate();
			ActiveState.SetCanExit();
			PreStateMovement(this);
			ActiveState.OnStatePreMove(DeltaTime);
			SetTargetSpeed();
			MoveRotator();
			AdditionalSpeed(DeltaTime);
			if (UseAdditiveRot)
			{
				AdditionalRotation(DeltaTime);
			}
			ActiveState.OnStateMove(DeltaTime);
			if (IsPlayingMode)
			{
				ActiveMode.OnAnimatorMove(DeltaTime);
			}
			ApplyExternalForce();
			_ = Position;
			PlatformMovement();
			if (!GroundedLogic())
			{
				bool mainRay = (FrontRay = false);
				MainRay = mainRay;
				SurfaceNormal = UpVector;
				SlopeMovement();
				AlignPosLerpDelta = 0f;
				AlignRotLerpDelta = 0f;
				if (!UseCustomRotation)
				{
					AlignRotation(align: false, DeltaTime, AlignRotLerp);
				}
				TerrainSlope = 0f;
				GravityLogic();
			}
			PostStateMovement(this);
			TryExitActiveState();
			TryActivateState();
			MovementSystem();
			if (float.IsNaN(AdditivePosition.x))
			{
				return;
			}
			if (ActiveMode != null && ActiveMode.ActiveAbility.NoYMovement)
			{
				AdditivePosition = Vector3.ProjectOnPlane(AdditivePosition, UpVector);
			}
			if (!DisablePosition)
			{
				if ((bool)RB)
				{
					if (Anim.updateMode == AnimatorUpdateMode.Normal)
					{
						RB.isKinematic = true;
						Position += AdditivePosition * TimeMultiplier;
					}
					else if (Anim.updateMode == AnimatorUpdateMode.AnimatePhysics)
					{
						if (RB.isKinematic)
						{
							Position += AdditivePosition * TimeMultiplier;
						}
						else
						{
							DesiredRBVelocity = AdditivePosition / DeltaTime * TimeMultiplier;
							RB.velocity = DesiredRBVelocity;
						}
					}
				}
				else
				{
					Position += AdditivePosition * TimeMultiplier;
				}
			}
			if (!DisableRotation)
			{
				Rotation *= AdditiveRotation;
				Strafing_Rotation();
			}
			UpdateAnimatorParameters();
			LastPosition = Position;
			additivePosition = Vector3.zero;
			additiveRotation = Quaternion.identity;
		}

		private bool GroundedLogic()
		{
			if (Grounded && !IgnoreModeGrounded)
			{
				SlopeMovement();
				if (AlignCycle.Value <= 1 || (AlignUniqueID + CurrentCycle) % AlignCycle.Value == 0)
				{
					AlignRayCasting();
				}
				AlignPosition(DeltaTime);
				if (!UseCustomRotation)
				{
					AlignRotation(UseOrientToGround, DeltaTime, AlignRotLerp);
				}
				return true;
			}
			return false;
		}

		private void ResetValues()
		{
			if (!(Anim.deltaPosition == Vector3.zero) || !(Anim.deltaRotation == Quaternion.identity))
			{
				float num = ((Anim.updateMode == AnimatorUpdateMode.Normal) ? Time.deltaTime : Time.fixedDeltaTime);
				DeltaRootMotion = ((RootMotion && GroundRootPosition) ? (Anim.deltaPosition * CurrentSpeedSet.RootMotionPos) : Vector3.Lerp(DeltaRootMotion, Vector3.zero, (float)currentSpeedModifier.lerpAnimator * num));
				if (Has_Pivot_Chest && !Has_Pivot_Hip)
				{
					DeltaRootMotion = Quaternion.FromToRotation(Up, SlopeNormal) * DeltaRootMotion;
				}
				AdditivePosition = DeltaRootMotion * TimeMultiplier;
				AdditiveRotation = (RootMotion ? Quaternion.Slerp(Quaternion.identity, Anim.deltaRotation, CurrentSpeedSet.RootMotionRot) : Quaternion.identity);
				if ((bool)RB)
				{
					Vector3 deltaVelocity = RB.velocity * DeltaTime;
					DeltaVelocity = deltaVelocity;
				}
				else
				{
					DeltaVelocity = DeltaPos;
				}
			}
		}

		internal void InputAxisUpdate()
		{
			if (Rotate_at_Direction)
			{
				if ((bool)MainCamera && UseCameraInput)
				{
					MoveFromDirection(RawRotateDirAxis);
				}
			}
			else if (UseRawInput)
			{
				if (AlwaysForward || ActiveState.AlwaysForward.Value)
				{
					RawInputAxis.z = 1f;
				}
				Vector3 rawInputAxis = RawInputAxis;
				rawInputAxis.Scale(LockMovementAxis);
				if (LockMovement || Sleep)
				{
					MovementAxis = Vector3.zero;
				}
				else if ((bool)MainCamera && UseCameraInput)
				{
					MoveWithCameraInput(rawInputAxis);
				}
				else
				{
					MoveWorld(rawInputAxis);
				}
			}
			else
			{
				MoveFromDirection(RawInputAxis);
			}
		}

		private void MoveWithCameraInput(Vector3 inputAxis)
		{
			Vector3 normalized = Vector3.ProjectOnPlane(MainCamera.forward, UpVector).normalized;
			Vector3 normalized2 = Vector3.ProjectOnPlane(MainCamera.right, UpVector).normalized;
			Vector3 vector;
			if (!FreeMovement)
			{
				vector = Vector3.zero;
			}
			else if (UseCameraUp)
			{
				float num = Vector3.SignedAngle(MainCamera.up, Vector3.up, MainCamera.right);
				num = Mathf.Clamp(num / 90f * CurrentSpeedSet.UpDownMult.Value, -1f, 1f);
				vector = inputAxis.y * LockMovementAxis.y * UpVector;
				vector += num * inputAxis.z * UpVector;
			}
			else
			{
				vector = inputAxis.y * LockMovementAxis.y * UpVector;
			}
			Vector3 move = inputAxis.z * normalized + inputAxis.x * normalized2 + vector;
			MoveFromDirection(move);
		}

		public virtual void SetInputAxis(Vector3 inputAxis)
		{
			UseRawInput = true;
			RawInputAxis = inputAxis;
			if (UsingUpDownExternal)
			{
				RawInputAxis.y = UpDownAdditive;
			}
		}

		public virtual void SetInputAxis(Vector2 inputAxis)
		{
			SetInputAxis(new Vector3(inputAxis.x, 0f, inputAxis.y));
		}

		public virtual void SetInputAxisXY(Vector2 inputAxis)
		{
			SetInputAxis(new Vector3(inputAxis.x, inputAxis.y, 0f));
		}

		public virtual void SetInputAxisYZ(Vector2 inputAxis)
		{
			SetInputAxis(new Vector3(0f, inputAxis.x, inputAxis.y));
		}

		public virtual void SetUpDownAxis(float upDown)
		{
			UpDownAdditive = upDown;
			UsingUpDownExternal = true;
			SetInputAxis(RawInputAxis);
		}

		public virtual void MoveWorld(Vector3 move)
		{
			UsingMoveWithDirection = false;
			if (!UseSmoothVertical && move.z > 0f)
			{
				move.z = 1f;
			}
			Move_Direction = t.TransformDirection(move).normalized;
			SetMovementAxis(move);
		}

		public virtual void SetMovementAxis(Vector3 move)
		{
			MovementAxisRaw = move;
			MovementAxis = MovementAxisRaw;
			MovementDetected = MovementAxisRaw != Vector3.zero;
			MovementAxis.Scale(ActiveState.MovementAxisMult);
		}

		public virtual void MoveFromDirection(Vector3 move)
		{
			if (LockMovement)
			{
				MovementAxis = Vector3.zero;
				return;
			}
			if (LockForwardMovement)
			{
				move = Vector3.Project(move, MainCamera.forward);
			}
			if (LockHorizontalMovement)
			{
				move = Vector3.Project(move, MainCamera.right);
			}
			if (ActiveState.KeepForwardMovement && move == Vector3.zero)
			{
				move = Move_Direction;
			}
			UsingMoveWithDirection = true;
			if (move.magnitude > 1f)
			{
				move.Normalize();
			}
			float num = (FreeMovement ? move.y : 0f);
			if (!FreeMovement)
			{
				move = Quaternion.FromToRotation(UpVector, SlopeNormal) * move;
			}
			Move_Direction = move;
			if (debugGizmos)
			{
				MDebug.Draw_Arrow(Position + GizmoDeltaPos, Move_Direction.normalized * 2f, Color.yellow);
				MDebug.DrawRay(Position, SlopeNormal, Color.black);
				MDebug.DrawRay(Position + GizmoDeltaPos, SlopeNormal, Color.black);
			}
			move = t.InverseTransformDirection(move);
			float num2 = Mathf.Atan2(move.x, move.z);
			float z = ((move.z < 0f) ? 0f : move.z);
			if (!Strafe)
			{
				DeltaAngle = (MovementDetected ? (num2 * 57.29578f) : 0f);
				if (Mathf.Approximately(DeltaAngle, float.NaN))
				{
					DeltaAngle = 0f;
				}
				if (Mathf.Abs(Vector3.Dot(Move_Direction, UpVector)) == 1f)
				{
					num2 = 0f;
					DeltaAngle = 0f;
				}
				inTurnLimit = Mathf.Abs(DeltaAngle) > TurnLimit;
				if (!UseRawInput && inTurnLimit)
				{
					z = 0f;
				}
				else if (!UseSmoothVertical)
				{
					z = Mathf.Abs(move.z);
					z = ((z > 0f) ? 1f : z);
					inTurnLimit = false;
				}
				else if (!inTurnLimit || VerticalSmooth > 1f)
				{
					z = Mathf.Clamp01(Move_Direction.magnitude);
				}
				else if (MovementDetected && UpDownSmooth != 0f)
				{
					z = Mathf.Clamp01(Move_Direction.magnitude);
				}
				if (Rotate_at_Direction)
				{
					z = 0f;
				}
				Vector3 movementAxis = new Vector3(num2, num, z);
				SetMovementAxis(movementAxis);
			}
			else
			{
				StrafeWithDirection(num);
			}
		}

		private void StrafeWithDirection(float UpDown)
		{
			Vector3 vector = Vector3.ProjectOnPlane(Aimer.RawAimDirection.normalized, UpVector);
			Vector3 move_Direction = Move_Direction;
			Vector3 vector2 = Quaternion.AngleAxis(90f, UpVector) * Aimer.RawAimDirection;
			float x = Vector3.Dot(vector2, move_Direction);
			float z = Vector3.Dot(vector, move_Direction);
			if (debugGizmos)
			{
				MDebug.DrawRay(Position + GizmoDeltaPos, vector * 2f, Color.cyan);
				MDebug.DrawRay(Position + GizmoDeltaPos, vector2 * 2f, Color.green);
			}
			DeltaAngle = Mathf.MoveTowards(DeltaAngle, 0f, DeltaTime * 2f);
			Vector3 normalized = new Vector3(x, UpDown, z).normalized;
			SetMovementAxis(normalized);
		}

		public virtual void RotateAtDirection(Vector3 direction)
		{
			if (!IsPlayingMode || ActiveMode.AllowRotation)
			{
				RawRotateDirAxis = direction;
				UseRawInput = false;
				Rotate_at_Direction = true;
			}
		}

		private void Strafing_Rotation()
		{
			if (Strafe && (bool)Aimer)
			{
				if ((float)m_StrafeLerp > 0f)
				{
					StrafeDeltaValue = Mathf.Lerp(StrafeDeltaValue, MovementDetected ? ActiveState.MovementStrafe : ActiveState.IdleStrafe, DeltaTime * (float)m_StrafeLerp);
					Rotation *= Quaternion.Euler(0f, Aimer.HorizontalAngle_Raw * StrafeDeltaValue, 0f);
				}
				else
				{
					Rotation *= Quaternion.Euler(0f, Aimer.HorizontalAngle_Raw, 0f);
				}
			}
			else
			{
				StrafeDeltaValue = 0f;
			}
		}

		private void ApplyExternalForce()
		{
			if (!(CurrentExternalForce == Vector3.zero) || !(ExternalForce == Vector3.zero))
			{
				float num = ((ExternalForceAcel > 0f) ? (DeltaTime * ExternalForceAcel) : 1f);
				CurrentExternalForce = Vector3.Lerp(CurrentExternalForce, ExternalForce, num);
				if (CurrentExternalForce.sqrMagnitude <= 0.001f)
				{
					CurrentExternalForce = Vector3.zero;
				}
				if (CurrentExternalForce != Vector3.zero)
				{
					AdditivePosition += CurrentExternalForce * DeltaTime;
				}
			}
		}

		public void GravityLogic()
		{
			if (UseGravity && !IgnoreModeGravity && !Grounded)
			{
				GravityStoredVelocity = StoredGravityVelocity();
				if (ClampGravitySpeed > 0f && ClampGravitySpeed * ClampGravitySpeed < GravityStoredVelocity.sqrMagnitude)
				{
					GravityTime--;
					GravityStoredVelocity = GravityStoredVelocity.normalized * ClampGravitySpeed;
				}
				AdditivePosition += DeltaTime * GravityExtraPower * GravityStoredVelocity + GravityOffset * DeltaTime;
				GravityTime++;
			}
		}

		internal Vector3 StoredGravityVelocity()
		{
			float num = DeltaTime * GravityTime;
			return num * num / 2f * GravityPower * ScaleFactor * TimeMultiplier * Gravity;
		}

		private void CheckCacheModeInput()
		{
			bool flag = false;
			foreach (Mode item in ModeQueueInput)
			{
				if (item.Active && item.TryActivate())
				{
					item.Debugging("<color=cyan> <B>[ModeQueueInput]</B>Try Activate Succesfull </color>");
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return;
			}
			foreach (Ability item2 in AbilityQueueInput)
			{
				if (item2.mode.TryActivate(item2))
				{
					item2.mode.Debugging("<color=cyan> <B>[AbilityQueueInput]</B>Try Activate Succesfull </color>");
					break;
				}
			}
		}

		internal void Set_Sleep_FromStates(State state)
		{
			foreach (State state2 in states)
			{
				if (!(state == state2))
				{
					bool flag = state2.SleepFromState.Contains(state.ID);
					flag ^= !state2.IncludeSleepState;
					state2.IsSleepFromState = flag;
				}
			}
		}

		internal virtual void Set_State_Sleep_FromMode(bool playingMode)
		{
			foreach (State state in states)
			{
				state.IsSleepFromMode = playingMode && state.SleepFromMode.Contains(ActiveMode.ID);
			}
		}

		internal virtual void Set_State_Sleep_FromStance()
		{
			foreach (State state in states)
			{
				state.IsSleepFromStance = state.SleepFromStance.Contains(Stance);
			}
		}

		internal virtual void Check_Queue_States(StateID ID)
		{
			foreach (State state in states)
			{
				state.OnQueue = state.QueueFrom.Contains(ID);
			}
		}

		private void SetAdvancedStance(StanceID value)
		{
			Stance stance = Stance_Get(value);
			if (stance != null)
			{
				if (!stance.CanActivate())
				{
					return;
				}
				bool strafe = Strafe;
				LastActiveStance = ActiveStance;
				ActiveStance = stance;
				LastStanceID = currentStance;
				currentStance = value;
				ActiveStance.Activate();
				if (ActiveStance != LastActiveStance)
				{
					LastActiveStance.Exit();
				}
				OnStanceChange.Invoke(value);
				OnStance(value.ID);
				foreach (Stance stance2 in Stances)
				{
					if (stance.DisableStances.Count > 0 && stance.DisableStances.Contains(stance2.ID))
					{
						stance2.Disable_Temp();
					}
					if (LastActiveStance.DisableStances.Count > 0 && LastActiveStance.DisableStances.Contains(stance2.ID))
					{
						stance2.Disable_Temp_Restore();
					}
				}
				Set_State_Sleep_FromStance();
				if (debugStances)
				{
					Debug.Log($"<B>[{base.name}] → Set: <color=yellow>[Stance - {value.name} - {value.ID}]</color></B>", base.gameObject);
				}
				TryAnimParameter(hash_Stance, currentStance.ID);
				TryAnimParameter(hash_LastStance, LastStanceID);
				if (!JustActivateState)
				{
					SetIntParameter(hash_LastState, ActiveStateID);
				}
				TryAnimParameter(hash_StateOn);
				if (strafe != Strafe)
				{
					StrafeLogic();
				}
				ActiveState.SetSpeed();
				if (IsPlayingMode && ActiveMode.StanceCanInterrupt(currentStance))
				{
					Mode_Interrupt();
				}
				else
				{
					CheckCacheModeInput();
				}
				if (ActiveStance.OverrideCapsule)
				{
					ActiveStance.newCapsule.Modify(MainCollider);
				}
				else
				{
					Reset_MainCollider();
				}
			}
			else if (debugStances && stance == null)
			{
				Debug.Log("<B>[" + base.name + "]</B> - <B> <color=yellow>[Stance: " + value.name + "]</color> - Fail to Activate. [NOT Found]</B>", base.gameObject);
			}
		}

		public void ResetCameraInput()
		{
			UseCameraInput = DefaultCameraInput;
		}

		private void DebLogAdditivePos()
		{
		}

		private void DebLogAdditiveRot()
		{
			additiveRotLog = !additiveRotLog;
		}

		internal virtual void SetModeParameters(Mode value, int status)
		{
			if (value != null)
			{
				int num = ((value.ActiveAbility != null) ? ((int)value.ActiveAbility.Index) : 0);
				int num2 = Mathf.Abs((int)value.ID * 1000) + Mathf.Abs(num);
				ModeAbility = (((int)value.ID < 0 || num < 0) ? (-num2) : num2);
				TryAnimParameter(hash_ModeOn);
				SetModeStatus(status);
				IsPreparingMode = true;
				ModeActivationTime = Time.time;
				ModeTime = 0f;
			}
			else
			{
				SetModeStatus(Int_ID.Available);
				ModeAbility = 0;
			}
		}

		public void SetModeStatus(int value)
		{
			Action<int, int> setIntParameter = SetIntParameter;
			int arg = hash_ModeStatus;
			int arg2 = (ModeStatus = value);
			setIntParameter(arg, arg2);
		}

		private void StrafeLogic()
		{
			if (!sleep)
			{
				if (debugStates)
				{
					Debuging($"Strafe: <B>[{Strafe}]</B>", "yellow");
				}
				OnStrafe.Invoke(Strafe);
				TryAnimParameter(hash_Strafe, Strafe);
				if (ActiveState.CanStrafe && ActiveState.StrafeAnimations)
				{
					TryAnimParameter(hash_StateOn);
				}
				if (!JustActivateState)
				{
					SetIntParameter(hash_LastState, ActiveStateID);
				}
				if (!Strafe)
				{
					ResetCameraInput();
				}
				else
				{
					Aimer?.SetEnable(enable: true);
				}
			}
		}

		public void DisablePivotChest()
		{
			Has_Pivot_Chest = false;
		}

		public void ResetPivotChest()
		{
			Has_Pivot_Chest = Starting_PivotChest;
		}

		public void UsePivotChest(bool value)
		{
			Has_Pivot_Chest = value;
		}

		private void EnterSpeedEvent(int index)
		{
			if (!JustChangedSpeedSet && OnEnterExitSpeeds != null)
			{
				OnEnterExitSpeed onEnterExitSpeed = OnEnterExitSpeeds.Find((OnEnterExitSpeed s) => s.SpeedIndex == index && s.SpeedSet == CurrentSpeedSet.name);
				if (OldEnterExitSpeed != null && onEnterExitSpeed != OldEnterExitSpeed)
				{
					OldEnterExitSpeed.OnExit.Invoke();
					OldEnterExitSpeed = null;
				}
				if (onEnterExitSpeed != null)
				{
					onEnterExitSpeed.OnEnter.Invoke();
					OldEnterExitSpeed = onEnterExitSpeed;
				}
			}
		}

		public void ResetSpeedSet()
		{
			CurrentSpeedSet = defaultSpeedSet;
		}

		public void SetSprint(bool value)
		{
			Sprint = value;
		}

		public bool PlayAction(int Set, int Index)
		{
			return Mode_TryActivate(Set, Index);
		}

		public bool ForceAction(int Set, int Index)
		{
			return Mode_ForceActivate(Set, Index);
		}
	}
}

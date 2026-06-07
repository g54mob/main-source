using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Animation;
using Assets.Scripts.Craft.Fuel;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.UI.Controllers;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Social.Achievements;
using Assets.Scripts.State;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Common.Physics;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Input;
using ModApi.Math;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.Ui.Inspector;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class EvaScript : PartModifierScript<EvaData>, IFlightUpdate, IGameLoopItem, IFlightFixedUpdate, IFlightLateUpdate, IEvaScript, ICameraTarget, IReactionEngine
	{
		private enum JumpState
		{
			Prepare = 0,
			Start = 1,
			Continue = 2,
			None = 3
		}

		private struct CollisionData
		{
			public int ContactCount;

			public ContactPoint[] ContactPoints;

			public Vector3 Impulse;

			public void Update(Collision collision)
			{
				Impulse = collision.impulse;
				ContactCount = collision.GetContacts(ContactPoints);
			}
		}

		private class CollisionInfo
		{
			public float Alignment { get; set; }

			public CollisionData Collision { get; set; }

			public ContactPoint ContactPoint { get; set; }

			public float GeeForce { get; set; }

			public float GeeForceFromGravity { get; set; }

			public float GeeForceFromGravityPercent { get; set; }

			public bool GroundedOnFeet { get; set; }
		}

		private const int MaxCollisionsCount = 300;

		private const int MaxContactsCount = 10;

		private const float MaxTetherLength = 750f;

		private static bool _achievementUnlockedSpacewalk = false;

		private static bool _achievementUnlockedWalkOnLuna = false;

		private static WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

		private Queue<Vector3> _accelVelocities;

		private EventMigrator<ICraftScript> _activeCommandPodChangingMigrator;

		private bool _activeWhileInCrewCompartment;

		private float _airborneStartTime;

		private ActivationGroupReplicationMode _backupReplicateActivationGroups;

		private bool _backupReplicateControls;

		private bool _backupReplicateStageActivation;

		private Rigidbody _bodyForLocalUp;

		private float _bodySpeed;

		private Camera _camera;

		private BoxCollider[] _clickyColliders;

		private Rigidbody _colliderRigidBody;

		private AudioSource _collisionAudio;

		private int _collisionCount;

		private CollisionNotifier _collisionNotifier;

		private CollisionData[] _collisions = new CollisionData[300];

		private CapsuleCollider _controllerCollider;

		private PhysicMaterial _controllerColliderPhysicsMaterial;

		private float _controllerColliderPhysicsMaterialDefaultDynamicFriction;

		private bool _controllerColliderRotatesWithAnimation;

		private EventMigrator<ICraftNode> _craftChangedSoiMigrator;

		private bool _craftInitialized;

		private EventMigrator<ICraftScript> _craftInitializedMigrator;

		private CrewAnimController _crewAnimController;

		private CrewCompartmentScript _crewCompartment;

		private bool _crewCompartmentHasBeenSet;

		private float _currentForwardSpeed;

		private float _currentStrafeSpeed;

		private float _currentVerticalSpeed;

		private bool _evaShootTetherProcessed;

		private FlightSceneScript _flightSceneScript;

		private float _footYPosThreshold;

		private FirstPersonCameraController _fpsCameraController;

		private bool _fpsCameraControllerSubscribed;

		private CameraVantageScript _fpsVantage;

		private double _fuelBurned;

		private FuelTankScript _fuelTank;

		private FullBodyBipedIK _fullBodyIk;

		private GrapplingHookScript _grapplingHook;

		private HandPoser[] _handPosers;

		private Transform _hips;

		private ImageEffectsScript _imageEffects;

		private IGameInputs _inputs;

		private bool _isGrounded;

		private float _jumpEndTime;

		private JumpState _jumpState = JumpState.None;

		private bool _loadingIntoCrewCompartmentInProgress;

		private bool _loadingIntoCrewCompartmentInProgressButHasBeenSuccessful;

		private Vector3 _localUpFromBody;

		private Vector3 _movementForceJetpack;

		private float _movementForceJetpackMag;

		private EventMigrator<ICraftNode> _nodeNameChangedMigrator;

		private Vector3 _oldForward;

		private int _overFlowCollisions;

		[SerializeField]
		private EvaPerformanceData _perfData = new EvaPerformanceData();

		private Renderer[] _renderers;

		private ICommandPod _replicatedCommandPod;

		private CollisionInfo _rigidBodyCollisionInfo;

		private CollisionInfo _rigidBodyCollisionInfoInstance = new CollisionInfo();

		private EvaSharedCamerasScript _sharedCameraScript;

		private float _smoothGs;

		private OrbitCameraController _thirdPersonCameraController;

		private ITimeManager _timeManager;

		private TransformInfoScript _transformInfo;

		private Vector3 _turningTorqueJetpack;

		private float _turningTorqueJetpackMag;

		private int _velocitiesMaxItems;

		[SerializeField]
		[Range(0.01f, 2f)]
		private float _fuelConsumption = 0.12f;

		public static float CameraFollowSpeed { get; set; } = 1f;

		public Vector3 Acceleration { get; private set; }

		public bool ActiveWhileInCrewCompartment
		{
			get
			{
				return _activeWhileInCrewCompartment;
			}
			set
			{
				bool num = value != _activeWhileInCrewCompartment;
				_activeWhileInCrewCompartment = value;
				if (num)
				{
					if (ActiveWhileInCrewCompartment && CrewCompartment.PartScript.CommandPod != null)
					{
						CraftControls.CopyControls(CrewCompartment.PartScript.CommandPod.Controls, base.PartScript.CommandPod.Controls);
					}
					else
					{
						CraftControls.ZeroControls(base.PartScript.CommandPod.Controls);
					}
					this.ActiveWhileInCrewCompartmentChanged?.Invoke();
				}
			}
		}

		public float AirborneTime => Time.time - _airborneStartTime;

		public bool AllowBodyRotation { get; private set; }

		public bool AutoUprightCharacter { get; private set; }

		Transform ICameraTarget.CameraTarget => base.transform;

		Vector3 ICameraTarget.CameraTargetPlanetPosition => (Vector3)Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.FrameToPlanetPosition(base.transform.position);

		public override bool CanRefuseConnection => true;

		public Vector3 CharacterControllerUp => -base.PartScript.CraftScript.GravityNormal;

		public CrewCompartmentScript CrewCompartment
		{
			get
			{
				return _crewCompartment;
			}
			private set
			{
				CrewCompartmentScript crewCompartment = _crewCompartment;
				_crewCompartment = value;
				if (_crewCompartment != crewCompartment || !_crewCompartmentHasBeenSet)
				{
					_crewCompartmentHasBeenSet = true;
					UpdateActiveInCrewCompartment();
					OnCrewCompartmentStateChanged(crewCompartment);
				}
			}
		}

		public ICommandPod CrewCompartmentCommandPod
		{
			get
			{
				if (!ActiveWhileInCrewCompartment)
				{
					return null;
				}
				return _crewCompartment.PartScript.CommandPod;
			}
		}

		public float CurrentThrust { get; private set; }

		public Vector3 DesiredUp { get; private set; }

		public bool EvaActive
		{
			get
			{
				if (CrewCompartment == null)
				{
					return !_loadingIntoCrewCompartmentInProgressButHasBeenSuccessful;
				}
				return false;
			}
		}

		public EvaControlSchemeType EvaControlScheme
		{
			get
			{
				if (!ActiveWhileInCrewCompartment)
				{
					return EvaControlSchemeType.Eva;
				}
				return EvaControlSchemeType.EvaInChair;
			}
		}

		public float ForceForward
		{
			get
			{
				if (!IsGrounded && !IsInWater)
				{
					return _perfData.ForceForwardJetpack * JetpackPowerScalar;
				}
				return _perfData.ForceForwardGround;
			}
		}

		public float ForceStrafe
		{
			get
			{
				if (!IsGrounded && !IsInWater)
				{
					return _perfData.ForceStrafeJetpack * JetpackPowerScalar;
				}
				return _perfData.ForceStrafeGround;
			}
		}

		public bool GrapplingHookEnabled
		{
			get
			{
				return base.Data.GrapplingHookEnabled;
			}
			set
			{
				base.Data.GrapplingHookEnabled = value;
			}
		}

		public float Gs => _smoothGs;

		public bool IgnoreForwardInputs { get; private set; }

		public bool InAtmosphere => base.PartScript.CraftScript.AtmosphereSample.AirDensity > 0f;

		public bool IsAtWaterSurface
		{
			get
			{
				if (base.PartScript.WaterPhysics.IsInWater)
				{
					return base.PartScript.WaterPhysics.UnderWaterAmount < 1f;
				}
				return false;
			}
		}

		public bool IsCrewCompartmentAttachPointInUse => !base.PartScript.Data.AttachPoints[0].IsAvailable;

		public bool IsFpsActive
		{
			get
			{
				if (_fpsCameraController != null)
				{
					return _fpsCameraController.IsSelected;
				}
				return false;
			}
		}

		public bool IsGrounded
		{
			get
			{
				return _isGrounded;
			}
			private set
			{
				bool num = _isGrounded != value;
				_isGrounded = value;
				if (num)
				{
					OnIsGroundedChanged();
				}
			}
		}

		public bool IsGroundedOnRigidBody
		{
			get
			{
				if (_colliderRigidBody != null)
				{
					return !IsGroundedTerrain;
				}
				return false;
			}
		}

		public bool IsGroundedTerrain { get; private set; }

		public bool IsInWater => base.PartScript.WaterPhysics.IsInWater;

		public bool IsPlayerCraft => Game.Instance.FlightScene.CraftNode == base.PartScript.CraftScript.CraftNode;

		public bool IsSwimmingEnabled
		{
			get
			{
				if (IsInWater)
				{
					return base.PartScript.WaterPhysics.UnderWaterAmount > 0.5f;
				}
				return false;
			}
		}

		public bool IsWalking
		{
			get
			{
				return base.PartScript.CommandPod.Controls.EvaWalk;
			}
			private set
			{
				base.PartScript.CommandPod.Controls.EvaWalk = value;
			}
		}

		public bool JetpackEnabled
		{
			get
			{
				return base.Data.JetpackEnabled;
			}
			set
			{
				base.Data.JetpackEnabled = value;
			}
		}

		public float JetpackPowerScalar
		{
			get
			{
				return base.Data.JetpackPowerScalar;
			}
			set
			{
				base.Data.JetpackPowerScalar = value;
			}
		}

		public float JumpPowerScalar
		{
			get
			{
				return base.Data.JumpPowerScalar;
			}
			set
			{
				base.Data.JumpPowerScalar = value;
			}
		}

		IOrbitNode ICameraTarget.OrbitNode => base.PartScript.CraftScript.CraftNode;

		public bool TetherAdjustLengthEnabled
		{
			get
			{
				if (GrapplingHook != null)
				{
					return GrapplingHookEnabled;
				}
				return false;
			}
		}

		public bool UnloadingFromCrewCompartmentInProgress { get; private set; }

		private GrapplingHookScript GrapplingHook
		{
			get
			{
				return _grapplingHook;
			}
			set
			{
				_grapplingHook = value;
				UpdateZoomEnabled();
			}
		}

		private float MaxForwardSpeed { get; set; }

		private float MaxStrafeSpeed { get; set; }

		private bool RecentlyJumped => _jumpEndTime > Time.time;

		private bool ShouldInterpolate => GetShouldInterpolate();

		private float TurningResponsiveness
		{
			get
			{
				if (!IsGrounded && !IsInWater)
				{
					return _perfData.TurningResponsivenessAir;
				}
				return _perfData.TurningResponsivenessGround;
			}
		}

		private bool UseKinematicTurning { get; set; }

		float IReactionEngine.CurrentMassFlowRate => (float)_fuelBurned * _fuelTank.Data.FuelType.Density;

		float IReactionEngine.CurrentThrust => CurrentThrust;

		IFuelSource IReactionEngine.FuelSource => _fuelTank;

		bool IReactionEngine.IsActive => EvaActive;

		float IReactionEngine.MaximumMassFlowRate => _fuelConsumption * _fuelTank.Data.FuelType.Density;

		float IReactionEngine.MaximumThrust => _perfData.ForceUpJetpack * 0.01f;

		PartData IReactionEngine.Part => base.PartScript.Data;

		float IReactionEngine.RemainingFuel => (float)(_fuelTank.TotalFuel * (double)_fuelTank.FuelType.Density);

		bool IReactionEngine.SupportsWarpBurn => false;

		float IReactionEngine.ThrottleResponse => 0.1f;

		public event ActiveWhileInCrewCompartmentChangedHandler ActiveWhileInCrewCompartmentChanged;

		public static void UpdateCrosshairsVisibility(bool? isPlayer = null)
		{
			ICraftNode craftNode = Game.Instance.FlightScene.CraftNode;
			bool valueOrDefault = isPlayer == true;
			if (!isPlayer.HasValue)
			{
				valueOrDefault = craftNode.IsPlayer;
				isPlayer = valueOrDefault;
			}
			bool flag;
			if (isPlayer.Value && craftNode.HasCommandPod && craftNode.CraftScript.ActiveCommandPod.IsEva)
			{
				IMapViewManager mapViewManager = Game.Instance.FlightScene.ViewManager.MapViewManager;
				flag = (mapViewManager == null || !mapViewManager.IsInForeground) && Game.Instance.FlightScene.CraftNode.CraftScript.ActiveCommandPod.EvaScript.GrapplingHookEnabled;
			}
			else
			{
				flag = false;
			}
			Game.Instance.FlightScene.FlightSceneUI.Crosshairs.enabled = flag;
		}

		public override bool AcceptConnection(AttachPointScript ourAttachPoint, AttachPointScript targetAttachPoint)
		{
			CrewCompartmentScript modifier = targetAttachPoint.PartScript.GetModifier<CrewCompartmentScript>();
			bool result;
			if (modifier != null)
			{
				if (modifier.IsFull)
				{
					result = false;
					if (modifier.Crew.Count > 0)
					{
						Game.Instance.Designer.ShowMessage($"The crew compartment is full with {modifier.Crew.Count} astronauts", 2f);
					}
					else
					{
						Game.Instance.Designer.ShowMessage("<color=\"red\">The crew compartment has no room for astronauts.</color>");
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (EvaActive && !_timeManager.CurrentMode.WarpMode)
			{
				_fuelBurned = 0.0;
				IsGrounded = _collisionCount > 0;
				AutoUprightCharacter = IsGrounded || (base.PartScript.WaterPhysics.IsInWater && !_fpsCameraController.IsSelected);
				AllowBodyRotation = !IsGrounded;
				UseKinematicTurning = !AllowBodyRotation || IsFpsActive;
				Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
				CraftControls controls = base.PartScript.CommandPod.Controls;
				Vector3 forward = rigidBody.transform.forward;
				Vector3 right = rigidBody.transform.right;
				Vector3 up = rigidBody.transform.up;
				bool flag = controls.EvaMoveFwdAft != 0f || controls.EvaStrafe != 0f;
				_controllerColliderPhysicsMaterial.dynamicFriction = (flag ? 0f : _controllerColliderPhysicsMaterialDefaultDynamicFriction);
				UpdateControllerColiderParent();
				rigidBody.drag = (IsAtWaterSurface ? 0.25f : 0f);
				rigidBody.angularDrag = (AllowBodyRotation ? 0.5f : float.MaxValue);
				rigidBody.interpolation = (ShouldInterpolate ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None);
				Vector3 vector;
				if (!IsGroundedTerrain && !IsInWater)
				{
					vector = ((!IsGroundedOnRigidBody) ? rigidBody.velocity : (rigidBody.velocity - _colliderRigidBody.velocity));
				}
				else
				{
					Quaternion quaternion = Quaternion.FromToRotation(Vector3.Lerp(forward, _oldForward, TurningResponsiveness), forward);
					rigidBody.velocity = quaternion * rigidBody.velocity;
					vector = rigidBody.velocity;
				}
				_bodySpeed = vector.magnitude;
				_currentVerticalSpeed = Vector3.Dot(vector, up);
				_currentForwardSpeed = Vector3.Dot(vector, forward);
				_currentStrafeSpeed = Vector3.Dot(vector, right);
				Vector3 totalForce = Vector3.zero;
				Vector3 totalForceJetpack = Vector3.zero;
				if (IsPlayerCraft)
				{
					UpdateMovement(out totalForce, out totalForceJetpack);
				}
				if (!ShouldInterpolate)
				{
					if (UseKinematicTurning)
					{
						UpdateKinematicTurning();
					}
					if (AutoUprightCharacter)
					{
						UprightCharacter();
					}
				}
				if (totalForce.sqrMagnitude == 0f && IsGrounded)
				{
					SlowDownCharacter(rigidBody, vector, _bodySpeed);
				}
				_movementForceJetpack = totalForceJetpack * 0.01f;
				_movementForceJetpackMag = _movementForceJetpack.magnitude;
				_crewAnimController.SideInput = controls.EvaStrafe;
				_oldForward = rigidBody.transform.forward;
				CurrentThrust = _movementForceJetpackMag + _turningTorqueJetpackMag * base.PartScript.CraftScript.Mass;
			}
			UpdateAcceleration(base.PartScript.BodyScript.RigidBody);
			_smoothGs = Mathf.Lerp(_smoothGs, _smoothGs + Mathf.Clamp((Acceleration - base.PartScript.CraftScript.GravityForce).magnitude * 0.102f - _smoothGs, -1f, 1f), frame.DeltaTime);
			if (base.Data.GTolerance > 0f && base.Data.GDamageScale > 0f && (float)Game.Instance.Settings.Game.Flight.ImpactDamageScale > 0f)
			{
				base.PartScript.TakeDamage(Mathf.Max(0f, _smoothGs - base.Data.GTolerance) * frame.DeltaTime * base.Data.GDamageScale * (float)Game.Instance.Settings.Game.Flight.ImpactDamageScale, PartDamageType.GForce);
			}
			_collisionCount = 0;
			_overFlowCollisions = 0;
			IsGroundedTerrain = false;
			_colliderRigidBody = null;
		}

		void IFlightLateUpdate.FlightLateUpdate(in FlightFrameData frame)
		{
			if (AutoUprightCharacter && ShouldInterpolate)
			{
				UprightCharacter();
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (EvaActive && !_timeManager.CurrentMode.WarpMode)
			{
				IsWalking = base.PartScript.CommandPod.Controls.EvaWalk;
				if (UseKinematicTurning && ShouldInterpolate)
				{
					UpdateKinematicTurning();
				}
				UpdateAnimationController();
				if (IsPlayerCraft)
				{
					UpdateJumpState();
					UpdateGrapplingHook();
					UpdateNozzles();
					CheckAchievements();
				}
			}
			else if (ActiveWhileInCrewCompartment && IsPlayerCraft)
			{
				UpdateGrapplingHook();
			}
			if (!GrapplingHookEnabled && GrapplingHook != null)
			{
				DestroyGrapplingHook(immediate: false, resetAdjustmentSlider: true);
			}
			if (ActiveWhileInCrewCompartment && IsPlayerCraft)
			{
				_fpsVantage.Data.CameraOffset = base.transform.InverseTransformPoint(_transformInfo.HeadCenter.position);
				_fpsCameraController.HeadUpVec = _transformInfo.HeadCenter.up;
			}
		}

		public void LoadIntoCrewCompartment(CrewCompartmentScript crewCompartment, Action onCompleted, bool announceBoarding = true)
		{
			if (crewCompartment != null && !_loadingIntoCrewCompartmentInProgress)
			{
				_loadingIntoCrewCompartmentInProgress = true;
				if (Game.InFlightScene && EvaActive)
				{
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>((Action)LoadIntoCompartment);
				}
				else
				{
					LoadIntoCompartment();
				}
			}
			void LoadIntoCompartment()
			{
				bool flag = true;
				if (Game.InDesignerScene)
				{
					SetCharacterVisibility(crewCompartment.Data.VisibleInCompartment, colliderEnabled: false);
					SetTransformToCrewCompartment(base.PartScript.Transform, crewCompartment);
				}
				else if (Game.InFlightScene)
				{
					bool flag2 = GrapplingHook != null && GrapplingHook.CraftFrom == base.PartScript.CraftScript;
					bool flag3 = true;
					if (IsCrewCompartmentAttachPointInUse)
					{
						foreach (PartConnection partConnection in base.PartScript.Data.AttachPoints[0].PartConnections)
						{
							if (partConnection.GetOtherPart(base.PartScript.Data) == crewCompartment.PartScript.Data)
							{
								flag3 = false;
								break;
							}
						}
						if (flag3)
						{
							UnloadFromCrewCompartment(setTransform: false);
						}
					}
					if (flag3)
					{
						AttachPoint attachPoint = null;
						foreach (AttachPoint attachPoint2 in crewCompartment.PartScript.Data.AttachPoints)
						{
							if (attachPoint2.IsSurfaceAttachPoint || attachPoint2.ConnectionType == AttachPointConnectionType.Eva)
							{
								attachPoint = attachPoint2;
							}
						}
						FlightSceneScript instance = FlightSceneScript.Instance;
						if (attachPoint != null)
						{
							if (crewCompartment.PartScript.CommandPod == null || crewCompartment.Data.CommandPodEnabledInCompartment || instance.ChangePlayersActiveCommandPodImmediate(crewCompartment.PartScript.CommandPod, crewCompartment.PartScript.CraftScript.CraftNode))
							{
								_loadingIntoCrewCompartmentInProgressButHasBeenSuccessful = true;
								if (announceBoarding)
								{
									instance.FlightSceneUI.ShowMessage(base.Data.CrewName + " has boarded the crew compartment.");
								}
								Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
								rigidBody.velocity = crewCompartment.PartScript.BodyScript.RigidBody.velocity;
								rigidBody.angularVelocity = crewCompartment.PartScript.BodyScript.RigidBody.angularVelocity;
								SetTransformToCrewCompartment(rigidBody.transform, crewCompartment);
								string text = crewCompartment.PartScript.CraftScript.CraftNode.Name;
								UpdateNodeName(ConnectParts(crewCompartment.PartScript, attachPoint, base.PartScript, base.PartScript.Data.AttachPoints[0]).CraftNode, text);
								UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
								{
									SetTransformToCrewCompartment(base.transform, crewCompartment);
								});
							}
							else
							{
								instance.FlightSceneUI.ShowMessage("The crew compartment is too far away to board.");
								flag = false;
							}
						}
						else
						{
							instance.FlightSceneUI.ShowMessage("Cannot load " + base.Data.CrewName + " into " + crewCompartment.PartScript.Data.Name + " b/c " + crewCompartment.PartScript.Data.Name + " has no suitable attach points.");
							flag = false;
						}
					}
					if (flag)
					{
						SetCharacterVisibility(crewCompartment.Data.VisibleInCompartment, colliderEnabled: false);
						Rigidbody rigidBody2 = base.PartScript.BodyScript.RigidBody;
						rigidBody2.collisionDetectionMode = CollisionDetectionMode.Discrete;
						rigidBody2.interpolation = RigidbodyInterpolation.None;
						rigidBody2.angularDrag = 0.05f;
						if (_fuelTank != null)
						{
							_fuelTank.CraftFuelSource.AddFuel(_fuelTank.TotalCapacity - _fuelTank.Data.Fuel);
						}
						if (flag2)
						{
							DestroyGrapplingHook(immediate: false, resetAdjustmentSlider: true);
						}
						base.PartScript.CraftScript.InitiateDragRecalculation();
					}
				}
				else
				{
					SetCharacterVisibility(crewCompartment.Data.VisibleInCompartment, colliderEnabled: false);
				}
				if (flag)
				{
					crewCompartment.OnCrewMemberLoaded(this);
					CrewCompartment = crewCompartment;
				}
				onCompleted?.Invoke();
				_loadingIntoCrewCompartmentInProgress = false;
				_loadingIntoCrewCompartmentInProgressButHasBeenSuccessful = false;
				if (Game.InFlightScene)
				{
					UpdateCommandReplication(base.PartScript.CommandPod.IsPlayerControlled, null);
				}
			}
		}

		public override void OnBeforePhysicsChanged(bool enabled)
		{
			base.OnBeforePhysicsChanged(enabled);
			if (!enabled)
			{
				base.PartScript.BodyScript.RigidBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
			}
		}

		public override void OnCloned()
		{
			base.OnCloned();
			if (base.Data.RequiresCrewMember)
			{
				CrewMember crewMember = Game.Instance.GameState.Crew.GetAvailableCrew(base.PartScript.CraftScript.Data.Assembly).FirstOrDefault();
				base.Data.AssignCrewMember(crewMember);
			}
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			base.OnConnectedToPart(e);
			CrewCompartmentScript modifier = e.TargetPart.PartScript.GetModifier<CrewCompartmentScript>();
			if (modifier != null)
			{
				LoadIntoCrewCompartment(modifier, null);
				Game.Instance.Designer.SelectPart(modifier.PartScript, null, justAdded: false);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (!Game.InFlightScene)
			{
				return;
			}
			OnCraftConfigurationChanged();
			if (Game.Instance.FlightScene.CraftNode != base.PartScript.CraftScript.CraftNode || !base.PartScript.CommandPod.IsPlayerControlled)
			{
				return;
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
			{
				if (x == 0)
				{
					Game.Instance.FlightScene.RaiseActiveCommandPodStateChanged();
				}
			}, 2);
		}

		public void OnCrewMemberChanged()
		{
			if (_transformInfo != null)
			{
				_transformInfo.UseAlternateJetpackStyle = base.Data.UseAlternateJetpackStyle;
				_transformInfo.InitializeJetpack();
			}
		}

		public override void OnDesignerPullout(Assembly assembly)
		{
			base.OnDesignerPullout(assembly);
			if (base.Data.RequiresCrewMember)
			{
				CrewMember crewMember = Game.Instance.GameState.Crew.GetAvailableCrew(base.PartScript.CraftScript.Data.Assembly).FirstOrDefault();
				base.Data.AssignCrewMember(crewMember);
			}
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			GroupModel groupModel = new GroupModel("Crew Info");
			model.AddGroup(groupModel);
			if (base.Data.RequiresCrewMember)
			{
				groupModel.Add(new TextModel("Name", () => base.Data.CrewName));
			}
			groupModel.Add(new TextModel("Gs", () => Units.MetricPrefix(Gs, "G")));
			if (_fuelTank != null)
			{
				groupModel.Add(new TextModel("Jetpack Fuel", () => Units.GetMassString((float)_fuelTank.TotalFuel * _fuelTank.FuelType.Density * 0.01f)));
			}
			TextButtonModel item = new TextButtonModel("Take Control", delegate
			{
				Game.Instance.FlightScene.ChangePlayersActiveCommandPodImmediate(base.PartScript.CommandPod, base.PartScript.CraftScript.CraftNode);
			}, null, () => ShowTakeControlButton());
			groupModel.Add(item);
			TextButtonModel textButtonModel = new TextButtonModel("EVA", delegate
			{
				CrewCompartment.UnloadCrewMember(this, takeControl: true);
			}, null, () => CrewCompartment != null);
			textButtonModel.Style = ButtonModel.ButtonStyle.Primary;
			groupModel.Add(textButtonModel);
			FlightSceneInterfaceScript ui = Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript;
			TextButtonModel transferButton = new TextButtonModel((ui.ActiveMoveCrewRequest == null) ? "Transfer" : (ui.ActiveMoveCrewRequest.Crew.Contains(this) ? "Cancel Transfer" : "Transfer"), delegate
			{
				OnTransferButtonClicked(groupModel);
			});
			transferButton.Style = ((ui.ActiveMoveCrewRequest != null) ? (ui.ActiveMoveCrewRequest.Crew.Contains(this) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default) : ButtonModel.ButtonStyle.Default);
			transferButton.Tooltip = "Transfer to a crew compartment";
			groupModel.Add(transferButton);
			GroupModel groupModel2 = groupModel;
			groupModel2.UpdateAction = (Action<ItemModel>)Delegate.Combine(groupModel2.UpdateAction, (Action<ItemModel>)delegate
			{
				transferButton.Style = ((ui.ActiveMoveCrewRequest != null) ? (ui.ActiveMoveCrewRequest.Crew.Contains(this) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default) : ButtonModel.ButtonStyle.Default);
				transferButton.Label = ((ui.ActiveMoveCrewRequest == null) ? "Transfer" : (ui.ActiveMoveCrewRequest.Crew.Contains(this) ? "Cancel Transfer" : "Transfer"));
			});
			if (base.Data.IsTourist)
			{
				ToggleModel item2 = new ToggleModel("Running", () => !IsWalking, delegate(bool x)
				{
					IsWalking = !x;
				});
				groupModel.Add(item2);
				return;
			}
			ToggleModel item3 = new ToggleModel("Grappling Hook", () => GrapplingHookEnabled, delegate(bool x)
			{
				GrapplingHookEnabled = x;
				UpdateCrosshairsVisibility();
			});
			groupModel.Add(item3);
			if (base.Data.JetpackAvailable)
			{
				ToggleModel item4 = new ToggleModel("Jetpack", () => JetpackEnabled, delegate(bool x)
				{
					JetpackEnabled = x;
				});
				groupModel.Add(item4);
			}
			ToggleModel item5 = new ToggleModel("Running", () => !IsWalking, delegate(bool x)
			{
				IsWalking = !x;
			});
			groupModel.Add(item5);
			SliderModel item6 = new SliderModel("Jump Power", () => JumpPowerScalar, delegate(float x)
			{
				JumpPowerScalar = x;
			}, 0.01f);
			groupModel.Add(item6);
			SliderModel item7 = new SliderModel("Jetpack Power", () => JetpackPowerScalar, delegate(float x)
			{
				JetpackPowerScalar = x;
			}, 0.01f, 5f);
			groupModel.Add(item7);
		}

		public override void OnInitialLaunch()
		{
			base.OnInitialLaunch();
			if (base.Data.CrewMember != null)
			{
				base.Data.CrewMember.State = CrewMemberState.InFlight;
			}
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			if (Game.InFlightScene)
			{
				base.PartScript.WaterPhysics.Enabled = false;
				_fuelTank = GetComponent<FuelTankScript>();
				CommandPodScript modifier = base.PartScript.GetModifier<CommandPodScript>();
				modifier.Data.SupressSwitchedToCraftMessage = true;
				modifier.IsPlayerControlledChanged += OnCommandPodIsPlayerControlledChanged;
			}
			if (!base.Data.JetpackAvailable)
			{
				Utilities.FindFirstGameObjectMyselfOrChildren("EVAChestPlate", base.gameObject)?.SetActive(value: false);
			}
		}

		public override void OnNodeLoaded()
		{
			base.OnNodeLoaded();
			_craftChangedSoiMigrator = new EventMigrator<ICraftNode>(() => base.PartScript.CraftScript.CraftNode, delegate(ICraftNode craftNode)
			{
				craftNode.ChangedSoI += OnChangedSoI;
			}, delegate(ICraftNode craftNode)
			{
				craftNode.ChangedSoI -= OnChangedSoI;
			});
			_craftChangedSoiMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICraftNode> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICraftNode> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
			_nodeNameChangedMigrator = new EventMigrator<ICraftNode>(() => base.PartScript.CraftScript.CraftNode, delegate(ICraftNode craftNode)
			{
				craftNode.NameChanged += OnNodeNameChanged;
			}, delegate(ICraftNode craftNode)
			{
				craftNode.NameChanged -= OnNodeNameChanged;
			});
			_nodeNameChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICraftNode> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICraftNode> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			if (Game.InFlightScene)
			{
				if (base.Data.CrewMember != null)
				{
					base.Data.CrewMember.State = CrewMemberState.Deceased;
				}
				if (IsPlayerCraft)
				{
					OnCommandPodIsPlayerControlledChanged(isPlayer: false, null, null);
				}
			}
		}

		public override void OnPhysicsChanged(bool enabled)
		{
			base.OnPhysicsChanged(enabled);
			if (enabled)
			{
				base.PartScript.BodyScript.RigidBody.collisionDetectionMode = (EvaActive ? CollisionDetectionMode.ContinuousDynamic : CollisionDetectionMode.Discrete);
			}
		}

		public override void OnPreNodeLoaded()
		{
			base.OnPreNodeLoaded();
			if (Game.InFlightScene)
			{
				_sharedCameraScript = EvaSharedCamerasScript.Instance;
				_fpsCameraController = _sharedCameraScript.FpsController;
				_fpsCameraController.DisablePartMaterial = false;
				_fpsVantage = GetComponent<CameraVantageScript>();
				_fpsVantage.AutoCenterCamera = false;
				_fpsVantage.CameraController = _fpsCameraController;
				_fpsVantage.MouseLook = !Device.IsMobileBuild;
				_thirdPersonCameraController = _sharedCameraScript.ThirdPersonConroller;
				base.gameObject.name = $"{base.Data.CrewName}_astronaut_{base.gameObject.GetInstanceID()}";
			}
		}

		public void Start()
		{
			if (Game.InFlightScene)
			{
				_inputs = Game.Instance.Inputs;
				UpdateGravitySuitableAnimationController();
				_activeCommandPodChangingMigrator = new EventMigrator<ICraftScript>(() => base.PartScript.CraftScript, delegate(ICraftScript craftScript)
				{
					craftScript.ActiveCommandPodChanging += OnActiveCommandPodChanging;
				}, delegate(ICraftScript craftScript)
				{
					craftScript.ActiveCommandPodChanging -= OnActiveCommandPodChanging;
				});
				_activeCommandPodChangingMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
				{
					partScript.MovedToNewCraft += migrator.MigrateEvent;
				}, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
				{
					partScript.MovedToNewCraft -= migrator.MigrateEvent;
				});
				base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
				UpdateCrewMemberLocation();
			}
		}

		public void TakeControl()
		{
			if (Game.InDesignerScene)
			{
				UnloadFromCrewCompartment();
				ActivateEvaForDisconnectedAstronaut();
				return;
			}
			if (!EvaActive)
			{
				UnloadFromCrewCompartment();
			}
			SwitchToCommandPod();
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (_transformInfo != null)
			{
				_transformInfo.UseAlternateJetpackStyle = base.Data.UseAlternateJetpackStyle;
			}
			if (Game.InFlightScene)
			{
				_hips = _crewAnimController.Animator.GetBoneTransform(HumanBodyBones.Hips);
				if (_hips == null)
				{
					Debug.LogError("Could not locate the astronauts hips bone.");
				}
				_flightSceneScript = Game.Instance.FlightScene as FlightSceneScript;
				if (!_flightSceneScript.IsInitialized)
				{
					_flightSceneScript.Initialized += delegate
					{
						if (base.PartScript.CommandPod.IsPlayerControlled)
						{
							SetEvaCameraModesInUse(evaCamerasInUse: true, updateCameraState: true);
						}
					};
				}
			}
			_craftInitializedMigrator = new EventMigrator<ICraftScript>(() => base.PartScript.CraftScript, delegate(ICraftScript craftScript)
			{
				craftScript.Initialized += OnCraftinitialized;
			}, delegate(ICraftScript craftScript)
			{
				craftScript.Initialized -= OnCraftinitialized;
			});
			_craftInitializedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
			_velocitiesMaxItems = (int)(0.5f / Time.fixedDeltaTime);
			_accelVelocities = new Queue<Vector3>(_velocitiesMaxItems);
			_footYPosThreshold = ((_controllerCollider.height * 0.5f - _controllerCollider.radius) * Vector3.down - _controllerCollider.center).y;
			Game.Instance.QualitySettings.Physics.WaterPhysics.Changed += OnWaterPhysicsQualityChanged;
			base.PartScript.Data.EnabledChanged += OnPartEnabledChanged;
		}

		private static ICraftScript ConnectParts(IPartScript partA, AttachPoint attachPointA, IPartScript partB, AttachPoint attachPointB)
		{
			if (partB.CraftScript.CraftNode.IsPlayer)
			{
				IPartScript partScript = partA;
				AttachPoint attachPoint = attachPointA;
				partA = partB;
				attachPointA = attachPointB;
				partB = partScript;
				attachPointB = attachPoint;
			}
			if (partB.CraftScript != partA.CraftScript)
			{
				if (partB.CraftScript.CraftNode == partA.CraftScript.CraftNode)
				{
					Debug.LogError("We're about to merge crafts which have different craft scripts, but the same craft node?");
				}
				CraftSplitter.MergeCraftNode(partB.CraftScript.CraftNode as CraftNode, partA.CraftScript.CraftNode as CraftNode);
			}
			PartConnection partConnection = new PartConnection(partA.Data, partB.Data);
			partConnection.AddAttachment(attachPointA, attachPointB);
			partA.CraftScript.Data.Assembly.AddPartConnection(partConnection);
			IBodyScript bodyScript = partA.BodyScript;
			IBodyScript bodyScript2 = partB.BodyScript;
			partConnection.BodyJointData = new BodyJointData(partConnection);
			partConnection.BodyJointData.Axis = Vector3.right;
			partConnection.BodyJointData.SecondaryAxis = Vector3.up;
			partConnection.BodyJointData.Position = bodyScript.Transform.InverseTransformPoint(partA.Transform.TransformPoint(attachPointA.Position));
			partConnection.BodyJointData.ConnectedPosition = bodyScript2.Transform.InverseTransformPoint(partB.Transform.TransformPoint(attachPointB.Position));
			partConnection.BodyJointData.BreakTorque = float.PositiveInfinity;
			partConnection.BodyJointData.JointType = BodyJointData.BodyJointType.Normal;
			partConnection.BodyJointData.Body = bodyScript.Data;
			partConnection.BodyJointData.ConnectedBody = bodyScript2.Data;
			CraftBuilder.CreateBodyJoint(partConnection);
			return partA.CraftScript;
		}

		private static CrewCompartmentScript GetCrewCompartment(EvaScript crewMember)
		{
			CrewCompartmentScript crewCompartmentScript = null;
			foreach (PartConnection partConnection in crewMember.PartScript.Data.PartConnections)
			{
				crewCompartmentScript = partConnection.PartA.GetModifier<CrewCompartmentData>()?.Script;
				if (crewCompartmentScript != null)
				{
					break;
				}
				crewCompartmentScript = partConnection.PartB.GetModifier<CrewCompartmentData>()?.Script;
				if (crewCompartmentScript != null)
				{
					break;
				}
			}
			return crewCompartmentScript;
		}

		private static void SetTransformToCrewCompartment(Transform trans, CrewCompartmentScript crewCompartment)
		{
			Vector3 position = crewCompartment.transform.TransformPoint(crewCompartment.CrewPosition);
			Quaternion rotation = crewCompartment.transform.rotation * Quaternion.Euler(crewCompartment.CrewRotation);
			trans.SetPositionAndRotation(position, rotation);
		}

		private static void SetTransformToCrewExit(Transform trans, CapsuleCollider collider, CrewCompartmentScript crewCompartment)
		{
			Transform obj = crewCompartment.PartScript.Transform;
			Vector3 position = obj.TransformPoint(crewCompartment.Data.CrewExitPosition);
			Quaternion rotation = obj.rotation * Quaternion.Euler(crewCompartment.Data.CrewExitRotation);
			trans.SetPositionAndRotation(position, rotation);
			if (Game.InFlightScene)
			{
				Vector3 vector = -crewCompartment.PartScript.CraftScript.GravityNormal;
				int layerMask = -1543503872;
				double agl = Utilities.PhysicsUtils.GetAgl(trans.position);
				if (agl < 0.0)
				{
					trans.position += vector * Mathf.Abs((float)agl);
					Physics.SyncTransforms();
				}
				Utilities.PhysicsUtils.DepenetrateCollider(collider, trans, vector, 0.01f, layerMask, QueryTriggerInteraction.Ignore);
			}
		}

		private static void UpdateNodeName(ICraftNode node, string name)
		{
			(node as CraftNode).Name = name;
			Game.Instance.FlightScene.IocContainer.Resolve<IMapViewSearchPanel>((Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context, suppressWarnings: true)?.RefreshSearchItemList();
		}

		private void ActivateEvaForDisconnectedAstronaut()
		{
			CrewCompartment = null;
			if (Game.InFlightScene)
			{
				UpdateCommandReplication(base.PartScript.CommandPod.IsPlayerControlled, null);
			}
			SetCharacterVisibility(visible: true, colliderEnabled: true);
			if (!Game.InFlightScene)
			{
				return;
			}
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			_collisionNotifier = rigidBody.gameObject.GetComponent<CollisionNotifier>();
			if (_collisionNotifier == null)
			{
				_collisionNotifier = rigidBody.gameObject.AddComponent<CollisionNotifier>();
				_collisionNotifier.CollisionEnter.AddListener(delegate(Collision x)
				{
					OnCollisionEnter(x);
				});
				_collisionNotifier.CollisionExit.AddListener(delegate(Collision x)
				{
					OnCollisionExit(x);
				});
				_collisionNotifier.CollisionStay.AddListener(delegate(Collision x)
				{
					OnCollisionStay(x);
				});
			}
			rigidBody.ResetInertiaTensor();
			UpdateNodeName(base.PartScript.CraftScript.CraftNode, base.Data.CrewName);
		}

		private float AdjustTetherLength(float adjustmentScalar)
		{
			float num;
			if (GrapplingHook != null)
			{
				num = GrapplingHook.AdjustTetherLength(adjustmentScalar, 750f);
				if (num < 750f)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage(string.Format("Tether {0} to {1:0.0}m", (adjustmentScalar > 0f) ? "extended" : "retracted", num));
				}
				else
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"Tether has reached maximum length: {750f}m");
				}
			}
			else
			{
				Debug.LogError("Attempted to adjust grappling hook tether's length when no grappling hook exists.");
				num = -1f;
			}
			return num;
		}

		private void Awake()
		{
			_transformInfo = GetComponentInChildren<TransformInfoScript>();
			_controllerCollider = GetComponentInChildren<CapsuleCollider>();
			_clickyColliders = GetComponentsInChildren<BoxCollider>();
			_controllerColliderPhysicsMaterial = _controllerCollider.material;
			_controllerColliderPhysicsMaterialDefaultDynamicFriction = _controllerColliderPhysicsMaterial.dynamicFriction;
			_renderers = GetComponentsInChildren<Renderer>();
			_crewAnimController = new CrewAnimController(GetComponentInChildren<Animator>(), _transformInfo);
			_fullBodyIk = GetComponentInChildren<FullBodyBipedIK>();
			_handPosers = GetComponentsInChildren<HandPoser>();
			for (int i = 0; i < 300; i++)
			{
				_collisions[i].ContactPoints = new ContactPoint[10];
			}
			if (Game.InFlightScene)
			{
				_timeManager = Game.Instance.FlightScene.TimeManager;
				_timeManager.TimeMultiplierModeChanging += OnTimeMultiplierModeChanging;
				_imageEffects = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Transform.GetComponent<ImageEffectsScript>();
				StartCoroutine(ProcessCompletedPhysicsCycle());
				_collisionAudio = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Flight.EvaCollision, base.gameObject, userInterfaceSound: false);
				_collisionAudio.playOnAwake = false;
			}
		}

		private Vector3 CalculateDesiredUp()
		{
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			if (Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.IsSurfaceLocked)
			{
				if (IsGroundedOnRigidBody)
				{
					CollisionData? collisionData = null;
					ContactPoint contactPoint = default(ContactPoint);
					float num = -1f;
					Vector3 up = rigidBody.transform.up;
					Vector3 zero = Vector3.zero;
					float num2 = 0f;
					for (int i = 0; i < _collisionCount; i++)
					{
						CollisionData value = _collisions[i];
						ContactPoint[] contactPoints = value.ContactPoints;
						zero += value.Impulse;
						num2 += value.Impulse.magnitude;
						for (int j = 0; j < value.ContactCount; j++)
						{
							ContactPoint contactPoint2 = contactPoints[j];
							float num3 = Vector3.Dot(up, contactPoint2.normal);
							if (num3 > num)
							{
								num = num3;
								contactPoint = contactPoint2;
								collisionData = value;
							}
						}
					}
					if (collisionData.HasValue)
					{
						Vector3 vector = _controllerCollider.transform.InverseTransformPoint(contactPoint.point);
						_rigidBodyCollisionInfo = _rigidBodyCollisionInfoInstance;
						_rigidBodyCollisionInfo.GroundedOnFeet = vector.y < _footYPosThreshold && num > 0.2f;
						_rigidBodyCollisionInfo.Collision = collisionData.Value;
						_rigidBodyCollisionInfo.ContactPoint = contactPoint;
						_rigidBodyCollisionInfo.Alignment = num;
						_rigidBodyCollisionInfo.GeeForce = collisionData.Value.Impulse.magnitude / (base.PartScript.CraftScript.GravityMagnitude * rigidBody.mass * Time.fixedDeltaTime);
						float num4 = zero.magnitude / (base.PartScript.CraftScript.GravityMagnitude * rigidBody.mass * Time.fixedDeltaTime);
						float geeForceFromGravity = Mathf.Clamp01(Vector3.Dot(-contactPoint.normal, base.PartScript.CraftScript.GravityNormal));
						_rigidBodyCollisionInfo.GeeForceFromGravity = geeForceFromGravity;
						_rigidBodyCollisionInfo.GeeForceFromGravity /= num4;
						if (_rigidBodyCollisionInfo.GeeForce > 0f)
						{
							_rigidBodyCollisionInfo.GeeForceFromGravityPercent = Mathf.Clamp01(Mathf.Lerp(_rigidBodyCollisionInfo.GeeForceFromGravityPercent, _rigidBodyCollisionInfo.GeeForceFromGravity / _rigidBodyCollisionInfo.GeeForce, Time.deltaTime));
						}
						else
						{
							_rigidBodyCollisionInfo.GeeForceFromGravityPercent = 1f;
						}
					}
					else
					{
						Debug.LogError($"IsGroundedOnRigidBody is true, but we couldn't fid any appropriate contacts from the available collisions ({_collisionCount})");
					}
				}
				else
				{
					_rigidBodyCollisionInfo = null;
				}
				if (!AutoUprightCharacter)
				{
					return rigidBody.transform.up;
				}
				if (IsGroundedOnRigidBody)
				{
					if (_rigidBodyCollisionInfo == null)
					{
						return -base.PartScript.CraftScript.GravityNormal;
					}
					Vector3 a = ((!_rigidBodyCollisionInfo.GroundedOnFeet) ? rigidBody.transform.up : _rigidBodyCollisionInfo.ContactPoint.normal);
					return Vector3.Lerp(a, -base.PartScript.CraftScript.GravityNormal, _rigidBodyCollisionInfo.GeeForceFromGravityPercent);
				}
				return CharacterControllerUp;
			}
			return rigidBody.transform.up;
		}

		private void CheckAchievements()
		{
			if (!_craftInitialized || !AchievementHelper.InFlightSceneDefaultSystem || AchievementHelper.InLevel)
			{
				return;
			}
			if (!_achievementUnlockedSpacewalk && AchievementHelper.IsInSpace(base.PartScript.CraftScript))
			{
				_achievementUnlockedSpacewalk = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.FirstSpacewalk);
			}
			if (!_achievementUnlockedWalkOnLuna)
			{
				ICraftNode craftNode = base.PartScript.CraftScript.CraftNode;
				if (craftNode.Parent.Name == "Luna" && !craftNode.IsDestroyed && craftNode.InContactWithPlanet && craftNode.GetInitialCraftNodeData(base.PartScript.Data.Config.InitialCraftNodeId)?.LaunchPlanetName == "Droo")
				{
					_achievementUnlockedWalkOnLuna = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.WalkOnLuna);
				}
			}
		}

		private GrapplingHookScript ConnectViaRaycast(Rigidbody bodyFrom, IPartScript partFrom, Vector3 positionFrom, Ray ray, float maxDist)
		{
			GrapplingHookScript grapplingHookScript = GrapplingHookScript.ConnectViaRaycast(bodyFrom, partFrom, positionFrom, ray, maxDist);
			if (grapplingHookScript != null)
			{
				if (grapplingHookScript.PartFrom != null)
				{
					grapplingHookScript.PartFrom.PartDestroyed += GrapplingHookPartDestroyed;
				}
				if (grapplingHookScript.PartTo != null)
				{
					grapplingHookScript.PartTo.PartDestroyed += GrapplingHookPartDestroyed;
				}
			}
			return grapplingHookScript;
		}

		private void DestroyGrapplingHook(bool immediate, bool resetAdjustmentSlider)
		{
			if (GrapplingHook.PartFrom != null)
			{
				GrapplingHook.PartFrom.PartDestroyed -= GrapplingHookPartDestroyed;
			}
			if (GrapplingHook.PartTo != null)
			{
				GrapplingHook.PartTo.PartDestroyed -= GrapplingHookPartDestroyed;
			}
			if (immediate)
			{
				UnityEngine.Object.DestroyImmediate(GrapplingHook);
			}
			else
			{
				UnityEngine.Object.Destroy(GrapplingHook);
			}
			if (resetAdjustmentSlider)
			{
				base.PartScript.CommandPod.Controls.EvaTetherLengthOffset = 0f;
			}
			GrapplingHook = null;
		}

		private bool GetShouldInterpolate()
		{
			ICommandPod commandPod = Game.Instance.FlightScene.CraftNode.CraftScript.RootPart.CommandPod;
			if (!IsPlayerCraft && commandPod.IsEva)
			{
				return (commandPod.EvaScript as EvaScript).ShouldInterpolate;
			}
			if (IsPlayerCraft)
			{
				if (GrapplingHook != null && GrapplingHook.BodyTo == null)
				{
					DestroyGrapplingHook(immediate: true, resetAdjustmentSlider: true);
					return false;
				}
				if (GrapplingHook != null && !GrapplingHook.BodyTo.isKinematic && GrapplingHook.BodyFrom == base.PartScript.BodyScript.RigidBody)
				{
					return GrapplingHook.BodyTo.interpolation == RigidbodyInterpolation.Interpolate;
				}
				return IsGroundedTerrain;
			}
			return false;
		}

		private void GrapplingHookPartDestroyed(IPartScript partScript)
		{
			DestroyGrapplingHook(immediate: false, resetAdjustmentSlider: true);
		}

		private void OnActiveCommandPodChanging(ICraftScript source, ICommandPod newPod, ICommandPod oldPod)
		{
			if (ActiveWhileInCrewCompartment && CrewCompartmentCommandPod != null && CrewCompartmentCommandPod != base.PartScript.CommandPod)
			{
				ICommandPod crewCompartmentCommandPod = CrewCompartmentCommandPod;
				for (int i = 1; i <= base.PartScript.CommandPod.ActivationGroupNames.Count; i++)
				{
					base.PartScript.CommandPod.SetActivationGroupState(i, crewCompartmentCommandPod.GetActivationGroupState(i));
				}
				base.PartScript.CommandPod.Controls.Throttle = crewCompartmentCommandPod.Controls.Throttle;
			}
		}

		private void OnChangedSoI(IOrbitNode source)
		{
			UpdateGravitySuitableAnimationController();
			UpdateCrewMemberLocation();
		}

		private void OnCollisionEnter(Collision collision)
		{
			ProcessCollision(collision);
			if (collision.impulse.sqrMagnitude > 20f * base.PartScript.BodyScript.RigidBody.mass * base.PartScript.BodyScript.RigidBody.mass)
			{
				_collisionAudio?.Play();
			}
		}

		private void OnCollisionExit(Collision collision)
		{
		}

		private void OnCollisionStay(Collision collision)
		{
			ProcessCollision(collision);
		}

		private void OnCommandPodIsPlayerControlledChanged(bool isPlayer, ICommandPod source, ICommandPod other)
		{
			UpdateCrosshairsVisibility(isPlayer);
			UpdateCommandReplication(isPlayer, other);
			if (isPlayer)
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Switched to " + base.Data.CrewName + ".");
			}
			UpdateZoomEnabled();
			bool updateCameraState = isPlayer || !(other?.IsEva ?? false);
			SetEvaCameraModesInUse(isPlayer, updateCameraState);
		}

		private void OnCraftConfigurationChanged()
		{
			if (IsCrewCompartmentAttachPointInUse)
			{
				if (!(CrewCompartment == null))
				{
					return;
				}
				if (Game.InDesignerScene)
				{
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
					{
						LoadIntoCrewCompartment(GetCrewCompartment(this), null);
					});
				}
				else
				{
					LoadIntoCrewCompartment(GetCrewCompartment(this), null);
				}
			}
			else if (!Game.InFlightScene || base.PartScript.CraftScript.RootPart.CommandPod == base.PartScript.CommandPod)
			{
				ActivateEvaForDisconnectedAstronaut();
			}
		}

		private void OnCraftinitialized(ICraftScript craftScript)
		{
			if (!_loadingIntoCrewCompartmentInProgress)
			{
				OnCraftConfigurationChanged();
			}
			if (Game.InFlightScene)
			{
				UpdateWaterPhysics();
				OnMovedToNewCraft(null, craftScript);
			}
			_craftInitialized = true;
		}

		private void OnCrewCompartmentAnimationChanged(CrewCompartmentScript source)
		{
			_crewAnimController.SelectAnimationController();
		}

		private void OnCrewCompartmentStateChanged(CrewCompartmentScript oldVal)
		{
			if (Game.InFlightScene)
			{
				if (CrewCompartment == null)
				{
					base.PartScript.BodyScript.RigidBody.transform.rotation = base.PartScript.Transform.rotation;
					base.PartScript.Transform.rotation = base.PartScript.BodyScript.RigidBody.transform.rotation;
					base.PartScript.Data.Enabled = true;
					base.transform.localPosition = Vector3.zero;
				}
				else
				{
					base.PartScript.Data.Enabled = CrewCompartment.Data.CommandPodEnabledInCompartment;
					_transformInfo.SetParticleSystemEnabled(enabled: false);
				}
				if (base.Data.JetpackAvailable)
				{
					base.PartScript.CraftScript.OnEngineActivationStatusChanged(base.PartScript.Data.Enabled);
				}
				base.PartScript.WaterPhysics.Enabled = EvaActive;
				if (ActiveWhileInCrewCompartment)
				{
					_sharedCameraScript.FpsController.NearClipOverride = () => 0.06f;
				}
				else
				{
					_sharedCameraScript.FpsController.NearClipOverride = null;
				}
				Game.Instance.FlightScene.UpdateActiveControlMaps(base.PartScript.CraftScript.CraftNode);
				if (IsFpsActive)
				{
					UpdateRenderers(CrewCompartment == null);
				}
			}
			if (oldVal != null)
			{
				oldVal.CrewOrientationChanged -= OnCrewOrientationChanged;
				oldVal.CrewAnimationChanged -= OnCrewCompartmentAnimationChanged;
			}
			if (CrewCompartment != null)
			{
				CrewCompartment.CrewOrientationChanged += OnCrewOrientationChanged;
				CrewCompartment.CrewAnimationChanged += OnCrewCompartmentAnimationChanged;
			}
			_crewAnimController.CrewCompartment = CrewCompartment;
		}

		private void OnCrewOrientationChanged(CrewCompartmentScript source)
		{
			RefreshCrewCompartmentPosition();
		}

		private void OnDestroy()
		{
			_craftInitializedMigrator?.Dispose();
			_craftChangedSoiMigrator?.Dispose();
			_nodeNameChangedMigrator?.Dispose();
			base.PartScript.MovedToNewCraft -= OnMovedToNewCraft;
			EnumSetting<PhysicsQualitySettings.WaterPhysicsQuality> enumSetting = Game.Instance?.QualitySettings?.Physics?.WaterPhysics;
			if (enumSetting != null)
			{
				enumSetting.Changed -= OnWaterPhysicsQualityChanged;
			}
			if (_timeManager != null)
			{
				_timeManager.TimeMultiplierModeChanging -= OnTimeMultiplierModeChanging;
			}
			if (_fpsCameraController != null)
			{
				_fpsCameraController.IsSelectedChanged -= OnFpsCameraIsSelectedChanged;
			}
		}

		private void OnFpsCameraIsSelectedChanged(CameraController source, bool selected)
		{
			UpdateRenderers(selected && !ActiveWhileInCrewCompartment);
			UpdateZoomEnabled();
		}

		private void OnIsGroundedChanged()
		{
			if (!IsGrounded)
			{
				_airborneStartTime = Time.time;
			}
			IgnoreForwardInputs = !IsGrounded;
		}

		private void OnMovedToNewCraft(ICraftScript oldCraft, ICraftScript newCraft)
		{
			if (base.Data.CrewMember != null)
			{
				base.Data.CrewMember.NodeId = newCraft.CraftNode.NodeId;
			}
		}

		private void OnNodeNameChanged(string newName, string oldName)
		{
			if (!_loadingIntoCrewCompartmentInProgress && !EvaActive && base.PartScript.Data.IsRootPart)
			{
				PartData partData = base.PartScript.CraftScript.Data.Assembly.Parts.Where((PartData x) => x.PreferredNodeName == oldName).FirstOrDefault();
				if (partData != null)
				{
					partData.PreferredNodeName = newName;
				}
			}
		}

		private void OnPartEnabledChanged()
		{
			UpdateActiveInCrewCompartment();
		}

		private void OnTimeMultiplierModeChanging(TimeMultiplierModeChangedEvent e)
		{
			SetAnimatorEnabled(!e.CurrentMode.WarpMode);
		}

		private void OnTransferButtonClicked(GroupModel model)
		{
			FlightSceneInterfaceScript flightSceneInterfaceScript = Game.Instance.FlightScene.FlightSceneUI as FlightSceneInterfaceScript;
			if (flightSceneInterfaceScript.ActiveMoveCrewRequest == null || !flightSceneInterfaceScript.ActiveMoveCrewRequest.Crew.Contains(this))
			{
				if (flightSceneInterfaceScript.ActiveMoveCrewRequest != null && flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment != null)
				{
					flightSceneInterfaceScript.ShowMessage($"Cannot transfer crew, because you are moving crew from {flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment.Data.Part.Name}#{flightSceneInterfaceScript.ActiveMoveCrewRequest.CrewCompartment.Data.Part.Id}");
					return;
				}
				flightSceneInterfaceScript.AddMoveCrewRequest(this);
				model.Update();
			}
			else
			{
				flightSceneInterfaceScript.CancelMoveCrewRequest(this);
				model.Update();
			}
		}

		private void OnWaterPhysicsQualityChanged(object sender, SettingChangedEventArgs<PhysicsQualitySettings.WaterPhysicsQuality> e)
		{
			if (Game.InFlightScene)
			{
				UpdateWaterPhysics();
			}
		}

		private void ProcessCollision(Collision collision)
		{
			if (_collisionCount < 300)
			{
				_collisions[_collisionCount].Update(collision);
				_collisionCount++;
			}
			else
			{
				_overFlowCollisions++;
				Debug.LogWarning($"{Time.frameCount} - Too many concurrent collisions ({_collisionCount + _overFlowCollisions}, max: {300}) for tracking array...ignoring");
			}
			if (Masks.IsLayerInMask(collision.gameObject.layer, 603979776))
			{
				IsGroundedTerrain = true;
				_bodyForLocalUp = null;
				return;
			}
			if (_colliderRigidBody != collision.rigidbody && _bodyForLocalUp != collision.rigidbody)
			{
				_bodyForLocalUp = collision.rigidbody;
				_localUpFromBody = collision.transform.InverseTransformDirection(base.PartScript.BodyScript.RigidBody.transform.up);
			}
			_colliderRigidBody = collision.rigidbody;
		}

		private bool ProcessCollision(Collision collision, out ContactPoint? primaryContact)
		{
			if (collision.contactCount > 0)
			{
				primaryContact = collision.contacts[0];
			}
			else
			{
				primaryContact = null;
			}
			return Masks.IsLayerInMask(collision.gameObject.layer, 603979776);
		}

		private IEnumerator ProcessCompletedPhysicsCycle()
		{
			while (true)
			{
				yield return _waitForFixedUpdate;
				if (AutoUprightCharacter && ShouldInterpolate)
				{
					UprightCharacter();
				}
				if (EvaActive)
				{
					DesiredUp = CalculateDesiredUp();
				}
			}
		}

		private void RefreshCrewCompartmentPosition()
		{
			if (Game.InFlightScene)
			{
				SetTransformToCrewCompartment(base.PartScript.BodyScript.RigidBody.transform, CrewCompartment);
			}
			else
			{
				SetTransformToCrewCompartment(base.PartScript.Transform, CrewCompartment);
			}
		}

		private void SetAnimatorEnabled(bool enabled)
		{
			_crewAnimController.Animator.enabled = enabled;
			_fullBodyIk.enabled = enabled;
			_handPosers.Foreach(delegate(HandPoser x)
			{
				x.enabled = enabled;
			});
		}

		private void SetCharacterVisibility(bool visible, bool colliderEnabled)
		{
			Renderer[] renderers = _renderers;
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].enabled = visible;
			}
			SetAnimatorEnabled(visible);
			_controllerCollider.enabled = colliderEnabled;
			BoxCollider[] clickyColliders = _clickyColliders;
			for (int i = 0; i < clickyColliders.Length; i++)
			{
				clickyColliders[i].enabled = visible && !colliderEnabled;
			}
		}

		private void SetEvaCameraModesInUse(bool evaCamerasInUse, bool updateCameraState)
		{
			if (updateCameraState)
			{
				_sharedCameraScript.SetEvaCamerasEnabled(evaCamerasInUse);
			}
			if (evaCamerasInUse)
			{
				_fpsCameraController.SetVantageScript(_fpsVantage);
				_thirdPersonCameraController.StaticTarget = this;
				if (!_fpsCameraControllerSubscribed)
				{
					_fpsCameraController.IsSelectedChanged += OnFpsCameraIsSelectedChanged;
					_fpsCameraControllerSubscribed = true;
				}
			}
			else
			{
				if (_fpsCameraController.IsSelected)
				{
					OnFpsCameraIsSelectedChanged(_fpsCameraController, selected: false);
				}
				_fpsCameraController.IsSelectedChanged -= OnFpsCameraIsSelectedChanged;
				_fpsCameraControllerSubscribed = false;
			}
			if (updateCameraState)
			{
				_fpsCameraController.SetEnabled(evaCamerasInUse, notifyCameraManager: true);
			}
		}

		private bool ShowTakeControlButton()
		{
			return Game.Instance.FlightScene.CraftNode.CraftScript.ActiveCommandPod != base.PartScript.CommandPod;
		}

		private void SlowDownCharacter(Rigidbody body, Vector3 bodyVelocity, float bodyVelocityMag)
		{
			float num = Mathf.Clamp(base.PartScript.CraftScript.GravityMagnitude, 0.5f, float.MaxValue);
			float num2 = 1f / num * Mathf.Clamp(bodyVelocityMag, 0f, 3f);
			Vector3 force = -bodyVelocity * num2;
			body.AddForce(force, ForceMode.Acceleration);
		}

		private void SwitchToCommandPod()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (!instance.ChangePlayersActiveCommandPodImmediate(base.PartScript.CommandPod, base.PartScript.CraftScript.CraftNode))
			{
				instance.FlightSceneUI.ShowMessage(base.Data.CrewName + " is too far away to control");
			}
		}

		private void UnloadFromCrewCompartment(bool setTransform = true)
		{
			if (Game.InFlightScene)
			{
				UnloadingFromCrewCompartmentInProgress = true;
				foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
				{
					PartConnection[] array = attachPoint.PartConnections.ToArray();
					foreach (PartConnection partConnection in array)
					{
						if (!partConnection.IsPhysicsJoint)
						{
							continue;
						}
						IBodyJoint[] array2 = base.PartScript.BodyScript.Joints.ToArray();
						foreach (IBodyJoint bodyJoint in array2)
						{
							if (partConnection == bodyJoint.PartConnection)
							{
								IBodyJoint bodyJoint2 = bodyJoint;
								if (bodyJoint2 != null && !bodyJoint2.PartConnection.IsDestroyed)
								{
									bodyJoint2.Destroy();
									base.PartScript.BodyScript.RigidBody.WakeUp();
								}
							}
						}
					}
					if (setTransform)
					{
						base.transform.rotation = base.PartScript.BodyScript.Transform.rotation;
					}
					UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
					{
						if (x == 0)
						{
							UnloadingFromCrewCompartmentInProgress = false;
						}
					}, 2);
				}
				if (setTransform)
				{
					SetTransformToCrewExit(base.PartScript.BodyScript.RigidBody.transform, _controllerCollider, CrewCompartment);
				}
			}
			else if (setTransform)
			{
				SetTransformToCrewExit(base.PartScript.Transform, _controllerCollider, CrewCompartment);
			}
		}

		private void UpdateAcceleration(Rigidbody body)
		{
			Vector3 velocity = body.velocity;
			Vector3 vector = Vector3.zero;
			if (_accelVelocities.Count < _velocitiesMaxItems)
			{
				vector = ((_accelVelocities.Count <= 0) ? body.velocity : _accelVelocities.Peek());
			}
			else
			{
				while (_accelVelocities.Count >= _velocitiesMaxItems)
				{
					vector = _accelVelocities.Dequeue();
				}
			}
			_accelVelocities.Enqueue(velocity);
			float num = Time.fixedDeltaTime * (float)_accelVelocities.Count;
			Acceleration = (velocity - vector) / num;
		}

		private void UpdateActiveInCrewCompartment()
		{
			ActiveWhileInCrewCompartment = CrewCompartment != null && base.PartScript.Data.Enabled;
		}

		private void UpdateAnimationController()
		{
			CraftControls controls = base.PartScript.CommandPod.Controls;
			CrewAnimController crewAnimController = _crewAnimController;
			crewAnimController.InsideAtmosphere = InAtmosphere;
			crewAnimController.ZeroGeeAnimation = !Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.IsSurfaceLocked;
			crewAnimController.ForwardInput = controls.EvaMoveFwdAft;
			crewAnimController.TurnInput = controls.EvaTurn;
			crewAnimController.Speed = _bodySpeed;
			crewAnimController.VerticalSpeed = _currentVerticalSpeed;
			crewAnimController.ForwardSpeed = _currentForwardSpeed;
			crewAnimController.SideSpeed = _currentStrafeSpeed;
			crewAnimController.InWater = base.PartScript.WaterPhysics.IsInWater;
			bool flag = ((IsGroundedOnRigidBody && _rigidBodyCollisionInfo != null) ? _rigidBodyCollisionInfo.GroundedOnFeet : IsGrounded);
			crewAnimController.InAir = !flag && (AirborneTime > 0.5f || RecentlyJumped);
			crewAnimController.Update();
		}

		private void UpdateCommandReplication(bool isPlayer, ICommandPod other)
		{
			ICommandPod commandPod = CrewCompartment?.PartScript.CommandPod;
			if (isPlayer && ActiveWhileInCrewCompartment && commandPod != null && commandPod != base.PartScript.CommandPod)
			{
				_backupReplicateControls = commandPod.ReplicateControls;
				_backupReplicateStageActivation = commandPod.ReplicateStageActivations;
				_backupReplicateActivationGroups = commandPod.ReplicateActivationGroups;
				commandPod.ReplicateControls = true;
				commandPod.ReplicateStageActivations = true;
				commandPod.ReplicateActivationGroups = ActivationGroupReplicationMode.All;
				base.PartScript.CommandPod.SetAutopilotEmulation(commandPod);
				if (CrewCompartmentCommandPod != null)
				{
					ICommandPod crewCompartmentCommandPod = CrewCompartmentCommandPod;
					for (int i = 1; i <= base.PartScript.CommandPod.ActivationGroupNames.Count; i++)
					{
						base.PartScript.CommandPod.SetActivationGroupState(i, crewCompartmentCommandPod.GetActivationGroupState(i));
					}
					base.PartScript.CommandPod.Controls.Throttle = crewCompartmentCommandPod.Controls.Throttle;
				}
				_replicatedCommandPod = commandPod;
			}
			else if (other == null || !other.IsEva)
			{
				if (_replicatedCommandPod != null)
				{
					_replicatedCommandPod.ReplicateControls = _backupReplicateControls;
					_replicatedCommandPod.ReplicateStageActivations = _backupReplicateStageActivation;
					_replicatedCommandPod.ReplicateActivationGroups = _backupReplicateActivationGroups;
				}
				base.PartScript.CommandPod.SetAutopilotEmulation(null);
			}
		}

		private void UpdateControllerColiderParent()
		{
			bool flag = AllowBodyRotation && base.PartScript.WaterPhysics.IsInWater;
			if (flag != _controllerColliderRotatesWithAnimation)
			{
				if (flag)
				{
					_controllerCollider.transform.parent = _hips;
					_controllerCollider.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					_controllerCollider.transform.localPosition = Vector3.zero;
				}
				else
				{
					_controllerCollider.transform.parent = base.PartScript.Transform;
					_controllerCollider.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
					_controllerCollider.transform.localPosition = Vector3.zero;
				}
			}
			_controllerColliderRotatesWithAnimation = flag;
		}

		private void UpdateCrewMemberLocation()
		{
			if (base.Data.CrewMember != null)
			{
				base.Data.CrewMember.Location = base.PartScript.CraftScript.CraftNode.Parent.Name;
			}
		}

		private void UpdateGrapplingHook()
		{
			Vector3 vector = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
			if (_thirdPersonCameraController.IsSelected)
			{
				Transform obj = Game.Instance.FlightScene.FlightSceneUI.Crosshairs.transform;
				Vector3 b = new Vector3((float)Screen.width / 1920f, (float)Screen.height / 1080f, 0f);
				float num = 1f / _thirdPersonCameraController.CurrentZoom;
				obj.position = Vector3.Lerp(b: vector + num * Vector3.Scale(new Vector3(250f, 750f, 0f), b), a: obj.position, t: Time.deltaTime * 10f);
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.Crosshairs.transform.position = vector;
			}
			CraftControls controls = base.PartScript.CommandPod.Controls;
			if (controls.EvaShootTether)
			{
				if (!_evaShootTetherProcessed)
				{
					_evaShootTetherProcessed = true;
					Camera nearCamera = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera;
					if (GrapplingHook != null)
					{
						if (GrapplingHook.BodyFrom != base.PartScript.BodyScript.RigidBody && GrapplingHook.BodyTo != base.PartScript.BodyScript.RigidBody)
						{
							DestroyGrapplingHook(immediate: false, resetAdjustmentSlider: true);
						}
						else
						{
							Rigidbody rigidbody = GrapplingHook.BodyTo;
							IPartScript partTo = GrapplingHook.PartTo;
							Vector3 positionFrom = GrapplingHook.PositionFrom;
							GameObject gameObject = null;
							if (GrapplingHook.AutoDeleteToBody)
							{
								gameObject = GrapplingHook.BodyTo.gameObject;
							}
							DestroyGrapplingHook(immediate: true, resetAdjustmentSlider: false);
							if (gameObject != null)
							{
								rigidbody = gameObject.AddComponent<Rigidbody>();
								rigidbody.isKinematic = true;
							}
							GrapplingHook = ConnectViaRaycast(rigidbody, partTo, rigidbody.transform.TransformPoint(positionFrom), nearCamera.ScreenPointToRay(Game.Instance.FlightScene.FlightSceneUI.Crosshairs.transform.position), 750f);
							if (GrapplingHook == null)
							{
								base.PartScript.CommandPod.Controls.EvaTetherLengthOffset = 0f;
							}
						}
					}
					else
					{
						GrapplingHook = ConnectViaRaycast(base.PartScript.BodyScript.RigidBody, base.PartScript, base.transform.position, nearCamera.ScreenPointToRay(Game.Instance.FlightScene.FlightSceneUI.Crosshairs.transform.position), 750f);
						if (GrapplingHook != null)
						{
							GrapplingHook.LineOffsetFrom = new Vector3(0f, 0.35f, 0f);
						}
					}
				}
			}
			else
			{
				_evaShootTetherProcessed = false;
			}
			if (GrapplingHook != null)
			{
				float evaTetherLength = controls.EvaTetherLength;
				if (evaTetherLength != 0f && (_fpsCameraController.IsSelected || UnityEngine.Input.mouseScrollDelta.sqrMagnitude == 0f) && !Game.Instance.FlightScene.ViewManager.MapViewManager.IsInForeground)
				{
					AdjustTetherLength(evaTetherLength);
				}
			}
			if (!(GrapplingHook != null) || (GrapplingHook.EvaFrom != null && GrapplingHook.EvaTo != null))
			{
				return;
			}
			if (GrapplingHook.EvaFrom != null && GrapplingHook.CraftTo != null)
			{
				FuelTankScript fuelTank = GrapplingHook.EvaFrom._fuelTank;
				if (fuelTank != null)
				{
					fuelTank.CraftFuelSource.AddFuel(fuelTank.TotalCapacity * (double)Time.deltaTime * 0.10000000149011612);
				}
			}
			else if (GrapplingHook.EvaTo != null && GrapplingHook.CraftFrom != null)
			{
				FuelTankScript fuelTank2 = GrapplingHook.EvaTo._fuelTank;
				if (fuelTank2 != null)
				{
					fuelTank2.CraftFuelSource.AddFuel(fuelTank2.TotalCapacity * (double)Time.deltaTime * 0.10000000149011612);
				}
			}
		}

		private void UpdateGravitySuitableAnimationController()
		{
			_crewAnimController.LowGravityAnimation = base.PartScript.CraftScript.CraftNode.Parent.PlanetData.SurfaceGravity < 4.0;
		}

		private void UpdateJumpState()
		{
			if (_jumpState == JumpState.Start || _jumpState == JumpState.Prepare)
			{
				return;
			}
			CraftControls controls = base.PartScript.CommandPod.Controls;
			if (IsGrounded && _jumpState == JumpState.None && (_inputs.EvaJump.GetButtonDownIfEnabled() || controls.EvaAnalogJump > 0.5f) && !_crewAnimController.PreventJump)
			{
				_jumpState = JumpState.Prepare;
				Func<bool> isReady = _crewAnimController.PrepareForJump();
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					bool num = isReady();
					if (num)
					{
						_jumpState = JumpState.Start;
						_jumpEndTime = Time.time + 2f;
					}
					return !num;
				});
			}
			else if ((_inputs.EvaJump.GetButton() || controls.EvaAnalogJump > 0.5f) && Time.time < _jumpEndTime)
			{
				_jumpState = JumpState.Continue;
			}
			else
			{
				_jumpState = JumpState.None;
			}
		}

		private void UpdateKinematicTurning()
		{
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			CraftControls controls = base.PartScript.CommandPod.Controls;
			Vector3 up = rigidBody.transform.up;
			Vector3 vector = Vector3.Cross(up, -(rigidBody.rotation * Vector3.right));
			float num = controls.EvaTurn;
			if (IsPlayerCraft)
			{
				if (IsFpsActive)
				{
					if (IsGrounded)
					{
						if (true)
						{
							vector = Vector3.Cross(up, -_fpsCameraController.CameraTransform.right);
							_fpsCameraController.DeltaRotation = new Vector2(Mathf.Clamp(_fpsCameraController.DeltaRotation.x, -89f, 89f), 0f);
						}
					}
					else
					{
						vector = _fpsCameraController.CameraTransform.forward;
						up = _fpsCameraController.CameraTransform.up;
						_fpsCameraController.DeltaRotation = Vector2.zero;
					}
				}
				else if (Game.Instance.Settings.Game.Flight.AstronautFollowCamera.Value && num == 0f && controls.EvaMoveFwdAft != 0f)
				{
					num = Mathf.Clamp(base.transform.InverseTransformDirection(Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Transform.forward).x, -1f, 1f);
				}
				if (num != 0f)
				{
					Vector3 vector2 = Vector3.Cross(up, vector);
					vector = Vector3.Lerp(vector, Mathf.Sign(num) * vector2, Time.deltaTime * _perfData.TurningSpeedGround * Mathf.Abs(num));
				}
			}
			Quaternion rot = Quaternion.LookRotation(vector, up);
			rigidBody.MoveRotation(rot);
		}

		private void UpdateMaxSpeeds()
		{
			float num = Mathf.Max(Mathf.Clamp01(base.PartScript.CraftScript.GravityMagnitude / 9.81f), 0.25f);
			num *= (IsWalking ? 0.25f : 1f);
			if (IsGrounded)
			{
				MaxForwardSpeed = _perfData.MaxForwardSpeedGround;
				MaxStrafeSpeed = _perfData.MaxStrafeSpeedGround;
			}
			else
			{
				float maxStrafeSpeed = (MaxForwardSpeed = float.MaxValue);
				MaxStrafeSpeed = maxStrafeSpeed;
			}
			MaxForwardSpeed *= num;
			MaxStrafeSpeed *= num;
		}

		private void UpdateMovement(out Vector3 totalForce, out Vector3 totalForceJetpack)
		{
			totalForce = Vector3.zero;
			totalForceJetpack = Vector3.zero;
			float num = 0f;
			UpdateMaxSpeeds();
			CraftFuelSource craftFuelSource = _fuelTank?.CraftFuelSource;
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			CraftControls controls = base.PartScript.CommandPod.Controls;
			float num2 = controls.EvaMoveFwdAft;
			float evaStrafe = controls.EvaStrafe;
			float evaRoll = controls.EvaRoll;
			float evaPitch = controls.EvaPitch;
			Vector3 forward = rigidBody.transform.forward;
			Vector3 right = rigidBody.transform.right;
			Vector3 up = rigidBody.transform.up;
			bool flag = JetpackEnabled && craftFuelSource != null && !craftFuelSource.IsEmpty;
			if (IgnoreForwardInputs && !Game.Instance.Inputs.EvaMoveFwdAft.GetButton())
			{
				IgnoreForwardInputs = false;
			}
			if (IsGrounded || IsInWater || flag)
			{
				if (evaStrafe != 0f)
				{
					float num3 = Mathf.Clamp01(Mathf.Abs(_currentStrafeSpeed) / MaxStrafeSpeed);
					totalForce += (1f - num3) * evaStrafe * ForceStrafe * right;
				}
				if (num2 != 0f)
				{
					if (!IgnoreForwardInputs)
					{
						float num4 = Mathf.Clamp01(Mathf.Abs(_currentForwardSpeed) / MaxForwardSpeed);
						totalForce += (1f - num4) * num2 * ForceForward * forward;
					}
					else
					{
						num2 = 0f;
					}
				}
				if (!IsGrounded)
				{
					totalForceJetpack += totalForce;
					num += Mathf.Abs(num2) + Mathf.Abs(evaStrafe);
				}
			}
			switch (_jumpState)
			{
			case JumpState.Start:
			{
				Vector3 vector = 5f * _perfData.JumpStrength * up;
				rigidBody.AddForce(vector * JumpPowerScalar, ForceMode.Impulse);
				_jumpState = JumpState.Continue;
				break;
			}
			case JumpState.Continue:
				rigidBody.AddForce(6.25f * _perfData.JumpStrength * JumpPowerScalar * up);
				break;
			default:
				Debug.LogError($"Unsupported jump state: {_jumpState}");
				break;
			case JumpState.Prepare:
			case JumpState.None:
				break;
			}
			float num5 = 0.01f * _perfData.TurningTorqueAir * (IsInWater ? 1f : JetpackPowerScalar);
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			if (craftFuelSource != null && !craftFuelSource.IsEmpty)
			{
				if (AllowBodyRotation && flag)
				{
					if (evaRoll != 0f)
					{
						zero += rigidBody.inertiaTensor.z * (0f - evaRoll) * num5 * forward;
						num += Mathf.Abs(evaRoll);
					}
					if (evaPitch != 0f)
					{
						zero += rigidBody.inertiaTensor.x * evaPitch * num5 * right;
						num += Mathf.Abs(evaPitch);
					}
					zero2 += zero;
				}
				if (!UseKinematicTurning && flag)
				{
					float evaTurn = controls.EvaTurn;
					if (evaTurn != 0f)
					{
						zero += rigidBody.inertiaTensor.y * num5 * evaTurn * up;
					}
					num += Mathf.Abs(evaTurn);
					zero2 += zero;
				}
			}
			_turningTorqueJetpack = zero2;
			_turningTorqueJetpackMag = zero2.sqrMagnitude;
			rigidBody.AddTorque(zero);
			float evaMoveUpDown = controls.EvaMoveUpDown;
			if (evaMoveUpDown != 0f && (flag || IsInWater))
			{
				totalForce += _perfData.ForceUpJetpack * (IsInWater ? 1f : JetpackPowerScalar) * evaMoveUpDown * up;
				totalForceJetpack += totalForce;
				num += Mathf.Abs(evaMoveUpDown);
			}
			if (!IsSwimmingEnabled && craftFuelSource != null)
			{
				_fuelBurned += craftFuelSource.RemoveFuel(num * _fuelConsumption * Time.deltaTime * JetpackPowerScalar);
			}
			rigidBody.AddForce(totalForce * 0.01f);
		}

		private void UpdateNozzles()
		{
			bool flag = _movementForceJetpackMag != 0f;
			bool flag2 = _turningTorqueJetpackMag != 0f;
			if (!IsSwimmingEnabled && (flag || flag2))
			{
				if (flag)
				{
					_transformInfo.UpperLeftJetpackNozzle.forward -= _movementForceJetpack;
					_transformInfo.UpperRightJetpackNozzle.forward -= _movementForceJetpack;
					_transformInfo.LowerLeftJetpackNozzle.forward -= _movementForceJetpack;
					_transformInfo.LowerRightJetpackNozzle.forward -= _movementForceJetpack;
				}
				if (flag2)
				{
					if (base.PartScript.CommandPod.Controls.EvaPitch != 0f)
					{
						Vector3 normalized = Vector3.Cross(_turningTorqueJetpack.normalized, base.transform.up).normalized;
						_transformInfo.UpperLeftJetpackNozzle.forward -= normalized;
						_transformInfo.UpperRightJetpackNozzle.forward -= normalized;
						_transformInfo.LowerLeftJetpackNozzle.forward += normalized;
						_transformInfo.LowerRightJetpackNozzle.forward += normalized;
					}
					else
					{
						Vector3 normalized2 = Vector3.Cross(_turningTorqueJetpack.normalized, _transformInfo.UpperLeftOriginal).normalized;
						_transformInfo.UpperLeftJetpackNozzle.forward -= normalized2;
						_transformInfo.UpperRightJetpackNozzle.forward += normalized2;
						_transformInfo.LowerLeftJetpackNozzle.forward -= normalized2;
						_transformInfo.LowerRightJetpackNozzle.forward += normalized2;
					}
				}
				_transformInfo.SetParticleSystemEnabled(enabled: true);
			}
			else
			{
				_transformInfo.SetParticleSystemEnabled(enabled: false);
			}
		}

		private void UpdateRenderers(bool shadowsOnly)
		{
			ShadowCastingMode shadowCastingMode = ((!shadowsOnly) ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly);
			Renderer[] renderers = _renderers;
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].shadowCastingMode = shadowCastingMode;
			}
		}

		private void UpdateWaterPhysics()
		{
			IBodyWaterPhysics waterPhysics = base.PartScript.BodyScript.WaterPhysics;
			PrecisionModeType precisionMode = (base.PartScript.WaterPhysics.PrecisionMode = PrecisionModeType.High);
			waterPhysics.PrecisionMode = precisionMode;
		}

		private void UpdateZoomEnabled()
		{
			_fpsCameraController.FovZoomEnabled = Device.IsMobileBuild || GrapplingHook == null;
		}

		private void UprightCharacter()
		{
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			float t = Mathf.Max(Mathf.Clamp01(Time.deltaTime * (base.PartScript.CraftScript.GravityMagnitude * rigidBody.mass)), 0.01f);
			Vector3 vector = DesiredUp;
			Vector3 up = rigidBody.transform.up;
			if ((double)Mathf.Abs(Vector3.Dot(up, vector)) < 0.99)
			{
				vector = Vector3.Lerp(up, vector, t);
			}
			Quaternion rot = Quaternion.LookRotation(Vector3.Cross(vector, -(rigidBody.rotation * Vector3.right)), vector);
			rigidBody.MoveRotation(rot);
		}
	}
}

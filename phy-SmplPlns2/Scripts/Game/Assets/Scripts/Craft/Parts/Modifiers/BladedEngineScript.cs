using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Utils;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer.SyncData;
using Assets.Scripts.Rendering;
using Assets.Scripts.Settings;
using Jundroo.Common.Events;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[BurstCompile(CompileSynchronously = true)]
	public class BladedEngineScript : EngineScript, IRpmSource, IVariableOutput
	{
		protected enum BladeMotionType
		{
			PropBlur = 0,
			IndependentUpdating = 1,
			Both = 2,
			None = 3
		}

		protected class BladeAssembly
		{
			public Transform Blade { get; private set; }

			public Transform Grip { get; private set; }

			public Transform Root { get; private set; }

			public BladeAssembly(Transform root)
			{
				Root = root;
				Grip = Root.Find("Grip");
				Blade = Root.Find("Blade");
				if (Blade.localEulerAngles.y != 0f)
				{
					Debug.LogWarning("The Blade transform in bladed engines must have localEulerAngles.y equal to zero for pitch adjustments to work");
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker DrawPropsInFlightScene = new ProfilerMarker("BladedEngineScript.DrawPropsInFlightScene");
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void UpdatePropBlurMatrices_000060AD_0024PostfixBurstDelegate([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees);

		internal static class UpdatePropBlurMatrices_000060AD_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<UpdatePropBlurMatrices_000060AD_0024PostfixBurstDelegate>(UpdatePropBlurMatrices).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<Matrix4x4*, int, float3*, float3*, quaternion*, quaternion*, float, void>)functionPointer)(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
						return;
					}
				}
				UpdatePropBlurMatrices_0024BurstManaged(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
			}
		}

		public const float MaxPitchDegrees = 75f;

		public const float MinPitchDegreeForAuto = 4f;

		public const float MinPitchInputValueForAuto = 4f / 75f;

		public const float RpmGovernorMaxChangeRate = 0.5f;

		protected const float PitchSoundMaxChangePerSecond = 0.5f;

		private const float MaxAlphaSpeed = 1000f;

		private const int MaxInstancedMeshes = 511;

		private const float MaxSpreadSpeed = 1000f;

		private const float MaxTimeOverstressed = 10f;

		private const float MinEngineVolume = 0.1f;

		private const float MinRpmForBlurredBlades = 50f;

		private List<BladeAssembly> _additionalPropellers = new List<BladeAssembly>();

		private List<BladeAssembly> _allPropellers = new List<BladeAssembly>();

		private bool _autoPitchControlReverse;

		private BladedEngineData _bladedEngine;

		[SerializeField]
		private Mesh _bladeMeshCombined;

		private BladeMotionType _bladeMotion;

		private InputControllerScript _bladePitchInput;

		private InputControllerScript _bladePitchInputAlt;

		private ReflectionProbe _craftReflectionProbe;

		private EnumSetting<CraftQualitySettings.CraftReflectionsQuality> _craftReflectionsSetting;

		private Transform _defaultHeadParent;

		private Vector3 _dragForcePrimary;

		private float _dragTorque;

		private AudioSource _engineAudioSource;

		private float _engineAudioVolume;

		private float _engineOverSpeedStartTime = float.MaxValue;

		[SerializeField]
		[Range(1f, 1000f)]
		private float _engineTorqueScale = 1f;

		private ReflectionProbe _globalReflectionProbe;

		private float _independentRotorAmplitudeAdjustment;

		private float _independentRotorFrequencyAdjustment;

		private bool _independentRotorUpdateActive;

		private bool _independentRotorUpdateEnabled;

		private float _irSignaturePower;

		private Vector3 _liftForcePrimary;

		private bool _mapLocationChanged;

		private BladeAssembly _masterPropeller;

		private PropellerScript _masterPropPhysicsScript;

		private GameObject _motorGameObject;

		private ConfigurableJoint _motorHubJoint;

		private Rigidbody _motorRigidBody;

		private float _netEngineTorqueMag;

		private bool _overspeeding;

		private Vector3 _partScale;

		[SerializeField]
		private Material _propBlurMaterial;

		private Matrix4x4[] _propBlurMatrices;

		[SerializeField]
		private Material _propDefaultMaterial;

		private Transform _propellerAssembly;

		private Dictionary<Transform, Collider> _propellerColliderMap = new Dictionary<Transform, Collider>();

		private GameObject _propellerContainer;

		private Rigidbody _propellerContainerRigidBody;

		private float _propellerContainerRigidBodyAngularDragBackup;

		private float _propellerContainerRigidBodyMaxAngularVelocityBackup;

		private List<MeshRenderer> _propellerMeshRenderers;

		private MaterialPropertyBlock _propMaterialPropertyBlock;

		private BoxCollider _propTriggerColliderForWater;

		private Transform _rotatingHeadAssembly;

		private float _rpm;

		[SerializeField]
		private bool _showDebugInfo;

		private float _startingPitch;

		private float _targetPitch;

		private float _timePaused;

		private bool _windmillingPropeller;

		public Aerofoil Airfoil { get; private set; }

		public Transform BladeAssemblyHub => _propellerAssembly;

		public int BladeCount => Data.BladeCount;

		public Rigidbody BodyNonRotatingBase => _motorRigidBody;

		public Rigidbody BodyRotatingBladeAssembly => _propellerContainerRigidBody;

		public float ChordScale
		{
			get
			{
				return _bladedEngine.ChordScale;
			}
			set
			{
				_bladedEngine.ChordScale = value;
				UpdateScale();
			}
		}

		public BladedEngineData Data => _bladedEngine;

		public override DesignerThrustTypes DesignerThrustType => DesignerThrustTypes.LegacyProp;

		public float Diameter
		{
			get
			{
				return _bladedEngine.Diameter;
			}
			set
			{
				_bladedEngine.Diameter = value;
				UpdateScale();
			}
		}

		public bool DirectPitchControl { get; set; }

		public float DragScalar { get; protected set; } = 1f;

		public float DragTorque => _dragTorque;

		public float EngineTorque { get; private set; }

		public float EstimateOfUnderwaterPercent => _part.EstimateOfUnderwaterPercent;

		public virtual string FriendlyName => "Propeller Engine";

		public float Fuel => _part.Aircraft.Fuel;

		public float GovernedRpm { get; private set; }

		public override float IRSignature => base.ThrottleInput.Value * base.Engine.PowerMultiplier * _irSignaturePower * 0.1f;

		public Vector3 LiftDirection => BladeAssemblyHub.forward;

		public Vector3 LiftForcePrimary => _liftForcePrimary;

		public float LiftScalar { get; set; } = 1f;

		public float MaxPower
		{
			get
			{
				return _bladedEngine.MaxPower;
			}
			set
			{
				_bladedEngine.MaxPower = value;
			}
		}

		public float MaxRpm => _bladedEngine.MaxRpm;

		public float MaxSlip => _masterPropPhysicsScript.MaxSlip;

		public float MinPower
		{
			get
			{
				return _bladedEngine.MinPower;
			}
			set
			{
				_bladedEngine.MinPower = value;
			}
		}

		public BladedEngineData.ControlTypes PitchControlType
		{
			get
			{
				return _bladedEngine.PitchControlType;
			}
			set
			{
				_bladedEngine.PitchControlType = value;
			}
		}

		public float Power
		{
			get
			{
				return _bladedEngine.Power;
			}
			set
			{
				_bladedEngine.Power = value;
			}
		}

		public int PropellerCount
		{
			get
			{
				return _bladedEngine.BladeCount;
			}
			set
			{
				_bladedEngine.BladeCount = value;
				UpdatePropellers();
			}
		}

		public bool PropellerPhysicsEnabled { get; private set; }

		public float PropellerPitch
		{
			get
			{
				return _bladedEngine.PropellerPitch;
			}
			set
			{
				if (value != _bladedEngine.PropellerPitch)
				{
					_bladedEngine.PropellerPitch = value;
					UpdatePitchRepresentation();
				}
			}
		}

		public float PropellerPitchDegrees => PropellerPitch * 75f;

		public float PropellerPitchMaximumDeflectionScale
		{
			get
			{
				return _bladedEngine.PropellerPitchScale;
			}
			set
			{
				UpdatePitchRepresentation();
				_bladedEngine.PropellerPitchScale = value;
			}
		}

		public string PropellerType
		{
			get
			{
				return _bladedEngine.BladeStyle;
			}
			set
			{
				_bladedEngine.BladeStyle = value;
				UpdatePropellerMeshes();
			}
		}

		public float ReportedRpm => RpmAbs;

		public virtual int ReportedRpmPriority => 0;

		public PartScript ReportingPartScript => base.PartScript;

		public bool ReverseRotation => _bladedEngine.ReverseRotation;

		public Transform RotatingHeadAssembly
		{
			get
			{
				return _rotatingHeadAssembly;
			}
			set
			{
				_rotatingHeadAssembly = value;
			}
		}

		public float Rpm
		{
			get
			{
				return _rpm;
			}
			private set
			{
				_rpm = value;
				RpmAbs = Mathf.Abs(_rpm);
				RpmPercentOfMax = RpmAbs / MaxRpm;
				RpmPercentOfMaxClamp01 = Mathf.Clamp01(RpmPercentOfMax);
			}
		}

		[VariableOutput("RPM")]
		public float RpmAbs { get; private set; }

		public float RpmPercentOfMax { get; private set; }

		public float RpmPercentOfMaxClamp01 { get; private set; }

		public bool SimulatePropellersAtZeroThrottle { get; set; }

		public BladedEngineData.ControlTypes ThrottleControlType
		{
			get
			{
				return _bladedEngine.ThrottleControlType;
			}
			set
			{
				_bladedEngine.ThrottleControlType = value;
			}
		}

		public bool ThrottleGovernorActive
		{
			get
			{
				if (ThrottleGovernorEnabled)
				{
					return base.ThrottleInput.Value >= _bladedEngine.ThrottleGovernorEngagePercent;
				}
				return false;
			}
		}

		public bool ThrottleGovernorEnabled => ThrottleControlType == BladedEngineData.ControlTypes.Auto;

		public override float Thrust => (_dragForcePrimary + _liftForcePrimary).magnitude / 0.01f;

		protected BladeMotionType BladeMotion
		{
			get
			{
				return _bladeMotion;
			}
			set
			{
				_bladeMotion = value;
				switch (_bladeMotion)
				{
				case BladeMotionType.Both:
					_independentRotorUpdateActive = true;
					break;
				case BladeMotionType.IndependentUpdating:
					_independentRotorUpdateActive = true;
					break;
				case BladeMotionType.None:
					_independentRotorUpdateActive = false;
					break;
				case BladeMotionType.PropBlur:
					_independentRotorUpdateActive = false;
					break;
				}
			}
		}

		protected virtual Vector3 CenterOfMassOffset => Vector3.zero;

		protected float EngineAudioPitchLerpSpeed { get; set; } = 0.25f;

		protected bool OverspeedingEnabled { get; private set; }

		protected virtual bool OverspeedingEnabledDefault
		{
			get
			{
				if (PitchControlType == BladedEngineData.ControlTypes.Manual)
				{
					return ThrottleControlType == BladedEngineData.ControlTypes.Manual;
				}
				return false;
			}
		}

		protected virtual float RpmReductionPercent => 1f / 3f;

		protected float SecondaryMotorTorques { get; set; }

		protected bool UpdatePitchContinuously { get; set; }

		private float BladePitchInputValue { get; set; }

		private Vector3 CenterOfMassBase { get; set; }

		private Transform ColliderContainer { get; set; }

		public void CalculateForces(float angleOfAttack, float rpm, float fluidDensityRatio, out Vector3 lift, out Vector3 drag)
		{
			_masterPropPhysicsScript.CalculateForces(angleOfAttack, rpm, fluidDensityRatio, out lift, out drag);
		}

		public void DestroyEngine(string message)
		{
			if (base.EngineDestroyed)
			{
				return;
			}
			if (_independentRotorUpdateActive && _independentRotorUpdateEnabled)
			{
				SetIndependentUpdateEnabled(enabled: false);
				BladeMotion = BladeMotionType.None;
			}
			base.EngineDestroyed = true;
			ConfigurableJoint motorHubJoint = _motorHubJoint;
			if (!(motorHubJoint != null))
			{
				return;
			}
			motorHubJoint.connectedBody.mass = 0.099999994f;
			motorHubJoint.connectedBody.linearDamping = 1f;
			motorHubJoint.connectedBody.useGravity = true;
			motorHubJoint.connectedBody.angularDamping = 1f;
			motorHubJoint.connectedBody.transform.parent = base.PartScript.Aircraft.WorldRigidBodies;
			if (!string.IsNullOrEmpty(message) && base.PartScript.Aircraft.IsPrimaryLocalPlayer)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage(message);
			}
			foreach (BladeAssembly propeller in _allPropellers)
			{
				UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
				{
					if (propeller != null && propeller.Root != null && _propellerContainerRigidBody != null)
					{
						DetachPropeller(_propellerContainerRigidBody, propeller.Root.transform);
					}
				}, UnityEngine.Random.Range(0, 2));
			}
			Rigidbody connectedBody = motorHubJoint.connectedBody;
			ExplosionScript.CreateExplosion(base.PartScript.Aircraft, connectedBody.transform.position, connectedBody.linearVelocity, 10f, 10);
			UnityEngine.Object.Destroy(motorHubJoint);
			_engineAudioSource.Stop();
			AudioManager.PlaySound(AudioStore.PartBreakOffAudio, base.transform.position);
		}

		public virtual void Initialize(bool remoteCraft)
		{
			base.PartScript.Aircraft.VelocitySet += OnVelocitySet;
			_bladedEngine.ChordScaleChanged += OnDataChordScaleChanged;
			_bladedEngine.DiameterChanged += OnDataDiameterScaleChanged;
			_bladedEngine.BladeCountChanged += OnDataBladeCountChanged;
			_bladedEngine.BladeStyleChanged += OnDataBladeStyleChanged;
			_bladedEngine.ReverseRotationChanged += OnDataReverseRotationChanged;
			_bladedEngine.BladePitchChanged += OnDataBladePitchChanged;
			_bladedEngine.BladePitchScaleChanged += OnDataBladePitchScaleChanged;
			base.EngineDestroyed = false;
			GovernedRpm = MaxRpm * 0.9f;
			base.CenterOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", base.PartScript.gameObject).transform;
			_applyEngineTorque = true;
			_startingPitch = PropellerPitch;
			_partScale = Vector3.one;
			if (base.PartScript.Part.PartScale.HasValue)
			{
				_partScale = base.PartScript.Part.PartScale.Value;
			}
			_independentRotorFrequencyAdjustment = UnityEngine.Random.Range(0.9f, 1.1f) * 10f;
			_independentRotorAmplitudeAdjustment = UnityEngine.Random.Range(0.9f, 1.1f) * 0.5f;
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				GameState.Instance.PauseChanged += OnPausedStateChanged;
				GameState.Instance.MapLocationChanged += OnMapLocationChanged;
			}
			List<InputControllerScript> modifiers = base.PartScript.GetModifiers<InputControllerScript>();
			SetupInputs(modifiers);
			InitializePropellers(remoteCraft);
		}

		public override void InitializePartSyncData(PartSyncData syncData)
		{
			base.InitializePartSyncData(syncData);
			syncData.RegisterValue(new SyncFloat
			{
				Value = () => Rpm,
				ValueRead = delegate(float x)
				{
					Rpm = x;
				}
			});
		}

		public override void OnModifierInitialized()
		{
			base.OnModifierInitialized();
			_bladedEngine = (BladedEngineData)base.Engine;
			base.PartScript.transform.Find("Root").localScale = _bladedEngine.HubHeadScale;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.transform.Find("AttachPoints").localScale = _bladedEngine.HubHeadScale;
			}
			UpdateCenterOfMassForPart();
		}

		public void RegisterDragFromProp(Vector3 dragForce)
		{
			_dragTorque = CalculateMotorDragTorqueFromBladeDragForce(dragForce);
			_dragForcePrimary = dragForce;
		}

		public void RegisterLiftFromProp(Vector3 liftForce)
		{
			_liftForcePrimary = liftForce;
		}

		public void SetMaxSlip(float maxSlip)
		{
			_masterPropPhysicsScript.SetMaxSlip(maxSlip);
		}

		protected static float GetBladePitchWithLag(float desiredPitch, float currentPitch, float speed)
		{
			float result = currentPitch;
			float num = desiredPitch - currentPitch;
			if (num != 0f)
			{
				result = (Utilities.CompareFloats(num, 0f, 0.001f) ? desiredPitch : Mathf.Lerp(currentPitch, desiredPitch, speed * Time.deltaTime));
			}
			return result;
		}

		protected override void Awake()
		{
			base.Awake();
			BladeMotion = BladeMotionType.PropBlur;
		}

		protected virtual float CalculateMotorDragTorqueFromBladeDragForce(Vector3 bladeDragForce)
		{
			return bladeDragForce.magnitude;
		}

		protected virtual void FlightFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (!base.EngineDestroyed)
			{
				PropellerPhysicsEnabled = true;
				AircraftScript aircraft = _part.Aircraft;
				float z = _propellerContainerRigidBody.transform.InverseTransformDirection(_propellerContainerRigidBody.angularVelocity).z;
				Rpm = (0f - z) * (30f / MathF.PI) / RpmReductionPercent;
				if (_part.EstimateOfUnderwaterPercent < 0.8f)
				{
					if (base.Body != null && _motorHubJoint != null)
					{
						bool flag = base.EngineThrottle > 0f || SimulatePropellersAtZeroThrottle || ThrottleControlType == BladedEngineData.ControlTypes.Auto;
						SetWindmillEnabled(!flag);
						if (flag)
						{
							SimulateEngine(aircraft, z);
						}
						else
						{
							WindmillPropeller();
						}
					}
					UpdateBladePitch();
				}
				else
				{
					SetWindmillEnabled(enabled: true);
					WindmillPropeller();
				}
			}
			else
			{
				Rpm = 0f;
				_liftForcePrimary = Vector3.zero;
				_dragForcePrimary = Vector3.zero;
				_dragTorque = 0f;
			}
			if (_independentRotorUpdateActive)
			{
				UpdateIndependentRotorUpdateState();
			}
		}

		protected virtual void FlightUpdate(bool remoteCraft)
		{
			BladePitchInputValue = ((_bladePitchInput != null) ? _bladePitchInput.Value : 0f) + ((_bladePitchInputAlt != null) ? _bladePitchInputAlt.Value : 0f);
			if (UpdatePitchContinuously)
			{
				UpdatePitchRepresentation();
			}
			if (remoteCraft)
			{
				float num = Rpm * 6f;
				_propellerContainer.transform.Rotate(new Vector3(0f, 0f, (0f - num) * Time.deltaTime), Space.Self);
				return;
			}
			if (_part.Aircraft.Fuel <= 0f || _part.EstimateOfUnderwaterPercent > 0.8f || base.EngineDestroyed)
			{
				base.EngineThrottle = 0f;
				_engineAudioSource.volume = 0f;
			}
			else
			{
				UpdateThrottle();
			}
			_engineAudioSource.pitch = Mathf.Lerp(_engineAudioSource.pitch, GetEngineAudioPitch(), EngineAudioPitchLerpSpeed * Time.deltaTime);
			_engineAudioSource.volume = Mathf.Lerp(_engineAudioSource.volume, GetEngineAudioVolume(), EngineAudioPitchLerpSpeed * Time.deltaTime);
			if (_showDebugInfo)
			{
				PrintDebugInfo();
			}
			if (base.PartScript.EstimateOfUnderwaterPercent > 0f)
			{
				float num2 = Mathf.Clamp(base.PartScript.EstimateOfUnderwaterPercent, 0f, 1f);
				_masterPropPhysicsScript.FluidDensityRatio = _part.Aircraft.AtmosphereSample.AirDensityRatio + 10f * num2;
			}
			else
			{
				_masterPropPhysicsScript.FluidDensityRatio = _part.Aircraft.AtmosphereSample.AirDensityRatio;
			}
			if (OverspeedingEnabled)
			{
				MonitorForOverspeeding();
			}
			else
			{
				_engineOverSpeedStartTime = float.MaxValue;
			}
		}

		protected virtual Rigidbody GetBodyToAddForceTo()
		{
			return _motorRigidBody;
		}

		protected virtual float GetDirectControlPitchValue()
		{
			return 0f;
		}

		protected virtual float GetEngineAudioPitch()
		{
			float num;
			if (base.EngineThrottle > 0f)
			{
				num = 1.25f + RpmAbs / MaxRpm + 1f;
				if (_masterPropPhysicsScript.Slip < float.PositiveInfinity)
				{
					num -= _masterPropPhysicsScript.Slip;
				}
			}
			else
			{
				num = 0.75f;
			}
			return num;
		}

		protected virtual float GetEngineAudioVolume()
		{
			float b = _engineAudioVolume * base.EngineThrottle * 2f;
			return Mathf.Max(0.1f, b);
		}

		protected virtual void OnBladesInitialized()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				ReparentUtil[] componentsInChildren = _part.gameObject.GetComponentsInChildren<ReparentUtil>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].Reparent();
				}
			}
		}

		protected virtual void OnDestroy()
		{
			GameState.Instance.PauseChanged -= OnPausedStateChanged;
			GameState.Instance.MapLocationChanged -= OnMapLocationChanged;
			if (_bladedEngine != null)
			{
				_bladedEngine.ChordScaleChanged -= OnDataChordScaleChanged;
				_bladedEngine.DiameterChanged -= OnDataDiameterScaleChanged;
				_bladedEngine.BladeCountChanged -= OnDataBladeCountChanged;
				_bladedEngine.BladeStyleChanged -= OnDataBladeStyleChanged;
				_bladedEngine.ReverseRotationChanged -= OnDataReverseRotationChanged;
				_bladedEngine.BladePitchChanged -= OnDataBladePitchChanged;
				_bladedEngine.BladePitchScaleChanged -= OnDataBladePitchScaleChanged;
			}
			if (_bladeMeshCombined != null)
			{
				UnityEngine.Object.Destroy(_bladeMeshCombined);
			}
			ThemeScript theme = base.PartScript?.Aircraft?.Theme;
			ReleaseMaterial(theme, transparent: true, ref _propBlurMaterial);
			ReleaseMaterial(theme, transparent: false, ref _propDefaultMaterial);
			static void ReleaseMaterial(ThemeScript themeScript, bool transparent, ref Material mat)
			{
				if (mat != null)
				{
					if (themeScript != null)
					{
						if (transparent)
						{
							themeScript.ReleaseTransparentPartMaterialInstance(mat);
						}
						else
						{
							themeScript.ReleaseDefaultPartMaterialInstance(mat);
						}
					}
					else
					{
						UnityEngine.Object.Destroy(mat);
					}
				}
				mat = null;
			}
		}

		protected override void OnEngineDamaged()
		{
			base.OnEngineDamaged();
			Power *= 0.25f;
		}

		protected override void OnEngineDestroyed()
		{
			DestroyEngine(null);
		}

		protected virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (!base.PartModifier.UsedInPropMode)
			{
				FlightFixedUpdate(in frame);
			}
		}

		protected virtual void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (!frame.Paused)
			{
				FlightUpdate(frame.IsRemoteCraft);
			}
			else
			{
				SetIndependentUpdateEnabled(enabled: false);
				_timePaused += frame.DeltaTime;
			}
			bool blur = !base.EngineDestroyed && (_bladeMotion == BladeMotionType.PropBlur || _bladeMotion == BladeMotionType.Both) && RpmAbs > 50f;
			DrawPropsInFlightScene(blur);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		protected virtual void RotateBlade(BladeAssembly blade, float neutralRotation, float pitchDegrees)
		{
			blade.Root.Rotate(new Vector3(0f, neutralRotation + pitchDegrees, 0f), Space.Self);
		}

		protected void SetOverspeedingEnabled(bool enabled)
		{
			OverspeedingEnabled = enabled;
			float num = (enabled ? 10000f : (GovernedRpm * 1.1f));
			float maxAngularVelocity = num * RpmReductionPercent * (MathF.PI / 30f);
			_propellerContainerRigidBody.maxAngularVelocity = maxAngularVelocity;
		}

		protected virtual void SetupInput(InputControllerScript inputController)
		{
			if (inputController.InputController.Name == "throttle")
			{
				base.ThrottleInput = inputController;
			}
			else if (inputController.InputController.Name == "propPitch")
			{
				_bladePitchInput = inputController;
				if (_bladedEngine.PitchControlType != BladedEngineData.ControlTypes.Manual)
				{
					_bladePitchInput.Disabled = true;
				}
			}
			else if (inputController.InputController.Name == "propPitchAlt")
			{
				_bladePitchInputAlt = inputController;
				if (_bladedEngine.PitchControlType != BladedEngineData.ControlTypes.Manual)
				{
					_bladePitchInputAlt.Disabled = true;
				}
			}
		}

		protected void UpdateCenterOfMassForPart()
		{
			Vector3 vector = new Vector3(CenterOfMassOffset.x, 0f - CenterOfMassOffset.z, CenterOfMassOffset.y);
			_part.Part.CenterOfMass = CenterOfMassBase + vector;
		}

		private static Vector3 CalculateBaselineCenterOfMass(PartScript partScript, Rigidbody motorBody, Rigidbody propellerContainerBody)
		{
			Vector3 position = partScript.transform.position * partScript.Part.EmptyMass + motorBody.transform.position * motorBody.mass + propellerContainerBody.transform.position * propellerContainerBody.mass;
			float num = partScript.Part.EmptyMass + motorBody.mass + propellerContainerBody.mass;
			position /= num;
			return partScript.transform.InverseTransformPoint(position);
		}

		private static float CalculatePerBladeAlpha(float numBlades, float desiredCombinedTransparency)
		{
			return 1f - Mathf.Pow(desiredCombinedTransparency, 1f / numBlades);
		}

		private static void CreateJointFromMotorToPart(Rigidbody motorBody, Rigidbody partBody)
		{
			FixedJoint fixedJoint = motorBody.gameObject.AddComponent<FixedJoint>();
			fixedJoint.connectedBody = partBody;
			fixedJoint.autoConfigureConnectedAnchor = true;
		}

		private static ConfigurableJoint CreateJointFromMotorToPropellers(Rigidbody motorBody, Rigidbody propellerContainerBody)
		{
			ConfigurableJoint configurableJoint = motorBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = propellerContainerBody;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.axis = new Vector3(0f, 0f, 1f);
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			configurableJoint.rotationDriveMode = RotationDriveMode.XYAndZ;
			JointDrive jointDrive = new JointDrive
			{
				maximumForce = float.MaxValue,
				positionSpring = float.MaxValue,
				positionDamper = float.MaxValue
			};
			configurableJoint.xDrive = jointDrive;
			configurableJoint.yDrive = jointDrive;
			configurableJoint.zDrive = jointDrive;
			configurableJoint.angularYZDrive = jointDrive;
			configurableJoint.autoConfigureConnectedAnchor = true;
			return configurableJoint;
		}

		private static void CreateRigidBodies(GameObject propellerContainer, GameObject motorContainer, bool inPlaneDesigner, out Rigidbody motorBody, out Rigidbody propellerContainerBody)
		{
			propellerContainerBody = propellerContainer.AddComponent<Rigidbody>();
			propellerContainerBody.mass = 0.099999994f;
			propellerContainerBody.isKinematic = inPlaneDesigner;
			propellerContainerBody.linearDamping = 0f;
			propellerContainerBody.angularDamping = 0.1f;
			motorBody = motorContainer.AddComponent<Rigidbody>();
			motorBody.mass = 0.099999994f;
			motorBody.isKinematic = inPlaneDesigner;
			motorBody.angularDamping = 0f;
			motorBody.linearDamping = 0f;
			motorBody.maxAngularVelocity = 10f;
		}

		private static void RemoveHubHeadScale(BladedEngineData bladedEngine, Transform transform)
		{
			Vector3 hubHeadScale = bladedEngine.HubHeadScale;
			Vector3 b = new Vector3(1f / hubHeadScale.x, 1f / hubHeadScale.y, 1f / hubHeadScale.z);
			transform.localScale = Vector3.Scale(transform.localScale, b);
			transform.localPosition = Vector3.Scale(transform.localPosition, b);
		}

		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		[MonoPInvokeCallback(typeof(Assets_002EScripts_002ECraft_002EParts_002EModifiers_002EUpdatePropBlurMatrices_000060AD_0024PostfixBurstDelegate))]
		private unsafe static void UpdatePropBlurMatrices([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
		{
			UpdatePropBlurMatrices_000060AD_0024BurstDirectCall.Invoke(matrices, count, positionPtr, scalePtr, baseRotationPtr, localRotationPtr, stepRotationDegrees);
		}

		private void AddWingScriptToMasterProp()
		{
			GameObject gameObject = new GameObject("PropPhysics");
			gameObject.transform.parent = _masterPropeller.Blade;
			gameObject.transform.localPosition = new Vector3(0f, -1f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 270f, 270f);
			gameObject.transform.localScale = new Vector3(1.32f, 3f, 0.375f);
			RemoveHubHeadScale(_bladedEngine, gameObject.transform);
			_masterPropPhysicsScript = gameObject.AddComponent<PropellerScript>();
			_masterPropPhysicsScript.SimulateRealtime = true;
			_masterPropPhysicsScript.RigidBodyToAddForceTo = GetBodyToAddForceTo();
			_masterPropPhysicsScript.RigidBodyToAddDragTo = _propellerContainerRigidBody;
			_masterPropPhysicsScript.PropEngine = this;
			_masterPropPhysicsScript.Container = _rotatingHeadAssembly.gameObject;
			_masterPropPhysicsScript.Initialize();
		}

		private void AdvanceThrottleWithThrottleResponse()
		{
			float num = base.ThrottleInput.Value * base.EngineThrottleFunctionalHealth;
			if (base.EngineThrottle < num)
			{
				base.EngineThrottle += Time.deltaTime * base.Engine.ThrottleResponse * base.EngineThrottleFunctionalHealth;
				if (base.EngineThrottle > num)
				{
					base.EngineThrottle = num;
				}
			}
			else if (base.EngineThrottle > num)
			{
				base.EngineThrottle -= Time.deltaTime * base.Engine.ThrottleResponse;
				if (base.EngineThrottle < num)
				{
					base.EngineThrottle = num;
				}
			}
		}

		private void BuildCombinedBladeMesh()
		{
			MeshRenderer componentInChildren = _masterPropeller.Blade.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			Mesh sharedMesh = componentInChildren.GetComponent<MeshFilter>().sharedMesh;
			_bladeMeshCombined = MeshUtility.CombineSubmeshes(sharedMesh);
			_bladeMeshCombined.name = sharedMesh.name + "_Combined";
			List<Vector3> value;
			using (ListPool<Vector3>.Get(out value))
			{
				List<Vector3> value2;
				using (ListPool<Vector3>.Get(out value2))
				{
					List<Vector4> value3;
					using (ListPool<Vector4>.Get(out value3))
					{
						_bladeMeshCombined.GetVertices(value);
						_bladeMeshCombined.GetNormals(value2);
						_bladeMeshCombined.GetTangents(value3);
						bool flag = value3.Count == value.Count;
						Transform transform = componentInChildren.transform;
						Matrix4x4 matrix4x = _masterPropeller.Blade.transform.worldToLocalMatrix * transform.localToWorldMatrix;
						Matrix4x4 transpose = matrix4x.inverse.transpose;
						float num = Mathf.Sign(matrix4x.determinant);
						for (int i = 0; i < value.Count; i++)
						{
							value[i] = matrix4x.MultiplyPoint3x4(value[i]);
							value2[i] = transpose.MultiplyVector(value2[i]).normalized;
							if (flag)
							{
								Vector4 vector = value3[i];
								Vector3 normalized = transpose.MultiplyVector(vector).normalized;
								value3[i] = new Vector4(normalized.x, normalized.y, normalized.z, vector.w * num);
							}
						}
						_bladeMeshCombined.SetVertices(value);
						_bladeMeshCombined.SetNormals(value2);
						if (flag)
						{
							_bladeMeshCombined.SetTangents(value3);
						}
						if (num < 0f)
						{
							List<int> value4;
							using (ListPool<int>.Get(out value4))
							{
								_bladeMeshCombined.GetTriangles(value4, 0);
								for (int j = 0; j < value4.Count; j += 3)
								{
									int value5 = value4[j + 1];
									value4[j + 1] = value4[j + 2];
									value4[j + 2] = value5;
								}
								_bladeMeshCombined.SetTriangles(value4, 0);
							}
						}
						_bladeMeshCombined.RecalculateBounds();
					}
				}
			}
		}

		private float CalculateDesiredCombinedBladeTransparency()
		{
			float num = ((RpmAbs < 50f) ? 0f : RpmAbs);
			return 1f - Mathf.Lerp(1f, 0.6f, Mathf.Clamp01(num / 1000f));
		}

		private AudioSource CreateEngineAudioSource()
		{
			if (!_part.TryGetComponent<AudioSource>(out var component))
			{
				Debug.LogWarning("BladedEngineScript does not have an audio source, using default");
				component = _part.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(component, AudioStore.BladeEngineAudio, AudioStore.BladeEngineAudio.Resource);
				_part.gameObject.AddComponent<LPFbyDistance>().Filter = _part.gameObject.AddComponent<AudioLowPassFilter>();
			}
			_engineAudioVolume = component.volume * (0.5f + 0.5f * (Power - MinPower) / (MaxPower - MinPower));
			component.minDistance *= _engineAudioVolume;
			component.maxDistance *= _engineAudioVolume;
			component.volume = 0f;
			component.Play();
			component.timeSamples = (int)(UnityEngine.Random.value * (float)component.clip.samples);
			return component;
		}

		private void DetachPropeller(Rigidbody container, Transform propeller)
		{
			propeller.transform.SetParent(base.PartScript.Aircraft.WorldRigidBodies);
			Collider collider = _propellerColliderMap[propeller.transform];
			collider.transform.parent = propeller.transform;
			float num = UnityEngine.Random.Range(0.5f, 1f);
			Rigidbody rigidbody = propeller.gameObject.AddComponent<Rigidbody>();
			rigidbody.linearVelocity = container.linearVelocity + container.angularVelocity.magnitude * 4f * collider.transform.forward;
			rigidbody.angularVelocity = container.angularVelocity * num;
			rigidbody.linearDamping = 2f * num;
			rigidbody.angularDamping = UnityEngine.Random.Range(0f, 0.01f);
			UnityEngine.Object.Destroy(rigidbody.gameObject.GetComponentInChildren<ControlRodLinkScript>());
		}

		private unsafe void DrawPropsInFlightScene(bool blur)
		{
			using (Profile.DrawPropsInFlightScene.Auto())
			{
				if (BladeCount < 1)
				{
					return;
				}
				int bladeCount = BladeCount;
				int num = Mathf.Min(511, Data.BladeBlurCount);
				int num2 = 511 / num;
				int num3 = Mathf.CeilToInt((float)bladeCount / (float)num2);
				int num4 = num2 * num;
				if (_propBlurMatrices == null || _propBlurMatrices.Length < num4)
				{
					_propBlurMatrices = new Matrix4x4[num4];
				}
				if (!blur)
				{
					num = 1;
					num2 = bladeCount;
					num3 = 1;
					num4 = bladeCount;
				}
				else
				{
					UpdatePropellerTransparency();
				}
				RenderParams rparams = new RenderParams(blur ? _propBlurMaterial : _propDefaultMaterial);
				rparams.layer = 21;
				rparams.shadowCastingMode = ShadowCastingMode.On;
				rparams.receiveShadows = !blur;
				rparams.reflectionProbeUsage = ReflectionProbeUsage.BlendProbes;
				rparams.lightProbeUsage = LightProbeUsage.BlendProbes;
				ReflectionProbe reflectionProbe = ((_craftReflectionsSetting.Value == CraftQualitySettings.CraftReflectionsQuality.Realtime) ? _craftReflectionProbe : _globalReflectionProbe);
				Texture texture = reflectionProbe?.texture;
				if (texture != null)
				{
					_propMaterialPropertyBlock.SetTexture("unity_SpecCube0", texture);
					_propMaterialPropertyBlock.SetVector("unity_SpecCube0_HDR", reflectionProbe.textureHDRDecodeValues);
					rparams.matProps = _propMaterialPropertyBlock;
				}
				float stepRotationDegrees = Mathf.Lerp(0f, Data.BladeBlurSpread, Mathf.Clamp01(RpmAbs / 1000f)) / (float)num;
				int num5 = 0;
				for (int i = 0; i < num3; i++)
				{
					int num6 = math.min(bladeCount - num5, num2);
					int instanceCount = num6 * num;
					for (int j = 0; j < num6; j++)
					{
						BladeAssembly bladeAssembly = _allPropellers[num5];
						float3 float5 = bladeAssembly.Blade.position;
						float3 float6 = _masterPropeller.Blade.lossyScale;
						quaternion quaternion2 = bladeAssembly.Root.localRotation;
						quaternion quaternion3 = bladeAssembly.Root.parent.rotation;
						ulong gcHandle;
						Matrix4x4* ptr = (Matrix4x4*)UnsafeUtility.PinGCArrayAndGetDataAddress(_propBlurMatrices, out gcHandle);
						UpdatePropBlurMatrices(ptr + j * num, num, &float5, &float6, &quaternion3, &quaternion2, stepRotationDegrees);
						UnsafeUtility.ReleaseGCObject(gcHandle);
						num5++;
					}
					Graphics.RenderMeshInstanced(in rparams, _bladeMeshCombined, 0, _propBlurMatrices, instanceCount);
				}
			}
		}

		private float GetGovernorTargetPitch(float currentTarget)
		{
			float rpmAbs = RpmAbs;
			if (!Utilities.CompareFloats(rpmAbs, GovernedRpm, 1f) && base.EngineThrottle > 0f)
			{
				float num = 1f - rpmAbs / GovernedRpm;
				float num2 = Time.fixedDeltaTime * 0.5f;
				float num3 = Mathf.Clamp(num2 * num, 0f - num2, num2);
				float num4 = Mathf.Clamp(Mathf.Abs(_targetPitch) - num3, 4f / 75f, 1f);
				float num5 = ((!(_masterPropPhysicsScript.Slip < float.PositiveInfinity)) ? (4f / 75f) : _masterPropPhysicsScript.GetBladePitch(4f / 75f, _masterPropPhysicsScript.Slip));
				if (!(num4 > 1f) && num4 < num5)
				{
					num4 = num5;
					if (_showDebugInfo)
					{
						Debug.Log("Limiting governor target to prevent negative effective AoA");
					}
					_ = base.EngineThrottle;
					_ = 0.9f;
				}
				num4 = Mathf.Clamp(num4, 0f, 1f);
				if (_autoPitchControlReverse)
				{
					num4 = 0f - num4;
				}
				return num4;
			}
			return currentTarget;
		}

		private float GetLocalRotation()
		{
			return _propellerContainerRigidBody.transform.localRotation.eulerAngles.z;
		}

		private float GetThrottleGovernorTargetThrottle()
		{
			float rpmAbs = RpmAbs;
			if (!Utilities.CompareFloats(rpmAbs, GovernedRpm, 1f))
			{
				float num = 1f - rpmAbs / GovernedRpm;
				float num2 = Time.fixedDeltaTime * 1f;
				float num3 = Mathf.Clamp(num2 * num, 0f - num2, num2);
				return Mathf.Clamp(base.EngineThrottle + num3, 0.01f, 1f);
			}
			return base.EngineThrottle;
		}

		private void InitializeFlightScenePropRendering()
		{
			if (base.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			BuildCombinedBladeMesh();
			ThemeScript theme = base.PartScript.Aircraft.Theme;
			_propDefaultMaterial = theme.RequestDefaultPartMaterialInstance();
			_propDefaultMaterial.enableInstancing = true;
			_propBlurMaterial = theme.RequestTransparentPartMaterialInstance(zwrite: false, preserveSpecular: false);
			_propBlurMaterial.enableInstancing = true;
			_propMaterialPropertyBlock = new MaterialPropertyBlock();
			_craftReflectionProbe = base.PartScript.Aircraft.ReflectionProbe;
			_globalReflectionProbe = UnityEngine.Object.FindAnyObjectByType<GlobalReflectionProbeScript>().ReflectionProbe;
			_craftReflectionsSetting = Game.Instance.Settings.Quality.Craft.Reflections;
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Blade.GetComponentInChildren<MeshRenderer>(includeInactive: true).enabled = false;
			}
		}

		private void InitializePropellers(bool remoteCraft)
		{
			Airfoil = AircraftScript.GetAirfoil("NACAPROP");
			_propellerAssembly = base.transform.parent.Find("Root/Mesh/Blades");
			_motorGameObject = _propellerAssembly.Find("Motor").gameObject;
			_propellerContainer = _propellerAssembly.Find("Container").gameObject;
			_rotatingHeadAssembly = _propellerAssembly.Find("Container/RotatingAssembly");
			_masterPropeller = new BladeAssembly(_rotatingHeadAssembly.Find("BladeAssembly"));
			Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("Collider", _masterPropeller.Blade.gameObject).transform;
			RemoveHubHeadScale(_bladedEngine, transform);
			_allPropellers.Add(_masterPropeller);
			base.transform.position = _propellerContainer.transform.position;
			if (!remoteCraft)
			{
				CreateRigidBodies(_propellerContainer, _motorGameObject, base.LoadContext != CraftLoadContext.Flight || !base.PartScript.PhysicsEnabled, out _motorRigidBody, out _propellerContainerRigidBody);
				_motorHubJoint = CreateJointFromMotorToPropellers(_motorRigidBody, _propellerContainerRigidBody);
				CenterOfMassBase = CalculateBaselineCenterOfMass(_part, _motorRigidBody, _propellerContainerRigidBody);
			}
			_engineAudioSource = CreateEngineAudioSource();
			UpdatePitchRepresentation();
			if (base.LoadContext == CraftLoadContext.Flight && !remoteCraft)
			{
				AddWingScriptToMasterProp();
			}
			if (!remoteCraft)
			{
				SetOverspeedingEnabled(OverspeedingEnabledDefault);
			}
		}

		private void MonitorForOverspeeding()
		{
			float num = Time.time - _engineOverSpeedStartTime;
			if (!base.EngineDestroyed)
			{
				if (RpmAbs > MaxRpm)
				{
					if (num < 0f)
					{
						_engineOverSpeedStartTime = Time.time;
					}
					if (Utilities.CompareFloats(num, 1f, 0.1f) && base.PartScript.Aircraft.IsPrimaryLocalPlayer)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage($"Caution: {FriendlyName} overspeeding ({(int)Mathf.Abs(Rpm)}rpm)", 10f);
						_overspeeding = true;
						_timePaused = 0f;
					}
				}
				else
				{
					if (_engineOverSpeedStartTime < float.MaxValue && _overspeeding && base.PartScript.Aircraft.IsPrimaryLocalPlayer)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage($"{FriendlyName} returned to safe RPM ({(int)MaxRpm}rpm)");
					}
					_overspeeding = false;
					_engineOverSpeedStartTime = float.MaxValue;
				}
			}
			if (!base.EngineDestroyed && num - _timePaused > 10f)
			{
				string message = null;
				if (base.PartScript.Aircraft.IsPrimaryLocalPlayer)
				{
					message = "Engine destroyed from overspeed";
				}
				DestroyEngine(message);
			}
		}

		private void OnDataBladeCountChanged(BladedEngineData source)
		{
			UpdatePropellers();
		}

		private void OnDataBladePitchChanged(BladedEngineData source)
		{
			UpdatePitchRepresentation();
		}

		private void OnDataBladePitchScaleChanged(BladedEngineData source)
		{
			UpdatePitchRepresentation();
		}

		private void OnDataBladeStyleChanged(BladedEngineData source)
		{
			UpdatePropellerMeshes();
		}

		private void OnDataChordScaleChanged(BladedEngineData source)
		{
			UpdateScale();
		}

		private void OnDataDiameterScaleChanged(BladedEngineData source)
		{
			UpdateScale();
		}

		private void OnDataReverseRotationChanged(BladedEngineData source)
		{
			UpdatePitchRepresentation();
		}

		private void OnMapLocationChanged(object sender, MapLocationChangedEventArgs e)
		{
			_mapLocationChanged = true;
		}

		private void OnPausedStateChanged(object sender, PauseChangedEventArgs e)
		{
			if (!e.IsPaused && _mapLocationChanged)
			{
				_mapLocationChanged = false;
				if (_motorRigidBody != null)
				{
					_motorRigidBody.angularVelocity = Vector3.zero;
					_motorRigidBody.linearVelocity = Vector3.zero;
				}
				if (_propellerContainerRigidBody != null)
				{
					_propellerContainerRigidBody.angularVelocity = Vector3.zero;
					_propellerContainerRigidBody.linearVelocity = Vector3.zero;
				}
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_irSignaturePower = Power;
			Initialize(frame.IsRemoteCraft);
			if (Utilities.CompareFloats(Vector3.Dot(base.transform.forward, _part.Aircraft.OrientedCenterOfMassRigidBodies.forward), -1f))
			{
				_autoPitchControlReverse = true;
			}
			else
			{
				_autoPitchControlReverse = false;
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				if (!frame.IsRemoteCraft)
				{
					CreateJointFromMotorToPart(_motorRigidBody, base.Body);
				}
				SetFlightScenePrimaryPartCollider();
			}
			UpdateScale();
			UpdatePropellerMeshes();
			InitializeFlightScenePropRendering();
			OnBladesInitialized();
			_defaultHeadParent = RotatingHeadAssembly.parent;
		}

		private void OnVelocitySet(Vector3 velocity)
		{
			_motorRigidBody.linearVelocity = velocity;
			_propellerContainerRigidBody.linearVelocity = velocity;
		}

		private void PrintDebugInfo()
		{
			Debug.LogFormat("{0}: Rpm: {1}, GovernedTarget: {2}, Driven motor torque: {3}Net Motor Torque: {4}, Total Lift: {5}, Motor blade drag torque: {6}, eff AoA: {7},  Pitch: {8}deg, MaxTopSpeed: {9}, Slip: {10}, cL: {11}, cD: {12}, geo pitch: {13}m", GetInstanceID(), Rpm, GovernedRpm, EngineTorque, _netEngineTorqueMag, _liftForcePrimary.magnitude, _dragTorque, _masterPropPhysicsScript.AngleOfAttack, PropellerPitch * 75f, _masterPropPhysicsScript.TheoreticalMaxSpeed * 2.23694f, _masterPropPhysicsScript.Slip, _masterPropPhysicsScript.CoeffecientOfLift, _masterPropPhysicsScript.CoeffecientOfDrag, _masterPropPhysicsScript.GeometricPitch);
		}

		private void ReinitializePartMaterialScript()
		{
			_part.PartMaterialScript.UpdateRenderers();
			_part.PartMaterialScript.InitializeMaterial();
			_part.PartMaterialScript.BakeMeshData();
		}

		private void SetFlightScenePrimaryPartCollider()
		{
			_propTriggerColliderForWater = base.gameObject.AddComponent<BoxCollider>();
			_propTriggerColliderForWater.isTrigger = true;
			_part.PrimaryPartCollider = _propTriggerColliderForWater;
		}

		private void SetIndependentUpdateEnabled(bool enabled)
		{
			if (enabled)
			{
				if (!_independentRotorUpdateEnabled)
				{
					_independentRotorUpdateEnabled = true;
					RotatingHeadAssembly.parent = base.transform;
				}
			}
			else if (_independentRotorUpdateEnabled)
			{
				_independentRotorUpdateEnabled = false;
				RotatingHeadAssembly.parent = _defaultHeadParent;
				ColliderContainer.localEulerAngles = RotatingHeadAssembly.localEulerAngles;
			}
		}

		private void SetupInputs(List<InputControllerScript> inputControllers)
		{
			foreach (InputControllerScript inputController in inputControllers)
			{
				SetupInput(inputController);
			}
		}

		private void SetWindmillEnabled(bool enabled)
		{
			if (_windmillingPropeller != enabled)
			{
				Rigidbody propellerContainerRigidBody = _propellerContainerRigidBody;
				if (enabled)
				{
					_propellerContainerRigidBodyAngularDragBackup = propellerContainerRigidBody.angularDamping;
					_propellerContainerRigidBodyMaxAngularVelocityBackup = propellerContainerRigidBody.maxAngularVelocity;
					PropellerPhysicsEnabled = false;
					propellerContainerRigidBody.angularDamping = 1f;
					propellerContainerRigidBody.maxAngularVelocity = float.MaxValue;
				}
				else
				{
					PropellerPhysicsEnabled = true;
					propellerContainerRigidBody.angularDamping = _propellerContainerRigidBodyAngularDragBackup;
					propellerContainerRigidBody.maxAngularVelocity = _propellerContainerRigidBodyMaxAngularVelocityBackup;
				}
				_windmillingPropeller = enabled;
			}
		}

		private void SimulateEngine(AircraftScript aircraft, float localAngularVelocity)
		{
			if (ThrottleGovernorEnabled)
			{
				if (ThrottleGovernorActive)
				{
					base.EngineThrottle = GetThrottleGovernorTargetThrottle() * base.EngineThrottleFunctionalHealth;
				}
				else
				{
					base.EngineThrottle = 0f;
				}
			}
			float num = (ReverseRotation ? 1f : (-1f));
			float num2 = 0.01f * num * RpmReductionPercent;
			EngineTorque = 0f;
			if (_part.Aircraft.Fuel > 0f)
			{
				float amount = base.EngineThrottle * base.Engine.FuelConsumptionRate * Time.fixedDeltaTime;
				aircraft.UseFuel(amount);
				EngineTorque = base.EngineThrottle * Power * num2;
			}
			float num3 = EngineTorque + SecondaryMotorTorques * num2;
			num3 *= _engineTorqueScale;
			float dragTorque = _dragTorque;
			dragTorque *= 0f - Mathf.Sign(localAngularVelocity);
			_netEngineTorqueMag = num3 + dragTorque;
			if (float.IsFinite(_netEngineTorqueMag))
			{
				_propellerContainerRigidBody.AddTorque(base.transform.forward * _netEngineTorqueMag);
			}
		}

		private void UpdateBladePitch()
		{
			if (DirectPitchControl)
			{
				PropellerPitch = GetDirectControlPitchValue();
			}
			else if (PitchControlType != BladedEngineData.ControlTypes.Fixed)
			{
				if (PitchControlType == BladedEngineData.ControlTypes.Manual)
				{
					_targetPitch = BladePitchInputValue;
				}
				else if (PitchControlType == BladedEngineData.ControlTypes.Auto)
				{
					_targetPitch = GetGovernorTargetPitch(_targetPitch);
				}
				float desiredPitch = ((PitchControlType != BladedEngineData.ControlTypes.Auto) ? (_targetPitch * _bladedEngine.PropellerPitchScale + _startingPitch) : _targetPitch);
				PropellerPitch = GetBladePitchWithLag(desiredPitch, PropellerPitch, 2f);
			}
		}

		private void UpdateIndependentRotorUpdateState()
		{
			float smoothDeltaTime = Time.smoothDeltaTime;
			float num = RpmAbs / 60f * smoothDeltaTime * 360f;
			float num2 = 360f / (float)PropellerCount;
			float num3 = num2 * 0.5f;
			float num4 = num2 / 10f;
			if (num > num4)
			{
				SetIndependentUpdateEnabled(enabled: true);
				float num7;
				if (num > num3)
				{
					float num5 = (float)(int)(num / num2) * num2;
					float num6 = num3;
					num6 *= 1f + _independentRotorAmplitudeAdjustment * Mathf.Sin(Time.time / _independentRotorFrequencyAdjustment);
					num7 = num5 - num6;
				}
				else
				{
					num7 = num;
				}
				float num8 = 0f - Mathf.Sign(Rpm);
				float num9 = num7 * num8;
				RotatingHeadAssembly.transform.localEulerAngles = new Vector3(0f, 0f, RotatingHeadAssembly.transform.localEulerAngles.z + num9);
			}
			else
			{
				SetIndependentUpdateEnabled(enabled: false);
			}
		}

		private void UpdatePitchRepresentation()
		{
			if (base.EngineDestroyed)
			{
				return;
			}
			float num = _bladedEngine.PropellerPitch * 75f;
			if (_bladedEngine.ReverseRotation)
			{
				num *= -1f;
			}
			num *= _bladedEngine.PropellerPitchScale;
			int num2 = (ReverseRotation ? 180 : 0);
			float num3 = 360f / (float)_bladedEngine.BladeCount;
			float num4 = 0f;
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Root.localEulerAngles = new Vector3(0f, 0f, num4);
				RotateBlade(allPropeller, num2, num);
				num4 += num3;
			}
		}

		private void UpdatePropellerMeshes()
		{
			Transform transform = _masterPropeller.Blade.Find("Mesh");
			while (transform.childCount != 0)
			{
				GameObject gameObject = transform.GetChild(0).gameObject;
				MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					_part.PartMaterialScript.RemoveRenderer(renderer, destroy: true);
				}
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			Vector3 localScale = _masterPropeller.Blade.localScale;
			_masterPropeller.Blade.localScale = Vector3.one;
			string text = PropellerType + "Prefab";
			GameObject gameObject2 = Resources.Load<GameObject>("Craft/Parts/Propellers/" + text);
			if (gameObject2 != null)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2);
				gameObject3.transform.parent = transform;
				gameObject3.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				gameObject3.transform.localPosition = Vector3.zero;
				gameObject3.transform.localScale = gameObject3.transform.localScale;
				_masterPropeller.Blade.localScale = localScale;
				transform.localScale = _partScale;
				UpdatePropellers();
				_propellerMeshRenderers = new List<MeshRenderer>(_masterPropeller.Root.GetComponentsInChildren<MeshRenderer>(includeInactive: true));
				for (int j = 0; j < _additionalPropellers.Count; j++)
				{
					_propellerMeshRenderers.AddRange(_additionalPropellers[j].Root.GetComponentsInChildren<MeshRenderer>(includeInactive: true));
				}
			}
			else
			{
				Debug.LogError("Couldn't load propeller: " + text);
			}
		}

		private void UpdatePropellers()
		{
			foreach (BladeAssembly additionalPropeller in _additionalPropellers)
			{
				GameObject gameObject = additionalPropeller.Root.gameObject;
				MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					_part.PartMaterialScript.RemoveRenderer(renderer, destroy: true);
				}
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
			_additionalPropellers.Clear();
			float num = 360f / (float)_bladedEngine.BladeCount;
			float num2 = num;
			int num3 = 2;
			while (num3 <= _bladedEngine.BladeCount)
			{
				Transform transform = UnityEngine.Object.Instantiate(_masterPropeller.Root.gameObject).transform;
				Vector3 vector = new Vector3(0f, 0f, num2);
				transform.parent = _masterPropeller.Root.parent;
				transform.localPosition = Quaternion.Euler(vector) * _masterPropeller.Root.localPosition;
				transform.localEulerAngles = vector;
				transform.localScale = _masterPropeller.Root.localScale;
				PropellerScript componentInChildren = transform.GetComponentInChildren<PropellerScript>();
				if (componentInChildren != null)
				{
					UnityEngine.Object.Destroy(componentInChildren);
				}
				_additionalPropellers.Add(new BladeAssembly(transform));
				num3++;
				num2 += num;
			}
			_allPropellers.Clear();
			_allPropellers.Add(_masterPropeller);
			_allPropellers.AddRange(_additionalPropellers);
			UpdatePitchRepresentation();
			ReinitializePartMaterialScript();
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				ColliderContainer = new GameObject("Colliders").transform;
				ColliderContainer.parent = _propellerContainer.transform;
				ColliderContainer.localPosition = Vector3.zero;
				ColliderContainer.localEulerAngles = Vector3.zero;
				_propellerColliderMap = new Dictionary<Transform, Collider>();
				foreach (BladeAssembly allPropeller in _allPropellers)
				{
					Collider componentInChildren2 = allPropeller.Blade.GetComponentInChildren<Collider>();
					componentInChildren2.transform.parent = ColliderContainer;
					componentInChildren2.transform.localScale = new Vector3(componentInChildren2.transform.localScale.x, 1f, componentInChildren2.transform.localScale.z);
					_propellerColliderMap.Add(allPropeller.Root, componentInChildren2);
				}
				if (base.PartScript.PhysicsEnabled)
				{
					_propellerContainerRigidBody.gameObject.AddComponent<PropellerCollisionScript>();
				}
			}
			else if (base.LoadContext == CraftLoadContext.Designer)
			{
				Assembly.CreateEditorCollidersForPartScript(base.PartScript);
			}
		}

		private void UpdatePropellerTransparency()
		{
			float desiredCombinedTransparency = CalculateDesiredCombinedBladeTransparency();
			float value = (base.EngineDestroyed ? 1f : CalculatePerBladeAlpha(Data.BladeBlurCount, desiredCombinedTransparency));
			_propBlurMaterial.SetFloat("_Alpha", value);
		}

		private void UpdateScale()
		{
			float num = (_bladedEngine.Diameter - _masterPropeller.Blade.localPosition.magnitude * 2f) / 2.54f;
			Vector3 localScale = new Vector3(num * ChordScale, num, num);
			foreach (BladeAssembly allPropeller in _allPropellers)
			{
				allPropeller.Blade.localScale = localScale;
				WorldScaleStaysScript[] componentsInChildren = allPropeller.Blade.GetComponentsInChildren<WorldScaleStaysScript>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].ResetWorldScale();
				}
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_propTriggerColliderForWater.size = new Vector3(localScale.x, localScale.x, 0.1f);
			}
		}

		private void UpdateThrottle()
		{
			if (!ThrottleGovernorEnabled)
			{
				AdvanceThrottleWithThrottleResponse();
			}
		}

		private void WindmillPropeller()
		{
			if (!(_motorHubJoint == null))
			{
				float num = 0f - PropellerPitch;
				if (num == 0f)
				{
					num = -0.1f;
				}
				_propellerContainerRigidBody.AddTorque(base.transform.forward * (_propellerContainerRigidBody.transform.InverseTransformDirection(_propellerContainerRigidBody.linearVelocity - _part.Aircraft.WindVelocity).z * num * 0.01f * (ReverseRotation ? (-1f) : 1f)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(CompileSynchronously = true, DisableSafetyChecks = true)]
		internal unsafe static void UpdatePropBlurMatrices_0024BurstManaged([NoAlias][WriteOnly] Matrix4x4* matrices, int count, float3* positionPtr, float3* scalePtr, quaternion* baseRotationPtr, quaternion* localRotationPtr, float stepRotationDegrees)
		{
			float3 translation = *positionPtr;
			float3 scale = *scalePtr;
			quaternion b = *localRotationPtr;
			quaternion a = *baseRotationPtr;
			quaternion b2 = quaternion.RotateZ(math.radians(stepRotationDegrees));
			for (int i = 0; i < count; i++)
			{
				a = math.mul(a, b2);
				matrices[i] = float4x4.TRS(translation, math.mul(a, b), scale);
			}
		}
	}
}

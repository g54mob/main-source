using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(Rigidbody))]
	public class CarController : VehicleController
	{
		[Serializable]
		public class EngineConfig
		{
			[Header("Power")]
			public float MaxMotorTorque;

			public AnimationCurve MotorTorqueFromRpmCurve;

			public float MaxRPM;

			public float MinRPM;

			public float RPMEngineToRPMWheelsFast;

			public float RPMEngineToRPMWheelsSlow;

			public float SpeedLimit;

			[Header("Cut off")]
			public float CutOffRPM;

			public float TargetCutOffRPM;

			public float CutOffTime;

			[Header("Turbo")]
			public bool EnableTurbo;

			[ShowInInspectorIf("EnableTurbo")]
			public float TurboIncreaseSpeed;

			[ShowInInspectorIf("EnableTurbo")]
			public float TurboDecreaseSpeed;

			[ShowInInspectorIf("EnableTurbo")]
			public float TurboAdditionalTorque;

			[Header("Boost")]
			public bool EnableBoost;

			[ShowInInspectorIf("EnableBoost")]
			public float BoostAmount;

			[ShowInInspectorIf("EnableBoost")]
			public float BoostAdditionalPower;

			[Header("Back fire")]
			[Range(0f, 1f)]
			public float ProbabilityBackfire;

			[Header("Automatic change gear")]
			public float RPMToNextGear;

			public float RPMToPrevGearDiff;
		}

		[Serializable]
		public class SteerConfig
		{
			[Header("Steer settings")]
			public float MaxSteerAngle;

			public bool EnableSteerLimit;

			public AnimationCurve SteerLimitCurve;

			public AnimationCurve SteerChangeSpeedToVelocity;

			public AnimationCurve SteerChangeSpeedFromVelocity;

			[Header("Steer assistance")]
			public float MaxVelocityAngleForHelp;

			public float MinSpeedForHelp;

			[Space(10f)]
			[Range(0f, 1f)]
			public float HelpDriftIntensity;

			[Header("Angular help")]
			public AnimationCurve HandBrakeAngularHelpCurve;

			public AnimationCurve DriftResistanceCurve;

			public float MaxSpeedForMaxAngularHelp;

			public float DriftLimitAngle;

			[Header("Electronic assistants")]
			[Range(0f, 1f)]
			public float ABS;

			[Range(0f, 1f)]
			public float TCS;
		}

		[Serializable]
		public class GearboxConfig
		{
			public float ChangeUpGearTime;

			public float ChangeDownGearTime;

			[Header("Automatic gearbox")]
			public bool AutomaticGearBox;

			[Header("Ratio")]
			public float[] GearsRatio;

			public float MainRatio;

			public bool HasRGear;

			[ShowInInspectorIf("HasRGear")]
			public float ReversGearRatio;
		}

		[CompilerGenerated]
		private sealed class _003CDoStartEngine_003Ed__127 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarController _003C_003E4__this;

			private float _003Ctimer_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoStartEngine_003Ed__127(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CResetDelay_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CResetDelay_003Ed__50(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public bool IsVehicleActive;

		[Header("CarController")]
		public LayerMask TrailerConnectorMask;

		public Transform TrailerConnectorPosition;

		public float SteerWheelMaxAngle;

		public Transform SteerWheel;

		private float SteerWheelStartXAngle;

		private Rigidbody _Rb;

		private float m_DefaultDrag;

		private float m_DefaultAngularDrag;

		private VehicleOutControl m_VehicleOutControl;

		private GasConsumer m_GasConsumer;

		private NetworkVehicle m_NetworkVehicle;

		private bool isResetAvailable;

		public CameraController CameraController;

		public int CameraIndex;

		private bool hasGas;

		public bool StartEngineInAwake;

		public float StartEngineDellay;

		public EngineConfig Engine;

		private float MaxMotorTorque;

		private float CutOffTimer;

		private bool InCutOff;

		private Coroutine StartEngineCoroutine;

		public SteerConfig Steer;

		protected float PrevSteerAngle;

		protected float CurrentSteerAngle;

		protected float WheelMaxSteerAngle;

		protected Wheel[] SteeringWheels;

		public GearboxConfig Gearbox;

		private int _CurrentGear;

		private float ChangeGearTimer;

		private float[] AllGearsRatio;

		private Wheel[] DriveWheels;

		public bool CanConnectTrailer { get; private set; }

		public TrailerController ConnectedTrailer { get; private set; }

		public TrailerController NearestTrailer { get; private set; }

		public ICarControl CarControl { get; set; }

		public bool BlockControl { get; protected set; }

		public bool HasGas => false;

		public NetworkVehicle NetworkVehicle => null;

		public GasConsumer GasConsumer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float CurrentMotorTorque => 0f;

		public bool EngineIsOn { get; private set; }

		public float EngineRPM { get; private set; }

		public float TargetRPM { get; private set; }

		public float EngineLoad { get; private set; }

		public float MaxRPM => 0f;

		public float MinRPM => 0f;

		public float CurrentAcceleration { get; private set; }

		public float CurrentTurbo { get; private set; }

		public bool InHandBrake => false;

		public float CurrentBrake { get; private set; }

		public float BoostAmount { get; private set; }

		public bool InBoost { get; private set; }

		public float TCSMultiplayer { get; private set; }

		protected float HorizontalControl => 0f;

		public bool ABSIsActive { get; private set; }

		public int CurrentGear
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CurrentGearIndex => 0;

		public bool InChangeGear => false;

		public event Action OnConnectTrailer
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

		public event Action<float> OnStartEngineAction
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

		public event Action OnStopEngineAction
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

		public event Action BackFireAction
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

		public event Action<int> OnChangeGearAction
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

		protected override void Awake()
		{
		}

		private void OnEnable()
		{
		}

		protected override void FixedUpdate()
		{
		}

		protected override void OnTriggerEnter(Collider other)
		{
		}

		protected override void OnTriggerExit(Collider other)
		{
		}

		public virtual void TryConnectDisconnectTrailer()
		{
		}

		public override void ResetVehicle()
		{
		}

		[IteratorStateMachine(typeof(_003CResetDelay_003Ed__50))]
		private IEnumerator ResetDelay()
		{
			return null;
		}

		public void EnterInCar()
		{
		}

		public void EnterInCarNetwork()
		{
		}

		public void ExitFromCar()
		{
		}

		public void FreezeCar(bool isFreeze)
		{
		}

		public void FreezeVehicle_Network(bool isFreeze)
		{
		}

		private void AwakeEngine()
		{
		}

		private void FixedUpdateEngine()
		{
		}

		public void StartEngine()
		{
		}

		public void StopEngine()
		{
		}

		[IteratorStateMachine(typeof(_003CDoStartEngine_003Ed__127))]
		private IEnumerator DoStartEngine()
		{
			return null;
		}

		private void PlayBackfireWithProbability()
		{
		}

		private void PlayBackfireWithProbability(float probability)
		{
		}

		private void AwakeSteering()
		{
		}

		private void FixedUpdateSteering()
		{
		}

		private void HelpAngularVelocity()
		{
		}

		private void FixedUpdateBrakeLogic()
		{
		}

		private void AwakeTransmition()
		{
		}

		private void FixedUpdateTransmition()
		{
		}

		public void NextGear()
		{
		}

		public void PrevGear()
		{
		}
	}
}

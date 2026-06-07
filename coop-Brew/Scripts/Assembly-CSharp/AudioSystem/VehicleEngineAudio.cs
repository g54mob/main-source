using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Vehicle;
using Ezereal;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Audio;
using VFXSystem;

namespace AudioSystem
{
	public class VehicleEngineAudio : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CEngineStartCoroutine_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleEngineAudio _003C_003E4__this;

			public float doorDelay;

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
			public _003CEngineStartCoroutine_003Ed__101(int _003C_003E1__state)
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
		private sealed class _003CFlashBackfireTrail_003Ed__114 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleEngineAudio _003C_003E4__this;

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
			public _003CFlashBackfireTrail_003Ed__114(int _003C_003E1__state)
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

		[Header("Vehicle Type")]
		[Tooltip("Auto-detected based on controller type, but can be manually overridden")]
		[SerializeField]
		private AudioVehicleType audioVehicleType;

		[Header("Audio Mixer")]
		[Tooltip("AudioMixerGroup for volume control (should be Vehicle group from AudioManager)")]
		[SerializeField]
		private AudioMixerGroup vehicleMixerGroup;

		[Header("References")]
		[Tooltip("Unified vehicle controller interface (auto-found if not assigned)")]
		private IVehicleController vehicleController;

		[Tooltip("Reference to EzerealCarController (auto-found if not assigned)")]
		[SerializeField]
		private EzerealCarController carController;

		[Tooltip("Reference to MopedController (auto-found if not assigned)")]
		[SerializeField]
		private MopedController mopedController;

		[Tooltip("Reference to EzerealWheelFrictionController for drift detection (auto-found if not assigned)")]
		[SerializeField]
		private EzerealWheelFrictionController frictionController;

		[Tooltip("Reference to VehicleSkidController for surface detection (auto-found if not assigned)")]
		[SerializeField]
		private VehicleSkidController skidController;

		[Tooltip("Transform to animate on gear shifts (optional)")]
		[SerializeField]
		private Transform vehicleBody;

		[Header("RPM Clips (1000-6000 in 500 increments)")]
		[Tooltip("Assign 11 clips: 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 6000")]
		[SerializeField]
		private AudioClip[] rpmClips;

		[Header("One-Shot Clips")]
		[Tooltip("Engine start sound (played before idle loop begins)")]
		[SerializeField]
		private AudioClip engineStartClip;

		[Tooltip("Optional gear shift sound")]
		[SerializeField]
		private AudioClip gearShiftClip;

		[Header("Tire")]
		[Tooltip("Optional tire rolling loop")]
		[SerializeField]
		private AudioClip tireClip;

		[Header("Moped Audio Clips")]
		[Tooltip("Moped engine start sound")]
		[SerializeField]
		private AudioClip mopedStartClip;

		[Tooltip("Moped idle loop (when stationary or no throttle)")]
		[SerializeField]
		private AudioClip mopedIdleClip;

		[Tooltip("Moped driving loop (crossfades with idle based on throttle/speed)")]
		[SerializeField]
		private AudioClip mopedDriveClip;

		[Header("Moped Volume Controls")]
		[Tooltip("Volume for engine start sound")]
		[Range(0f, 1f)]
		[SerializeField]
		private float mopedStartVolume;

		[Tooltip("Volume for idle loop (always audible in background)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float mopedIdleVolume;

		[Tooltip("Volume for drive/accelerating loop")]
		[Range(0f, 1f)]
		[SerializeField]
		private float mopedDriveVolume;

		[Header("Moped Pitch Settings")]
		[Tooltip("Minimum pitch when idle/slow")]
		[Range(0.5f, 1.5f)]
		[SerializeField]
		private float mopedPitchMin;

		[Tooltip("Maximum pitch at high speed")]
		[Range(0.5f, 2f)]
		[SerializeField]
		private float mopedPitchMax;

		[Tooltip("Speed at which max pitch is reached (km/h)")]
		[SerializeField]
		private float mopedMaxSpeedForPitch;

		[Header("Moped Crossfade Settings")]
		[Tooltip("Minimum idle volume when accelerating (0.3 = 30% always audible)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float mopedIdleMinBlend;

		[Tooltip("Fade-out speed multiplier (lower = lazier engine)")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float mopedLazyFadeMultiplier;

		[Tooltip("Idle return speed multiplier when releasing throttle (lower = slower return)")]
		[Range(0.1f, 1f)]
		[SerializeField]
		private float mopedIdleReturnMultiplier;

		[Header("Moped Loop Crossfade (hides loop seams)")]
		[Tooltip("How many seconds before loop end to start crossfading to the other source")]
		[Range(0.1f, 2f)]
		[SerializeField]
		private float loopCrossfadeLeadTime;

		[Tooltip("Duration of crossfade between loop iterations")]
		[Range(0.1f, 2f)]
		[SerializeField]
		private float loopCrossfadeDuration;

		[Header("Vehicle Type")]
		[Tooltip("Pitch multiplier (1.0=car, 0.5-0.7=tractor)")]
		[Range(0.3f, 1.5f)]
		[SerializeField]
		private float pitchMultiplier;

		[Header("Gear Settings")]
		[Tooltip("Speed range per gear (km/h)")]
		[SerializeField]
		private float speedPerGear;

		[Tooltip("Maximum gears")]
		[SerializeField]
		private int maxGears;

		[Header("Audio Settings")]
		[Tooltip("Maximum engine volume")]
		[Range(0f, 1f)]
		[SerializeField]
		private float maxEngineVolume;

		[Tooltip("Maximum tire volume")]
		[Range(0f, 1f)]
		[SerializeField]
		private float maxTireVolume;

		[Tooltip("Audio crossfade speed")]
		[SerializeField]
		private float crossfadeSpeed;

		[Header("RPM Transition Speeds")]
		[Tooltip("How fast RPM rises when accelerating")]
		[SerializeField]
		private float rpmRiseSpeed;

		[Tooltip("How fast RPM falls when coasting (lift off throttle)")]
		[SerializeField]
		private float rpmFallSpeed;

		[Tooltip("How fast RPM returns to idle when stopped")]
		[SerializeField]
		private float rpmIdleSpeed;

		[Tooltip("Cruise RPM as fraction of acceleration target (0=idle, 1=full)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float coastingRpmFactor;

		[Tooltip("RPM increase per gear for minimum RPM (higher = more difference between gears)")]
		[SerializeField]
		private float rpmIncreasePerGear;

		[Header("Wheel Spin Audio (Burnouts/Doughnuts)")]
		[Tooltip("How much wheel RPM contributes to engine audio (0=ignore, 1=full)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float wheelSpinAudioFactor;

		[Tooltip("Conversion from wheel RPM to engine audio RPM")]
		[SerializeField]
		private float wheelRpmToEngineRpm;

		[Header("Gear Shift Animation")]
		[Tooltip("Enable body pitch on gear shift")]
		[SerializeField]
		private bool enableGearShiftAnimation;

		[Tooltip("Pitch angle (degrees)")]
		[SerializeField]
		private float shiftPitchAngle;

		[Header("Exhaust Backfire")]
		[Tooltip("Transform at exhaust pipe location (for audio positioning)")]
		[SerializeField]
		private Transform exhaustTransform;

		[Tooltip("Flame trail GameObject to flash on/off (should be disabled by default)")]
		[SerializeField]
		private GameObject backfireTrail;

		[Tooltip("Backfire pop/bang sound")]
		[SerializeField]
		private AudioClip backfireClip;

		[Tooltip("Chance of backfire on downshift while coasting (0=never, 1=always)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float backfireChance;

		[Tooltip("How long the flame trail stays visible (seconds)")]
		[SerializeField]
		private float backfireDuration;

		[Tooltip("Backfire sound volume")]
		[Range(0f, 1f)]
		[SerializeField]
		private float backfireVolume;

		[Header("Drift Sound")]
		[Tooltip("Tire squeal loop for drifting")]
		[SerializeField]
		private AudioClip driftLoopClip;

		[Tooltip("Maximum drift sound volume")]
		[Range(0f, 1f)]
		[SerializeField]
		private float maxDriftVolume;

		[Tooltip("Minimum speed to play drift sound (km/h)")]
		[SerializeField]
		private float minDriftSpeed;

		[Tooltip("Minimum sideways velocity to trigger drift sound (m/s)")]
		[SerializeField]
		private float minDriftSidewaysVel;

		[Tooltip("Sideways velocity for max drift volume (m/s)")]
		[SerializeField]
		private float maxDriftSidewaysVel;

		[Tooltip("Drift sound pitch range")]
		[SerializeField]
		private float driftPitchMin;

		[SerializeField]
		private float driftPitchMax;

		[Tooltip("How fast drift sound fades in/out")]
		[SerializeField]
		private float driftFadeSpeed;

		[Header("Brake Sound")]
		[Tooltip("Brake squeal loop")]
		[SerializeField]
		private AudioClip brakeSquealClip;

		[Tooltip("Maximum brake sound volume")]
		[Range(0f, 1f)]
		[SerializeField]
		private float maxBrakeVolume;

		[Tooltip("Minimum speed for brake squeal (km/h)")]
		[SerializeField]
		private float minBrakeSpeed;

		[Tooltip("Minimum brake input to trigger squeal (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float minBrakeInput;

		[Tooltip("Brake sound pitch range")]
		[SerializeField]
		private float brakePitchMin;

		[SerializeField]
		private float brakePitchMax;

		[Tooltip("How fast brake sound fades in/out")]
		[SerializeField]
		private float brakeFadeSpeed;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private AudioSource[] rpmSources;

		private AudioSource tireSource;

		private AudioSource driftSource;

		private AudioSource brakeSource;

		private AudioSource mopedIdleSourceA;

		private AudioSource mopedIdleSourceB;

		private AudioSource mopedDriveSourceA;

		private AudioSource mopedDriveSourceB;

		private bool idleUsingA;

		private bool driveUsingA;

		private float idleCrossfadeT;

		private float driveCrossfadeT;

		private bool idleCrossfading;

		private bool driveCrossfading;

		private float idleSmoothedVolume;

		private float driveSmoothedVolume;

		private float driveSmoothedPitch;

		private int currentGear;

		private float currentRpm;

		private bool isEngineOn;

		private float lastShiftTime;

		private bool isAnimating;

		private bool isStartingEngine;

		private const float IDLE_RPM = 1000f;

		private const float MIN_RPM = 1000f;

		private const float RPM_STEP = 500f;

		private const float SHIFT_COOLDOWN = 0.3f;

		public event Action OnGearShift
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

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void SyncMopedEngineState()
		{
		}

		public override void OnDestroy()
		{
		}

		private void CreateAudioSources()
		{
		}

		private void CreateMopedAudioSources()
		{
		}

		private AudioSource CreateNonLoopingSource(string name, AudioClip clip)
		{
			return null;
		}

		private AudioSource CreateLoopingSource(string name, AudioClip clip)
		{
			return null;
		}

		public void StartEngineSequence(float doorSoundDelay = 0.8f)
		{
		}

		public void StopEngineSequence()
		{
		}

		[IteratorStateMachine(typeof(_003CEngineStartCoroutine_003Ed__101))]
		private IEnumerator EngineStartCoroutine(float doorDelay)
		{
			return null;
		}

		private void StartEngineLoops()
		{
		}

		private void StopEngine()
		{
		}

		private float GetMaxRpmForGear()
		{
			return 0f;
		}

		private float GetMinRpmForGear()
		{
			return 0f;
		}

		private float GetDrivenWheelRpm()
		{
			return 0f;
		}

		private void UpdateGears()
		{
		}

		private void ShiftUp()
		{
		}

		private void ShiftDown()
		{
		}

		private void TryBackfire()
		{
		}

		[Rpc(SendTo.Server)]
		private void TriggerBackfireRpc()
		{
		}

		[ClientRpc]
		private void TriggerBackfireClientRpc()
		{
		}

		private void ExecuteBackfire()
		{
		}

		[IteratorStateMachine(typeof(_003CFlashBackfireTrail_003Ed__114))]
		private IEnumerator FlashBackfireTrail()
		{
			return null;
		}

		private void PlayGearShift()
		{
		}

		private void UpdateEngineAudio()
		{
		}

		private void UpdateMopedAudio()
		{
		}

		private void UpdateMopedEngineAudio()
		{
		}

		private void UpdateDoubleBufferedLoop(AudioSource sourceA, AudioSource sourceB, ref bool usingA, ref bool crossfading, ref float crossfadeT, float volume, float pitch, AudioClip clip)
		{
		}

		private void UpdateMopedTireAudio()
		{
		}

		private void UpdateTireAudio()
		{
		}

		private void UpdateDriftAndBrakeAudio()
		{
		}

		public void SetPitchMultiplier(float value)
		{
		}

		public int GetCurrentGear()
		{
			return 0;
		}

		public float GetCurrentRpm()
		{
			return 0f;
		}

		public bool IsEngineRunning()
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2423594931(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4139308704(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

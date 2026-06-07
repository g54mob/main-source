using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InteractionSystem;
using MyStuff.Environment;
using Unity.Netcode;
using UnityEngine;

namespace MyStuff.Sleep
{
	public class SleepManager : NetworkBehaviour
	{
		public enum SleepPhase
		{
			None = 0,
			WaitingForPlayers = 1,
			Sleeping = 2,
			WakingUp = 3
		}

		[CompilerGenerated]
		private sealed class _003CAccelerateTimeCoroutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepManager _003C_003E4__this;

			private TimeOfDayManager _003CtimeManager_003E5__2;

			private float _003CcameraReturnNormalizedTime_003E5__3;

			private float _003CwakeUpNormalizedTime_003E5__4;

			private float _003CcurrentTime_003E5__5;

			private bool _003CneedsMidnightWrap_003E5__6;

			private bool _003CpassedMidnight_003E5__7;

			private bool _003CcameraReturnTriggered_003E5__8;

			private float _003CsafetyTimeout_003E5__9;

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
			public _003CAccelerateTimeCoroutine_003Ed__47(int _003C_003E1__state)
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
		private sealed class _003CClearStartingFlagAfterDelay_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SleepManager _003C_003E4__this;

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
			public _003CClearStartingFlagAfterDelay_003Ed__43(int _003C_003E1__state)
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

		[Header("Sleep Settings")]
		[Tooltip("Time scale multiplier during sleep (higher = faster time roll)")]
		[SerializeField]
		private float acceleratedTimeScale;

		[Tooltip("Hour when camera starts returning to player (24-hour format)")]
		[SerializeField]
		private int cameraReturnHour;

		[Tooltip("Minute when camera starts returning")]
		[SerializeField]
		private int cameraReturnMinute;

		[Tooltip("Target hour to wake up and regain control (24-hour format)")]
		[SerializeField]
		private int wakeUpHour;

		[Tooltip("Target minute to wake up")]
		[SerializeField]
		private int wakeUpMinute;

		[Header("Defensive Settings")]
		[Tooltip("Maximum retries for finding local player bed")]
		[SerializeField]
		private int maxBedFindRetries;

		[Tooltip("Delay between retries (seconds)")]
		[SerializeField]
		private float bedFindRetryDelay;

		[Tooltip("Maximum time to wait for all components to be ready (seconds)")]
		[SerializeField]
		private float maxReadinessWaitTime;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<SleepPhase> currentPhase;

		private NetworkList<ulong> sleepingPlayerIds;

		private Dictionary<ulong, BedInteractable> playerBeds;

		private Coroutine timeAccelerationCoroutine;

		private float originalTimeScale;

		private bool isStartingSleepSequence;

		private Coroutine cameraSequenceCoroutine;

		private bool hasCameraSequenceStarted;

		public static SleepManager Instance { get; private set; }

		public int SleepingPlayerCount => 0;

		public int TotalPlayerCount => 0;

		public bool AllPlayersReady => false;

		public SleepPhase CurrentPhase => default(SleepPhase);

		public bool CanStartSleeping => false;

		public bool IsPlayerSleeping(ulong clientId)
		{
			return false;
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void ResetTimeScaleToNormal()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public override void OnDestroy()
		{
		}

		private void StopAllSleepCoroutines()
		{
		}

		public void PlayerStartedSleeping(ulong clientId, BedInteractable bed)
		{
		}

		public void PlayerCancelledSleep(ulong clientId)
		{
		}

		private void OnClientDisconnect(ulong clientId)
		{
		}

		private void StartSleepSequence()
		{
		}

		[IteratorStateMachine(typeof(_003CClearStartingFlagAfterDelay_003Ed__43))]
		private IEnumerator ClearStartingFlagAfterDelay()
		{
			return null;
		}

		private void NotifyClientsToStartCameraSequence()
		{
		}

		private void CompleteAllStationSteps()
		{
		}

		private void AbortSleepSequence()
		{
		}

		[IteratorStateMachine(typeof(_003CAccelerateTimeCoroutine_003Ed__47))]
		private IEnumerator AccelerateTimeCoroutine()
		{
			return null;
		}

		private void WakeAllPlayers()
		{
		}

		[ClientRpc]
		private void StartCameraSequenceForClientClientRpc(ulong bedNetworkObjectId, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		private void StartCameraSequenceImmediate(ulong bedNetworkObjectId)
		{
		}

		[ClientRpc]
		private void EndCameraSequenceClientRpc()
		{
		}

		[ClientRpc]
		private void AbortCameraSequenceClientRpc()
		{
		}

		private void TriggerAutoSaveOnSleep()
		{
		}

		private BedInteractable GetLocalPlayerBed()
		{
			return null;
		}

		private void OnPhaseChanged(SleepPhase previousValue, SleepPhase newValue)
		{
		}

		[ContextMenu("Force Reset Sleep State")]
		public void ForceResetState()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1713943535(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_234106259(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2925332673(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Crime
{
	public class CommunityServiceManager : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CServiceCoroutine_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CommunityServiceManager _003C_003E4__this;

			public ulong playerNetworkId;

			private float _003Celapsed_003E5__2;

			private Transform _003CplayerTransform_003E5__3;

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
			public _003CServiceCoroutine_003Ed__29(int _003C_003E1__state)
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

		[Header("Crime Reduction Settings")]
		[Tooltip("Crime rate reduction per hour of service (%)")]
		[SerializeField]
		private float crimeReductionPerHour;

		[Tooltip("Maximum crime reduction per day (%) to prevent abuse")]
		[SerializeField]
		private float maxReductionPerDay;

		[Header("Service Requirements")]
		[Tooltip("Minimum time player must spend doing service (real-time seconds)")]
		[SerializeField]
		private float minimumServiceTime;

		[Tooltip("Maximum continuous service time before break required (real-time seconds)")]
		[SerializeField]
		private float maximumServiceTime;

		[Tooltip("Cooldown between service sessions (real-time seconds)")]
		[SerializeField]
		private float serviceCooldown;

		[Header("Service Location")]
		[Tooltip("Interaction radius for starting service")]
		[SerializeField]
		private float interactionRadius;

		[Tooltip("Player must stay within this radius or service is cancelled")]
		[SerializeField]
		private float serviceRadius;

		[Header("Visual Feedback")]
		[Tooltip("Particle effect to play during service (optional)")]
		[SerializeField]
		private ParticleSystem serviceParticles;

		[Tooltip("Audio clip to play during service (optional)")]
		[SerializeField]
		private AudioClip serviceAudio;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> isServiceActive;

		private NetworkVariable<ulong> currentServicerNetworkId;

		private NetworkVariable<double> serviceStartTime;

		private Dictionary<ulong, float> dailyReductionTracker;

		private Dictionary<ulong, double> cooldownTracker;

		private Coroutine serviceCoroutine;

		private AudioSource audioSource;

		public bool IsServiceActive => false;

		public ulong CurrentServicerNetworkId => 0uL;

		public float CurrentServiceDuration => 0f;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public bool CanStartService(ulong playerNetworkId, out string reason)
		{
			reason = null;
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		public void StartServiceServerRpc(ulong playerNetworkId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void StopServiceServerRpc(ulong playerNetworkId)
		{
		}

		private void StopService(ulong playerNetworkId, string reason, bool wasCompleted)
		{
		}

		[IteratorStateMachine(typeof(_003CServiceCoroutine_003Ed__29))]
		private IEnumerator ServiceCoroutine(ulong playerNetworkId)
		{
			return null;
		}

		private void ApplyCrimeReduction(ulong playerNetworkId, float serviceDuration)
		{
		}

		public void ResetDailyReductions()
		{
		}

		[ClientRpc]
		private void StartServiceClientRpc(ulong playerNetworkId)
		{
		}

		[ClientRpc]
		private void StopServiceClientRpc(ulong playerNetworkId, string reason, bool wasCompleted)
		{
		}

		[ClientRpc]
		private void NotifyServiceFailedClientRpc(ulong playerNetworkId, string reason)
		{
		}

		[ClientRpc]
		private void NotifyReductionAppliedClientRpc(ulong playerNetworkId, float reductionAmount)
		{
		}

		private new NetworkObject GetNetworkObject(ulong networkObjectId)
		{
			return null;
		}

		public bool IsPlayerInRange(Transform playerTransform)
		{
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2643968252(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_905034541(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3127069802(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3966075925(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3523911186(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_93347643(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

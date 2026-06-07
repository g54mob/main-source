using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Minigames
{
	[RequireComponent(typeof(NetworkObject))]
	public class BoilingMinigameManager : NetworkBehaviour
	{
		[Header("Configuration")]
		[SerializeField]
		private MinigameConfig config;

		private Component station;

		private object processingTimerRef;

		private object currentStepDurationRef;

		private FieldInfo processingStepField;

		private object processingStepNetVar;

		private readonly NetworkVariable<MinigameSessionData> currentSession;

		private Dictionary<ulong, PlayerMinigameContribution> contributions;

		private int lastKnownStepIndex;

		private int rushMeterCarryOver;

		private bool reflectionValid;

		private int pendingStepIndex;

		private int pendingPreviousStep;

		public MinigameSessionData CurrentSession => default(MinigameSessionData);

		public bool IsMinigameAvailable => false;

		public bool ReflectionValid => false;

		public event Action<MinigameRewardResult> OnRewardReceived
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

		public event Action<MinigameSessionData> OnSessionStarted
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

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void CacheReflection()
		{
		}

		private int ReadStepIndex()
		{
			return 0;
		}

		private void Update()
		{
		}

		private void OnStepChanged(int newStepIndex, int previousStepIndex)
		{
		}

		private void OnSessionChanged(MinigameSessionData previous, MinigameSessionData current)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SubmitMinigameResultServerRpc(MinigameSubmission submission, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void ApplyProgressCredit(float seconds)
		{
		}

		private int CountActiveContributors(double currentTime, double windowSeconds)
		{
			return 0;
		}

		[ClientRpc]
		private void NotifyRewardClientRpc(MinigameRewardResult result, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void BroadcastSessionUpdateClientRpc(float totalGranted, int rushMeter, MinigameTier rushTier)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ToggleOverclockServerRpc(bool enabled, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3045088073(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2793700647(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3322414794(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_840254306(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

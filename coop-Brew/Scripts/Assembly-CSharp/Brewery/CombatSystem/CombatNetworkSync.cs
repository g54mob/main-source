using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.CombatSystem
{
	[RequireComponent(typeof(Animator))]
	public class CombatNetworkSync : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private SimpleCombatController combatController;

		[Header("Network Settings")]
		[Tooltip("Minimum time between attack requests (rate limiting)")]
		[SerializeField]
		private float attackRateLimit;

		private NetworkVariable<bool> isInCombat;

		private NetworkVariable<int> comboStep;

		private NetworkVariable<bool> isBlocking;

		private NetworkVariable<bool> isHurt;

		private NetworkVariable<bool> isAttacking;

		private NetworkVariable<double> attackStartNetworkTime;

		private NetworkVariable<float> attackWindowDuration;

		private Dictionary<ulong, float> lastAttackTime;

		private static readonly int InCombatHash;

		private static readonly int AttackTriggerHash;

		private static readonly int AttackIndexHash;

		private static readonly int BlockHoldHash;

		private static readonly int HitTriggerHash;

		public bool IsInCombat => false;

		public bool IsBlocking => false;

		public bool IsHurt => false;

		public int ComboStep => 0;

		public bool IsAttacking => false;

		public double AttackStartNetworkTime => 0.0;

		public float AttackWindowDuration => 0f;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		[ServerRpc]
		public void RequestAttackServerRpc(int step, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		public void SetBlockingServerRpc(bool blocking, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		public void SetInCombatServerRpc(bool inCombat, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		public void NotifyAttackStartedServerRpc(float windowDuration, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		public void NotifyAttackEndedServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void PlayAttackClientRpc(int step)
		{
		}

		[ClientRpc]
		public void PlayHitReactionClientRpc(ulong victimClientId, float damage, Vector3 attackerPosition, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		public void SyncCombatStateClientRpc(bool inCombat)
		{
		}

		private void OnInCombatChanged(bool previous, bool current)
		{
		}

		private void OnBlockingChanged(bool previous, bool current)
		{
		}

		private void OnHurtChanged(bool previous, bool current)
		{
		}

		private void OnComboStepChanged(int previous, int current)
		{
		}

		private void OnIsAttackingChanged(bool previous, bool current)
		{
		}

		private void ResetHurtState()
		{
		}

		public bool IsInValidAttackWindow(float toleranceSeconds = 0.15f)
		{
			return false;
		}

		public void ResetAttackState()
		{
		}

		private void UpdateAnimatorState()
		{
		}

		public void ServerApplyHit(NetworkObject victim, float damage, Vector3 attackerPosition)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1468532720(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_447440534(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2065943802(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1309577233(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4010011419(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2116326409(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2358401682(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3836399170(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

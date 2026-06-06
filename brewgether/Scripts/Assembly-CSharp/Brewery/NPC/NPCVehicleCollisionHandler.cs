using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC
{
	[RequireComponent(typeof(NetworkObject))]
	public class NPCVehicleCollisionHandler : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRespawnAtHomeCoroutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCVehicleCollisionHandler _003C_003E4__this;

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
			public _003CRespawnAtHomeCoroutine_003Ed__23(int _003C_003E1__state)
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

		[Header("Detection")]
		[Tooltip("Layer mask for detecting vehicles")]
		[SerializeField]
		private LayerMask vehicleLayerMask;

		[Tooltip("Minimum vehicle speed (m/s) to trigger ragdoll. Below this, NPC just gets pushed.")]
		[SerializeField]
		private float minVehicleSpeed;

		[Tooltip("Minimum vehicle speed (m/s) for a lethal hit. Below this, NPC ragdolls but survives and respawns.")]
		[SerializeField]
		private float lethalSpeedThreshold;

		[Header("Ragdoll")]
		private float impactForceMultiplier;

		private float upwardForceBonus;

		[Header("Recovery")]
		[Tooltip("Time before NPC respawns at home (seconds)")]
		[SerializeField]
		private float respawnDelay;

		[Tooltip("Fade out ragdoll before respawn (spawn disappear particles)")]
		[SerializeField]
		private bool fadeOutBeforeRespawn;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private CapsuleCollider capsuleCollider;

		private NPCRagdollController ragdollController;

		private SimpleNPCController npcController;

		private NPCHealthController healthController;

		private bool isBeingHitByVehicle;

		private Coroutine respawnCoroutine;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private bool IsVehicle(GameObject obj)
		{
			return false;
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		public void HandleVehicleImpactRpc(Vector3 impactForce, Vector3 impactPoint, float vehicleSpeed)
		{
		}

		public void HandleVehicleImpact(Vector3 impactForce, Vector3 impactPoint, float vehicleSpeed)
		{
		}

		[ClientRpc]
		private void PlayImpactEffectsClientRpc(Vector3 impactPoint)
		{
		}

		private void HandleVehicleHit(Collision collision, Rigidbody vehicleRb, float vehicleSpeed)
		{
		}

		[ClientRpc]
		private void DisableCapsuleColliderClientRpc()
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnAtHomeCoroutine_003Ed__23))]
		private IEnumerator RespawnAtHomeCoroutine()
		{
			return null;
		}

		private Vector3 GetVisitorRespawnPoint()
		{
			return default(Vector3);
		}

		private void RespawnAtHome(Vector3 respawnPosition)
		{
		}

		[ClientRpc]
		private void RespawnClientRpc(Vector3 homePosition)
		{
		}

		private void OnDisable()
		{
		}

		private static bool VehicleHasDriver(Rigidbody vehicleRb)
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_650173280(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4007263662(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1201394923(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_78145487(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

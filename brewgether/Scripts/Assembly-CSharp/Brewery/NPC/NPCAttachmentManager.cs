using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC
{
	public class NPCAttachmentManager : NetworkBehaviour
	{
		private class AttachmentData
		{
			public Transform transform;

			public GameObject gameObject;

			public MeshFilter meshFilter;

			public MeshRenderer meshRenderer;

			public SkinnedMeshRenderer skinnedMeshRenderer;

			public bool isCurrentlyDetached;

			public Coroutine respawnCoroutine;
		}

		[CompilerGenerated]
		private sealed class _003CRespawnAfterDelay_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCAttachmentManager _003C_003E4__this;

			public AttachmentData attachment;

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
			public _003CRespawnAfterDelay_003Ed__28(int _003C_003E1__state)
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

		[Header("Detachment Settings")]
		[Tooltip("Chance (0-1) for each attachment to detach when NPC is hit")]
		[Range(0f, 1f)]
		[SerializeField]
		private float detachChancePerHit;

		[Tooltip("Maximum attachments that can detach from a single hit")]
		[SerializeField]
		private int maxDetachmentsPerHit;

		[Tooltip("Minimum damage required to potentially detach attachments")]
		[SerializeField]
		private float minDamageToDetach;

		[Header("Physics Settings")]
		[Tooltip("How long the fallen attachment exists before being cleaned up")]
		[SerializeField]
		private float fallenLifetime;

		[Tooltip("Force multiplier applied to fallen attachments")]
		[SerializeField]
		private float detachForceMultiplier;

		[Tooltip("Upward force component to make attachments pop up")]
		[SerializeField]
		private float upwardForce;

		[Tooltip("Random torque applied to fallen attachments for tumbling")]
		[SerializeField]
		private float randomTorque;

		[Header("Respawn Settings")]
		[Tooltip("Time before detached attachment reappears on NPC")]
		[SerializeField]
		private float respawnDelay;

		[Header("Pop Animation (LeanTween)")]
		[Tooltip("Enable scale pop animation when attachments detach")]
		[SerializeField]
		private bool enablePopAnimation;

		[Tooltip("Scale punch amount (1.5 = 50% bigger at peak)")]
		[SerializeField]
		private float scalePunchAmount;

		[Tooltip("Duration of the scale punch animation")]
		[SerializeField]
		private float popDuration;

		[Header("Layer Settings")]
		[Tooltip("Physics layer for fallen attachments")]
		[SerializeField]
		private string fallenLayer;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private List<AttachmentData> attachments;

		private bool isInitialized;

		private NPCHealthController healthController;

		public int AttachmentCount => 0;

		public int DetachedCount => 0;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void InitializeAttachments()
		{
		}

		private Transform FindChildRecursive(Transform parent, string childName)
		{
			return null;
		}

		private void OnNPCDamaged(ulong attackerId, Vector3 attackerPosition, float damage)
		{
		}

		[ClientRpc]
		private void DetachAttachmentsClientRpc(int[] indices, Vector3 hitDirection, float force, int physicsSeed)
		{
		}

		[ClientRpc]
		private void RespawnAttachmentClientRpc(int index)
		{
		}

		[ClientRpc]
		private void RespawnAllClientRpc()
		{
		}

		private void DetachAttachment(AttachmentData attachment, Vector3 hitDirection, float force)
		{
		}

		private void SpawnFallenAttachment(AttachmentData attachment, Vector3 position, Quaternion rotation, Vector3 scale, Vector3 hitDirection, float force)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnAfterDelay_003Ed__28))]
		private IEnumerator RespawnAfterDelay(AttachmentData attachment)
		{
			return null;
		}

		public void RespawnAllAttachments()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3337787447(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1082763512(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_541558531(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

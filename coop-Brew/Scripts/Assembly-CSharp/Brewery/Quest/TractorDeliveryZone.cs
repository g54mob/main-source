using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	public class TractorDeliveryZone : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSubscribeToQuestEvents_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TractorDeliveryZone _003C_003E4__this;

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
			public _003CSubscribeToQuestEvents_003Ed__16(int _003C_003E1__state)
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

		[Header("Quest Configuration")]
		[SerializeField]
		private string npcId;

		[SerializeField]
		private string questChainId;

		[SerializeField]
		private string customEventContext;

		[SerializeField]
		private int deliveryStepIndex;

		[Header("Detection")]
		[SerializeField]
		private string tractorTag;

		[Header("Visual Feedback")]
		[SerializeField]
		private GameObject vfxObject;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool hasDelivered;

		private GameObject pendingTractor;

		private VehicleInteractable pendingVehicleInteractable;

		private bool pendingDisable;

		private ParticleSystem[] childParticles;

		private bool subscribedToQuest;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSubscribeToQuestEvents_003Ed__16))]
		private IEnumerator SubscribeToQuestEvents()
		{
			return null;
		}

		private void UnsubscribeFromQuestEvents()
		{
		}

		private void HandleQuestStepChanged(string questId, int stepIndex, QuestStep step)
		{
		}

		private void HandleQuestCompleted(string questId, QuestChain chain)
		{
		}

		private void HandleSaveDataRestored()
		{
		}

		private void SyncToCurrentQuestState()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void Update()
		{
		}

		[ClientRpc]
		private void OnTractorDeliveredClientRpc()
		{
		}

		private void DisableTractorControls(GameObject tractor)
		{
		}

		[ClientRpc]
		private void DisableTractorControlsClientRpc()
		{
		}

		public void EnableDeliveryZone()
		{
		}

		public void DisableDeliveryZone()
		{
		}

		private void SetParticlesEmitting(bool emit)
		{
		}

		public void ResetDeliveryState()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2029888227(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4078233218(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

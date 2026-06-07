using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Simple;
using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Quest
{
	[RequireComponent(typeof(NetworkObject))]
	public class NPCQuestGiver : NetworkBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CRegisterAndAutoStartCoroutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCQuestGiver _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CRegisterAndAutoStartCoroutine_003Ed__26(int _003C_003E1__state)
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

		[Header("NPC Identity")]
		[Tooltip("Unique identifier for this NPC (e.g., 'uncle_benny')")]
		[SerializeField]
		private string npcId;

		[Tooltip("Display name shown in UI")]
		[SerializeField]
		private string displayName;

		[Header("Quest Configuration")]
		[Tooltip("The quest chain this NPC gives (optional - can be auto-started)")]
		[SerializeField]
		private QuestChain questChain;

		[Tooltip("If true, this NPC's quest auto-starts when player spawns")]
		[SerializeField]
		private bool autoStartQuest;

		[Header("Phase Dialogue")]
		[Tooltip("Dialogue shown when quest hasn't started yet")]
		[TextArea(2, 5)]
		[SerializeField]
		private string preQuestDialogue;

		[Tooltip("Dialogue shown when quest is completed")]
		[TextArea(2, 5)]
		[SerializeField]
		private string postQuestDialogue;

		[Header("Components")]
		[Tooltip("Head look component (optional, for player tracking)")]
		[SerializeField]
		private SimpleNPCHeadLook headLook;

		[Tooltip("Animator component (optional, for idle animations)")]
		[SerializeField]
		private SimpleNPCAnimator animator;

		[Tooltip("Portrait image shown in quest dialogue UI")]
		[SerializeField]
		private Sprite portrait;

		[Header("Interaction")]
		[Tooltip("Interaction distance (meters)")]
		[SerializeField]
		private float interactionDistance;

		[Tooltip("Interaction priority (higher = preferred)")]
		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isDialogueActive;

		public string NPCId => null;

		public string DisplayName => null;

		public QuestChain QuestChain => null;

		public bool AutoStartQuest => false;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void RegisterAndAutoStartQuest()
		{
		}

		[IteratorStateMachine(typeof(_003CRegisterAndAutoStartCoroutine_003Ed__26))]
		private IEnumerator RegisterAndAutoStartCoroutine()
		{
			return null;
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		private void DetermineAndShowDialogue(ulong interactingClientId)
		{
		}

		private ClientRpcParams CreateClientRpcParams(ulong targetClientId)
		{
			return default(ClientRpcParams);
		}

		[ClientRpc]
		private void ShowSimpleDialogueClientRpc(string dialogue, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void ShowQuestDialogueClientRpc(string questId, int stepIndex, ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		private void ShowDialogueForCurrentState(ulong interactingClientId)
		{
		}

		private void ShowQuestStepDialogue(string questId, ulong interactingClientId)
		{
		}

		private string GetReminderDialogue(QuestStep step)
		{
			return null;
		}

		private void ShowSimpleDialogue(string dialogue)
		{
		}

		public string GetCurrentDialoguePreview()
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1296759314(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2304234223(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

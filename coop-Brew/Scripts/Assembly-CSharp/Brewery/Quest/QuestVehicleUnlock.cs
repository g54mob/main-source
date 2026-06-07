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
	public class QuestVehicleUnlock : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSubscribeToQuestEvents_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestVehicleUnlock _003C_003E4__this;

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
			public _003CSubscribeToQuestEvents_003Ed__8(int _003C_003E1__state)
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
		private string questChainId;

		[SerializeField]
		private int unlockAtStepIndex;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VehicleInteractable vehicleInteractable;

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

		[IteratorStateMachine(typeof(_003CSubscribeToQuestEvents_003Ed__8))]
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

		private void SetVehicleInteractable(bool interactable)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}

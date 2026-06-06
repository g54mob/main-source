using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Data;
using InteractionSystem;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class VisitorNPCInteraction : MonoBehaviour, IInteractable
	{
		[CompilerGenerated]
		private sealed class _003CWanderBehavior_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisitorNPCInteraction _003C_003E4__this;

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
			public _003CWanderBehavior_003Ed__31(int _003C_003E1__state)
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

		[Header("Settings")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("Wandering")]
		[SerializeField]
		private float wanderRadius;

		[SerializeField]
		private float minWanderInterval;

		[SerializeField]
		private float maxWanderInterval;

		[SerializeField]
		private float idleLookAroundChance;

		private bool _isActive;

		private Vector3 _gatheringCenter;

		private NPCProfile _profile;

		private SimpleNPCController _controller;

		private SimpleNPCLifeBrain _lifeBrain;

		private INPCMotor _motor;

		private SimpleNPCHeadLook _headLook;

		private Transform _interactionAnchor;

		private Coroutine _wanderCoroutine;

		private bool _isInteracting;

		private Transform _interactingPlayer;

		public NPCProfile Profile => null;

		public bool IsActiveVisitor => false;

		private bool IsServer => false;

		public static event Action<NPCProfile> OnVisitorInteracted
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

		public void Initialize(NPCProfile profile)
		{
		}

		private void OnDestroy()
		{
		}

		public void Deactivate()
		{
		}

		private void DisableNormalBehavior()
		{
		}

		private void EnableNormalBehavior()
		{
		}

		[IteratorStateMachine(typeof(_003CWanderBehavior_003Ed__31))]
		private IEnumerator WanderBehavior()
		{
			return null;
		}

		private void StopAndLookAtPlayer(Transform player)
		{
		}

		public void ResumeWandering()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
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
	}
}

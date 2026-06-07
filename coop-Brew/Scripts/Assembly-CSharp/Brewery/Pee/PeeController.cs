using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.EmoteSystem;
using Brewery.Player;
using Player.Customization.Sidekick;
using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Pee
{
	public class PeeController : NetworkBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDisablePeeFXDelayed_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public PeeController _003C_003E4__this;

			public GameObject fxRoot;

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
			public _003CDisablePeeFXDelayed_003Ed__68(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		private InputReader inputReader;

		[SerializeField]
		private Animator animator;

		[Tooltip("Parent GameObject containing male pee particle systems (jet, drops, splash). Will be enabled/disabled.")]
		[SerializeField]
		private GameObject malePeeFXRoot;

		[Tooltip("Parent GameObject containing female pee particle systems (jet, drops, splash). Will be enabled/disabled.")]
		[SerializeField]
		private GameObject femalePeeFXRoot;

		[Header("Settings")]
		[Tooltip("Percentage added per drink consumed")]
		[SerializeField]
		private float peePerDrink;

		[Tooltip("Real-time seconds for the pee meter to fill from 0% to 100% naturally")]
		[SerializeField]
		private float naturalFillDuration;

		[Tooltip("How many seconds it takes to drain 10% while peeing")]
		[SerializeField]
		private float secondsPer10Percent;

		[Tooltip("Seconds at 100% before the player pees themselves")]
		[SerializeField]
		private float urgentTimeLimit;

		[Tooltip("Safety timeout - force stop peeing after this many seconds even if drain fails")]
		[SerializeField]
		private float maxPeeDuration;

		private NetworkVariable<float> syncedPeePercentage;

		private NetworkVariable<bool> syncedIsPeeing;

		private float urgentTimer;

		private bool isUrgent;

		private float peeTimer;

		private bool isPeeingLocal;

		private float peeStartPercentage;

		private bool isWCDraining;

		private SamplePlayerAnimationController movementController;

		private bool wasMovementEnabled;

		private bool movementLockedByUs;

		private SidekickCharacterCustomizer sidekickCustomizer;

		private bool isFemale;

		private bool forcedCrouchByUs;

		private EmoteController emoteController;

		private PlayerHealthController healthController;

		private PeeIK peeIK;

		public float PeePercentage => 0f;

		public bool IsPeeing => false;

		public bool IsUrgent => false;

		public float UrgentTimeRemaining => 0f;

		public bool IsWCDraining => false;

		public event Action<float> OnPeePercentageChanged
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

		public event Action<bool> OnUrgentStateChanged
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

		public event Action OnPeedSelf
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

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnDisable()
		{
		}

		private new void OnDestroy()
		{
		}

		private void SubscribeToInput()
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void Update()
		{
		}

		public void AddPee(float amount = -1f)
		{
		}

		public void StartWCPee()
		{
		}

		public void StopWCPee()
		{
		}

		private void OnPlayerDeath()
		{
		}

		private void HandlePeeInput()
		{
		}

		private void StartPeeing()
		{
		}

		private void StopPeeing()
		{
		}

		public void ForceStopPeeing()
		{
		}

		private void OnPeeingStateChanged(bool oldValue, bool newValue)
		{
		}

		private void ApplyPeeVisuals(bool peeing)
		{
		}

		private void LockMovement()
		{
		}

		private void RestoreMovement()
		{
		}

		private void ForceCrouch()
		{
		}

		private void RestoreCrouch()
		{
		}

		private GameObject GetActivePeeFXRoot()
		{
			return null;
		}

		private void SetPeeFXActive(bool active)
		{
		}

		[IteratorStateMachine(typeof(_003CDisablePeeFXDelayed_003Ed__68))]
		private IEnumerator DisablePeeFXDelayed(GameObject fxRoot, float delay)
		{
			return null;
		}

		private bool IsInputBlocked()
		{
			return false;
		}

		[ContextMenu("Fill Pee to 100%")]
		private void DebugFillPee()
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

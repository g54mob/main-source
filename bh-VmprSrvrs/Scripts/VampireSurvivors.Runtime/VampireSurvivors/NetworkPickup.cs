using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings.TransformBindings;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors
{
	[RequireComponent(typeof(CoherenceSync))]
	public class NetworkPickup : Pickup
	{
		[CompilerGenerated]
		private sealed class _003CWaitForAcksAndReturnToPool_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkPickup _003C_003E4__this;

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
			public _003CWaitForAcksAndReturnToPool_003Ed__39(int _003C_003E1__state)
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

		protected CoherenceSync _coherenceSync;

		protected bool _vacuumAssigned;

		protected bool _takeAssigned;

		protected bool _performingVacuum;

		protected bool _performingTake;

		protected bool _requestedVacuum;

		protected bool _requestedTake;

		protected List<ClientID> _ackedClients;

		protected bool _taken;

		protected bool _canPauseSyncTimer;

		protected bool _reactivateRenderer;

		protected Coherence.Log.Logger _logger;

		private PositionBinding _positionBinding;

		private float _ackTimeout;

		private const float MaxAckTimeout = 3.4028235E+38f;

		protected virtual bool UsesOrderedCommand => false;

		public CoherenceSync Sync => null;

		public bool ForceDespawn { get; set; }

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestVacuum(CoherenceSync requestingPlayer)
		{
		}

		[Command]
		public void PerformVacuum(long startingSimFrame, CoherenceSync requestingPlayer)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void RequestTake(CoherenceSync requestingPlayer)
		{
		}

		[Command]
		public void PerformTake(long startingSimFrame, CoherenceSync requestingPlayer)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void AckTake(uint clientId)
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void OnlineForceDespawn()
		{
		}

		public virtual bool GetOnlineVacuum(VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
		{
			return false;
		}

		public virtual void GetOnlineTaken()
		{
		}

		protected override void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected virtual void PreOnlineVacuum()
		{
		}

		protected virtual void PreOnlineTake()
		{
		}

		protected void Reset()
		{
		}

		public override void Despawn()
		{
		}

		protected void OnlineDespawn()
		{
		}

		public override void GetTaken()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForAcksAndReturnToPool_003Ed__39))]
		private IEnumerator WaitForAcksAndReturnToPool()
		{
			return null;
		}

		private bool AllConnectedClientsAckedPickup()
		{
			return false;
		}

		protected virtual void ReturnPickupToPool()
		{
		}

		private static float GetMaxAckTimeout()
		{
			return 0f;
		}

		protected bool IsBeingTaken()
		{
			return false;
		}

		protected bool IsBeingVacuumed()
		{
			return false;
		}

		private bool IsPickupAlreadyDestroyed()
		{
			return false;
		}
	}
}

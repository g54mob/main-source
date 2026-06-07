using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.Data;
using Brewery.Stand;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	[RequireComponent(typeof(AStarNPCMotor))]
	public class SimpleNPCLifeBrain : NetworkBehaviour, INPCBrain
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialize_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleNPCLifeBrain _003C_003E4__this;

			private int _003Cretries_003E5__2;

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
			public _003CDelayedInitialize_003Ed__33(int _003C_003E1__state)
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

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("Enable detailed AI state logging for ALL NPCs (static - affects all instances)")]
		[SerializeField]
		private bool enableAIStateLogging;

		private INPCMotor motor;

		private NPCHealthController healthController;

		private NPCRagdollController ragdollController;

		private NPCBrawlCombat combatExecutor;

		private SimpleNPCController npcController;

		private NPCBrawlAgent brawlAgent;

		private NPCContext ctx;

		private RoutineBrain routineBrain;

		private CombatBrain combatBrain;

		private BarInteractor barInteractor;

		private StandInteractor standInteractor;

		private ThreatReceiver threatReceiver;

		private SimpleNPCPersonality personality;

		private BrainMode currentMode;

		private bool isInitialized;

		private float combatEndCooldown;

		private const float COMBAT_END_COOLDOWN_DURATION = 2f;

		private string aiId;

		public BrainMode CurrentMode => default(BrainMode);

		internal RoutineBrain Routine => null;

		internal CombatBrain Combat => null;

		internal BarInteractor Bar => null;

		internal StandInteractor Stand => null;

		public bool IsAtBar => false;

		public bool IsInCombat => false;

		bool INPCBrain.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnValidate()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialize_003Ed__33))]
		private IEnumerator DelayedInitialize()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		private void Initialize()
		{
		}

		private void Cleanup()
		{
		}

		private void TickCurrentMode()
		{
		}

		private void TransitionToMode(BrainMode newMode, string reason = "")
		{
		}

		private void HandleThreatReceived(ThreatInfo threat)
		{
		}

		private void HandleKnockout()
		{
		}

		private void HandleRecovered()
		{
		}

		private void HandleDrinkFinishedForBrawl()
		{
		}

		private void HandleCombatEnded()
		{
		}

		public void ForceGoHome()
		{
		}

		public void ForceGoToBar()
		{
		}

		public bool JoinBrawl(Transform target, ulong targetId)
		{
			return false;
		}

		public void FleeFromRaid()
		{
		}

		public SimpleNPCPersonality GetPersonality()
		{
			return default(SimpleNPCPersonality);
		}

		[ContextMenu("Log NPC Diagnostics")]
		public void LogDiagnostics()
		{
		}

		private void OnDrawGizmosSelected()
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

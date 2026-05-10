using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Combat;
using ScheduleOne.Law;
using ScheduleOne.Noise;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Responses
{
	public class NPCResponses_Civilian : NPCResponses
	{
		public enum EAttackResponse
		{
			None = 0,
			Panic = 1,
			Flee = 2,
			CallPolice = 3,
			Fight = 4
		}

		public enum EThreatType
		{
			None = 0,
			AimedAt = 1,
			GunshotHeard = 2,
			ExplosionHeard = 3
		}

		[CompilerGenerated]
		private sealed class _003CResetAttackResponse_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NPCResponses_Civilian _003C_003E4__this;

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
			public _003CResetAttackResponse_003Ed__8(int _003C_003E1__state)
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

		public bool CanCallPolice;

		private EAttackResponse currentThreatResponse;

		private float lastThreatTime;

		private Coroutine resetCoroutine;

		protected override void Awake()
		{
		}

		private void ScheduleResetCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003CResetAttackResponse_003Ed__8))]
		private IEnumerator ResetAttackResponse()
		{
			return null;
		}

		public override void GunshotHeard(NoiseEvent gunshotSound)
		{
		}

		public override void ExplosionHeard(NoiseEvent explosionSound)
		{
		}

		public override void PlayerFailedPickpocket(Player player)
		{
		}

		protected override void RespondToFirstNonLethalAttack(Player perpetrator, Impact impact)
		{
		}

		protected override void RespondToAnnoyingImpact(Player perpetrator, Impact impact)
		{
		}

		protected override void RespondToLethalAttack(Player perpetrator, Impact impact)
		{
		}

		protected override void RespondToRepeatedNonLethalAttack(Player perpetrator, Impact impact)
		{
		}

		private void RespondToLethalOrRepeatedAttack(Player perpetrator, Impact impact)
		{
		}

		public override void RespondToAimedAt(Player player)
		{
		}

		private void ExecuteThreatResponse(EAttackResponse response, Player target, Vector3 threatOrigin, Crime crime = null)
		{
		}

		private EAttackResponse GetThreatResponse(EThreatType type, Player threatSource)
		{
			return default(EAttackResponse);
		}
	}
}

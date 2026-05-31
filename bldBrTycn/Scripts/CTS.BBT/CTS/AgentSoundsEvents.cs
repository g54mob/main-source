using System;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class AgentSoundsEvents : MonoBehaviour
	{
		private Agent _agent;

		public static event Action<Agent> Stepping;

		public static event Action<Agent> SittingLow;

		public static event Action<Agent> SittingHigh;

		public static event Action<Agent> SittingUp;

		public static event Action<Agent> Talking001;

		public static event Action<Agent> Talking002;

		public static event Action<Agent> Talking003;

		public static event Action<Agent> TalkingCrossArms;

		public static event Action<Agent> TalkingLaugh;

		public static event Action<Agent> CallingWaiter;

		public static event Action<Agent> Drinking;

		public static event Action<Agent> Bitten;

		public static event Action<Agent> BittenDeath;

		public static event Action<Agent> Vomiting;

		public static event Action<Agent> TakingOrder;

		public static event Action<Agent> MakingDrink;

		public static event Action<Agent> Bitting;

		public static event Action<Agent> CorpseFall;

		public static event Action<Agent> Mop;

		public static event Action<Agent> CleaningTableHigh;

		public static event Action<Agent> CleaningTableLow;

		public static event Action<Agent> DropingCorpse;

		private void Awake()
		{
			_agent = GetComponent<Agent>();
		}

		private void OnLaugh()
		{
			AgentSoundsEvents.TalkingLaugh?.Invoke(_agent);
		}

		private void OnTakingOrder()
		{
			AgentSoundsEvents.TakingOrder?.Invoke(_agent);
		}

		private void OnMakingDrink()
		{
			AgentSoundsEvents.MakingDrink?.Invoke(_agent);
		}

		private void OnBitten()
		{
			AgentSoundsEvents.Bitten?.Invoke(_agent);
		}

		private void OnBittenDeath()
		{
			AgentSoundsEvents.BittenDeath?.Invoke(_agent);
		}

		private void OnBitting()
		{
			AgentSoundsEvents.Bitting?.Invoke(_agent);
		}

		private void OnFootstep()
		{
			if (!(_agent.Movement.Velocity.magnitude < 0.1f))
			{
				AgentSoundsEvents.Stepping?.Invoke(_agent);
			}
		}

		private void OnSitLow()
		{
			AgentSoundsEvents.SittingLow?.Invoke(_agent);
		}

		private void OnSitHigh()
		{
			AgentSoundsEvents.SittingHigh?.Invoke(_agent);
		}

		private void OnDrinking()
		{
			AgentSoundsEvents.Drinking?.Invoke(_agent);
		}

		private void OnCallingWaiter()
		{
			AgentSoundsEvents.CallingWaiter?.Invoke(_agent);
		}

		private void OnSittingUp()
		{
			AgentSoundsEvents.SittingUp?.Invoke(_agent);
		}

		private void OnCorpseFall()
		{
			AgentSoundsEvents.CorpseFall?.Invoke(_agent);
		}

		private void OnMop()
		{
			AgentSoundsEvents.Mop?.Invoke(_agent);
		}

		private void OnCleanTableHigh()
		{
			AgentSoundsEvents.CleaningTableHigh?.Invoke(_agent);
		}

		private void OnCleanTableLow()
		{
			AgentSoundsEvents.CleaningTableLow?.Invoke(_agent);
		}

		private void OnCorpseBringDown()
		{
			AgentSoundsEvents.DropingCorpse?.Invoke(_agent);
		}

		private void OnVomit()
		{
			AgentSoundsEvents.Vomiting?.Invoke(_agent);
		}

		private void Talk001()
		{
			AgentSoundsEvents.Talking001?.Invoke(_agent);
		}

		private void Talk002()
		{
			AgentSoundsEvents.Talking002?.Invoke(_agent);
		}

		private void Talk003()
		{
			AgentSoundsEvents.Talking003?.Invoke(_agent);
		}

		private void TalkCrossArms()
		{
			AgentSoundsEvents.TalkingCrossArms?.Invoke(_agent);
		}
	}
}

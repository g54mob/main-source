using System;
using System.Collections;
using Animancer;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class AgentActionBlocked : AgentAction<Agent>
	{
		private readonly string _log;

		public static event Action<Agent> Blocked;

		public AgentActionBlocked(string log)
		{
			base.Name = "Blocked";
			_log = log;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			AgentActionBlocked.Blocked?.Invoke(base.ActionAgent);
			Debug.LogWarning(_log);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Confused, FadeMode.FromStart);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}

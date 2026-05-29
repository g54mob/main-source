using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ActionAgentAutonomy : InstantAction
	{
		[SerializeField]
		private SoftReference<Agent> _agent;

		[SerializeField]
		[ShowIf("HasValue")]
		private bool _autonomyPaused;

		[SerializeField]
		[ShowIf("HasValue")]
		private bool _choreAutonomyPaused;

		private bool HasValue => _agent.HasValue;

		protected override bool PlayAction(ActionSequence sequence)
		{
			Agent agent = _agent.Get();
			if (!agent)
			{
				return false;
			}
			agent.AutonomousActions.Paused = _autonomyPaused;
			if (agent is Worker worker)
			{
				worker.ChoreAssigner.SetActive(!_choreAutonomyPaused);
			}
			return true;
		}
	}
}

using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionAgentStatistics : InstantAction
	{
		[SerializeField]
		private SoftReference<Agent> _agent;

		[SerializeField]
		private bool _statisticsEnabled = true;

		protected override bool PlayAction(ActionSequence sequence)
		{
			Agent agent = _agent.Get();
			if (!agent)
			{
				return false;
			}
			agent.Statistics.Paused = !_statisticsEnabled;
			return true;
		}
	}
}

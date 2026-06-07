using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class PollutionTrigger : TutorialNotificationTriggerBase
	{
		[Header("Trigger 1")]
		[Tooltip("A drifter has over [X] pollution")]
		[SerializeField]
		private int _agentPollutionThreshold;

		[Header("Trigger 2")]
		[Tooltip("[X] drifters have more than 0 pollution")]
		[SerializeField]
		private int _pollutedAgentCountThreshold;

		private bool _isPolluted;

		private int _pollutedAgentCount;

		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			if (!gotTriggered)
			{
				GameEventDispatcher.AddListener(GameEventType.PollutionUpdated, AgentPolluted);
			}
		}

		private void AgentPolluted(GameEvent gameEvent)
		{
			if (!(gameEvent is AgentEvent agentEvent))
			{
				return;
			}
			_pollutedAgentCount = 0;
			foreach (Agent agent in Community.PlayerCommunity.Agents)
			{
				if (agent.Vitals.Pollution.Level > 0f)
				{
					_pollutedAgentCount++;
				}
			}
			if (_pollutedAgentCount >= _pollutedAgentCountThreshold || agentEvent.Agent.Vitals.Pollution.Level >= (float)_agentPollutionThreshold)
			{
				GameEventDispatcher.RemoveListener(GameEventType.PollutionUpdated, AgentPolluted);
				if (Trigger())
				{
					GameEventDispatcher.Dispatch(GameEventType.AgentPollutionThresholdReached);
				}
			}
		}
	}
}

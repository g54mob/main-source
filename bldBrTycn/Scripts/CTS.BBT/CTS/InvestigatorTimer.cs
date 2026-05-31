using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class InvestigatorTimer : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Agent _agent;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			AgentActionEnterBar.AgentEnteredBar += OnAgentEnteredBar;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			AgentActionEnterBar.AgentEnteredBar -= OnAgentEnteredBar;
		}

		private void OnAgentEnteredBar(Agent agent)
		{
			if (!(agent != _agent))
			{
				_agent.Cooldowns.StartCooldown(BBTAgentTags.Investigate);
			}
		}
	}
}

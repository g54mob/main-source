using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Resume Hypnosis")]
	public class AutonomousActionResumeHypnosis : AgentAutonomousAction<CustomerActionHypnosisLoop>
	{
		[SerializeField]
		private int _hasHypnotizedTag = 50;

		protected override CustomerActionHypnosisLoop CreateActionInstance(Agent agent)
		{
			return new CustomerActionHypnosisLoop(null);
		}

		protected override int CalculateScore(Agent agent, CustomerActionHypnosisLoop action)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			action.Target = customer.ControllingVampire;
			if (!customer.ControllingVampire)
			{
				return -1;
			}
			return _hasHypnotizedTag;
		}
	}
}

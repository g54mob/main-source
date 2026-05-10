using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionHypnosisLoopConstructor : ActionConstructor<CustomerActionHypnosisLoop>
	{
		[SerializeField]
		private SoftReference<Agent> _agentToFollow;

		protected override CustomerActionHypnosisLoop ConstructAction()
		{
			return new CustomerActionHypnosisLoop(_agentToFollow);
		}
	}
}

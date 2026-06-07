using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Actions/Use Need Fill Station")]
	public class ActionSOUseNeedFillStation : ActionData
	{
		public override AgentAction InstantiateAction()
		{
			return new AgentActionUseStationNeedFill();
		}
	}
}

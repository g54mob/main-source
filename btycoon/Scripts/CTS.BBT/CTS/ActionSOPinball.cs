using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Actions/Play Pinball")]
	public class ActionSOPinball : ActionData
	{
		public override AgentAction InstantiateAction()
		{
			return new AgentActionPinball();
		}
	}
}

using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Actions/Play Darts")]
	public class ActionSOThrowDarts : ActionData
	{
		public override AgentAction InstantiateAction()
		{
			return new AgentActionPlayDarts();
		}
	}
}

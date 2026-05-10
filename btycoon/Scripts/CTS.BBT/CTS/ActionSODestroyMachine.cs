using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/AI/Actions/Destroy Machine")]
	public class ActionSODestroyMachine : ActionData
	{
		[SerializeField]
		private float _actionDuration = 2f;

		public override AgentAction InstantiateAction()
		{
			return new AgentActionDestroyMachine(_actionDuration);
		}
	}
}

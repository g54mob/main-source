using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public abstract class ActionData : ScriptableObject
	{
		public abstract AgentAction InstantiateAction();
	}
}

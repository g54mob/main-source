using UnityEngine;

namespace CTS.BBT.AI
{
	public abstract class AgentAutonomousAction : ScriptableObject
	{
		[SerializeField]
		private bool _canBeExecutedWhenBusy;

		public bool CanBeExecutedWhenBusy => _canBeExecutedWhenBusy;

		public abstract int CalculateScore(Agent agent, AgentAction action);

		public abstract AgentAction CreateAction(Agent agent);
	}
	public abstract class AgentAutonomousAction<TAction> : AgentAutonomousAction where TAction : AgentAction
	{
		public sealed override int CalculateScore(Agent agent, AgentAction action)
		{
			return CalculateScore(agent, (TAction)action);
		}

		public sealed override AgentAction CreateAction(Agent agent)
		{
			return CreateActionInstance(agent);
		}

		protected abstract TAction CreateActionInstance(Agent agent);

		protected abstract int CalculateScore(Agent agent, TAction action);
	}
}

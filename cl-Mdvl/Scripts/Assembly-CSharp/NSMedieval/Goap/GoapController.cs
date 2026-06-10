using System;
using NSEipix.Base;

namespace NSMedieval.Goap
{
	public class GoapController : MonoSingleton<GoapController>
	{
		public delegate void AgentHandler(Agent agent);

		public delegate void AgentGoalHandler(Agent agent, Goal id);

		public delegate void AgentHandlerIdState(Agent agent, string goalId, GoalCondition state);

		public delegate void AgentCallbackHandler();

		public event AgentHandler AgentSelectedEvent;

		public event AgentHandler AgentDeselectedEvent;

		public event AgentGoalHandler OnNextGoalPlannedEvent;

		public event AgentGoalHandler OnGoalStartedEvent;

		public event AgentHandlerIdState OnGoalEndedEvent;

		public event Action OnStartTicker;

		public void AgentSelected(bool selected, Agent agent)
		{
			if (selected)
			{
				this.AgentSelectedEvent?.Invoke(agent);
			}
			else
			{
				this.AgentDeselectedEvent?.Invoke(agent);
			}
		}

		public void OnNextGoalPlanned(Agent agent, Goal goal)
		{
			this.OnNextGoalPlannedEvent?.Invoke(agent, goal);
		}

		public void OnGoalStarted(Agent agent, Goal goal)
		{
			this.OnGoalStartedEvent?.Invoke(agent, goal);
		}

		public void OnGoalEnded(Agent agent, string goalId, GoalCondition state)
		{
			this.OnGoalEndedEvent?.Invoke(agent, goalId, state);
		}

		public void StartGoapTicker()
		{
			this.OnStartTicker?.Invoke();
		}
	}
}

using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class LockInCellSimultaneousGoal : QuestNumericGoal
	{
		private List<Agent> _prisoners = new List<Agent>();

		public LockInCellSimultaneousGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Cell.AgentCaptured -= OnAgentCaptured;
			Cell.AgentReleased -= OnAgentReleased;
			_prisoners.Clear();
		}

		public override void StartObserving()
		{
			Cell.AgentCaptured += OnAgentCaptured;
			Cell.AgentReleased += OnAgentReleased;
			foreach (Cell item in CTSSingleton<BarFurnitures>.Instance.Enumerate<Cell>())
			{
				if ((bool)item.Victim && !_prisoners.Contains(item.Victim))
				{
					_prisoners.Add(item.Victim);
				}
			}
			SetGoalVariable(_prisoners.Count);
		}

		private void OnAgentReleased(Cell arg1, Agent victim)
		{
			if (_prisoners.Remove(victim))
			{
				AddToGoalVariable(-1);
			}
		}

		private void OnAgentCaptured(Cell cell, Agent agent)
		{
			if (!_prisoners.Contains(agent))
			{
				_prisoners.Add(agent);
				AddToGoalVariable(1);
			}
		}
	}
}

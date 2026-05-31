using System;
using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.AI
{
	public static class Agents
	{
		private static List<Agent> agentList = new List<Agent>();

		public static int Count => agentList.Count;

		public static IEnumerable<Agent> List => agentList;

		public static Agent Get(Index index)
		{
			List<Agent> list = agentList;
			return list[index.GetOffset(list.Count)];
		}

		public static void Add(Agent p_agent)
		{
			Remove(p_agent);
			agentList.Add(p_agent);
		}

		public static void Remove(Agent p_agent)
		{
			agentList.Remove(p_agent);
		}

		public static void ClearAgents()
		{
			agentList.Clear();
		}

		public static bool IsAnyAvailable<TAgent>() where TAgent : Agent
		{
			foreach (Agent agent in agentList)
			{
				if ((object)((!agent) as TAgent) == null)
				{
					return true;
				}
			}
			return false;
		}
	}
}

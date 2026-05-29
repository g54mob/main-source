using System.Collections.Generic;

namespace CTS.BBT.AI
{
	public static class Workers
	{
		private static HashSet<Worker> agentList = new HashSet<Worker>();

		public static IEnumerable<Worker> List => agentList;

		public static void Add(Worker p_agent)
		{
			Remove(p_agent);
			agentList.Add(p_agent);
		}

		public static void Remove(Worker p_agent)
		{
			agentList.Remove(p_agent);
		}

		public static void ClearAgents()
		{
			agentList.Clear();
		}
	}
}

using System.Collections.Generic;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class State
	{
		public SuperState SuperState { get; set; }

		public List<Transition> Leaving { get; } = new List<Transition>();

		public List<Transition> Arriving { get; } = new List<Transition>();

		public string NodeName { get; private set; }

		public string StateName { get; private set; }

		public List<string> EntryActions { get; private set; } = new List<string>();

		public List<string> ExitActions { get; private set; } = new List<string>();

		public State(StateInfo stateInfo)
		{
			NodeName = stateInfo.UnderlyingState.ToString();
			StateName = stateInfo.UnderlyingState.ToString();
			foreach (ActionInfo entryAction in stateInfo.EntryActions)
			{
				if (entryAction.FromTrigger == null)
				{
					EntryActions.Add(entryAction.Method.Description);
				}
			}
			foreach (InvocationInfo exitAction in stateInfo.ExitActions)
			{
				ExitActions.Add(exitAction.Description);
			}
		}

		public State(string nodeName)
		{
			NodeName = nodeName;
			StateName = null;
		}
	}
}

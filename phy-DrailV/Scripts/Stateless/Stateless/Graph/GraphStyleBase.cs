using System;
using System.Collections.Generic;
using System.Linq;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public abstract class GraphStyleBase
	{
		public abstract string GetPrefix();

		public abstract string GetInitialTransition(StateInfo initialState);

		public abstract string FormatOneState(State state);

		public abstract string FormatOneCluster(SuperState stateInfo);

		public abstract string FormatOneDecisionNode(string nodeName, string label);

		public virtual List<string> FormatAllTransitions(List<Transition> transitions)
		{
			List<string> list = new List<string>();
			if (transitions == null)
			{
				return list;
			}
			foreach (Transition transition in transitions)
			{
				string text = null;
				if (transition is StayTransition stayTransition)
				{
					text = (stayTransition.ExecuteEntryExitActions ? FormatOneTransition(stayTransition.SourceState.NodeName, stayTransition.Trigger.UnderlyingTrigger.ToString(), stayTransition.DestinationEntryActions.Select((ActionInfo x) => x.Method.Description), stayTransition.SourceState.NodeName, stayTransition.Guards.Select((InvocationInfo x) => x.Description)) : FormatOneTransition(stayTransition.SourceState.NodeName, stayTransition.Trigger.UnderlyingTrigger.ToString(), null, stayTransition.SourceState.NodeName, stayTransition.Guards.Select((InvocationInfo x) => x.Description)));
				}
				else if (transition is FixedTransition fixedTransition)
				{
					text = FormatOneTransition(fixedTransition.SourceState.NodeName, fixedTransition.Trigger.UnderlyingTrigger.ToString(), fixedTransition.DestinationEntryActions.Select((ActionInfo x) => x.Method.Description), fixedTransition.DestinationState.NodeName, fixedTransition.Guards.Select((InvocationInfo x) => x.Description));
				}
				else
				{
					if (!(transition is DynamicTransition dynamicTransition))
					{
						throw new ArgumentException("Unexpected transition type");
					}
					text = FormatOneTransition(dynamicTransition.SourceState.NodeName, dynamicTransition.Trigger.UnderlyingTrigger.ToString(), dynamicTransition.DestinationEntryActions.Select((ActionInfo x) => x.Method.Description), dynamicTransition.DestinationState.NodeName, new List<string> { dynamicTransition.Criterion });
				}
				if (text != null)
				{
					list.Add(text);
				}
			}
			return list;
		}

		public virtual string FormatOneTransition(string sourceNodeName, string trigger, IEnumerable<string> actions, string destinationNodeName, IEnumerable<string> guards)
		{
			throw new InvalidOperationException("If you use IGraphStyle.FormatAllTransitions() you must implement an override of FormatOneTransition()");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class UmlDotGraphStyle : GraphStyleBase
	{
		public override string GetPrefix()
		{
			return "digraph {\ncompound=true;\nnode [shape=Mrecord]\nrankdir=\"LR\"\n";
		}

		public override string FormatOneCluster(SuperState stateInfo)
		{
			string text = "";
			StringBuilder stringBuilder = new StringBuilder(stateInfo.StateName ?? "");
			if (stateInfo.EntryActions.Count > 0 || stateInfo.ExitActions.Count > 0)
			{
				stringBuilder.Append("\\n----------");
				stringBuilder.Append(string.Concat(stateInfo.EntryActions.Select((string act) => "\\nentry / " + act)));
				stringBuilder.Append(string.Concat(stateInfo.ExitActions.Select((string act) => "\\nexit / " + act)));
			}
			text = "\nsubgraph \"cluster" + stateInfo.NodeName + "\"\n\t{\n\tlabel = \"" + stringBuilder.ToString() + "\"\n";
			foreach (State subState in stateInfo.SubStates)
			{
				text += FormatOneState(subState);
			}
			return text + "}\n";
		}

		public override string FormatOneState(State state)
		{
			if (state.EntryActions.Count == 0 && state.ExitActions.Count == 0)
			{
				return "\"" + state.StateName + "\" [label=\"" + state.StateName + "\"];\n";
			}
			string text = "\"" + state.StateName + "\" [label=\"" + state.StateName + "|";
			List<string> list = new List<string>();
			list.AddRange(state.EntryActions.Select((string act) => "entry / " + act));
			list.AddRange(state.ExitActions.Select((string act) => "exit / " + act));
			return string.Concat(text + string.Join("\\n", list), "\"];\n");
		}

		public override string FormatOneTransition(string sourceNodeName, string trigger, IEnumerable<string> actions, string destinationNodeName, IEnumerable<string> guards)
		{
			string text = trigger ?? "";
			if (actions != null && actions.Count() > 0)
			{
				text = text + " / " + string.Join(", ", actions);
			}
			if (guards.Any())
			{
				foreach (string guard in guards)
				{
					if (text.Length > 0)
					{
						text += " ";
					}
					text = text + "[" + guard + "]";
				}
			}
			return FormatOneLine(sourceNodeName, destinationNodeName, text);
		}

		public override string FormatOneDecisionNode(string nodeName, string label)
		{
			return "\"" + nodeName + "\" [shape = \"diamond\", label = \"" + label + "\"];\n";
		}

		public override string GetInitialTransition(StateInfo initialState)
		{
			string text = initialState.UnderlyingState.ToString();
			string text2 = Environment.NewLine + " init [label=\"\", shape=point];";
			text2 = text2 + Environment.NewLine + " init -> \"" + text + "\"[style = \"solid\"]";
			return text2 + Environment.NewLine + "}";
		}

		internal string FormatOneLine(string fromNodeName, string toNodeName, string label)
		{
			return "\"" + fromNodeName + "\" -> \"" + toNodeName + "\" [style=\"solid\", label=\"" + label + "\"];";
		}
	}
}

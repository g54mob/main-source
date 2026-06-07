using System;
using System.Collections.Generic;
using System.Linq;
using Stateless.Reflection;

namespace Stateless.Graph
{
	public class StateGraph
	{
		private StateInfo initialState;

		public Dictionary<string, State> States { get; private set; } = new Dictionary<string, State>();

		public List<Transition> Transitions { get; private set; } = new List<Transition>();

		public List<Decision> Decisions { get; private set; } = new List<Decision>();

		public StateGraph(StateMachineInfo machineInfo)
		{
			initialState = machineInfo.InitialState;
			AddSuperstates(machineInfo);
			AddSingleStates(machineInfo);
			AddTransitions(machineInfo);
			ProcessOnEntryFrom(machineInfo);
		}

		public string ToGraph(GraphStyleBase style)
		{
			string text = style.GetPrefix().Replace("\n", Environment.NewLine);
			foreach (State item in States.Values.Where((State x) => x is SuperState))
			{
				text += style.FormatOneCluster((SuperState)item).Replace("\n", Environment.NewLine);
			}
			foreach (State value in States.Values)
			{
				if (!(value is SuperState) && !(value is Decision) && value.SuperState == null)
				{
					text += style.FormatOneState(value).Replace("\n", Environment.NewLine);
				}
			}
			foreach (Decision decision in Decisions)
			{
				text += style.FormatOneDecisionNode(decision.NodeName, decision.Method.Description).Replace("\n", Environment.NewLine);
			}
			foreach (string item2 in style.FormatAllTransitions(Transitions))
			{
				text = text + Environment.NewLine + item2;
			}
			return text + style.GetInitialTransition(initialState);
		}

		private void ProcessOnEntryFrom(StateMachineInfo machineInfo)
		{
			foreach (StateInfo state2 in machineInfo.States)
			{
				State state = States[state2.UnderlyingState.ToString()];
				foreach (ActionInfo entryAction in state2.EntryActions)
				{
					if (entryAction.FromTrigger == null)
					{
						continue;
					}
					foreach (Transition item in state.Arriving)
					{
						if (item.ExecuteEntryExitActions && item.Trigger.UnderlyingTrigger.ToString() == entryAction.FromTrigger)
						{
							item.DestinationEntryActions.Add(entryAction);
						}
					}
				}
			}
		}

		private void AddTransitions(StateMachineInfo machineInfo)
		{
			foreach (StateInfo state3 in machineInfo.States)
			{
				State state = States[state3.UnderlyingState.ToString()];
				foreach (FixedTransitionInfo fixedTransition in state3.FixedTransitions)
				{
					State state2 = States[fixedTransition.DestinationState.UnderlyingState.ToString()];
					if (state == state2)
					{
						StayTransition stayTransition = new StayTransition(state, fixedTransition.Trigger, fixedTransition.GuardConditionsMethodDescriptions, !fixedTransition.IsInternalTransition);
						Transitions.Add(stayTransition);
						state.Leaving.Add(stayTransition);
						state.Arriving.Add(stayTransition);
						if (!stayTransition.ExecuteEntryExitActions)
						{
							continue;
						}
						foreach (ActionInfo item5 in state3.EntryActions.Where((ActionInfo a) => a.FromTrigger == null))
						{
							stayTransition.DestinationEntryActions.Add(item5);
						}
					}
					else
					{
						FixedTransition item = new FixedTransition(state, state2, fixedTransition.Trigger, fixedTransition.GuardConditionsMethodDescriptions);
						Transitions.Add(item);
						state.Leaving.Add(item);
						state2.Arriving.Add(item);
					}
				}
				foreach (DynamicTransitionInfo dynamicTransition in state3.DynamicTransitions)
				{
					Decision decision = new Decision(dynamicTransition.DestinationStateSelectorDescription, Decisions.Count + 1);
					Decisions.Add(decision);
					FixedTransition item2 = new FixedTransition(state, decision, dynamicTransition.Trigger, dynamicTransition.GuardConditionsMethodDescriptions);
					Transitions.Add(item2);
					state.Leaving.Add(item2);
					decision.Arriving.Add(item2);
					if (dynamicTransition.PossibleDestinationStates == null)
					{
						continue;
					}
					foreach (DynamicStateInfo possibleDestinationState in dynamicTransition.PossibleDestinationStates)
					{
						States.TryGetValue(possibleDestinationState.DestinationState, out var value);
						if (value != null)
						{
							DynamicTransition item3 = new DynamicTransition(decision, value, dynamicTransition.Trigger, possibleDestinationState.Criterion);
							Transitions.Add(item3);
							decision.Leaving.Add(item3);
							value.Arriving.Add(item3);
						}
					}
				}
				foreach (IgnoredTransitionInfo ignoredTrigger in state3.IgnoredTriggers)
				{
					StayTransition item4 = new StayTransition(state, ignoredTrigger.Trigger, ignoredTrigger.GuardConditionsMethodDescriptions, executeEntryExitActions: false);
					Transitions.Add(item4);
					state.Leaving.Add(item4);
					state.Arriving.Add(item4);
				}
			}
		}

		private void AddSingleStates(StateMachineInfo machineInfo)
		{
			foreach (StateInfo state in machineInfo.States)
			{
				if (!States.ContainsKey(state.UnderlyingState.ToString()))
				{
					States[state.UnderlyingState.ToString()] = new State(state);
				}
			}
		}

		private void AddSuperstates(StateMachineInfo machineInfo)
		{
			foreach (StateInfo item in machineInfo.States.Where(delegate(StateInfo sc)
			{
				ICollection<StateInfo> substates = sc.Substates;
				return substates != null && substates.Count() > 0 && sc.Superstate == null;
			}))
			{
				SuperState superState = new SuperState(item);
				States[item.UnderlyingState.ToString()] = superState;
				AddSubstates(superState, item.Substates);
			}
		}

		private void AddSubstates(SuperState superState, IEnumerable<StateInfo> substates)
		{
			foreach (StateInfo substate in substates)
			{
				if (!States.ContainsKey(substate.UnderlyingState.ToString()))
				{
					if (substate.Substates.Count != 0)
					{
						SuperState superState2 = new SuperState(substate);
						States[substate.UnderlyingState.ToString()] = superState2;
						superState.SubStates.Add(superState2);
						superState2.SuperState = superState;
						AddSubstates(superState2, substate.Substates);
					}
					else
					{
						State state = new State(substate);
						States[substate.UnderlyingState.ToString()] = state;
						superState.SubStates.Add(state);
						state.SuperState = superState;
					}
				}
			}
		}
	}
}
